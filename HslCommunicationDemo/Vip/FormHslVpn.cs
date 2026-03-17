using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Vip
{
	public partial class FormHslVpn : HslFormContent
	{
		public FormHslVpn( )
		{
			InitializeComponent( );

			logNet = new LogNetSingle( string.Empty );
			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

			this.vpnSessions = new List<VpnSession>( );
			this.timer = new Timer( );
			this.timer.Interval = 1000;
			this.timer.Tick += Timer_Tick;
			this.timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			label_session_count.Text = vpnSessions.Count.ToString( );
			if (running)
			{
				vpnLeftSeconds--;
				label_left_seconds.Text = vpnLeftSeconds.ToString( );
				if (vpnLeftSeconds <= 0)
				{
					this.logNet?.WriteInfo( Program.Language == 1 ? "端口映射服务的有效时间已到，正在断开连接..." : "The validity period of the PortMapping service has expired. The connection is being disconnected..." );
					button2_Click( null, null );
				}
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			if (this.InvokeRequired)
			{
				Invoke( new Action<object, HslEventArgs>( LogNet_BeforeSaveToFile ), sender, e );
				return;
			}

			if  (logStop) return;
			textBox4.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.device_ip = textBox_device_ip.Text;
			this.device_port = Convert.ToInt32( textBox_device_port.Text );

			mqttClient = new MqttClient( new MqttConnectionOptions( )
			{
				IpAddress   = textBox_ip.Text,
				Port        = int.Parse( textBox_port.Text ),
				Credentials = new MqttCredential( textBox_userName.Text, textBox_password.Text ),
				ClientId    = textBox_clientId.Text,
				UseRSAProvider = true,
			} );

			OperateResult connect = mqttClient.ConnectServer( );
			if (connect.IsSuccess)
			{
				mqttClient.OnMqttMessageReceived += MqttClient_OnMqttMessageReceived;

				button1.Enabled = false;
				button2.Enabled = true;

				mqttClient.PublishMessage( new MqttApplicationMessage( )
				{
					Topic = "GetPort",
					Payload = Encoding.UTF8.GetBytes( "Request for PortMapping service" )
				} );

				this.logNet?.WriteInfo( Program.Language == 1 ? "连接服务器成功，正在请求端口映射服务..." : "The connection to the server was successful. Requesting PortMapping service..." );
			}
			else
			{
				DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
			}
		}

		private void MqttClient_OnMqttMessageReceived( MqttClient client, MqttApplicationMessage message )
		{
			if (message.Topic == "GetPort")
			{
				// 收到服务器返回的开放端口号，如果大于100000，则是失败的消息
				int port = BitConverter.ToInt32( message.Payload, 0 );
				if (port > 100000)
				{
					this.logNet?.WriteInfo( Program.Language == 1 ? "服务器分配端口失败，无法提供端口映射服务" : "The server failed to allocate ports, and thus cannot provide PortMapping services." );
				}
				else
				{
					this.logNet?.WriteInfo( Program.Language == 1 ? $"服务器分配端口成功，远程访问的端口号为：{port}" : $"The server has successfully allocated the port. The port number for remote access is: {port}" );
					int useTime = BitConverter.ToInt32( message.Payload, 4 );
					this.vpnLeftSeconds = useTime;
					this.running = true;

					this.logNet?.WriteInfo( Program.Language == 1 ? $"端口映射服务的有效时间为：{useTime} 秒" : $"The validity period of the PortMapping service is: {useTime} s" );
					Invoke( new Action( ( ) =>
					{
						label_server_port.Text = port.ToString( );
						label_left_seconds.Text = useTime.ToString( );
					} ) );
				}
			}
			else if (message.Topic == "Online")
			{
				// 连接操作，准备去连接本地的设备
				VpnSession vpnSession = new VpnSession( );
				vpnSession.Guid = Encoding.UTF8.GetString( message.Payload );
				vpnSession.Socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
				lock (lockObj)
				{
					vpnSessions.Add( vpnSession );
				}
				this.logNet?.WriteInfo( Program.Language == 1 ? $"远程客户端[{vpnSession.Guid}]上线，准备连接本地的设备..." : $"Remote client [{vpnSession.Guid}] has connected and is ready to establish a connection with the local device..." );
				try
				{
					vpnSession.Socket.Connect( System.Net.IPAddress.Parse( this.device_ip ), this.device_port );
					vpnSession.ConnectingDevice = false;
					this.logNet?.WriteInfo( Program.Language == 1 ? $"连接本地设备[{this.device_ip}:{this.device_port}]成功" : $"Connection to the local device [{this.device_ip}:{this.device_port}] has been successful." );
				}
				catch (Exception ex)
				{
					this.logNet?.WriteInfo( (Program.Language == 1 ? $"连接本地设备[{this.device_ip}:{this.device_port}]失败: " : $"Connection to the local device [{this.device_ip}:{this.device_port}] failed: ") + ex.Message );
					vpnSession.ConnectingDevice = false;
				}

				try
				{
					vpnSession.Socket.BeginReceive( vpnSession.tcpBuffer, 0, vpnSession.tcpBuffer.Length, SocketFlags.None, new AsyncCallback( TcpReceiveCallBack ), vpnSession );
				}
				catch( Exception ex )
				{
					this.logNet?.WriteInfo( (Program.Language == 1 ? $"开始从本地设备[{this.device_ip}:{this.device_port}]数据接收失败: " : $"The data reception from the local device [{this.device_ip}:{this.device_port}] has failed." )+ ex.Message );
					Offline( vpnSession.Guid );
				}
			}
			else if (message.Topic == "Offline")
			{
				string guid = Encoding.UTF8.GetString( message.Payload );
				Offline( guid, Program.Language == 1 ? $"远程客户端[{guid}]断开，准备断开本地的设备..." : $"Remote client [{guid}] has disconnected. Preparing to disconnect the local device..." );
			}
			else if (message.Topic.StartsWith( "Data:"))
			{
				// 收到服务器的数据报文
				string guid = message.Topic.Substring( 5 );
				VpnSession vpnSession = null;
				lock(lockObj)
				{
					vpnSession = vpnSessions.Where( m => m.Guid == guid ).FirstOrDefault( );
				}
				if (vpnSession != null)
				{
					// 如果正处于连接中的时候，多给与一点超时时间，最多10秒
					if (vpnSession.ConnectingDevice)
					{
						DateTime start = DateTime.Now;
						while(true)
						{
							if (vpnSession.ConnectingDevice == false) break;
							HslHelper.ThreadSleep( 50 );
							if ((DateTime.Now - start).TotalSeconds > 10_000)
							{
								break;
							}
						}
					}

					try
					{
						vpnSession.Socket.Send( message.Payload );


						this.logNet.WriteInfo( $"MqttServer -> Device[{(message.Payload == null ? 0 : message.Payload.Length)}]: " + message.Payload.ToHexString( ' ' ) );
					}
					catch (Exception ex)
					{
						Offline( vpnSession, ex );
						return;
					}
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.vpnLeftSeconds = 900;
			this.running = false;
			mqttClient?.ConnectClose( );
			button1.Enabled = true;
			button2.Enabled = false;

			this.logNet?.WriteInfo( Program.Language == 1 ? "已断开与服务器的连接，端口映射服务已停止..." : "The connection to the server has been disconnected, and the PortMapping service has been stopped..." );
		}

		#region Log

		private ILogNet logNet;

		#endregion

		#region Socket Tcp

		private List<VpnSession> vpnSessions;
		private object lockObj = new object( );

		private void Offline( string guid, string message = null )
		{
			// 断开连接操作，准备断开本地的设备
			bool remove = false;
			lock (lockObj)
			{
				VpnSession session = vpnSessions.Where( m => m.Guid == guid ).FirstOrDefault( );
				if (session != null)
				{
					session.Close( );
					remove = vpnSessions.Remove( session );
				}
			}

			if ( remove && !string.IsNullOrEmpty( message ))
			{
				this.logNet?.WriteInfo( message );
			}
		}

		private void Offline( VpnSession session, Exception ex )
		{
			// 异常关闭操作
			this.logNet?.WriteInfo( (Program.Language == 1 ? $"本地客户端[{session.Guid}]断开，准备断开远程的连接...  Reason: " : $"The local client [{session.Guid}] has disconnected. Preparing to disconnect the remote connection... Reason:") + ex.Message );
			mqttClient.PublishMessage( new MqttApplicationMessage( )
			{
				Topic = "Offline",
				Payload = Encoding.UTF8.GetBytes( session.Guid )
			} );
			Offline( session.Guid );
		}

		private void TcpReceiveCallBack( IAsyncResult ar )
		{
			if (ar.AsyncState is VpnSession session)
			{
				byte[] data = null;
				try
				{
					int length = session.Socket.EndReceive( ar );
					data = session.tcpBuffer.SelectBegin( length );
				}
				catch (Exception ex)
				{
					// 异常关闭操作
					Offline( session, ex );
					return;
				}

				OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( )
				{
					Topic = "Data:" + session.Guid,
					Payload = data
				} );

				if (send.IsSuccess == false)
				{
					this.logNet?.WriteError( "Send data to MqttServer failed: " + send.Message );
				}
				else
				{
					this.logNet.WriteInfo( $"Device -> MqttServer[{(data == null ? 0 : data.Length)}]: " + data.ToHexString( ' ' ) );
				}

				try
				{
					session.Socket.BeginReceive( session.tcpBuffer, 0, session.tcpBuffer.Length, SocketFlags.None, new AsyncCallback( TcpReceiveCallBack ), session );
				}
				catch (Exception ex)
				{
					// 异常关闭操作
					Offline( session, ex );
					return;
				}
			}
		}

		#endregion

		#region Private Member

		private MqttClient mqttClient;
		private string device_ip = "127.0.0.1";
		private int device_port = 10000;
		private System.Windows.Forms.Timer timer;
		private bool running = false;
		private int vpnLeftSeconds = 900;
		private bool logStop = false;

		#endregion

		#region Xml

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_device_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_device_port.Text );
			element.SetAttributeValue( "MqttIp", textBox_ip.Text );
			element.SetAttributeValue( "MqttPort", textBox_port.Text );
			element.SetAttributeValue( "MqttUserName", textBox_userName.Text );
			element.SetAttributeValue( "MqttPassword", textBox_password.Text );
			element.SetAttributeValue( "MqttClientId", textBox_clientId.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_device_ip.Text   = GetXmlValue( element, DemoDeviceList.XmlIpAddress, textBox_device_ip.Text, m => m );
			textBox_device_port.Text = GetXmlValue( element, DemoDeviceList.XmlPort, textBox_device_port.Text, m => m );
			textBox_ip.Text          = GetXmlValue( element, "MqttIp",       textBox_ip.Text, m => m );
			textBox_port.Text        = GetXmlValue( element, "MqttPort",     textBox_port.Text, m => m );
			textBox_userName.Text    = GetXmlValue( element, "MqttUserName", textBox_userName.Text, m => m );
			textBox_password.Text    = GetXmlValue( element, "MqttPassword", textBox_password.Text, m => m );
			textBox_clientId.Text    = GetXmlValue( element, "MqttClientId", textBox_clientId.Text, m => m );
		}

		#endregion



		private void FormHslVpn_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "PortMapping";
				label1.Text = "Local IP:";
				label3.Text = "Port:";

				label9.Text = "Server IP:";
				label8.Text = "Port:";
				label7.Text = "User Name:";
				label4.Text = "Password:";
				label6.Text = "Client Id:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

				label2.Text = "Log:";
				label5.Text = "Mapping Port:";
				label10.Text = "Left Run Seconds:";
				label11.Text = "Online Sessions:";
				button_log_stop.Text = "Stop Log";
				button_log_continue.Text = "Continue Log";
			}
		}

		private void button_log_stop_Click( object sender, EventArgs e )
		{
			this.logStop = true;
		}

		private void button_log_continue_Click( object sender, EventArgs e )
		{
			this.logStop = false;
		}


		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}

	public class VpnSession
	{
		public string Guid { get; set; }

		public Socket Socket { get; set; }

		/// <summary>
		/// 正在连接设备
		/// </summary>
		public bool ConnectingDevice { get; set; } = true;

		public byte[] tcpBuffer = new byte[2048];

		public void Close( )
		{
			NetSupport.CloseSocket( this.Socket );
			this.Socket = null;
		}
	}
}
