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
			}
		}

		private WebSocketServer wsServer;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				wsServer = new WebSocketServer( );
				wsServer.OnClientApplicationMessageReceive += WebSocket_OnClientApplicationMessageReceive;

				wsServer.IsTopicRetain = checkBox2.Checked;
				wsServer.ServerStart( int.Parse( textBox2.Text ) );
				wsServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				wsServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
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

		Random random = new Random( );
		private void WebSocket_OnClientApplicationMessageReceive( WebSocketSession session, WebSocketMessage message )
		{
			Invoke( new Action( ( ) =>
			{
				if(!isStop)
					textBox8.AppendText( $"OpCode:[{message.OpCode}] Mask:[{message.HasMask}] Payload:[{Encoding.UTF8.GetString( message.Payload )}]" + Environment.NewLine );
			} ) );

			// 应答客户端连接的情况下是需要进行返回数据的，此处演示返回的是原始的数据，追加一个随机数，你可以自己根据业务来决定返回什么数据
			if (session.IsQASession)
			{
				wsServer.SendClientPayload( session, Encoding.UTF8.GetString( message.Payload ) + random.Next( 1000, 10000 ) );
			}
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
			// 发布到指定的客户端ID
			StringBuilder sb = new StringBuilder( );
			for (int i = 0; i < 100 * 1024; i++)
			{
				sb.Append( "2" );
			}
			wsServer.PublishAllClientPayload( sb.ToString( ) );
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
				button7.Text = "继续";
				isStop = true;
			}
			else
			{
				isStop = false;
				button7.Text = "暂停";
			}
		}
	}


	#endregion
}
