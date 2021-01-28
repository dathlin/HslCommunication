using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication.Core;
using HslCommunication.Core.Net;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.Redis;
using HslCommunicationDemo.Toledo;

namespace HslCommunicationDemo
{
	public partial class FormSelect : Form
	{
		public static Color ThemeColor = Color.FromArgb( 64, 64, 64 );

		public FormSelect( )
		{
			InitializeComponent( );
			Form = this;

			imageList = new ImageList( );
			imageList.Images.Add( "Method_636",            Properties.Resources.Method_636 );        // 0
			imageList.Images.Add( "ab",                    Properties.Resources.ab );                // 1
			imageList.Images.Add( "fujifilm",              Properties.Resources.fujifilm );          // 2
			imageList.Images.Add( "HslCommunication",      Properties.Resources.HslCommunication );  // 3
			imageList.Images.Add( "idcard",                Properties.Resources.idcard );            // 4
			imageList.Images.Add( "inovance",              Properties.Resources.inovance );          // 5
			imageList.Images.Add( "keyence",               Properties.Resources.keyence );           // 6
			imageList.Images.Add( "ls",                    Properties.Resources.ls );                // 7
			imageList.Images.Add( "melsec",                Properties.Resources.melsec );            // 8
			imageList.Images.Add( "modbus",                Properties.Resources.modbus );            // 9
			imageList.Images.Add( "omron",                 Properties.Resources.omron );             // 10
			imageList.Images.Add( "panasonic",             Properties.Resources.panasonic );         // 11
			imageList.Images.Add( "redis",                 Properties.Resources.redis );             // 12
			imageList.Images.Add( "schneider",             Properties.Resources.schneider );         // 13
			imageList.Images.Add( "siemens",               Properties.Resources.siemens );           // 14
			imageList.Images.Add( "debug",                 Properties.Resources.debug );             // 15
			imageList.Images.Add( "barcode",               Properties.Resources.barcode );           // 16
			imageList.Images.Add( "mqtt",                  Properties.Resources.mqtt );              // 17
			imageList.Images.Add( "toledo",                Properties.Resources.toledo );            // 18
			imageList.Images.Add( "robot",                 Properties.Resources.robot );             // 19
			imageList.Images.Add( "beckhoff",              Properties.Resources.beckhoff );          // 20
			imageList.Images.Add( "abb",                   Properties.Resources.abb );               // 21
			imageList.Images.Add( "fatek",                 Properties.Resources.fatek );             // 22
			imageList.Images.Add( "kuka",                  Properties.Resources.kuka );              // 23
			imageList.Images.Add( "efort",                 Properties.Resources.efort );             // 24
			imageList.Images.Add( "fanuc",                 Properties.Resources.fanuc );             // 25
			imageList.Images.Add( "Class_489",             Properties.Resources.Class_489 );         // 26
			imageList.Images.Add( "zkt",                   Properties.Resources.zkt );               // 27
			imageList.Images.Add( "websocket",             Properties.Resources.websocket );         // 28
			imageList.Images.Add( "yaskawa",               Properties.Resources.yaskawa );           // 29
			imageList.Images.Add( "xinje",                 Properties.Resources.xinje );             // 30
			imageList.Images.Add( "yokogawa",              Properties.Resources.yokogawa );          // 31
			imageList.Images.Add( "delta",                 Properties.Resources.delta );             // 32
			imageList.Images.Add( "ge",                    Properties.Resources.ge );                // 33


			treeView1.ImageList = imageList;
			treeView2.ImageList = imageList;
		}



		private void FormLoad_Load( object sender, EventArgs e )
		{

			dockPanel1.Theme = vS2015BlueTheme1;


			ThemeColor = menuStrip1.BackColor;
			verisonToolStripMenuItem.Text = "Version: " + HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( );

			if (Settings1.Default.language == 1)
			{
				if (System.Globalization.CultureInfo.CurrentCulture.ToString( ).StartsWith( "zh" ))
				{
					Program.Language = 1;
					Language( Program.Language );
				}
				else
				{
					HslCommunication.StringResources.SeteLanguageEnglish( );
					Program.Language = 2;
					Language( Program.Language );
				}
			}
			else
			{
				Program.Language = 2;
				HslCommunication.StringResources.SeteLanguageEnglish( );
				Language( Program.Language );
			}

			support赞助ToolStripMenuItem.Click += Support赞助ToolStripMenuItem_Click;
			TreeViewIni( );

			new FormIndex( ).Show( dockPanel1 );
			//new FormHslMap( ).Show( dockPanel1 );

			LoadDeviceList( );

			timer = new Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );

			treeView2.MouseClick += TreeView2_MouseClick;
			deleteDeviceToolStripMenuItem.Click += DeleteDeviceToolStripMenuItem_Click;
		}

		private void TreeView2_MouseClick( object sender, MouseEventArgs e )
		{
			if(e.Button == MouseButtons.Right)
			{
				treeView2.SelectedNode = treeView2.GetNodeAt( e.Location );
				contextMenuStrip1.Show( treeView2, e.Location );
			}
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if(curpcp != null)
			{
				string RamInfo = (curpcp.NextValue( ) / MB_DIV).ToString( "F1" ) + "MB";
				label2.Text = "Ram: " + RamInfo;
			}
			label1.Text = $"Timeout:{HslCommunication.HslTimeOut.TimeOutCheckCount}  Lock:{SimpleHybirdLock.SimpleHybirdLockCount}  Wait:{SimpleHybirdLock.SimpleHybirdLockWaitCount}";
		}

		private HslCommunication.MQTT.MqttClient mqttClient;
		private System.Windows.Forms.Timer timer;
		private Process cur = null;
		private PerformanceCounter curpcp = null;
		private const int MB_DIV = 1024 * 1024;

		private void Support赞助ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using (HslCommunication.BasicFramework.FormSupport form = new HslCommunication.BasicFramework.FormSupport( ))
			{
				form.ShowDialog( );
			}
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "HslCommunication 测试工具";
				免责条款ToolStripMenuItem.Text = "全国使用分布";
				论坛toolStripMenuItem.Text = "博客";
				日志ToolStripMenuItem.Text = "API 文档";
				//授权ToolStripMenuItem.Text = "授权";
				tabPage1.Text = "所有设备列表";
				tabPage2.Text = "保存列表";
				deleteDeviceToolStripMenuItem.Text = "删除设备";
			}
			else
			{
				Text = "HslCommunication Test Tool";
				论坛toolStripMenuItem.Text = "Blog";
				免责条款ToolStripMenuItem.Text = "China Map";
				日志ToolStripMenuItem.Text = "API Doc";
				//授权ToolStripMenuItem.Text = "Authorize";
				tabPage1.Text = "All Devices";
				tabPage2.Text = "Save Devices";
			}
		}

		private void 论坛toolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start( "http://blog.hslcommunication.cn/" );
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void OpenWebside( string url )
		{
			try
			{
				System.Diagnostics.Process.Start( url );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void blogsToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.cnblogs.com/dathlin/p/7703805.html" );
		}

		private void webSideToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hslcommunication.cn/" );
		}

		private void toolStripMenuItem1_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hslcommunication.cn/MesDemo" );
		}
		private void 简体中文ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 简体中文
			HslCommunication.StringResources.SetLanguageChinese( );
			Program.Language = 1;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save( );
			Language( Program.Language );
			MessageBox.Show( "已选择中文" );
		}

		private void englishToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// English
			HslCommunication.StringResources.SeteLanguageEnglish( );
			Program.Language = 2;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save( );
			Language( Program.Language );
			MessageBox.Show( "Select English!" );
		}

		private void 日志ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://api.hslcommunication.cn" );
		}


		private void FormLoad_Shown( object sender, EventArgs e )
		{
			System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
		}

		private void ThreadPoolCheckVersion( object obj )
		{
			System.Threading.Thread.Sleep( 100 );
			mqttClient = new HslCommunication.MQTT.MqttClient( new HslCommunication.MQTT.MqttConnectionOptions( )
			{
				IpAddress = "118.24.36.220",
				Port = 1883,
				ClientId = "HslDemo"
			} );
			mqttClient.ConnectServer( );
			HslCommunication.Enthernet.NetSimplifyClient simplifyClient = new HslCommunication.Enthernet.NetSimplifyClient( "118.24.36.220", 18467 );
			HslCommunication.OperateResult<HslCommunication.NetHandle, string> read = simplifyClient.ReadCustomerFromServer( 1, HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( ) );
			if (read.IsSuccess)
			{
				HslCommunication.BasicFramework.SystemVersion version = new HslCommunication.BasicFramework.SystemVersion( read.Content2 );
				if (version > HslCommunication.BasicFramework.SoftBasic.FrameworkVersion)
				{
					// 有更新
					Invoke( new Action( ( ) =>
					 {
						 if (MessageBox.Show( "New version on server：" + read.Content2 + Environment.NewLine + " Start update?", "Version Check", MessageBoxButtons.YesNo ) == DialogResult.Yes)
						 {
							 try
							 {
								 System.Diagnostics.Process.Start( Application.StartupPath + "\\软件自动更新.exe" );
								 System.Threading.Thread.Sleep( 50 );
								 Close( );
							 }
							 catch(Exception ex)
							 {
								 MessageBox.Show( "更新软件丢失，无法启动更新： " + ex.Message );
							 }
						 }
					 } ) );
				}
			}

			try
			{
				cur = Process.GetCurrentProcess( );
				curpcp = new PerformanceCounter( "Process", "Working Set - Private", cur.ProcessName );
			}
			catch
			{

			}
		}

		private void 免责条款ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			new FormHslMap( ).Show( dockPanel1 );
			//Hide( );
			//System.Threading.Thread.Sleep( 200 );
			//using (FormDisclaimer form = new FormDisclaimer( ))
			//{
			//	form.ShowDialog( );
			//}
			//System.Threading.Thread.Sleep( 200 );
			//Show( );
		}

		private void authorization授权ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			new FormCharge( ).Show( dockPanel1 );
		}

		private ImageList imageList;
		private Dictionary<string, int> formIconImageIndex = new Dictionary<string, int>( );

		private TreeNode GetTreeNodeByIndex( string name, int index, Type form )
		{
			formIconImageIndex.Add( form.Name, index );
			return new TreeNode( name, index, index )
			{
				Tag = form
			};
		}

		private void TreeViewIni( )
		{
			// 三菱PLC相关
			TreeNode melsecNode = new TreeNode( "Melsec Plc [三菱]",   8, 8 );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)",    8, typeof( FormMelsecCipNet ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-1E (Binary)",       8, typeof( FormMelsec1EBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-1E (ASCII)",        8, typeof( FormMelsec1EAscii ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC (Binary)",         8, typeof( FormMelsecBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC Udp(Binary)",      8, typeof( FormMelsecUdp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC (ASCII)",          8, typeof( FormMelsecAscii ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC Udp(ASCII)",       8, typeof( FormMelsecAsciiUdp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC-R (Binary)",       8, typeof( FormMelsecRBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Serial【编程口】",  8, typeof( FormMelsecSerial ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Serial OverTcp",   8, typeof( FormMelsecSerialOverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Links【485】",     8, typeof( FormMelsecLinks ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Links OverTcp",    8, typeof( FormMelsecLinksOverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-3C (format1)",      8, typeof( FormMelsec3C ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-3C OverTcp",        8, typeof( FormMelsec3COverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Mc Virtual Server",   8, typeof( FormMcServer ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Mc Udp Server",       8, typeof( FormMcUdpServer ) ) );
			treeView1.Nodes.Add( melsecNode );

			// 西门子PLC相关
			TreeNode siemensNode = new TreeNode( "Siemens Plc [西门子]", 14, 14 );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S1200",           14, typeof( FormSiemensS1200 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S1500",           14, typeof( FormSiemensS1500 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S300",            14, typeof( FormSiemensS300 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S400",            14, typeof( FormSiemensS400 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S200",            14, typeof( FormSiemensS200 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S200 smart",      14, typeof( FormSiemensS200Smart ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "Fetch/Write",        14, typeof( FormSiemensFW ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "PPI",                14, typeof( FormSiemensPPI ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "PPI OverTcp",        14, typeof( FormSiemensPPIOverTcp ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "MPI",                14, typeof( FormSiemensMPI ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7 Virtual Server",  14, typeof( FormS7Server ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "Fetch Write Server", 14, typeof( FormFetchWriteServer ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "Siemens DTU",        14, typeof( FormSiemensDTU ) ) );
			treeView1.Nodes.Add( siemensNode );

			// Modbus协议
			TreeNode modbusNode = new TreeNode( "Modbus", 9, 9 );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Tcp",                9, typeof( FormModbus ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Udp",                9, typeof( FormModbusUdp ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Tcp[Alien]",         9, typeof( FormModbusAlien ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Rtu",                9, typeof( FormModbusRtu ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Rtu OverTcp",        9, typeof( FormModbusRtuOverTcp ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Ascii",              9, typeof( FormModbusAscii ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Server",             9, typeof( FormModbusServer ) ) );
			treeView1.Nodes.Add( modbusNode );

			// Modbus协议
			TreeNode inovanceNode = new TreeNode( "Inovance Plc[汇川]", 5, 5 );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceAMTcp",              5, typeof( FormInovanceAMTcp ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceAMSerial",           5, typeof( FormInovanceAMSerial ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceH3UTcp",             5, typeof( FormInovanceH3UTcp ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceH3USerial",          5, typeof( FormInovanceH3USerial ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceH5UTcp",             5, typeof( FormInovanceH5UTcp ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceH5USerial",          5, typeof( FormInovanceH5USerial ) ) );
			treeView1.Nodes.Add( inovanceNode );

			// 欧姆龙PLC相关
			TreeNode omronNode = new TreeNode( "Omron Plc[欧姆龙]", 10, 10 );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Tcp",                       10, typeof( FormOmron ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Udp",                       10, typeof( FormOmronUdp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)",               10, typeof( FormOmronCip ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Connected CIP",                  10, typeof( FormOmronConnectedCip ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink 【串口】",              10, typeof( FormOmronHostLink ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink OverTcp",               10, typeof( FormOmronHostLinkOverTcp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink C-Mode",                10, typeof( FormOmronHostLinkCMode ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "C-Mode OverTcp",                 10, typeof( FormOmronHostLinkCModeOverTcp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Virtual Server",            10, typeof( FormOmronServer ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Udp Server",                10, typeof( FormOmronUdpServer ) ) );
			treeView1.Nodes.Add( omronNode );

			// Lsis PLC
			TreeNode lsisNode = new TreeNode( "LSis Plc", 7, 7 );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "XGB Fast Enet",       7, typeof( FormLsisFEnet ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "XGB Cnet",            7, typeof( FormLsisCnet ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "XGB Cnet OverTcp",    7, typeof( FormLsisCnetOverTcp ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "XGK Cnet",            7, typeof( FormLsisXGKCnet ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "XGK Fast Enet",       7, typeof( FormLsisXGKFEnet ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "LSis Virtual Server", 7, typeof( FormLSisServer ) ) );
			treeView1.Nodes.Add( lsisNode );

			// Keyence PLC
			TreeNode keyencePlc = new TreeNode( "Keyence Plc[基恩士]", 6, 6 );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (Binary)",        6, typeof( FormKeyenceBinary ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (ASCII)",         6, typeof( FormKeyenceAscii ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "Nano (ASCII)",          6, typeof( FormKeyenceNanoSerial ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "Nano OverTcp",          6, typeof( FormKeyenceNanoSerialOverTcp ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "SR2000 [读码]",         6, typeof( FormKeyenceSR2000 ) ) );
			treeView1.Nodes.Add( keyencePlc );

			// Panasonic PLC
			TreeNode panasonicPlc = new TreeNode( "Panasonic Plc[松下]", 11, 11 );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (Binary)",         11, typeof( FormPanasonicBinary ) ) );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "Mewtocol",               11, typeof( FormPanasonicMew ) ) );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "Mewtocol OverTcp",       11, typeof( FormPanasonicMewOverTcp ) ) );
			treeView1.Nodes.Add( panasonicPlc );

			// Allen Bradlly PLC
			TreeNode allenBrandlyPlc = new TreeNode( "AllenBrandly[罗克韦尔]", 1, 1 );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)",        1, typeof( FormAllenBrandly ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "MicroCip(Micro800)",      1, typeof( FormAllenBrandlyMicroCip ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP Browser",             1, typeof( FormAllenBrandlyBrowser ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP Virtual Server",      1, typeof( FormCipServer ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "SLC Net",                 1, typeof( FormAllenBrandlySLC ) ) );
			treeView1.Nodes.Add( allenBrandlyPlc );

			// Beckhoff PLC
			TreeNode beckhoffPlc = new TreeNode( "Beckhoff Plc[倍福]", 20, 20 );
			beckhoffPlc.Nodes.Add( GetTreeNodeByIndex( "Ads Net",    20, typeof( FormBeckpffAdsNet ) ) );
			treeView1.Nodes.Add( beckhoffPlc );

			// GE PLC
			TreeNode gePlc = new TreeNode( "GE Plc[通用电气]", 33, 33 );
			gePlc.Nodes.Add( GetTreeNodeByIndex( "SRTP", 33, typeof( FormGeSRTP ) ) );
			gePlc.Nodes.Add( GetTreeNodeByIndex( "SRTP Server", 33, typeof( FormGeSRTPServer ) ) );
			treeView1.Nodes.Add( gePlc );

			// Fatek 永宏PLC
			TreeNode fatekNode = new TreeNode( "Fatek Plc[永宏]", 22, 22 );
			fatekNode.Nodes.Add( GetTreeNodeByIndex( "programe [编程口]", 22, typeof( FormFatekPrograme ) ) );
			fatekNode.Nodes.Add( GetTreeNodeByIndex( "programe OverTcp", 22, typeof( FormFatekProgrameOverTcp ) ) );
			treeView1.Nodes.Add( fatekNode );

			// Fuji Plc
			TreeNode fujiNode = new TreeNode( "Fuji Plc[富士]", 2, 2 );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB [编程口]", 2, typeof( FormFujiSPB ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB OverTcp", 2, typeof( FormFujiSPBOverTcp ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB Server", 2, typeof( FormFujiSPBServer ) ) );
			treeView1.Nodes.Add( fujiNode );

			// XinJE Plc
			TreeNode xinjeNode = new TreeNode( "XinJE Plc[信捷]", 30, 30 );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE XC Serial", 30, typeof( FormXinJEXCSerial ) ) );
			treeView1.Nodes.Add( xinjeNode );

			// Yokogawa Plc
			TreeNode YokogawaNode = new TreeNode( "Yokogawa Plc[横河]", 31, 31 );
			YokogawaNode.Nodes.Add( GetTreeNodeByIndex( "Yokogawa Link Tcp", 31, typeof( FormYokogawaLinkTcp ) ) );
			YokogawaNode.Nodes.Add( GetTreeNodeByIndex( "Yokogawa Link Server", 31, typeof( FormYokogawaLinkServer ) ) );
			treeView1.Nodes.Add( YokogawaNode );

			// delta Plc
			TreeNode deltaNode = new TreeNode( "Delta Plc[台达]", 32, 32 );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Dvp Serial", 32, typeof( FormDeltaDvpSerial ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Dvp Serial Ascii", 32, typeof( FormDeltaDvpSerialAscii ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Dvp Tcp Net", 32, typeof( FormDeltaDvpTcpNet ) ) );
			treeView1.Nodes.Add( deltaNode );

			// 身份证阅读器
			TreeNode idNode = new TreeNode( "ID Card[身份证]", 4, 4 );
			idNode.Nodes.Add( GetTreeNodeByIndex( "SAM Serial", 27, typeof( FormSAMSerial ) ) );
			idNode.Nodes.Add( GetTreeNodeByIndex( "SAM Tcp", 27, typeof( FormSAMTcpNet ) ) );
			treeView1.Nodes.Add( idNode );

			// Redis 相关
			TreeNode redisNode = new TreeNode( "Redis", 12, 12 );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Client",      12, typeof( FormRedisClient ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Browser",     12, typeof( Redis.RedisBrowser ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Subscribe",   12, typeof( FormRedisSubscribe ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Copy",        12, typeof( FormRedisCopy ) ) );
			treeView1.Nodes.Add( redisNode );

			// Mqtt 相关
			TreeNode mqttNode = new TreeNode( "MQTT", 17, 17 );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt Server",      17, typeof( FormMqttServer ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt Client",      17, typeof( FormMqttClient ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt RPC Client",  17, typeof( FormMqttSyncClient ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt File Server", 17, typeof( FormMqttFileServer ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt File Client", 17, typeof( FormMqttFileClient ) ) );
			treeView1.Nodes.Add( mqttNode );

			// WebSocket 相关
			TreeNode wsNode = new TreeNode( "WebSocket", 28, 28 );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket Client", 28, typeof( FormWebsocketClient ) ) );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket Server", 28, typeof( FormWebsocketServer ) ) );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket QANet",  28, typeof( FormWebsocketQANet ) ) );
			treeView1.Nodes.Add( wsNode );

			// HttpWeb 相关
			TreeNode httpNode = new TreeNode( "Http", 0, 0 );
			httpNode.Nodes.Add( GetTreeNodeByIndex( "Http Web Server", 0, typeof( FormHttpServer ) ) );
			httpNode.Nodes.Add( GetTreeNodeByIndex( "Http Web Client", 0, typeof( FormHttpClient ) ) );
			treeView1.Nodes.Add( httpNode );

			// Robot 相关
			TreeNode robotNode = new TreeNode( "Robot[机器人]", 19, 19 );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "EFORT New [新版]",            24, typeof( Robot.FormEfort ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "EFORT Pre [旧版]",            24, typeof( Robot.FormEfortPrevious ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Kuka [库卡]",                 23, typeof( FormKuka ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Kuka Tcp [库卡]",             23, typeof( FormKukaTcp ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "YRC1000 [安川]",              29, typeof( FormYRC1000 ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "ABB Web",                     21, typeof( Robot.FormABBWebApi ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "ABB Web Server",              21, typeof( FormAbbServer ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc [发那科]",              25, typeof( Robot.FormFanucRobot ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc Server [发那科服务器]", 25, typeof( FormFanucRobotServer ) ) );
			robotNode.Nodes.Add( new TreeNode( "Hyundai [现代]" )  { Tag = typeof( Robot.FormHyundaiUdp ) } );
			robotNode.Nodes.Add( new TreeNode( "YamahaRCX [雅马哈]" )  { Tag = typeof( Robot.FormYamahaRCX ) } );
			treeView1.Nodes.Add( robotNode );
			 
			TreeNode cncNode = new TreeNode( "CNC[数控机床]" );
			cncNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc 0i [Test]", 25, typeof( FormCncFanuc ) ) );
			treeView1.Nodes.Add( cncNode );

			TreeNode sensorNode = new TreeNode( "Sensor[传感器]" );
			sensorNode.Nodes.Add( new TreeNode( "Vibration[捷杰振动]" ) { Tag = typeof( FormVibrationSensorClient ) } );
			treeView1.Nodes.Add( sensorNode );

			TreeNode freeNode = new TreeNode( "Freedom[自由协议]" );
			freeNode.Nodes.Add( new TreeNode( "TCP Net" ) {        Tag = typeof( FormFreedomTcpNet ) } );
			freeNode.Nodes.Add( new TreeNode( "UDP Net" ) {        Tag = typeof( FormFreedomUdpNet ) } );
			freeNode.Nodes.Add( new TreeNode( "Serial [串口]" ) {  Tag = typeof( FormFreedomSerial ) } );
			treeView1.Nodes.Add( freeNode );

			// Debug 相关
			TreeNode debugNode = new TreeNode( "Debug About[调试技术]", 15, 15 );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Serial [串口调试]", 15, typeof( FormSerialDebug ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Tcp/Ip Client [网口调试]", 15, typeof( FormTcpDebug ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Tcp/Ip Server [网口调试]", 15, typeof( FormTcpServer ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Serial2Tcp [串口转网口]", 15, typeof( FormSerialToTcp ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Bytes Data [数据调试]", 15, typeof( FormByteTransfer ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Mail [邮件调试]", 15, typeof( FormMail ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Order Number [订单号调试]", 15, typeof( FormSeqCreate ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Regist [注册码调试]", 15, typeof( FormRegister ) ) );
			treeView1.Nodes.Add( debugNode );

			// HSL 相关
			TreeNode hslNode = new TreeNode( "Hsl Protocal[HSL 协议]", 3, 3 );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Simplify Net [同步交互]", 3, typeof( FormSimplifyNet ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Simplify Net Alien", 3, typeof( FormSimplifyNetAlien ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Complex Net [异步交互]", 3, typeof( FormComplexNet ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Udp Net [同步交互]", 3, typeof( FormUdpNet ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "File Net [文件收发]", 3, typeof( FormFileClient ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Log Net [日志记录]", 3, typeof( FormLogNet ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Push Net [消息推送]", 3, typeof( FormPushNet ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "SoftUpdate [软件更新]", 3, typeof( FormUpdateServer ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Plain Net [明文交互]", 3, typeof( FormPlainSocket ) ) );
			hslNode.Nodes.Add( GetTreeNodeByIndex( "Dtu Server[DTU服务器]", 3, typeof( FormDtuServer ) ) );
			treeView1.Nodes.Add( hslNode );

			// 扫码软件
			TreeNode barCodeNode = new TreeNode( "BarCode[扫码]", 16, 16 );
			barCodeNode.Nodes.Add( GetTreeNodeByIndex( "Sick", 16, typeof( BarCode.FormSickBarCode ) ) );
			treeView1.Nodes.Add( barCodeNode );

			// Instrument 仪器仪表
			TreeNode instrumentNode = new TreeNode( "Instrument [仪器仪表]" );
			instrumentNode.Nodes.Add( new TreeNode( "DAM3601 [阿尔泰科技]" ) { Tag = typeof( FormDAM3601 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 [电力规约]" ) { Tag = typeof( FormDLT645 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 OverTcp" ) { Tag = typeof( FormDLT645OverTcp ) } );
			treeView1.Nodes.Add( instrumentNode );

			// 托利多电子秤Toledo
			TreeNode toledoNode = new TreeNode( "Toledo [托利多]", 18, 18 );
			toledoNode.Nodes.Add( GetTreeNodeByIndex( "Serial [串口通讯]", 18, typeof( Toledo.FormToledoSerial ) ) );
			toledoNode.Nodes.Add( GetTreeNodeByIndex( "Tcp Server [网口服务]", 18, typeof( Toledo.FormToledoTcpServer ) ) );
			treeView1.Nodes.Add( toledoNode );

			// 控件库
			TreeNode controlNode = new TreeNode( "Control [控件库]" );
			controlNode.Nodes.Add( new TreeNode( "Simple Control" ) { Tag = typeof( FormBasicControl ) } );
			controlNode.Nodes.Add( new TreeNode( "Gauge [仪表盘]" ) { Tag = typeof( FormGauge ) } );
			controlNode.Nodes.Add( new TreeNode( "Curve [曲线]" ) { Tag = typeof( FormCurve ) } );
			controlNode.Nodes.Add( new TreeNode( "Pie Chart [饼图]" ) { Tag = typeof( FormPieChart ) } );
			controlNode.Nodes.Add( new TreeNode( "Pipe [管道组态]" ) { Tag = typeof( FormPipe ) } );
			treeView1.Nodes.Add( controlNode );

			// 算法相关 algorithms
			TreeNode algorithmsNode = new TreeNode( "Algorithms [算法]" );
			algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶算法]" ) { Tag = typeof( Algorithms.FourierTransform ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶滤波]" ) { Tag = typeof( Algorithms.FourierFilter ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "PID [Pid模拟]" ) { Tag = typeof( Algorithms.FormPid ) } );
			treeView1.Nodes.Add( algorithmsNode );

			// 其他界面
			TreeNode othersNode = new TreeNode( "Special [特殊协议]" );
			othersNode.Nodes.Add( new TreeNode( "Open Protocol"   ) { Tag = typeof( FormOpenProtocol ) } );
			othersNode.Nodes.Add( new TreeNode( "南京自动化 DCS"  ) { Tag = typeof( FormDcsNanJingAuto ) } );
			othersNode.Nodes.Add( new TreeNode( "Knx"             ) { Tag = typeof( PLC.FormKnx ) } );
			treeView1.Nodes.Add( othersNode );

			// treeView1.ExpandAll( );
		}

		private void TreeView1_DoubleClick( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;
			if (treeNode.Tag == null) return;

			if (treeNode.Tag is Type type)
			{
				HslFormContent hslForm = (HslFormContent)type.GetConstructors( )[0].Invoke( null );
				if (treeNode.ImageIndex >= 0)
					hslForm.Icon = Icon.FromHandle( ((Bitmap)imageList.Images[treeNode.ImageIndex]).GetHicon( ) );
				else
					hslForm.Icon = Icon.FromHandle( Properties.Resources.Method_636.GetHicon( ) );
				if (hslForm != null) hslForm.Show( dockPanel1 );
			}
		}

		private void treeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if(e.Button == MouseButtons.Right)
			{
				TreeNode treeNode = treeView1.GetNodeAt(e.Location);
				if (treeNode != null) treeView1.SelectedNode = treeNode;
			}
		}

		private DemoDeviceList deviceList = new DemoDeviceList( );

		public void LoadDeviceList( )
		{
			if(File.Exists( Path.Combine( Application.StartupPath, "devices.xml" ) ))
			{
				deviceList.SetDevices( XElement.Load( Path.Combine( Application.StartupPath, "devices.xml" ) ) );
				RefreshSaveDevices( );
				tabControl1.SelectedTab = tabPage2;
			}
		}

		public void AddDeviceList(XElement element )
		{
			deviceList.AddDevice( element );
			RefreshSaveDevices( );
			File.WriteAllText( Path.Combine( Application.StartupPath, "devices.xml" ), deviceList.GetDevices.ToString( ) );
		}

		public void RefreshSaveDevices( )
		{
			treeView2.Nodes.Clear( );
			foreach (var item in deviceList.GetDevices.Elements( ))
			{
				string name = item.Attribute( "Name" ).Value;
				AddTreeNode(  treeView2, null, item, name );
			}
			treeView2.ExpandAll( );
		}

		private void DeleteDeviceToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if (treeView2.SelectedNode == null) return;
			if (treeView2.SelectedNode.Tag == null) return;
			if (treeView2.SelectedNode.Tag is XElement element)
			{
				deviceList.DeleteDevice( element );
				RefreshSaveDevices( );
				File.WriteAllText( Path.Combine( Application.StartupPath, "devices.xml" ), deviceList.GetDevices.ToString( ) );
				MessageBox.Show( "Delete Success!" );
			}
		}


		private void AddTreeNode( TreeView treeView, TreeNode parent, XElement element, string key )
		{
			int index = key.IndexOf( ':' );
			if (index <= 0)
			{
				// 不存在冒号
				TreeNode node = new TreeNode( key );
				node.Tag = element;
				string type = element.Attribute( DemoDeviceList.XmlType ).Value;
				if (formIconImageIndex.ContainsKey( type ))
				{
					node.ImageIndex = formIconImageIndex[type];
					node.SelectedImageIndex = formIconImageIndex[type];
				}
				else
				{
					node.ImageIndex = 0;
					node.SelectedImageIndex = 0;
				}

				if (parent == null)
				{
					treeView.Nodes.Add( node );
				}
				else
				{
					parent.Nodes.Add( node );
				}
			}
			else
			{
				TreeNode parentNode = null;
				if (parent == null)
				{
					for (int i = 0; i < treeView.Nodes.Count; i++)
					{
						if (treeView.Nodes[i].Text == key.Substring( 0, index ))
						{
							parentNode = treeView.Nodes[i];
							break;
						}
					}
				}
				else
				{
					for (int i = 0; i < parent.Nodes.Count; i++)
					{
						if (parent.Nodes[i].Text == key.Substring( 0, index ))
						{
							parentNode = parent.Nodes[i];
							break;
						}
					}
				}


				if (parentNode == null)
				{
					parentNode = new TreeNode( key.Substring( 0, index ) );
					parentNode.ImageKey = "Class_489";
					parentNode.SelectedImageKey = "Class_489";
					AddTreeNode( treeView, parentNode, element, key.Substring( index + 1 ) );

					if(parent == null)
					{
						treeView.Nodes.Add( parentNode );
					}
					else
					{
						parent.Nodes.Add( parentNode );
					}
				}
				else
				{
					AddTreeNode( treeView, parentNode, element, key.Substring( index + 1 ) );
				}
			}
		}

		public static FormSelect Form { get; set; }
		public static Type[] formTypes = Assembly.GetExecutingAssembly( ).GetTypes( );

		private void treeView2_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			TreeNode treeNode = treeView2.SelectedNode;
			if (treeNode == null) return;
			if (treeNode.Tag == null) return;

			if (treeNode.Tag is XElement element)
			{
				string type = element.Attribute( DemoDeviceList.XmlType ).Value;
				HslFormContent hslForm = null;
				// 读取类型
				foreach (var item in formTypes)
				{
					if(item.Name == type)
					{
						hslForm = (HslFormContent)item.GetConstructors( )[0].Invoke( null );
						break;
					}
				}

				if (hslForm != null)
				{
					if (treeNode.ImageIndex >= 0)
						hslForm.Icon = Icon.FromHandle( ((Bitmap)imageList.Images[treeNode.ImageIndex]).GetHicon( ) );
					else
						hslForm.Icon = Icon.FromHandle( Properties.Resources.Method_636.GetHicon( ) );

					hslForm.Show( dockPanel1 );
					hslForm.LoadXmlParameter( element );
				}
			}
		}

		private void FormSelect_FormClosing( object sender, FormClosingEventArgs e )
		{
			mqttClient?.ConnectClose( );
		}
	}

	public class FormSiemensS1200 : FormSiemens
	{
		public FormSiemensS1200( ) : base( SiemensPLCS.S1200 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-1200";
		}
	}
	public class FormSiemensS1500 : FormSiemens
	{
		public FormSiemensS1500( ) : base( SiemensPLCS.S1500 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-1500";
		}
	}
	public class FormSiemensS300 : FormSiemens
	{
		public FormSiemensS300( ) : base( SiemensPLCS.S300 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-300";
		}
	}
	public class FormSiemensS400 : FormSiemens
	{
		public FormSiemensS400( ) : base( SiemensPLCS.S400 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-400";
		}
	}
	public class FormSiemensS200 : FormSiemens
	{
		public FormSiemensS200( ) : base( SiemensPLCS.S200 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-200";
		}
	}
	public class FormSiemensS200Smart : FormSiemens
	{
		public FormSiemensS200Smart( ) : base( SiemensPLCS.S200Smart )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-200Smart";
		}
	}
}
