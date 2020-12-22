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
using HslCommunication;
using HslCommunication.Profinet.Yokogawa;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormYokogawaLinkTcp : HslFormContent
	{
		public FormYokogawaLinkTcp( )
		{
			InitializeComponent( );
			yokogawa = new YokogawaLinkTcp( );
			yokogawa.ConnectTimeOut = 2000;
		}


		private YokogawaLinkTcp yokogawa = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Yokogawa Read PLC Demo";

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

			if (!byte.TryParse( textBox16.Text, out byte cpu ))
			{
				MessageBox.Show( "Cpu Number input wrong！" );
				return;
			}
			
			yokogawa.IpAddress = textBox1.Text;
			yokogawa.Port = port;
			yokogawa.CpuNumber = cpu;

			OperateResult connect = yokogawa.ConnectServer( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteOp1.SetReadWriteNet( yokogawa, "D100", false );
			}
			else
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			yokogawa.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( yokogawa, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = yokogawa.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void groupBox5_Enter( object sender, EventArgs e )
		{

		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 随机bool读取
			OperateResult<bool[]> read = yokogawa.ReadRandomBool( textBox5.Text.Split( new char[] { ';' } ) );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToArrayString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 随机bool写入
			OperateResult write = yokogawa.WriteRandomBool( textBox5.Text.Split( new char[] { ';' } ), textBox4.Text.ToStringArray<bool>( ) );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success!"  );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + write.ToMessageShowString( ) );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 随机word读取
			OperateResult<short[]> read = yokogawa.ReadRandomInt16( textBox5.Text.Split( new char[] { ';' } ) );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToArrayString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 随机word写入
			OperateResult write = yokogawa.WriteRandom( textBox5.Text.Split( new char[] { ';' } ), textBox4.Text.ToStringArray<short>( ) );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success!" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + write.ToMessageShowString( ) );
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// start
			OperateResult start = yokogawa.Start( );
			if (start.IsSuccess) MessageBox.Show( "Started Success!" );
			else MessageBox.Show( "Started failed: " + start.ToMessageShowString( ) );
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// stop
			OperateResult stop = yokogawa.Stop( );
			if (stop.IsSuccess) MessageBox.Show( "Stop Success!" );
			else MessageBox.Show( "Stop failed: " + stop.ToMessageShowString( ) );
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// ProgramStatus
			OperateResult<int> read = yokogawa.ReadProgramStatus( );
			if (read.IsSuccess)
			{
				switch (read.Content)
				{
					case 1: textBox4.Text = "1 : RUN"; break;
					case 2: textBox4.Text = "2 : Stop"; break;
					case 3: textBox4.Text = "3 : Debug"; break;
					case 4: textBox4.Text = "4 : Rom writer"; break;
					default: textBox4.Text = read.Content.ToString( ); break;
				}
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// SystemInfo
			OperateResult<YokogawaSystemInfo> read = yokogawa.ReadSystemInfo( );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// DateTime
			OperateResult<DateTime> read = yokogawa.ReadDateTime( );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}
		}
	}
}
