using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.BasicFramework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo
{
	public partial class FormTcpDebug : HslFormContent
	{
		#region Form

		public FormTcpDebug( )
		{
			InitializeComponent( );

			connectHandShake = new List<byte[]>( );
		}

		private void FormTcpDebug_Load( object sender, EventArgs e )
		{
			panel_main.Enabled = false;
			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 500;
			timer.Tick += Timer_Tick;
			timer.Start( );

			Language( Program.Language );

			panel3.Paint += Panel3_Paint;
			panel4.Paint += Panel3_Paint;

			radioButton_binary.CheckedChanged += RadioButton_binary_CheckedChanged;
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

		private void Panel3_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1 ) );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text                    = "TCP/IP调试助手";
				label1.Text             = "Ip地址：";
				label3.Text             = "端口号：";
				button1.Text            = "连接";
				button2.Text            = "关闭连接";
				label6.Text             = "数据发送区：";
				label7.Text             = "数据收发显示：";
				checkBox_show_send.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button_send.Text        = "发送数据";
				label8.Text             = "已选择数据字节数：";
			}
			else
			{
				Text                    = "TCP/IP Debug Tools";
				label1.Text             = "Ip:";
				label3.Text             = "Port:";
				button1.Text            = "Connect";
				button2.Text            = "Disconnect";
				button4.Text            = "Build Message";
				label6.Text             = "Data sending Area:";
				label7.Text             = "Data sending and receiving display:";
				checkBox_show_send.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button_send.Text        = "Send Data";
				label8.Text             = "Number of data bytes selected:";
				checkBox_stop_show.Text = "Stop Show";
			}
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (!string.IsNullOrEmpty( textBox6.Text ))
			{
				string select = textBox6.SelectedText;
				if(!string.IsNullOrEmpty(select))
				{
					if (isBinary)
					{
						// 二进制
						byte[] bytes = SoftBasic.HexStringToBytes( select );
						label8.Text = (Program.Language == 1? "已选择数据字节数：" : "Number of data bytes selected:") + bytes.Length;
					}
					else
					{
						label8.Text = (Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:") + select.Length;
					}
				}
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			textBox6.Clear( );
		}

		private void button_edit_hand_Click( object sender, EventArgs e )
		{
			// 编辑握手包
			using (HslDebug.FormHandShake handShake = new HslDebug.FormHandShake( this.connectHandShake ))
			{
				if (handShake.ShowDialog( this ) == DialogResult.OK)
				{
					this.connectHandShake = handShake.HandShake;
					this.label4.Text = (Program.Language == 1 ? "握手包：" : "HandShanke: ") + handShake.HandShake?.Count;
				}
			}
		}

		#endregion

		#region Start Close

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接服务器
			try
			{
				socketCore?.Close( );
				System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse( HslCommunication.Core.HslHelper.GetIpAddressFromInput( textBox_ip.Text ) );
				if (radioButton_tcp.Checked)
				{
					socketCore = new Socket( iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp );
					connectSuccess = false;
					// 以下代码是5秒的超时
					new Thread( ( ) =>
					{
						Thread.Sleep( 5000 );
						if (!connectSuccess) socketCore?.Close( );
					} ).Start( );
					socketCore.Connect( iPAddress, int.Parse( textBox_port.Text ) );
					connectSuccess = true;

					// 如果有握手的报文
					if (this.connectHandShake.Count > 0)
					{
						for (int i = 0; i < this.connectHandShake.Count; i++)
						{
							// 发送
							SendData( this.connectHandShake[i] );
							// 接收
							int len = socketCore.Receive( buffer, 0, buffer.Length, SocketFlags.None );
							textBox6.AppendText( GetTextHeader( 0, buffer.SelectBegin( len ) ) );
						}
					}

					socketCore.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), socketCore );
				}
				else
				{
					// UDP的情况
					udpEndPoint = new IPEndPoint( iPAddress, int.Parse( textBox_port.Text ) );
					socketCore = new Socket( iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp );

					socketCore.SendTo( new byte[0], udpEndPoint );

					// 如果有握手的报文
					if (this.connectHandShake.Count > 0)
					{
						for (int i = 0; i < this.connectHandShake.Count; i++)
						{
							// 发送
							SendData( this.connectHandShake[i] );

							EndPoint Remote = (EndPoint)new IPEndPoint( udpEndPoint.AddressFamily == AddressFamily.InterNetworkV6 ? IPAddress.IPv6Any : IPAddress.Any, 0 );
							// 接收
							int len = socketCore.ReceiveFrom( buffer, 0, buffer.Length, SocketFlags.None, ref Remote );
							textBox6.AppendText( GetTextHeader( 0, buffer.SelectBegin( len ) ) );
						}
					}

					IsStarted = true;
					threadReceive = new System.Threading.Thread( new System.Threading.ThreadStart( ThreadReceiveUdpCycle ) ) { IsBackground = true };
					threadReceive.Start( );

				}

				button1.Enabled = false;
				button2.Enabled = true;
				panel_main.Enabled = true;
				panel_tcp_udp.Enabled = false;
				button_send.Enabled = true;

				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			catch(Exception ex)
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message );
			}
		}


		private void button2_Click( object sender, EventArgs e )
		{
			IsStarted = false;
			socketCore?.Close( );
			button1.Enabled = true;
			button2.Enabled = false;
			panel_tcp_udp.Enabled = true;
			button_send.Enabled = false;
		}

		#endregion


		/// <inheritdoc cref="GetTextHeader(int, string)"/>
		private string GetTextHeader( int code, byte[] info )
		{
			if (isBinary)
			{
				return GetTextHeader( checkBox_show_time.Checked, code, SoftBasic.ByteToHexString( info, ' ' ) );
			}
			else
			{
				return GetTextHeader( checkBox_show_time.Checked, code, SoftBasic.GetAsciiStringRender( info ) );
			}
		}

		/// <summary>
		/// code = 0 表示 收，code = 1 时表示 发, code = 2 时表示关闭
		/// </summary>
		/// <param name="timeShow">是否显示时间</param>
		/// <param name="code">操作代码</param>
		/// <param name="info">消息</param>
		/// <returns>打包后的字符串</returns>
		public static string GetTextHeader( bool timeShow, int code, string info )
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
			if (timeShow) sb.Append( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " );

			sb.Append( $"[{op}]   " );
			sb.Append( info );
			sb.AppendLine( );
			return sb.ToString( );
		}

		/// <summary>
		/// 后台接收数据的线程
		/// </summary>
		protected virtual void ThreadReceiveUdpCycle( )
		{
			IPEndPoint sender = new IPEndPoint( udpEndPoint.AddressFamily == AddressFamily.InterNetworkV6 ? IPAddress.IPv6Any : IPAddress.Any, 0 );
			EndPoint Remote = (EndPoint)sender;
			while (IsStarted)
			{
				int length = 0;
				try
				{
					length = socketCore.ReceiveFrom( buffer, 0, buffer.Length, SocketFlags.None, ref Remote );
					if (length > 0) Invoke( new Action( ( ) =>
					{
						if (!checkBox_stop_show.Checked) textBox6.AppendText( GetTextHeader( 0, buffer.SelectBegin( length ) ) );
					} ) );
				}
				catch (Exception ex)
				{
					Invoke( new Action( ( ) =>
					{
						textBox6.AppendText( (Program.Language == 1 ? "服务器断开连接。原因：" : "DisConnect from remote, reason: ") + ex.Message + Environment.NewLine );
					} ) );
				}
			}
		}

		private void ReceiveCallBack( IAsyncResult ar )
		{
			try
			{
				int length = socketCore.EndReceive( ar );
				byte[] data = new byte[length];
				if (length > 0) Array.Copy( buffer, 0, data, 0, length );

				socketCore.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), socketCore );

				if (length == 0)
				{
					// 大概率远程关闭了连接
					Invoke( new Action( ( ) =>
					{
						textBox6.AppendText( GetTextHeader( checkBox_show_time.Checked, 2, Program.Language == 1 ? "远程关闭连接" : "Remote closes connection" ) );
						socketCore?.Close( );
						button_send.Enabled = false;
						button1.Enabled     = true;
						button2.Enabled     = false;
					} ) );
					return;
				}

				Invoke( new Action( ( ) =>
				{
					if(!checkBox_stop_show.Checked) textBox6.AppendText( GetTextHeader( 0, data ) );
					if (checkBox_auto_return.Checked) button_send.PerformClick( );
				} ) );
			}
			catch(ObjectDisposedException)
			{
				Invoke( new Action( ( ) =>
				{
					textBox6.AppendText( GetTextHeader( checkBox_show_time.Checked, 2, Program.Language == 1 ? "客户端关闭连接" : "Client closes connection" ) );
					button_send.Enabled = false;
					button1.Enabled = true;
					button2.Enabled = false;
				} ) );
			}
			catch(Exception ex)
			{
				Invoke( new Action( ( ) =>
				{
					textBox6.AppendText( GetTextHeader( checkBox_show_time.Checked, 2, (Program.Language == 1 ? "服务器断开连接: " : "DisConnect from remote: ") + ex.Message ) );
					button_send.Enabled = false;
					button1.Enabled = true;
					button2.Enabled = false;
				} ) );
			}
		}

		private void SendData( byte[] send )
		{
			if (send == null) return;
			try
			{
				if (radioButton_tcp.Checked)
				{
					socketCore?.Send( send, 0, send.Length, SocketFlags.None );
				}
				else
				{
					socketCore?.SendTo( send, 0, send.Length, SocketFlags.None, udpEndPoint );
				}
				textBox6.AppendText( GetTextHeader( 1, send ) );                         // 显示发送
			}
			catch (Exception ex)
			{
				// 发送失败的逻辑
				SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 发送数据
			byte[] send = isBinary ? SoftBasic.HexStringToBytes( textBox5.Text ) : SoftBasic.GetFromAsciiStringRender( textBox5.Text );

			if      (radioButton_append_0d.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { 0x0D } );
			else if (radioButton_append_0a.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { 0x0A } );
			else if (radioButton_append_0d0a.Checked)  send = SoftBasic.SpliceArray( send, new byte[] { 0x0D, 0x0A } );
			else if (radioButton_append_crc16.Checked) send = HslCommunication.Serial.SoftCRC16.CRC16( send );

			SendData( send );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			using(HslDebug.FormMessageCreate form = new HslDebug.FormMessageCreate())
			{
				if ( form.ShowDialog() == DialogResult.OK)
				{
					if (form.MessageCreate != null)
					{
						if (form.MessageCreate.HexBinary)
							radioButton_binary.Checked = true;
						else
							radioButton_ascii.Checked = true;

						textBox5.Text = form.MessageCreate.Result;
					}
				}
			}
			//HslCommunication.Robot.EFORT.ER7BC10 eR7BC10 = new HslCommunication.Robot.EFORT.ER7BC10( "192.168.0.100",8008 );
			//textBox5.Text = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( eR7BC10.GetReadCommand( ), ' ' );
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

		private void ToledoTest( )
		{
			while (toledoThread)
			{
				System.Threading.Thread.Sleep( 30 );

				byte[] send = "02 2C 30 20 20 20 33 38 36 32 20 20 20 30 30 30 0D".ToHexBytes( );
				toledoWeight += random.Next( 200 ) / 100f - 1;
				if (toledoWeight < 0) toledoWeight = 5f;
				if (toledoWeight > 100) toledoWeight = 95f;
				string tmp = toledoWeight.ToString( "F2" ).Replace( ".", "" ).PadLeft( 6, ' ' );
				Encoding.ASCII.GetBytes( tmp ).CopyTo( send, 4 );

				try
				{
					socketCore?.Send( send, 0, send.Length, SocketFlags.None );
				}
				catch (Exception ex)
				{
					HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
					return;
				}
			}
		}

		#endregion

		#region Private Member

		private Socket socketCore = null;
		private bool connectSuccess = false;
		private byte[] buffer = new byte[2048];
		private System.Windows.Forms.Timer timer;
		private List<byte[]> connectHandShake;
		private EndPoint udpEndPoint = null;
		private System.Threading.Thread threadReceive;
		private bool IsStarted = false;

		private bool isBinary = true;
		private bool toledoThread = false;
		private Random random = new Random( );
		private float toledoWeight = 30f;


		#endregion
	}
}
