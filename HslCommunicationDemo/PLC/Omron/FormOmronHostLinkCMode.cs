using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication;
using HslCommunication.Profinet.Omron;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Omron;

namespace HslCommunicationDemo
{
	public partial class FormOmronHostLinkCMode : HslFormContent
	{
		public FormOmronHostLinkCMode( )
		{
			InitializeComponent( );
			omronHostLink = new OmronHostLinkCMode( );
			// omronHostLink.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private OmronHostLinkCMode omronHostLink = null;
		private HostLinkCModeControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			panel2.Enabled = false;

			Language( Program.Language );
			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
			comboBox2.SelectedIndex = 2;

			control = new HostLinkCModeControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";

				label1.Text = "Station:";
				label3.Text = "Parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label21.Text = "Address:";
				label29.Text = "Com:";
				label28.Text = "BaudRate:";
				label27.Text = "DataBit:";
				label26.Text = "StopBit:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox19.Text, out int baudRate ))
			{
				MessageBox.Show( DemoUtils.BaudRateInputWrong );
				return;
			}

			if (!int.TryParse( textBox18.Text, out int dataBits ))
			{
				MessageBox.Show( DemoUtils.DataBitsInputWrong );
				return;
			}

			if (!int.TryParse( textBox2.Text, out int stopBits ))
			{
				MessageBox.Show( DemoUtils.StopBitInputWrong );
				return;
			}

			if (!byte.TryParse( textBox1.Text, out byte Station ))
			{
				MessageBox.Show( "PLC Station input wrong！" );
				return;
			}

			omronHostLink?.Close( );
			omronHostLink = new OmronHostLinkCMode( );
			omronHostLink.LogNet = LogNet;

			try
			{
				omronHostLink.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox2.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox2.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				omronHostLink.UnitNumber = Station;
				omronHostLink.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;


				omronHostLink.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置子控件的读取能力
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( omronHostLink, "D100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( omronHostLink, "D100", string.Empty );
				// userControlReadWriteDevice1.BatchRead.SetReadRandom( omronFinsNet.ReadRandom );
				//userControlReadWriteDevice1.BatchRead.SetReadWordRandom( omronHostLink.Read );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronHostLink.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );


				control.SetDevice( omronHostLink, "D100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			omronHostLink.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox19.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox18.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox19.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox18.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
