using HslCommunication;
using HslCommunication.Core.Device;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class PipeSelectControl : UserControl
	{
		public PipeSelectControl( )
		{
			InitializeComponent( );

			comboBox_pipe_select.DataSource = new string[]
			{
				"TcpIp",
				"UdpIp",
				"Serial",
				"Mqtt",
				"SSL/TLS",
				"DTU",
				"MoxaCom"
			};

			string[] ports = SerialPort.GetPortNames( );
			comboBox_com_port.DataSource = ports;
			if (ports?.Length > 0) comboBox_com_port.SelectedIndex = 0;

			this.panel_mqtt.Visible = false;
			this.panel_mqtt.Location = this.panel_tcp.Location;

			this.panel_serial.Visible = false;
			this.panel_serial.Location = this.panel_tcp.Location;

			this.panel_udp.Visible = false;
			this.panel_udp.Location = this.panel_tcp.Location;

			this.panel_dtu.Visible = false;
			this.panel_dtu.Location = this.panel_tcp.Location;

			comboBox_pipe_select.SelectedIndex = 0;
			comboBox_pipe_select.SelectedIndexChanged += ComboBox_pipe_select_SelectedIndexChanged;

			if (Program.Language == 2)
			{
				comboBox_com_parity.DataSource = new string[] { "None", "Odd", "Even" };
			}
			comboBox_com_parity.SelectedIndex = 0;
		}

		private void ComboBox_pipe_select_SelectedIndexChanged( object sender, EventArgs e )
		{
			switch(comboBox_pipe_select.SelectedIndex)
			{
				case 0: SetVisible( SettingPipe.TcpPipe );break;
				case 1: SetVisible( SettingPipe.UdpPipe ); break;
				case 2: SetVisible( SettingPipe.SerialPipe ); break;
				case 3: SetVisible( SettingPipe.MqttPipe ); break;
				case 4: SetVisible( SettingPipe.SslPipe ); break;
				case 5: SetVisible( SettingPipe.DTU ); break;
				case 6: SetVisible( SettingPipe.MoxaCom ); break;
			}
		}

		private void PipeSelectControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				
			}
			else
			{
				label1.Text = label10.Text = label15.Text = "Ip:";
				label3.Text = label9.Text = label14.Text = "Port:";
				label2.Text = "Conn-Time:";
				label4.Text = label7.Text = "Recv-Time:";
				label12.Text = "Name:";
				label27.Text = "Com:";
				label26.Text = "BaudRate:";
				label6.Text = "StopBits:";
				label5.Text = "Parity:";
				label25.Text = "Databits:";
				label_info_pipe.Text = "Pipe";

				linkLabel_dtu_message.Text = "MSG";
				label13.Text = "Pwd:";
				label11.Text = "Port:";
				checkBox_dtu_back.Text = "Back MSG?";
			}
		}


		#region XML Save

		public void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( "PipeSetting", settingPipe );
			if (settingPipe == SettingPipe.TcpPipe || settingPipe == SettingPipe.SslPipe)
			{
				element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_tcp_ip.Text );
				element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_tcp_port.Text );
				element.SetAttributeValue( DemoDeviceList.XmlConnectTimeOut, textBox_tcp_connectTimeout.Text );
				element.SetAttributeValue( DemoDeviceList.XmlReceiveTimeOut, textBox_tcp_receive.Text );
				if (settingTcpIP != null)
				{
					element.SetAttributeValue( "PipeSleepTime", settingTcpIP.SleepTime );
					element.SetAttributeValue( "SocketKeepAliveTime", settingTcpIP.SocketKeepAliveTime );
					element.SetAttributeValue( "IsPersistentConnection", settingTcpIP.IsPersistentConnection );
					element.SetAttributeValue( "LocalIpAddress", settingTcpIP.LocalIpAddress );
					element.SetAttributeValue( "LocalPort", settingTcpIP.LocalPort );
					if (!string.IsNullOrEmpty( settingTcpIP.SendBeforeHex )) element.SetAttributeValue( "SendBeforeHex", settingTcpIP.SendBeforeHex );
				}
			}
			else if(settingPipe == SettingPipe.UdpPipe)
			{
				element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_udp_ip.Text );
				element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_udp_port.Text );
				element.SetAttributeValue( DemoDeviceList.XmlReceiveTimeOut, textBox_udp_receiveTimeout.Text );
				if (settingUdpIP != null)
				{
					element.SetAttributeValue( "PipeSleepTime", settingUdpIP.SleepTime );
					element.SetAttributeValue( "SocketKeepAliveTime", settingUdpIP.SocketKeepAliveTime );
					element.SetAttributeValue( "IsPersistentConnection", settingUdpIP.IsPersistentConnection );
					element.SetAttributeValue( "LocalIpAddress", settingUdpIP.LocalIpAddress );
					element.SetAttributeValue( "LocalPort", settingUdpIP.LocalPort );
					if (!string.IsNullOrEmpty( settingUdpIP.SendBeforeHex )) element.SetAttributeValue( "SendBeforeHex", settingUdpIP.SendBeforeHex );
				}
			}
			else if (settingPipe == SettingPipe.SerialPipe || settingPipe == SettingPipe.MoxaCom)
			{
				element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox_com_port.Text );
				element.SetAttributeValue( DemoDeviceList.XmlBaudRate, comboBox_com_baudrate.Text );
				element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox_com_databits.Text );
				element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox_com_stopbits.Text );
				element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox_com_parity.SelectedIndex );

				if (settingSerial != null)
				{
					element.SetAttributeValue( "PipeSleepTime", settingSerial.SleepTime );
					element.SetAttributeValue( "RtsEnable", settingSerial.RtsEnable );
					element.SetAttributeValue( "DtrEnable", settingSerial.DtrEnable );
					if (!string.IsNullOrEmpty( settingSerial.SendBeforeHex )) element.SetAttributeValue( "SendBeforeHex", settingSerial.SendBeforeHex );
				}
			}
			else if (settingPipe == SettingPipe.MqttPipe)
			{
				element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_mqtt_ip.Text );
				element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_mqtt_port.Text );
				element.SetAttributeValue( "MqttName", textBox_mqtt_name.Text );
				element.SetAttributeValue( "MqttPassword", this.settingMqtt.Password );
				element.SetAttributeValue( "MqttClientID", this.settingMqtt.ClientID );
				element.SetAttributeValue( "MqttUseRSAProvider", this.settingMqtt.UseRSAProvider );
				element.SetAttributeValue( "Device2Mqtt", this.settingMqtt.Device2Mqtt );
				element.SetAttributeValue( "Mqtt2Device", this.settingMqtt.Mqtt2Device );
			}
			else if (settingPipe == SettingPipe.DTU)
			{
				element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_dtu_port.Text );
				element.SetAttributeValue( "DTUBack",              checkBox_dtu_back.Checked );
				element.SetAttributeValue( "DTUId",                textBox_dtu_id.Text );
				element.SetAttributeValue( "DTUPwd",               textBox_dtu_pwd.Text );
			}
		}

		public void LoadXmlParameter( XElement element, SettingPipe settingPipeDefault )
		{
			SettingPipe setting = HslFormContent.GetXmlEnum( element, "PipeSetting", settingPipeDefault );
			this.SettingPipe = setting;
			if (setting == SettingPipe.TcpPipe || setting == SettingPipe.SslPipe)
			{
				textBox_tcp_ip.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlIpAddress, textBox_tcp_ip.Text, m => m );
				textBox_tcp_port.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlPort, textBox_tcp_port.Text, m => m );
				textBox_tcp_connectTimeout.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlConnectTimeOut, textBox_tcp_connectTimeout.Text, m => m );
				textBox_tcp_receive.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlReceiveTimeOut, textBox_tcp_receive.Text, m => m );
				if (element.Attribute( "PipeSleepTime" ) != null)
				{
					this.settingTcpIP = new SettingTcpIP( );
					this.settingTcpIP.SleepTime = HslFormContent.GetXmlValue( element, "PipeSleepTime", this.settingTcpIP.SleepTime, int.Parse );
					this.settingTcpIP.LocalIpAddress = HslFormContent.GetXmlValue( element, "LocalIpAddress", this.settingTcpIP.LocalIpAddress, m => m );
					this.settingTcpIP.LocalPort = HslFormContent.GetXmlValue( element, "LocalPort", this.settingTcpIP.LocalPort, int.Parse );
					this.settingTcpIP.SocketKeepAliveTime = HslFormContent.GetXmlValue( element, "SocketKeepAliveTime", this.settingTcpIP.SocketKeepAliveTime, int.Parse );
					this.settingTcpIP.IsPersistentConnection = HslFormContent.GetXmlValue( element, "IsPersistentConnection", this.settingTcpIP.IsPersistentConnection, bool.Parse );
					this.settingTcpIP.SendBeforeHex = HslFormContent.GetXmlValue( element, "SendBeforeHex", this.settingTcpIP.SendBeforeHex, m => m );
				}
			}
			else if (setting == SettingPipe.UdpPipe)
			{
				textBox_udp_ip.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlIpAddress, textBox_udp_ip.Text, m => m );
				textBox_udp_port.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlPort, textBox_udp_port.Text, m => m );
				textBox_udp_receiveTimeout.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlReceiveTimeOut, textBox_udp_receiveTimeout.Text, m => m );
				if (element.Attribute( "PipeSleepTime" ) != null)
				{
					this.settingUdpIP = new SettingTcpIP( );
					this.settingUdpIP.SleepTime = HslFormContent.GetXmlValue( element, "PipeSleepTime", this.settingUdpIP.SleepTime, int.Parse );
					this.settingUdpIP.LocalIpAddress = HslFormContent.GetXmlValue( element, "LocalIpAddress", this.settingUdpIP.LocalIpAddress, m => m );
					this.settingUdpIP.LocalPort = HslFormContent.GetXmlValue( element, "LocalPort", this.settingUdpIP.LocalPort, int.Parse );
					this.settingUdpIP.SocketKeepAliveTime = HslFormContent.GetXmlValue( element, "SocketKeepAliveTime", this.settingUdpIP.SocketKeepAliveTime, int.Parse );
					this.settingUdpIP.IsPersistentConnection = HslFormContent.GetXmlValue( element, "IsPersistentConnection", this.settingUdpIP.IsPersistentConnection, bool.Parse );
					this.settingUdpIP.SendBeforeHex = HslFormContent.GetXmlValue( element, "SendBeforeHex", this.settingUdpIP.SendBeforeHex, m => m );
				}
			}
			else if (setting == SettingPipe.SerialPipe || setting == SettingPipe.MoxaCom)
			{
				comboBox_com_port.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlCom, comboBox_com_port.Text, m => m );
				comboBox_com_baudrate.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlBaudRate, comboBox_com_baudrate.Text, m => m );
				textBox_com_databits.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlDataBits, textBox_com_databits.Text, m => m );
				textBox_com_stopbits.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlStopBit, textBox_com_stopbits.Text, m => m );
				comboBox_com_parity.SelectedIndex = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlParity, comboBox_com_parity.SelectedIndex, int.Parse );
				if (element.Attribute( "PipeSleepTime" ) != null)
				{
					this.settingSerial = new SettingSerial( );
					this.settingSerial.SleepTime = HslFormContent.GetXmlValue( element, "PipeSleepTime", this.settingSerial.SleepTime, int.Parse );
					this.settingSerial.RtsEnable = HslFormContent.GetXmlValue( element, "RtsEnable", this.settingSerial.RtsEnable, bool.Parse );
					this.settingSerial.DtrEnable = HslFormContent.GetXmlValue( element, "DtrEnable", this.settingSerial.DtrEnable, bool.Parse );
					this.settingSerial.SendBeforeHex = HslFormContent.GetXmlValue( element, "SendBeforeHex", this.settingSerial.SendBeforeHex, m => m );
				}
			}
			else if (setting == SettingPipe.MqttPipe)
			{
				textBox_mqtt_ip.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlIpAddress, textBox_mqtt_ip.Text, m => m );
				textBox_mqtt_port.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlPort, textBox_mqtt_port.Text, m => m );
				textBox_mqtt_name.Text = HslFormContent.GetXmlValue( element, "MqttName", textBox_mqtt_name.Text, m => m );
				this.settingMqtt.Password = HslFormContent.GetXmlValue( element, "MqttPassword", this.settingMqtt.Password, m => m );
				this.settingMqtt.ClientID = HslFormContent.GetXmlValue( element, "MqttClientID", this.settingMqtt.ClientID, m => m );
				this.settingMqtt.UseRSAProvider = HslFormContent.GetXmlValue( element, "MqttUseRSAProvider", this.settingMqtt.UseRSAProvider, bool.Parse );
				this.settingMqtt.Device2Mqtt = HslFormContent.GetXmlValue( element, "Device2Mqtt", this.settingMqtt.Device2Mqtt, m => m );
				this.settingMqtt.Mqtt2Device = HslFormContent.GetXmlValue( element, "Mqtt2Device", this.settingMqtt.Mqtt2Device, m => m );
			}
			else if (setting == SettingPipe.DTU)
			{
				textBox_dtu_port.Text     = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlPort, textBox_dtu_port.Text, m => m );
				checkBox_dtu_back.Checked = HslFormContent.GetXmlValue( element, "DTUBack", checkBox_dtu_back.Checked, bool.Parse );
				textBox_dtu_id.Text       = HslFormContent.GetXmlValue( element, "DTUId", textBox_dtu_id.Text, m => m );
				textBox_dtu_pwd.Text      = HslFormContent.GetXmlValue( element, "DTUPwd", textBox_dtu_pwd.Text, m => m );
			}
		}

		#endregion

		#region Public Properties

		public string TcpPortText
		{
			get => this.textBox_tcp_port.Text;
			set => this.textBox_tcp_port.Text = value;
		}

		public string UdpPortText
		{
			get => this.textBox_udp_port.Text;
			set => this.textBox_udp_port.Text = value;
		}

		public string SerialBaudRate
		{
			get => this.comboBox_com_baudrate.Text;
			set => this.comboBox_com_baudrate.Text = value;
		}

		public string SerialDataBits
		{
			get => this.textBox_com_databits.Text;
			set => this.textBox_com_databits.Text = value;
		}

		public string SerialStopBits
		{
			get => this.textBox_com_stopbits.Text;
			set => this.textBox_com_stopbits.Text = value;
		}

		public System.IO.Ports.Parity SerialParity
		{
			get
			{
				switch (comboBox_com_parity.SelectedIndex)
				{
					case 0: return Parity.None;
					case 1: return Parity.Odd;
					case 2: return Parity.Even;
				}
				return Parity.None;
			}
			set
			{
				switch (value)
				{
					case Parity.None: comboBox_com_parity.SelectedIndex = 0; break;
					case Parity.Odd: comboBox_com_parity.SelectedIndex = 1; break;
					case Parity.Even: comboBox_com_parity.SelectedIndex = 2; break;
				}
			}
		}

		#endregion

		public SettingPipe SettingPipe
		{
			get => this.settingPipe;
			set
			{
				//switch (comboBox_pipe_select.SelectedIndex)
				//{
				//	case 0: SetVisible( SettingPipe.TcpPipe ); break;
				//	case 1: SetVisible( SettingPipe.UdpPipe ); break;
				//	case 2: SetVisible( SettingPipe.SerialPipe ); break;
				//	case 3: SetVisible( SettingPipe.MqttPipe ); break;
				//	case 4: SetVisible( SettingPipe.SslPipe ); break;
				//}
				switch(value)
				{
					case SettingPipe.TcpPipe: comboBox_pipe_select.SelectedIndex = 0; break;
					case SettingPipe.UdpPipe: comboBox_pipe_select.SelectedIndex = 1; break;
					case SettingPipe.MoxaCom:
					case SettingPipe.SerialPipe: comboBox_pipe_select.SelectedIndex = 2; break;
					case SettingPipe.MqttPipe: comboBox_pipe_select.SelectedIndex = 3; break;
					case SettingPipe.SslPipe: comboBox_pipe_select.SelectedIndex = 4; break;
					case SettingPipe.DTU: comboBox_pipe_select.SelectedIndex = 5; break;
					default: SetVisible( value ); break;
				}
				SetVisible( value );
			}
		}

		public void SetVisible( SettingPipe settingPipe )
		{
			if (settingPipe == SettingPipe.TcpPipe )
			{
				this.panel_tcp.Visible = true;
				this.panel_udp.Visible = false;
				this.panel_mqtt.Visible = false;
				this.panel_serial.Visible = false;
				this.panel_dtu.Visible = false;
			}
			else if ( settingPipe == SettingPipe.SslPipe)
			{
				this.panel_tcp.Visible = true;
				this.panel_udp.Visible = false;
				this.panel_mqtt.Visible = false;
				this.panel_serial.Visible = false;
				this.panel_dtu.Visible = false;
			}
			else if (settingPipe == SettingPipe.UdpPipe)
			{
				this.panel_udp.Visible = true;
				this.panel_tcp.Visible = false;
				this.panel_mqtt.Visible = false;
				this.panel_serial.Visible = false;
				this.panel_dtu.Visible = false;
			}
			else if (settingPipe == SettingPipe.SerialPipe || settingPipe == SettingPipe.MoxaCom)
			{
				this.panel_serial.Visible = true;
				this.panel_udp.Visible = false;
				this.panel_tcp.Visible = false;
				this.panel_mqtt.Visible = false;
				this.panel_dtu.Visible = false;
			}
			else if (settingPipe == SettingPipe.MqttPipe)
			{
				this.panel_mqtt.Visible = true;
				this.panel_serial.Visible = false;
				this.panel_udp.Visible = false;
				this.panel_tcp.Visible = false;
				this.panel_dtu.Visible = false;
			}
			else if (settingPipe == SettingPipe.DTU)
			{
				this.panel_mqtt.Visible = false;
				this.panel_serial.Visible = false;
				this.panel_udp.Visible = false;
				this.panel_tcp.Visible = false;
				this.panel_dtu.Visible = true;
			}
			this.settingPipe = settingPipe;
		}


		public void IniPipe( BinaryCommunication device )
		{
			this.deviceTcpNet = device;
			if (this.settingPipe == SettingPipe.TcpPipe)
			{
				device.CommunicationPipe = CreatePipeTcpNet( device );
			}
			else if (this.settingPipe == SettingPipe.UdpPipe)
			{
				device.CommunicationPipe = CreatePipeUdpNet( device );
			}
			else if (this.settingPipe == SettingPipe.SerialPipe)
			{
				device.CommunicationPipe = CreatePipeSerialPort( device );
			}
			else if (this.settingPipe == SettingPipe.MoxaCom)
			{
				device.CommunicationPipe = CreatePipeMoxa( device );
			}
			else if (this.settingPipe == SettingPipe.SslPipe)
			{
				device.CommunicationPipe = CreatePipeSSLNet( device );
			}
			else if (this.settingPipe == SettingPipe.MqttPipe)
			{
				device.CommunicationPipe = CreatePipeMqttClient( );
			}
			else if (this.settingPipe == SettingPipe.DTU)
			{
				if (this.deviceTcpNet == null) throw new Exception( "当前的协议不支持DTU模式" );


				if (dtuServer != null) dtuServer.ServerClose( );
				dtuServer = new NetworkAlienClient( );
				dtuServer.LogNet = this.deviceTcpNet.LogNet;
				dtuServer.IsResponseAck = checkBox_dtu_back.Checked;                         // 是否返回注册包

				if (!string.IsNullOrEmpty(textBox_dtu_pwd.Text))
				{
					dtuServer.SetPassword( Encoding.ASCII.GetBytes( textBox_dtu_pwd.Text ) );
				}
				dtuServer.OnClientConnected += DtuServer_OnClientConnected;
				//dtuServer.OnClientConnected += ( PipeDtuNet session ) =>
				//{
				//	if (session.DTU == "123")
				//	{
				//		OperateResult connect = this.deviceTcpNet.SetDtuPipe( session );
				//		if (connect.IsSuccess)
				//		{
				//			Console.WriteLine( "connect success" );
				//		}
				//	}
				//};
				dtuServer.ServerStart( int.Parse( textBox_dtu_port.Text ) );


				linkLabel_dtu_state.Text = "Wait Connect...";
				linkLabel_dtu_state.LinkColor = Color.DodgerBlue;

				this.deviceTcpNet.SetDtuPipe( new PipeDtuNet( ) { DtuServer = dtuServer, DTU = textBox_dtu_id.Text, Pwd = textBox_dtu_pwd.Text } );
			}
		}

		public void ExtraCloseAction( BinaryCommunication device )
		{
			if (dtuServer != null)
			{
				dtu_connected = 0;
				linkLabel_dtu_state.Text = "Stopped";
				linkLabel_dtu_state.LinkColor = Color.Gray;

				dtuServer.ServerClose( );
				dtuServer = null;
			}
		}

		private void DeviceTcpNet_OnConnectClose( object sender, EventArgs e )
		{
			dtu_connected = 0;
			linkLabel_dtu_state.Text = "Stopped";
			linkLabel_dtu_state.LinkColor = Color.Gray;

			if (dtuServer != null)
			{
				dtuServer.ServerClose( );
				dtuServer = null;
			}
			//this.deviceTcpNet.OnConnectClose -= DeviceTcpNet_OnConnectClose;
		}

		private int dtu_connected = 0;
		private void DtuServer_OnClientConnected( PipeDtuNet session )
		{
			if (session.DTU == textBox_dtu_id.Text)
			{
				if (this.deviceTcpNet.CommunicationPipe != null && !this.deviceTcpNet.CommunicationPipe.IsConnectError( ))
				{
					// 当前已经在线，提示重复登录消息
					dtuServer.LogNet?.WriteDebug( dtuServer.ToString( ), $"DTU:{session.DTU} Login Repeat" );
					session?.CloseCommunication( );  // 关闭连接
					return;
				}
				OperateResult connect = this.deviceTcpNet.SetDtuPipe( session );
				dtu_connected++;
				Invoke( new Action( ( ) =>
				{
					if (connect.IsSuccess)
					{
						linkLabel_dtu_state.Text = $"Connected[{dtu_connected}]";
						linkLabel_dtu_state.LinkColor = Color.Green;
						linkLabel_dtu_state.BackColor = Color.Cyan;
					}
					else
					{
						MessageBox.Show( "Connect failed: " + connect.Message );
						linkLabel_dtu_state.Text = "Connect failed";
						linkLabel_dtu_state.LinkColor = Color.Tomato;
					}
				} ) );
				HslCommunication.Core.HslHelper.ThreadSleep( 2000 );
				if (connect.IsSuccess) linkLabel_dtu_state.BackColor = System.Windows.Forms.Control.DefaultBackColor;
			}
			else
			{
				dtuServer.LogNet?.WriteDebug( dtuServer.ToString( ), $"DTU:{session.DTU} Login Forbidden" );
				session?.CloseCommunication( );  // 关闭连接
				Invoke( new Action( ( ) =>
				{
					linkLabel_dtu_state.Text = "ID not same";
					linkLabel_dtu_state.LinkColor = Color.Tomato;
				} ) );
			}
		}

		public PipeTcpNet CreatePipeTcpNet( BinaryCommunication binaryCommunication )
		{
			PipeTcpNet pipe = new PipeTcpNet( textBox_tcp_ip.Text, int.Parse( textBox_tcp_port.Text ) );
			pipe.ConnectTimeOut = int.Parse( textBox_tcp_connectTimeout.Text );
			pipe.ReceiveTimeOut = int.Parse( textBox_tcp_receive.Text );

			if (settingTcpIP != null)
			{
				pipe.SleepTime = settingTcpIP.SleepTime;
				pipe.SocketKeepAliveTime = settingTcpIP.SocketKeepAliveTime;
				pipe.IsPersistentConnection = settingTcpIP.IsPersistentConnection;
				if (!string.IsNullOrEmpty( settingTcpIP.LocalIpAddress ) || settingTcpIP.LocalPort > 0)
				{
					pipe.LocalBinding = new System.Net.IPEndPoint( string.IsNullOrEmpty( settingTcpIP.LocalIpAddress ) ? System.Net.IPAddress.Any : System.Net.IPAddress.Parse( settingTcpIP.LocalIpAddress ),
					settingTcpIP.LocalPort < 0 ? 0 : settingTcpIP.LocalPort );
				}
				if (!string.IsNullOrEmpty( settingTcpIP.SendBeforeHex ))
					binaryCommunication.SendBeforeHex = settingTcpIP.SendBeforeHex;
			}
			return pipe;
		}

		public PipeSslNet CreatePipeSSLNet( BinaryCommunication binaryCommunication )
		{
			PipeSslNet pipe = new PipeSslNet( textBox_tcp_ip.Text, int.Parse( textBox_tcp_port.Text ), serverMode: false );
			pipe.ConnectTimeOut = int.Parse( textBox_tcp_connectTimeout.Text );
			pipe.ReceiveTimeOut = int.Parse( textBox_tcp_receive.Text );

			if (settingTcpIP != null)
			{
				pipe.SleepTime = settingTcpIP.SleepTime;
				pipe.SocketKeepAliveTime = settingTcpIP.SocketKeepAliveTime;
				pipe.IsPersistentConnection = settingTcpIP.IsPersistentConnection;
				if (!string.IsNullOrEmpty( settingTcpIP.LocalIpAddress ) || settingTcpIP.LocalPort > 0)
				{
					pipe.LocalBinding = new System.Net.IPEndPoint( string.IsNullOrEmpty( settingTcpIP.LocalIpAddress ) ? System.Net.IPAddress.Any : System.Net.IPAddress.Parse( settingTcpIP.LocalIpAddress ),
					settingTcpIP.LocalPort < 0 ? 0 : settingTcpIP.LocalPort );
				}
				if (!string.IsNullOrEmpty( settingTcpIP.SendBeforeHex ))
					binaryCommunication.SendBeforeHex = settingTcpIP.SendBeforeHex;
			}

			return pipe;
		}

		public PipeUdpNet CreatePipeUdpNet( BinaryCommunication binaryCommunication )
		{
			PipeUdpNet pipeUdpNet = new PipeUdpNet( textBox_udp_ip.Text, int.Parse( textBox_udp_port.Text ) );
			pipeUdpNet.ReceiveTimeOut = int.Parse( textBox_udp_receiveTimeout.Text );

			if (this.settingUdpIP != null)
			{
				pipeUdpNet.SleepTime = settingUdpIP.SleepTime;
				pipeUdpNet.SocketKeepAliveTime = settingUdpIP.SocketKeepAliveTime;
				pipeUdpNet.IsPersistentConnection = settingUdpIP.IsPersistentConnection;
				if (!string.IsNullOrEmpty( settingUdpIP.LocalIpAddress ) || settingUdpIP.LocalPort > 0)
				{
					pipeUdpNet.LocalBinding = new System.Net.IPEndPoint( string.IsNullOrEmpty( settingUdpIP.LocalIpAddress ) ? System.Net.IPAddress.Any : System.Net.IPAddress.Parse( settingUdpIP.LocalIpAddress ),
					settingUdpIP.LocalPort < 0 ? 0 : settingUdpIP.LocalPort );
				}
				if (!string.IsNullOrEmpty( settingUdpIP.SendBeforeHex ))
					binaryCommunication.SendBeforeHex = settingUdpIP.SendBeforeHex;
			}
			return pipeUdpNet;
		}

		private Parity GetSerialParity( )
		{
			return comboBox_com_parity.SelectedIndex == 0 ? System.IO.Ports.Parity.None : comboBox_com_parity.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even; 
		}

		private StopBits GetSerialStopBits( )
		{
			return textBox_com_stopbits.Text.Trim( ) == "1" ? System.IO.Ports.StopBits.One : textBox_com_stopbits.Text.Trim( ) == "2" ? System.IO.Ports.StopBits.Two :
				textBox_com_stopbits.Text.Trim( ) == "0" ? System.IO.Ports.StopBits.None : System.IO.Ports.StopBits.OnePointFive;
		}

		public PipeSerialPort CreatePipeSerialPort( BinaryCommunication binaryCommunication )
		{
			PipeSerialPort pipeSerialPort = new PipeSerialPort( );

			pipeSerialPort.SerialPortInni( p =>
			{
				p.PortName = comboBox_com_port.Text;
				p.BaudRate = int.Parse( comboBox_com_baudrate.Text );
				p.DataBits = int.Parse( textBox_com_databits.Text );
				p.StopBits = GetSerialStopBits( );
				p.Parity = GetSerialParity( );
				if (this.settingSerial != null)
				{
					p.RtsEnable = this.settingSerial.RtsEnable;
					p.DtrEnable = this.settingSerial.DtrEnable;
				};
			} );
			if (this.settingSerial != null)
			{
				pipeSerialPort.SleepTime = this.settingSerial.SleepTime;
				if (!string.IsNullOrEmpty( settingSerial.SendBeforeHex ))
					binaryCommunication.SendBeforeHex = settingSerial.SendBeforeHex;
			}

			return pipeSerialPort;
		}

		public PipeMoxa CreatePipeMoxa( BinaryCommunication binaryCommunication )
		{
			PipeMoxa pipeMoxa = new PipeMoxa( );
			pipeMoxa.SerialPortInni( comboBox_com_port.Text, int.Parse( comboBox_com_baudrate.Text ), int.Parse( textBox_com_databits.Text ), GetSerialStopBits( ), GetSerialParity( ) );

			if (this.settingSerial != null)
			{
				pipeMoxa.SleepTime = this.settingSerial.SleepTime;
				if (!string.IsNullOrEmpty( settingSerial.SendBeforeHex ))
					binaryCommunication.SendBeforeHex = settingSerial.SendBeforeHex;
			}

			return pipeMoxa;
		}

		public PipeMqttClient CreatePipeMqttClient( )
		{
			MqttConnectionOptions options = new MqttConnectionOptions( );
			options.IpAddress = textBox_mqtt_ip.Text;
			options.Port = int.Parse( textBox_mqtt_port.Text );
			if (!string.IsNullOrEmpty(textBox_mqtt_name.Text))
			{
				options.Credentials = new MqttCredential( textBox_mqtt_name.Text, settingMqtt == null ? string.Empty : settingMqtt.Password );
			}
			if (settingMqtt!= null)
			{
				options.ClientId = settingMqtt.ClientID;
				options.UseRSAProvider = settingMqtt.UseRSAProvider;
			}

			MqttClient mqttClient = new MqttClient( options );
			OperateResult connect = mqttClient.ConnectServer( );
			if (!connect.IsSuccess) throw new Exception( $"Connect mqtt server [{textBox_mqtt_ip.Text}] failed: " + connect.IsSuccess );

			PipeMqttClient pipe = new PipeMqttClient( mqttClient, settingMqtt.Device2Mqtt, settingMqtt.Mqtt2Device );
			return pipe;
		}

		private SettingPipe settingPipe = SettingPipe.TcpPipe;
		private SettingTcpIP settingTcpIP = null;
		private SettingTcpIP settingUdpIP = null;
		private SettingMqtt settingMqtt = new SettingMqtt( );
		private SettingSerial settingSerial = null;
		private HslCommunication.Core.Net.NetworkAlienClient dtuServer;
		private BinaryCommunication deviceTcpNet;

		private void linkLabel_tcp_more_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormPropertyModify form = new FormPropertyModify( ))
			{
				SettingTcpIP newSettings = new SettingTcpIP( this.settingTcpIP ?? new SettingTcpIP( ) );
				form.SetObject( newSettings );
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					this.settingTcpIP = newSettings;
				}
			}
		}

		private void linkLabel_udp_more_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormPropertyModify form = new FormPropertyModify( ))
			{
				SettingTcpIP newSettings = new SettingTcpIP( this.settingUdpIP ?? new SettingTcpIP( ) );
				form.SetObject( newSettings );
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					this.settingUdpIP = newSettings;
				}
			}
		}

		private void linkLabel_mqtt_more_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormPropertyModify form = new FormPropertyModify( ))
			{
				SettingMqtt newSettings = new SettingMqtt( this.settingMqtt ?? new SettingMqtt( ) );
				form.SetObject( newSettings );
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					this.settingMqtt = newSettings;
				}
			}
		}

		private void linkLabel_serial_more_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormPropertyModify form = new FormPropertyModify( ))
			{
				SettingSerial newSettings = new SettingSerial( this.settingSerial ?? new SettingSerial( ) );
				form.SetObject( newSettings );
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					this.settingSerial = newSettings;
				}
			}
		}

		private void linkLabel_dtu_message_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			using (FormDtuMessageCreate form = new FormDtuMessageCreate( ))
			{
				form.SetDtuId( textBox_dtu_id.Text, textBox_dtu_pwd.Text );
				if (form.ShowDialog( ) == DialogResult.OK)
				{

				}
			}
		}
	}

	public enum SettingPipe
	{
		TcpPipe,
		UdpPipe,
		SslPipe,
		SerialPipe,
		MqttPipe,
		DTU,
		MoxaCom,
	}

	public class SettingTcpIP
	{
		public SettingTcpIP( )
		{

		}

		public SettingTcpIP( SettingTcpIP other )
		{
			this.SleepTime = other.SleepTime;
			this.SocketKeepAliveTime = other.SocketKeepAliveTime;
			this.IsPersistentConnection = other.IsPersistentConnection;
			this.LocalIpAddress = other.LocalIpAddress;
			this.LocalPort = other.LocalPort;
			this.SendBeforeHex = other.SendBeforeHex;
		}

		public SettingTcpIP( PipeTcpNet pipeTcpNet )
		{
			this.SleepTime = pipeTcpNet.SleepTime;
			this.SocketKeepAliveTime = pipeTcpNet.SocketKeepAliveTime;
			this.IsPersistentConnection = pipeTcpNet.IsPersistentConnection;
			if (pipeTcpNet.LocalBinding != null)
			{
				this.LocalIpAddress = pipeTcpNet.LocalBinding.Address.ToString( );
				this.LocalPort = pipeTcpNet.Port;
			}
		}

		[Description( "在发送数据到PLC后，接收数据之前等待的时间。\r\nAfter sending data to PLC, wait time before receiving data." )]
		[DefaultValue( 0 )]
		public int SleepTime { get; set; } = 0;

		[Description( "Socket的底层的心跳保活时间，毫秒单位，小于0则不设置。\r\nHeartbeat keepalive time of the underlying Socket, in milliseconds. If the value is smaller than 0, this parameter is not specified." )]
		[DefaultValue( -1 )]
		public int SocketKeepAliveTime { get; set; } = -1;

		[Description( "是否设置长连接操作，true表示长连接，反之则短连接。\r\nWhether to set the long connection operation: true indicates a long connection; otherwise, a short connection." )]
		[DefaultValue( true )]
		public bool IsPersistentConnection { get; set; } = true;

		[Description( "绑定使用的本地IP地址，如果没有设置或是0.0.0.0，则表示任意可用的地址\r\nThe local IP address used by the binding, if not set or 0.0.0.0, represents any available address" )]
		[DefaultValue( "" )]
		public string LocalIpAddress { get; set; } = "";

		[Description( "本地使用的端口，-1表示自动\r\nPort used locally, -1 indicates automatic" )]
		[DefaultValue( -1 )]
		public int LocalPort { get; set; } = -1;

		[Description( "在每条报文发送前，额外发送的数据内容，常用于lora，会追加四个字节的站号\r\nBefore each message is sent, the additional data content sent, often used in lora, is appended with a four-byte station" )]
		[DefaultValue( "" )]
		public string SendBeforeHex { get; set; } = "";

		public override string ToString( ) => $"Tcp/Udp Seting [网络管道额外参数配置]";
	}

	public class SettingSerial
	{
		public SettingSerial( ){ }

		public SettingSerial( SettingSerial other )
		{
			this.RtsEnable = other.RtsEnable;
			this.DtrEnable = other.DtrEnable;
			this.SleepTime = other.SleepTime;
			this.SendBeforeHex = other.SendBeforeHex;
		}

		[Description( "获取或设置在串行通信中是否启用请求发送信号\r\nGets or sets whether to enable request signaling in serial communication" )]
		[DefaultValue( false )]
		public bool RtsEnable { get; set; } = false;

		[Description( "获取或设置在串行通信中是否启用数据终端就绪信号\r\nObtain or set whether to enable the data terminal ready signal in serial communication" )]
		[DefaultValue( false )]
		public bool DtrEnable { get; set; } = false;

		[Description( "获取或设置当前的发送数据后到接收数据前的等待时间，默认20毫秒\r\nThe default waiting time between the time the data is sent and the time between receiving the data is 20 milliseconds" )]
		[DefaultValue( 20 )]
		public int SleepTime { get; set; } = 20;

		[Description( "在每条报文发送前，额外发送的数据内容，常用于lora，会追加四个字节的站号\r\nBefore each message is sent, the additional data content sent, often used in lora, is appended with a four-byte station" )]
		[DefaultValue( "" )]
		public string SendBeforeHex { get; set; } = "";

		public override string ToString( ) => $"Serial Setting [串口额外参数配置]";
	}


	public class SettingMqtt
	{
		public SettingMqtt(){ }

		public SettingMqtt( SettingMqtt other)
		{
			this.Password = other.Password;
			this.ClientID = other.ClientID;
			this.Device2Mqtt = other.Device2Mqtt;
			this.Mqtt2Device = other.Mqtt2Device;
			this.UseRSAProvider = other.UseRSAProvider;
		}

		[Description( "Mqtt账户的密码，如果需要账户验证的话\r\nPassword for Mqtt account, if account verification is required" )]
		[DefaultValue( "" )]
		public string Password{ get; set; } = "";

		[Description( "Mqtt的客户端ID信息，根据实际情况输入\r\nClient ID information of Mqtt. Set this parameter based on the actual situation" )]
		[DefaultValue( "" )]
		public string ClientID { get; set; } = "";

		[Description( "订阅该topic时，当服务器收到设备发送的报文时，将返回该报文。\r\nWhen you subscribe to this topic, the server returns the packet when it receives the packet sent by the device." )]
		[DisplayName( "Device->Mqtt Topic" )]
		[DefaultValue( "DeviceToMqtt" )]
		public string Device2Mqtt { get; set; } = "DeviceToMqtt";

		[Description( "发布该topic时，将由服务器把报文写入到真实的PLC里面。\r\nWhen this topic is published, the server writes the message into the real PLC." )]
		[DisplayName( "Mqtt->Device Topic" )]
		[DefaultValue( "MqttToDevice" )]
		public string Mqtt2Device { get; set; } = "MqttToDevice";
		
		[Description( "当连接hslcommunication构建的MQTTServer时，支持rsa加密通信操作\r\nrsa encrypted communication operations are supported when connecting to MQTTServer built by hslcommunication" )]
		[DefaultValue( false )]
		public bool UseRSAProvider{ get; set; }

		public override string ToString( ) => $"Mqtt Setting [MQTT额外参数配置]";
	}

}
