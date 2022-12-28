using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.MQTT;

namespace HslCommunicationDemo
{
	public partial class FormSerialDebug : HslFormContent
	{
		public FormSerialDebug( )
		{
			InitializeComponent( );
		}

		private void FormSerialDebug_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.SelectedIndex = 0;

			comboBox2.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox2.SelectedIndex = 0;
			}
			catch
			{
				comboBox2.Text = "COM3";
			}

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "串口调试助手";
				label1.Text = "Com口：";
				label3.Text = "波特率:";
				label22.Text = "数据位:";
				label23.Text = "停止位:";
				label24.Text = "奇偶：";
				button1.Text = "打开串口";
				button2.Text = "关闭串口";
				label6.Text = "数据发送区：";
				label7.Text = "数据接收区：";
				checkBox_send_show.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button_send.Text = "发送数据";
				comboBox1.DataSource = new string[] { "无", "奇", "偶" };
			}
			else
			{
				Text = "Serial Debug Tools";
				label1.Text = "Com:";
				label3.Text = "Baud rate:";
				label22.Text = "Data bits:";
				label23.Text = "Stop bits:";
				label24.Text = "parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label6.Text = "Data sending Area:";
				label7.Text = "Data receiving Area:";
				checkBox_send_show.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button_send.Text = "Send Data";
				label8.Text = "Number of data bytes selected:";
				checkBox_stop_show.Text = "Stop Show";
				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		// 01 10 00 64 00 10 20 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00 0B 00 0C 00 0D 00 0E 00 0F



		#region Private Member

		private SerialPort SP_ReadData = null;                    // 串口交互的核心

		#endregion

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int baudRate ))
			{
				MessageBox.Show( Program.Language == 1 ? "波特率输入错误！" : "Baud rate input error" );
				return;
			}

			if (!int.TryParse( textBox16.Text, out int dataBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "数据位输入错误！" : "Data bits input error" );
				return;
			}

			if (!int.TryParse( textBox17.Text, out int stopBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "停止位输入错误！" : "Stop bits input error" );
				return;
			}

			if (checkBox6.Checked)
			{
				mqttClient?.ConnectClose( );
				mqttClient = new MqttClient( new MqttConnectionOptions( )
				{
					IpAddress = textBox8.Text,
					Port = int.Parse( textBox7.Text ),
					Credentials = new MqttCredential( textBox10.Text, textBox9.Text ),
					ConnectTimeout = 3000,
				} );
				OperateResult connect = mqttClient.ConnectServer( );
				if (!connect.IsSuccess)
				{
					MessageBox.Show( "MQTT Connected failed, not use it" );
					mqttClient = null;
				}
			}


			SP_ReadData = new SerialPort( );
			SP_ReadData.PortName = comboBox2.Text;
			SP_ReadData.BaudRate = baudRate;
			SP_ReadData.DataBits = dataBits;
			SP_ReadData.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
			SP_ReadData.Parity = comboBox1.SelectedIndex == 0 ? Parity.None : (comboBox1.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
			SP_ReadData.RtsEnable = checkBox5.Checked;

			try
			{
				SP_ReadData.DataReceived += SP_ReadData_DataReceived;
				SP_ReadData.Open( );
				button1.Enabled = false;
				button2.Enabled = true;

				panel2.Enabled = true;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}
		private void RadioButton_binary_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton_binary.Checked)
			{
				isBinary = true;
			}
			else
			{
				isBinary = false;
			}
		}
		private bool isBinary = true;
		/// <inheritdoc cref="GetTextHeader(int, string)"/>
		private string GetTextHeader( int code, byte[] info )
		{
			if (isBinary)
			{
				return GetTextHeader( code, SoftBasic.ByteToHexString( info, ' ' ) );
			}
			else
			{
				return GetTextHeader( code, SoftBasic.GetAsciiStringRender( info ) );
			}
		}

		/// <summary>
		/// code = 0 表示 收，code = 1 时表示 发, code = 2 时表示关闭
		/// </summary>
		/// <param name="code">操作代码</param>
		/// <param name="info">消息</param>
		/// <returns>打包后的字符串</returns>
		private string GetTextHeader( int code, string info )
		{
			string op = string.Empty;
			if (Program.Language == 1)
			{
				op = code == 0 ? "收" : code == 1 ? "发" : code == 2 ? "关" : "None";
			}
			else
			{
				op = code == 0 ? "Recv" : code == 1 ? "Send" : code == 2 ? "Clos" : "None";
			}

			StringBuilder sb = new StringBuilder( );
			if (checkBox_show_time.Checked)
			{
				sb.Append( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " );
			}

			sb.Append( $"[{op}]   " );
			sb.Append( info );
			sb.AppendLine( );
			return sb.ToString( );
		}

		private void SP_ReadData_DataReceived( object sender, SerialDataReceivedEventArgs e )
		{
			// 接收数据
			List<byte> buffer = new List<byte>( );
			byte[] data = new byte[1024];
			while (true)
			{
				System.Threading.Thread.Sleep( 20 );
				if(SP_ReadData.BytesToRead < 1)
				{
					break;
				}

				int recCount = SP_ReadData.Read( data, 0, Math.Min( SP_ReadData.BytesToRead, data.Length ) );

				byte[] buffer2 = new byte[recCount];
				Array.Copy( data, 0, buffer2, 0, recCount );
				buffer.AddRange( buffer2 );
			}

			if (buffer.Count == 0) return;

			mqttClient?.PublishMessage( new MqttApplicationMessage( )
			{
				Topic = textBox1.Text,
				Payload = buffer.ToArray( ),
			} );

			Invoke( new Action( ( ) =>
			 {
				 if (!checkBox_stop_show.Checked) textBox6.AppendText( GetTextHeader( 0, buffer.ToArray( ) ) );
				 if (checkBox_auto_return.Checked) button_send.PerformClick( );
			 } ) );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 发送数据
			byte[] send = isBinary ? SoftBasic.HexStringToBytes( textBox5.Text ) : SoftBasic.GetFromAsciiStringRender( textBox5.Text );

			if      (radioButton_append_0d.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { 0x0D } );
			else if (radioButton_append_0a.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { 0x0A } );
			else if (radioButton_append_0d0a.Checked)  send = SoftBasic.SpliceArray( send, new byte[] { 0x0D, 0x0A } );
			else if (radioButton_append_crc16.Checked) send = HslCommunication.Serial.SoftCRC16.CRC16( send );

			if (send == null) return;
			try
			{
				SP_ReadData?.Write( send, 0, send.Length );
				if(checkBox_send_show.Checked) textBox6.AppendText( GetTextHeader( 1, send ) );                         // 显示发送
			}
			catch (Exception ex)
			{
				// 发送失败的逻辑
				SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void textBox5_KeyDown( object sender, KeyEventArgs e )
		{
			// 按下 ENTER 键的时候自动发送
			if(e.KeyCode == Keys.Enter)
			{
				button_send.PerformClick( );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 关闭串口
			try
			{
				SP_ReadData.Close( );
				button2.Enabled = false;
				button1.Enabled = true;

				panel2.Enabled = false;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		#region Toledo Test

		private void button6_Click( object sender, EventArgs e )
		{
			if (button6.BackColor != Color.Green)
			{
				toledoThread = true;
				button6.BackColor = Color.Green;
				new System.Threading.Thread( new System.Threading.ThreadStart( ToledoTest ) ) { IsBackground = true }.Start( );
			}
			else
			{
				toledoThread = false;
				button6.BackColor = SystemColors.Control;
			}
		}

		private bool toledoThread = false;
		private Random random = new Random( );
		private float toledoWeight = 30f;
		private MqttClient mqttClient;

		private void ToledoTest( )
		{
			while (toledoThread)
			{
				System.Threading.Thread.Sleep( 50 );

				byte[] send = "02 2C 30 20 20 20 33 38 36 32 20 20 20 30 30 30 0D".ToHexBytes( );
				toledoWeight += random.Next( 200 ) / 100f - 1;
				if (toledoWeight < 0) toledoWeight = 5f;
				if (toledoWeight > 100) toledoWeight = 95f;
				string tmp = toledoWeight.ToString( "F2" ).Replace( ".", "" ).PadLeft( 6, ' ' );
				Encoding.ASCII.GetBytes( tmp ).CopyTo( send, 4 );

				try
				{
					SP_ReadData?.Write( send, 0, send.Length );
				}
				catch (Exception ex)
				{
					HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
					return;
				}
			}
		}

		#endregion

	}
}
