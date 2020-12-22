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

namespace HslCommunicationDemo
{
	public partial class FormMelsec3COverTcp : HslFormContent
	{
		public FormMelsec3COverTcp( )
		{
			InitializeComponent( );
			melsecA3C = new MelsecA3CNet1OverTcp( );
		}


		private MelsecA3CNet1OverTcp melsecA3C = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";

				label27.Text = "Ip:";
				label26.Text = "Port:";
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

			melsecA3C?.ConnectClose( );
			melsecA3C = new MelsecA3CNet1OverTcp( );
			melsecA3C.IpAddress = textBox1.Text;
			melsecA3C.Port = port;

			try
			{
				melsecA3C.Station = byte.Parse( textBox15.Text );

				OperateResult connect = melsecA3C.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet( melsecA3C, "D100", true );
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
			melsecA3C.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}



		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( melsecA3C, textBox6, textBox9, textBox10 );
		}


		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = melsecA3C.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
		
		#region Use Exmaple

		private void test1()
		{
			// 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

			// if we want read M100-M109, so we can do like this
			OperateResult<bool[]> read = melsecA3C.ReadBool( "M100", 10 );
			if (read.IsSuccess)
			{
				bool m100 = read.Content[0];
				// and so on
				// ...
				// then
				bool m109 = read.Content[9];
			}
			else
			{
				// failed, the follow operation is output the wrong msg
				Console.WriteLine( "Read failed: " + read.ToMessageShowString( ) );
			}
		}

		private void test2()
		{
			// the next we want write data
			bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
			OperateResult read = melsecA3C.Write( "M100", values );
			if (read.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
			}
		}


		private void test3()
		{
			// These are the underlying operations that ignore validation of success
			short d100_short = melsecA3C.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsecA3C.ReadUInt16( "D100" ).Content;
			int d100_int = melsecA3C.ReadInt32( "D100" ).Content;
			uint d100_uint = melsecA3C.ReadUInt32( "D100" ).Content;
			long d100_long = melsecA3C.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsecA3C.ReadUInt64( "D100" ).Content;
			float d100_float = melsecA3C.ReadFloat( "D100" ).Content;
			double d100_double = melsecA3C.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsecA3C.ReadString( "D100", 10 ).Content;
		}
		private void test4()
		{
			// These are the underlying operations that ignore validation of success
			melsecA3C.Write( "D100", (short)5 );
			melsecA3C.Write( "D100", (ushort)5 );
			melsecA3C.Write( "D100", 5 );
			melsecA3C.Write( "D100", (uint)5 );
			melsecA3C.Write( "D100", (long)5 );
			melsecA3C.Write( "D100", (ulong)5 );
			melsecA3C.Write( "D100", 5f );
			melsecA3C.Write( "D100", 5d );
			// length should Multiples of 2 
			melsecA3C.Write( "D100", "12345678" );
		}


		private void test5()
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = melsecA3C.Read( "D100", 10 );
			if (read.IsSuccess)
			{
				int count = melsecA3C.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsecA3C.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsecA3C.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6()
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = melsecA3C.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsecA3C.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			melsecA3C.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}

		#endregion

		private void button3_Click_1( object sender, EventArgs e )
		{
			//OperateResult operate = melsecA3C.StartPLC( );
			//if(!operate.IsSuccess)
			//{
			//    MessageBox.Show( "启动失败：" + operate.Message );
			//}
			//else
			//{
			//    MessageBox.Show( "启动成功" );
			//}
		}

		private void button4_Click( object sender, EventArgs e )
		{

			//OperateResult operate = melsecA3C.StopPLC( );
			//if (!operate.IsSuccess)
			//{
			//    MessageBox.Show( "停止失败：" + operate.Message );
			//}
			//else
			//{
			//    MessageBox.Show( "停止成功" );
			//}
		}


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
