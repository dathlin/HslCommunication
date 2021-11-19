using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo
{
	public partial class FormTcpToTcp : HslFormContent
	{
		public FormTcpToTcp( )
		{
			InitializeComponent( );
		}

		private void FormSerialDebug_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "网口转网口调试助手";
				label7.Text = "数据接收区：";
				checkBox3.Text = "是否显示发送数据";
			}
			else
			{
				Text = "TCP TO TCP Debug Tools";
				label7.Text = "Data receiving Area:";
				checkBox3.Text = "Whether to display send data";
			}
		}

		// 01 10 00 64 00 10 20 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00 0B 00 0C 00 0D 00 0E 00 0F



		#region Private Member

		private Socket remote = null;
		private Socket socketCore = null;
		private Socket client = null;
		private byte[] buffer = new byte[2048];

		#endregion

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int remotePort ))
			{
				MessageBox.Show( Program.Language == 1 ? "端口号输入错误！" : "IpAddress port input error" );
				return;
			}

			remote = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			try
			{
				remote.Connect( IPAddress.Parse( textBox3.Text ), remotePort );
				remote.BeginReceive( new byte[0], 0, 0, SocketFlags.None, new AsyncCallback( RemoteSocketEndReceive ), remote );
				button1.Enabled = false;
				button2.Enabled = true;

				panel2.Enabled = true;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
				return;
			}

			// 连接服务器
			try
			{
				socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
				socketCore.Bind( new IPEndPoint( 0, int.Parse( textBox1.Text ) ) );
				socketCore.Listen( 100 );
				socketCore.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), socketCore );

				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;

				MessageBox.Show( HslCommunication.StringResources.Language.ConnectServerSuccess );
			}
			catch (Exception ex)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message );
			}
		}

		private void RemoteSocketEndReceive( IAsyncResult ar )
		{
			if (ar.AsyncState is Socket socket)
			{
				byte[] buffer = new byte[1024];
				try
				{
					int length = socket.Receive( buffer, 0, 1024, SocketFlags.None );
					if (length == 0)
					{
						Invoke( new Action( ( ) =>
						{
							DemoUtils.AppendTextBox( textBox6, remote.RemoteEndPoint.ToString( ), "Remote Offline" );
						} ) );
						return;
					}
					else
					{
						buffer = buffer.SelectBegin( length );
					}
					remote.BeginReceive( new byte[0], 0, 0, SocketFlags.None, new AsyncCallback( RemoteSocketEndReceive ), remote );
				}
				catch (Exception ex)
				{
					Invoke( new Action( ( ) =>
					{
						DemoUtils.AppendTextBox( textBox6, remote?.RemoteEndPoint.ToString( ), "Remote Offline Exception: " + ex.Message );
					} ) );
					return;
				}

				try
				{
					client?.Send( buffer, 0, buffer.Length, SocketFlags.None );
					Invoke( new Action( ( ) =>
					{
						string msg = string.Empty;
						if (checkBox1.Checked)
						{
							msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( buffer, ' ' );
						}
						else
						{
							msg = HslCommunication.BasicFramework.SoftBasic.GetAsciiStringRender( buffer );
						}


						DemoUtils.AppendTextBox( textBox6, "Remote->Client", msg );

					} ) );
				}
				catch (Exception ex)
				{
					Invoke( new Action( ( ) =>
					{
						if (client != null) DemoUtils.AppendTextBox( textBox6, client.RemoteEndPoint.ToString( ), "Client Offline Exception: " + ex.Message );
					} ) );
					return;
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
				ClientSession session = new ClientSession( );
				try
				{
					// 在原始套接字上调用EndAccept方法，返回新的套接字
					client = server_socket.EndAccept( iar );

					session.Socket = client;
					session.EndPoint = (IPEndPoint)client.RemoteEndPoint;

					client.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), session );


					Invoke( new Action( ( ) =>
					{
						DemoUtils.AppendTextBox( textBox6, session.EndPoint.ToString( ), "Client Online" );
						textBox4.Text = client.RemoteEndPoint.ToString( );
					} ) );
				}
				catch (ObjectDisposedException)
				{
					// 服务器关闭时候触发的异常，不进行记录
					client = null;
					return;
				}
				catch
				{
					// 有可能刚连接上就断开了，那就不管
					client = null;
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
							DemoUtils.AppendTextBox( textBox6, client.EndPoint.ToString( ), "Client Offline" );
						} ) );
						client = null;
						return;
					};

					client.Socket.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), client );
					byte[] data = new byte[length];
					Array.Copy( buffer, 0, data, 0, length );
					remote?.Send( data, 0, data.Length, SocketFlags.None );

					Invoke( new Action( ( ) =>
					{
						string msg = string.Empty;
						if (checkBox1.Checked)
						{
							msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( data, ' ' );
						}
						else
						{
							msg = HslCommunication.BasicFramework.SoftBasic.GetAsciiStringRender( data );
						}

						DemoUtils.AppendTextBox( textBox6, "Client->Remote", msg );
					} ) );
				}
				catch
				{
					Invoke( new Action( ( ) =>
					{
						this.client = null;
						DemoUtils.AppendTextBox( textBox6, "Client Offline", Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote" );
					} ) );
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 关闭串口
			try
			{
				remote?.Close( );
				remote = null;
				client?.Close( );
				socketCore?.Close( );
				button2.Enabled = false;
				button1.Enabled = true;

				panel2.Enabled = false;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

	}
}
