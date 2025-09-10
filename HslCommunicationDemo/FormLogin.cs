using HslCommunication;
using HslCommunication.MQTT;
using HslCommunicationDemo.Properties;
using HslRedisDesktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormLogin : System.Windows.Forms.Form
	{
		public FormLogin( )
		{
			InitializeComponent( );
			this.Icon = DemoUtils.ConvertToIcon( Resources.HslCommunication );
		}

		private void FormLogin_Load( object sender, EventArgs e )
		{
			string name = HslCommunicationDemo.Settings1.Default.LoginName;
			//string password = HslCommunicationDemo.Settings1.Default.LoginPassword;

			textBox1.Text = name;
			//textBox2.Text = password;

			if (Program.Language == 1)
				label3.Text = Program.SystemName;
			else
			{
				label1.Text = "UserName:";
				label2.Text = "Password:";
				label3.Text = "Industrial equipment debugging system";
				button1.Text = "Login";
			}


		}

		private void button1_Click( object sender, EventArgs e )
		{
			mqttSyncClient = new MqttSyncClient( new MqttConnectionOptions( )
			{
				IpAddress = "118.195.180.167",
				Port = 7790,
				UseRSAProvider = true,
			} );


			mqttSyncClient.ConnectionOptions.Credentials = new MqttCredential( )
			{
				UserName = textBox1.Text,
				Password = textBox2.Text
			};

			OperateResult connect = mqttSyncClient.ConnectServer( );
			if (connect.IsSuccess == false)
			{
				DemoUtils.ShowMessage( "连接失败：" + connect.Message );
				return;
			}
			// 连接成功，保存用户名和密码
			// 请求已经注册的证书列表
			OperateResult<List<byte[]>> read = mqttSyncClient.ReadRpc<List<byte[]>>( "GetAllCertificate", "" );
			if (read.IsSuccess == false)
			{
				DemoUtils.ShowMessage( "读取证书列表失败: " + read.Message );
				return;
			}


			if (true)
			{
				HslCommunicationDemo.Settings1.Default.LoginName = textBox1.Text;
				//HslCommunicationDemo.Settings1.Default.LoginPassword = textBox2.Text;
				HslCommunicationDemo.Settings1.Default.Save( );
				DialogResult = DialogResult.OK;
			}
			else
			{
				DemoUtils.ShowMessage( "用户名或密码错误，请重新输入！" );
			}
		}

		public MqttSyncClient GetMqttSyncClient() { return mqttSyncClient; }

		private MqttSyncClient mqttSyncClient;

		private void FormLogin_Shown( object sender, EventArgs e )
		{
			textBox2.Focus( );
		}
	}
}
