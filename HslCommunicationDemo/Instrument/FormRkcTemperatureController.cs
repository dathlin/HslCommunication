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
using HslCommunication.Instrument.RKC;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormRkcTemperatureController : HslFormContent
	{
		public FormRkcTemperatureController( )
		{
			InitializeComponent( );
			rkc = new TemperatureController( );
			// omronHostLink.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private TemperatureController rkc = null;
		private SpecialFeaturesControl control;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
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
			comboBox2.SelectedIndex = 0;

			control = new SpecialFeaturesControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "RKC CD/CH digital temperature controller";

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

			rkc?.Close( );
			rkc = new TemperatureController( );
			rkc.LogNet = LogNet;

			try
			{
				rkc.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
					sp.Parity = comboBox2.SelectedIndex == 0 ? Parity.None : (comboBox2.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
				} );
				//yamateke.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;

				rkc.Open( );
				rkc.Station = Station;
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( rkc, "M1", false );
				userControlReadWriteDevice1.ReadWriteOp.EnableRKC( );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( rkc, "M1", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => rkc.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

				control.SetDevice( rkc, "M1" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			rkc.Close( );
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
			textBox1.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
