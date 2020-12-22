using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.WebSocket;
using HslCommunication;
using System.Threading;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region Websocket


	public partial class FormWebsocketClient : HslFormContent
	{
		public FormWebsocketClient( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "Websocket客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label6.Text = "主题：";
				label9.Text = "Payload：";
				button3.Text = "发送";
				button4.Text = "清空";
				label12.Text = "接收：";
				button5.Text = "压力测试";
			}
			else
			{
				Text = "Websocket Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "Topic:";
				label9.Text = "Payload:";
				button3.Text = "Send";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				button5.Text = "Press Test";
			}
		}

		private WebSocketClient wsClient;

		private void button1_Click( object sender, EventArgs e )
		{
			panel2.Enabled = true;
			if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				
			}

			wsClient?.ConnectClose( );
			wsClient = new WebSocketClient( textBox1.Text, int.Parse( textBox2.Text ), textBox5.Text );//( textBox1.Text, int.Parse(textBox2.Text), textBox5.Text );
			wsClient.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );
			wsClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			wsClient.OnClientApplicationMessageReceive += WebSocket_OnWebSocketMessageReceived;
			//wsClient.OnNetworkError += WsClient_OnNetworkError; // 这里使用内置的处理方式，一般也就够用了。
			OperateResult connect = null;
			if(string.IsNullOrEmpty(textBox3.Text))
				connect = wsClient.ConnectServer( );
			else
				connect = wsClient.ConnectServer( textBox3.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ) );

			if (connect.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
			}
		}

		private void WsClient_OnNetworkError( object sender, EventArgs e )
		{
			// 当网络异常的时候触发，可以在此处重连服务器
			if (sender is WebSocketClient client)
			{
				// 开始重连服务器，直到连接成功为止
				client.LogNet?.WriteInfo( "网络异常，准备10秒后重新连接。" );
				while (true)
				{
					// 每隔10秒重连
					System.Threading.Thread.Sleep( 10_000 );
					client.LogNet?.WriteInfo( "准备重新连接服务器..." );

					if (client.IsClosed) return;  // 如果已经是关闭了的，就不需要进行重连服务器了
					OperateResult connect = client.ConnectServer( );
					if (connect.IsSuccess)
					{
						// 连接成功后，可以在下方break之前进行订阅，或是数据初始化操作
						client.LogNet?.WriteInfo( "连接服务器成功！" );
						break;
					}
					client.LogNet?.WriteInfo( "连接失败，准备10秒后重新连接。" );
				}
			}
		}

		private void WebSocket_OnWebSocketMessageReceived( WebSocketMessage message )
		{
			try
			{
				Invoke( new Action( ( ) =>
				{
					string msg = Encoding.UTF8.GetString( message.Payload );
					if (radioButton4.Checked)
					{
						try
						{
							msg = System.Xml.Linq.XElement.Parse( msg ).ToString( );
						}
						catch
						{

						}
					}
					else if (radioButton5.Checked)
					{
						try
						{
							msg = Newtonsoft.Json.Linq.JObject.Parse( msg ).ToString( );
						}
						catch
						{

						}
					}


					if (radioButton2.Checked)
						textBox8.AppendText( msg + Environment.NewLine );
					else if (radioButton1.Checked)
						textBox8.Text = msg;
				} ) );
			}
			catch
			{

			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				 {
					 if(radioButton2.Checked)
						textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				 } ) );
			}
			catch
			{

			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			wsClient?.ConnectClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult send = wsClient.SendServer(  textBox4.Text );

			if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
		}



		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			button5.Enabled = false;
			MessageBox.Show( "暂时不支持" );
			//for (int i = 0; i < testThreadCount; i++)
			//	new Thread( new ThreadStart( ThreadPoolTest ) ) { IsBackground = true }.Start( );
		}

		private void ThreadPoolTest( )
		{
			//WebSocketClient ws = new WebSocketClient( textBox1.Text, int.Parse( textBox2.Text ) );
			//if(ws.ConnectServer( ).IsSuccess)
			//{
				
			//}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUrl, textBox5.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTopic, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox5.Text = element.Attribute( DemoDeviceList.XmlUrl ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlTopic ).Value;
			textBox9.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}


	#endregion
}
