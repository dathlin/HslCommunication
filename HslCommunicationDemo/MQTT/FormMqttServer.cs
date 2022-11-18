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
using HslCommunication.Reflection;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Core;
using System.Security.Cryptography;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormMqttServer : HslFormContent
	{
		public FormMqttServer( )
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
			if (mqttServer != null)
			{
				label2.Text = "Online Count:" + mqttServer.OnlineCount;
				label4.Text = "Receive Count:" + receiveCount;
				listBox1.DataSource = mqttServer.OnlineSessions;
			}
		}

		private Timer timer1s;

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "Mqtt Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button5.Text = "Publish Id";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button3.Text = "Publish All";
				button4.Text = "Clear";
				button6.Text = "Publish";
				label12.Text = "Receive:";
				checkBox3.Text = "Send test message back when client connect";
				checkBox2.Text = "Willcards";
			}
		}

		private MqttServer mqttServer;
		private SiemensS7Net siemens;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				siemens = new SiemensS7Net( SiemensPLCS.S1200, "127.0.0.1" );
				siemens.SetPersistentConnection( );

				mqttServer = new MqttServer( );
				mqttServer.OnClientApplicationMessageReceive += MqttServer_OnClientApplicationMessageReceive;
				mqttServer.OnClientConnected                 += MqttServer_OnClientConnected;
				mqttServer.TopicWildcard = checkBox2.Checked;
				if (checkBox1.Checked)
				{
					mqttServer.ClientVerification += MqttServer_ClientVerification;
				}

				mqttServer.RegisterMqttRpcApi( "Account", this );
				mqttServer.RegisterMqttRpcApi( "Siemens", siemens );               // 注册一个西门子PLC的服务接口的示例
				mqttServer.RegisterMqttRpcApi( "TimeOut", typeof(HslTimeOut) );    // 注册的类的静态方法和静态属性
				mqttServer.RegisterMqttRpcApi( "Fanuc",   new HslCommunication.CNC.Fanuc.FanucSeries0i( "127.0.0.1" ) );
				mqttServer.RegisterMqttRpcApi( "PCCC", new HslCommunication.Profinet.AllenBradley.AllenBradleyPcccNet( "127.0.0.1" ) );
				mqttServer.ServerStart( int.Parse( textBox2.Text ) );
				mqttServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				mqttServer.RegisterMqttRpcApi( "Log", mqttServer.LogNet );
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

		private void button8_Click( object sender, EventArgs e )
		{
			//button8.Enabled = false;
			timerPublish = new System.Threading.Timer( new System.Threading.TimerCallback( TimerPublish ), null, 0, 1000 );
		}

		private System.Threading.Timer timerPublish;
		private int publishTick = 0;
		private void TimerPublish( object obj )
		{
			mqttServer.PublishTopicPayload( "A", Encoding.UTF8.GetBytes( "A" + publishTick ) );
			mqttServer.PublishTopicPayload( "B", Encoding.UTF8.GetBytes( "B" + publishTick ) );
			mqttServer.PublishTopicPayload( "C", Encoding.UTF8.GetBytes( "C" + publishTick ) );
			mqttServer.PublishTopicPayload( "D", Encoding.UTF8.GetBytes( "D" + publishTick ) );
			publishTick++;
		}

		private void MqttServer_OnClientConnected( MqttSession session )
		{
			if (checkBox3.Checked)
			{
				// 当客户端连接上来时，可以立即返回一些数据内容信息
				mqttServer.PublishTopicPayload( session, "HslMqtt", Encoding.UTF8.GetBytes( "This is a test message" ) );
			}
		}

		private int MqttServer_ClientVerification( MqttSession mqttSession, string clientId, string userName, string passwrod )
		{
			if (userName == "hsl") mqttSession.DeveloperPermissions = false;      // hsl不具备开发者权限，无法遍历接口
			if (userName == "admin" && passwrod == "123456") return 0; // 成功
			if (userName == "hsl" && passwrod == "123456") return 0; // 成功
			return 5; // 账号密码验证失败
		}

		private long receiveCount = 0;

		private void MqttServer_OnClientApplicationMessageReceive( MqttSession session, MqttClientApplicationMessage message )
		{
			if (message.Topic == "ndiwh是本地AIHDniwd")   // 用户客户端的压力测试
			{
				mqttServer.PublishTopicPayload( session, message.Topic, message.Payload );
			}

			if (session.Protocol == "HUSL")
			{
				// 当前的会话是同步通信的情况
				if (message.Topic == "A")
				{
					// 测试回传一条数据信息
					mqttServer.PublishTopicPayload( session, "B", Encoding.UTF8.GetBytes( "这是回传的一条测试数据" ) );
				}
				else if (message.Topic == "B")
				{
					System.Threading.Thread.Sleep( 1000 );
					// 假设服务器处理数据要耗费10秒钟
					for (int i = 0; i < 10; i++)
					{
						System.Threading.Thread.Sleep( 1000 );
						mqttServer.ReportProgress( session, ((i + 1) * 10).ToString( ), $"当前正在处理{i + 1}步" );
					}
					System.Threading.Thread.Sleep( 1000 );
					mqttServer.PublishTopicPayload( session, StringResources.Language.SuccessText, Encoding.UTF8.GetBytes( "B操作处理成功" ) );
				}
				else if (message.Topic == "C")
				{
					// 回传一条1M的数据
					byte[] buffer = new byte[1024 * 1024];
					for (int i = 0; i < buffer.Length; i++)
					{
						buffer[i] = 0x30;
					}
					mqttServer.PublishTopicPayload( session, "C", buffer );
				}
				else if (message.Topic == "D")
				{
					// 返回一条操作失败的信息
					mqttServer.ReportOperateResult( session, "当前的功能码不支持！" );
				}
				else if (message.Topic == "E")
				{
					// 返回一条操作结果的信息
					if (random.Next( 100 ) < 50)
						mqttServer.ReportOperateResult( session, new OperateResult<string>( "当前的结果为失败信息" ) );
					else
						mqttServer.ReportOperateResult( session, OperateResult.CreateSuccessResult( "成功" ) );

				}
				else if (message.Topic == "F")
				{
					// 返回当前对象支持的API信息
					mqttServer.PublishTopicPayload( session, "list", Encoding.UTF8.GetBytes( JArray.FromObject( MqttHelper.GetSyncServicesApiInformationFromObject( this ) ).ToString( ) ) );
				}
				else
				{
					// 如果不回传数据，客户端就会引发超时，关闭连接


					// 下面是示例，支持了一个CheckName的接口数据，返回类型必须是 OperateResult<string>
					// mqttServer.ReportObjectApiMethod( session, message, this );
				}
			}

			Invoke( new Action( ( ) =>
			{
				if (!isStop)
				{
					receiveCount++;
					if (message.Payload?.Length > 100 && checkBox_long_message_hide.Checked)
					{
						if (checkBox_receive_isHex.Checked)
							textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload:[{message.Payload.SelectBegin( 100 ).ToHexString( ' ' )}...]" + Environment.NewLine );
						else
							textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload:[{Encoding.UTF8.GetString( message.Payload.SelectBegin( 100 ) )}...]" + Environment.NewLine );
					}
					else
					{
						if (checkBox_receive_isHex.Checked)
							textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload:[{message.Payload.ToHexString(' ')}]" + Environment.NewLine );
						else
							textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + $" Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload:[{Encoding.UTF8.GetString( message.Payload )}]" + Environment.NewLine );
					}
				}
			} ) );
		}

		[HslMqttApi("检查账户的信息")]
		[HslMqttPermission(ClientID ="AAA")]
		public OperateResult<string> CheckName(string name, short value )
		{
			if (value < 10) return new OperateResult<string>( "值不能小于10" );
			return OperateResult.CreateSuccessResult( "成功:" + name + " 年龄:" + value );
		}

		[HslMqttApi( "读取设备的信息，\r\naddress: 设备的地址 \r\nlength: 读取的数据长度" )]
		public OperateResult<string> ReadInt( string address, short length )
		{
			return OperateResult.CreateSuccessResult( "成功:" + address );
		}

		[HslMqttApi( "读取设备的信息，address: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<int, string> ReadABC( string address )
		{
			return OperateResult.CreateSuccessResult( random.Next(1000), "成功:" + address );
		}

		[HslMqttApi( "读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<short> ReadInt16( string address = "100", short length = 10 )
		{
			return OperateResult.CreateSuccessResult( (short)random.Next( 10000 ) );
		}

		[HslMqttApi( "读取设备的Int16数组信息，address: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<short[]> ReadInt16Array( string address, short length )
		{
			short[] array = new short[10];
			for (int i = 0; i < 10; i++)
			{
				array[i] = (short)random.Next( 10000 );
			}
			return OperateResult.CreateSuccessResult( array );
		}

		[HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
		public async Task<short> ReadDatabaseAsync( string abc = "123" )
		{
			await Task.Delay( 1000 );
			return await Task.FromResult( short.Parse( abc ) );
		}

		[HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
		public Task WriteDatabaseAsync( string abc = "123" )
		{
			return Task.Delay( 500 );
		}

		[HslMqttApi( "读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度" )]
		public short ReadFloat( ISessionContext context, string address, short length = 12345 )
		{
			if (context.UserName != "hsl") return -100;
			return (short)random.Next( 10000 );
		}

		[HslMqttApi( "读取设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度" )]
		public Student ReadStudent( string address = "M100", short length = 10 )
		{
			return new Student( ) { Name = "张三", Age = 23, ID = "1012312321" };
		}

		[HslMqttApi( "读取设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<Student> ReadStudentResult( string address, short length )
		{
			if (random.Next( 1000 ) < 500)
			{
				return OperateResult.CreateSuccessResult( new Student( ) { Name = "张三", Age = 23, ID = "1012312321" } );
			}
			else
			{
				return new OperateResult<Student>( "读取失败" );
			}
		}

		[HslMqttApi( Description = "写入设备的多个学生信息\r\naddress: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<string> WriteMultiStudentResult( string address, short length, Student[] student )
		{
			if (random.Next( 1000 ) < 500)
			{
				if (student == null) return new OperateResult<string>( "student is null" );
				for (int i = 0; i < student.Length; i++)
				{

				}
				return OperateResult.CreateSuccessResult( $"学生信息写入成功，数组数量：{student.Length} ID列表:{student.Select( m => m.ID ).ToArray( ).ToArrayString( )}" );
			}
			else
			{
				return new OperateResult<string>( "写入失败" );
			}
		}

		[HslMqttApi( Description = "写入设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<string> WriteStudentResult( string address, short length, Student student )
		{
			if (random.Next( 1000 ) < 500)
			{
				if(student== null) return new OperateResult<string>( "student is null" );
				return OperateResult.CreateSuccessResult( $"学生信息写入成功：ID:{student.ID} Name:{student.Name}" );
			}
			else
			{
				return new OperateResult<string>( "写入失败" );
			}
		}

		[HslMqttApi( "启动设备的接口信息")]
		public OperateResult<string> StartDevice( DateTime start )
		{
			return OperateResult.CreateSuccessResult( start.ToString( ) );
		}

		[HslMqttApi( "StopDevice", "关闭设备的接口信息" )]
		public OperateResult<int> asdgasasdasd( )
		{
			return OperateResult.CreateSuccessResult( random.Next( 10000 ) );
		}

		[HslMqttApi( HttpMethod = "POST" )]
		public string GetJObjectTest( JObject json )
		{
			return json.ToString( );
		}


		private Random random = new Random( );

		public class Student
		{
			public string Name { get; set; }
			public int Age { get; set; }
			public string ID { get; set; }
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

			mqttServer.ServerClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			mqttServer.PublishAllClientTopicPayload( textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ) );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
			receiveCount = 0;
		}

		private void Button5_Click( object sender, EventArgs e )
		{
			// 发布到指定的客户端ID
			mqttServer.PublishTopicPayload( textBox1.Text, textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ) );
		}

		private void button6_Click_1( object sender, EventArgs e )
		{
			// 发布指定的主题
			mqttServer.PublishTopicPayload( textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ) );
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


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlRetureMessage, checkBox3.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRetureMessage ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}


	#endregion
}
