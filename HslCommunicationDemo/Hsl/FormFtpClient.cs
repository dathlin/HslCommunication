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
using HslCommunication.Core.Pipe;
using HslCommunication.Enthernet;
using HslCommunication.Enthernet.Ftp;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.MQTT;

namespace HslCommunicationDemo
{
	public partial class FormFtpClient : HslFormContent
	{
		public FormFtpClient( )
		{
			InitializeComponent( );

			localFolder = Application.StartupPath + @"\FtpFiles";
		}

		private void FormFileClient_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine", Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
			imageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );
			imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );
			imageList.Images.Add( "Method_636", Properties.Resources.Method_636 );
			imageList.Images.Add( "Module_648", Properties.Resources.Module_648 );
			imageList.Images.Add( "Structure_507", Properties.Resources.Structure_507 );
			imageList.Images.Add( "loading", Properties.Resources.loading );
			imageList.Images.Add( "file", Properties.Resources.file );
			imageList.Images.Add( "dll", Properties.Resources.dll );
			imageList.Images.Add( "exe", Properties.Resources.exe );
			imageList.Images.Add( "xml", Properties.Resources.xml );
			imageList.Images.Add( "png", Properties.Resources.png );
			imageList.Images.Add( "doc", Properties.Resources.doc );
			imageList.Images.Add( "chm", Properties.Resources.chm );
			imageList.Images.Add( "ppt", Properties.Resources.ppt );
			imageList.Images.Add( "xls", Properties.Resources.xls );
			imageList.Images.Add( "vsd", Properties.Resources.vsd );
			imageList.Images.Add( "pdf", Properties.Resources.pdf );
			imageList.Images.Add( "ttf", Properties.Resources.ttf );
			imageList.Images.Add( "txt", Properties.Resources.txt );
			imageList.Images.Add( "js", Properties.Resources.js );
			imageList.Images.Add( "jsp", Properties.Resources.jsp );
			imageList.Images.Add( "msi", Properties.Resources.msi );
			imageList.Images.Add( "rar", Properties.Resources.rar );
			imageList.Images.Add( "sql", Properties.Resources.sql );
			imageList.Images.Add( "cs", Properties.Resources.cs );
			imageList.Images.Add( "java", Properties.Resources.java );
			imageList.Images.Add( "py", Properties.Resources.py );
			imageList.Images.Add( "css", Properties.Resources.css );
			imageList.Images.Add( "vdo", Properties.Resources.vdo );
			imageList.Images.Add( "wav", Properties.Resources.wav );

			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
		}

		#region Intergration File Client


		private HslCommunication.Enthernet.Ftp.FtpClient ftpClient = null;
		private string localFolder = string.Empty;

		#endregion

		private void button7_Click_1( object sender, EventArgs e )
		{
			// 连接
			button7.Enabled = false;
			ftpClient = new HslCommunication.Enthernet.Ftp.FtpClient( );
			ftpClient.IpAddress = textBox_ip.Text;
			ftpClient.Port =  int.Parse( textBox2.Text );
			ftpClient.Username = textBox9.Text;
			ftpClient.Password = textBox10.Text;
			ftpClient.LogNet = new LogNetSingle( "" );
			ftpClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

			OperateResult connect = ftpClient.ConnectServer( );
			if (connect.IsSuccess)
			{
				panel2.Enabled = true;
				button7.Enabled = false;
				button1.Enabled = true;
				textBox1.Text = ftpClient.SystemType;
				DemoUtils.ShowMessage( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				button7.Enabled = true;
				DemoUtils.ShowMessage( connect.Message );
			}

			StringBuilder stringBuilder = CodeExampleControl.CreateFromObject( ftpClient, "ftpClient" );
			CodeExampleControl.SetPropties( "ftpClient", stringBuilder, ftpClient, "IpAddress", "Port", "Username", "Password" );
			textBox_code_create.Text = stringBuilder.ToString( );

			// 创建本地文件存储的路径
			if (!System.IO.Directory.Exists( localFolder ))
			{
				System.IO.Directory.CreateDirectory( localFolder );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				{
					textBox_log.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				} ) );
			}
			catch(ObjectDisposedException)
			{

			}
		}

		private void 批量上传ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag is FtpFileItem ftpFileItem)
			{
				if (ftpFileItem.IsDirectory)
				{
					// 获取路径信息
					string path = GetGroupsFromNode( node );
					using (OpenFileDialog ofd = new OpenFileDialog( ))
					{
						ofd.Multiselect = true;
						if (ofd.ShowDialog( ) == DialogResult.OK)
						{
							// 开始上传文件
							textBox_upload_group.Text = path;
							UploadObject uploadObject = new UploadObject( )
							{
								Group = path,
								FileNames = ofd.FileNames
							};
							ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolUploadFiles ), uploadObject );
						}
					}
				}
			}
			else if (node.SelectedImageKey == "VirtualMachine")
			{
				// 上传文件到根目录
				string path = "/";
				using (OpenFileDialog ofd = new OpenFileDialog( ))
				{
					ofd.Multiselect = true;
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						// 开始上传文件
						textBox_upload_group.Text = path;
						UploadObject uploadObject = new UploadObject( )
						{
							Group = path,
							FileNames = ofd.FileNames
						};
						ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolUploadFiles ), uploadObject );
					}
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 选择文件
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					textBox3.Text = ofd.FileName;
				}
			}
		}

		private void 刷新目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag is FtpFileItem ftpFileItem)
			{
				if (ftpFileItem.IsDirectory)
				{
					node.Nodes.Clear( );
					string groups = GetGroupsFromNode( node );

					Invoke( new Action( ( ) =>
					{
						textBox_code_example.Text = $"OperateResult<FtpFileItem[]> list = ftpClient.ListFiles( \"{groups}\" );\r\n" + DemoUtils.GetWriteExampleCode( "list", "读取文件及目录" );
					} ) );

					OperateResult<FtpFileItem[]> list = ftpClient.ListFiles( groups );
					if (list.IsSuccess)
					{
						FillNodeByFactoryGroupId( node, list );
						node.Expand( );
					}
					else
					{
						DemoUtils.ShowMessage( list.ToMessageShowString( ) );
					}
				}
			}
			else
			{
				// 刷新根目录
				button6.PerformClick( );
			}
		}

		#region Upload File

		/*************************************************************************************************
		 * 
		 *   一条指令即可完成文件的上传操作，上传模式有三种
		 *   1. 指定本地的完整路径的文件名
		 *   2. 将流（stream）中的数据上传到服务器
		 *   3. 将bitmap图片数据上传到服务器
		 * 
		 ********************************************************************************************/

		// 取消上传的令牌
		private HslCancelToken uploadCacel = null;
		private bool showUploadResult = false;

		private void button_upload_Click( object sender, EventArgs e )
		{
			// 开始上传
			uploadCacel = new HslCancelToken( );
			if (!string.IsNullOrEmpty( textBox3.Text ))
			{
				if (!System.IO.File.Exists( textBox3.Text ))
				{
					DemoUtils.ShowMessage( "选择的文件不存在，退出！" );
					return;
				}

				UploadFlieExample( textBox_upload_group.Text, new string[] { textBox3.Text } );
			}
			else
			{
				DemoUtils.ShowMessage( "Please Select a File" );
			}
			uploadCacel = null;
		}

		private void UploadFlieExample( string group, string[] files )
		{
			button_upload.Enabled = false;             // 上传按钮禁用，取消上传按钮使能
			button_upload_cancel.Enabled = true;

			if (files?.Length > 0)
			{
				UploadObject uploadObject = new UploadObject( )
				{
					Group = group,
					FileNames = files
				};

				ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolUploadFiles ), uploadObject );
			}

		}

		private void ThreadPoolUploadFiles( object state )
		{
			if (state is UploadObject uploadObject)
			{
				string group = uploadObject.Group;
				int success = 0;
				int failed = 0;

				for ( int i = 0; i < uploadObject.FileNames.Length; i ++)
				{
					string fileName = uploadObject.FileNames[i];
					Invoke( new Action( ( ) =>
					{
						textBox3.Text = fileName;
					} ) );

					System.IO.FileInfo fileInfo = new System.IO.FileInfo( fileName );

					if (string.IsNullOrEmpty( group )) group = "/";
					if (!group.EndsWith( "/" )) group += "/";
					string remoteFileName = group + fileInfo.Name;

					// 显示示例代码
					Invoke( new Action( ( ) =>
					{
						textBox_code_example.Text = $"OperateResult result = ftpClient.UploadFile( \"{fileName}\", \"{remoteFileName}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "文件上传" );
					} ) );

					// start to upload file to server , u shold specify the catgray about the file
					DateTime uploadStartTime = DateTime.Now;
					OperateResult result = ftpClient.UploadFile(
						fileName,                       // 需要上传的原文件的完整路径，上传成功还需要个条件，该文件不能被占用
						remoteFileName,                 // 在服务器存储的文件名，带路径信息，例如  /Files/Personal/Admin/123.txt
						UpdateReportProgress,           // 文件上传时的进度报告，如果你不需要，指定为NULL就行，一般文件比较大，带宽比较小，都需要进度提示
						uploadCacel                     // 用于取消的令牌，不需要取消的话，传NULL即可
						);


					if (result.IsSuccess) success++;
					else failed++;

					if (i == uploadObject.FileNames.Length - 1 || result.IsSuccess == false)
					{
						Invoke( new Action( ( ) =>
						{
							button_upload.Enabled = true;
							button_upload_cancel.Enabled = false;

							if (result.IsSuccess)
							{
								// file upload success
								DemoUtils.ShowMessage( $"文件上传成功[{success}]！耗时：" + (DateTime.Now - uploadStartTime).TotalSeconds.ToString( "F1" ) + " 秒" );
							}
							else
							{
								// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
								// mostly failed by network exception, like offline
								DemoUtils.ShowMessage( $"文件成功上传[{success}], 上传[{fileName}]失败：" + result.ToMessageShowString( ) );
							}
						}
						) );
						return;
					}
					else
					{
						HslHelper.ThreadSleep( 100 );
					}
				}
			}
		}

		// 点击取消上传按钮
		private void button_upload_cancel_Click( object sender, EventArgs e )
		{
			if (uploadCacel != null) uploadCacel.IsCancelled = true;
		}

		/// <summary>
		/// 用于更新上传进度的方法，该方法是线程安全的
		/// </summary>
		/// <param name="sended">已经上传的字节数</param>
		/// <param name="totle">总字节数</param>
		private void UpdateReportProgress( long sended, long totle )
		{
			if (progressBar1.InvokeRequired)
			{
				progressBar1.Invoke( new Action<long, long>( UpdateReportProgress ), sended, totle );
				return;
			}


			// 此处代码是安全的
			// thread-safe code
			int value = (int)(sended * 100L / totle);

			label10.Text = SoftBasic.GetSizeDescription( sended ) + "/" + SoftBasic.GetSizeDescription( totle );
			progressBar1.Value = value;
		}

		#endregion

		#region Download File

		private void button8_Click( object sender, EventArgs e )
		{
			// 打开文件保存的目录
			System.Diagnostics.Process.Start( this.localFolder );
		}

		private void 下载文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag != null)
			{
				if (node.Tag is FtpFileItem fileItem)
				{
					// 菜单下载文件
					if (!button_download.Enabled)
					{
						DemoUtils.ShowMessage( "请等待之前的下载完成再进行操作！" );
						return;
					}

					textBox_download_fileName.Text = GetGroupsFromNode( node.Parent ) + "/" + fileItem.Name;
					DownloadFileExample( );
				}
			}

		}

		private void 全部下载ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 菜单下载文件
			if (!button_download.Enabled)
			{
				DemoUtils.ShowMessage( "请等待之前的下载完成再进行操作！" );
				return;
			}

			TreeNode node = treeView1.SelectedNode;
			List<string> list = new List<string>();
			if (node.Tag is FtpFileItem ftpFileItem)
			{
				if (ftpFileItem.IsDirectory)
				{
					foreach (TreeNode item in node.Nodes)
					{
						if (item == null) continue;

						if (item.Tag is FtpFileItem fileItem)
						{
							if (fileItem.IsDirectory) continue;
							list.Add( GetGroupsFromNode( item.Parent ) + "/" + fileItem.Name );
						}
					}
				}
			}
			else if (node.ImageKey == "VirtualMachine")
			{
				foreach (TreeNode item in node.Nodes)
				{
					if (item == null) continue;

					if (item.Tag is FtpFileItem fileItem)
					{
						if (fileItem.IsDirectory) continue;
						list.Add( GetGroupsFromNode( item.Parent ) + "/" + fileItem.Name );
					}
				}
			}

			if (list.Count > 0)
			{
				ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolDownloadFiles ), list );
			}
		}

		private void ThreadPoolDownloadFiles( object state )
		{
			if (state is List<string> list)
			{
				for(int i = 0; i < list.Count; i++)
				{
					Invoke( new Action( ( ) =>
					{
						progressBar2.Value = 0;                                       // 下载的进度条复位
						textBox_download_fileName.Text = list[i];

						button_download.Enabled = false;                              // 下载按钮禁止，打开取消下载按钮
						button_download_cancel.Enabled = true;
						label15.Text = "Start downloading...";
					} ) );


					DownloadFileHelper( list[i], $"总计:{list.Count} 当前:{(i + 1).ToString( )} " );
				}
			}
		}

		#region Download Sample



		private HslCancelToken downloadCacel = null;

		private void button_download_Click( object sender, EventArgs e )
		{
			// 点击开始下载，此处按照实际项目需求放到了后台线程处理，事实上这种耗时的操作就应该放到后台线程
			// click this button to start a backgroud thread for downloading file
			downloadCacel = new HslCancelToken( );
			DownloadFileExample( );
		}

		private void DownloadFileExample( )
		{
			progressBar2.Value = 0;                                       // 下载的进度条复位
			button_download.Enabled = false;                              // 下载按钮禁止，打开取消下载按钮
			button_download_cancel.Enabled = true;
			label15.Text = "Start downloading...";

			ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolDownloadFile ), textBox_download_fileName.Text );
		}

		private void ThreadPoolDownloadFile( object state )
		{
			string fileName = state as string;
			DownloadFileHelper( fileName, string.Empty );
		}

		private void DownloadFileHelper( string fileName, string info )
		{
			string saveNmae = fileName;

			if (fileName.Contains( "/" ))
			{
				saveNmae = fileName.Substring( fileName.LastIndexOf( '/' ) + 1 );
			}
			else if (fileName.Contains( "\\" ))
			{
				saveNmae = fileName.Substring( fileName.LastIndexOf( '\\' ) + 1 );
			}

			saveNmae = System.IO.Path.Combine( localFolder, saveNmae );
			// 显示示例代码
			Invoke( new Action( ( ) =>
			{
				textBox_code_example.Text = $"OperateResult result = ftpClient.DownloadFile( \"{fileName}\", \"{saveNmae}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "文件下载" );
			} ) );

			DateTime downloadStartTime = DateTime.Now;
			OperateResult result = ftpClient.DownloadFile(
					fileName,                                        // 文件在服务器上保存的名称，举例123.txt
					saveNmae,                                        // 下载后在文本保存的路径，也可以直接下载到 MemoryStream 的数据流中，或是bitmap中，或是手动选择存储路径
					DownloadReportProgress,                          // 文件下载的时候的进度报告，友好的提示下载进度信息
					downloadCacel                                    // 取消下载操作的令牌，如果不需要取消，使用NULL即可
					);

			downloadCacel = null;
			Invoke( new Action( ( ) =>
			{
				button_download.Enabled = true;
				button_download_cancel.Enabled = false;
				if (result.IsSuccess)
				{
					// message: file download success
					label15.Text = info + "文件下载成功！耗时：" + (DateTime.Now - downloadStartTime).TotalSeconds.ToString( "F1" ) + " 秒";
				}
				else
				{
					// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
					// mostly failed by network exception, like offline, and file not exsist,
					label15.Text = info + "文件下载失败：" + result.Message;
					DemoUtils.ShowMessage( "文件下载失败：" + result.ToMessageShowString( ) );
				}
			} ) );
		}

		// 点击下载取消的按钮，取消的令牌设置为 True
		private void button_download_cancel_Click( object sender, EventArgs e )
		{
			if (downloadCacel != null) downloadCacel.IsCancelled = true;
		}

		/// <summary>
		/// 用于更新文件下载进度的方法，该方法是线程安全的，主要作用是将下载文件的进度在进度条上显示
		/// </summary>
		/// <param name="receive">已经接收的字节数</param>
		/// <param name="totle">总字节数</param>
		private void DownloadReportProgress( long receive, long totle )
		{
			if (progressBar2.InvokeRequired)
			{
				progressBar2.Invoke( new Action<long, long>( DownloadReportProgress ), receive, totle );
				return;
			}

			// 此处代码是线程安全的
			// thread-safe code
			int value = (int)(receive * 100L / totle);
			progressBar2.Value = value;
			label9.Text = SoftBasic.GetSizeDescription( receive ) + "/" + SoftBasic.GetSizeDescription( totle );
		}

		#endregion

		#endregion

		#region Delete Files

		private void 删除文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 删除文件
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag != null)
			{
				if (node.Tag is FtpFileItem fileItem)
				{
					string fullPath = GetGroupsFromNode( node.Parent );
					if (string.IsNullOrEmpty( fullPath )) fullPath = "/";
					if (fullPath.EndsWith( "/" ) == false) fullPath += "/";
					fullPath += fileItem.Name;

					if (Program.Language == 2)
					{
						if (DemoUtils.ShowMessage( $"Are you sure to delete the file: {fullPath}?", "Delete Confirmation", MessageBoxButtons.YesNo ) == DialogResult.No) return;
					}
					else
					{
						if (DemoUtils.ShowMessage( $"是否确认删除文件: {fullPath}?", "删除确认", MessageBoxButtons.YesNo ) == DialogResult.No) return;
					}

					// 显示示例代码
					Invoke( new Action( ( ) =>
					{
						textBox_code_example.Text = $"OperateResult result = ftpClient.DeleteFile( \"{fullPath}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "文件删除" );
					} ) );

					// 文件名示例: /Files/Personal/Admin/123.txt
					OperateResult result = ftpClient.DeleteFile( fullPath );
					if (result.IsSuccess)
					{
						// delete file success
						if (Program.Language == 2)
							DemoUtils.ShowMessage( "File deleted successfully!" );
						else
							DemoUtils.ShowMessage( "文件删除成功！" );
					}
					else
					{
						// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
						// file not exsist or net work exception
						if (Program.Language == 2)
							DemoUtils.ShowMessage( "File deletion failed, reason: " + result.ToMessageShowString( ) );
						else
							DemoUtils.ShowMessage( "文件删除失败，原因：" + result.ToMessageShowString( ) );
					}
				}
				else
				{
					// 请求数据
				}
			}
		}

		private void 删除目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			string path = GetGroupsFromNode( node );
			if (string.IsNullOrEmpty( path )) path = "/";
			if (path.EndsWith( "/" ) == false) path += "/";

			if (Program.Language == 2)
			{
				if (DemoUtils.ShowMessage( $"Are you sure to delete the directory: {path}?", "Delete Confirmation", MessageBoxButtons.YesNo ) == DialogResult.No) return;
			}
			else
			{
				if (DemoUtils.ShowMessage( $"是否确认删除目录: {path} ?", "删除确认", MessageBoxButtons.YesNo ) == DialogResult.No) return;
			}

			Invoke( new Action( ( ) =>
			{
				textBox_code_example.Text = $"OperateResult result = ftpClient.DeleteDirectory( \"{path}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "目录删除" );
			} ) );
			// 
			OperateResult result =  ftpClient.DeleteDirectory( path );
			if (result.IsSuccess)
			{
				// delete file success
				DemoUtils.ShowMessage( "目录删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				DemoUtils.ShowMessage( "目录删除失败，原因：" + result.ToMessageShowString( ) );
			}

		}

		private void 清除目录文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;


			if (DemoUtils.ShowMessage( $"是否确认清除目录[{GetGroupsFromNode( node )}]及所有文件?", "删除确认", MessageBoxButtons.YesNo ) == DialogResult.No) return;

			Invoke( new Action( ( ) =>
			{
				textBox_code_example.Text = $"OperateResult result = ftpClient.DeleteDirectory( \"{GetGroupsFromNode( node )}\", clearFiles: true );\r\n" + DemoUtils.GetWriteExampleCode( "result", "目录及文件删除" );
			} ) );

			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = ftpClient.DeleteDirectory( GetGroupsFromNode( node ), clearFiles: true );
			if (result.IsSuccess)
			{
				// delete file success
				DemoUtils.ShowMessage( "指定目录及文件删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				DemoUtils.ShowMessage( "指定目录及文件删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private void 创建目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			FormInputNewValue form = new FormInputNewValue( "" );
			if (Program.Language == 2)
				form.Text = "Please enter the new directory name:";
			else
				form.Text = "请输入新的目录名称：";
			if (form.ShowDialog( ) == DialogResult.OK)
			{
				TreeNode node = treeView1.SelectedNode;
				if (node == null) return;
				string path = GetGroupsFromNode( node );
				if (string.IsNullOrEmpty( path )) path = "/";
				if (path.EndsWith( "/" ) == false) path += "/";
				path += form.InputValue;


				Invoke( new Action( ( ) =>
				{
					textBox_code_example.Text = $"OperateResult result = ftpClient.CreateDirectory( \"{path}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "创建目录" );
				} ) );

				OperateResult result = ftpClient.CreateDirectory( path );
				if (result.IsSuccess)
				{
					// create directory success
					if (Program.Language == 2)
						DemoUtils.ShowMessage( "Directory created successfully!" );
					else
						DemoUtils.ShowMessage( "目录创建成功！" );
				}
				else
				{
					// 创建失败的原因除了一般的网络问题，还有目录已经存在等原因
					// directory exsist or net work exception
					if (Program.Language == 2)
						DemoUtils.ShowMessage( "Directory creation failed, reason: " + result.ToMessageShowString( ) );
					else
						DemoUtils.ShowMessage( "目录创建失败，原因：" + result.ToMessageShowString( ) );
				}
			}
		}

		private void 重命名目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			string path = GetGroupsFromNode( node );
			FormInputNewPath form = new FormInputNewPath( path, path );
			if (form.ShowDialog( ) == DialogResult.OK)
			{

				Invoke( new Action( ( ) =>
				{
					textBox_code_example.Text = $"OperateResult result = ftpClient.RenameFolder( \"{path}\", \"{form.PathInput}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "重命名目录" );
				} ) );

				OperateResult result = ftpClient.RenameFolder(
					path,                                      // 类别信息，例如 Files/Personal/Admin
					form.PathInput
				);
				if (result.IsSuccess)
				{
					// delete file success
					DemoUtils.ShowMessage( "修改目录名称成功！" );
				}
				else
				{
					// 删除失败的原因除了一般的网络问题
					// file not exsist or net work exception
					DemoUtils.ShowMessage( "修改目录名称失败，原因：" + result.ToMessageShowString( ) );
				}
			}

		}

		private void 重命名ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 重命名文件
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag is FtpFileItem fileItem)
			{
				string fullPath = GetGroupsFromNode( node.Parent );
				if (string.IsNullOrEmpty( fullPath )) fullPath = "/";
				if (fullPath.EndsWith( "/" ) == false) fullPath += "/";
				fullPath += fileItem.Name;
				FormInputNewPath form = new FormInputNewPath( fileItem.Name, fileItem.Name );
				if (form.ShowDialog( ) == DialogResult.OK)
				{

					Invoke( new Action( ( ) =>
					{
						textBox_code_example.Text = $"OperateResult result = ftpClient.RenameFile( \"{fullPath}\", \"{form.PathInput}\" );\r\n" + DemoUtils.GetWriteExampleCode( "result", "重命名文件" );
					} ) );

					OperateResult result = ftpClient.RenameFile( fullPath, form.PathInput );
					if (result.IsSuccess)
					{
						// rename file success
						DemoUtils.ShowMessage( "文件重命名成功！" );
					}
					else
					{
						// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
						// file not exsist or net work exception
						DemoUtils.ShowMessage( "文件重命名失败，原因：" + result.ToMessageShowString( ) );
					}
				}
			}
		}
		#endregion

		#region DownloadPathFolders

		private void FillNodeByFactoryGroupId( TreeNode root, OperateResult<FtpFileItem[]> read )
		{
			root.Nodes.Clear( );
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					if (item.IsDirectory)
					{
						TreeNode node = new TreeNode( item.Name );
						node.Tag = item;
						node.Nodes.Add( new TreeNode( "loading..." ) { ImageKey = "loading", SelectedImageKey = "loading" } );
						root.Nodes.Add( node );
						node.ImageKey = "Class_489";
						node.SelectedImageKey = "Class_489";
					}
					else
					{
						// 文件处理
						TreeNode node = new TreeNode( item.Name );
						node.Tag = item;
						root.Nodes.Add( node );
						node.ImageKey = GetFileExtensionIconKey( item.Name );
						node.SelectedImageKey = GetFileExtensionIconKey( item.Name );
					}
				}
			}
			else
			{
				DemoUtils.ShowMessage( read.ToMessageShowString( ) );
			}
		}

		#endregion

		#region DownloadPathFileNames

		private string GetFileExtensionIconKey( string fileName )
		{
			if (string.IsNullOrEmpty( fileName )) return "file";
			if (fileName.LastIndexOf( '.' ) < 0 && fileName.LastIndexOf( '.' ) == fileName.Length - 1) return "file";
			string ext = fileName.Substring( fileName.LastIndexOf( '.' ) + 1 ).ToLower( );
			if (ext == "doc" || ext == "docx") return "doc";
			if (ext == "xls" || ext == "xlsx") return "xls";
			if (ext == "dll") return "dll";
			if (ext == "exe") return "exe";
			if (ext == "xml") return "xml";
			if (ext == "png" || ext == "bmp" || ext == "jpg" || ext == "jpeg" || ext == "gif") return "png";
			if (ext == "chm") return "chm";
			if (ext == "ppt" || ext == "pptx") return "ppt";
			if (ext == "vsd") return "vsd";
			if (ext == "pdf") return "pdf";
			if (ext == "ttf") return "ttf";
			if (ext == "txt") return "txt";
			if (ext == "js") return "js";
			if (ext == "jsp") return "jsp";
			if (ext == "msi") return "msi";
			if (ext == "rar" || ext == "tar" || ext == "zip" || ext == "iso" || ext == "7z") return "rar";
			if (ext == "sql") return "sql";
			if (ext == "cs") return "cs";
			if (ext == "java") return "java";
			if (ext == "py") return "py";
			if (ext == "css") return "css";
			if (ext == "avi" || ext == "mov" || ext == "rmvb" || ext == "rm" || ext == "flv" || ext == "mp4" || ext == "3gp") return "vdo";
			if (ext == "wav" || ext == "mp3" || ext == "wma" || ext == "midi") return "wav";
			return "file";
		}
		#endregion

		private void button6_Click( object sender, EventArgs e )
		{
			treeView1.Nodes[0].Nodes.Clear( );
			button6.Enabled = false;

			OperateResult<FtpFileItem[]> list = ftpClient.ListFiles( "/" );
			if (list.IsSuccess)
			{
				FillNodeByFactoryGroupId( treeView1.Nodes[0], list );
				treeView1.Nodes[0].Expand( );
			}
			else
			{
				DemoUtils.ShowMessage( list.ToMessageShowString( ) );
			}

			button6.Enabled = true;
		}


		private void treeView1_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				if (node.Nodes.Count == 1 && node.Nodes[0].ImageKey == "loading")
				{
					string groups = GetGroupsFromNode( node );

					Invoke( new Action( ( ) =>
					{
						textBox_code_example.Text = $"OperateResult<FtpFileItem[]> list = ftpClient.ListFiles( \"{groups}\" );\r\n" + DemoUtils.GetWriteExampleCode( "list", "读取文件及目录" );
					} ) );

					OperateResult<FtpFileItem[]> list = ftpClient.ListFiles( groups );
					if (list.IsSuccess)
					{
						FillNodeByFactoryGroupId( node, list );
						node.Expand( );
					}
					else
					{
						DemoUtils.ShowMessage( list.ToMessageShowString( ) );
					}
				}
			}
			else if (node.ImageKey == "VirtualMachine")
			{
				// button6_Click( sender, EventArgs.Empty );
			}
		}

		private string GetGroupsFromNode( TreeNode node )
		{
			List<string> list = new List<string>( );
			while (node != null)
			{
				list.Add( node.Text );
				node = node.Parent;
			}
			list.Reverse( );
			list.RemoveAt( 0 );
			return GetGroupsString( list.ToArray( ) );
		}

		private string GetGroupsString( string[] groups )
		{
			if (groups == null) return string.Empty;
			if (groups.Length == 0) return string.Empty;

			string tmp = groups[0];
			for (int i = 1; i < groups.Length; i++)
			{
				tmp += "/" + groups[i];
			}
			return tmp;
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				if (node.Tag is FtpFileItem fileItem)
				{
					string path        = GetGroupsFromNode( node.Parent );
					if (string.IsNullOrEmpty( path )) path = "/";
					if (path.EndsWith( "/" ) == false) path += "/";

					textBox_file_fileName.Text     = path + fileItem.Name;
					textBox_file_fileSize.Text     = fileItem.Size.ToString( ) + $" [{SoftBasic.GetSizeDescription( fileItem.Size )}]";
					textBox_file_date.Text         = fileItem.CreateTime.ToString( );
				}
				else
				{
					// 请求数据
				}
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox9.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			ftpClient?.ConnectClose( );
			button7.Enabled = true;
			button1.Enabled = false;
		}

		private void treeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				treeView1.SelectedNode = treeView1.GetNodeAt( e.Location );
				TreeNode node = treeView1.SelectedNode;
				if (node.Tag != null)
				{
					if (node.Tag is FtpFileItem fileItem)
					{
						if (fileItem.IsDirectory)
						{
							删除目录ToolStripMenuItem.Enabled = true;
							重命名目录ToolStripMenuItem.Enabled = true;
							清除目录文件ToolStripMenuItem.Enabled = true;
							contextMenuStrip2.Show( treeView1, e.Location );
						}
						else
						{
							contextMenuStrip1.Show( treeView1, e.Location );
						}
					}
				}
				else
				{
					if (node.ImageKey == "VirtualMachine")
					{
						删除目录ToolStripMenuItem.Enabled = false;
						重命名目录ToolStripMenuItem.Enabled = false;
						清除目录文件ToolStripMenuItem.Enabled = false;
						contextMenuStrip2.Show( treeView1, e.Location );
					}
				}
			}
		}

		private void FormMqttFileClient_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button7.Enabled == false) button1_Click( null, EventArgs.Empty );
		}

	}

	public class UploadObject
	{
		public string Group { get; set; }
		public string[] FileNames { get; set; }
	}
}
