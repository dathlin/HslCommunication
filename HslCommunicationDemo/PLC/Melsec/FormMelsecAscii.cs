using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication.Profinet.Melsec;
using System.Threading;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormMelsecAscii : HslFormContent
	{
		public FormMelsecAscii( )
		{
			InitializeComponent( );
			melsec_net = new MelsecMcAsciiNet( );
		}


		private MelsecMcAsciiNet melsec_net = null;


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
				MessageBox.Show( connect.Message );
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
				if (!melsec_net.Write( "D100", (short)1234 ).IsSuccess) failed++;
				if (!melsec_net.ReadInt16( "D100" ).IsSuccess) failed++;
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
				MessageBox.Show( "Failed: " + runResult.ToMessageShowString( ) );
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

		private void button6_Click( object sender, EventArgs e )
		{
			// 读取型号
			OperateResult<string> readResult = melsec_net.ReadPlcType( );
			if (readResult.IsSuccess)
			{
				MessageBox.Show( "Type:" + readResult.Content );
			}
			else
			{
				MessageBox.Show( "Failed: " + readResult.ToMessageShowString( ) );
			}
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
}
