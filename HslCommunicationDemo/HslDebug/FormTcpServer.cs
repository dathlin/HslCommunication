using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Net;

namespace HslCommunicationDemo
{
	public partial class FormTcpServer : HslFormContent
	{
		#region Form

		public FormTcpServer( )
		{
			InitializeComponent( );
		}

		private void FormTcpDebug_Load( object sender, EventArgs e )
		{
			panel_main.Enabled = false;
			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 500;
			timer.Tick += Timer_Tick;
			timer.Start( );

			Language( Program.Language );

			panel5.Paint += Panel3_Paint;
			panel4.Paint += Panel3_Paint;
			panel_tcp_udp.Paint += Panel3_Paint;
		}

		private void Panel3_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1 ) );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "TCP/IP调试助手";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button_start.Text = "启动";
				button_close.Text = "关闭";
				label6.Text = "数据发送区：";
				label7.Text = "数据接收区：";
				checkBox3.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button3.Text = "发送数据";
				label8.Text = "已选择数据字节数：";
			}
			else
			{
				Text = "TCP/IP Debug Tools";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button_start.Text = "Start";
				button_close.Text = "Close";
				label6.Text = "Data sending Area:";
				label7.Text = "Data receiving Area:";
				checkBox3.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button3.Text = "Send Data";
				label8.Text = "Number of data bytes selected:";
			}
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (!string.IsNullOrEmpty( textBox6.Text ))
			{
				string select = textBox6.SelectedText;
				if (!string.IsNullOrEmpty( select ))
				{
					if (radioButton_binary.Checked)
					{
						// 二进制
						byte[] bytes = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( select );
						label8.Text = (Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:") + bytes.Length;
					}
					else
					{
						label8.Text = (Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:") + select.Length;
					}
				}

				label4.Text = "Onlines: " + sockets.Count;
			}
		}

		private void RenderReiceiveData( IPEndPoint endPoint, byte[] data )
		{
			string msg = radioButton_binary.Checked ? SoftBasic.ByteToHexString( data, ' ' ) : SoftBasic.GetAsciiStringRender( data );
			if (!checkBox_stop_show.Checked) textBox6.AppendText( FormTcpDebug.GetTextHeader( checkBox_show_time.Checked, 0, msg ) );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 发送数据
			byte[] send = radioButton_binary.Checked ? SoftBasic.HexStringToBytes( textBox5.Text ) : SoftBasic.GetFromAsciiStringRender( textBox5.Text );

			if (radioButton_append_0d.Checked) send = SoftBasic.SpliceArray( send, new byte[] { 0x0D } );
			else if (radioButton_append_0a.Checked) send = SoftBasic.SpliceArray( send, new byte[] { 0x0A } );
			else if (radioButton_append_0d0a.Checked) send = SoftBasic.SpliceArray( send, new byte[] { 0x0D, 0x0A } );
			else if (radioButton_append_crc16.Checked) send = HslCommunication.Serial.SoftCRC16.CRC16( send );

			if (checkBox3.Checked)
			{
				// 显示发送信息
				textBox6.AppendText( FormTcpDebug.GetTextHeader( checkBox_show_time.Checked, 1, radioButton_binary.Checked ? SoftBasic.ByteToHexString( send, ' ' ) : SoftBasic.GetAsciiStringRender( send ) ) );
			}
			try
			{
				if (radioButton_tcp.Checked)
				{
					lock (lockObject)
					{
						for (int i = 0; i < sockets.Count; i++)
						{
							if (sockets[i].EndPoint.ToString( ) == comboBox1.Text)
							{
								sockets[i].Socket.Send( send, 0, send.Length, SocketFlags.None );
								break;
							}
						}
					}
				}
				else
				{
					if (udpEndPoint != null)
					{
						socketCore.SendTo( send, 0, send.Length, SocketFlags.None, udpEndPoint );
					}
				}
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			HslCommunication.Robot.EFORT.ER7BC10 eR7BC10 = new HslCommunication.Robot.EFORT.ER7BC10( "192.168.0.100", 8008 );
			textBox5.Text = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( eR7BC10.GetReadCommand( ), ' ' );
		}

		#endregion

		#region TCP UDP Receive

		/// <summary>
		/// UDP启动时候的接收方法
		/// </summary>
		private void ThreadReceiveUdpCycle( )
		{
			IPEndPoint ipep = new IPEndPoint( IPAddress.Any, 0 );
			EndPoint Remote = (EndPoint)ipep;
			while (IsStarted)
			{
				byte[] data = new byte[2048];
				int length = 0;
				try
				{
					length = socketCore.ReceiveFrom( data, ref Remote );
					udpEndPoint = Remote;
					if (length > 0) Invoke( new Action( ( ) =>
					{
						comboBox1.DataSource = new EndPoint[] { udpEndPoint };
						RenderReiceiveData( (IPEndPoint)Remote, data.SelectBegin( length ) );
					} ) );
				}
				catch
				{
					Invoke( new Action( ( ) =>
					{
						textBox6.AppendText( ( Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote" ) + Environment.NewLine );
					} ) );
				}
			}
		}

		/// <summary>
		/// 异步传入的连接申请请求
		/// </summary>
		/// <param name="iar">异步对象</param>
		protected void AsyncAcceptCallback( IAsyncResult iar )
		{
			//还原传入的原始套接字
			if (iar.AsyncState is Socket server_socket)
			{
				Socket client = null;
				ClientSession session = new ClientSession( );
				try
				{
					// 在原始套接字上调用EndAccept方法，返回新的套接字
					client = server_socket.EndAccept( iar );

					session.Socket = client;
					session.EndPoint = (IPEndPoint)client.RemoteEndPoint;

					client.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), session );

					lock (session)
					{
						sockets.Add( session );
					}

					Invoke( new Action( ( ) =>
					{
						textBox6.AppendText( "Client Online[" + session.EndPoint.Address.ToString( ) + "]" + Environment.NewLine );
						lock (lockObject)
						{
							comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
						}
					} ) );
				}
				catch (ObjectDisposedException)
				{
					// 服务器关闭时候触发的异常，不进行记录
					lock (lockObject)
					{
						sockets.Remove( session );
					}
					return;
				}
				catch
				{
					// 有可能刚连接上就断开了，那就不管
					lock (lockObject)
					{
						sockets.Remove( session );
					}
					client?.Close( );
				}


				server_socket.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), server_socket );
			}
		}

		private void ReceiveCallBack( IAsyncResult ar )
		{
			if (ar.AsyncState is ClientSession client)
			{
				try
				{
					int length = client.Socket.EndReceive( ar );

					if (length == 0)
					{
						Invoke( new Action( ( ) =>
						{
							client.Socket.Close( );
							lock (lockObject)
							{
								sockets.Remove( client );
								comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
							}
							textBox6.AppendText( FormTcpDebug.GetTextHeader( checkBox_show_time.Checked, 2, "Client Offline[" + client.EndPoint.Address.ToString( ) + "]" +
								(Program.Language == 1 ? "远程关闭连接" : "Remote closes connection") ) );
						} ) );
						return;
					};

					client.Socket.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), client );

					byte[] data = new byte[length];
					Array.Copy( buffer, 0, data, 0, length );
					Invoke( new Action( ( ) =>
					{
						RenderReiceiveData( client.EndPoint, data );
					} ) );
				}
				catch (ObjectDisposedException)
				{
					Invoke( new Action( ( ) =>
					{
						lock (lockObject)
						{
							sockets.Remove( client );
							comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
						}
					} ) );
				}
				catch
				{
					Invoke( new Action( ( ) =>
					{
						lock (lockObject)
						{
							sockets.Remove( client );
							comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
						}
						textBox6.AppendText( Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote" + Environment.NewLine );
					} ) );
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
				if (radioButton_tcp.Checked)
				{
					// TCP的启动
					socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
					socketCore.Bind( new IPEndPoint( 0, int.Parse( textBox_port.Text ) ) );
					socketCore.Listen( 500 );//单次允许最后请求500个，足够小型系统应用了
					socketCore.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), socketCore );
				}
				else
				{
					// UDP的启动
					socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
					socketCore.Bind( new IPEndPoint( IPAddress.Any, int.Parse( textBox_port.Text ) ) );
					threadReceive = new System.Threading.Thread( new System.Threading.ThreadStart( ThreadReceiveUdpCycle ) ) { IsBackground = true };
					threadReceive.Start( );
					IsStarted = true;
				}

				button_start.Enabled = false;
				button_close.Enabled = true;
				panel_main.Enabled = true;
				panel_tcp_udp.Enabled = false;

				MessageBox.Show( HslCommunication.StringResources.Language.ConnectServerSuccess );
			}
			catch (Exception ex)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.NetEngineStart + Environment.NewLine + ex.Message );
			}
		}


		private void button2_Click( object sender, EventArgs e )
		{
			IsStarted = false;
			socketCore?.Close( );
			button_start.Enabled = true;
			button_close.Enabled = false;
			panel_main.Enabled = false;
			panel_tcp_udp.Enabled = true;

			// 关闭所有的多余的连接
			lock (lockObject)
			{
				foreach ( var socket in sockets)
				{
					socket?.Socket?.Close( );
				}
				sockets.Clear( );
			}
		}

		#endregion

		#region Private Member

		private object lockObject = new object( );
		private Socket socketCore = null;
		private byte[] buffer = new byte[2048];
		private System.Windows.Forms.Timer timer;
		private List<ClientSession> sockets = new List<ClientSession>( );
		private System.Threading.Thread threadReceive;
		private bool IsStarted = false;
		private EndPoint udpEndPoint = null;

		#endregion
	}

	class ClientSession
	{
		public Socket Socket { get; set; }

		public IPEndPoint EndPoint { get; set; }

		public override string ToString( ) => EndPoint.ToString( );
	}
}
