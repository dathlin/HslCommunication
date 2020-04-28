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
using HslCommunication.Profinet.Freedom;
using HslCommunication;
using System.IO.Ports;

namespace HslCommunicationDemo
{
	public partial class FormFreedomSerial : HslFormContent
	{
		public FormFreedomSerial( )
		{
			InitializeComponent( );
			freedom = new FreedomSerial( );
		}


		private FreedomSerial freedom = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );

			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (freedom != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Free protocol access based on serial port";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";


				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接

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

			freedom?.Close( );
			freedom = new FreedomSerial( );


			if (radioButton1.Checked) freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );
			if (radioButton2.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );
			if (radioButton3.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseWordTransform( );
			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );

			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;
			freedom.SerialPortInni( sp =>
			{
				sp.PortName = comboBox3.Text;
				sp.BaudRate = baudRate;
				sp.DataBits = dataBits;
				sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
				sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
			} );
			freedom.RtsEnable = checkBox5.Checked;

			button1.Enabled = false;
			OperateResult open = freedom.Open( );
			if (open.IsSuccess)
			{
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				userControlReadWriteOp1.SetReadWriteNet( freedom, "", true );
			}
			else
			{
				MessageBox.Show( open.Message );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			freedom.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = freedom.Read( textBox6.Text, 0 );
			if (read.IsSuccess)
			{
				textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
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
			OperateResult<byte[]> read = freedom.ReadBase( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}

		#endregion
		

	}

}
