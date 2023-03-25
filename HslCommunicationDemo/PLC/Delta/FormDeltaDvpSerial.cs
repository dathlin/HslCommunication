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
using System.Threading;
using System.IO.Ports;
using HslCommunication.Profinet.Delta;
using System.Xml.Linq;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormDeltaDvpSerial : HslFormContent
	{
		public FormDeltaDvpSerial( )
		{
			InitializeComponent( );
		}

		private DeltaSerial delta = null;
		private SpecialFeaturesControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}

			Language( Program.Language );
			comboBox1.SelectedIndex = 2;

			comboBox2.DataSource = SoftBasic.GetEnumValues<DeltaSeries>( );
			control = new SpecialFeaturesControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Delta DVP Read Demo";

				label1.Text = "Com:";
				label2.Text = "Series:";
				label3.Text = "baudRate:";
				label22.Text = "DataBit";
				label23.Text = "StopBit";
				label24.Text = "parity";
				label21.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int baudRate ))
			{
				MessageBox.Show( DemoUtils.BaudRateInputWrong );
				return;
			}

			if (!int.TryParse( textBox16.Text, out int dataBits ))
			{
				MessageBox.Show( DemoUtils.DataBitsInputWrong );
				return;
			}

			if (!int.TryParse( textBox17.Text, out int stopBits ))
			{
				MessageBox.Show( DemoUtils.StopBitInputWrong );
				return;
			}


			if (!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "Station input wrong！" );
				return;
			}

			delta?.Close( );
			delta = new DeltaSerial( station );
			delta.LogNet = LogNet;
			delta.Series = (DeltaSeries)comboBox2.SelectedItem;

			try
			{
				delta.SerialPortInni( sp =>
				 {
					 sp.PortName = comboBox3.Text;
					 sp.BaudRate = baudRate;
					 sp.DataBits = dataBits;
					 sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					 sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				 } );
				delta.RtsEnable = checkBox5.Checked;
				delta.Open( );

				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置基本的读写信息
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( delta, "D100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( delta, "D100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => delta.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => delta.ReadFromCoreServer( m ), "None CRC", "example: 01 03 00 00 00 01" );

				control.SetDevice( delta, "D100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			delta.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
