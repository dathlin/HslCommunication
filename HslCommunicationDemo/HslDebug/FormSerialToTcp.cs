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
	public partial class FormSerialToTcp : HslFormContent
	{
		public FormSerialToTcp( )
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
				label7.Text = "数据接收区：";
				checkBox3.Text = "是否显示发送数据";
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
				label7.Text = "Data receiving Area:";
				checkBox3.Text = "Whether to display send data";
				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
			}
		}

		// 01 10 00 64 00 10 20 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00 0B 00 0C 00 0D 00 0E 00 0F



		#region Private Member

		private SerialPort SP_ReadData = null;                    // 串口交互的核心
		private Socket socketCore = null;
		private Socket client = null;
		private byte[] buffer = new byte[2048];

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

			// 连接服务器
			try
			{
				socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
				socketCore.Bind( new IPEndPoint( 0, int.Parse( textBox1.Text ) ) );
				socketCore.Listen( 500 );//单次允许最后请求500个，足够小型系统应用了
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
					SP_ReadData.Write( data, 0, data.Length );
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

						DemoUtils.AppendTextBox( textBox6, "Tcp-Serial", msg );
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

			try
			{
				byte[] send = buffer.ToArray( );
				client.Send( send, 0, send.Length, SocketFlags.None );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Client Send Failed! " + ex.Message );
				return;
			}

			Invoke( new Action( ( ) =>
			 {
				 string msg = string.Empty;
				 if (checkBox1.Checked)
				 {
					 msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( buffer.ToArray( ), ' ' );
				 }
				 else
				 {
					 msg = HslCommunication.BasicFramework.SoftBasic.GetAsciiStringRender( buffer.ToArray( ) );
				 }

				 DemoUtils.AppendTextBox( textBox6, "Serial-Tcp", msg );
			 } ) );
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

	}
	class ClientSession
	{
		public Socket Socket { get; set; }

		public IPEndPoint EndPoint { get; set; }

		public override string ToString( ) => EndPoint.ToString( );
	}
}
