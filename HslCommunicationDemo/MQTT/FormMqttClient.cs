using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.MQTT;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.MQTT;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormMqttClient : HslFormContent
	{
		public FormMqttClient( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			panel2.Enabled = false;
			button2.Enabled = false;

			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<MqttQualityOfServiceLevel>( );
			Language( Program.Language );

			listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
		}

		private void ListBox1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			if (listBox1.SelectedItem is string topic)
			{
				textBox5.Text = topic;
			}
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				checkBox_debug_info_show.Text = "调试信息显示";
			}
			else
			{
				Text                   = "Mqtt Client Test";
				label1.Text            = "Ip:";
				label3.Text            = "Port:";
				button1.Text           = "Connect";
				button2.Text           = "Disconnect";
				label7.Text            = "Topic:";
				label8.Text            = "";
				label9.Text            = "Payload:";
				button4.Text           = "Clear";
				label12.Text           = "Receive:";
				button9.Text           = "Press Test";
				button7.Text           = "subscribe";
				button8.Text           = "unsubscribe";
				button_publish.Text    = "Publish";
				button_will_topic.Text = "Will";
				label6.Text            = "ClientID:";
				label2.Text            = "Name:";
				label4.Text            = "Pwd:";
				button3.Text           = "Window-Sub";
				radioButton2.Text      = "Append";
				radioButton1.Text      = "Cover";
				label5.Text            = "Timeout";
				checkBox_long_message_hide.Text = "Long Msg Hide";

			}
		}

		private MqttClient mqttClient;

		private async void button1_Click( object sender, EventArgs e )
		{
			if (checkBox_rsa.Checked && checkBox_SslTls.Checked)
			{
				MessageBox.Show( "无法同时勾选RSA加密通信及SSL加密通信！\r\nIt is not possible to check both RSA encryption and SSL encryption options." );
				return;
			}
			// 连接
			MqttConnectionOptions options = new MqttConnectionOptions( )
			{
				IpAddress       = textBox_ip.Text,
				Port            = int.Parse( textBox2.Text ),
				ClientId        = textBox3.Text,
				KeepAlivePeriod = TimeSpan.FromSeconds(int.Parse(textBox6.Text)),
				UseRSAProvider  = checkBox_rsa.Checked,
				CleanSession    = true,
				UseSSL          = checkBox_SslTls.Checked,
			};
			if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
			}
			if (!string.IsNullOrEmpty( this.mqtt_will_topic ))
			{
				options.WillMessage = new MqttApplicationMessage( )
				{
					Topic   = this.mqtt_will_topic,
					Payload = Encoding.UTF8.GetBytes( this.mqtt_will_message )
				};
			}
			options.CertificateFile = textBox_certificate.Text;
			options.SSLSecure = checkBox_sslSecure.Checked;

			button1.Enabled = false;
			mqttClient?.ConnectClose( );
			mqttClient            = new MqttClient( options );
			mqttClient.LogNet     = new HslCommunication.LogNet.LogNetSingle( string.Empty );
			mqttClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			mqttClient.OnMqttMessageReceived   += MqttClient_OnMqttMessageReceived;
			//mqttClient.OnNetworkError          += MqttClient_OnNetworkError; // 自己来控制异常及重连的操作

			OperateResult connect = await mqttClient.ConnectServerAsync( );

			if(connect.IsSuccess)
			{
				panel2.Enabled  = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled  = true;
				listBox1.DataSource = mqttClient.SubcribeTopics;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );

				code = CodeExampleControl.CreateStringBulider( mqttClient );
			}
			else
			{
				mqttClient = null;
				button1.Enabled = true;
				MessageBox.Show( connect.ToMessageShowString( ) );
			}


		}

		private StringBuilder code = new StringBuilder( );

		private void MqttClient_OnNetworkError( object sender, EventArgs e )
		{
			// 当网络异常的时候触发，可以在此处重连服务器
			if(sender is MqttClient client)
			{
				// 开始重连服务器，直到连接成功为止
				client.LogNet?.WriteInfo( "网络异常，准备10秒后重新连接。" );
				while (true)
				{
					// 每隔10秒重连
					System.Threading.Thread.Sleep( 10_000 );
					client.LogNet?.WriteInfo( "准备重新连接服务器..." );

					// 重连之前需要判断是否关闭了Client，自己重写的异常需要自己手动处理
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

		private long receiveCount = 0;
		private void MqttClient_OnMqttMessageReceived( MqttClient client, MqttApplicationMessage message )
		{
			string topic = message.Topic;
			byte[] payload = message.Payload;
			try
			{
				Invoke( new Action( ( ) =>
				{
					receiveCount++;
					label10.Text = "Receive Count: " + receiveCount;
					string msg = string.Empty;
					if (radioButton_binary.Checked)
					{
						msg = payload.ToHexString( ' ' );
					}
					else if (radioButton_text.Checked)
					{
						msg = Encoding.UTF8.GetString( payload );
					}
					else if (radioButton_xml.Checked)
					{
						try
						{
							msg = XElement.Parse( Encoding.UTF8.GetString( payload ) ).ToString( );
						}
						catch
						{
							msg = Encoding.UTF8.GetString( payload );
						}
					}
					else if (radioButton_json.Checked)
					{
						try
						{
							msg = Newtonsoft.Json.Linq.JObject.Parse( Encoding.UTF8.GetString( payload ) ).ToString( );
						}
						catch
						{
							msg = Encoding.UTF8.GetString( payload );
						}
					}

					bool show = true;
					if (checkBox_regex_filter.Checked)
					{
						show = System.Text.RegularExpressions.Regex.IsMatch( msg, textBox_regex_filter.Text );
					}
					if (!show) return;

					if (checkBox_long_message_hide.Checked)
					{
						if (msg?.Length > 200)
						{
							msg = msg.Substring( 200 );
						}
					}
					if (radioButton2.Checked)
						textBox8.AppendText( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + $" Topic[{topic}] Retain[{message.Retain}]: " + Environment.NewLine + msg + Environment.NewLine );
					else if (radioButton1.Checked)
						textBox8.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Topic[{topic}] Retain[{message.Retain}]: " + Environment.NewLine + msg;
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
				if (checkBox_debug_info_show.Checked && radioButton2.Checked)
				{
					Invoke( new Action( ( ) =>
					 {
						 textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
					 } ) );
				}
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
			panel2.Enabled  = false;

			mqttClient.ConnectClose( );
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// 只推不发布，只针对HSL的MQTT SERVER有效
			if (comboBox1.SelectedItem is MqttQualityOfServiceLevel level)
			{
				OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( )
				{
					QualityOfServiceLevel = level,
					Topic                 = textBox5.Text,
					Payload               = checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ),
					Retain                = checkBox1.Checked                        // 如果为TRUE，该消息在服务器上进行驻留保存，方便客户端连上立即推送
				} );

				if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );

				textBox_code.Text = $"OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( ) {{ QualityOfServiceLevel = " +
					$"QualityOfServiceLevel.{level}, Topic=\"{textBox5.Text}\", " +
					$"Retain={checkBox1.Checked.ToString( ).ToLower( )}, Payload = {(checkBox_publish_isHex.Checked ? ("\"" + textBox4.Text + "\".ToHexBytes( )") : "Encoding.UTF8.GetBytes( \"" + textBox4.Text + "\")")} }}";
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private void Button7_Click( object sender, EventArgs e )
		{
			//OperateResult send = mqttClient.SubscribeMessage( textBox5.Text );
			OperateResult send = mqttClient.SubscribeMessage( new string[] { textBox5.Text } );

			if (!send.IsSuccess) MessageBox.Show( "SubscribeMessage Failed:" + send.Message );
			else listBox1.DataSource = mqttClient.SubcribeTopics;

			textBox_code.Text = $"OperateResult send = mqttClient.SubscribeMessage( new string[] {{\"{textBox5.Text}\"}} );";
		}

		private void Button8_Click( object sender, EventArgs e )
		{
			OperateResult send = mqttClient.UnSubscribeMessage( textBox5.Text );

			if (!send.IsSuccess) MessageBox.Show( "UnSubscribeMessage Failed:" + send.Message );
			else listBox1.DataSource = mqttClient.SubcribeTopics;

			textBox_code.Text = $"OperateResult send = mqttClient.UnSubscribeMessage( \"{textBox5.Text}\" );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			for (int i = 0; i < 20; i++)
			{
				System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolSendTest ),
					new MqttApplicationMessage( )
					{
						QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
						Topic = "ndiwh是本地AIHDniwd",
						Payload = Encoding.UTF8.GetBytes( textBox4.Text + (i + 1) )
					} );
			}
		}

		private async void ThreadPoolSendTest( object obj )
		{
			if (obj is MqttApplicationMessage message)
			{
				for (int i = 0; i < 100; i++)
				{
					await mqttClient.PublishMessageAsync( message );
				}
			}
		}



		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
			element.SetAttributeValue( DemoDeviceList.XmlKeepLive, textBox6.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
			element.SetAttributeValue( "WillTopic", mqtt_will_topic );
			element.SetAttributeValue( "WillMessage", mqtt_will_message );
			element.SetAttributeValue( "certificate", textBox_certificate.Text );
			element.SetAttributeValue( "sslSecure", checkBox_sslSecure.Checked );
			element.SetAttributeValue( "rsa", checkBox_rsa.Checked );
			element.SetAttributeValue( "SSLTLS", checkBox_SslTls.Checked );
			element.SetAttributeValue( "LongMessageHide", checkBox_long_message_hide.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text   = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text   = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox11.Text  = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			textBox6.Text   = element.Attribute( DemoDeviceList.XmlKeepLive ).Value;
			textBox3.Text   = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox9.Text   = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text  = element.Attribute( DemoDeviceList.XmlPassword ).Value;
			mqtt_will_topic = element.Attribute( "WillTopic" ) == null ? string.Empty : element.Attribute( "WillTopic" ).Value;
			mqtt_will_message = element.Attribute( "WillMessage" ) == null ? string.Empty : element.Attribute( "WillMessage" ).Value;
			textBox_certificate.Text = element.Attribute( "certificate" ) == null ? string.Empty : element.Attribute( "certificate" ).Value;
			checkBox_sslSecure.Checked = element.Attribute( "sslSecure" ) == null ? false : bool.Parse( element.Attribute( "sslSecure" ).Value );
			checkBox_rsa.Checked = element.Attribute( "rsa" ) == null ? false : bool.Parse( element.Attribute( "rsa" ).Value );
			checkBox_SslTls.Checked = GetXmlValue( element, "SSLTLS", false, bool.Parse );
			checkBox_long_message_hide.Checked = GetXmlValue( element, "LongMessageHide", false, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}


		private string mqtt_will_topic;
		private string mqtt_will_message;

		private void button_will_topic_Click( object sender, EventArgs e )
		{
			using (FormWillTopicSetting form = new FormWillTopicSetting( mqtt_will_topic, mqtt_will_message ))
			{
				if ( form.ShowDialog() == DialogResult.OK)
				{
					mqtt_will_topic = form.Topic;
					mqtt_will_message = form.Message;
				}
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			FormMqttSubscribe form = new FormMqttSubscribe( mqttClient );
			form.Show( );
		}

		private void button_certificate_Click( object sender, EventArgs e )
		{
			using(OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					textBox_certificate.Text = ofd.FileName;
				}
			}
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			textBox8.Text = code.ToString( ); 
		}
	}


	#endregion
}
