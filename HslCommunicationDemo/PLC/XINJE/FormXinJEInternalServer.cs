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
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormXinJEInternalServer : HslFormContent
	{
		public FormXinJEInternalServer( )
		{
			InitializeComponent( );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				label1.Text = "Station:";
				Text = "XINJE Virtual Server";
				label3.Text = "Port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.XINJE.Helper.GetXinJEInternalServerAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			xinjeServer?.ServerClose( );
		}

		#region Server Start

		private HslCommunication.Profinet.XINJE.XinJEServer xinjeServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_port.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				xinjeServer = new HslCommunication.Profinet.XINJE.XinJEServer(  );                       // 实例化对象
				xinjeServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				xinjeServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( xinjeServer );
				xinjeServer.Station = byte.Parse( textBox_station.Text );
				xinjeServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( xinjeServer, "D100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", xinjeServer, nameof( xinjeServer.Station ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			xinjeServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
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
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox_station.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "1", m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
