using HslCommunication;
using HslCommunication.Enthernet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication.Core;
using HslCommunication.BasicFramework;
#if !NET35
using System.Threading.Tasks;
#endif

namespace HslCommunicationDemo
{
	public partial class FormFileClient : HslFormContent
	{
		public FormFileClient( )
		{
			InitializeComponent( );
		}

		private void FormFileClient_Load( object sender, EventArgs e )
		{
			textBox15.Text = Guid.Empty.ToString( );
		}

		#region Intergration File Client


		private IntegrationFileClient integrationFileClient;                 // 客户端的核心引擎

		private void IntegrationFileClientInitialization( )
		{
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( "Port输入异常，请重新输入！" );
				return;
			}

			if (!int.TryParse( textBox4.Text, out int fileCache ))
			{
				MessageBox.Show( "FileCache输入异常，请重新输入！" );
				return;
			}


			// 定义连接服务器的一些属性，超时时间，IP及端口信息
			integrationFileClient = new IntegrationFileClient( textBox1.Text, port )
			{
				ConnectTimeOut = 5000,                                                      // 连接的超时时间
				Token = new Guid( textBox15.Text ),                                         // 指定一个令牌（不是必须的）
				LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs\\log.txt" ),   // 指定日志（不是必须的）
				FileCacheSize = fileCache * 1024,                                           // 文件缓存大小，越大速度越快，越占内存，2M比较适合
			};

			// 创建本地文件存储的路径
			string path = Application.StartupPath + @"\Files";
			if (!System.IO.Directory.Exists( path ))
			{
				System.IO.Directory.CreateDirectory( path );
			}

			button1.Enabled = false;
			panel2.Enabled = true;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			IntegrationFileClientInitialization( );
		}


		#endregion

		#region Upload File


		/*************************************************************************************************
		 * 
		 *   一条指令即可完成文件的上传操作，上传模式有三种
		 *   1. 指定本地的完整路径的文件名
		 *   2. 将流（stream）中的数据上传到服务器
		 *   3. 将bitmap图片数据上传到服务器
		 * 
		 ********************************************************************************************/

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

		private async void button3_Click( object sender, EventArgs e )
		{
			// 开始上传
			if (!string.IsNullOrEmpty( textBox3.Text ))
			{
				if(!System.IO.File.Exists( textBox3.Text ))
				{
					MessageBox.Show( "选择的文件不存在，退出！" );
					return;
				}

				// 点击开始上传，此处按照实际项目需求放到了后台线程处理，事实上这种耗时的操作就应该放到后台线程
				// click the button and start a background thread to upload file
				// System.Threading.Thread thread = new System.Threading.Thread( new System.Threading.ParameterizedThreadStart( (ThreadUploadFile) ) );
				// thread.IsBackground = true;
				// thread.Start( textBox3.Text );
				// progressBar1.Value = 0;

				button3.Enabled = false;
				string fileName = textBox3.Text;
				System.IO.FileInfo fileInfo = new System.IO.FileInfo( fileName );
				DateTime uploadStartTime = DateTime.Now;
				// 开始正式上传，关于三级分类，下面只是举个例子，上传成功后去服务器端寻找文件就能明白
				// start to upload file to server , u shold specify the catgray about the file
				OperateResult result = await integrationFileClient.UploadFileAsync(
					fileName,                       // 需要上传的原文件的完整路径，上传成功还需要个条件，该文件不能被占用
					fileInfo.Name,                  // 在服务器存储的文件名，带后缀，一般设置为原文件的文件名，当然您也可以重新设置名字
					textBox_upload_factory.Text,    // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_group.Text,      // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_id.Text,         // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_tag.Text,        // 这个文件的额外描述文本，可以为空（""）
					textBox_upload_name.Text,       // 文件的上传人，当然你也可以不使用，可以为空（""）
					UpdateReportProgress            // 文件上传时的进度报告，如果你不需要，指定为NULL就行，一般文件比较大，带宽比较小，都需要进度提示
					);
				button3.Enabled = true;
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
		}

		private void ThreadUploadFile( object filename )
		{
			if (filename is string fileName)
			{
				System.IO.FileInfo fileInfo = new System.IO.FileInfo( fileName );
				// 开始正式上传，关于三级分类，下面只是举个例子，上传成功后去服务器端寻找文件就能明白
				// start to upload file to server , u shold specify the catgray about the file
				OperateResult result = integrationFileClient.UploadFile(
					fileName,                       // 需要上传的原文件的完整路径，上传成功还需要个条件，该文件不能被占用
					fileInfo.Name,                  // 在服务器存储的文件名，带后缀，一般设置为原文件的文件名，当然您也可以重新设置名字
					textBox_upload_factory.Text,    // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_group.Text,      // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_id.Text,         // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_upload_tag.Text,        // 这个文件的额外描述文本，可以为空（""）
					textBox_upload_name.Text,       // 文件的上传人，当然你也可以不使用，可以为空（""）
					UpdateReportProgress            // 文件上传时的进度报告，如果你不需要，指定为NULL就行，一般文件比较大，带宽比较小，都需要进度提示
					);

				// 切换到UI前台显示结果 
				// Show Upload Result , Because it may be failed
				Invoke( new Action<OperateResult>( operateResult =>
				{
					button3.Enabled = true;
					if (result.IsSuccess)
					{
						// file upload success
						MessageBox.Show( "文件上传成功！" );
					}
					else
					{
						// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
						// mostly failed by network exception, like offline
						MessageBox.Show( "文件上传失败：" + result.ToMessageShowString( ) );
					}
				} ), result );
			}
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

			label10.Text = sended + "/" + totle;
			progressBar1.Value = value;
		}



		#endregion

		#region Download File


		/*************************************************************************************************
		 * 
		 *   一条指令即可完成文件的下载操作，下载模式有三种
		 *   1. 指定需要下载的文件名（带后缀）
		 *   2. 将服务器上的数据下载到流（stream）中
		 *   3. 将服务器上的数据下载到bitmap图片中
		 * 
		 ********************************************************************************************/

		private async void button4_Click( object sender, EventArgs e )
		{
			// 点击开始下载，此处按照实际项目需求放到了后台线程处理，事实上这种耗时的操作就应该放到后台线程
			// click this button to start a backgroud thread for downloading file
			progressBar2.Value = 0;
			button4.Enabled = false;

			string fileName = textBox_download_fileName.Text;
			DateTime downloadStartTime = DateTime.Now;
			OperateResult result = await integrationFileClient.DownloadFileAsync(
					fileName,                                              // 文件在服务器上保存的名称，举例123.txt
					textBox_download_factory.Text,                         // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_group.Text,                           // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_id.Text,                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					DownloadReportProgress,                                // 文件下载的时候的进度报告，友好的提示下载进度信息
					Application.StartupPath + @"\Files\" + fileName        // 下载后在文本保存的路径，也可以直接下载到 MemoryStream 的数据流中，或是bitmap中，或是手动选择存储路径
					);

			button4.Enabled = true;
			if (result.IsSuccess)
			{
				// message: file download success
				MessageBox.Show( "文件下载成功！耗时：" + (DateTime.Now - downloadStartTime).TotalSeconds.ToString( "F1" ) + " 秒" );
			}
			else
			{
				// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
				// mostly failed by network exception, like offline, and file not exsist,
				MessageBox.Show( "文件下载失败：" + result.ToMessageShowString( ) );
			}
		}

		private void button10_Click( object sender, EventArgs e )
		{
			string fileName = textBox_download_fileName.Text;
			OperateResult<bool> result = integrationFileClient.IsFileExists(
					fileName,                                              // 文件在服务器上保存的名称，举例123.txt
					textBox_download_factory.Text,                         // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_group.Text,                           // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_id.Text                               // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
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

		private void ThreadDownloadFile( object filename )
		{
			if (filename is string fileName)
			{
				OperateResult result = integrationFileClient.DownloadFile(
					fileName,                                              // 文件在服务器上保存的名称，举例123.txt
					textBox_download_factory.Text,                         // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_group.Text,                           // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					textBox_download_id.Text,                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
					DownloadReportProgress,                                // 文件下载的时候的进度报告，友好的提示下载进度信息
					Application.StartupPath + @"\Files\" + filename        // 下载后在文本保存的路径，也可以直接下载到 MemoryStream 的数据流中，或是bitmap中，或是手动选择存储路径
					);

				// 切换到UI前台显示结果
				Invoke( new Action<OperateResult>( operateResult =>
				{
					button4.Enabled = true;
					if (result.IsSuccess)
					{
						// message: file download success
						MessageBox.Show( "文件下载成功！" );
					}
					else
					{
						// 失败原因多半来自网络异常，还有文件不存在，分类名称填写异常
						// mostly failed by network exception, like offline, and file not exsist,
						MessageBox.Show( "文件下载失败：" + result.ToMessageShowString( ) );
					}
				} ), result );
			}
		}

		/// <summary>
		/// 用于更新文件下载进度的方法，该方法是线程安全的
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
			label9.Text = receive + "/" + totle;
		}


		#endregion

		#region Delete Files

		private async void button5_Click( object sender, EventArgs e )
		{
			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await integrationFileClient.DeleteFileAsync( 
				textBox_delete_fileName.Text,                       // 文件在服务器上保存的名称，举例123.txt
				textBox_delete_factory.Text,                        // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_group.Text,                          // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_id.Text                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
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

		private async void button9_Click( object sender, EventArgs e )
		{
			// 文件的删除不需要放在后台线程，前台即可处理，无论多少大的文件，无论该文件是否在下载中，都是很快删除的
			OperateResult result = await integrationFileClient.DeleteFolderFilesAsync(
				textBox_delete_factory.Text,                        // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_group.Text,                          // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_id.Text                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "文件信息删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "文件删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			OperateResult result = integrationFileClient.DeleteEmptyFolders(
				textBox_delete_factory.Text,                        // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_group.Text,                          // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_id.Text                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				);
			if (result.IsSuccess)
			{
				// delete file success
				MessageBox.Show( "空目录信息删除成功！" );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "空目录信息删除失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void button12_Click( object sender, EventArgs e )
		{
			OperateResult<GroupFileInfo> result = await integrationFileClient.GetGroupFileInfoAsync(
				textBox_delete_factory.Text,                        // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_group.Text,                          // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_id.Text                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				);
			if (result.IsSuccess)
			{
				// get file size success
				label22.Text = result.Content.ToString( );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "获取文件大小失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		private async void button13_Click( object sender, EventArgs e )
		{
			OperateResult<GroupFileInfo[]> result = await integrationFileClient.GetSubGroupFileInfosAsync(
				textBox_delete_factory.Text,                        // 第一级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_group.Text,                          // 第二级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				textBox_delete_id.Text                              // 第三级分类，指示文件存储的类别，对应在服务器端存储的路径不一致
				);
			if (result.IsSuccess)
			{
				MessageBox.Show( result.Content.ToJsonString( ) );
			}
			else
			{
				// 删除失败的原因除了一般的网络问题，还有因为服务器的文件不存在，会在Message里有显示。
				// file not exsist or net work exception
				MessageBox.Show( "获取文件大小失败，原因：" + result.ToMessageShowString( ) );
			}
		}

		#endregion

		#region DownloadPathFolders


		private void FillNodeByFactoryGroupId( TreeNode root, OperateResult<string[]> read, int grade )
		{
			root.Nodes.Clear( );
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					TreeNode node = new TreeNode( item );
					node.Tag = grade;
					node.Nodes.Add( new TreeNode( ) );
					root.Nodes.Add( node );
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


		private void FillNodeFilesByFactoryGroupId( TreeNode root, OperateResult<GroupFileItem[]> read )
		{
			root.Nodes.Clear( );
			root.ExpandAll( );
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					TreeNode node = new TreeNode( item.FileName );
					node.Tag = item;
					root.Nodes.Add( node );
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
			FillNodeByFactoryGroupId( treeView1.Nodes[0], await integrationFileClient.DownloadPathFoldersAsync( "", "", "" ), 1 );
			button6.Enabled = true;
			treeView1.Nodes[0].ExpandAll( );
		}


		private async void treeView1_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				if(node.Tag is int grade)
				{
					if(grade == 1)
					{
						FillNodeByFactoryGroupId( node, await integrationFileClient.DownloadPathFoldersAsync( node.Text, "", "" ), 2 );
					}
					else if(grade == 2)
					{
						FillNodeByFactoryGroupId( node, await integrationFileClient.DownloadPathFoldersAsync( node.Parent.Text, node.Text, "" ), 3 );
					}
					else if(grade == 3)
					{
						FillNodeFilesByFactoryGroupId( node, await integrationFileClient.DownloadPathFileNamesAsync( node.Parent.Parent.Text, node.Parent.Text, node.Text ) );
					}
				}
			}
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				if (node.Tag is GroupFileItem fileItem)
				{
					List<string> list = new List<string>( 3 ) { string.Empty, string.Empty, string.Empty };
					list[0] = node.Parent?.Parent?.Parent?.Text;
					list[1] = node.Parent?.Parent?.Text;
					list[2] = node.Parent?.Text;
					for (int i = 2; i >= 0; i--)
						if (string.IsNullOrEmpty( list[i] )) list.RemoveAt( i );
					if (list.Count > 0) textBox_show_factory.Text = list[0];
					if (list.Count > 1) textBox_show_group.Text = list[1];
					if (list.Count > 2) textBox_show_id.Text = list[2];

					textBox_file_fileName.Text = fileItem.FileName;
					textBox_file_fileSize.Text = fileItem.FileSize.ToString( );
					textBox_file_date.Text = fileItem.UploadTime.ToString( );
					textBox_file_dowloadTimes.Text = fileItem.DownloadTimes.ToString( );
					textBox_file_upload.Text = fileItem.Owner;
					textBox_file_tag.Text = fileItem.Description;
				}
			}
		}


		private void TestMethod()
		{
			// 浏览服务器的指定节点的所有文件信息
			// Browser Your path files on server
			OperateResult<GroupFileItem[]> read = integrationFileClient.DownloadPathFileNames( "Files", "Group",  "id" );
			if (read.IsSuccess)
			{
				foreach (var item in read.Content)
				{
					
				}
				
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 开启压力测试
			threadlength = 20;
			upSuccess = 0;
			downSuccess = 0;
			deleteSuccess = 0;
			for (int i = 0; i < threadlength; i++)
			{
				new System.Threading.Thread( new System.Threading.ParameterizedThreadStart( ServerPressureTest ) ) { IsBackground = true }.Start( "B" + i );
			}
			button7.Enabled = false;
		}

		private int threadlength = 20;
		Random random = new Random( );
		private int upSuccess = 0;
		private int downSuccess = 0;
		private int deleteSuccess = 0;

		private void ServerPressureTest( object obj )
		{
			if (obj is string path)
			{
				string pathNew = System.IO.Path.Combine( Application.StartupPath, path );
				System.IO.Directory.CreateDirectory( pathNew );
				for (int j = 0; j < 100; j++)
				{
					string fileName = path + "-A" + random.Next( 500 ) + ".txt";
					string fullName = System.IO.Path.Combine( pathNew, fileName );

					StringBuilder sb = new StringBuilder( );
					for (int i = 0; i < 1024; i++)
					{
						sb.Append( '1' );
					}
					System.IO.File.WriteAllText( fullName, sb.ToString( ), Encoding.UTF8 );
					if (integrationFileClient.UploadFile( fullName, "Files", "Group", "id", null ).IsSuccess) upSuccess++;
					System.IO.File.Delete( fullName );
					if (!integrationFileClient.IsFileExists( fileName, "Files", "Group", "id" ).Content)
					{
						upSuccess--;
						continue;
					}

					if (integrationFileClient.DownloadFile( fileName, "Files", "Group", "id", null, fullName ).IsSuccess) downSuccess++;
					System.IO.File.Delete( fullName );


					if (integrationFileClient.DeleteFile( fileName, "Files", "Group", "id" ).IsSuccess) deleteSuccess++;
					if (integrationFileClient.IsFileExists( fileName, "Files", "Group", "id" ).Content)
					{
						deleteSuccess--;
						continue;
					}
				}
				System.IO.Directory.Delete( pathNew );
				if(System.Threading.Interlocked.Decrement(ref threadlength) == 0)
				{
					Invoke( new Action( ( ) =>
					 {
						 button7.Enabled = true;
						 MessageBox.Show( "成功上传次数：" + upSuccess + Environment.NewLine + "成功下载次数：" + downSuccess + Environment.NewLine + "成功删除次数：" + deleteSuccess );
					 } ) );
				}
			}

		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 开启压力测试
			threadlength = 20;
			upSuccess = 0;
			downSuccess = 0;
			deleteSuccess = 0;
			for (int i = 0; i < threadlength; i++)
			{
				System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ServerPressureTest2 ), "B" + i );
			}
			button8.Enabled = false;
		}

		private async void ServerPressureTest2( object obj )
		{
			if (obj is string path)
			{
				string pathNew = System.IO.Path.Combine( Application.StartupPath, path );
				System.IO.Directory.CreateDirectory( pathNew );
				for (int j = 0; j < 100; j++)
				{
					string fileName = "A" + random.Next( 500 ) + ".txt";
					string fullName = System.IO.Path.Combine( pathNew, fileName );

					StringBuilder sb = new StringBuilder( );
					for (int i = 0; i < 1024; i++)
					{
						sb.Append( '1' );
					}
					System.IO.File.WriteAllText( fullName, sb.ToString( ), Encoding.UTF8 );
					if ((await integrationFileClient.UploadFileAsync( fullName, "Files", "Group", "id", null )).IsSuccess) upSuccess++;
					System.IO.File.Delete( fullName );
					if ((await integrationFileClient.DownloadFileAsync( fileName, "Files", "Group", "id", null, fullName )).IsSuccess) downSuccess++;
					System.IO.File.Delete( fullName );
					// if (integrationFileClient.DeleteFile( fileName, "Files", "Group", "id" ).IsSuccess) deleteSuccess++;
				}
				System.IO.Directory.Delete( pathNew );
				if (System.Threading.Interlocked.Decrement( ref threadlength ) == 0)
				{
					Invoke( new Action( ( ) =>
					{
						button8.Enabled = true;
						MessageBox.Show( "成功上传次数：" + upSuccess + Environment.NewLine + "成功下载次数：" + downSuccess + Environment.NewLine + "成功删除次数：" + deleteSuccess );
					} ) );
				}
			}

		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlToken, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlToken ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
