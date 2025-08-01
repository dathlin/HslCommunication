﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Beckhoff;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormBeckhoffAdsServer : HslFormContent
	{
		public FormBeckhoffAdsServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Beckhoff ADS Virtual Server [data support, bool: M, I, Q]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict mc protocol and only supports perfect communication with HSL components.";
			}


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Beckhoff.Helper.GetDeviceAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start

		private BeckhoffAdsServer adsServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				adsServer = new BeckhoffAdsServer( );                       // 实例化对象
				adsServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );         // 如果客户端1个小时不通信，就关闭连接
				adsServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( adsServer );
				// 添加几个符号数据
				adsServer.AddTagValue( "MAIN.bool1", true );
				adsServer.AddTagValue( "MAIN.a", (short)0 );
				adsServer.AddTagValue( "MAIN.cc", 0 );
				adsServer.AddTagValue( "MAIN.dd", 0f );
				adsServer.AddTagValue( "MAIN.ee", new bool[11] );
				adsServer.AddTagValue( "MAIN.ff", new short[3] );

				adsServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( adsServer, "M100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", adsServer );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button11.Enabled = false;
			adsServer?.ServerClose( );
		}

		private void MelsecMcServer_OnDataReceived( object sender,  object source, byte[] receive )
		{
			// 我们可以捕获到接收到的客户端的modbus报文
			// 如果是TCP接收的
			if (source is HslCommunication.Core.Net.AppSession session)
			{
				// 获取当前客户的IP地址
				string ip = session.IpAddress;
			}

			// 如果是串口接收的
			if (source is System.IO.Ports.SerialPort serialPort)
			{
				// 获取当前的串口的名称
				string portName = serialPort.PortName;
			}
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;

			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
