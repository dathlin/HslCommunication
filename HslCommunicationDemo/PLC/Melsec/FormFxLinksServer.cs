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
	public partial class FormFxLinksServer : HslFormContent
	{
		public FormFxLinksServer( )
		{
			InitializeComponent( );
			fxLinksServer = new MelsecFxLinksServer( );                       // 实例化对象
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_format.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			comboBox_format.SelectedIndex = 0;

			if(Program.Language == 2)
			{
				Text = "FxLinks Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict mc protocol and only supports perfect communication with HSL components.";
				label4.Text = "Station:";
				label1.Text = "Format:";
			}

			checkBox_sumCheck.CheckedChanged += CheckBox2_CheckedChanged;


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Melsec.Helper.GetFxLinksAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
			}
		}

		private void CheckBox2_CheckedChanged( object sender, EventArgs e )
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.SumCheck = checkBox_sumCheck.Checked;
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			fxLinksServer?.ServerClose( );
		}

		#region Server Start

		private MelsecFxLinksServer fxLinksServer;
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
				fxLinksServer.SumCheck = checkBox_sumCheck.Checked;
				fxLinksServer.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
				fxLinksServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				fxLinksServer.Station = byte.Parse( textBox_station.Text );
				//mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				fxLinksServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( fxLinksServer, "D100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", "", fxLinksServer, nameof( fxLinksServer.Station ), nameof( fxLinksServer.SumCheck ), nameof( fxLinksServer.Format ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.StartSerialSlave( textBox_serial.Text );
				button5.Enabled = false;

				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", textBox_serial.Text, fxLinksServer, nameof( fxLinksServer.Station ), nameof( fxLinksServer.SumCheck ), nameof( fxLinksServer.Format ) );
			}
		}
		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			fxLinksServer?.CloseSerialSlave( );
			fxLinksServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button5.Enabled = true;
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
			element.SetAttributeValue( DemoDeviceList.XmlPort,       textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBinary,     checkBox_sumCheck.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox_format.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation,    textBox_station.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCom,        textBox_serial.Text );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text             = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox_sumCheck.Checked     = GetXmlValue( element, DemoDeviceList.XmlBinary, checkBox_sumCheck.Checked, bool.Parse );
			comboBox_format.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, comboBox_format.SelectedIndex, int.Parse );

			if (element.Attribute( DemoDeviceList.XmlStation ) != null)
				textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;

			textBox_serial.Text = GetXmlValue( element, DemoDeviceList.XmlCom, textBox_serial.Text, m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
