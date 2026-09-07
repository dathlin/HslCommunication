using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.MQTT;
using Newtonsoft.Json;

namespace HslCommunicationDemo.Plugins
{
	public partial class FormPluginsInstall : Form
	{
		public FormPluginsInstall( EdgeServerSettings serverSettings, string pluginsType )
		{
			InitializeComponent( );
			this.serverSettings = serverSettings;
			this.pluginsType = pluginsType;
			//this.Icon = Util.ConvertToIcon( Properties.Resources.Library );

			this.hslAction = new Action<long, long>( UpdateProgress );
			hslProgressBar1.Visible = false;
		}

		/// <summary>
		/// 从远程服务器安装插件的实例化
		/// </summary>
		/// <param name="serverSettings"></param>
		/// <param name="pluginsType"></param>
		/// <param name="pluginsServer"></param>
		public FormPluginsInstall( EdgeServerSettings serverSettings, string pluginsType, PluginsServerInfo pluginsServer, IEdgePlugins pluginsDefinition )
		{
			InitializeComponent( );
			this.serverSettings = serverSettings;
			this.pluginsType = pluginsType;
			//this.Icon = Util.ConvertToIcon( Properties.Resources.Library );
			this.hslAction = new Action<long, long>( UpdateProgress );

			button_selectfile.Visible = false;
			label1.Text = "下载进度:";
			textBox2.ReadOnly = true;
			button_upload.Enabled = false;
			button_upload.Text = "正在下载...";
			button_upload.ForeColor = Color.Black;

			this.isInstallFromPluginsServer = true;
			this.pluginsServerInfo = pluginsServer;
			this.pluginsDefinition = pluginsDefinition;

			textBox2.Text = pluginsDefinition.DllName;
		}

		private Action<long, long> hslAction;

		public void UpdateProgress( long already, long total )
		{
			if (InvokeRequired)
			{
				Invoke( hslAction, already, total );
				return;
			}

			hslProgressBar1.Value = (int)(already * 100 / total);
		}

		private void FormPluginsInstall_Load( object sender, EventArgs e )
		{
			button_selectfile.Click += Button_selectfile_Click;
			button_upload.Click += Button_upload_Click;
		}

		private void FormPluginsInstall_Shown( object sender, EventArgs e )
		{
			// 如果是从远程服务器安装/更新插件，则直接启动后台线程
			if (this.isInstallFromPluginsServer && this.pluginsServerInfo != null)
			{
				ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadInstallFromPluginsServer ), new object( ) );
			}
		}

		private void ThreadInstallFromPluginsServer( object objectIngore )
		{
			// 先获取网关的框架
			HslCommunication.Core.HslHelper.ThreadSleep( 100 );

			OperateResult<string, byte[]> download = this.pluginsServerInfo.Client.Read( 
				"PluginsServer/DownloadPlugin", Encoding.UTF8.GetBytes( new { type = this.pluginsType, id = this.pluginsDefinition.DllName, version = "" }.ToJsonString( ) ), receiveProgress: this.UpdateProgress );

			if (download.IsSuccess == false)
			{
				Invoke( new Action( ( ) =>
				{
					MessageBox.Show( $"下载插件 [{this.pluginsDefinition.DllName}] 失败, 原因: " + download.Message );
				} ) );
				return;
			}

			try
			{

				XElement pluginXml = XElement.Parse( JsonConvert.DeserializeObject( Encoding.UTF8.GetString( download.Content2 ) ).ToString( ) );
				Dictionary<string, byte[]> files = new Dictionary<string, byte[]>( );

				string tagName = "FileFramework";
				StringBuilder stringBuilder = new StringBuilder( ); 
				foreach (XElement xml in pluginXml.Element( tagName ).Elements( "File" ))
				{
					string name = xml.Element( "Name" ).Value;
					byte[] data = Convert.FromBase64String( xml.Element( "Content" ).Value );

					files.Add( name, data );
					stringBuilder.AppendLine( name );
				}

				HslCommunication.Core.HslHelper.ThreadSleep( 100 );
				Invoke( new Action( ( ) =>
				{
					textBox1.Text = stringBuilder.ToString( );
					button_upload.Text = "正在上传...";
					progressBar1.Value = 0;
				} ) );


				OperateResult<int> existCheck = this.serverSettings.CheckRegisterPluginsExist( this.pluginsDefinition.DllName );
				if (!existCheck.IsSuccess)
				{
					// 检查失败
					Invoke( new Action( ( ) =>
					{
						button_upload.Enabled = true;
						MessageBox.Show( "检查插件是否存在失败：" + existCheck.Message );
						return;
					} ) );
				}

				int fileCurrent = 0;
				foreach (var file in files)
				{
					fileCurrent++;
					Invoke( new Action( ( ) =>
					{
						label_progress.Text = $"({fileCurrent}/{files.Count})";
					} ) );

					OperateResult upload = this.serverSettings.UploadPluginsFile( this.pluginsDefinition.DllName, file.Key, file.Value );
					if (!upload.IsSuccess)
					{
						Invoke( new Action( ( ) =>
						{
							button_upload.Enabled = true;
							MessageBox.Show( $"插件[{file}]上传失败，请重新安装！\r\n{upload.Message}" );
							return;
						} ) );

					}
					HslCommunication.Core.HslHelper.ThreadSleep( 200 );
				}
				Invoke( new Action( ( ) =>
				{
					button_upload.Enabled = true;
				} ) );

				if (existCheck.Content == 0)
				{
					// 插件新安装
					OperateResult install = this.serverSettings.LoadRegisterPlugins( this.pluginsDefinition.DllName );
					Invoke( new Action( ( ) =>
					{
						if (!install.IsSuccess)
						{
							MessageBox.Show( $"插件[{this.pluginsDefinition.DllName}]上传成功，但是加载失败：" + install.Message );
						}
						else
						{
							//MessageBox.Show( $"插件[{this.pluginsDefinition.DllName}]上传成功，并且成功加载！" );
							button_upload.Text = "安装成功";
							// 刷新插件
						}
					} ) );
				}
				else
				{
					Invoke( new Action( ( ) =>
					{
						// 更新更新
						// MessageBox.Show( $"插件[{this.pluginsDefinition.DllName}]上传成功，重启网关服务器生效！" );
						button_upload.Text = "安装成功，重启生效";
					} ) );
				}
			}
			catch( Exception ex )
			{
				Invoke( new Action( ( ) =>
				{
					button_upload.Enabled = true;
					MessageBox.Show( $"插件[{this.pluginsDefinition.DllName}]上传失败，请重新安装！\r\n{ex.Message}" );
					return;
				} ) );
			}
		}

		private void Button_selectfile_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			openFileDialog.Title = "选择插件文件";
			if (openFileDialog.ShowDialog( ) == DialogResult.OK)
			{
				string[] files = openFileDialog.FileNames;
				string pluginsName = string.Empty;
				foreach ( string file in files)
				{
					FileInfo fileInfo = new FileInfo( file );
					if (fileInfo.Name.EndsWith( ".dll" ))
					{
						pluginsName = fileInfo.Name;
						break;
					}
				}
				textBox1.Lines = files;
				if (string.IsNullOrEmpty( textBox2.Text ))
					textBox2.Text = pluginsName;
			}
			openFileDialog.Dispose( );
		}

		private void Button_upload_Click( object sender, EventArgs e )
		{
			if (this.isInstallFromPluginsServer && this.pluginsServerInfo != null)
			{
				ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadInstallFromPluginsServer ), new object( ) );
				return;
			}

			// 先检查插件是否存在
			string pluginsName = textBox2.Text;


			if (this.serverSettings == null) return;
			button_upload.Enabled = false;
			OperateResult<int> existCheck = this.serverSettings.CheckRegisterPluginsExist( pluginsName );
			if (!existCheck.IsSuccess)
			{
				// 检查失败
				button_upload.Enabled = true;
				MessageBox.Show( "检查插件是否存在失败：" + existCheck.Message );
				return;
			}
			if (existCheck.Content == 1)
			{
				if (MessageBox.Show( "插件已经存在，是否进行覆盖？", "覆盖确认", MessageBoxButtons.YesNo ) == DialogResult.No)
				{
					button_upload.Enabled = true;
					return;
				}
			}

			string[] files = textBox1.Lines;
			if (files == null || files.Length == 0)
			{
				button_upload.Enabled = true;
				MessageBox.Show( "当前没有插件文件需要上传" );
				return;
			}

			progressBar1.Value = 0;
			int fileCurrent = 0;
			foreach (string file in files)
			{
				fileCurrent++;
				label_progress.Text = $"({fileCurrent}/{files.Length})";
				FileInfo fileInfo = new FileInfo( file );
				if (File.Exists( file ))
				{
					OperateResult upload = this.serverSettings.UploadPluginsFile( pluginsName, fileInfo.Name, File.ReadAllBytes( file ) );
					if (!upload.IsSuccess)
					{
						button_upload.Enabled = true;
						MessageBox.Show( $"插件[{file}]上传失败，请重新上传！\r\n{upload.Message}" );
						return;
					}
				}
			}
			button_upload.Enabled = true;

			if (existCheck.Content == 0)
			{
				// 插件新安装
				OperateResult install = this.serverSettings.LoadRegisterPlugins( pluginsName );
				if (!install.IsSuccess)
				{
					MessageBox.Show( $"插件[{pluginsName}]上传成功，但是加载失败：" + install.Message );
				}
				else
				{
					MessageBox.Show( $"插件[{pluginsName}]上传成功，并且成功加载！" );
					// 刷新插件
				}
			}
			else
			{
				// 更新更新
				MessageBox.Show( $"插件[{pluginsName}]上传成功，重启网关服务器生效！" );
			}
		}

		private void SendProgressReqport( long already, long total )
		{
			if (InvokeRequired && IsHandleCreated)
			{
				try
				{
					Invoke( new Action<long, long>( SendProgressReqport ), already, total );
				}
				catch { }
				return;
			}

			progressBar1.Maximum = (int)total;
			progressBar1.Value = (int)already;
		}


		private EdgeServerSettings serverSettings;
		private string pluginsType;
		private bool isInstallFromPluginsServer = false;
		private PluginsServerInfo pluginsServerInfo;
		private IEdgePlugins pluginsDefinition;

	}
}
