using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.HslDebug
{
	public class SocketDebugSession
	{
		/// <summary>
		/// 普通的TCP对象信息
		/// </summary>
		/// <param name="socket"></param>
		public SocketDebugSession( Socket socket )
		{
			sessionId = System.Threading.Interlocked.Increment( ref sessionIdCreate );
			WorkSocket = socket;
			try
			{
				RemoteEndPoint = WorkSocket.RemoteEndPoint;
				LocalEndPoint = WorkSocket.LocalEndPoint;
			}
			catch
			{

			}
		}

		/// <summary>
		/// UDP的通信对象信息
		/// </summary>
		/// <param name="socket">套接字</param>
		/// <param name="udp">udp远程对象</param>
		public SocketDebugSession( Socket socket, EndPoint udp )
		{
			sessionId = System.Threading.Interlocked.Increment( ref sessionIdCreate );
			WorkSocket = socket;
			RemoteEndPoint = udp; 
			try
			{
				LocalEndPoint = WorkSocket.LocalEndPoint;
			}
			catch
			{

			}
			useMode = 1;
		}

		/// <summary>
		/// 如果使用的串口信息
		/// </summary>
		/// <param name="SerialPort"></param>
		/// <param name="com"></param>
		public SocketDebugSession( SerialPort SerialPort, string com )
		{
			sessionId = System.Threading.Interlocked.Increment( ref sessionIdCreate );
			this.SerialPort = SerialPort;
			this.PortName = com;
			useMode = 2;
		}



		public Socket WorkSocket { get; private set; }

		public EndPoint LocalEndPoint { get; private set; }

		public EndPoint RemoteEndPoint { get; private set; }

		/// <summary>
		/// 当使用串口的时候的串口名称
		/// </summary>
		public string PortName { get; set; }

		/// <summary>
		/// 串口信息
		/// </summary>
		public SerialPort SerialPort { get; set; }

		/// <summary>
		/// 使用模式，TCP时为0， UDP为1，COM口为2
		/// </summary>
		public int UseMode => useMode;

		/// <summary>
		/// 当前会话的唯一ID信息
		/// </summary>
		public long SessionID => sessionId;

		/// <summary>
		/// 当移除对象的时候，是否进行关闭的操作
		/// </summary>
		public bool CloseWhenRemove { get; set; } = true;

		/// <summary>
		/// 当作服务器使用时候的数据缓冲区
		/// </summary>
		public byte[] Buffer { get; set; }

		/// <summary>
		/// 将数据发送到会话中去
		/// </summary>
		/// <param name="data"></param>
		public void SendData( byte[] data )
		{
			if (data == null) return;
			if (useMode == 0)
			{
				WorkSocket.Send( data );
			}
			else if (useMode == 1)
			{
				WorkSocket.SendTo( data, RemoteEndPoint );
			}
			else if (useMode == 2)
			{
				this.SerialPort.Write( data, 0, data.Length );
			}
		}

		#region Private Member

		private int useMode = 0;
		private long sessionId = 0;

		#endregion

		#region Object Override

		public void Close( )
		{
			if (UseMode == 0 || UseMode == 1)
			{
				if (CloseWhenRemove) WorkSocket?.Close( );
			}
			else
			{
				SerialPort?.Dispose( );
			}
		}

		public override string ToString( )
		{
			return useMode < 2 ? RemoteEndPoint.ToString( ) : PortName;
		}
		#endregion


		private static long sessionIdCreate = 0;
	}
}
