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
using HslCommunicationDemo.Control;

namespace HslCommunicationDemo
{
	public partial class FormMelsecBinary : HslFormContent
	{
		public FormMelsecBinary()
		{
			InitializeComponent( );
			melsec_net = new MelsecMcNet( );
		}


		private MelsecMcNet melsec_net = null;


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

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";

				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				button9.Text = "random";


				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";

				button3.Text = "Pressure test, r/w 3,000s";
				label22.Text = "M100 D100 X1A0 Y1A0";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			melsec_net.IpAddress = textBox1.Text;
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			melsec_net.Port = port;

			melsec_net.ConnectClose( );

			button1.Enabled = false;
			melsec_net.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = await melsec_net.ConnectServerAsync( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				userControlReadWriteOp1.SetReadWriteNet( melsec_net, "D100", true );
			}
			else
			{
				MessageBox.Show( connect.Message + Environment.NewLine + "ErrorCode: " + connect.ErrorCode );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			melsec_net.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( melsec_net, textBox6, textBox9, textBox10 );
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 批量随机读取
			// textBox9.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ).Select( m => ushort.Parse( m ) ).ToArray( )
			OperateResult<byte[]> read = melsec_net.ReadRandom(
				textBox6.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ),
				textBox9.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ).Select( m => ushort.Parse( m ) ).ToArray( ) );
			if (read.IsSuccess)
			{
				textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}

		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = melsec_net.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
			OperateResult<bool[]> read = melsec_net.ReadBool( "M100", 10 );
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

		private void test2( )
		{
			bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
			OperateResult read = melsec_net.Write( "M100", values );
			if (read.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
			}
		}


		private void test3( )
		{
			short d100_short = melsec_net.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsec_net.ReadUInt16( "D100" ).Content;
			int d100_int = melsec_net.ReadInt32( "D100" ).Content;
			uint d100_uint = melsec_net.ReadUInt32( "D100" ).Content;
			long d100_long = melsec_net.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsec_net.ReadUInt64( "D100" ).Content;
			float d100_float = melsec_net.ReadFloat( "D100" ).Content;
			double d100_double = melsec_net.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsec_net.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			melsec_net.Write( "D100", (short)5 );
			melsec_net.Write( "D100", (ushort)5 );
			melsec_net.Write( "D100", 5 );
			melsec_net.Write( "D100", (uint)5 );
			melsec_net.Write( "D100", (long)5 );
			melsec_net.Write( "D100", (ulong)5 );
			melsec_net.Write( "D100", 5f );
			melsec_net.Write( "D100", 5d );
			// length should Multiples of 2 
			melsec_net.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = melsec_net.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = melsec_net.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsec_net.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsec_net.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = melsec_net.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsec_net.WriteCustomer( "D100", new UserType( ) );

			melsec_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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

		private async void thread_test2( )
		{
			int count = 500;
			while (count > 0)
			{
				if (!(await melsec_net.WriteAsync( "D100", (short)1234 ) ).IsSuccess) failed++;
				if (!(await melsec_net.ReadInt16Async( "D100" ) ).IsSuccess) failed++;
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

		private void button4_Click( object sender, EventArgs e )
		{
			// 远程启动
			OperateResult runResult = melsec_net.RemoteRun( );
			if (runResult.IsSuccess)
			{
				MessageBox.Show( "Run Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + runResult.ToMessageShowString() );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 远程停止
			OperateResult runResult = melsec_net.RemoteStop( );
			if (runResult.IsSuccess)
			{
				MessageBox.Show( "Stop Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + runResult.ToMessageShowString( ) );
			}
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			// 读取型号
			button6.Enabled = false;
			OperateResult<string> readResult = await melsec_net.ReadPlcTypeAsync( );
			if (readResult.IsSuccess)
			{
				MessageBox.Show( "Type:" + readResult.Content );
			}
			else
			{
				MessageBox.Show( "Failed: " + readResult.ToMessageShowString( ) );
			}
			button6.Enabled = true;
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 远程重置
			OperateResult result = melsec_net.RemoteReset( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "RemoteReset Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.ToMessageShowString( ) );
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 错误灯恢复
			OperateResult result = melsec_net.ErrorStateReset( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "ErrorStateReset Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.ToMessageShowString( ) );
			}
		}

		private async void button10_Click( object sender, EventArgs e )
		{
			// 等待M100为True，读取频率为间隔100ms，等待超时为30秒
			button10.Enabled = false;
			OperateResult<TimeSpan> wait = await melsec_net.WaitAsync( "M100", true, 100, 30_000 );
			if (wait.IsSuccess)
			{
				MessageBox.Show( "Wait Success, Takes " + wait.Content.TotalSeconds.ToString( "F1" ) + " Seconds" );
			}
			else
			{
				MessageBox.Show( "Wait Failed:" + wait.Message );
			}
			button10.Enabled = true;
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// 等待D100为123，读取频率为间隔100ms，等待超时为30秒
			button11.Enabled = false;
			OperateResult<TimeSpan> wait = await melsec_net.WaitAsync( "D100", (short)123, 100, 30_000 );
			if (wait.IsSuccess)
			{
				MessageBox.Show( "Wait Success, Takes " + wait.Content.TotalSeconds.ToString( "F1" ) + " Seconds" );
			}
			else
			{
				MessageBox.Show( "Wait Failed:" + wait.Message );
			}
			button11.Enabled = true;
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}

	public class UserType : HslCommunication.IDataTransfer
	{
		#region IDataTransfer

		private HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.RegularByteTransform();


		public ushort ReadCount => 10;

		public void ParseSource( byte[] Content )
		{
			int count = ByteTransform.TransInt32( Content, 0 );
			float temp = ByteTransform.TransSingle( Content, 4 );
			short name1 = ByteTransform.TransInt16( Content, 8 );
			string barcode = Encoding.ASCII.GetString( Content, 10, 10 );
		}

		public byte[] ToSource( )
		{
			byte[] buffer = new byte[20];
			ByteTransform.TransByte( count ).CopyTo( buffer, 0 );
			ByteTransform.TransByte( temp ).CopyTo( buffer, 4 );
			ByteTransform.TransByte( name1 ).CopyTo( buffer, 8 );
			Encoding.ASCII.GetBytes( barcode ).CopyTo( buffer, 10 );
			return buffer;
		}


		#endregion


		#region Public Data

		public int count { get; set; }

		public float temp { get; set; }

		public short name1 { get; set; }

		public string barcode { get; set; }

		#endregion
	}
}
