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
using HslCommunication.Profinet.Vigor;
using HslCommunication;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormVigorSerial : HslFormContent
	{
		public FormVigorSerial( )
		{
			InitializeComponent( );
			vigor = new VigorSerial( );
		}


		private VigorSerial vigor = null;
		private SpecialFeaturesControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
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

			control = new SpecialFeaturesControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "FATEK Read PLC Demo";

				label1.Text = "parity:";
				label3.Text = "Stop bits";
				label27.Text = "Com:";
				label26.Text = "BaudRate";
				label25.Text = "Data bits";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
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
			

			vigor?.Close( );
			vigor = new VigorSerial( );
			vigor.LogNet = LogNet;
			
			try
			{
				vigor.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				vigor.Station = byte.Parse( textBox15.Text );


				vigor.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置基本的读写信息
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( vigor, "D100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( vigor, "D100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => vigor.ReadFromCoreServer( m ), string.Empty, string.Empty );

				control.SetDevice( vigor, "D100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			vigor.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = vigor.ReadBool( "M100", 10 );
			if(read.IsSuccess)
			{
				bool m100 = read.Content[0];
				// and so on
				bool m109 = read.Content[9];
			}
			else
			{
				// failed
			}
		}
		

		private void test3( )
		{
			short d100_short = vigor.ReadInt16( "D100" ).Content;
			ushort d100_ushort = vigor.ReadUInt16( "D100" ).Content;
			int d100_int = vigor.ReadInt32( "D100" ).Content;
			uint d100_uint = vigor.ReadUInt32( "D100" ).Content;
			long d100_long = vigor.ReadInt64( "D100" ).Content;
			ulong d100_ulong = vigor.ReadUInt64( "D100" ).Content;
			float d100_float = vigor.ReadFloat( "D100" ).Content;
			double d100_double = vigor.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = vigor.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			vigor.Write( "D100", (short)5 );
			vigor.Write( "D100", (ushort)5 );
			vigor.Write( "D100", 5 );
			vigor.Write( "D100", (uint)5 );
			vigor.Write( "D100", (long)5 );
			vigor.Write( "D100", (ulong)5 );
			vigor.Write( "D100", 5f );
			vigor.Write( "D100", 5d );
			// length should Multiples of 2 
			vigor.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = vigor.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = vigor.ByteTransform.TransInt32( read.Content, 0 );
				float temp = vigor.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = vigor.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = vigor.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			vigor.WriteCustomer( "D100", new UserType( ) );

			vigor.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
