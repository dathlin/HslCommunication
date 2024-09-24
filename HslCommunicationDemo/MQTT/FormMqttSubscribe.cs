using HslCommunication;
using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

#region Sample

namespace HslCommunicationDemo.MQTT
{
	public partial class FormMqttSubscribe : System.Windows.Forms.Form
	{
		// 将 mqttClient 传递给子窗体
		public FormMqttSubscribe( MqttClient mqttClient )
		{
			InitializeComponent( );

			this.mqttClient = mqttClient;
		}

		private void FormMqttSubscribe_Load( object sender, EventArgs e )
		{
			button8.Enabled = false;
		}


		MqttClient mqttClient = null;

		private void button7_Click( object sender, EventArgs e )
		{
			// 子窗体订阅操作，在子窗体订阅的情况下，一般来说每个子窗体不同的topic主题
			OperateResult send = mqttClient.SubscribeMessage( new string[] { textBox5.Text } );

			if (!send.IsSuccess) MessageBox.Show( "SubscribeMessage Failed:" + send.Message );
			else
			{
				// 获取订阅的信息，绑定本类的触发事件
				SubscribeTopic subscribeTopic = mqttClient.GetSubscribeTopic( textBox5.Text );
				if (subscribeTopic != null) subscribeTopic.OnMqttMessageReceived += FormMqttSubscribe_OnMqttMessageReceived;
				button7.Enabled = false;
				button8.Enabled = true;
			}
		}

		private void FormMqttSubscribe_OnMqttMessageReceived( MqttClient client, MqttApplicationMessage message )
		{
			// 订阅触发，这里举例是显示出来
			try
			{
				string topic = message.Topic;
				byte[] payload = message.Payload;
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

					if (checkBox_long_message_hide.Checked)
					{
						if (msg?.Length > 200)
						{
							msg = msg.Substring( 200 );
						}
					}
					if (radioButton2.Checked)
						textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Topic[{topic}]: " + msg + Environment.NewLine );
					else if (radioButton1.Checked)
						textBox8.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Topic[{topic}]: " + msg;
				} ) );
			}
			catch
			{

			}
		}

		private long receiveCount = 0;


		private void button8_Click( object sender, EventArgs e )
		{
			// 取消订阅操作，需要先解绑注册事件
			SubscribeTopic subscribeTopic = mqttClient.GetSubscribeTopic( textBox5.Text );
			if (subscribeTopic != null)
			{
				subscribeTopic.OnMqttMessageReceived -= FormMqttSubscribe_OnMqttMessageReceived;

				// 取消订阅，为了不影响其他的界面的订阅信息（可能其他子界面也有订阅相同的主题），这里先判断订阅计数，减到 0 才真正的取消订阅
				// 如果你的主题只有一个窗体使用到的话，那么这里就不需要判断，直接取消订阅即可
				if (subscribeTopic.RemoveSubscribeTick( ) <= 0)
				{
					OperateResult send = mqttClient.UnSubscribeMessage( textBox5.Text );

					if (!send.IsSuccess) MessageBox.Show( "UnSubscribeMessage Failed:" + send.Message );
					else
					{
						button7.Enabled = true;
						button8.Enabled = false;
					}
				}
				else
				{
					button7.Enabled = true;
					button8.Enabled = false;
				}
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 清空文本的操作
			textBox8.Clear( );
		}
	}
}

#endregion