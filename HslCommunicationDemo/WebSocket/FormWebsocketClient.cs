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
using System.Runtime.Remoting.Contexts;

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


			comboBox1.DataSource = DemoUtils.GetEncodings( );
			comboBox1.SelectedIndex = 3;
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
				button_ssl_file.Text = "文件";
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
				label5.Text = "Connect-T:";
				checkBox2.Text = "GET Carray Host?";
				radioButton2.Text = "Append";
				radioButton1.Text = "Coverage";
				checkBox_SSL.Text = "Cert";
			}
		}

		private WebSocketClient wsClient;

		private void button1_Click( object sender, EventArgs e )
		{
			panel2.Enabled = true;

			wsClient?.ConnectClose( );
			if (textBox1.Text.StartsWith( "ws://", StringComparison.OrdinalIgnoreCase ) ||
				textBox1.Text.StartsWith( "wss://", StringComparison.OrdinalIgnoreCase ))
			{
				wsClient = new WebSocketClient( textBox1.Text );//( textBox1.Text, int.Parse(textBox2.Text), textBox5.Text );
			}
			else
			{
				wsClient = new WebSocketClient( textBox1.Text, int.Parse( textBox2.Text ), textBox5.Text );//( textBox1.Text, int.Parse(textBox2.Text), textBox5.Text );
			}
			wsClient.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );
			wsClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			wsClient.OnClientApplicationMessageReceive += WebSocket_OnWebSocketMessageReceived;
			wsClient.GetCarryHostAndPort = checkBox2.Checked;

			if (!int.TryParse( textBox11.Text, out int connectTimeout )){
				MessageBox.Show( "Connect time is not correct!" );
				return;
			}
			wsClient.ConnectTimeOut = connectTimeout;
			//wsClient.OnNetworkError += WsClient_OnNetworkError; // 这里使用内置的处理方式，一般也就够用了。
			if (checkBox_SSL.Checked){
				wsClient.UseSSL( textBox_ssl_ca.Text );
			}

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

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			StringBuilder sb = new StringBuilder( );
			if (textBox1.Text.StartsWith( "ws://", StringComparison.OrdinalIgnoreCase ) ||
				textBox1.Text.StartsWith( "wss://", StringComparison.OrdinalIgnoreCase ))
			{
				sb.AppendLine( $"WebSocketClient wsClient = new WebSocketClient( \"{textBox1.Text}\" );" ); //( textBox1.Text, int.Parse(textBox2.Text), textBox5.Text );
			}
			else
			{
				sb.AppendLine( $"WebSocketClient wsClient = new WebSocketClient( \"{textBox1.Text}\", {int.Parse( textBox2.Text )}, \"{textBox5.Text}\" );" );//( textBox1.Text, int.Parse(textBox2.Text), textBox5.Text );
			}
			sb.AppendLine( $"wsClient.GetCarryHostAndPort = {checkBox2.Checked.ToString( ).ToLower( )};" );
			if (checkBox_SSL.Checked)
			{
				sb.AppendLine( $"wsClient.UseSSL( \"{textBox_ssl_ca.Text}\" );");
			}
			sb.AppendLine( $"wsClient.ConnectTimeOut = {textBox11.Text};" );
			if (string.IsNullOrEmpty( textBox3.Text ))
				sb.AppendLine( $"OperateResult connect = wsClient.ConnectServer( );" );
			else
				sb.AppendLine( $"OperateResult connect = wsClient.ConnectServer( \"{textBox3.Text}\".Split( new char[] {{','}}, StringSplitOptions.RemoveEmptyEntries ) );" );
			sb.AppendLine( $"//wsClient.OnClientApplicationMessageReceive += WebSocket_OnWebSocketMessageReceived;  // 收到数据触发事件" );
			sb.AppendLine( $"//wsClient.SendServer( \"ABCD1234\" );   // 发送数据到服务器上去" );
			textBox8.Text = sb.ToString( );
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
				if (checkBox_logHex.Checked) wsClient.LogNet?.WriteDebug( wsClient.ToString( ), $"OpCode[{message.OpCode}] HasMask[{message.HasMask}] Payload: {message.Payload.ToHexString( ' ' )}" );
				Invoke( new Action( ( ) =>
				{
					string msg = string.Empty;
					if (radioButton_hex.Checked)
					{
						msg = message.Payload.ToHexString( ' ' );
					}
					else
					{
						msg = DemoUtils.GetEncodingFromIndex( comboBox1.SelectedIndex ).GetString( message.Payload );
						if (radioButton4.Checked)
						{
							try
							{
								msg = XElement.Parse( msg ).ToString( );
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
					}

					if (radioButton2.Checked)
						wsClient.LogNet?.WriteInfo( msg );
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
			OperateResult send = wsClient.SendServer( checkBox1.Checked, textBox4.Text );

			if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
		}



		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUrl, textBox5.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTopic, textBox3.Text );
			element.SetAttributeValue( nameof( WebSocketClient.GetCarryHostAndPort ), checkBox2.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox5.Text = element.Attribute( DemoDeviceList.XmlUrl ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlTopic ).Value;
			checkBox2.Checked = GetXmlValue( element, nameof( WebSocketClient.GetCarryHostAndPort ), false, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button_ssl_file_Click( object sender, EventArgs e )
		{
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					textBox_ssl_ca.Text = ofd.FileName;
				}
			}
		}

	}


	#endregion
}
