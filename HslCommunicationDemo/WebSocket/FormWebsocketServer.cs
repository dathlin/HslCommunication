using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.WebSocket;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormWebsocketServer : HslFormContent
	{
		public FormWebsocketServer( )
		{
			InitializeComponent( );

			checkBox4.CheckedChanged +=CheckBox4_CheckedChanged;
			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			dataForwardControl = new DataForwardControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl1, dataForwardControl, false, DataForwardControl.GetTitle( ) );
		}

		private void CheckBox4_CheckedChanged( object sender, EventArgs e )
		{
			if (wsServer != null)
			{
				wsServer.DataCompress = checkBox4.Checked;
			}
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			comboBox1.SelectedIndex = 0;

			Language( Program.Language );

			if (Program.Language == 1)
			{
				textBox_client_subscribe.Text = @"HslCommunication's WebSocketServer 内置的订阅功能

方式一：
连接的Http的Header里新增一行  HslSubscribes:A,B

方式二：
客户端连接的Url里使用信息  ws://127.0.0.1:1883/HslSubscribes=A,B
";
				textBox_client_subscribe2.Text = @"本Dmeo界面支持的方式三：
直接发送一个文本消息，内容为一个 Json 格式的数据，示例：
{
    ""Command"": ""Subscribe"",
    ""Topic"": ""A""
}

取消订阅的消息格式为：
{
    ""Command"": ""UnSubscribe"",
    ""Topic"": ""A""
}";
			}
			else
			{
				textBox_client_subscribe.Text = @"Built-in Subscription Function of HslCommunication's WebSocketServer

Method 1:
Add a new line to the connected HTTP header: HslSubscribes:A,B

Method 2:
Include the parameter in the client connection URL: ws://127.0.0.1:1883/HslSubscribes=A,B
";
				textBox_client_subscribe2.Text = @"Method 3 supported by this Demo interface:：
Send a text message directly with the content in JSON format. Example:
{
    ""Command"": ""Subscribe"",
    ""Topic"": ""A""
}

The message format for unsubscription is as follows:
{
    ""Command"": ""UnSubscribe"",
    ""Topic"": ""A""
}";
			}

			timer1s = new Timer( );
			timer1s.Interval = 1000;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start( );
		}

		private void Timer1s_Tick( object sender, EventArgs e )
		{
			if (wsServer != null)
			{
				label2.Text = "Online Count:" + wsServer.OnlineCount;
				listBox1.DataSource = wsServer.OnlineSessions;

				if (Program.Language == 1)
					label_tick.Text = "接收次数: " + this.count;
				else
					label_tick.Text = "Recv Tick: " + this.count;

				if (Program.Language == 1)
					label_bytes_length.Text = "接收字节: " + this.bytes_length;
				else
					label_bytes_length.Text = "Recv Bytes: " + this.bytes_length;
			}
		}

		private Timer timer1s;
		private CodeExampleControl codeExampleControl;
		private DataForwardControl dataForwardControl;

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "Websocket服务器";
				label3.Text = "端口：";
				button1.Text = "启动服务";
				button2.Text = "关闭服务";
				button5.Text = "广播100K数据";
				label7.Text = "Topic：";
				label8.Text = "主题";
				label9.Text = "Payload：";
				button3.Text = "广播内容";
				button4.Text = "清空";
				tabPage1.Text = "数据接收";
				checkBox2.Text = "是否开启订阅缓存";
				tabPage3.Text = "主题列表";
			}
			else
			{
				Text = "Websocket Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button5.Text = "Publish 100K Data";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button3.Text = "Publish Payload";
				button4.Text = "Clear";
				tabPage1.Text = "Data Receive";
				checkBox2.Text = "Start Topic Cache";
				checkBox3.Text = "Send test message back when client connect";
				button8.Text = "web test";
				checkBox_willcard.Text = "Topic willcard?";
				button6.Text = "Broadcast";
				button7.Text = "Stop";
				checkBox4.Text = "DataCompress";
				tabPage2.Text = "Client Subscribe";
				checkBox_debug.Text = "Show Heartbeat Log";
			}
		}

		private WebSocketServer wsServer;

		private void FormWebsocketServer_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				wsServer = new WebSocketServer( );
				wsServer.OnClientApplicationMessageReceive += WebSocket_OnClientApplicationMessageReceive;
				wsServer.OnClientConnected += WsServer_OnClientConnected;

				wsServer.IsTopicRetain = checkBox2.Checked;
				wsServer.DataCompress = checkBox4.Checked;

				if (checkBox_ssl.Checked)
				{
					wsServer.UseSSL( textBox_certFile.Text, textBox_ssl_password.Text );
				}
				wsServer.ServerStart( int.Parse( textBox2.Text ) );
				wsServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				wsServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				wsServer.TopicWildcard = checkBox_willcard.Checked;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				DemoUtils.ShowMessage( "Start Success" );

				StringBuilder stringBuilder = new StringBuilder( );
				stringBuilder.AppendLine( "WebSocketServer wsServer = new WebSocketServer( );" );
				stringBuilder.AppendLine( $"wsServer.IsTopicRetain = {checkBox2.Checked};" );
				if (wsServer.DataCompress) stringBuilder.AppendLine( $"wsServer.DataCompress = true;" );
				if (checkBox_ssl.Checked)
				{
					stringBuilder.AppendLine( $"wsServer.UseSSL( \"{textBox_certFile.Text}\", \"{textBox_ssl_password.Text}\" );" );
				}
				stringBuilder.Append( $"wsServer.ServerStart( {int.Parse( textBox2.Text )} );" );
				codeExampleControl.RenderExampleCode( stringBuilder );

				this.dataForwardControl.SetWebSocketServer( wsServer, this.AddTopic );
				count = 0;   // 重置接收数据的次数
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Start Failed : " + ex.Message );
			}
		}

		private void WsServer_OnClientConnected( WebSocketSession session )
		{
			// 当客户端刚连上来的时候可以选择回发数据操作，具体取决于你的业务逻辑
			// 这里的逻辑是并且这个会话不是"同步问答"会话的情况下
			if (checkBox3.Checked && session.IsQASession == false)
			{
				wsServer.SendClientPayload( session, "This a test message when client connect, url:" + session.Url );
			}
		}

		Random random = new Random( );
		private long count = 0; // 统计接收的次数
		private long bytes_length = 0; // 统计接收的字节数

		private void WebSocket_OnClientApplicationMessageReceive( WebSocketSession session, WebSocketMessage message )
		{
			this.count++;
			if (message.Payload != null) this.bytes_length += message.Payload.Length;

			// 应答客户端连接的情况下是需要进行返回数据的，此处演示返回的是原始的数据，追加一个随机数，你可以自己根据业务来决定返回什么数据
			if (session.IsQASession)
			{
				wsServer.SendClientPayload( session, Encoding.UTF8.GetString( message.Payload ) + " " + random.Next( 1000, 10000 ) );
			}
			string content = string.Empty;
			if (message.OpCode == 1)
			{
				content = Encoding.UTF8.GetString( message.Payload );
			}
			else
			{
				content = message.Payload.ToHexString( ' ' );
			}
			wsServer.LogNet?.WriteInfo( wsServer.ToString( ), $"From {session.Communication} : OpCode[{message.OpCode}] Mask[{message.HasMask}] Payload: {content}" );


			if (message.Payload?.Length > 20)
			{
				try
				{
					content = content.Trim( ' ', '\r', '\n' );
					if (!content.StartsWith( "{" ) || !content.EndsWith( "}" )) return;
					JObject para = JObject.Parse( content );

					string command = para["Command"].Value<string>( );
					string topic = para["Topic"].Value<string>( );

					if (command == "Subscribe")
					{
						wsServer.AddSessionTopic( session, topic );
						wsServer.LogNet?.WriteInfo( wsServer.ToString( ), $"{session.Communication} Subscribe {topic} Success!" );
					}
					else if (command == "UnSubscribe")
					{
						if (wsServer.RemoveSessionTopic( session, topic ))
							wsServer.LogNet?.WriteInfo( wsServer.ToString( ), $"{session.Communication} UnSubscribe {topic} Success!" );
						else
							wsServer.LogNet?.WriteInfo( wsServer.ToString( ), $"{session.Communication} UnSubscribe {topic} Failed!" );
					}
				}
				catch
				{

				}
			}
			// wsServer.AddSessionTopic( session, Encoding.UTF8.GetString( message.Payload ) );
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			if (!isStop)
			{
				if (e.HslMessage.Degree == HslCommunication.LogNet.HslMessageDegree.DEBUG && !checkBox_debug.Checked)
				{
					if (e.HslMessage.Text.Contains( "PING" ) || e.HslMessage.Text.Contains( "PONG" ))
						return;
				}
				Invoke( new Action( ( ) =>
				 {
					 textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				 } ) );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button5.Enabled = true;
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			wsServer.ServerClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if (comboBox1.SelectedIndex == 0)
			{
				wsServer.PublishAllClientPayload( textBox4.Text );
				string content = JsonConvert.SerializeObject( textBox4.Text );
				codeExampleControl.RenderRightExampleCode( $"wsServer.PublishAllClientPayload( {content} );  // opCode = 1" );
			}
			else
			{
				wsServer.PublishAllClientPayload( textBox4.Text.ToHexBytes( ) );
				codeExampleControl.RenderRightExampleCode( $"wsServer.PublishAllClientPayload( \"{textBox4.Text}\".ToHexBytes( ) ); // opCode = 2" );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private void Button5_Click( object sender, EventArgs e )
		{
			// 发布100K数据
			StringBuilder sb = new StringBuilder( );
			for (int i = 0; i < 100 * 1024; i++)
			{
				sb.Append( "2" );
			}
			wsServer.PublishAllClientPayload( sb.ToString( ) );
		}

		private bool startThreadPublish = false;
		private System.Threading.Thread thread;
		private void button9_Click( object sender, EventArgs e )
		{
			if (startThreadPublish)
			{
				startThreadPublish = false;
				button9.Text = "高频发布测试";
			}
			else
			{
				startThreadPublish = true;
				button9.Text = Program.Language == 1 ? "停止" : "Stop";
				if (thread == null)
				{
					thread = new System.Threading.Thread( new System.Threading.ThreadStart( ThreadTest ) );
					thread.IsBackground = true;
					thread.Start( );
				}
			}
		}
		private void ThreadTest( )
		{
			int timeCost = 0;
			while (true)
			{
				System.Threading.Thread.Sleep( 200 );
				if (startThreadPublish)
				{
					DateTime start = DateTime.Now;
					for (int i = 0; i < 10; i++)
					{
						byte[] buffer = new byte[1024];
						random.NextBytes( buffer );
						wsServer.PublishAllClientPayload( buffer.ToHexString( ) + "\r\n" + "上次平均耗时：" + timeCost + "ms" );
					}
					timeCost = Convert.ToInt32( (DateTime.Now - start).TotalSeconds / 10 );
				}
			}
		}

		private void button6_Click_1( object sender, EventArgs e )
		{
			// 发布指定的主题
			wsServer.PublishClientPayload( textBox5.Text, textBox4.Text );
			string content = JsonConvert.SerializeObject( textBox4.Text );
			codeExampleControl.RenderRightExampleCode( $"wsServer.PublishClientPayload( \"{textBox5.Text}\", \"{content}\" );  // opCode = 1" );

			AddTopic( textBox5.Text, textBox4.Text, null );
		}

		bool isStop = false;
		private void button7_Click( object sender, EventArgs e )
		{
			if (!isStop)
			{
				button7.Text = Program.Language == 1 ? "继续" : "Continue";
				isStop = true;
			}
			else
			{
				isStop = false;
				button7.Text = Program.Language == 1 ? "暂停" : "Stop";
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			string content = $@"<html>
	<head>
		<title>
			测试的websocket信息-hslcommunication
		</title>
	</head>
	<body>
		<div id=""hsl""></div>
	</body>
	<script type=""text/javascript"">
		if (""WebSocket"" in window)
		{{
			// 打开一个 web socket
			var ws = new WebSocket('ws{(checkBox_ssl.Checked?"s":"")}://127.0.0.1:{textBox2.Text}');
			var count = 0;
			ws.onopen = function()
			{{
				 console.log('已经打开...');
			}};
			ws.onmessage = function (evt)
			{{
				var received_msg = evt.data;
				var obj = document.getElementById('hsl');
				obj.innerText = received_msg;
				count++;
			}};
			var int=self.setInterval(""clock()"",1000);
			function clock()
			{{
				 console.log('接收次数:' + count);
			}}
		}}
		else
		{{
			var obj = document.getElementById('hsl');
			obj.innerText = '您的浏览器不支持 WebSocket!';
		}}
	</script>
</html>";
			try
			{
				System.IO.File.WriteAllText( "websocket.html", content, Encoding.UTF8 );
				System.Diagnostics.Process.Start( "websocket.html" );
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTagCache, checkBox2.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlRetureMessage, checkBox3.Checked );
			element.SetAttributeValue( nameof( WebSocketServer.DataCompress ), checkBox4.Checked );

			this.dataForwardControl.SaveToXml( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox2.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlTagCache ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRetureMessage ).Value );
			checkBox4.Checked = GetXmlValue( element, nameof( WebSocketServer.DataCompress ), false, bool.Parse );

			this.dataForwardControl.LoadFromXml( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button10_Click( object sender, EventArgs e )
		{
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					textBox_certFile.Text = ofd.FileName;
				}
			}
		}



		#region Topics Mangment

		private Dictionary<string, WebSocketTopic> topics = new Dictionary<string, WebSocketTopic>( );
		private WebSocketTopic selectedTopic = null;

		private void AddTopic( string topic, string payload, WebSocketSession session )
		{
			if (topics.ContainsKey( topic ))
			{
				topics[topic].Payload = payload;
				topics[topic].Time = DateTime.Now;
				topics[topic].PublishCount++;
				topics[topic].session = session;
			}
			else
			{
				topics.Add( topic, new WebSocketTopic( )
				{
					Topic = topic,
					Payload = payload,
					Time = DateTime.Now,
					PublishCount = 1,
					session = session
				} );
			}
			RefreshTopicList( );
		}

		private void RefreshTopicList( )
		{
			if (InvokeRequired)
			{
				Invoke( new Action( RefreshTopicList ) );
				return;
			}


			DemoUtils.DataGridSpecifyRowCount( dataGridView1, topics.Count );
			int index = 0;
			foreach (var item in topics.Values)
			{
				dataGridView1.Rows[index].Cells[0].Value = (index + 1);
				dataGridView1.Rows[index].Cells[1].Value = item.Topic;
				dataGridView1.Rows[index].Cells[2].Value = item.PublishCount;
				dataGridView1.Rows[index].Tag = item;

				if (object.ReferenceEquals( selectedTopic, item ))
				{
					RenderSelectedTopic( );
				}
				index++;
			}

		}

		private void RenderSelectedTopic( )
		{
			if (selectedTopic != null)
			{
				textBox_topic_publishSession.Text = selectedTopic.session == null ? "" : selectedTopic.session.Communication.ToString( );
				textBox_topic_topic.Text = selectedTopic.Topic;
				if (selectedTopic.Payload != null)
					textBox_topic_payload.Text = selectedTopic.Payload;
				else
					textBox_topic_payload.Text = string.Empty;
				textBox_topic_publishTime.Text = selectedTopic.Time.ToString( DemoUtils.DateTimeFormate );
				label_topic_size.Text = (selectedTopic.Payload?.Length ?? 0).ToString( );
			}
		}

		private void dataGridView1_CellClick( object sender, DataGridViewCellEventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Tag is WebSocketTopic topic)
				{
					selectedTopic = topic;
					RenderSelectedTopic( );
				}
			}
		}

		#endregion

	}

	public class WebSocketTopic
	{
		public string Topic { get; set; }

		public string Payload { get; set; }

		public DateTime Time { get; set; }

		public int PublishCount { get; set; }

		public WebSocketSession session { get; set; }

		public override string ToString( )
		{
			return $"Topic:{Topic}, Payload Length:{Payload?.Length}, Time:{Time}, PublishCount:{PublishCount}";
		}
	}


	#endregion
}
