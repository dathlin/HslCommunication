using HslCommunication.BasicFramework;
using HslCommunication.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HslCommunicationDemo.HslDebug
{
	public partial class DebugControl : UserControl
	{
		public DebugControl( )
		{
			InitializeComponent( );
			packetMessages = new List<PacketMessageItem>( );
			sessions = new List<SocketDebugSession>( );

			Disposed += DebugControl_Disposed;

			panel4.Paint += Panel3_Paint;
			panel5.Paint += Panel3_Paint;

			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			button_send.Click += button_send_Click;
			linkLabel_build_message.Click += button_build_message_Click;

			checkBox_send_cycle.CheckedChanged += CheckBox_send_cycle_CheckedChanged;
			listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
		}

		private void DebugControl_Disposed( object sender, EventArgs e )
		{
			if (checkBox_send_cycle.Checked) checkBox_send_cycle.Checked = false;

			timer?.Dispose( );

		}

		#region Form Load

		private void DebugControl_Load( object sender, EventArgs e )
		{
			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 500;
			timer.Tick += Timer_Tick;
			timer.Start( );

			List<string> strings = new List<string>( );
			strings.Add( "Binary" );
			strings.AddRange( DemoUtils.GetEncodings( ) );


			comboBox_encoding.DataSource = strings.ToArray( );
			comboBox_encoding.SelectedIndex = 0;
			// 中英文设置
			if (Program.Language == 1)
			{
				label6.Text = "发送:";
				label7.Text = "数据收发显示：";
				checkBox_show_send.Text = "是否显示发送数据";
				button_send.Text = "发送数据";
				label8.Text = "已选择字节数：";
			}
			else
			{
				linkLabel_build_message.Text = "Build Msg";
				label6.Text = "Send:";
				label7.Text = "Data Send/Receive display:";
				checkBox_show_send.Text = "Display send data";
				button_send.Text = "Send Data";
				label8.Text = "Bytes selected:";
				checkBox_stop_show.Text = "Stop Show";
				checkBox_auto_return.Text = "Auto Ret";
				button5.Text = "Clear";
				checkBox_show_header.Text = "Display message header?";
				label3.Text = "Msg(d-click)";
				checkBox_send_cycle.Text = "Cycle";
				radioButton_send_text.Text = "SendText";
				radioButton_send_cycle.Text = "SendList";
				radioButton_send_single.Text = "Single";
				radioButton_send_all.Text = "All";
				textBox_send_info.Text = "<sleep=100> Single line can split and delay send";
			}
			linkLabel1.Text = string.Format( GetLinkLabelPacketMessageText( ), 0 );
			this.label_session_count.Text = string.Format( GetSessionCountText( ), this.sessions.Count );

			richTextBox_main.ScrollToCaret( );
		}

		private void ListBox1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			if (listBox1.SelectedItem is PacketMessageItem messageItem)
			{
				textBox5.Text = messageItem.Message;
			}
		}

		private void CheckBox_send_cycle_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox_send_cycle.Checked)
			{
				if (!int.TryParse(textBox_send_intenal.Text, out int time ))
				{
					MessageBox.Show( "The interval input is abnormal and requires the input of numeric text" );
					return;
				}

				// 开启定时发送
				sendtimer?.Dispose( );
				sendtimer = new System.Windows.Forms.Timer( );
				sendtimer.Interval = time;
				sendtimer.Tick += Sendtimer_Tick; 
				sendtimer.Start( );
			}
			else
			{
				// 停止定时发送
				sendtimer?.Stop( );
				sendtimer?.Dispose( );
			}
		}
		
		private void Sendtimer_Tick( object sender, EventArgs e )
		{
			if (radioButton_send_cycle.Checked)
			{
				if (this.packetMessages == null || this.packetMessages.Count == 0) return;

				if (listIndex >= this.packetMessages.Count)
				{
					listIndex = 0;
				}
				textBox5.Text = this.packetMessages[listIndex].Message;
				listIndex++;
			}

			button_send.PerformClick( );
		}

		private void Panel3_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1 ) );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (!string.IsNullOrEmpty( richTextBox_main.Text ))
			{
				string select = richTextBox_main.SelectedText;
				if (!string.IsNullOrEmpty( select ))
				{
					if (comboBox_encoding.SelectedIndex == 0)
					{
						// 二进制
						byte[] bytes = SoftBasic.HexStringToBytes( select );
						label8.Text = (Program.Language == 1 ? "已选择字节数：" : "Bytes selected:") + bytes.Length;
					}
					else
					{
						label8.Text = (Program.Language == 1 ? "已选择字节数：" : "Bytes selected:") + select.Length;
					}
				}
			}
		}


		private void button_clear_Click( object sender, EventArgs e )
		{
			richTextBox_main.Clear( );
			Interlocked.Exchange( ref sendCount, 0 );
			Interlocked.Exchange( ref recvCount, 0 );
			label_send_count.Text = "Send Count: " + sendCount;
			label_recv_count.Text = "Recv Count: " + recvCount;
		}

		private void button_build_message_Click( object sender, EventArgs e )
		{
			using (HslDebug.FormMessageCreate form = new HslDebug.FormMessageCreate( ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					if (form.MessageCreate != null)
					{
						if (form.MessageCreate.HexBinary)
							comboBox_encoding.SelectedIndex = 0;
						else
							comboBox_encoding.SelectedIndex = 1;

						textBox5.Text = form.MessageCreate.Result;
					}
				}
			}
			//HslCommunication.Robot.EFORT.ER7BC10 eR7BC10 = new HslCommunication.Robot.EFORT.ER7BC10( "192.168.0.100",8008 );
			//textBox5.Text = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( eR7BC10.GetReadCommand( ), ' ' );
		}


		#endregion

		private string GetLinkLabelPacketMessageText( )
		{
			return Program.Language == 1 ? "管理({0})" : "Set({0})";
		}
		private string GetSessionCountText( )
		{
			return Program.Language == 1 ? "会话数量: {0}" : "Onlines: {0}";
		}

		private void RenderMessage( int code, string msg )
		{
			if (!string.IsNullOrEmpty( msg ))
			{
				int index = richTextBox_main.Text.Length;
				richTextBox_main.AppendText( msg );
				richTextBox_main.Select( index, msg.Length );
				if (code < 0)
					richTextBox_main.SelectionColor = Color.Gray;
				else if (code == 0)
					richTextBox_main.SelectionColor = Color.Green;
				else if (code == 1)
					richTextBox_main.SelectionColor = Color.Blue;
				else if (code == 4)
					richTextBox_main.SelectionColor = Color.Purple;
				else
					richTextBox_main.SelectionColor = Color.Red;
				richTextBox_main.AppendText( Environment.NewLine );
			}
		}



		/// <summary>
		/// code = 0 表示 收，code = 1 时表示 发, code = 2 时表示关闭, code = 3 时上线， code = 4: DTU相关
		/// </summary>
		/// <param name="session">会话信息</param>
		/// <param name="code">代号</param>
		/// <param name="data">数据</param>
		/// <param name="head">额外的头信息</param>
		public void RenderSendReceiveContent( SocketDebugSession session, int code, byte[] data, string msg = null, string head = null )
		{
			if (checkBox_stop_show.Checked) return;
			if (code == 1)
			{
				if (!checkBox_show_send.Checked) return;
			}


			if (checkBox_show_header.Checked)
			{
				string header = GetTextHeader( session, code, data == null ? -1 : data.Length, head );
				RenderMessage( -1, header );
			}

			if (data != null)
			{
				if (code == 1)
				{
					Interlocked.Add( ref sendCount, data.Length );
					label_send_count.Text = "Send Count: " + sendCount;
				}
				else if (code == 0)
				{
					Interlocked.Add( ref recvCount, data.Length );
					label_recv_count.Text = "Recv Count: " + recvCount;
				}
				string content = null;
				if (comboBox_encoding.SelectedIndex == 0) content = SoftBasic.ByteToHexString( data, ' ' );
				else if (comboBox_encoding.SelectedIndex == 1) content = SoftBasic.GetAsciiStringRender( data );
				else content = DemoUtils.GetEncodingFromIndex( comboBox_encoding.SelectedIndex - 1 ).GetString( data );
				RenderMessage( code, content );
			}

			if (!string.IsNullOrEmpty( msg ))
			{
				RenderMessage( code, msg );
			}

			richTextBox_main.ScrollToCaret( );

			if (code == 0)
			{
				if (checkBox_auto_return.Checked) button_send.PerformClick( );
			}
			else if (code == 2)
			{
				// 发生了关闭的操作
				RemoveSessions( session );
			}
		}

		/// <summary>
		/// code = 0 表示 收，code = 1 时表示 发, code = 2 时表示关闭, code = 3 时上线， code = 4: DTU相关
		/// </summary>
		/// <param name="session">目标的节点信息</param>
		/// <param name="code">操作代码</param>
		/// <param name="length">消息的长度信息</param>
		/// <returns>打包后的字符串</returns>
		private static string GetTextHeader( SocketDebugSession session, int code, int length, string head = null )
		{
			string op = string.Empty;
			if (Program.Language == 1)
			{
				op = code == 0 ? "收" : code == 1 ? "发" : code == 2 ? "关" : code == 3 ? "上线" : code == 4 ? "DTU" : "无";
			}
			else
			{
				op = code == 0 ? "Recv" : code == 1 ? "Send" : code == 2 ? "Clos" : code == 3 ? "Online" : code == 4 ? "DTU" : "None";
			}

			StringBuilder sb = new StringBuilder( );
			sb.Append( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " );

			if (session != null)
			{
				if (session.UseMode < 2)
				{
					if (code == 0)
					{
						sb.Append( $"[{op} {session.RemoteEndPoint} To {session.LocalEndPoint}]" );
					}
					else if (code == 1)
					{
						sb.Append( $"[{op} {session.LocalEndPoint} To {session.RemoteEndPoint}]" );
					}
					else
					{
						sb.Append( $"[{op} {session.RemoteEndPoint}]" );
					}
				}
				else if (session.UseMode == 2)
				{
					if (code == 0)
					{
						sb.Append( $"[{op} From {session.PortName}]" );
					}
					else if (code == 1)
					{
						sb.Append( $"[{op} To {session.PortName}]" );
					}
					else
					{
						sb.Append( $"[{op} {session.PortName}]" );
					}
				}
			}
			else
			{
				if (!string.IsNullOrEmpty( head ))
					sb.Append( $"[{head}]" );
			}

			if (length >= 0) sb.Append( $"  Bytes Length: {length}" );
			return sb.ToString( );
		}

		#region Session Managment

		public void SetSessions( List<SocketDebugSession> sessions )
		{
			if (sessions == null) sessions = new List<SocketDebugSession>( );
			this.sessions = sessions;

			this.comboBox_sessions.DataSource = this.sessions.ToArray( );
			this.label_session_count.Text = string.Format( GetSessionCountText( ), this.sessions.Count );
		}

		/// <summary>
		/// 新增一个会话信息
		/// </summary>
		/// <param name="session">会话信息</param>
		public void AddSessions( SocketDebugSession session )
		{
			if (session == null) return;
			this.sessions.Add( session );

			// 提醒上线
			string header = GetTextHeader( session, 3,  -1  );
			RenderMessage( -1, header );

			this.comboBox_sessions.DataSource = this.sessions.ToArray( );
			this.label_session_count.Text = string.Format( GetSessionCountText( ), this.sessions.Count );
		}

		/// <summary>
		/// 移除一个会话信息
		/// </summary>
		/// <param name="session">会话信息</param>
		public void RemoveSessions( SocketDebugSession session )
		{
			if (session == null) return;
			if( this.sessions.RemoveAll( m => m.SessionID == session.SessionID ) == 0)
			{
				// MessageBox.Show( $"移除会话[{session}]失败" );
			}

			this.comboBox_sessions.DataSource = this.sessions.ToArray( );
			session?.Close( );
			this.label_session_count.Text = string.Format( GetSessionCountText( ), this.sessions.Count );
		}

		public void RemoveSessionsAll( )
		{
			this.sessions.ForEach( m => m?.Close( ) );
			this.sessions.Clear( );
			this.comboBox_sessions.DataSource = this.sessions.ToArray( );
			this.label_session_count.Text = string.Format( GetSessionCountText( ), this.sessions.Count );
		}

		#endregion

		#region Packet Message Managment


		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormPacketMessage form = new FormPacketMessage( this.packetMessages ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					if (form.PacketMessages != null)
					{
						this.packetMessages = form.PacketMessages;
						linkLabel1.Text = string.Format( GetLinkLabelPacketMessageText( ), this.packetMessages.Count );

						this.listBox1.DataSource = packetMessages.ToArray( );
					}
				}
			}
		}

		private async void button_send_Click( object sender, EventArgs e )
		{
			// 分析是否分多次发送，中间可以使用特殊标记分割
			if (System.Text.RegularExpressions.Regex.IsMatch( textBox5.Text, @"<sleep=[0-9]+>" ))
			{
				string[] lines = textBox5.Lines;
				if (lines == null) return;
				button_send.Enabled = false;
				for (int i = 0; i < lines.Length; i++)
				{
					string str = lines[i];
					if (string.IsNullOrEmpty( str )) continue;
					if (System.Text.RegularExpressions.Regex.IsMatch( str, @"^<sleep=[0-9]+>" ))
					{
						int time = Convert.ToInt32( System.Text.RegularExpressions.Regex.Match( str, @"[0-9]+" ).Value );
						if (time > 0) await Task.Delay( time );
					}
					else
					{
						SendTextInfo( str );
					}
				}
				button_send.Enabled = true;
			}
			else
			{
				SendTextInfo( textBox5.Text );
			}
		}

		private void SendTextInfo( string text )
		{
			// 发送数据
			byte[] send = null;
			if (comboBox_encoding.SelectedIndex == 0) send = SoftBasic.HexStringToBytes( text );
			else if (comboBox_encoding.SelectedIndex == 1) send = SoftBasic.GetFromAsciiStringRender( text );
			else send = DemoUtils.GetEncodingFromIndex( comboBox_encoding.SelectedIndex - 1 ).GetBytes( text );

			if      (radioButton_append_0d.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { AsciiControl.CR } );
			else if (radioButton_append_0a.Checked)    send = SoftBasic.SpliceArray( send, new byte[] { AsciiControl.LF } );
			else if (radioButton_append_0d0a.Checked)  send = SoftBasic.SpliceArray( send, new byte[] { AsciiControl.CR, AsciiControl.LF } );
			else if (radioButton_append_crc16.Checked) send = HslCommunication.Serial.SoftCRC16.CRC16( send );

			SendSourceData( send );
			// SendData?.Invoke( send );
		}

		/// <summary>
		/// 发送相关的数据信息
		/// </summary>
		/// <param name="send"></param>
		public void SendSourceData( byte[] send )
		{
			if (send == null) return;

			if (radioButton_send_single.Checked)
			{
				if (comboBox_sessions.SelectedItem == null)
				{
					if (checkBox_send_cycle.Checked) checkBox_send_cycle.Checked = false;
					MessageBox.Show( Program.Language == 1 ? "当前没有可用的连接通道，请先连接上。" : "There are currently no connection channels available, please connect them first." );
					return;
				}
				if (comboBox_sessions.SelectedItem is SocketDebugSession session)
				{
					SendSourceData( session, send );
				}
			}
			else
			{
				if (sessions == null || sessions.Count == 0)
				{
					if (checkBox_send_cycle.Checked) checkBox_send_cycle.Checked = false;
					MessageBox.Show( Program.Language == 1 ? "当前没有可用的连接通道，请先连接上。" : "There are currently no connection channels available, please connect them first." );
					return;
				}

				for (int i = 0; i < sessions.Count; i++)
				{
					SendSourceData( sessions[i], send );
				}
			}
		}

		/// <summary>
		/// 发送相关的数据信息
		/// </summary>
		/// <param name="session">会话的信息</param>
		/// <param name="send"></param>
		public void SendSourceData( SocketDebugSession session, byte[] send )
		{
			if (send == null) return;
			try
			{
				if (session.UseMode == 0)
				{
					session.WorkSocket?.Send( send, 0, send.Length, SocketFlags.None );
				}
				else if (session.UseMode == 1)
				{
					session.WorkSocket?.SendTo( send, 0, send.Length, SocketFlags.None, session.RemoteEndPoint );
				}
				else if (session.UseMode == 2)
				{
					session.SerialPort?.Write( send, 0, send.Length );
				}

				RenderSendReceiveContent( session, 1, send );                         // 显示发送
			}
			catch (Exception ex)
			{
				// 发送失败的逻辑
				RenderSendReceiveContent( session, 2, send, "Send failed: " + ex.Message );                  // 显示发送异常
				RemoveSessions( session );
			}
		}

		public void LoadXml(XElement element )
		{
			this.packetMessages.Clear( );
			foreach (var item in element.Elements( nameof( PacketMessageItem ) ))
			{
				PacketMessageItem packetMessageItem = new PacketMessageItem( );
				packetMessageItem.LoadByXmlElement( item );
				this.packetMessages.Add( packetMessageItem );
			}

			linkLabel1.Text = string.Format( GetLinkLabelPacketMessageText( ), this.packetMessages.Count );
			this.listBox1.DataSource = packetMessages.ToArray( );
		}

		public void SaveXml( XElement element )
		{
			if (this.packetMessages?.Count > 0)
			{
				foreach (var item in this.packetMessages)
				{
					element.Add( item.ToXmlElement( ) );
				}
			}
		}




		#endregion

		#region Private Member

		private List<SocketDebugSession> sessions;
		private int listIndex = 0;
		private List<PacketMessageItem> packetMessages;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Timer sendtimer;
		private long sendCount = 0;
		private long recvCount = 0;

		#endregion

		private void panel1_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, 0, 0, panel1.Width - 1, panel1.Height - 1 );
		}
	}
}
