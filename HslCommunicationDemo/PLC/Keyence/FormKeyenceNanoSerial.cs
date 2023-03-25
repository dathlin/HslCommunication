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
using HslCommunication.Profinet.Melsec;
using HslCommunication;
using HslCommunication.Profinet.Keyence;
using System.Xml.Linq;
using System.IO.Ports;
using HslCommunicationDemo.PLC.Keyence;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceNanoSerial : HslFormContent
	{
		public FormKeyenceNanoSerial( )
		{
			InitializeComponent( );
			keyenceNanoSerial = new KeyenceNanoSerial( );
		}


		private KeyenceNanoSerial keyenceNanoSerial = null;
		private NanoControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 2;
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
			control = new NanoControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence Read PLC Demo";

				label1.Text = "parity:";
				label3.Text = "Stop bits";
				label27.Text = "Com:";
				label26.Text = "BaudRate";
				label25.Text = "Data bits";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label2.Text = "Station:";

				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close

		
		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int baudRate ))
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

			if(!byte.TryParse(textBox3.Text,out byte station ))
			{
				MessageBox.Show( "Station int wrong, it needs 0 - 255" );
				return;
			}

			keyenceNanoSerial?.Close( );
			keyenceNanoSerial = new KeyenceNanoSerial( );
			keyenceNanoSerial.UseStation = checkBox1.Checked;
			keyenceNanoSerial.Station = station;
			keyenceNanoSerial.LogNet = LogNet;
			try
			{
				keyenceNanoSerial.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				keyenceNanoSerial.Open( );
				
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置子控件的读取能力
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( keyenceNanoSerial, "DM100", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( keyenceNanoSerial, "DM100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => keyenceNanoSerial.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				// 特殊读取
				control.SetDevice( keyenceNanoSerial, "DM100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			keyenceNanoSerial.Close( );
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
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
