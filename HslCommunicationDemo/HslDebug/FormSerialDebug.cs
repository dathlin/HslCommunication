using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.IMessage;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using HslCommunication.MQTT;
using HslCommunicationDemo.HslDebug;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

			comboBox_Parity.SelectedIndex = 0;

			comboBox_portName.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox_portName.SelectedIndex = 0;
			}
			catch
			{
				comboBox_portName.Text = "COM3";
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
				comboBox_Parity.DataSource = new string[] { "无", "奇", "偶" };
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
				label8.Text = "Pwd:";
				label2.Text = "Topic:";
				label9.Text = "Name:";
				checkBox_useMqtt.Text = "Use MQTT";
				comboBox_Parity.DataSource = new string[] { "None", "Odd", "Even" };
				checkBox1.Text = "Go to Dtu?";
			}
		}

		// 01 10 00 64 00 10 20 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00 0B 00 0C 00 0D 00 0E 00 0F

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_BaudRate.Text, out int baudRate ))
			{
				MessageBox.Show( Program.Language == 1 ? "波特率输入错误！" : "Baud rate input error" );
				return;
			}

			if (!int.TryParse( textBox_DataBits.Text, out int dataBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "数据位输入错误！" : "Data bits input error" );
				return;
			}

			if (!int.TryParse( textBox_StopBit.Text, out int stopBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "停止位输入错误！" : "Stop bits input error" );
				return;
			}

			if (checkBox_useMqtt.Checked)
			{
				mqttClient?.ConnectClose( );
				mqttClient = new MqttClient( new MqttConnectionOptions( )
				{
					IpAddress = textBox_mqtt_ip.Text,
					Port = int.Parse( textBox_mqtt_port.Text ),
					Credentials = new MqttCredential( textBox_mqtt_name.Text, textBox_mqtt_password.Text ),
					ConnectTimeout = 3000,
				} );
				OperateResult connect = mqttClient.ConnectServer( );
				if (!connect.IsSuccess)
				{
					MessageBox.Show( "MQTT Connected failed, not use it" );
					mqttClient = null;
				}
			}


			SerialPort SP_ReadData = new SerialPort( );
			SP_ReadData.PortName = comboBox_portName.Text;
			SP_ReadData.BaudRate = baudRate;
			SP_ReadData.DataBits = dataBits;
			SP_ReadData.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
			SP_ReadData.Parity = comboBox_Parity.SelectedIndex == 0 ? Parity.None : (comboBox_Parity.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
			SP_ReadData.RtsEnable = checkBox5.Checked;

			try
			{
				SP_ReadData.DataReceived += SP_ReadData_DataReceived;
				SP_ReadData.Open( );

				socketDebugSession = new SocketDebugSession( SP_ReadData, SP_ReadData.PortName );
				this.debugControl1.AddSessions( socketDebugSession );

				if (checkBox1.Checked)
				{
					System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ConnectDtuIp ), dtuRemoteConnect );
				}

				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void SP_ReadData_DataReceived( object sender, SerialDataReceivedEventArgs e )
		{
			// 接收数据
			List<byte> buffer = new List<byte>( );
			byte[] data = new byte[1024];
			if (checkBox_until_empty.Checked)
			{
				while (true)
				{
					System.Threading.Thread.Sleep( 20 );
					if (socketDebugSession.SerialPort.BytesToRead < 1)
					{
						break;
					}

					int recCount = socketDebugSession.SerialPort.Read( data, 0, Math.Min( socketDebugSession.SerialPort.BytesToRead, data.Length ) );
					buffer.AddRange( data.SelectBegin( recCount ) );
				}
			}
			else
			{
				int recCount = socketDebugSession.SerialPort.Read( data, 0, data.Length );
				if (recCount > 0) buffer.AddRange( data.SelectBegin( recCount ) );
			}

			if (buffer.Count == 0) return;

			mqttClient?.PublishMessage( new MqttApplicationMessage( )
			{
				Topic = textBox_mqtt_topic.Text,
				Payload = buffer.ToArray( ),
			} );

			Invoke( new Action( ( ) =>
			 {
				 this.debugControl1.RenderSendReceiveContent( socketDebugSession, 0, buffer.ToArray( ) );
			 } ) );


			if (checkBox1.Checked && this.pipeDtu != null && dtuRemoteConnect != null)
			{
				data = buffer.ToArray( );
				this.pipeDtu?.Send( data );
				RenderDtuData( dtuRemoteConnect, pipeDtu, null, 4, data, string.Empty, $"Send DTU {dtuRemoteConnect.EndPoint}" );
			}
		}


		private void button2_Click( object sender, EventArgs e )
		{
			// 关闭串口
			try
			{
				this.debugControl1.RemoveSessions( socketDebugSession );
				button2.Enabled = false;
				button1.Enabled = true;

				panel2.Enabled = false;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}


		#region Xml Save Load

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox_BaudRate.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox_DataBits.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox_StopBit.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox_Parity.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox_portName.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );

			element.SetAttributeValue( "UseMqtt", checkBox_useMqtt.Checked );
			element.SetAttributeValue( "MqttIP", textBox_mqtt_ip.Text );
			element.SetAttributeValue( "MqttPort", textBox_mqtt_port.Text );
			element.SetAttributeValue( "MqttName", textBox_mqtt_name.Text );
			element.SetAttributeValue( "MqttPwd", textBox_mqtt_password.Text );
			element.SetAttributeValue( "MqttTopic", textBox_mqtt_topic.Text );


			element.RemoveNodes( );
			this.debugControl1.SaveXml( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_BaudRate.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox_DataBits.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox_StopBit.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox_Parity.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			comboBox_portName.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );

			checkBox_useMqtt.Checked = GetXmlValue( element, "UseMqtt", false, bool.Parse );
			textBox_mqtt_ip.Text = GetXmlValue( element,     "MqttIP", "", m => m );
			textBox_mqtt_port.Text = GetXmlValue( element,   "MqttPort", "", m => m );
			textBox_mqtt_name.Text = GetXmlValue( element,   "MqttName", "", m => m );
			textBox_mqtt_password.Text = GetXmlValue( element, "MqttPwd", "", m => m );
			textBox_mqtt_topic.Text = GetXmlValue( element, "MqttTopic", "", m => m );


			this.debugControl1.LoadXml( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}



		#endregion

		#region DTU Support


		private void checkBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox1.Checked)
			{
				// 开启DTU
				// 连接异形客户端
				using (FormInputAlien form = new FormInputAlien( ))
				{
					if (form.ShowDialog( ) == DialogResult.OK)
					{
						if (form.UseHslDtuServer)
						{
							dtuRemoteConnect = new RemoteConnectInfo( form.IpAddress, form.Port, form.DTU, form.Pwd, form.NeedAckDtuResult );
							//System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ConnectDtuIp ), dtuRemoteConnect );
						}
						else
						{
							dtuRemoteConnect = new RemoteConnectInfo( form.IpAddress, form.Port, form.CustomizeDTU );
							//System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ConnectDtuIp ), dtuRemoteConnect );
						}

					}
				}
			}
			else
			{
				// 关闭DTU
				dtuRemoteConnect = null;
			}
		}

		private void RenderDtuData( RemoteConnectInfo remoteConnect, PipeTcpNet pipeDtu, SocketDebugSession session, int code, byte[] data, string msg = null, string head = null )
		{
			if (code == 2)
			{
				if (button1.Enabled == false && checkBox1.Checked)
				{

				}
				else
				{
					pipeDtu.CloseCommunication( );
					pipeDtu = null;
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( session, code, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] Finish", head );
					} ) );
					return;
				}
			}

			Invoke( new Action( ( ) =>
			{
				this.debugControl1.RenderSendReceiveContent( session, code, data, msg, head );
			} ) );

			if (code == 2)
			{
				// code = 2 的时候执行关闭的操作
				pipeDtu.CloseCommunication( );
				pipeDtu = null;

				HslHelper.ThreadSleep( 10_000 );
				if (button1.Enabled == false && checkBox1.Checked) ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ConnectDtuIp ), remoteConnect );
				else
				{
					Invoke( new Action( ( ) =>
					{
						this.debugControl1.RenderSendReceiveContent( session, code, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] Finish", head );
					} ) );
				}
			}
		}

		private byte[] dtuBuffer = new byte[2048];
		private PipeTcpNet pipeDtu;
		private RemoteConnectInfo dtuRemoteConnect = null;

		public void ConnectDtuIp( object obj )
		{
			if (obj is RemoteConnectInfo remoteConnect)
			{
				pipeDtu = new HslCommunication.Core.Pipe.PipeTcpNet( remoteConnect.EndPoint.Address.ToString( ), remoteConnect.EndPoint.Port );
				pipeDtu.ConnectTimeOut = 10_000;

				OperateResult<bool> connect = pipeDtu.OpenCommunication( );
				if (!connect.IsSuccess)
				{
					RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] Socket Connected Failed : {connect.Message} 10s later retry..." );
					return;
				}

				// 连接成功后，先发送注册包
				if (remoteConnect.DtuBytes != null)
				{
					OperateResult send = pipeDtu.Send( remoteConnect.DtuBytes );
					if (send.IsSuccess)
					{
						Invoke( new Action( ( ) => this.debugControl1.RenderSendReceiveContent( null, 4, remoteConnect.DtuBytes, null, $"Ini DTU {remoteConnect.EndPoint}" ) ) );
					}
					else
					{
						RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] Socket Connected Failed : {connect.Message} 10s later retry..." );
						return;
					}
				}

				if (remoteConnect.NeedAckResult)
				{
					// 如果需要返回的情况
					OperateResult<byte[]> check = pipeDtu.ReceiveMessage( new AlienMessage( ), null, useActivePush: false );
					if (check.IsSuccess)
					{
						Invoke( new Action( ( ) => this.debugControl1.RenderSendReceiveContent( null, 0, check.Content, null, $"Ini DTU {remoteConnect.EndPoint} Back" ) ) );
						if (check.Content.Length >= 6)
						{
							switch (check.Content[5])
							{
								case 0x01:
									{
										RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {StringResources.Language.DeviceCurrentIsLoginRepeat} 10s later retry..." );
										return;
									}
								case 0x02:
									{
										RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {StringResources.Language.DeviceCurrentIsLoginForbidden} 10s later retry..." );
										return;
									}
								case 0x03:
									{
										RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {StringResources.Language.PasswordCheckFailed} 10s later retry..." );
										return;
									}
							}
						}
					}
				}
				remoteConnect.Session = new PipeSession( ) { Communication = pipeDtu };
				try
				{
					pipeDtu.Socket.BeginReceive( dtuBuffer, 0, dtuBuffer.Length, SocketFlags.None, new AsyncCallback( DtuAsyncCallback ), remoteConnect );
				}
				catch (Exception ex)
				{
					RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {ex.Message} 10s later retry..." );
				}
			}
		}

		private void DtuAsyncCallback( IAsyncResult ar )
		{
			if (ar.AsyncState is RemoteConnectInfo remoteConnect)
			{
				try
				{
					int len = (remoteConnect.Session.Communication as PipeTcpNet).Socket.EndReceive( ar );
					if (len == 0)
					{
						// DTU关闭了连接
						RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] Closed, 10s later retry..." );
						return;
					}

					byte[] data = dtuBuffer.SelectBegin( len );
					RenderDtuData( remoteConnect, pipeDtu, null, 4, data, string.Empty, $"Revc DTU {remoteConnect.EndPoint}" );

					// 然后发送给本地的socket
					if (socketDebugSession != null)
					{
						try
						{
							socketDebugSession.SendData( data );
							Invoke( new Action( ( ) => this.debugControl1.RenderSendReceiveContent( socketDebugSession, 1, data, null, $"Send DTU {remoteConnect.EndPoint}" ) ) );
						}
						catch (Exception ex)
						{
							Invoke( new Action( ( ) => this.debugControl1.RenderSendReceiveContent( socketDebugSession, -1, null, "socketDebugSession.SendData failed: " + ex.Message ) ) );
						}
					}
				}
				catch (Exception ex)
				{
					RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {ex.Message} 10s later retry..." );
					return;
				}

				try
				{
					pipeDtu.Socket.BeginReceive( dtuBuffer, 0, dtuBuffer.Length, SocketFlags.None, new AsyncCallback( DtuAsyncCallback ), remoteConnect );
				}
				catch (Exception ex)
				{
					RenderDtuData( remoteConnect, pipeDtu, null, 2, null, $"RemoteConnectInfo[{remoteConnect.EndPoint}] {ex.Message} 10s later retry..." );
				}
			}
		}


		#endregion

		#region Private Member

		private SocketDebugSession socketDebugSession;
		private MqttClient mqttClient;

		#endregion
	}
}
