using HslCommunication.LogNet;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.HslDebug;
using HslCommunicationDemo.MQTT;
using HslCommunicationDemo.PLC;
using HslCommunicationDemo.PLC.Invt;
using HslCommunicationDemo.PLC.Omron;
using HslCommunicationDemo.PLC.WeCon;
using HslCommunicationDemo.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormPanelLeft : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormPanelLeft( WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel, ImageList imageList, ILogNet logNet )
		{
			this.dockPanel1 = dockPanel;
			this.logNet     = logNet;
			this.imageList = imageList;
			InitializeComponent( );
		}


		private void FormPanelLeft_Load( object sender, EventArgs e )
		{
			CloseButtonVisible = false;
			treeView1.ImageList = imageList;

			TreeViewIni( );
			treeView1.DoubleClick      += TreeView1_DoubleClick;
			treeView1.MouseClick       += TreeView1_MouseClick;

			SetLanguage( );
		}

		public void SetLanguage( )
		{
			if (Program.Language == 1)
			{
				this.Text = "设备列表";
			}
			else
			{
				this.Text = "Device List";
			}
		}

		private void TreeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode treeNode = treeView1.GetNodeAt( e.Location );
				if (treeNode != null) treeView1.SelectedNode = treeNode;
			}
		}

		private void RenderTreeNode( TreeNode treeNode )
		{
			if (treeNode == null) return;
			if (treeNode.Tag == null) return;

			if (treeNode.Tag is Type type)
			{
				HslFormContent hslForm = (HslFormContent)type.GetConstructors( )[0].Invoke( null );
				if (hslForm != null)
				{
					hslForm.LogNet = this.logNet;

					if (treeNode.ImageIndex >= 0)
					{
						hslForm.Icon = Icon.FromHandle( ((Bitmap)imageList.Images[treeNode.ImageIndex]).GetHicon( ) );
						hslForm.SetProtocolImage( (Bitmap)imageList.Images[treeNode.ImageIndex] );
					}
					else
					{
						hslForm.Icon = Icon.FromHandle( Properties.Resources.Method_636.GetHicon( ) );
						hslForm.SetProtocolImage( Properties.Resources.Method_636 );
					}
					if (hslForm != null) hslForm.Show( dockPanel1 );
				}
			}
		}

		private void TreeView1_DoubleClick( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			RenderTreeNode( treeNode );
		}

		private void TreeViewIni( )
		{
			// 三菱PLC相关
			TreeNode melsecNode = new TreeNode( "Melsec Plc [三菱]", 8, 8 );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)", 8, typeof( FormMelsecCipNet ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-1E (Binary)", 8, typeof( FormMelsec1EBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-1E (ASCII)", 8, typeof( FormMelsec1EAscii ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-1E Server", 8, typeof( FormMcA1EServer ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC (Binary)", 8, typeof( FormMelsecBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC Udp(Binary)", 8, typeof( FormMelsecUdp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC (ASCII)", 8, typeof( FormMelsecAscii ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC Udp(ASCII)", 8, typeof( FormMelsecAsciiUdp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "MC-R (Binary)", 8, typeof( FormMelsecRBinary ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Serial【编程口】", 8, typeof( FormMelsecSerial ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Serial OverTcp", 8, typeof( FormMelsecSerialOverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Links【485】", 8, typeof( FormMelsecLinks ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Fx Links OverTcp", 8, typeof( FormMelsecLinksOverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "FxLinks Server", 8, typeof( FormFxLinksServer ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-3C (串口)", 8, typeof( FormMelsec3C ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-3C OverTcp", 8, typeof( FormMelsec3COverTcp ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "A-3C Server", 8, typeof( FormMcA3CServer ) ) );
			melsecNode.Nodes.Add( GetTreeNodeByIndex( "Mc Virtual Server", 8, typeof( FormMcServer ) ) );
			treeView1.Nodes.Add( melsecNode );

			// 西门子PLC相关
			TreeNode siemensNode = new TreeNode( "Siemens Plc [西门子]", 14, 14 );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S1200", 14, typeof( FormSiemensS1200 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S1500", 14, typeof( FormSiemensS1500 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S300", 14, typeof( FormSiemensS300 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S400", 14, typeof( FormSiemensS400 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S200", 14, typeof( FormSiemensS200 ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-S200 smart", 14, typeof( FormSiemensS200Smart ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "Fetch/Write", 14, typeof( FormSiemensFW ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "WebApi", 14, typeof( FormSiemensWebApi ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "PPI", 14, typeof( FormSiemensPPI ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "PPI OverTcp", 14, typeof( FormSiemensPPIOverTcp ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "MPI", 14, typeof( FormSiemensMPI ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7 Virtual Server", 14, typeof( FormS7Server ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7 PPI Server", 14, typeof( FormSiemensPPIServer ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "Fetch Write Server", 14, typeof( FormFetchWriteServer ) ) );
			siemensNode.Nodes.Add( GetTreeNodeByIndex( "S7-PLUS",     14, typeof( FormSiemensS7Plus ) ) );
			treeView1.Nodes.Add( siemensNode );

			// Modbus协议
			TreeNode modbusNode = new TreeNode( "Modbus", 9, 9 );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Tcp", 9, typeof( FormModbus ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Udp", 9, typeof( FormModbusUdp ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Rtu", 9, typeof( FormModbusRtu ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Rtu OverTcp", 9, typeof( FormModbusRtuOverTcp ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Ascii", 9, typeof( FormModbusAscii ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "ModbusAscii OverTcp", 9, typeof( FormModbusAsciiOverTcp ) ) );
			modbusNode.Nodes.Add( GetTreeNodeByIndex( "Modbus Server", 9, typeof( FormModbusServer ) ) );
			treeView1.Nodes.Add( modbusNode );

			// Modbus协议
			TreeNode inovanceNode = new TreeNode( "Inovance Plc[汇川]", 5, 5 );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceSerial", 5, typeof( FormInovanceSerial ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceSerialOverTcp", 5, typeof( FormInovanceSerialOverTcp ) ) );
			inovanceNode.Nodes.Add( GetTreeNodeByIndex( "InovanceTcpNet", 5, typeof( FormInovanceTcpNet ) ) );
			treeView1.Nodes.Add( inovanceNode );

			// 欧姆龙PLC相关
			TreeNode omronNode = new TreeNode( "Omron Plc[欧姆龙]", 10, 10 );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Tcp", 10, typeof( FormOmron ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Udp", 10, typeof( FormOmronUdp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)", 10, typeof( FormOmronCip ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Connected CIP", 10, typeof( FormOmronConnectedCip ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Omron CIP Server", 10, typeof( FormOmronCipServer ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink 【串口】", 10, typeof( FormOmronHostLink ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink OverTcp", 10, typeof( FormOmronHostLinkOverTcp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink C-Mode", 10, typeof( FormOmronHostLinkCMode ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "C-Mode OverTcp", 10, typeof( FormOmronHostLinkCModeOverTcp ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Virtual Server", 10, typeof( FormOmronServer ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Fins Udp Server", 10, typeof( FormOmronUdpServer ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "HostLink Server", 10, typeof( FormOmronHostLinkServer ) ) );
			omronNode.Nodes.Add( GetTreeNodeByIndex( "Cmode Server", 10, typeof( FormOmronHostLinkCModeServer ) ) );
			treeView1.Nodes.Add( omronNode );

			// Lsis PLC
			TreeNode lsisNode = new TreeNode( "LSis Plc", 7, 7 );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "LSis Fast Enet", 7, typeof( FormLsisFEnet ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex("LSis Cnet", 7, typeof( FormLsisCnet ) ) );
            lsisNode.Nodes.Add(GetTreeNodeByIndex("LSis Cpu", 7, typeof(FormLsisCpu)));
            lsisNode.Nodes.Add( GetTreeNodeByIndex("LSis Cnet OverTcp", 7, typeof( FormLsisCnetOverTcp ) ) );
			lsisNode.Nodes.Add( GetTreeNodeByIndex( "LSis Virtual Server", 7, typeof( FormLSisServer ) ) );
			treeView1.Nodes.Add( lsisNode );

			// Keyence PLC
			TreeNode keyencePlc = new TreeNode( "Keyence Plc[基恩士]", 6, 6 );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (Binary)", 6, typeof( FormKeyenceBinary ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (ASCII)", 6, typeof( FormKeyenceAscii ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "Nano (ASCII)", 6, typeof( FormKeyenceNanoSerial ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "Nano OverTcp", 6, typeof( FormKeyenceNanoSerialOverTcp ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "Nano Server", 6, typeof( FormKeyenceNanoServer ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "SR2000 [读码]", 6, typeof( FormKeyenceSR2000 ) ) );
			keyencePlc.Nodes.Add( GetTreeNodeByIndex( "DL-EN1 [传感器]", 6, typeof( FormKeyenceDLEN1 ) ) );
			treeView1.Nodes.Add( keyencePlc );

			// Panasonic PLC
			TreeNode panasonicPlc = new TreeNode( "Panasonic Plc[松下]", 11, 11 );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "MC-3E (Binary)", 11, typeof( FormPanasonicBinary ) ) );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "Mewtocol", 11, typeof( FormPanasonicMew ) ) );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "Mewtocol OverTcp", 11, typeof( FormPanasonicMewOverTcp ) ) );
			panasonicPlc.Nodes.Add( GetTreeNodeByIndex( "Mewtocol Server", 11, typeof( FormPanasonicMewtocolServer ) ) );
			treeView1.Nodes.Add( panasonicPlc );

			// Allen Bradlly PLC
			TreeNode allenBrandlyPlc = new TreeNode( "AllenBrandly[罗克韦尔]", 1, 1 );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "EtherNet/IP(CIP)", 1, typeof( FormAllenBrandly ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "Connected CIP", 1, typeof( FormAllenBrandlyConnectedCip ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "MicroCip(Micro800)", 1, typeof( FormAllenBrandlyMicroCip ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP Browser", 1, typeof( FormAllenBrandlyBrowser ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP Virtual Server", 1, typeof( FormCipServer ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP PCCC", 1, typeof( FormAllenBrandlyPCCC ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "CIP PCCC Server", 1, typeof( FormPcccServer ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "SLC Net", 1, typeof( FormAllenBrandlySLC ) ) );
			allenBrandlyPlc.Nodes.Add( GetTreeNodeByIndex( "DF1", 1, typeof( FormAllenBradleyDF1Serial ) ) );
			treeView1.Nodes.Add( allenBrandlyPlc );

			// Beckhoff PLC
			TreeNode beckhoffPlc = new TreeNode( "Beckhoff Plc[倍福]", 20, 20 );
			beckhoffPlc.Nodes.Add( GetTreeNodeByIndex( "Ads Net", 20, typeof( FormBeckhoffAdsNet ) ) );
			beckhoffPlc.Nodes.Add( GetTreeNodeByIndex( "Ads Server", 20, typeof( FormBeckhoffAdsServer ) ) );
			treeView1.Nodes.Add( beckhoffPlc );

			// GE PLC
			TreeNode gePlc = new TreeNode( "GE Plc[通用电气]", 33, 33 );
			gePlc.Nodes.Add( GetTreeNodeByIndex( "SRTP", 33, typeof( FormGeSRTP ) ) );
			gePlc.Nodes.Add( GetTreeNodeByIndex( "SRTP Server", 33, typeof( FormGeSRTPServer ) ) );
			treeView1.Nodes.Add( gePlc );

			// Yaskawa PLC
			TreeNode yaskawaPlc = new TreeNode( "Yaskawa Plc[安川]", 29, 29 );
			yaskawaPlc.Nodes.Add( GetTreeNodeByIndex( "MemobusTcp", 29, typeof( FormYASKAWAMemobusTcpNet ) ) );
			yaskawaPlc.Nodes.Add( GetTreeNodeByIndex( "MemobusUdp", 29, typeof( FormYASKAWAMemobusUdpNet ) ) );
			yaskawaPlc.Nodes.Add( GetTreeNodeByIndex( "MemobusTcpServer", 29, typeof( FormMemobusTcpServer ) ) );
			treeView1.Nodes.Add( yaskawaPlc );

			// yamatake 山武 
			TreeNode yamatakePlc = new TreeNode( "yamatake[山武]", 34, 34 );
			yamatakePlc.Nodes.Add( GetTreeNodeByIndex( "DigitronCPL", 34, typeof( FormDigitronCPL ) ) );
			yamatakePlc.Nodes.Add( GetTreeNodeByIndex( "DigitronCPL OverTcp", 34, typeof( FormDigitronCPLOverTcp ) ) );
			yamatakePlc.Nodes.Add( GetTreeNodeByIndex( "DigitronCPL Server", 34, typeof( FormDigitronCPLServer ) ) );
			treeView1.Nodes.Add( yamatakePlc );

			// RKC 理化
			TreeNode rkc = new TreeNode( "RKC[理化]", 35, 35 );
			rkc.Nodes.Add( GetTreeNodeByIndex( "温度控制器", 35, typeof( FormRkcTemperatureController ) ) );
			rkc.Nodes.Add( GetTreeNodeByIndex( "温度控制器TCP", 35, typeof( FormRkcTemperatureControllerOverTcp ) ) );
			rkc.Nodes.Add( GetTreeNodeByIndex( "温度控制器Server", 35, typeof( FormRkcTemperatureControllerServer ) ) );
			treeView1.Nodes.Add( rkc );

			// Fatek 永宏PLC
			TreeNode fatekNode = new TreeNode( "Fatek Plc[永宏]", 22, 22 );
			fatekNode.Nodes.Add( GetTreeNodeByIndex( "programe [编程口]", 22, typeof( FormFatekPrograme ) ) );
			fatekNode.Nodes.Add( GetTreeNodeByIndex( "programe OverTcp", 22, typeof( FormFatekProgrameOverTcp ) ) );
			fatekNode.Nodes.Add( GetTreeNodeByIndex( "programe Server", 22, typeof( FormFatekProgrameServer ) ) );
			treeView1.Nodes.Add( fatekNode );

			// Vigor 丰炜
			TreeNode vigorNode = new TreeNode( "Vigor Plc[丰炜]", 36, 36 );
			vigorNode.Nodes.Add( GetTreeNodeByIndex( "Serial [编程口]", 36, typeof( FormVigorSerial ) ) );
			vigorNode.Nodes.Add( GetTreeNodeByIndex( "Serial OverTcp", 36, typeof( FormVigorSerialOverTcp ) ) );
			vigorNode.Nodes.Add( GetTreeNodeByIndex( "Virtual Server", 36, typeof( FormVigorServer ) ) );
			treeView1.Nodes.Add( vigorNode );

			// Fuji Plc
			TreeNode fujiNode = new TreeNode( "Fuji Plc[富士]", 2, 2 );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB [编程口]", 2, typeof( FormFujiSPB ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB OverTcp", 2, typeof( FormFujiSPBOverTcp ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPB Server", 2, typeof( FormFujiSPBServer ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPH Net", 2, typeof( FormFujiSPHNet ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "SPH Server", 2, typeof( FormFujiSPHServer ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "CommandST", 2, typeof( FormFujiCSTNet ) ) );
			fujiNode.Nodes.Add( GetTreeNodeByIndex( "CommandST Server", 2, typeof( FormFujiCSTServer ) ) );
			treeView1.Nodes.Add( fujiNode );

			// XinJE Plc
			TreeNode xinjeNode = new TreeNode( "XinJE Plc[信捷]", 30, 30 );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE Serial", 30, typeof( FormXinJEXCSerial ) ) );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE Serial OverTcp", 30, typeof( FormXinJESerialOverTcp ) ) );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE TCP [Modbus]", 30, typeof( FormXinJETcpNet ) ) );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE Server", 30, typeof( FormXinJEInternalServer ) ) );
			xinjeNode.Nodes.Add( GetTreeNodeByIndex( "XinJE TCP[专用]", 30, typeof( FormXinJEInternalTcp ) ) );
			treeView1.Nodes.Add( xinjeNode );

			// 维控PLC
			TreeNode weconNode = new TreeNode( "WeCon Plc[维控]", 43, 43 );
			weconNode.Nodes.Add( GetTreeNodeByIndex( "WeCon ModbusTcp", 43, typeof( FormWeConModbus ) ) );
			weconNode.Nodes.Add( GetTreeNodeByIndex( "WeCon ModbusRtu", 43, typeof( FormWeConModbusRtu ) ) );
			treeView1.Nodes.Add( weconNode );

			// 麦格米特
			TreeNode megMeetNode = new TreeNode( "MegMeet Plc[麦格米特]", 44, 44 );
			megMeetNode.Nodes.Add( GetTreeNodeByIndex( "MegMeet Serial", 44, typeof( FormMegMeetSerial ) ) );
			megMeetNode.Nodes.Add( GetTreeNodeByIndex( "MegMeet Serial OverTcp", 44, typeof( FormMegMeetSerialOverTcp ) ) );
			megMeetNode.Nodes.Add( GetTreeNodeByIndex( "MegMeet TCP [Modbus]", 44, typeof( FormMegMeetTcpNet ) ) );
			treeView1.Nodes.Add( megMeetNode );

			// 英威腾PLC
			TreeNode invtNode = new TreeNode( "Invt Plc[英威腾]", 45, 45 );
			invtNode.Nodes.Add( GetTreeNodeByIndex( "Invt ModbusTcp", 45, typeof( FormInvtModbus ) ) );
			invtNode.Nodes.Add( GetTreeNodeByIndex( "Invt ModbusRtu", 45, typeof( FormInvtModbusRtu ) ) );
			treeView1.Nodes.Add( invtNode );

			// Yokogawa Plc
			TreeNode YokogawaNode = new TreeNode( "Yokogawa Plc[横河]", 31, 31 );
			YokogawaNode.Nodes.Add( GetTreeNodeByIndex( "Yokogawa Link Tcp", 31, typeof( FormYokogawaLinkTcp ) ) );
			YokogawaNode.Nodes.Add( GetTreeNodeByIndex( "Yokogawa Link Server", 31, typeof( FormYokogawaLinkServer ) ) );
			treeView1.Nodes.Add( YokogawaNode );

			// Toyota Plc
			TreeNode ToyotaNode = new TreeNode( "Toyota Plc[丰田]", 39, 39 );
			ToyotaNode.Nodes.Add( GetTreeNodeByIndex( "ToyoPuc Tcp", 39, typeof( FormToyoPuc ) ) );
			ToyotaNode.Nodes.Add( GetTreeNodeByIndex( "ToyoPuc Server", 39, typeof( FormToyoPucServer ) ) );
			treeView1.Nodes.Add( ToyotaNode );

			// delta Plc
			TreeNode deltaNode = new TreeNode( "Delta Plc[台达]", 32, 32 );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Serial", 32, typeof( FormDeltaDvpSerial ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Serial Over Tcp", 32, typeof( FormDeltaSerialOverTcp ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Serial Ascii", 32, typeof( FormDeltaDvpSerialAscii ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Ascii Over Tcp", 32, typeof( FormDeltaSerialAsciiOverTcp ) ) );
			deltaNode.Nodes.Add( GetTreeNodeByIndex( "Tcp Net", 32, typeof( FormDeltaDvpTcpNet ) ) );
			treeView1.Nodes.Add( deltaNode );

			// 身份证阅读器
			TreeNode idNode = new TreeNode( "ID Card[身份证]", 4, 4 );
			idNode.Nodes.Add( GetTreeNodeByIndex( "SAM Serial", 27, typeof( FormSAMSerial ) ) );
			idNode.Nodes.Add( GetTreeNodeByIndex( "SAM Tcp", 27, typeof( FormSAMTcpNet ) ) );
			treeView1.Nodes.Add( idNode );

			// Redis 相关
			TreeNode redisNode = new TreeNode( "Redis", 12, 12 );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Client", 12, typeof( FormRedisClient ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Browser", 12, typeof( HslRedisDesktop.FormRedisMain ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Subscribe", 12, typeof( FormRedisSubscribe ) ) );
			redisNode.Nodes.Add( GetTreeNodeByIndex( "Redis Copy", 12, typeof( FormRedisCopy ) ) );
			treeView1.Nodes.Add( redisNode );

			// Mqtt 相关
			TreeNode mqttNode = new TreeNode( "MQTT", 17, 17 );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt Server", 17, typeof( FormMqttServer ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt Client", 17, typeof( FormMqttClient ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt RPC Client", 17, typeof( FormMqttSyncClient ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt File Server", 17, typeof( FormMqttFileServer ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt File Client", 17, typeof( FormMqttFileClient ) ) );
			mqttNode.Nodes.Add( GetTreeNodeByIndex( "Mqtt Rpc Device", 17, typeof( FormMqttRpcDevice ) ) );
			treeView1.Nodes.Add( mqttNode );

			// WebSocket 相关
			TreeNode wsNode = new TreeNode( "WebSocket", 28, 28 );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket Client", 28, typeof( FormWebsocketClient ) ) );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket Server", 28, typeof( FormWebsocketServer ) ) );
			wsNode.Nodes.Add( GetTreeNodeByIndex( "WebSocket QANet", 28, typeof( FormWebsocketQANet ) ) );
			treeView1.Nodes.Add( wsNode );

			// HttpWeb 相关
			TreeNode httpNode = new TreeNode( "Http", 46, 46 );
			httpNode.Nodes.Add( GetTreeNodeByIndex( "Http Web Server", 46, typeof( FormHttpServer ) ) );
			httpNode.Nodes.Add( GetTreeNodeByIndex( "Http Web Client", 46, typeof( FormHttpClient ) ) );
			treeView1.Nodes.Add( httpNode );

			// Robot 相关
			TreeNode robotNode = new TreeNode( "Robot[机器人]", 19, 19 );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "EFORT New [新版]", 24, typeof( Robot.FormEfort ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "EFORT Pre [旧版]", 24, typeof( Robot.FormEfortPrevious ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Kuka [库卡]", 23, typeof( FormKuka ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Kuka Tcp [库卡]", 23, typeof( FormKukaTcp ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "YRC1000 [安川]", 29, typeof( FormYRC1000 ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "HighEthernet [安川]", 29, typeof( FormYRCHighEthernet ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "ABB Web", 21, typeof( Robot.FormABBWebApi ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "ABB Web Server", 21, typeof( FormAbbServer ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc [发那科]", 25, typeof( Robot.FormFanucRobot ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc Server [发那科服务器]", 25, typeof( FormFanucRobotServer ) ) );
			robotNode.Nodes.Add( GetTreeNodeByIndex( "Estun [埃斯顿]", 19, typeof( Robot.FormEstunTcp ) ) );
			robotNode.Nodes.Add( new TreeNode( "Hyundai [现代]" ) { Tag = typeof( Robot.FormHyundaiUdp ) } );
			robotNode.Nodes.Add( new TreeNode( "YamahaRCX [雅马哈]" ) { Tag = typeof( Robot.FormYamahaRCX ) } );
			treeView1.Nodes.Add( robotNode );

			TreeNode cncNode = new TreeNode( "CNC[数控机床]" );
			cncNode.Nodes.Add( GetTreeNodeByIndex( "Fanuc 0i [Test]", 25, typeof( FormCncFanuc ) ) );
			treeView1.Nodes.Add( cncNode );

			TreeNode secsNode = new TreeNode( "Secs [半导体]" );
			secsNode.Nodes.Add( new TreeNode( "Secs Gem" ) { Tag = typeof( FormSecsGem ) } );
			secsNode.Nodes.Add( new TreeNode( "Secs Server" ) { Tag = typeof( PLC.Secs.FormSecsHsmsServer ) } );
			treeView1.Nodes.Add( secsNode );

			TreeNode sensorNode = new TreeNode( "Sensor[传感器]" );
			sensorNode.Nodes.Add( new TreeNode( "Vibration[捷杰振动]" ) { Tag = typeof( FormVibrationSensorClient ) } );
			treeView1.Nodes.Add( sensorNode );

			TreeNode freeNode = new TreeNode( "Freedom[自由协议]" );
			freeNode.Nodes.Add( new TreeNode( "TCP Net" ) { Tag = typeof( FormFreedomTcpNet ) } );
			freeNode.Nodes.Add( new TreeNode( "UDP Net" ) { Tag = typeof( FormFreedomUdpNet ) } );
			freeNode.Nodes.Add( new TreeNode( "Serial [串口]" ) { Tag = typeof( FormFreedomSerial ) } );
			treeView1.Nodes.Add( freeNode );

			// Debug 相关
			TreeNode debugNode = new TreeNode( "Debug About[调试技术]", 15, 15 );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Regex [正则表达式]", 15, typeof( FormRegexTest ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Check [校验码调试]", 15, typeof( FormCheck ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Serial [串口调试]", 40, typeof( FormSerialDebug ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Tcp/Ip Client [网口调试]", 41, typeof( FormTcpDebug ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Tcp/Ip Server [网口调试]", 41, typeof( FormTcpServer ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Serial2Tcp [串口转网口]", 40, typeof( FormSerialToTcp ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Tcp2Tcp [网口转网口]", 41, typeof( FormTcpToTcp ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Bytes Data [数据调试]", 42, typeof( FormByteTransfer ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Mail [邮件调试]", 15, typeof( FormMail ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Order Number [订单号调试]", 15, typeof( FormSeqCreate ) ) );
			debugNode.Nodes.Add( GetTreeNodeByIndex( "Regist [注册码调试]", 15, typeof( FormRegister ) ) );
			treeView1.Nodes.Add( debugNode );
			treeNodeDebug = debugNode;

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
			TreeNode barCodeNode = new TreeNode( "Bar/RFID[扫码及RFID]", 16, 16 );
			barCodeNode.Nodes.Add( GetTreeNodeByIndex( "Sick", 16, typeof( BarCode.FormSickBarCode ) ) );
			barCodeNode.Nodes.Add( GetTreeNodeByIndex( "Turck Reader", 38, typeof( FormTurckReaderNet ) ) );
			barCodeNode.Nodes.Add( GetTreeNodeByIndex( "Turck Reader Server", 38, typeof( FormTurckReaderServer ) ) );
			treeView1.Nodes.Add( barCodeNode );

			// Instrument 仪器仪表
			TreeNode instrumentNode = new TreeNode( "Instrument [仪器仪表]" );
			instrumentNode.Nodes.Add( new TreeNode( "DAM3601 [阿尔泰科技]" ) { Tag = typeof( FormDAM3601 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 [电力规约]" ) { Tag = typeof( FormDLT645 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 OverTcp" ) { Tag = typeof( FormDLT645OverTcp ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645 Server" ) { Tag = typeof( FormDLT645Server ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645-1997" ) { Tag = typeof( FormDLT645With1997 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT645-1997 OverTcp" ) { Tag = typeof( FormDLT645With1997OverTcp ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT698 [电力规约]" ) { Tag = typeof( FormDLT698 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT698 OverTcp" ) { Tag = typeof( FormDLT698OverTcp ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DLT698 TcpNet" ) { Tag = typeof( FormDLT698TcpNet ) } );
			instrumentNode.Nodes.Add( new TreeNode( "光源控制器" ) { Tag = typeof( Light.FormShineInLight ) } );
			instrumentNode.Nodes.Add( new TreeNode( "DTSU6606 [德力西电表]" ) { Tag = typeof( FormDTSU6606 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "IEC104 [电力规约]", 37, 37 ) { Tag = typeof( FormIEC104 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "CJT188 [水表，燃气]" ) { Tag = typeof( FormCJT188 ) } );
			instrumentNode.Nodes.Add( new TreeNode( "CJT188 OverTcp" ) { Tag = typeof( FormCJT188OverTcp ) } );
			treeView1.Nodes.Add( instrumentNode );

			// 托利多电子秤Toledo
			TreeNode toledoNode = new TreeNode( "Toledo [托利多]", 18, 18 );
			toledoNode.Nodes.Add( GetTreeNodeByIndex( "Toledo Server [网口串口]", 18, typeof( Toledo.FormToledoTcpServer ) ) );
			treeView1.Nodes.Add( toledoNode );

			// 算法相关 algorithms
			TreeNode algorithmsNode = new TreeNode( "Algorithms [算法]" );
			algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶算法]" ) { Tag = typeof( Algorithms.FourierTransform ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶滤波]" ) { Tag = typeof( Algorithms.FourierFilter ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "PID [Pid模拟]" ) { Tag = typeof( Algorithms.FormPid ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "RSA [加密解密]" ) { Tag = typeof( FormRSADebug ) } );
			algorithmsNode.Nodes.Add( new TreeNode( "Cert [Hsl证书]" ) { Tag = typeof( FormHslCertificate ) } );
			treeView1.Nodes.Add( algorithmsNode );

			// 其他界面
			TreeNode othersNode = new TreeNode( "Special [特殊协议]" );
			othersNode.Nodes.Add( new TreeNode( "Open Protocol" ) { Tag = typeof( FormOpenProtocol ) } );
			othersNode.Nodes.Add( new TreeNode( "Open ProtocolServer" ) { Tag = typeof( FormOpenProtocolServer ) } );
			othersNode.Nodes.Add( new TreeNode( "南京自动化 DCS" ) { Tag = typeof( FormDcsNanJingAuto ) } );
			othersNode.Nodes.Add( new TreeNode( "Knx" ) { Tag = typeof( PLC.FormKnx ) } );
			treeView1.Nodes.Add( othersNode );

			// treeView1.ExpandAll( );
		}

		private TreeNode GetTreeNodeByIndex( string name, int index, Type form )
		{
			formIconImageIndex.Add( form.Name, index );
			return new TreeNode( name, index, index )
			{
				Tag = form
			};
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

					if (parent == null)
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

		private ILogNet logNet = null;
		private ImageList imageList;
		private Dictionary<string, int> formIconImageIndex = new Dictionary<string, int>( );
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
		public static Type[] formTypes = Assembly.GetExecutingAssembly( ).GetTypes( );
		private TreeNode treeNodeDebug;

		/// <summary>
		/// 获取当前的图标信息
		/// </summary>
		public Dictionary<string, int> IconImageIndex => this.formIconImageIndex;

		public void RenderSerialDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[2] );
		}

		public void RenderTCPDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[3] );
		}


		public void RenderTCPServerDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[4] );
		}

		public void RenderSerial2TcpDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[5] );
		}

		public void RenderTCP2TcpDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[6] );
		}

		public void RenderByteTransformDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[7] );
		}

		public void RenderRegexDebug( )
		{
			RenderTreeNode( treeNodeDebug.Nodes[0] );
		}
	}
}
