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
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo
{
	public partial class FormSiemensWebApi : HslFormContent
	{
		public FormSiemensWebApi( )
		{
			InitializeComponent( );
			siemensTcpNet = new SiemensWebApi( );
		}


		private SiemensWebApi siemensTcpNet = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

				button7.Text = "r-time";
				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";

				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button8.Text = "w-time";

				groupBox3.Text = "Bulk Read test";
				groupBox5.Text = "Special function test";

				button3.Text = "Order";
			}
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close
		
		private void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			siemensTcpNet.IpAddress = textBox1.Text;
			siemensTcpNet.Port = port;
			//siemensTcpNet.LocalBinding = new System.Net.IPEndPoint( System.Net.IPAddress.Parse( "127.0.0.1" ), 12345 );
			try
			{
				siemensTcpNet.UserName = textBox15.Text;
				siemensTcpNet.Password = textBox16.Text;

				OperateResult connect = siemensTcpNet.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet( siemensTcpNet, "\"全局DB\".Static_14", false );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message );
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
			siemensTcpNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		#region 单数据读取测试


		private async void Button7_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		#endregion

		#region 单数据写入测试

		private async void Button8_Click( object sender, EventArgs e )
		{
			// time写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
		}


		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult<byte[]> read = siemensTcpNet.Read( textBox6.Text, 0 );
				if (read.IsSuccess)
				{
					textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Read Failed：" + ex.Message );
			}
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			// 批量读取
			OperateResult<JToken[]> read = await siemensTcpNet.ReadAsync( textBox6.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ) );

			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
			else
			{
				JArray json = new JArray( );
				for (int i = 0; i < read.Content.Length; i++)
				{
					json.Add( read.Content[i] );

				}
				textBox10.Text = json.ToString( );

			}
		}

		#endregion

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private long successCount = 0;
		private System.Windows.Forms.Timer timer;


		private void button9_Click( object sender, EventArgs e )
		{
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
			new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
			new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
			button9.Enabled = false;

			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			label2.Text = successCount.ToString( );
		}

		private async void thread_test1( )
		{
			int count = 100000;
			while (count > 0)
			{
				if (!(await siemensTcpNet.WriteAsync( "M100", (short)1234 )).IsSuccess) failed++;
				if (!(await siemensTcpNet.ReadInt16Async( "M100" ) ).IsSuccess) failed++;
				count--;
				successCount++;
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
					label2.Text = successCount.ToString( );
					timer.Stop( );
					button9.Enabled = true;
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}



		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox16.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			OperateResult<double> read = await siemensTcpNet.ReadVersionAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( read.Content.ToString( ) );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			OperateResult read = await siemensTcpNet.ReadPingAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Ping Success" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}
	}
}
