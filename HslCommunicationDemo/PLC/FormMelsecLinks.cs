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
using System.Xml.Linq;
using System.IO.Ports;

namespace HslCommunicationDemo
{
	public partial class FormMelsecLinks : HslFormContent
	{
		public FormMelsecLinks( )
		{
			InitializeComponent( );
			melsecSerial = new MelsecFxLinks( );
		}

		private MelsecFxLinks melsecSerial = null;

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
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";

				label1.Text = "parity:";
				label3.Text = "Stop bits";
				label27.Text = "Com:";
				label26.Text = "BaudRate";
				label25.Text = "Data bits";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Start Plc";
				button4.Text = "Stop Plc";
				label21.Text = "Address:";

				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";


				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";

				button3.Text = "Start";
				button4.Text = "Stop";
				button5.Text = "Plc Type";

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
			

			melsecSerial?.Close( );
			melsecSerial = new MelsecFxLinks( );
			
			try
			{
				melsecSerial.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				melsecSerial.Station = byte.Parse( textBox15.Text );
				melsecSerial.WaittingTime = byte.Parse( textBox18.Text );
				melsecSerial.SumCheck = checkBox1.Checked;


				melsecSerial.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteOp1.SetReadWriteNet( melsecSerial, "D100", false );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			melsecSerial.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( melsecSerial, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = melsecSerial.ReadBase( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}


		#endregion
		
		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = melsecSerial.ReadBool( "M100", 10 );
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
			short d100_short = melsecSerial.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsecSerial.ReadUInt16( "D100" ).Content;
			int d100_int = melsecSerial.ReadInt32( "D100" ).Content;
			uint d100_uint = melsecSerial.ReadUInt32( "D100" ).Content;
			long d100_long = melsecSerial.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsecSerial.ReadUInt64( "D100" ).Content;
			float d100_float = melsecSerial.ReadFloat( "D100" ).Content;
			double d100_double = melsecSerial.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsecSerial.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			melsecSerial.Write( "D100", (short)5 );
			melsecSerial.Write( "D100", (ushort)5 );
			melsecSerial.Write( "D100", 5 );
			melsecSerial.Write( "D100", (uint)5 );
			melsecSerial.Write( "D100", (long)5 );
			melsecSerial.Write( "D100", (ulong)5 );
			melsecSerial.Write( "D100", 5f );
			melsecSerial.Write( "D100", 5d );
			// length should Multiples of 2 
			melsecSerial.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = melsecSerial.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = melsecSerial.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsecSerial.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsecSerial.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = melsecSerial.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsecSerial.WriteCustomer( "D100", new UserType( ) );

			melsecSerial.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

		}

		// private MelsecMcAsciiNet melsec_ascii_net = null;

		#endregion

		#region 压力测试

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		// 压力测试，开3个线程，每个线程进行读写操作，看使用时间
		private void button3_Click( object sender, EventArgs e )
		{
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
			new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
			new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
			button3.Enabled = false;
		}

		private void thread_test2( )
		{
			int count = 500;
			while (count > 0)
			{
				if (!melsecSerial.Write( "D100", (short)1234 ).IsSuccess) failed++;
				if (!melsecSerial.ReadInt16( "D100" ).IsSuccess) failed++;
				count--;
			}
			thread_end( );
		}

		private void thread_end( )
		{
			if (Interlocked.Decrement( ref thread_status ) == 0)
			{
				// 执行完成
				Invoke( new Action( ( ) =>
				{
					button3.Enabled = true;
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}




		#endregion

		private void button3_Click_1( object sender, EventArgs e )
		{
			OperateResult operate = melsecSerial.StartPLC( );
			if(!operate.IsSuccess)
			{
				MessageBox.Show( "Start Failed：" + operate.Message );
			}
			else
			{
				MessageBox.Show( "Start Success" );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{

			OperateResult operate = melsecSerial.StopPLC( );
			if (!operate.IsSuccess)
			{
				MessageBox.Show( "Stop Failed：" + operate.Message );
			}
			else
			{
				MessageBox.Show( "Stop Success" );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = melsecSerial.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Read PLC Type failed:" + read.ToMessageShowString( ) );
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox18.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSumCheck, checkBox1.Checked );
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
			textBox18.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlSumCheck ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
