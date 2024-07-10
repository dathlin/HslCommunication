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
	public partial class FormOmronCipServer : HslFormContent
	{
		public FormOmronCipServer( )
		{
			InitializeComponent( );
		}



		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Omron Cip Virtual Server [support single value]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
				checkBox1.Text = "Create Tag when write";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.AllenBrandly.Helper.GetCIPAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			cipServer?.ServerClose( );
		}

		#region Server Start

		private HslCommunication.Profinet.Omron.OmronCipServer cipServer;
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

				cipServer = new HslCommunication.Profinet.Omron.OmronCipServer( );                       // 实例化对象
				cipServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
				cipServer.CreateTagWithWrite = checkBox1.Checked;
				this.sslServerControl1.InitializeServer( cipServer );

				short[] d = new short[2000];
				float[] a1 = new float[2000];
				for (int i = 0; i < d.Length; i++)
				{
					d[i] = (short)(i + 1);
					a1[i] = d[i];
				}
				
				cipServer.ServerStart( port );
				//cipServer.AddTagValue( "TEST2", new bool[10000] );
				cipServer.AddTagValue( "A", (short)10 );
				cipServer.AddTagValue( "A1", a1 );
				cipServer.AddTagValue( "B", 123 );
				cipServer.AddTagValue( "C", 123f );
				cipServer.AddTagValue( "D", d );
				cipServer.AddTagValue( "E", true );
				cipServer.AddTagValue( "F", "12345", 100 );
				cipServer.AddTagValue( "G", new string[5] { "123", "123456", string.Empty, "abcd", "测试" }, 100 );
				cipServer.AddTagValue( "AB.C", new short[] { 1, 2, 3, 4, 5 } );
				cipServer.AddTagValue( "M", new uint[] { 1, 2, 3, 4 } );
				cipServer.AddTagValue( "REAL500", new float[500] );
				cipServer.AddTagValue( "N", 100L );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;
				userControlReadWriteServer1.SetReadWriteServer( cipServer, "A", 1 );


				// 设置示例代码
				codeExampleControl.SetCodeText( "server", "", cipServer, nameof( cipServer.CreateTagWithWrite ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			cipServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
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

		#endregion

		private void userControlReadWriteServer1_Load( object sender, EventArgs e )
		{

		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "CreateTagWithWrite", checkBox1.Checked );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox1.Checked = GetXmlValue( element, "CreateTagWithWrite", false, bool.Parse );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
