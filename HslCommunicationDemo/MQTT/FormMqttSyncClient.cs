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
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region FormMqttSyncClient


	public partial class FormMqttSyncClient : HslFormContent
	{
		public FormMqttSyncClient( )
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
				Text = "Mqtt同步客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label7.Text = "Topic：";
				label8.Text = "主题";
				label9.Text = "Payload：";
				button4.Text = "清空";
				label12.Text = "接收：";
			}
			else
			{
				Text = "Mqtt Sync Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button3.Text = "most one";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				button3.Text = "Read";
			}
		}

		private MqttSyncClient mqttSyncClient;

		private async void button1_Click( object sender, EventArgs e )
		{
			// 连接
			MqttConnectionOptions options = new MqttConnectionOptions( )
			{
				IpAddress = textBox1.Text,
				Port = int.Parse( textBox2.Text ),
				ClientId = textBox3.Text,
			};
			if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
			}

			button1.Enabled = false;
			mqttSyncClient = new MqttSyncClient( options );
			OperateResult connect = await mqttSyncClient.ConnectServerAsync( );

			if(connect.IsSuccess)
			{
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				button1.Enabled = true;
				MessageBox.Show( connect.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			mqttSyncClient.ConnectClose( );
		}

		private void SendProgressReport(long already, long total )
		{
			// already : 已发送的字节数
			// total : 总计发送的字节数
			if (InvokeRequired)
			{
				Invoke( new Action<long, long>( SendProgressReport ), already, total );
				return;
			}

			hslProgress1.Value = (int)(already * 100 / total);
		}

		private void ReceiveProgressReport( long already, long total )
		{
			// already : 已接收的字节数
			// total : 总计接收的字节数
			if (InvokeRequired)
			{
				Invoke( new Action<long, long>( ReceiveProgressReport ), already, total );
				return;
			}

			hslProgress2.Value = (int)(already * 100 / total);
		}


		private async void button3_Click( object sender, EventArgs e )
		{
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button3.Enabled = false;
			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync(
				textBox5.Text, Encoding.UTF8.GetBytes( textBox4.Text ),
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) );
			button3.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Read Failed:" + read.Message ); return; }

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg;
		}


		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 大批量数据上传的情况
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button5.Enabled = false;

			// 编造一条1M的数据
			byte[] buffer = new byte[1024 * 1024];
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = 0x30;
			}

			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync( textBox5.Text, buffer,
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) ) ;
			button5.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Rend Failed:" + read.Message ); return; }

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg;
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button6.Enabled = false;
			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync(
				"C", Encoding.UTF8.GetBytes( textBox4.Text ),
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) );
			button6.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Rend Failed:" + read.Message ); return; }

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg?.Length > 100 ? msg.Substring( 0, 100 ) + "..." : msg;
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
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
