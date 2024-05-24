using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.Xml.Linq;
using System.IO.Ports;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormOmronHostLinkServer : HslFormContent
	{
		public FormOmronHostLinkServer( )
		{
			InitializeComponent( );
			omronFinsServer = new HslCommunication.Profinet.Omron.OmronHostLinkServer( );                       // 实例化对象
			omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Omron Virtual Server [data support, d, a, h, c, w]";
				label3.Text = "Port:";
				label14.Text = "Serial:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				button5.Text = "Start Serial";
				label11.Text = "This server is not a strict fins protocol and only supports perfect communication with HSL components.";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Omron.Helper.GetOmronAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			omronFinsServer?.ServerClose( );
		}

		private HslCommunication.Profinet.Omron.OmronHostLinkServer omronFinsServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			try
			{
				this.sslServerControl1.InitializeServer( omronFinsServer );
				omronFinsServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				omronFinsServer.ServerStart( port );

				userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置示例代码
				codeExampleControl.SetCodeText( "server", "", omronFinsServer, nameof( omronFinsServer.UnitNumber ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}


		private void button5_Click( object sender, EventArgs e )
		{
			try
			{
				omronFinsServer.StartSerialSlave( textBox_serial.Text );

				userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
				button5.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );

				// 设置示例代码
				codeExampleControl.SetCodeText( "server", textBox_serial.Text, omronFinsServer, nameof( omronFinsServer.UnitNumber ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}
		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			omronFinsServer?.CloseSerialSlave( );
			omronFinsServer?.ServerClose( );
			button1.Enabled = true;
			button5.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived( object sender, object source, byte[] receive )
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

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "Serial", textBox_serial.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox_serial.Text = GetXmlValue( element, "Serial", textBox_serial.Text, m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
