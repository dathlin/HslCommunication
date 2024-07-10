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
using HslCommunication.Profinet.Melsec;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormMcA3CServer : HslFormContent
	{
		public FormMcA3CServer( )
		{
			InitializeComponent( );
			mcNetServer = new MelsecA3CServer( );                       // 实例化对象
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_format.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			comboBox_format.SelectedIndex = 0;

			if(Program.Language == 2)
			{
				Text = "MC Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}

			checkBox_sumcheck.CheckedChanged += CheckBox2_CheckedChanged;

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Melsec.Helper.GetMcServerAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (mcNetServer != null)
			{
				mcNetServer.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
			}
		}

		private void CheckBox2_CheckedChanged( object sender, EventArgs e )
		{
			if (mcNetServer != null)
			{
				mcNetServer.SumCheck = checkBox_sumcheck.Checked;
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			mcNetServer?.ServerClose( );
		}

		#region Server Start

		private MelsecA3CServer mcNetServer;
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
				mcNetServer.SumCheck = checkBox_sumcheck.Checked;
				mcNetServer.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
				mcNetServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				//mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( mcNetServer );
				mcNetServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( mcNetServer, "D100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", "", mcNetServer, nameof( mcNetServer.Station ), nameof( mcNetServer.SumCheck ), nameof( mcNetServer.Format ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			if (mcNetServer != null)
			{
				mcNetServer.StartSerialSlave( textBox_serial.Text );
				button5.Enabled = false;

				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", textBox_serial.Text, mcNetServer, nameof( mcNetServer.Station ), nameof( mcNetServer.SumCheck ), nameof( mcNetServer.Format ) );
			}
		}
		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			mcNetServer?.CloseSerialSlave( );
			mcNetServer?.ServerClose( );
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
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( "SumCheck", checkBox_sumcheck.Checked );
			element.SetAttributeValue( "Format", comboBox_format.SelectedIndex );
			element.SetAttributeValue( "Serial", textBox_serial.Text );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox_sumcheck.Checked = GetXmlValue( element, "SumCheck", true, bool.Parse );
			comboBox_format.SelectedIndex = GetXmlValue( element, "Format", 0, int.Parse );
			textBox_serial.Text = GetXmlValue( element, "Serial", textBox_serial.Text, m => m );

			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
