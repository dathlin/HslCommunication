using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.Redis;

namespace HslCommunicationDemo
{
	public partial class FormSelect : Form
	{
		public static Color ThemeColor = Color.FromArgb( 64, 64, 64 );

		public FormSelect( )
		{
			InitializeComponent( );

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

			treeView1.ImageList = imageList;
		}



		private void FormLoad_Load( object sender, EventArgs e )
		{
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

			if(!Program.IsActive)
				new FormCharge( ).Show( dockPanel1 );
			new FormIndex( ).Show( dockPanel1 );
			//new FormHslMap( ).Show( dockPanel1 );
		}

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
			}
			else
			{
				Text = "HslCommunication Test Tool";
				论坛toolStripMenuItem.Text = "Blog";
				免责条款ToolStripMenuItem.Text = "China Map";
				日志ToolStripMenuItem.Text = "API Doc";
				//授权ToolStripMenuItem.Text = "Authorize";
			}
		}

		private void 论坛toolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start( "http://118.24.36.220:8082/" );
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
			OpenWebside( "http://118.24.36.220/" );
		}

		private void toolStripMenuItem1_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://118.24.36.220/MesDemo" );
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
			OpenWebside( "http://118.24.36.220:8080/html/c136d3de-eab7-9b0f-4bdf-d891297c8018.htm" );
		}


		private void FormLoad_Shown( object sender, EventArgs e )
		{
			System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
		}

		private void ThreadPoolCheckVersion( object obj )
		{
			System.Threading.Thread.Sleep( 100 );
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

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			OpenWebside( "https://github.com/dathlin/HslControlsDemo" );
		}

		private void rToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using (FormAuthor form = new FormAuthor( ))
			{
				form.ShowDialog( );
			}
		}

		private ImageList imageList;

		private void TreeViewIni( )
		{
			// 三菱PLC相关
			TreeNode melsecNode = new TreeNode( "Melsec Plc [三菱]",   8, 8 );
			melsecNode.Nodes.Add( new TreeNode( "A-1E (Binary)",       8, 8 ) { Tag = typeof( FormMelsec1EBinary ) } );
			melsecNode.Nodes.Add( new TreeNode( "A-1E (ASCII)",        8, 8 ) { Tag = typeof( FormMelsec1EAscii ) } );
			melsecNode.Nodes.Add( new TreeNode( "MC (Binary)",         8, 8 ) { Tag = typeof( FormMelsecBinary ) } );
			melsecNode.Nodes.Add( new TreeNode( "MC Udp(Binary)",      8, 8 ) { Tag = typeof( FormMelsecUdp ) } );
			melsecNode.Nodes.Add( new TreeNode( "MC (ASCII)",          8, 8 ) { Tag = typeof( FormMelsecAscii ) } );
			melsecNode.Nodes.Add( new TreeNode( "MC Udp(ASCII)",       8, 8 ) { Tag = typeof( FormMelsecAsciiUdp ) } );
			melsecNode.Nodes.Add( new TreeNode( "MC-R (Binary)",       8, 8 ) { Tag = typeof( FormMelsecRBinary ) } );
			melsecNode.Nodes.Add( new TreeNode( "Fx Serial【编程口】",  8, 8 ) { Tag = typeof( FormMelsecSerial ) } );
			melsecNode.Nodes.Add( new TreeNode( "Fx Serial OverTcp",   8, 8 ) { Tag = typeof( FormMelsecSerialOverTcp ) } );
			melsecNode.Nodes.Add( new TreeNode( "Fx Links【485】",     8, 8 ) { Tag = typeof( FormMelsecLinks ) } );
			melsecNode.Nodes.Add( new TreeNode( "Fx Links OverTcp",    8, 8 ) { Tag = typeof( FormMelsecLinksOverTcp ) } );
			melsecNode.Nodes.Add( new TreeNode( "A-3C (format1)",      8, 8 ) { Tag = typeof( FormMelsec3C ) } );
			melsecNode.Nodes.Add( new TreeNode( "A-3C OverTcp",        8, 8 ) { Tag = typeof( FormMelsec3COverTcp ) } );
			melsecNode.Nodes.Add( new TreeNode( "Mc Virtual Server",   8, 8 ) { Tag = typeof( FormMcServer ) } );
			treeView1.Nodes.Add( melsecNode );

			// 西门子PLC相关
			TreeNode siemensNode = new TreeNode( "Siemens Plc [西门子]", 14, 14 );
			siemensNode.Nodes.Add( new TreeNode( "S1200", 14, 14 ) { Tag = typeof( FormSiemensS1200 ) } );
			siemensNode.Nodes.Add( new TreeNode( "S1500", 14, 14 ) { Tag = typeof( FormSiemensS1500 ) } );
			siemensNode.Nodes.Add( new TreeNode( "S300", 14, 14 ) { Tag = typeof( FormSiemensS300 ) } );
			siemensNode.Nodes.Add( new TreeNode( "S400", 14, 14 ) { Tag = typeof( FormSiemensS400 ) } );
			siemensNode.Nodes.Add( new TreeNode( "S200", 14, 14 ) { Tag = typeof( FormSiemensS200 ) } );
			siemensNode.Nodes.Add( new TreeNode( "S200 smart", 14, 14 ) { Tag = typeof( FormSiemensS200Smart ) } );
			siemensNode.Nodes.Add( new TreeNode( "Fetch/Write", 14, 14 ) { Tag = typeof( FormSiemensFW ) } );
			siemensNode.Nodes.Add( new TreeNode( "PPI", 14, 14 ) { Tag = typeof( FormSiemensPPI ) } );
			siemensNode.Nodes.Add( new TreeNode( "PPI OverTcp", 14, 14 ) { Tag = typeof( FormSiemensPPIOverTcp ) } );
			siemensNode.Nodes.Add( new TreeNode( "MPI", 14, 14 ) { Tag = typeof( FormSiemensMPI ) } );
			siemensNode.Nodes.Add( new TreeNode( "S7 Virtual Server", 14, 14 ) { Tag = typeof( FormS7Server ) } );
			treeView1.Nodes.Add( siemensNode );

			// Modbus协议
			TreeNode modbusNode = new TreeNode( "Modbus", 9, 9 );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Tcp", 9, 9 ) { Tag = typeof( FormModbus ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Udp", 9, 9 ) { Tag = typeof( FormModbusUdp ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Tcp[Alien]", 9, 9 ) { Tag = typeof( FormModbusAlien ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Rtu", 9, 9 ) { Tag = typeof( FormModbusRtu ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Rtu OverTcp", 9, 9 ) { Tag = typeof( FormModbusRtuOverTcp ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Ascii", 9, 9 ) { Tag = typeof( FormModbusAscii ) } );
			modbusNode.Nodes.Add( new TreeNode( "Modbus Server", 9, 9 ) { Tag = typeof( FormModbusServer ) } );
			treeView1.Nodes.Add( modbusNode );

			// Modbus协议
			TreeNode inovanceNode = new TreeNode( "Inovance Plc[汇川]", 5, 5 );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceAMTcp", 5, 5 ) { Tag = typeof( FormInovanceAMTcp ) } );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceAMSerial", 5, 5 ) { Tag = typeof( FormInovanceAMSerial ) } );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceH3UTcp", 5, 5 ) { Tag = typeof( FormInovanceH3UTcp ) } );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceH3USerial", 5, 5 ) { Tag = typeof( FormInovanceH3USerial ) } );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceH5UTcp", 5, 5 ) { Tag = typeof( FormInovanceH5UTcp ) } );
			inovanceNode.Nodes.Add( new TreeNode( "InovanceH5USerial", 5, 5 ) { Tag = typeof( FormInovanceH5USerial ) } );
			treeView1.Nodes.Add( inovanceNode );

			// 欧姆龙PLC相关
			TreeNode omronNode = new TreeNode( "Omron Plc[欧姆龙]", 10, 10 );
			omronNode.Nodes.Add( new TreeNode( "Fins Tcp", 10, 10 ) { Tag = typeof( FormOmron ) } );
			omronNode.Nodes.Add( new TreeNode( "Fins Udp", 10, 10 ) { Tag = typeof( FormOmronUdp ) } );
			omronNode.Nodes.Add( new TreeNode( "EtherNet/IP(CIP)", 10, 10 ) { Tag = typeof( FormOmronCip ) } );
			omronNode.Nodes.Add( new TreeNode( "Connected CIP", 10, 10 ) { Tag = typeof( FormOmronConnectedCip ) } );
			omronNode.Nodes.Add( new TreeNode( "HostLink 【串口】", 10, 10 ) { Tag = typeof( FormOmronHostLink ) } );
			omronNode.Nodes.Add( new TreeNode( "HostLink OverTcp", 10, 10 ) { Tag = typeof( FormOmronHostLinkOverTcp ) } );
			omronNode.Nodes.Add( new TreeNode( "HostLink C-Mode", 10, 10 ) { Tag = typeof( FormOmronHostLinkCMode ) } );
			omronNode.Nodes.Add( new TreeNode( "Fins Virtual Server", 10, 10 ) { Tag = typeof( FormOmronServer ) } );
			treeView1.Nodes.Add( omronNode );

			// Lsis PLC
			TreeNode lsisNode = new TreeNode( "LSis Plc", 7, 7 );
			lsisNode.Nodes.Add( new TreeNode( "XGB Fast Enet", 7, 7 ) { Tag = typeof( FormLsisFEnet ) } );
			lsisNode.Nodes.Add( new TreeNode( "XGB Cnet", 7, 7 ) { Tag = typeof( FormLsisCnet ) } );
			lsisNode.Nodes.Add( new TreeNode( "XGB Cnet OverTcp", 7, 7 ) { Tag = typeof( FormLsisCnetOverTcp ) } );
			lsisNode.Nodes.Add( new TreeNode( "LSis Virtual Server", 7, 7 ) { Tag = typeof( FormLSisServer ) } );
			treeView1.Nodes.Add( lsisNode );

			// Keyence PLC
			TreeNode keyencePlc = new TreeNode( "Keyence Plc[基恩士]", 6, 6 );
			keyencePlc.Nodes.Add( new TreeNode( "MC-3E (Binary)", 6, 6 ) { Tag = typeof( FormKeyenceBinary ) } );
			keyencePlc.Nodes.Add( new TreeNode( "MC-3E (ASCII)", 6, 6 ) { Tag = typeof( FormKeyenceAscii ) } );
			keyencePlc.Nodes.Add( new TreeNode( "Nano (ASCII)", 6, 6 ) { Tag = typeof( FormKeyenceNanoSerial ) } );
			keyencePlc.Nodes.Add( new TreeNode( "Nano OverTcp", 6, 6 ) { Tag = typeof( FormKeyenceNanoSerialOverTcp ) } );
			treeView1.Nodes.Add( keyencePlc );

			// Panasonic PLC
			TreeNode panasonicPlc = new TreeNode( "Panasonic Plc[松下]", 11, 11 );
			panasonicPlc.Nodes.Add( new TreeNode( "MC-3E (Binary)", 11, 11 ) { Tag = typeof( FormPanasonicBinary ) } );
			panasonicPlc.Nodes.Add( new TreeNode( "Mewtocol", 11, 11 ) { Tag = typeof( FormPanasonicMew ) } );
			panasonicPlc.Nodes.Add( new TreeNode( "Mewtocol OverTcp", 11, 11 ) { Tag = typeof( FormPanasonicMewOverTcp ) } );
			treeView1.Nodes.Add( panasonicPlc );

			// Allen Bradlly PLC
			TreeNode allenBrandlyPlc = new TreeNode( "AllenBrandly Plc[罗克韦尔]", 1, 1 );
			allenBrandlyPlc.Nodes.Add( new TreeNode( "EtherNet/IP(CIP)", 1, 1 ) { Tag = typeof( FormAllenBrandly ) } );
			allenBrandlyPlc.Nodes.Add( new TreeNode( "MicroCip(Micro800)", 1, 1 ) { Tag = typeof( FormAllenBrandlyMicroCip ) } );
			allenBrandlyPlc.Nodes.Add( new TreeNode( "CIP Browser", 1, 1 ) { Tag = typeof( FormAllenBrandlyBrowser ) } );
			allenBrandlyPlc.Nodes.Add( new TreeNode( "CIP Virtual Server", 1, 1 ) { Tag = typeof( FormCipServer ) } );
			treeView1.Nodes.Add( allenBrandlyPlc );

			// Beckhoff PLC
			TreeNode beckhoffPlc = new TreeNode( "Beckhoff Plc[倍福]" );
			beckhoffPlc.Nodes.Add( new TreeNode( "Ads Net" ) { Tag = typeof( FormBeckpffAdsNet ) } );
			treeView1.Nodes.Add( beckhoffPlc );

			// Fatek 永宏PLC
			TreeNode fatekNode = new TreeNode( "Fatek Plc[永宏]" );
			fatekNode.Nodes.Add( new TreeNode( "programe [编程口]" ) { Tag = typeof( FormFatekPrograme ) } );
			fatekNode.Nodes.Add( new TreeNode( "programe OverTcp" ) { Tag = typeof( FormFatekProgrameOverTcp ) } );
			treeView1.Nodes.Add( fatekNode );

			// Fuji Plc
			TreeNode fujiNode = new TreeNode( "Fuji Plc[富士]", 2, 2 );
			fujiNode.Nodes.Add( new TreeNode( "SPB [编程口]", 2, 2 ) { Tag = typeof( FormFujiSPB ) } );
			fujiNode.Nodes.Add( new TreeNode( "SPB OverTcp", 2, 2 ) { Tag = typeof( FormFujiSPBOverTcp ) } );
			treeView1.Nodes.Add( fujiNode );

			// Knx
			TreeNode knxNode = new TreeNode( "Knx" );
			knxNode.Nodes.Add( new TreeNode( "Knx" ) { Tag = typeof( PLC.FormKnx ) } );
			treeView1.Nodes.Add( knxNode );

			// 身份证阅读器
			TreeNode idNode = new TreeNode( "ID Card[身份证]", 4, 4 );
			idNode.Nodes.Add( new TreeNode( "SAM Serial", 4, 4 ) { Tag = typeof( FormSAMSerial ) } );
			idNode.Nodes.Add( new TreeNode( "SAM Tcp", 4, 4 ) { Tag = typeof( FormSAMTcpNet ) } );
			treeView1.Nodes.Add( idNode );

			// Redis 相关
			TreeNode redisNode = new TreeNode( "Redis", 12, 12 );
			redisNode.Nodes.Add( new TreeNode( "Redis Client", 12, 12 )    { Tag = typeof( FormRedisClient ) } );
			redisNode.Nodes.Add( new TreeNode( "Redis Browser", 12, 12 )   { Tag = typeof( Redis.RedisBrowser ) } );
			redisNode.Nodes.Add( new TreeNode( "Redis Subscribe", 12, 12 ) { Tag = typeof( FormRedisSubscribe ) } );
			redisNode.Nodes.Add( new TreeNode( "Redis Copy", 12, 12 )      { Tag = typeof( FormRedisCopy ) } );
			treeView1.Nodes.Add( redisNode );

			// Mqtt 相关
			TreeNode mqttNode = new TreeNode( "MQTT", 17, 17 );
			mqttNode.Nodes.Add( new TreeNode( "Mqtt Server", 17, 17 ) { Tag = typeof( FormMqttServer ) } );
			mqttNode.Nodes.Add( new TreeNode( "Mqtt Client", 17, 17 ) { Tag = typeof( FormMqttClient ) } );
			mqttNode.Nodes.Add( new TreeNode( "Mqtt Sync Client", 17, 17 ) { Tag = typeof( FormMqttSyncClient ) } );
			treeView1.Nodes.Add( mqttNode );

			// WebSocket 相关
			TreeNode wsNode = new TreeNode( "WebSocket" );
			wsNode.Nodes.Add( new TreeNode( "WebSocket Client" ) { Tag = typeof( FormWebsocketClient ) } );
			wsNode.Nodes.Add( new TreeNode( "WebSocket Server" ) { Tag = typeof( FormWebsocketServer ) } );
			wsNode.Nodes.Add( new TreeNode( "WebSocket QANet" ) { Tag = typeof( FormWebsocketQANet ) } );
			treeView1.Nodes.Add( wsNode );

			// Robot 相关
			TreeNode robotNode = new TreeNode( "Robot[机器人]", 19, 19 );
			robotNode.Nodes.Add( new TreeNode( "EFORT New [新版]" ) { Tag = typeof( Robot.FormEfort ) } );
			robotNode.Nodes.Add( new TreeNode( "EFORT Pre [旧版]" ) { Tag = typeof( Robot.FormEfortPrevious ) } );
			robotNode.Nodes.Add( new TreeNode( "Kuka [库卡]" ) { Tag = typeof( FormKuka ) } );
			robotNode.Nodes.Add( new TreeNode( "YRC1000 [安川]" ) { Tag = typeof( FormYRC1000 ) } );
			robotNode.Nodes.Add( new TreeNode( "ABB Web" ) { Tag = typeof( Robot.FormABBWebApi ) } );
			robotNode.Nodes.Add( new TreeNode( "ABB Web Server" ) { Tag = typeof( FormAbbServer ) } );
			robotNode.Nodes.Add( new TreeNode( "Fanuc [发那科]" ) { Tag = typeof( Robot.FormFanucRobot ) } );
			robotNode.Nodes.Add( new TreeNode( "Fanuc Server [发那科服务器]" ) { Tag = typeof( FormFanucRobotServer ) } );
			robotNode.Nodes.Add( new TreeNode( "Hyundai [现代]" ) { Tag = typeof( Robot.FormHyundaiUdp ) } );
			robotNode.Nodes.Add( new TreeNode( "YamahaRCX [雅马哈]" ) { Tag = typeof( Robot.FormYamahaRCX ) } );
			treeView1.Nodes.Add( robotNode );

			TreeNode cncNode = new TreeNode( "CNC[数控机床]" );
			cncNode.Nodes.Add( new TreeNode( "Fanuc 0i [Test]" ) { Tag = typeof( FormCncFanuc ) } );
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
			debugNode.Nodes.Add( new TreeNode( "Serial [串口调试]", 15, 15 ) {         Tag = typeof( FormSerialDebug ) } );
			debugNode.Nodes.Add( new TreeNode( "Tcp/Ip Client [网口调试]", 15, 15 ) {  Tag = typeof( FormTcpDebug ) } );
			debugNode.Nodes.Add( new TreeNode( "Tcp/Ip Server [网口调试]", 15, 15 ) {  Tag = typeof( FormTcpServer ) } );
			debugNode.Nodes.Add( new TreeNode( "Bytes Data [数据调试]", 15, 15 ) {     Tag = typeof( FormByteTransfer ) } );
			debugNode.Nodes.Add( new TreeNode( "Mail [邮件调试]", 15, 15 ) {           Tag = typeof( FormMail ) } );
			debugNode.Nodes.Add( new TreeNode( "Order Number [订单号调试]", 15, 15 ) { Tag = typeof( FormSeqCreate ) } );
			debugNode.Nodes.Add( new TreeNode( "Regist [注册码调试]", 15, 15 ) {       Tag = typeof( FormRegister ) } );
			treeView1.Nodes.Add( debugNode );

			// HSL 相关
			TreeNode hslNode = new TreeNode( "Hsl Protocal[HSL 协议]", 3, 3 );
			hslNode.Nodes.Add( new TreeNode( "Simplify Net [同步交互]", 3, 3 ) { Tag = typeof( FormSimplifyNet ) } );
			hslNode.Nodes.Add( new TreeNode( "Simplify Net Alien", 3, 3 ) { Tag = typeof( FormSimplifyNetAlien ) } );
			hslNode.Nodes.Add( new TreeNode( "Complex Net [异步交互]", 3, 3 ) { Tag = typeof( FormComplexNet ) } );
			hslNode.Nodes.Add( new TreeNode( "Udp Net [同步交互]", 3, 3 ) { Tag = typeof( FormUdpNet ) } );
			hslNode.Nodes.Add( new TreeNode( "File Net [文件收发]", 3, 3 ) { Tag = typeof( FormFileClient ) } );
			hslNode.Nodes.Add( new TreeNode( "Log Net [日志记录]", 3, 3 ) { Tag = typeof( FormLogNet ) } );
			hslNode.Nodes.Add( new TreeNode( "Push Net [消息推送]", 3, 3 ) { Tag = typeof( FormPushNet ) } );
			hslNode.Nodes.Add( new TreeNode( "SoftUpdate [软件更新]", 3, 3 ) { Tag = typeof( FormUpdateServer ) } );
			hslNode.Nodes.Add( new TreeNode( "Plain Net [明文交互]", 3, 3 ) { Tag = typeof( FormPlainSocket ) } );
			hslNode.Nodes.Add( new TreeNode( "Http Web", 3, 3 ) { Tag = typeof( FormHttpServer ) } );
			hslNode.Nodes.Add( new TreeNode( "Dtu Server[DTU服务器]", 3, 3 ) { Tag = typeof( FormDtuServer ) } );
			treeView1.Nodes.Add( hslNode );

			// 扫码软件
			TreeNode barCodeNode = new TreeNode( "BarCode[扫码]", 16, 16 );
			barCodeNode.Nodes.Add( new TreeNode( "Sick", 16, 16 ) { Tag = typeof( BarCode.FormSickBarCode ) } );
			treeView1.Nodes.Add( barCodeNode );

			// Instrument 仪器仪表
			TreeNode instrumentNode = new TreeNode( "Instrument [仪器仪表]" );
			instrumentNode.Nodes.Add( new TreeNode( "DAM3601 [阿尔泰科技]" ) { Tag = typeof( FormDAM3601 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 [电力规约]" ) { Tag = typeof( FormDLT645 ) } );
			treeView1.Nodes.Add( instrumentNode );

			// 托利多电子秤Toledo
			TreeNode toledoNode = new TreeNode( "Toledo [托利多]", 18, 18 );
			toledoNode.Nodes.Add( new TreeNode( "Serial [串口通讯]", 18, 18 ) { Tag = typeof( Toledo.FormToledoSerial ) } );
			toledoNode.Nodes.Add( new TreeNode( "Tcp Server [网口服务]", 18, 18 ) { Tag = typeof( Toledo.FormToledoTcpServer ) } );
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
			othersNode.Nodes.Add( new TreeNode( "Open Protocol" ) { Tag = typeof( FormOpenProtocol ) } );
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
				if (hslForm != null) hslForm.Show( dockPanel1 );
			}
		}

	}

	public class FormSiemensS1200 : FormSiemens
	{
		public FormSiemensS1200( ) : base( SiemensPLCS.S1200 )
		{

		}
	}
	public class FormSiemensS1500 : FormSiemens
	{
		public FormSiemensS1500( ) : base( SiemensPLCS.S1500 )
		{

		}
	}
	public class FormSiemensS300 : FormSiemens
	{
		public FormSiemensS300( ) : base( SiemensPLCS.S300 )
		{

		}
	}
	public class FormSiemensS400 : FormSiemens
	{
		public FormSiemensS400( ) : base( SiemensPLCS.S400 )
		{

		}
	}
	public class FormSiemensS200 : FormSiemens
	{
		public FormSiemensS200( ) : base( SiemensPLCS.S200 )
		{

		}
	}
	public class FormSiemensS200Smart : FormSiemens
	{
		public FormSiemensS200Smart( ) : base( SiemensPLCS.S200Smart )
		{

		}
	}
}
