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
	public partial class FormOmronServer : HslFormContent
	{
		public FormOmronServer( )
		{
			InitializeComponent( );

			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

			checkBox_isstringreverse.CheckedChanged += CheckBox_isstringreverse_CheckedChanged;
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void CheckBox_isstringreverse_CheckedChanged( object sender, EventArgs e )
		{
			if (omronFinsServer != null) omronFinsServer.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (omronFinsServer != null) omronFinsServer.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Omron Virtual Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Omron.Helper.GetOmronAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		private HslCommunication.Profinet.Omron.OmronFinsServer omronFinsServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				omronFinsServer = new HslCommunication.Profinet.Omron.OmronFinsServer( );                       // 实例化对象
				omronFinsServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
				omronFinsServer.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
				omronFinsServer.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
				this.sslServerControl1.InitializeServer( omronFinsServer );
				if (this.serverSettingControl1.ServerStart( omronFinsServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置示例代码
				codeExampleControl.SetCodeText( "server", "", omronFinsServer, this.sslServerControl1, nameof( omronFinsServer.ActiveTimeSpan ), nameof( omronFinsServer.DataFormat ), "ByteTransform.IsStringReverseByteWord" );
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
			omronFinsServer?.ServerClose( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			omronFinsServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
			this.serverSettingControl1.ButtonSerial.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, omronFinsServer, this.sslServerControl1, nameof( omronFinsServer.DataFormat ), "ByteTransform.IsStringReverseByteWord" );

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

		public override void SaveXmlParameter( XElement element )
		{
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			this.userControlReadWriteServer1.LoadDataTable( element );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedItem.ToString( ) );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.userControlReadWriteServer1.GetDataTable( element );
			this.comboBox1.SelectedItem = GetXmlEnum( element, DemoDeviceList.XmlDataFormat, HslCommunication.Core.DataFormat.CDAB );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
