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
using HslCommunication.Profinet.Turck;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormTurckReaderServer : HslFormContent
	{
		public FormTurckReaderServer( )
		{
			InitializeComponent( );
			readerServer = new ReaderServer( );                       // 实例化对象
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Turck Reader protocol";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample(
				new DeviceAddressExample[]
				{
					new DeviceAddressExample( "100",    "整数地址", false, true, "" ),
					new DeviceAddressExample( "100.1",    "小数地址", false, true, "" ),
				} );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}


		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			readerServer?.ServerClose( );
		}

		#region Server Start

		private ReaderServer readerServer;
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
				readerServer.BytesOfBlock   = int.Parse( textBox1.Text );
				readerServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				this.sslServerControl1.InitializeServer( readerServer );
				readerServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( readerServer, "100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", readerServer, nameof( readerServer.BytesOfBlock ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			if (readerServer != null)
			{
				readerServer.StartSerialSlave( textBox_serial.Text );
				button5.Enabled = false;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", textBox_serial.Text, readerServer, nameof( readerServer.BytesOfBlock ) );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			readerServer?.CloseSerialSlave( );
			readerServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button5.Enabled = true;
			button11.Enabled = false;
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
			element.SetAttributeValue( "BytesOfBlock", textBox1.Text );
			element.SetAttributeValue( "Serial", textBox_serial.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox1.Text = element.Attribute( "BytesOfBlock" ).Value;
			textBox_serial.Text = GetXmlValue( element, "Serial", textBox_serial.Text, m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
