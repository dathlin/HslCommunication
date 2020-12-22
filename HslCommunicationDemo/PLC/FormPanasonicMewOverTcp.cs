using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Panasonic;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormPanasonicMewOverTcp : HslFormContent
	{
		public FormPanasonicMewOverTcp( )
		{
			InitializeComponent( );
		}


		private PanasonicMewtocolOverTcp panasonicMewtocol = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;


			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Panasonic Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				label21.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

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

				button3.Text = "Pressure test, r/w 3,000s";

			}
		}



		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			if (!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "Plc Station input wrong!" );
				return;
			}

			panasonicMewtocol?.ConnectClose( );
			panasonicMewtocol = new PanasonicMewtocolOverTcp( station );
			panasonicMewtocol.IpAddress = textBox1.Text;
			panasonicMewtocol.Port = port;


			try
			{
				OperateResult connect = panasonicMewtocol.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet( panasonicMewtocol, "R0", true );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			panasonicMewtocol.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult<byte[]> read = panasonicMewtocol.Read( textBox6.Text , ushort.Parse( textBox9.Text ) );
				if (read.IsSuccess)
				{
					textBox10.Text = "结果：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					MessageBox.Show( "读取失败：" + read.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "读取失败：" + ex.Message );
			}
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult<byte[]> read = panasonicMewtocol.ReadFromCoreServer( HslCommunication.Serial.SoftCRC16.CRC16(HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text )) );
				if (read.IsSuccess)
				{
					textBox11.Text = "结果：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					MessageBox.Show( "读取失败：" + read.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "读取失败：" + ex.Message );
			}
		}


		#endregion
		
		#region 压力测试

		private void button4_Click( object sender, EventArgs e )
		{
			PressureTest2( );
		}

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		// 压力测试，开3个线程，每个线程进行读写操作，看使用时间
		private void PressureTest2( )
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
				if (!panasonicMewtocol.Write( "100", (short)1234 ).IsSuccess) failed++;
				if (!panasonicMewtocol.ReadInt16( "100" ).IsSuccess) failed++;
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
					MessageBox.Show( "耗时：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + "失败次数：" + failed );
				} ) );
			}
		}
		
		#endregion

		#region Test Function
		
		private void Test1()
		{
			OperateResult<bool[]> read = panasonicMewtocol.ReadBool( "100", 10 );
			if(read.IsSuccess)
			{
				bool coil_100 = read.Content[0];
				// and so on 
				bool coil_109 = read.Content[9];
			}
			else
			{
				// failed
				string err = read.Message;
			}
		}


		private void Test2()
		{
			bool[] values = new bool[] { true, false, false, false, true, true, false, true, false, false };
			OperateResult write = panasonicMewtocol.Write( "100", values );
			if (write.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
				string err = write.Message;
			}

			HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseWordTransform( );
		}


		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
