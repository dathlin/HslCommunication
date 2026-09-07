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
using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo.Plugins
{
	public partial class FormPluginsManagement : HslFormContent
	{
		public FormPluginsManagement( ILogNet logNet, EdgeServerSettings serverSettings )
		{
			InitializeComponent( );
			this.log = logNet;
			this.serverSettings = serverSettings;

			this.buttons.Add( hslButton1 );

			hslButton1.Click +=HslButton1_Click;

			hslButton1.Selected = true;
			hslButton1.ForeColor = Color.White;


			this.pluginsListControl1.PluginSelectEvent += PluginsListControl1_PluginSelectEvent;
			this.pluginsDetailsControl1.PluginUnloadEvent += PluginsDetailsControl1_PluginUnloadEvent;
			this.pluginsDetailsControl1.PluginInstallEvent += PluginsDetailsControl1_PluginInstallEvent;
			this.KeyDown += this.pluginsListControl1.ItemControl_KeyDown;
			this.button_search.Click += Button_search_Click;
			this.textBox_search.KeyDown += TextBox_search_KeyDown;
			this.button_install.Click += Button_install_Click;
			this.linkLabel_refresh.Click += LinkLabel_refresh_Click;

			// 远程服务器的信息列表加载
			this.serverInfosPath = Path.Combine( Application.StartupPath, "PluginsServerInfos.txt" );
			if (File.Exists( serverInfosPath ) )
			{
				try
				{
					JObject json = JObject.Parse( File.ReadAllText( serverInfosPath, Encoding.UTF8 ) );
					if(json.ContainsKey( "Selected" ))
					{
						this.selectedServerInfo = json["Selected"].Value<int>( );
					}
					if (json.ContainsKey( "Servers" ))
					{
						this.serverInfos = (json["Servers"] as JArray).ToObject<List<PluginsServerInfo>>( );
					}
				}
				catch
				{

				}
			}

			if (this.serverInfos == null || this.serverInfos.Count == 0)
			{
				this.serverInfos = new List<PluginsServerInfo>( )
				{
					CreateDefaultServerInfo( )
				};
			}

			comboBox1.DataSource = this.serverInfos;
			if (this.selectedServerInfo >= this.serverInfos.Count) this.selectedServerInfo = 0;
			if (this.serverInfos.Count > 0)
			{
				comboBox1.SelectedIndex = this.selectedServerInfo;
			}

			comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
		}

		private PluginsServerInfo CreateDefaultServerInfo( )
		{
			return new PluginsServerInfo
			{
				Name = "plugins.org",
				IpAddress = "118.195.180.167",
				Port = 7792
			};
		}

		private void SaveServerSetting( int selectIndex, List<PluginsServerInfo> list )
		{
			JObject json = new JObject( );
			json.Add( "Selected", new JValue( selectIndex ) );
			json.Add( "Servers", JArray.FromObject( list ) );
			try
			{
				File.WriteAllText( serverInfosPath, json.ToString( ), Encoding.UTF8 );
			}
			catch( Exception ex )
			{
				MessageBox.Show( "保存失败:" + ex.Message );
			}
		}

		private async void HslButton1_Click( object sender, EventArgs e )
		{
			await SetButtonSelect( hslButton1 );
		}

		public async Task SetButtonSelect( HslButton hslButton )
		{
			foreach (HslButton button in buttons)
			{
				if (button == hslButton) continue;
				button.Selected = false;
				button.ForeColor = Color.DimGray;
			}

			// 切换当前插件的信息
			hslButton.Selected = true;
			hslButton.ForeColor = Color.White;

			if (hslButton1.Selected)
			{
				// 显示设备插件
				this.pluginsType = "HslDemo";
			}

			if (this.viewMode == 1)
			{
				this.textBox_search.Text = "";
				RefreshPluginsServer( );
			}
			else
				await RefreshPlugins( this.pluginsType );
		}

		private void FormPluginsManagement_Load( object sender, EventArgs e )
		{
			if (this.serverSettings != null)
			{
				Text = "Plugins-Demo";
			}

			// 默认界面为浏览插件时间
			this.viewMode = 1;
			label2.BackColor = Color.LightGreen;
			label2.ForeColor = Color.Black;
			label1.BackColor = this.BackColor;
			label1.ForeColor = Color.DarkGray;
		}



		private async void LinkLabel_refresh_Click( object sender, EventArgs e )
		{
			if (this.viewMode == 1)
				RefreshPluginsServer( );
			else
			{
				await RefreshPlugins( this.pluginsType );
			}
		}

		private async void Button_install_Click( object sender, EventArgs e )
		{
			// 安装本地插件
			using (FormPluginsInstall form = new FormPluginsInstall( this.serverSettings, this.pluginsType ))
			{
				form.ShowDialog( );
			}
			await RefreshPlugins( this.pluginsType );
		}

		private void TextBox_search_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.Enter)
			{
				button_search.PerformClick( );
			}
			else
			{
				this.pluginsListControl1.ItemControl_KeyDown(sender, e);
			}
		}

		private void Button_search_Click( object sender, EventArgs e )
		{
			if (this.viewMode == 1)
			{
				RefreshPluginsServer( textBox_search.Text );
			}
			else
			{
				this.pluginsListControl1.SetSearchCondition( textBox_search.Text );
			}
		}

		private void PluginsDetailsControl1_PluginUnloadEvent( IEdgePlugins pluginsDefinition )
		{
			if (this.serverSettings == null) return;
			if (MessageBox.Show( $"是否确认真的卸载插件：{pluginsDefinition.DllName}", "Unload Plugins", MessageBoxButtons.YesNo ) == DialogResult.Yes)
			{
				OperateResult unload = this.serverSettings.UnloadRegisterPlugins( pluginsDefinition.DllName );
				if (unload.IsSuccess)
				{
					MessageBox.Show( "卸载插件成功，软件重启生效。" );
				}
				else
				{
					MessageBox.Show( "卸载插件失败：" + unload.Message );
				}
			}
		}

		private async void PluginsDetailsControl1_PluginInstallEvent( IEdgePlugins pluginsDefinition )
		{
			// 安装一个插件
			if (this.serverSettings == null) return;

			PluginsServerInfo rpc = GetPluginsServerRpc( );
			if (rpc == null)
			{
				MessageBox.Show( "当前没有可用的远程连接参数，需要配置一个。" );
				return;
			}
			OperateResult connect = rpc.Client.ConnectServer( );
			if (!connect.IsSuccess)
			{
				MessageBox.Show( $"当前连接服务器[{rpc.Name}]失败：" + connect.Message );
				return;
			}

			if (pluginsDefinition is ServerPluginItem serverPluginItem)
			{
				if (serverPluginItem.FrameworkFiles == null || serverPluginItem.FrameworkFiles.Count == 0)
				{
					MessageBox.Show( $"当前的插件不包含框架[Net Framework]，无法安装到网关服务器" );
					return;
				}
			}

			using (FormPluginsInstall form = new FormPluginsInstall( this.serverSettings, this.pluginsType, rpc, pluginsDefinition ))
			{
				form.ShowDialog();
				rpc.Client?.ConnectClose( );
				await RefreshPlugins( this.pluginsType );
			}
		}

		private void PluginsListControl1_PluginSelectEvent( IEdgePlugins pluginsDefinition )
		{
			this.pluginsDetailsControl1.SetPluginsDefinition( pluginsDefinition );
		}

		public void SetPlugins( IEdgePlugins[] pluginsDefinitions )
		{
			this.pluginsListControl1.SetPlugins( pluginsDefinitions );
		}

		public async Task RefreshPlugins( string pluginsType = "" )
		{
			this.pluginsListControl1.SetPlugins( new IEdgePlugins[] { } );

			//serverSettings.NodeImages.AddImageItem( readPlugins.Content )
			if (EdgeServerSettings.Plugins != null)
				this.pluginsListControl1.SetPlugins( EdgeServerSettings.Plugins.Values.ToArray( ) );
		}

		private List<HslButton> buttons = new List<HslButton>( );
		private EdgeServerSettings serverSettings;
		private ILogNet log;
		private string pluginsType = "HslDemo";
		private int viewMode = 0; // 0 : 已安装  1: 浏览插件市场

		private List<PluginsServerInfo> serverInfos;
		private int selectedServerInfo = 0;
		private string serverInfosPath = string.Empty;

		private PluginsServerInfo GetPluginsServerRpc()
		{
			if (comboBox1.SelectedItem is PluginsServerInfo pluginsServer)
			{
				if (pluginsServer.Client == null)
				{
					pluginsServer.Client = new MqttSyncClient( new MqttConnectionOptions( )
					{
						IpAddress = pluginsServer.IpAddress,
						Port = pluginsServer.Port,
						Credentials = new MqttCredential( "guest", "guest" ),
					} );
					pluginsServer.Client.CommunicationPipe.IsPersistentConnection = false;  // 短连接
				}

				return pluginsServer;
			}
			else
			{
				PluginsServerInfo serverInfo = CreateDefaultServerInfo( );
				serverInfo.Client = new MqttSyncClient( new MqttConnectionOptions( )
				{
					IpAddress = serverInfo.IpAddress,
					Port = serverInfo.Port,
					Credentials = new MqttCredential( "guest", "guest" ),
				} );
				serverInfo.Client.CommunicationPipe.IsPersistentConnection = false;  // 短连接
				return serverInfo;
			}
		}

		private void RefreshPluginsServer( string search = "" )
		{
			this.pluginsListControl1.SetPlugins( new IEdgePlugins[0] );
			PluginsServerInfo rpc = GetPluginsServerRpc( );
			OperateResult<List<ServerPluginItem>> read = rpc.Client.ReadRpc<List<ServerPluginItem>>( "PluginsServer/GetPluginsList", new { type = this.pluginsType, search = search } );
			if (read.IsSuccess == false)
			{
				MessageBox.Show( $"Connect server[{rpc.Name}] failed: " + read.Message );
				rpc.Client.ConnectClose( );
			}
			else
			{
				this.pluginsListControl1.SetPlugins( read.Content.ToArray( ) );
			}
		}

		private void label2_Click( object sender, EventArgs e )
		{
			// 切换浏览插件市场
			this.viewMode = 1;
			label2.BackColor = Color.LightGreen;
			label2.ForeColor = Color.Black;
			label1.BackColor = this.BackColor;
			label1.ForeColor = Color.DarkGray;

			RefreshPluginsServer( );
		}

		private async void label1_Click( object sender, EventArgs e )
		{
			// 切换浏览已安装
			this.viewMode = 0;

			label2.BackColor = this.BackColor;
			label2.ForeColor = Color.DarkGray;
			label1.BackColor = Color.LightGreen;
			label1.ForeColor = Color.Black;

			textBox_search.Text = "";
			// 刷新本地的插件信息
			await RefreshPlugins( this.pluginsType );
		}

		private void label4_Click( object sender, EventArgs e )
		{
			// 配置当前的资源列表
			using (FormPluginsServerSetting serverSetting = new FormPluginsServerSetting( this.serverInfos ))
			{
				if (serverSetting.ShowDialog( ) == DialogResult.OK)
				{
					this.serverInfos = serverSetting.ServerInfoSettings;
					comboBox1.DataSource = this.serverInfos;

					this.selectedServerInfo = comboBox1.SelectedIndex;
					// 保存本地
					SaveServerSetting( this.selectedServerInfo, this.serverInfos );
				}
			}
		}



		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (this.serverInfos.Count > 1)
			{
				// 保存本地
				this.selectedServerInfo = comboBox1.SelectedIndex;
				SaveServerSetting( this.selectedServerInfo, this.serverInfos );
			}
		}
	}

	public class PluginsServerInfo
	{
		public string Name { get; set; }

		public string IpAddress { get; set; }

		public int Port { get; set; }

		[JsonIgnore]
		public MqttSyncClient Client { get; set; }

		public override string ToString( )
		{
			return Name;
		}
	}
}
