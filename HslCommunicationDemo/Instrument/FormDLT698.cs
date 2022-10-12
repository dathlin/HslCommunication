using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.Instrument.DLT;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunication.Core;

namespace HslCommunicationDemo
{
	public partial class FormDLT698 : HslFormContent
	{
		public FormDLT698( )
		{
			InitializeComponent( );
		}

		private DLT698 dLT698 = null;

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
				Text = "DLT698 Read Demo";

				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label22.Text = "DataBit";
				label23.Text = "StopBit";
				label24.Text = "parity";
				label_address.Text = "station";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";

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

				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int baudRate ))
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

			dLT698?.Close( );
			dLT698 = new DLT698( textBox_station.Text );
			dLT698.LogNet = LogNet;
			dLT698.EnableCodeFE = checkBox_enable_Fe.Checked;

			try
			{
				dLT698.SerialPortInni( sp =>
				 {
					 sp.PortName = comboBox3.Text;
					 sp.BaudRate = baudRate;
					 sp.DataBits = dataBits;
					 sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					 sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				 } );
				dLT698.RtsEnable = checkBox5.Checked;
				dLT698.Open( );

				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteOp1.SetReadWriteNet( dLT698, "20-00-02-00", false );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			dLT698.Close( );
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
				OperateResult<byte[]> read = dLT698.Read( textBox6.Text, ushort.Parse( textBox9.Text ) );
				if (read.IsSuccess)
				{
					textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
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

		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			// 10 00 08 05 01 1E 20 01 02 00 00 01 10 11 22 33 44 55 66 77 88 99 00 AA BB CC DD EE FF 
			OperateResult<byte[]> read = dLT698.ReadByApdu( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult active = dLT698.ActiveDeveice( );
			if (active.IsSuccess)
			{
				MessageBox.Show( "Send Active Code Success" );
			}
			else
			{
				MessageBox.Show( "Active Code failed:" + active.Message );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = dLT698.ReadAddress( );
			if (read.IsSuccess)
			{
				textBox_station.Text = read.Content;
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Address:{read.Content}";
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 广播当前时间
			//OperateResult read = dLT645.BroadcastTime( DateTime.Now );
			//if (read.IsSuccess)
			//{
			//    textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] BroadcastTime Success";
			//}
			//else
			//{
			//    MessageBox.Show( "Read failed: " + read.Message );
			//}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 写通信地址
			OperateResult read = dLT698.WriteAddress( textBox1.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Write Success";
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = dLT698.ReadStringArray( textBox1.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Read Result: {Environment.NewLine}";
				if (read.Content != null)
				{
					foreach (string item in read.Content)
					{
						if (!string.IsNullOrEmpty(item))
						{
							textBox12.AppendText( item );
							textBox12.AppendText( Environment.NewLine );
						}
					}
				}
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button8_Click( object sender, EventArgs e )
		{
			//OperateResult<byte[]> buildConnect = dLT698.BuildConnect( );
			//if (!buildConnect.IsSuccess)
			//{
			//	MessageBox.Show( "Failed: " + buildConnect.Message );
			//}
			//else
			//{
			//	textBox10.Text = "Result：" + buildConnect.Content.ToHexString( );
			//}

		}
	}
}
