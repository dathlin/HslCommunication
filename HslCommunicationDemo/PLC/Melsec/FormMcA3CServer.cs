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
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_format.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			comboBox_format.SelectedIndex = 0;

			if(Program.Language == 2)
			{
				Text = "MC Virtual Server";
				label4.Text = "Station:";
			}

			checkBox_sumcheck.CheckedChanged += CheckBox2_CheckedChanged;

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Melsec.Helper.GetMcServerAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
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
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start

		private MelsecA3CServer mcNetServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				mcNetServer.SumCheck = checkBox_sumcheck.Checked;
				mcNetServer.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
				mcNetServer.Station = byte.Parse( textBox_station.Text );
				//mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( mcNetServer );
				if (this.serverSettingControl1.ServerStart( mcNetServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( mcNetServer, "D100" );
				userControlReadWriteServer1.SetEnable( true );
				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", "", mcNetServer, this.sslServerControl1, nameof( mcNetServer.Station ), nameof( mcNetServer.SumCheck ), nameof( mcNetServer.Format ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			if (mcNetServer != null)
			{
				mcNetServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
				this.serverSettingControl1.ButtonSerial.Enabled = false;

				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, mcNetServer, nameof( mcNetServer.Station ), nameof( mcNetServer.SumCheck ), nameof( mcNetServer.Format ) );
			}
		}
		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			userControlReadWriteServer1.Close( );
			mcNetServer?.CloseSerialSlave( );
			mcNetServer?.ServerClose( );
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
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "SumCheck", checkBox_sumcheck.Checked );
			element.SetAttributeValue( "Format", comboBox_format.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			checkBox_sumcheck.Checked     = GetXmlValue( element, "SumCheck", true, bool.Parse );
			comboBox_format.SelectedIndex = GetXmlValue( element, "Format", 0, int.Parse );
			textBox_station.Text          = GetXmlValue( element, DemoDeviceList.XmlStation, "0", m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
