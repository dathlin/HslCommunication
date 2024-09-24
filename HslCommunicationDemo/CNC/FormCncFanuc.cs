using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.CNC.Fanuc;
using HslCommunication;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region FormMqttSyncClient


	public partial class FormCncFanuc : HslFormContent
	{
		public FormCncFanuc( )
		{
			InitializeComponent( );

		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			textBox7.Text = System.IO.Path.Combine( Application.StartupPath, "O6.txt" );
			textBox_path.Text = "//CNC_MEM/USER/PATH1/";

			imageList = new ImageList( );
			imageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
			imageList.Images.Add( "file", Properties.Resources.file );
			treeView1.ImageList = imageList;
			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.MouseDown += TreeView1_MouseDown;

			AddNCToolStripMenuItem.Click += AddNCToolStripMenuItem_Click;
			readNCToolStripMenuItem.Click += ReadNCToolStripMenuItem_Click;
			deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
			readNcLocalToolStripMenuItem.Click += ReadNcLocalToolStripMenuItem_Click;
			Language( Program.Language );

			panel4.Paint += Panel4_Paint;
		}


		private void Panel4_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, panel4.Width - 1, panel4.Height - 1 ) );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "Fanuc 0i-mf Test";
				label1.Text   = "Ip:";
				label3.Text   = "Port:";
				button1.Text  = "Connect";
				button2.Text  = "Disconnect";
				label12.Text  = "Receive:";
				label4.Text   = "Addr:";
				label10.Text  = "Addr:";
				label6.Text   = "Len:";
				label8.Text   = "Prog Path";
				label11.Text  = "Data:";
				button23.Text = "Read";
				button25.Text = "Set Main Program";
				button31.Text = "Write";
				button27.Text = "Down Program";
				button28.Text = "Read Program";
				button29.Text = "Del Program";
				label15.Text = "Right Mouse Click";


			}
		}

		private FanucSeries0i fanuc;

		private async void button1_Click( object sender, EventArgs e )
		{
			fanuc?.ConnectClose( );
			fanuc = new FanucSeries0i( textBox1.Text, int.Parse( textBox2.Text ) );
			fanuc.LogNet = this.LogNet;
			button1.Enabled = false;
			OperateResult connect = await fanuc.ConnectServerAsync( );

			if(connect.IsSuccess)
			{
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );

				textBox_code.Text = $"FanucSeries0i fanuc = new FanucSeries0i( \"{textBox1.Text}\", int.Parse( \"{textBox2.Text}\" ) );";
			}
			else
			{
				button1.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
					"Error: " + connect.ErrorCode );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			fanuc.ConnectClose( );
		}

		private void button32_Click( object sender, EventArgs e )
		{
			// 系统信息
			OperateResult<FanucSysInfo> read = fanuc.ReadSysInfo( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<FanucSysInfo> read = fanuc.ReadSysInfo( );";
		}

		private void button34_Click( object sender, EventArgs e )
		{
			// 操作信息
			OperateResult<FanucOperatorMessage[]> read = fanuc.ReadOperatorMessage( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<FanucOperatorMessage[]> read = fanuc.ReadOperatorMessage( );";
		}
		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<SysStatusInfo> read= fanuc.ReadSysStatusInfo( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<SysStatusInfo> read= fanuc.ReadSysStatusInfo( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<SysAlarm[]> read = fanuc.ReadSystemAlarm( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<SysAlarm[]> read = fanuc.ReadSystemAlarm( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<SysAllCoors> read = fanuc.ReadSysAllCoors( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<SysAllCoors> read = fanuc.ReadSysAllCoors( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			OperateResult<int[]> read = fanuc.ReadProgramList( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int[]> read = fanuc.ReadProgramList( );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string, int> read = fanuc.ReadSystemProgramCurrent( );
			if (read.IsSuccess)
			{
				textBox8.Text = "程序名：" + read.Content1 + Environment.NewLine + "程序号：" + read.Content2;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string, int> read = fanuc.ReadSystemProgramCurrent( );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			OperateResult<double, double> read = fanuc.ReadSpindleSpeedAndFeedRate( );
			if (read.IsSuccess)
			{
				textBox8.Text = "主轴转速：" + read.Content1 + Environment.NewLine + "进给倍率：" + read.Content2;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double, double> read = fanuc.ReadSpindleSpeedAndFeedRate( );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			OperateResult<double[]> read = fanuc.ReadFanucAxisLoad( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double[]> read = fanuc.ReadFanucAxisLoad( );";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			OperateResult<CutterInfo[]> read = fanuc.ReadCutterInfos( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<CutterInfo[]> read = fanuc.ReadCutterInfos( );";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = fanuc.ReadCurrentForegroundDir( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = fanuc.ReadCurrentForegroundDir( );";
		}

		private void button22_Click( object sender, EventArgs e )
		{
			// 系统语言
			OperateResult<ushort> read = fanuc.ReadLanguage( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString() + Environment.NewLine +
					"此处举几个常用值 0: 英语 1: 日语 2: 德语 3: 法语 4: 中文繁体 6: 韩语 15: 中文简体 16: 俄语 17: 土耳其语";
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<ushort> read = fanuc.ReadLanguage( );";
		}
		private void button12_Click( object sender, EventArgs e )
		{
			OperateResult<double[]> read = fanuc.ReadDeviceWorkPiecesSize( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double[]> read = fanuc.ReadDeviceWorkPiecesSize( );";
		}

		private void button13_Click( object sender, EventArgs e )
		{
			OperateResult<int> read = fanuc.ReadAlarmStatus( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = fanuc.ReadAlarmStatus( );";
		}

		private void ReadTimeData( int type )
		{
			OperateResult<long> read = fanuc.ReadTimeData( type );
			if (read.IsSuccess)
			{
				textBox8.Text = $"{read.Content / 3600} H {read.Content % 3600 / 60} M {read.Content % 3600 % 60} S";
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<long> read = fanuc.ReadTimeData( {type} );";
		}
		private void button14_Click( object sender, EventArgs e )
		{
			// 开机时间
			ReadTimeData( 0 );
		}

		private void button15_Click( object sender, EventArgs e )
		{
			// 运行时间
			ReadTimeData( 1 );
		}

		private void button16_Click( object sender, EventArgs e )
		{
			// 切割时间
			ReadTimeData( 2 );
		}

		private void button17_Click( object sender, EventArgs e )
		{
			// 空闲时间
			ReadTimeData( 3 );
		}

		private void button24_Click( object sender, EventArgs e )
		{
			// 当前的程序
			OperateResult<string> read = fanuc.ReadCurrentProgram( );
			if (read.IsSuccess)
			{
				textBox8.Text = "程序内容：" + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = fanuc.ReadCurrentProgram( );";
		}

		private void button30_Click( object sender, EventArgs e )
		{
			// 当前的刀号
			OperateResult<int> read = fanuc.ReadCutterNumber( );
			if (read.IsSuccess)
			{
				textBox8.Text = "刀号：" + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = fanuc.ReadCutterNumber( );";
		}

		private async void button28_Click( object sender, EventArgs e )
		{
			// 读取程序

			button28.Enabled = false;
			//OperateResult<string> read = fanuc.ReadProgram( programNum, textBox_path.Text );
			OperateResult<string> read = await fanuc.ReadProgramAsync( textBox9.Text, textBox_path.Text );
			button28.Enabled = true;
			if (read.IsSuccess)
			{
				textBox_program.Text = "程序内容：" + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "读取失败！" + read.ToMessageShowString( ) );
			}

			textBox_code2.Text = $"OperateResult<string> read = fanuc.ReadProgram( \"{textBox9.Text}\", \"{textBox_path.Text}\" );";
		}

		private void button29_Click( object sender, EventArgs e )
		{
			// 删除程序
			string path = textBox_path.Text;
			if (!path.EndsWith( "/" )) path = path + "/";

			OperateResult read = fanuc.DeleteFile( path + textBox9.Text );
			if (read.IsSuccess)
			{
				MessageBox.Show( Program.Language == 1 ? "删除程序成功！" : "Delete program file success! path: " + path + textBox9.Text );
			}
			else
			{
				MessageBox.Show( "删除失败！" + read.ToMessageShowString( ) );
			}

			textBox_code2.Text = $"OperateResult read = fanuc.DeleteFile( \"{path + textBox9.Text}\" );";
		}
		private void button25_Click( object sender, EventArgs e )
		{
			// 设置为主程序
			if (!ushort.TryParse( textBox6.Text, out ushort programNum ))
			{
				MessageBox.Show( "主程序号输入错误！" );
				return;
			}
			OperateResult set = fanuc.SetCurrentProgram( programNum );
			if (set.IsSuccess)
			{
				MessageBox.Show( "设置主程序成功！" );
			}
			else
			{
				MessageBox.Show( "设置主程序失败！" + set.ToMessageShowString( ) );
			}

			textBox_code2.Text = $"OperateResult set = fanuc.SetCurrentProgram( {programNum} );";
		}

		private async void button27_Click( object sender, EventArgs e )
		{
			if (!System.IO.File.Exists( textBox7.Text ))
			{
				MessageBox.Show( "文件不存在!" );
				return;
			}
			// 下载程序
			button27.Enabled = false;
			OperateResult write = await fanuc.WriteProgramFileAsync( textBox7.Text, 512, textBox_path.Text );
			button27.Enabled = true;
			if (write.IsSuccess)
			{
				MessageBox.Show( "下载成功！" );
			}
			else
			{
				MessageBox.Show( "下载失败！" + write.Message );
			}

			textBox_code2.Text = $"OperateResult write = fanuc.WriteProgramFile( \"{textBox7.Text}\", 512, \"{textBox_path.Text}\" );";
		}
		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult start = fanuc.StartProcessing( );
			if (start.IsSuccess)
			{
				MessageBox.Show( "启动成功！" );
			}
			else
			{
				MessageBox.Show( "启动失败！"  + start.ToMessageShowString());
			}

			textBox_code.Text = $"OperateResult start = fanuc.StartProcessing( );";
		}
		private void button18_Click( object sender, EventArgs e )
		{
			if(!int.TryParse( textBox3.Text, out int address ))
			{
				MessageBox.Show( "宏变量地址输入错误！" );
				return;
			}
			OperateResult<double> read = fanuc.ReadSystemMacroValue( address );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double> read = fanuc.ReadSystemMacroValue( {address} );";
			//for (int i = 0; i < 10000; i++)
			//{
			//	OperateResult<double> read = await fanuc.ReadSystemMacroValueAsync( address + i );
			//	if (read.IsSuccess)
			//	{
			//		textBox8.AppendText( $"{DateTime.Now} [{address + i}] : {read.Content}{Environment.NewLine}" );
			//		if (read.Content.ToString( ) == "1000") break;
			//	}
			//	else
			//	{
			//		textBox8.AppendText( $"{DateTime.Now} [{address + i}] : failed{Environment.NewLine}" );
			//		// MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			//	}
			//}
			//textBox8.AppendText( $"{DateTime.Now} Finish{Environment.NewLine}" );
		}

		private void button36_Click( object sender, EventArgs e )
		{
			// 写数据到宏变量
			if (!int.TryParse( textBox3.Text, out int address ))
			{
				MessageBox.Show( "宏变量地址输入错误！" );
				return;
			}

			if (!double.TryParse(textBox4.Text, out double value ))
			{
				MessageBox.Show( "写入宏变量的值输入错误！" );
				return;
			}

			OperateResult read = fanuc.WriteSystemMacroValue( address, new double[] { value } );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Write Success!"  );
			}
			else
			{
				MessageBox.Show( "Write Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult read = fanuc.WriteSystemMacroValue( {address}, new double[] {{{value}}} );";
		}

		private void button19_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = fanuc.ReadCurrentDateTime( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( "yyyy-MM-dd HH:mm:ss" );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = fanuc.ReadCurrentDateTime( );";
		}

		private void button20_Click( object sender, EventArgs e )
		{
			// 已加工数量
			OperateResult<int> read = fanuc.ReadCurrentProduceCount( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = fanuc.ReadCurrentProduceCount( );";
		}

		private void button21_Click( object sender, EventArgs e )
		{
			// 总加工数量
			OperateResult<int> read = fanuc.ReadExpectProduceCount( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = fanuc.ReadExpectProduceCount( );";
		}

		private void button23_Click( object sender, EventArgs e )
		{
			// 读数据
			OperateResult<byte[]> read = fanuc.ReadPMCData( textBox_pmc_read.Text, ushort.Parse( textBox_pmc_length.Text ) );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToHexString( ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<byte[]> read = fanuc.ReadPMCData( \"{textBox_pmc_read.Text}\", ushort.Parse( \"{textBox_pmc_length.Text}\" ) );";
		}

		private void button31_Click( object sender, EventArgs e )
		{
			// 写数据
			OperateResult write = fanuc.WritePMCData( textBox_pmc_write.Text, textBox_pmc_Data.Text.ToHexBytes( ) );

			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success!" );
			}
			else
			{
				MessageBox.Show( "Write Failed:" + write.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult write = fanuc.WritePMCData( \"{textBox_pmc_write.Text}\", \"{textBox_pmc_Data.Text}\".ToHexBytes( ) );";
		}
		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void panel3_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, panel3.Width - 1, panel3.Height - 1 ) );
		}

		private string GetPathFromTree( TreeNode treeNode )
		{
			if (treeNode.Parent == null) return "//" + treeNode.Text + "/";
			if (treeNode.Tag is FileDirInfo fileDirInfo)
			{
				if (!fileDirInfo.IsDirectory)
				{
					return GetPathFromTree( treeNode.Parent ) + treeNode.Text;
				}
				else
				{
					return GetPathFromTree( treeNode.Parent ) + treeNode.Text + "/";
				}
			}
			return GetPathFromTree( treeNode.Parent ) + treeNode.Text + "/";
		}

		private void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if (e.Node == null) return;
			if (e.Node.Tag is FileDirInfo fileDirInfo)
			{
				if (!fileDirInfo.IsDirectory)
				{
					textBox_program.Text = fileDirInfo.ToString( );
					textBox9.Text = fileDirInfo.Name;
					if (e.Node.Parent?.Tag is FileDirInfo parent)
					{
						textBox_path.Text = GetPathFromTree( e.Node.Parent );
					}
				}
				else
				{
					textBox_path.Text = GetPathFromTree( e.Node );
					List<string> list = new List<string>( );
					foreach (TreeNode item in e.Node.Nodes)
					{
						if (item.Tag is FileDirInfo file)
						{
							if (!file.IsDirectory)
								list.Add( file.ToString( ) );
						}
					}
					textBox_program.Text = list.ToJsonString( );
				}
			}
		}

		private void BrowerFile( TreeNode treeNode )
		{
			OperateResult<FileDirInfo[]> read = fanuc.ReadAllDirectoryAndFile( GetPathFromTree( treeNode ) );
			if (read.IsSuccess)
			{
				foreach(FileDirInfo fileDirInfo in read.Content)
				{
					TreeNode node = new TreeNode( fileDirInfo.Name );
					node.Tag = fileDirInfo;
					treeNode.Nodes.Add( node );

					if (fileDirInfo.IsDirectory)
					{
						node.ImageKey = "Class_489";
						node.SelectedImageKey = "Class_489";
						BrowerFile( node );
					}
					else
					{
						node.ImageKey = "file";
						node.SelectedImageKey = "file";
					}
				}
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}
		private void TreeView1_MouseDown( object sender, MouseEventArgs e )
		{
			TreeNode treeNode = treeView1.GetNodeAt( e.Location );
			if (treeNode == null) return;

			treeView1.SelectedNode = treeNode;
			if (treeNode.Parent == null) return;

			if (e.Button == MouseButtons.Right)
				contextMenuStrip1.Show( treeView1, e.Location );
		}

		private async void DeleteToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			string path = GetPathFromTree( treeNode );
			OperateResult write = await fanuc.DeleteFileAsync( path );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Delete success！" );
			}
			else
			{
				MessageBox.Show( "delete failed！" + write.Message );
			}
		}

		private async void ReadNCToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is FileDirInfo fileDirInfo)
			{
				if (fileDirInfo.IsDirectory) return;

				string path = GetPathFromTree( treeNode.Parent );
				//int program = int.Parse( fileDirInfo.Name.Substring( 1 ) );

				//OperateResult<string> read = fanuc.ReadProgram( program, path );
				OperateResult<string> read = await fanuc.ReadProgramAsync( fileDirInfo.Name, path );
				if (read.IsSuccess)
				{
					textBox_program.Text = $"Program Content[{path}]：" + Environment.NewLine + read.Content;
				}
				else
				{
					MessageBox.Show( "read failed！" + read.ToMessageShowString( ) );
				}
			}
		}

		private async void ReadNcLocalToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is FileDirInfo fileDirInfo)
			{
				if (fileDirInfo.IsDirectory) return;

				string path = GetPathFromTree( treeNode.Parent );
				//int program = int.Parse( fileDirInfo.Name.Substring( 1 ) );

				//OperateResult<string> read = fanuc.ReadProgram( program, path );
				OperateResult<string> read = await fanuc.ReadProgramAsync( fileDirInfo.Name, path );
				if (read.IsSuccess)
				{
					// 弹窗让用户选择保存的文件路径
					SaveFileDialog sfd = new SaveFileDialog( );
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						string fileName = sfd.FileName;
						System.IO.File.WriteAllText( fileName, read.Content );
						MessageBox.Show( "Save success!" );
					}
				}
				else
				{
					MessageBox.Show( "read failed！" + read.ToMessageShowString( ) );
				}
			}
		}
		private async void AddNCToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is FileDirInfo fileDirInfo)
			{
				if (!fileDirInfo.IsDirectory)
				{
					MessageBox.Show( "Add nc program must select path!" );
					return;
				}

				string path = GetPathFromTree( treeNode );
				OpenFileDialog openFileDialog = new OpenFileDialog( );
				if(openFileDialog.ShowDialog( this ) == DialogResult.OK)
				{
					OperateResult write = await fanuc.WriteProgramFileAsync( openFileDialog.FileName, 512, path );
					if (write.IsSuccess)
					{
						MessageBox.Show( "Success！" );
					}
					else
					{
						MessageBox.Show( "failed！" + write.ToMessageShowString() );
					}
				}

			}
		}

		private ImageList imageList;


		private void button33_Click( object sender, EventArgs e )
		{
			treeView1.Nodes[0].Nodes.Clear( );
			BrowerFile( treeView1.Nodes[0] );
			treeView1.Nodes[0].ExpandAll( );
			//OperateResult<FileDirInfo[]> read = fanuc.ReadAllDirects( textBox_path.Text );
			//if (read.IsSuccess)
			//{
			//	textBox8.Text = read.Content.ToJsonString( );
			//}
			//else
			//{
			//	MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			//}
		}

		private void button35_Click( object sender, EventArgs e )
		{
			fanuc.OperatePath = short.Parse( textBox_op_path.Text );
			MessageBox.Show( "Success!" );

			textBox_code.Text = $"fanuc.OperatePath = short.Parse( \"{textBox_op_path.Text}\" );";
		}

		private void button37_Click( object sender, EventArgs e )
		{
			// 轴名称列表
			OperateResult<string[]> read = fanuc.ReadAxisNames( );
			if (read.IsSuccess)
			{
				textBox8.Text = "轴名称：" + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string[]> read = fanuc.ReadAxisNames( );";
		}

		private void button38_Click( object sender, EventArgs e )
		{
			// 主轴名称列表
			OperateResult<string[]> read = fanuc.ReadSpindleNames( );
			if (read.IsSuccess)
			{
				textBox8.Text = "主轴：" + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string[]> read = fanuc.ReadSpindleNames( );";
		}

		private void button39_Click( object sender, EventArgs e )
		{
			// 读诊断
			OperateResult<double[]> read = fanuc.ReadDiagnoss( int.Parse( textBox_read_diagnoss.Text ), int.Parse( textBox_diagnoss_length.Text ), int.Parse( textBox_diagnoss_axis.Text ) );
			if (read.IsSuccess)
			{
				textBox8.Text = "诊断：" + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double[]> read = fanuc.ReadDiagnoss( {textBox_read_diagnoss.Text}, {textBox_diagnoss_length.Text}, {textBox_diagnoss_axis.Text} );";
		}

		private void button40_Click( object sender, EventArgs e )
		{
			// 读当前刀组
			OperateResult<int> read = fanuc.ReadUseToolGroupId( );
			if (read.IsSuccess)
			{
				textBox8.Text = "当前刀组：" + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = fanuc.ReadUseToolGroupId( );";
		}

		private void button41_Click( object sender, EventArgs e )
		{
			// 读刀组寿命
			short id = 0;
			try
			{
				id = Convert.ToInt16( textBox5.Text );
			}
			catch( Exception ex )
			{
				MessageBox.Show( "刀组号输入不正确：" + ex.Message );
				return;
			}
			OperateResult<ToolInformation> read = fanuc.ReadToolInfoByGroup( id );
			if (read.IsSuccess)
			{
				textBox8.Text = "刀具信息：" + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<ToolInformation> read = fanuc.ReadToolInfoByGroup( {id} );";
		}

		private void button42_Click( object sender, EventArgs e )
		{
			// 清除刀组号
			short id = 0;
			try
			{
				id = Convert.ToInt16( textBox5.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "刀组号输入不正确：" + ex.Message );
				return;
			}
			OperateResult read = fanuc.ClearToolGroup( id, id );
			if (read.IsSuccess)
			{
				textBox8.Text = "清除成功";
				MessageBox.Show( "清除成功" );
			}
			else
			{
				MessageBox.Show( "Clear Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult read = fanuc.ClearToolGroup( {id}, {id} );";
		}
	}


	#endregion
}
