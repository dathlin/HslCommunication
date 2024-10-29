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
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormWebsocketServer : HslFormContent
	{
		public FormWebsocketServer( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			Language( Program.Language );

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
			}
		}

		private Timer timer1s;

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
				label12.Text = "接收：";
				checkBox2.Text = "是否开启订阅缓存";
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
				label12.Text = "Receive:";
				checkBox2.Text = "Start Topic Cache";
				checkBox3.Text = "Send test message back when client connect";
				button8.Text = "web test";
				checkBox_willcard.Text = "Topic willcard?";
				button6.Text = "Broadcast";
				button7.Text = "Stop";

			}
		}

		private WebSocketServer wsServer;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				wsServer = new WebSocketServer( );
				wsServer.OnClientApplicationMessageReceive += WebSocket_OnClientApplicationMessageReceive;
				wsServer.OnClientConnected += WsServer_OnClientConnected;

				wsServer.IsTopicRetain = checkBox2.Checked;

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
				MessageBox.Show( "Start Success" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Start Failed : " + ex.Message );
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
		private void WebSocket_OnClientApplicationMessageReceive( WebSocketSession session, WebSocketMessage message )
		{
			// 应答客户端连接的情况下是需要进行返回数据的，此处演示返回的是原始的数据，追加一个随机数，你可以自己根据业务来决定返回什么数据
			if (session.IsQASession)
			{
				wsServer.SendClientPayload( session, Encoding.UTF8.GetString( message.Payload ) + " " + random.Next( 1000, 10000 ) );
			}
			Invoke( new Action( ( ) =>
			{
				if(!isStop)
					textBox8.AppendText( $"OpCode:[{message.OpCode}] Mask:[{message.HasMask}] Payload:[{Encoding.UTF8.GetString( message.Payload )}]" + Environment.NewLine );
			} ) );
			// wsServer.AddSessionTopic( session, Encoding.UTF8.GetString( message.Payload ) );
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			 } ) );
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
			wsServer.PublishAllClientPayload( textBox4.Text );
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
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox2.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlTagCache ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRetureMessage ).Value );
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
	}


	#endregion
}
