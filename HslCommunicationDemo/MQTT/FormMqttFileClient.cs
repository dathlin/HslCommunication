using HslCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication.MQTT;
using HslCommunication.Core;
using HslCommunication.Enthernet;
using HslCommunication.BasicFramework;
using System.Threading.Tasks;
using HslCommunicationDemo.MQTT;

namespace HslCommunicationDemo
{
	public partial class FormMqttFileClient : HslFormContent
	{
		public FormMqttFileClient( )
		{
			InitializeComponent( );
		}

		private void FormFileClient_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine",        Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489",             Properties.Resources.Class_489 );
			imageList.Images.Add( "Enum_582",              Properties.Resources.Enum_582 );
			imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );
			imageList.Images.Add( "Method_636",            Properties.Resources.Method_636 );
			imageList.Images.Add( "Module_648",            Properties.Resources.Module_648 ); 
			imageList.Images.Add( "Structure_507",         Properties.Resources.Structure_507 );
			imageList.Images.Add( "loading",               Properties.Resources.loading );
			imageList.Images.Add( "file",                  Properties.Resources.file );
			imageList.Images.Add( "dll",                   Properties.Resources.dll );
			imageList.Images.Add( "exe",                   Properties.Resources.exe );
			imageList.Images.Add( "xml",                   Properties.Resources.xml );
			imageList.Images.Add( "png",                   Properties.Resources.png );
			imageList.Images.Add( "doc",                   Properties.Resources.doc );
			imageList.Images.Add( "chm",                   Properties.Resources.chm );
			imageList.Images.Add( "ppt",                   Properties.Resources.ppt );
			imageList.Images.Add( "xls",                   Properties.Resources.xls );
			imageList.Images.Add( "vsd",                   Properties.Resources.vsd );
			imageList.Images.Add( "pdf",                   Properties.Resources.pdf );
			imageList.Images.Add( "ttf",                   Properties.Resources.ttf );
			imageList.Images.Add( "txt",                   Properties.Resources.txt );
			imageList.Images.Add( "js",                    Properties.Resources.js );
			imageList.Images.Add( "jsp",                   Properties.Resources.jsp );
			imageList.Images.Add( "msi",                   Properties.Resources.msi );
			imageList.Images.Add( "rar",                   Properties.Resources.rar );
			imageList.Images.Add( "sql",                   Properties.Resources.sql );
			imageList.Images.Add( "cs",                    Properties.Resources.cs );
			imageList.Images.Add( "java",                  Properties.Resources.java );
			imageList.Images.Add( "py",                    Properties.Resources.py );
			imageList.Images.Add( "css",                   Properties.Resources.css );
			imageList.Images.Add( "vdo",                   Properties.Resources.vdo );
			imageList.Images.Add( "wav",                   Properties.Resources.wav );

			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
		}

		#region Intergration File Client


		private MqttSyncClient mqttSyncClient;


		#endregion

		private async void button7_Click_1( object sender, EventArgs e )
		{
			// 连接
			MqttConnectionOptions options = new MqttConnectionOptions( )
			{
				IpAddress      = textBox_ip.Text,
				Port           = int.Parse( textBox2.Text ),
				ClientId       = textBox1.Text,
				UseRSAProvider = checkBox_rsa.Checked,
			};
			if (!string.IsNullOrEmpty( textBox9.Text ) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
			}

			button7.Enabled = false;
			mqttSyncClient = new MqttSyncClient( options );
			OperateResult connect = await mqttSyncClient.ConnectServerAsync( );

			if (connect.IsSuccess)
			{
				// 此处为什么关闭呢？因为文件的操作都是基于新的socket的，这样支持多线程操作，所以此处关闭也没事
				// Why is it closed here? Because file operations are based on the new socket, this supports multi-threaded operations, so it’s okay to close here
				mqttSyncClient.ConnectClose( );
				panel2.Enabled = true;
				button7.Enabled = false;
				button1.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				button7.Enabled = true;
				MessageBox.Show( connect.Message );
			}

			// 创建本地文件存储的路径
			string path = Application.StartupPath + @"\Files";
			if (!System.IO.Directory.Exists( path ))
			{
				System.IO.Directory.CreateDirectory( path );
			}
		}



		private async void 批量上传ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag is GroupFileItem groupFile)
			{
			}
			else
			{
				// 获取路径信息
				string path = GetGroupsFromNode( node );
				using (OpenFileDialog ofd = new OpenFileDialog( ))
				{
					ofd.Multiselect = true;
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						foreach (var item in ofd.FileNames)
						{
							textBox3.Text = item;
							await UploadFlieExample( path );
						}
						MessageBox.Show( $"上传目录[{path}]完成，共计文件：" + ofd.FileNames.Length );
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
			treeView1_BeforeExpand( sender, new TreeViewCancelEventArgs( treeView1.SelectedNode, false, TreeViewAction.Expand ) );
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
		// mqttSyncClient 即为通信对象

		private async void button_upload_Click( object sender, EventArgs e )
		{
			// 开始上传
			uploadCacel = new HslCancelToken( );
			if (!string.IsNullOrEmpty( textBox3.Text ))
			{
				if (!System.IO.File.Exists( textBox3.Text ))
				{
					MessageBox.Show( "选择的文件不存在，退出！" );
					return;
				}

				DateTime uploadStartTime = DateTime.Now;
				OperateResult result = await UploadFlieExample( string.Empty );

				if (result.IsSuccess)
				{
					// file upload success
					MessageBox.Show( "文件上传成功！耗时：" + (DateTime.Now - uploadStartTime).TotalSeconds.ToString( "F1" ) + " 秒" );
				}
				else
				{
					// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
					// mostly failed by network exception, like offline
					MessageBox.Show( "文件上传失败：" + result.ToMessageShowString( ) );
				}
			}
			else
			{
				MessageBox.Show( "Please Select a File" );
			}
			uploadCacel = null;
		}

		private async Task<OperateResult> UploadFlieExample( string group )
		{
			button_upload.Enabled = false;             // 上传按钮禁用，取消上传按钮使能
			button_upload_cancel.Enabled = true;
			string fileName = textBox3.Text;           // 等待上传的完整文件路径
			System.IO.FileInfo fileInfo = new System.IO.FileInfo( fileName );

			group = string.IsNullOrEmpty( group ) ? textBox_upload_group.Text : group;
			// 开始正式上传，关于三级分类，下面只是举个例子，上传成功后去服务器端寻找文件就能明白
			// start to upload file to server , u shold specify the catgray about the file
			OperateResult result = await mqttSyncClient.UploadFileAsync(
				fileName,                       // 需要上传的原文件的完整路径，上传成功还需要个条件，该文件不能被占用
				group,                          // 类别信息，例如 Files/Personal/Admin
				fileInfo.Name,                  // 在服务器存储的文件名，带后缀，一般设置为原文件的文件名，当然您也可以重新设置名字
				textBox_upload_tag.Text,        // 这个文件的额外描述文本，可以为空（""）
				UpdateReportProgress,           // 文件上传时的进度报告，如果你不需要，指定为NULL就行，一般文件比较大，带宽比较小，都需要进度提示
				uploadCacel                     // 用于取消的令牌，不需要取消的话，传NULL即可
				);
			button_upload.Enabled = true;
			button_upload_cancel.Enabled = false;
			return result;
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
			System.Diagnostics.Process.Start( Application.StartupPath + @"\Files" );
		}

		private async void 下载文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag != null)
			{
				if (node.Tag is GroupFileItem fileItem)
				{
					// 菜单下载文件
					if (!button_download.Enabled)
					{
						MessageBox.Show( "请等待之前的下载完成再进行操作！" );
						return;
					}

					textBox5.Text = GetGroupsFromNode( node.Parent );
					textBox_download_fileName.Text = fileItem.FileName;
					await DownloadFileExample( );
				}
			}

		}

		private async void 全部下载ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag is GroupFileItem groupFile)
			{
			}
			else
			{
				foreach (TreeNode item in node.Nodes)
				{
					if (item == null) continue;

					if (item.Tag is GroupFileItem fileItem)
					{
						// 菜单下载文件
						if (!button_download.Enabled)
						{
							MessageBox.Show( "请等待之前的下载完成再进行操作！" );
							return;
						}

						textBox5.Text = GetGroupsFromNode( item.Parent );
						textBox_download_fileName.Text = fileItem.FileName;
						await DownloadFileExample( );
					}
				}
			}
		}

		#region Download Sample

		// mqttSyncClient 即为通信对象

		private HslCancelToken downloadCacel = null;

		private async void button_download_Click( object sender, EventArgs e )
		{
			// 点击开始下载，此处按照实际项目需求放到了后台线程处理，事实上这种耗时的操作就应该放到后台线程
			// click this button to start a backgroud thread for downloading file
			downloadCacel = new HslCancelToken( );
			await DownloadFileExample( );
			downloadCacel = null;
		}

		/*************************************************************************************************
		 * 
		 *   一条指令即可完成文件的下载操作，下载模式有三种
		 *   1. 指定需要下载的文件名（带后缀）
		 *   2. 将服务器上的数据下载到流（stream）中
		 *   3. 将服务器上的数据下载到bitmap图片中
		 * 
		 ********************************************************************************************/

		private async Task DownloadFileExample( )
		{
			progressBar2.Value = 0;                                       // 下载的进度条复位
			button_download.Enabled = false;                              // 下载按钮禁止，打开取消下载按钮
			button_download_cancel.Enabled = true;
			label15.Text = "Start downloading...";

			string fileName = textBox_download_fileName.Text;
			DateTime downloadStartTime = DateTime.Now;
			OperateResult result = await mqttSyncClient.DownloadFileAsync(
					textBox5.Text,                                         // 类别信息，例如 Files/Personal/Admin
					fileName,                                              // 文件在服务器上保存的名称，举例123.txt
					DownloadReportProgress,                                // 文件下载的时候的进度报告，友好的提示下载进度信息
					Application.StartupPath + @"\Files\" + fileName,       // 下载后在文本保存的路径，也可以直接下载到 MemoryStream 的数据流中，或是bitmap中，或是手动选择存储路径
					downloadCacel                                          // 取消下载操作的令牌，如果不需要取消，使用NULL即可
					);

			button_download.Enabled = true;
			button_download_cancel.Enabled = false;
			if (result.IsSuccess)
			{
				// message: file download success
				label15.Text = "文件下载成功！耗时：" + (DateTime.Now - downloadStartTime).TotalSeconds.ToString( "F1" ) + " 秒";
			}
			else
			{
				// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
				// mostly failed by network exception, like offline, and file not exsist,
				label15.Text = "文件下载失败：" + result.Message;
			}
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

		private async void button10_Click( object sender, EventArgs e )
		{
			string fileName = textBox_download_fileName.Text;
			OperateResult<bool> result = await mqttSyncClient.IsFileExistsAsync(
					textBox_upload_group.Text,                            // 类别信息，例如 Files/Personal/Admin
					fileName                                              // 文件在服务器上保存的名称，举例123.txt
					);
			if (result.IsSuccess)
			{
				if (result.Content)
					MessageBox.Show( "文件存在！" );
				else
					MessageBox.Show( "文件不存在！" );
			}
			else
			{
				MessageBox.Show( result.Message );
			}
		}
		#endregion

		#region Delete Files

		private async void 删除文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 删除文件
			TreeNode node = treeView1.SelectedNode;
			if (node.Tag != null)
			{
				if (node.Tag is GroupFileItem fileItem)
				{
					OperateResult result = await mqttSyncClient.DeleteFileAsync(
						GetGroupsFromNode( node.Parent ),                  // 类别信息，例如 Files/Personal/Admin
						fileItem.FileName                                  // 文件在服务器上保存的名称，举例123.txt
						);
					if (result.IsSuccess)
					{
						// delete file success
						MessageBox.Show( "文件删除成功！" );
					}
					else
					{
						// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
						// file not exsist or net work exception
						MessageBox.Show( "文件删除失败，原因：" + result.ToMessageShowString( ) );
					}
				}
				else
				{
					// 请求数据
				}
			}
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await mqttSyncClient.DeleteFileAsync(
				textBox6.Text,                                     // 类别信息，例如 Files/Personal/Admin
				textBox_delete_fileName.Text                       // 文件在服务器上保存的名称，举例123.txt
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "文件删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "文件删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void 删除目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if (MessageBox.Show( $"是否确认删除目录: {GetGroupsFromNode( node )}?", "删除确认", MessageBoxButtons.YesNo ) == DialogResult.No) return;

			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await mqttSyncClient.DeleteFolderAsync(
				GetGroupsFromNode( node )                                      // 类别信息，例如 Files/Personal/Admin
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "目录删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "目录删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void 清除目录文件ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if (MessageBox.Show( $"是否确认清除目录[{GetGroupsFromNode( node )}]所有文件?", "删除确认", MessageBoxButtons.YesNo ) == DialogResult.No) return;

			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await mqttSyncClient.DeleteFolderFilesAsync(
				GetGroupsFromNode( node )                                      // 类别信息，例如 Files/Personal/Admin
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "指定目录所有文件删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "指定目录所有文件删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void 重命名目录ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			string path = GetGroupsFromNode( node );
			FormInputNewPath form = new FormInputNewPath( path, path );
			if(form.ShowDialog() == DialogResult.OK)
			{
				OperateResult result = await mqttSyncClient.RenameFolderAsync(
					path,                                      // 类别信息，例如 Files/Personal/Admin
					form.PathInput
				);
				if (result.IsSuccess)
				{
					// delete file success
					MessageBox.Show( "修改目录名称成功！" );
				}
				else
				{
					// 删除失败的原因除了一般的网络问题
					// file not exsist or net work exception
					MessageBox.Show( "修改目录名称失败，原因：" + result.ToMessageShowString( ) );
				}
			}

		}

		private async void button9_Click( object sender, EventArgs e )
		{
			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await mqttSyncClient.DeleteFolderFilesAsync(
				textBox6.Text                                      // 类别信息，例如 Files/Personal/Admin
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "文件目录删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "文件目录删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// 获取目标的所有文件的大小
			OperateResult<GroupFileInfo> result = await mqttSyncClient.GetGroupFileInfoAsync(
				textBox6.Text                                      // 类别信息，例如 Files/Personal/Admin
				);
			if (result.IsSuccess)
			{
				// success
				label17.Text = result.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "获取目录大小失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void button12_Click( object sender, EventArgs e )
		{
			// 获取目标的所有文件的大小
			OperateResult<GroupFileInfo[]> result = await mqttSyncClient.GetSubGroupFileInfosAsync(
				textBox6.Text,                                      // 类别信息，例如 Files/Personal/Admin
				true
				);
			if (result.IsSuccess)
			{
				// success
				MessageBox.Show( result.Content.ToJsonString( ) );
			}
			else
			{
				MessageBox.Show( "获取目录大小失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		#endregion

		#region DownloadPathFolders

		private void FillNodeByFactoryGroupId( TreeNode root, OperateResult<string[]> read )
		{
			root.Nodes.Clear( );
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					TreeNode node = new TreeNode( item );
					node.Tag = item;
					node.Nodes.Add( new TreeNode( "loading..." ) { ImageKey = "loading", SelectedImageKey = "loading" } ) ;
					root.Nodes.Add( node );
					node.ImageKey = "Class_489";
					node.SelectedImageKey = "Class_489";
				}

				// root.ExpandAll( ); occur an exception ?? I don't know
			}
			else
			{
				MessageBox.Show( read.ToMessageShowString( ) );
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

		private void FillNodeFilesByFactoryGroupId( TreeNode root, OperateResult<GroupFileItem[]> read )
		{
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					TreeNode node = new TreeNode( item.FileName );
					node.Tag = item;
					root.Nodes.Add( node );
					node.ImageKey = GetFileExtensionIconKey( item.FileName );
					node.SelectedImageKey = GetFileExtensionIconKey( item.FileName );
				}

				// root.ExpandAll( ); occur an exception ?? I don't know
			}
			else
			{
				MessageBox.Show( read.ToMessageShowString( ) );
			}
		}

		#endregion

		private async void button6_Click( object sender, EventArgs e )
		{
			treeView1.Nodes[0].Nodes.Clear( );
			button6.Enabled = false;
			FillNodeByFactoryGroupId( treeView1.Nodes[0], await mqttSyncClient.DownloadPathFoldersAsync( null ) );
			FillNodeFilesByFactoryGroupId( treeView1.Nodes[0], await mqttSyncClient.DownloadPathFileNamesAsync( null ) );
			button6.Enabled = true;
			treeView1.Nodes[0].Expand( );
		}


		private async void treeView1_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				string groups = GetGroupsFromNode( node );
				FillNodeByFactoryGroupId( node, await mqttSyncClient.DownloadPathFoldersAsync( groups ) );
				FillNodeFilesByFactoryGroupId( node, await mqttSyncClient.DownloadPathFileNamesAsync( groups ) );
			}
		}

		private string GetGroupsFromNode( TreeNode node )
		{
			List<string> list = new List<string>( );
			while(node != null)
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
				if (node.Tag is GroupFileItem fileItem)
				{
					textBox_show_group.Text        = GetGroupsFromNode( node.Parent );
					textBox_file_fileName.Text     = fileItem.FileName;
					textBox_file_fileSize.Text     = fileItem.FileSize.ToString( );
					textBox_file_date.Text         = fileItem.UploadTime.ToString( );
					textBox_file_dowloadTimes.Text = fileItem.DownloadTimes.ToString( );
					textBox_file_upload.Text       = fileItem.Owner;
					textBox_file_tag.Text          = fileItem.Description;
				}
				else
				{
					// 请求数据
				}
			}
		}

		private int threadlength = 20;
		Random random = new Random( );
		private int upSuccess = 0;
		private int downSuccess = 0;
		private int deleteSuccess = 0;

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox1.Text = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox9.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			mqttSyncClient.ConnectClose( );
			button7.Enabled = true;
			button1.Enabled = false;
		}

		private void treeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if(e.Button == MouseButtons.Right)
			{
				treeView1.SelectedNode = treeView1.GetNodeAt( e.Location );
				TreeNode node = treeView1.SelectedNode;
				if (node.Tag != null)
				{
					if (node.Tag is GroupFileItem fileItem)
					{
						contextMenuStrip1.Show( treeView1, e.Location );
					}
					else
					{
						contextMenuStrip2.Show( treeView1, e.Location );
					}
				}
				else
				{
					contextMenuStrip2.Show( treeView1, e.Location );
				}
			}
		}

	}
}
