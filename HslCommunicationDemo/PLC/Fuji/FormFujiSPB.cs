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
using HslCommunication.Profinet.Fuji;
using HslCommunication;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormFujiSPB : HslFormContent
	{
		public FormFujiSPB( )
		{
			InitializeComponent( );
			fujiSPB = new FujiSPB( );
		}


		private FujiSPB fujiSPB = null;
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
				Text = "Fuji Read PLC Demo";

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
			

			fujiSPB?.Close( );
			fujiSPB = new FujiSPB( );
			fujiSPB.LogNet = LogNet;
			
			try
			{
				fujiSPB.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				fujiSPB.Station = byte.Parse( textBox15.Text );


				fujiSPB.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置基本的读写信息
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( fujiSPB, "M100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( fujiSPB, "M100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => fujiSPB.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

				control.SetDevice( fujiSPB, "M100" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			fujiSPB.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 测试使用

		private void test3( )
		{
			short d100_short = fujiSPB.ReadInt16( "D100" ).Content;
			ushort d100_ushort = fujiSPB.ReadUInt16( "D100" ).Content;
			int d100_int = fujiSPB.ReadInt32( "D100" ).Content;
			uint d100_uint = fujiSPB.ReadUInt32( "D100" ).Content;
			long d100_long = fujiSPB.ReadInt64( "D100" ).Content;
			ulong d100_ulong = fujiSPB.ReadUInt64( "D100" ).Content;
			float d100_float = fujiSPB.ReadFloat( "D100" ).Content;
			double d100_double = fujiSPB.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = fujiSPB.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			fujiSPB.Write( "D100", (short)5 );
			fujiSPB.Write( "D100", (ushort)5 );
			fujiSPB.Write( "D100", 5 );
			fujiSPB.Write( "D100", (uint)5 );
			fujiSPB.Write( "D100", (long)5 );
			fujiSPB.Write( "D100", (ulong)5 );
			fujiSPB.Write( "D100", 5f );
			fujiSPB.Write( "D100", 5d );
			// length should Multiples of 2 
			fujiSPB.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = fujiSPB.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = fujiSPB.ByteTransform.TransInt32( read.Content, 0 );
				float temp = fujiSPB.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = fujiSPB.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = fujiSPB.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			fujiSPB.WriteCustomer( "D100", new UserType( ) );

			fujiSPB.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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
