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
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormWebsocketQANet : HslFormContent
	{
		public FormWebsocketQANet( )
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
				Text = "Websocket同步访问客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label9.Text = "Payload：";
				button3.Text = "发送";
				button4.Text = "清空";
				label12.Text = "接收：";
				button5.Text = "压力测试";
			}
			else
			{
				Text = "Websocket QA Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label9.Text = "Payload:";
				button3.Text = "Send";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				button5.Text = "Press Test";
			}
		}

		private WebSocketQANet wsClient;

		private void button1_Click( object sender, EventArgs e )
		{
			panel2.Enabled = true;
			if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				
			}

			wsClient = new WebSocketQANet( textBox1.Text, int.Parse(textBox2.Text) );
			wsClient.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );
			wsClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

			if (checkBox_ssl_tls.Checked)
			{
				wsClient.CommunicationPipe = new PipeSslNet( textBox1.Text, int.Parse( textBox2.Text ), serverMode: false ); // 如果选中SSL的话，管道就切换为SSL
			}

			OperateResult connect = null;
			connect = wsClient.ConnectServer( );
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

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				 {
					 if (checkBox_hex_log.Checked == false && e.HslMessage.Degree == HslCommunication.LogNet.HslMessageDegree.DEBUG) return;
					 if (radioButton2.Checked)
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

			wsClient.ConnectClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = wsClient.ReadFromServer(  textBox4.Text );

			if (read.IsSuccess)
			{
				string msg = read.Content;
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
					wsClient.LogNet?.WriteInfo( msg );
				else if (radioButton1.Checked)
					textBox8.Text = msg;
			}
			else
			{
				MessageBox.Show( "read Failed:" + read.Message );
			}
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
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
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
