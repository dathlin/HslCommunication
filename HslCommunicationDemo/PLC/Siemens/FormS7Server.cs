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
				Text = "S7 Virtual Server [data support i,q,m,db block read and write, db block only one, whether it is DB1.1 or DB100.1 refers to the same]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Siemens.Helper.GetSiemensS7Address( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
			//timer = new Timer( );
			//timer.Interval = 1000;
			//timer.Tick += Timer_Tick;
			//timer.Start( );
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
			if (button1.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private HslCommunication.Profinet.Siemens.SiemensS7Server s7NetServer;
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

				s7NetServer = new HslCommunication.Profinet.Siemens.SiemensS7Server( );                       // 实例化对象
				s7NetServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				s7NetServer.OnDataReceived += BusTcpServer_OnDataReceived;

				this.sslServerControl1.InitializeServer( s7NetServer );

				userControlReadWriteServer1.SetReadWriteServer( s7NetServer, "M100" );
				s7NetServer.ServerStart( port );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", s7NetServer );
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

		private void button_db_add_Click( object sender, EventArgs e )
		{
			if (int.TryParse( textBox_db.Text, out int db ))
			{
				if (s7NetServer == null)
					DemoUtils.ShowMessage( "Must start s7 server first!" );
				else
				{
					s7NetServer.AddDbBlock( db );
					DemoUtils.ShowMessage( "Add db block success" );
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Please input correct db block number!" );
			}
		}

		private void button_db_remove_Click( object sender, EventArgs e )
		{
			if (int.TryParse( textBox_db.Text, out int db ))
			{
				if (s7NetServer == null)
					DemoUtils.ShowMessage( "Must start s7 server first!" );
				else if (db == 1 || db == 2 || db == 3)
				{
					DemoUtils.ShowMessage( "Can not remove db block 1, 2, 3" );
				}
				else
				{
					s7NetServer.RemoveDbBlock( db );
					DemoUtils.ShowMessage( "Remove db block success" );
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Please input correct db block number!" );
			}
		}

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
