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
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.Modbus;
using HslCommunication.Serial;

namespace HslCommunicationDemo
{
	public partial class FormModbusRtu : HslFormContent
	{
		public FormModbusRtu( )
		{
			InitializeComponent( );
		}

		private ModbusRtu busRtuClient = null;
		private ModbusControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;



			comboBox2.SelectedIndex = 2;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

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
			control = new ModbusControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Modbus Rtu Read Demo";

				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label22.Text = "DataBit";
				label23.Text = "StopBit";
				label24.Text = "parity";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				checkBox2.Text = "IsClearCacheBeforeRead";
				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busRtuClient != null)
			{
				busRtuClient.IsStringReverse = checkBox3.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busRtuClient != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
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

			busRtuClient?.Close( );
			busRtuClient = new ModbusRtu( station );
			busRtuClient.AddressStartWithZero = checkBox1.Checked;
			busRtuClient.IsClearCacheBeforeRead = checkBox2.Checked;
			busRtuClient.LogNet = LogNet;
			busRtuClient.Crc16CheckEnable = checkBox_crc16.Checked;


			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
			busRtuClient.IsStringReverse = checkBox3.Checked;

			try
			{
				busRtuClient.SerialPortInni( sp =>
				 {
					 sp.PortName = comboBox3.Text;
					 sp.BaudRate = baudRate;
					 sp.DataBits = dataBits;
					 sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					 sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				 } );
				busRtuClient.RtsEnable = checkBox5.Checked;
				busRtuClient.Open( );

				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置子控件的读取能力
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( busRtuClient, "100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( busRtuClient, "100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busRtuClient.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busRtuClient.ReadFromCoreServer( SoftCRC16.CRC16( m ), true, false ), "No CRC", "with no crc16, example: 01 03 00 00 00 01" );

				control.SetDevice( busRtuClient, "100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			busRtuClient.Close( );
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
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
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
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
			comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
