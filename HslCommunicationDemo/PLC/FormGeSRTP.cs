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
using HslCommunication.Profinet.GE;
using HslCommunication;
using HslCommunicationDemo.Control;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormGeSRTP : HslFormContent
	{
		public FormGeSRTP( )
		{
			InitializeComponent( );
		}


		private GeSRTPNet ge = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
			textBox13.Text = "02 00 5f 06 00 00 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 06 c0 00 00 00 00 10 0e 00 00 01 01 04 08 00 00 01 00 00 00 00 00 00 00 00 00";
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

		
		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			ge?.ConnectClose( );
			ge = new GeSRTPNet( textBox1.Text, port );

			try
			{
				OperateResult connect = ge.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet( ge, "R1", true );
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
			ge.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		
		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( ge, textBox6, textBox9, textBox10 );
		}

		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = ge.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = DateTime.Now.ToString("HH:mm:ss") + "：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}


		#endregion
		
		#region 压力测试

		private void button3_Click( object sender, EventArgs e )
		{
			// 读取PLC的时间
			OperateResult<DateTime> read = ge.ReadPLCTime( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.ToMessageShowString( ) );
			}
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			// 读取PLC的程序名
			OperateResult<string> read = await ge.ReadProgramNameAsync( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.ToMessageShowString( ) );
			}
		}
		#endregion

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
