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
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.Net;
using HslCommunicationDemo.HslDebug;

namespace HslCommunicationDemo
{
	public partial class FormTcpServer : HslFormContent
	{
		#region Form

		public FormTcpServer( )
		{
			InitializeComponent( );
			sessionUdp = new Dictionary<string, SocketDebugSession>( );

			panel_tcp_udp.Paint += Panel3_Paint;
		}

		private void FormTcpDebug_Load( object sender, EventArgs e )
		{
			panel_main.Enabled = false;
			Language( Program.Language );
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
				label3.Text = "端口号：";
				button_start.Text = "启动";
				button_close.Text = "关闭";
			}
			else
			{
				Text = "TCP/IP Debug Tools";
				label3.Text = "Port:";
				button_start.Text = "Start";
				button_close.Text = "Close";
				label2.Text = "Buffer Len:";
			}
		}


		#endregion

		#region TCP UDP Receive



		/// <summary>
		/// UDP启动时候的接收方法
		/// </summary>
		private void ThreadReceiveUdpCycle( )
		{
			byte[] data = new byte[this.bufferLength];
			while (IsStarted)
			{
				int length = 0;
				try
				{
					EndPoint Remote = (EndPoint)new IPEndPoint( IPAddress.Any, 0 );
					length = socketCore.ReceiveFrom( data, 0, data.Length, SocketFlags.None, ref Remote );
					udpEndPoint = Remote;

					SocketDebugSession session = null;
					string udp = udpEndPoint.ToString( );
					if (sessionUdp.ContainsKey( udp ))
					{
						session = sessionUdp[udp];
					}
					else
					{
						session = new SocketDebugSession( socketCore, udpEndPoint );
						session.CloseWhenRemove = false;                                       // 移除会话时不进行关闭操作
						sessionUdp.Add( udp, session );
						Invoke( new Action( ( ) =>
						{
							this.debugControl1.AddSessions( session );
						} ) );
					}

					if (length > 0) Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( session, 0, data.SelectBegin( length ) );
					} ) );
				}
				catch( Exception ex )
				{
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( new SocketDebugSession( socketCore, udpEndPoint ) { CloseWhenRemove = false }
							, 2, null, (Program.Language == 1 ? "服务器断开连接: " : "DisConnect from remote: ") + ex.Message );;
						this.debugControl1.RemoveSessionsAll( );
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
				try
				{
					// 在原始套接字上调用EndAccept方法，返回新的套接字
					client = server_socket.EndAccept( iar );

					SocketDebugSession session = new SocketDebugSession( client );
					session.Buffer = new byte[this.bufferLength];
					client.BeginReceive( session.Buffer, 0, session.Buffer.Length, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), session );

					//lock (session)
					//{
					//	sockets.Add( session );
					//}

					Invoke( new Action( ( ) =>
					{
						this.debugControl1.AddSessions( session );
					} ) );
				}
				catch (ObjectDisposedException)
				{
					// 服务器关闭时候触发的异常，不进行记录
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RemoveSessionsAll( );
					} ) );
					return;
				}
				catch
				{
					// 有可能刚连接上就断开了，那就不管
					client?.Close( );
				}

				try
				{
					server_socket.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), server_socket );
				}
				catch (ObjectDisposedException)
				{
					// 这个时候已经是关闭了

				}
			}
		}

		private void ReceiveCallBack( IAsyncResult ar )
		{
			if (ar.AsyncState is SocketDebugSession client)
			{
				try
				{
					int length = client.WorkSocket.EndReceive( ar );

					if (length == 0)
					{
						Invoke( new Action( ( ) =>
						{
							this.debugControl1.RenderSendReceiveContent( client, 2, null, (Program.Language == 1 ? "远程关闭连接" : "Remote closes connection") );
						} ) );
						return;
					};

					byte[] data = new byte[length];
					Array.Copy( client.Buffer, 0, data, 0, length );

					client.WorkSocket.BeginReceive( client.Buffer, 0, client.Buffer.Length, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), client );

					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( client, 0, data );
					} ) );
				}
				catch (ObjectDisposedException)
				{
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( client, 2, null, (Program.Language == 1 ? "服务器关闭连接" : "Server closes connection") );
					} ) );
				}
				catch( Exception ex )
				{
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( client, 2, null, (Program.Language == 1 ? "服务器断开连接: " : "DisConnect from remote: ") + ex.Message );
					} ) );
				}
			}
		}

		#endregion

		#region Start Close

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_buffer_length.Text, out int bufferLength ))
			{
				MessageBox.Show( "Buffer length input wrong!" );
				return;
			}
			this.bufferLength = bufferLength;

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
			button_start.Enabled = true;
			button_close.Enabled = false;
			panel_main.Enabled = false;
			panel_tcp_udp.Enabled = true;

			// 关闭所有的多余的连接
			socketCore?.Close( );
			this.debugControl1.RemoveSessionsAll( );
		}

		#endregion

		#region XML Save Load

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( "Tcp", radioButton_tcp.Checked );
			element.SetAttributeValue( "BufferLength", textBox_buffer_length.Text );

			element.RemoveNodes( );
			this.debugControl1.SaveXml( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = GetXmlValue( element, DemoDeviceList.XmlPort, "502", m => m );
			bool tcp = GetXmlValue( element, "Tcp", true, bool.Parse );
			if (tcp)
				radioButton_tcp.Checked = true;
			else
				radioButton_udp.Checked = true;
			textBox_buffer_length.Text = GetXmlValue( element, "BufferLength", "2048", m => m );

			this.debugControl1.LoadXml( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		#endregion

		#region Private Member

		private Dictionary<string, SocketDebugSession> sessionUdp;
		private Socket socketCore = null;
		private System.Threading.Thread threadReceive;
		private bool IsStarted = false;
		private EndPoint udpEndPoint = null;
		private int bufferLength = 2048;

		#endregion
	}

}
