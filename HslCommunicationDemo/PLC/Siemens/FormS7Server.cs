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
using HslCommunicationDemo.DemoControl;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Siemens;

namespace HslCommunicationDemo
{
	public partial class FormS7Server : HslFormContent
	{
		public FormS7Server( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "S7 Virtual Server [data support i,q,m,db block read and write, DB1, DB2, DB3, others need add]";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Siemens.Helper.GetSiemensS7Address( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			dbControl = new S7ServerDbControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( dbControl, false, "Db Blocks" );
			dbControl.Enabled = false;

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			//timer = new Timer( );
			//timer.Interval = 1000;
			//timer.Tick += Timer_Tick;
			//timer.Start( );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}

		private short m60 = 0;
		private bool m62 = false;
		private float m64 = 1.1f;


		private void Timer_Tick( object sender, EventArgs e )
		{
			m60++;
			s7NetServer.Write( "M60", m60 );
			s7NetServer.Write( "M62", !m62 );
			m62 = !m62;
			m64 += 1f;
			if (m64 > 2000) m64 = 1.1f;
			s7NetServer.Write( "M64", m64 );
			s7NetServer.Write( "M70", "A" + DateTime.Now.Minute.ToString( ) + DateTime.Now.Second.ToString( ) );
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private HslCommunication.Profinet.Siemens.SiemensS7Server s7NetServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private S7ServerDbControl dbControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{

				s7NetServer = new HslCommunication.Profinet.Siemens.SiemensS7Server( );                       // 实例化对象
				s7NetServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				s7NetServer.OnDataReceived += BusTcpServer_OnDataReceived;

				this.sslServerControl1.InitializeServer( s7NetServer );
				if (this.serverSettingControl1.ServerStart( s7NetServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( s7NetServer, "M100" );
				userControlReadWriteServer1.SetEnable( true );

				dbControl.SetServer( s7NetServer );
				dbControl.Enabled = true;
				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", s7NetServer, this.sslServerControl1 );
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
			s7NetServer?.ServerClose( );
			dbControl.Enabled = false;
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			s7NetServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
			this.serverSettingControl1.ButtonSerial.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, s7NetServer, this.sslServerControl1 );

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

		public override void SaveXmlParameter( XElement element )
		{
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			this.userControlReadWriteServer1.GetDataTable( element );
			this.dbControl.SaveToXElement( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.userControlReadWriteServer1.LoadDataTable( element );
			this.dbControl.LoadFromXElement( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
