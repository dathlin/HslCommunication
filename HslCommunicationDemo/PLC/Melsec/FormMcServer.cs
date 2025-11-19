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
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "MC Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
			}
			else
			{

			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Melsec.Helper.GetMcServerAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );


			if (ServerMode == 1) this.userControlHead1.ProtocolInfo = "Mc Qna3E Udp Server";
			if (ServerMode == 2) this.userControlHead1.ProtocolInfo = "Mc A1E Tcp Server";
			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteServer1, e );
			if (e.Cancel) return;

			if (serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
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
			try
			{
				if (ServerMode == 0) mcNetServer = new HslCommunication.Profinet.Melsec.MelsecMcServer( radioButton_binary.Checked );                       // 实例化对象
				else if (ServerMode == 2) mcNetServer = new HslCommunication.Profinet.Melsec.MelsecA1EServer( radioButton_binary.Checked );

				mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;                     // 接收到数据触发
				userControlReadWriteServer1.SetReadWriteServerLog( mcNetServer );                // 设置日志

				this.sslServerControl1.InitializeServer( mcNetServer );  // 如果配置SSL，则初始化SSL
				if (!this.serverSettingControl1.ServerStart( mcNetServer )) return;   // 启动服务器

				userControlReadWriteServer1.SetReadWriteServer( mcNetServer, "D100" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", mcNetServer, this.sslServerControl1, nameof( mcNetServer.IsBinary ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message + "\r\n" + ex.StackTrace );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			userControlReadWriteServer1.Close( );
			mcNetServer?.CloseSerialSlave( );
			mcNetServer?.ServerClose( );
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
			mcNetServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
			this.serverSettingControl1.ButtonSerial.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, mcNetServer, nameof( mcNetServer.IsBinary ) );

		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.serverSettingControl1.SaveXmlParameter( element );
			this.sslServerControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlBinary, radioButton_binary.Checked );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			bool check = bool.Parse( element.Attribute( DemoDeviceList.XmlBinary ).Value );
			if (check)
				radioButton_binary.Checked = true;
			else
				radioButton_ascii.Checked = true;
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
