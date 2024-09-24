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
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo
{
	public partial class FormMcServer : HslFormContent
	{
		public FormMcServer( )
		{
			InitializeComponent( );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "MC Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label14.Text = "Serial:";
				button5.Text = "Start";
				toolTip1.SetToolTip( radioButton_both, "The port number of the UDP defaults to the tcp port number +1" );
			}
			else
			{

				toolTip1.SetToolTip( radioButton_both, "Udp的端口号默认为 Tcp 的端口号 +1" );
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Melsec.Helper.GetMcServerAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );


			button5.Enabled = false;
			if (ServerMode == 1) this.userControlHead1.ProtocolInfo = "Mc Qna3E Udp Server";
			if (ServerMode == 2) this.userControlHead1.ProtocolInfo = "Mc A1E Tcp Server";

		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			mcNetServer?.ServerClose( );
		}

		#region Server Start

		/// <summary>
		/// 服务器模式，0： MC协议TCP，1：MC协议UDP，2：A1E协议TCP
		/// </summary>
		public int ServerMode { get; set; } = 0;
		private HslCommunication.Profinet.Melsec.MelsecMcServer mcNetServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			int port1 = 0;
			int port2 = 0;
			if (textBox2.Text.Contains( ";" ) || textBox2.Text.Contains( ":" ) || textBox2.Text.Contains( "-" ))
			{
				string[] ports = textBox2.Text.Split( new char[] { ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries );
				if (ports.Length >= 1)
				{
					if (!int.TryParse( ports[0], out port1 ))
					{
						MessageBox.Show( DemoUtils.PortInputWrong );
						return;
					}

					if (!int.TryParse( ports[1], out port2 ))
					{
						MessageBox.Show( DemoUtils.PortInputWrong );
						return;
					}
				}
			}
			else
			{
				if (!int.TryParse( textBox2.Text, out port1 ))
				{
					MessageBox.Show( DemoUtils.PortInputWrong );
					return;
				}
				port2 = port1 + 1;
			}

			try
			{
				if (ServerMode == 0) mcNetServer = new HslCommunication.Profinet.Melsec.MelsecMcServer( radioButton_binary.Checked );                       // 实例化对象
				else if (ServerMode == 2) mcNetServer = new HslCommunication.Profinet.Melsec.MelsecA1EServer( radioButton_binary.Checked );

				mcNetServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );                            // 1小时不通信就断开
				mcNetServer.EnableIPv6 = radioButton_ipv6.Checked;                               // 是否开启IPv6
				mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;                     // 接收到数据触发
				userControlReadWriteServer1.SetReadWriteServerLog( mcNetServer );                // 设置日志

				this.sslServerControl1.InitializeServer( mcNetServer );  // 如果配置SSL，则初始化SSL

				if (radioButton_tcp.Checked)
				{
					mcNetServer.ServerStart( port1, modeTcp: true );
				}
				else if (radioButton_udp.Checked)
				{
					mcNetServer.ServerStart( port1, modeTcp: false );
				}
				else
				{
					mcNetServer.ServerStart( port1,  port2 );
				}
				userControlReadWriteServer1.SetReadWriteServer( mcNetServer, "D100" );

				button1.Enabled = false;
				button5.Enabled = true;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", mcNetServer, nameof( mcNetServer.IsBinary ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message + "\r\n" + ex.StackTrace );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			mcNetServer?.CloseSerialSlave( );
			mcNetServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void MelsecMcServer_OnDataReceived( object sender, PipeSession session, byte[] receive )
		{
			// 我们可以捕获到接收到的客户端的modbus报文
			// 如果是TCP接收的
			if (session.Communication is PipeTcpNet pipeTcpNet)
			{
				// 获取当前客户的IP地址
				string ip = pipeTcpNet.IpAddress;
			}

			// 如果是串口接收的
			if (session.Communication is PipeSerialPort serialPort)
			{
				// 获取当前的串口的名称
				string portName = serialPort.GetPipe( ).PortName;
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			mcNetServer.StartSerialSlave( textBox_serialPort.Text );
			button5.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", textBox_serialPort.Text, mcNetServer, nameof( mcNetServer.IsBinary ) );

		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBinary, radioButton_binary.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlCom, textBox_serialPort.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			bool check = bool.Parse( element.Attribute( DemoDeviceList.XmlBinary ).Value );
			if (check)
				radioButton_binary.Checked = true;
			else
				radioButton_ascii.Checked = true;
			textBox_serialPort.Text = GetXmlValue( element, DemoDeviceList.XmlCom, textBox_serialPort.Text, m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
