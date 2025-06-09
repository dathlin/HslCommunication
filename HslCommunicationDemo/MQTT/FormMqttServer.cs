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
using HslControls;
using HslCommunicationDemo.DemoControl;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormMqttServer : HslFormContent
	{
		public FormMqttServer( )
		{
			InitializeComponent( );

			comboBox_session_select.SelectedIndexChanged += ComboBox_session_select_SelectedIndexChanged;

			radioButton_every_seconds.CheckedChanged += RadioButton_every_seconds_CheckedChanged;
			radioButton_every_minute.CheckedChanged += RadioButton_every_seconds_CheckedChanged;
			radioButton_every_hour.CheckedChanged += RadioButton_every_seconds_CheckedChanged;
			radioButton_every_day.CheckedChanged += RadioButton_every_seconds_CheckedChanged;
		}

		private void RadioButton_every_seconds_CheckedChanged( object sender, EventArgs e )
		{
			if (sender is RadioButton radioButton)
			{
				if (radioButton.Checked)
				{
					// 切换了显示逻辑
					datas = new int[dataCount];
					texts = new string[dataCount];
					lastMinute = -1;
					lastHour = -1;
					lastDay = -1;
					hslBarChart1.SetDataSource( datas, texts );
				}
			}
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

		private Button button_publish = null;

		private void checkBox_publish_timer_CheckedChanged( object sender, EventArgs e )
		{
			if (!checkBox_publish_timer.Checked)
			{
				button_publish = null;
				timer_publish?.Stop( );
				timer_publish?.Dispose( );
			}
			else
			{
				// 启动一个定时器
				if (!int.TryParse(textBox1.Text, out int publishTimer ))
				{
					DemoUtils.ShowMessage( "Timer interval input wrong!" );
					return;
				}
				timer_publish = new Timer( );
				timer_publish.Interval = publishTimer;
				timer_publish.Tick += Timer_publish_Tick;
				timer_publish.Start( );
			}
		}

		private void Timer_publish_Tick( object sender, EventArgs e )
		{
			if (button_publish == null)
			{
			}
			else
			{
				button_publish.PerformClick( );
			}
		}
		private int[] datas = new int[30];
		private string[] texts = new string[30];
		private int dataCount = 30;
		private int lastMinute = -1;
		private int lastHour = -1;
		private int lastDay = -1;

		private void Timer1s_Tick( object sender, EventArgs e )
		{
			if (mqttServer != null)
			{
				long receiveCountNow = receiveCount;

				label2.Text = "Online Count:" + mqttServer.OnlineCount;
				label_receive_count.Text = "Receive Count: " + receiveCountNow;
				label_receive_size.Text = "Size: " + SoftBasic.GetSizeDescription( receiveSize );
				listBox1.DataSource = mqttServer.OnlineSessions;



				int current = (int)(receiveCountNow - lastReceiveCount);
				lastReceiveCount = receiveCountNow;

				DateTime time = DateTime.Now;
				if (radioButton_every_seconds.Checked)
				{
					if (checkBox_skip_zero.Checked && current == 0)
					{

					}
					else
					{
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref datas, new int[] { current }, dataCount );
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref texts, new string[] { DateTime.Now.Second.ToString( ) }, dataCount );
					}
					hslBarChart1.SetDataSource( datas, texts );
				}
				else if (radioButton_every_minute.Checked)
				{
					if (time.Minute != lastMinute)
					{
						lastMinute = time.Minute;
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref datas, new int[] { current }, dataCount );
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref texts, new string[] { lastMinute + "M" }, dataCount );
					}
					else
					{
						datas[datas.Length - 1] += current;
					}
					hslBarChart1.SetDataSource( datas, texts );
				}
				else if (radioButton_every_hour.Checked)
				{
					if (time.Hour != lastHour)
					{
						lastHour = time.Hour;
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref datas, new int[] { current }, dataCount );
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref texts, new string[] { lastHour + "M" }, dataCount );
					}
					else
					{
						datas[datas.Length - 1] += current;
					}
					hslBarChart1.SetDataSource( datas, texts );
				}
				else if ( radioButton_every_day.Checked )
				{
					if (time.Day != lastDay)
					{
						lastDay = time.Day;
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref datas, new int[] { current }, dataCount );
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref texts, new string[] { lastDay + "D" }, dataCount );
					}
					else
					{
						datas[datas.Length - 1] += current;
					}
					hslBarChart1.SetDataSource( datas, texts );
				}
			}
		}

		private Timer timer1s;
		private Timer timer_publish;

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
				button_clear.Text = "Clear";
				button6.Text = "Publish";
				label12.Text = "Receive:";
				checkBox3.Text = "Send test message back when client connect";
				checkBox2.Text = "Willcards";
				checkBox_publish_timer.Text = "Timer";
				button_stop.Text = "Stop";
				checkBox_long_message_hide.Text = "Long text for partial display";
				checkBox1.Text = "Enable the username and password below:";
				label_login_name.Text = "Name:";
				label_login_password.Text = "Password:";

				radioButton_every_seconds.Text = "Seconds";
				radioButton_every_minute.Text = "Minute";
				radioButton_every_hour.Text = "Hour";
				radioButton_every_day.Text = "Day";
				checkBox_skip_zero.Text = "Skip times 0?";
			}
		}

		private MqttServer mqttServer;
		private SiemensS7Net siemens;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				siemens = new SiemensS7Net( SiemensPLCS.S1200, "127.0.0.1" );

				mqttServer = new MqttServer( );
				mqttServer.OnClientApplicationMessageReceive += MqttServer_OnClientApplicationMessageReceive;
				mqttServer.OnClientConnected                 += MqttServer_OnClientConnected;
				mqttServer.OnClientDisConnected              += MqttServer_OnClientDisConnected;
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


				this.sslServerControl1.InitializeServer( mqttServer );
				mqttServer.ServerStart( int.Parse( textBox2.Text ) );
				mqttServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				mqttServer.RegisterMqttRpcApi( "Log", mqttServer.LogNet );
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				DemoUtils.ShowMessage( "Start Success" );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Start Failed : " + ex.Message );
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

			Invoke( new Action( ( ) =>
			{
				comboBox_session_select.DataSource = mqttServer.OnlineSessions;
			} ) );
		}

		private void MqttServer_OnClientDisConnected( MqttSession session )
		{
			Invoke( new Action( ( ) =>
			{
				comboBox_session_select.DataSource = mqttServer.OnlineSessions;
			} ) );
		}

		private void ComboBox_session_select_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (comboBox_session_select.SelectedItem is MqttSession session)
			{
				textBox_session_onlineTime.Text = session.OnlineTime.ToString( DemoUtils.DateTimeFormate );
				textBox_session_activeTime.Text = session.ActiveTime.ToString( DemoUtils.DateTimeFormate );
				textBox_session_ip.Text = session.EndPoint.Address.ToString( );
				textBox_session_port.Text = session.EndPoint.Port.ToString( );
				textBox_session_clientID.Text = session.ClientId;
				textBox_session_rsa.Text = session.IsAesCryptography.ToString( );
				textBox_session_userName.Text = session.UserName;
				textBox_session_willTopic.Text = session.WillTopic;

				textBox_session_topics.Lines = session.GetTopics( );
			}
		}


		private int MqttServer_ClientVerification( MqttSession mqttSession, string clientId, string userName, string passwrod )
		{
			if (userName == textBox_login_name.Text.Trim( ) && passwrod == textBox_login_password.Text.Trim( )) return 0; // 成功
			if (userName == "hsl" && passwrod == "123456")
			{
				mqttSession.DeveloperPermissions = true;   // 例如也让hsl账户拥有开发者权限，可以遍历接口，请求主题信息等操作
				return 0; // 成功
			}
			return 5; // 账号密码验证失败
		}

		private long receiveCount = 0;
		private long lastReceiveCount = 0;
		private long receiveSize = 0;

		private TopicSaveItem GetSavedTopicItem( MqttSession session, MqttClientApplicationMessage message )
		{
			// 如果 session 为空，则是服务器自己发布的消息
			TopicSaveItem currentItem;
			lock (all_dicts)
			{
				if (all_dicts.ContainsKey( message.Topic ))
				{
					all_dicts[message.Topic].Session = session;
					all_dicts[message.Topic].Message = message;
					all_dicts[message.Topic].ReceiveDateTime = DateTime.Now;
					all_dicts[message.Topic].Count++;
					currentItem = all_dicts[message.Topic];
				}
				else
				{
					TopicSaveItem item = new TopicSaveItem( );
					item.Topic = message.Topic;
					item.Message = message;
					item.ReceiveDateTime = DateTime.Now;
					item.Session = session;
					item.Count = 1;

					currentItem = item;
					all_dicts.Add( message.Topic, item );
				}
			}
			return currentItem;
		}

		private void DeleteTopicItem( TopicSaveItem item )
		{
			lock (all_dicts)
			{
				if (all_dicts.ContainsKey( item.Topic ))
				{
					all_dicts.Remove( item.Topic );
				}
			}
		}

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
					mqttServer.ReportOperateResult( session, Program.Language == 1 ? "当前的功能码不支持！" : "The current function code is not supported!" );
				}
				else if (message.Topic == "E")
				{
					// 返回一条操作结果的信息
					if (random.Next( 100 ) < 50)
						mqttServer.ReportOperateResult( session, new OperateResult<string>( Program.Language == 1 ? "当前的结果为失败信息" : "The current result is a failure message" ) );
					else
						mqttServer.ReportOperateResult( session, OperateResult.CreateSuccessResult( Program.Language == 1 ? "成功" : "Successful" ) );

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

					// 此处直接返回不存在的API接口功能
					mqttServer.ReportOperateResult( session, Program.Language == 1 ? "不支持的注册接口信息" : "Unsupported information about the registered interface" );
				}
			}
			else if (session.Protocol == "MQTT")
			{
				TopicSaveItem currentItem = GetSavedTopicItem( session, message );

				Invoke( new Action( ( ) =>
				{
					if (currentItem != null)
					{
						if (currentItem.ViewRow != null)
						{
							currentItem.RenderRow( );
						}
						else
						{
							int index = dataGridView1.Rows.Add( );
							currentItem.RenderRow( dataGridView1.Rows[index] );
						}

						if (object.ReferenceEquals( currentItem, selectedItem ))
						{
							RenderTopicSaveItem( currentItem );
						}
					}
						//AddressExampleControl.DataGridSpecifyRowCount( dataGridView1, saveItems.Length );
						//for (int i = 0; i < saveItems.Length; i++)
						//{
						//	dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString( );
						//	dataGridView1.Rows[i].Cells[1].Value = saveItems[i].Topic;
						//	dataGridView1.Rows[i].Cells[2].Value = saveItems[i].Count.ToString( );
						//	dataGridView1.Rows[i].Tag = saveItems[i];
						//}
				} ) );
			}

			Invoke( new Action( ( ) =>
			{
				receiveCount++;
				receiveSize += message.Payload.LongLength;

				if (!isStop)
				{
					textBox8.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) +
						$" Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload{(message.Retain ? "-Retain" : "")}:[{GetStringFromPayload( message.Payload )}]" + Environment.NewLine );
				}
			} ) );
		}

		private Dictionary<string, TopicSaveItem> all_dicts = new Dictionary<string, TopicSaveItem>( );
		private TopicSaveItem selectedItem = null;

		private void RenderTopicSaveItem( TopicSaveItem item )
		{
			if (item != null)
			{
				textBox_topic_topic.Text = item.Topic;
				checkBox_topic_retain.Checked = item.Message.Retain;
				textBox_topic_publishTime.Text = item.ReceiveDateTime.ToString( HslCommunicationDemo.DemoUtils.DateTimeFormate );
				if (item.Session != null)
					textBox_topic_publishSession.Text = item.Session.ToString( );
				else
					textBox_topic_publishSession.Text = string.Empty;

				string tmp = GetStringFromPayload( item.Message.Payload );
				if (radioButton_topic_render_json.Checked)
				{
					try
					{
						tmp = JObject.Parse( tmp ).ToString( );
					}
					catch
					{
					}
				}
				textBox_topic_payload.Text = tmp;

				if (item.Message.Payload!=null) label_topic_size.Text = SoftBasic.GetSizeDescription( item.Message.Payload.LongLength );
				else label_topic_size.Text = "0";
			}
			else
			{
				textBox_topic_topic.Text = string.Empty;
				checkBox_topic_retain.Checked = false;
				textBox_topic_publishTime.Text = string.Empty;
				textBox_topic_publishSession.Text = string.Empty;
				textBox_topic_payload.Text = string.Empty;
				label_topic_size.Text = "0";
			}
		}

		private void dataGridView1_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Tag is TopicSaveItem item)
				{
					RenderTopicSaveItem( item );
					selectedItem = item;
				}
			}
		}

		private string GetStringFromPayload( byte[] payload )
		{
			string tmp = string.Empty;
			if (payload == null) payload = new byte[0];

			if (radioButton_recv_Hex.Checked) tmp = payload.ToHexString( ' ' );
			else if (radioButton_recv_ASCII.Checked) tmp = Encoding.ASCII.GetString( payload );
			else if (radioButton_recv_Unicode.Checked) tmp = Encoding.Unicode.GetString( payload );
			else if (radioButton_recv_UTF8.Checked) tmp = Encoding.UTF8.GetString( payload );
			else if (radioButton_recv_gb2312.Checked) tmp = Encoding.GetEncoding( "gb2312" ).GetString( payload );

			if (tmp?.Length > 100 && checkBox_long_message_hide.Checked) tmp = tmp.Substring( 0, 100 ) + "...";

			return tmp;
		}

		private void button7_Click_1( object sender, EventArgs e )
		{
			// 删除当前选中的主题信息
			if (selectedItem == null) return;
			if (string.IsNullOrEmpty( textBox_topic_topic.Text )) return;

			dataGridView1.Rows.Remove( selectedItem.ViewRow );
			DeleteTopicItem( selectedItem );
			selectedItem = null;
			RenderTopicSaveItem( null );
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


		[HslMqttApi( "获取两个数的除法信息，a: 第一个数 b: 第二个数" )]
		public OperateResult<int> Devide( int a = 200, int b = 10 )
		{
			return OperateResult.CreateSuccessResult( a / b );
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
			// 发布所有
			mqttServer.PublishAllClientTopicPayload( textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ), 
				checkBox_retain.Checked);
			button_publish = button3;
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
			mqttServer.PublishTopicPayload( textBox_publish_clientID.Text, textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ), checkBox_retain.Checked );
			button_publish = button5;
		}

		private void button6_Click_1( object sender, EventArgs e )
		{
			// 发布指定的主题
			mqttServer.PublishTopicPayload( textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes( ) : Encoding.UTF8.GetBytes( textBox4.Text ), checkBox_retain.Checked );
			button_publish = button6;
		}

		bool isStop = false;
		private void button7_Click( object sender, EventArgs e )
		{
			if (!isStop)
			{
				button_stop.Text = "继续";
				isStop = true;
			}
			else
			{
				isStop = false;
				button_stop.Text = "暂停";
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

		private void button4_Click_1( object sender, EventArgs e )
		{
			if (comboBox_session_select.SelectedItem is MqttSession session)
			{
				mqttServer.RemoveAndCloseSession( session, "" );
			}
		}

		private void button_statistics_start_Click( object sender, EventArgs e )
		{

		}

		private void button_publish_test_Click( object sender, EventArgs e )
		{
			// 高频发布测试代码
			textBox5.Text = "HSL:MQTT:TEST:10000";
			for (int i = 0; i < 10000; i++)
			{
				this.mqttServer.PublishTopicPayload( "HSL:MQTT:TEST:10000", BitConverter.GetBytes( i ) );
			}
			MessageBox.Show( "Publish finish" );
		}

	}

	public class TopicSaveItem
	{
		public TopicSaveItem( ) 
		{
			ID = System.Threading.Interlocked.Increment( ref newId );
		}


		/// <summary>
		/// 序号信息
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 当前的主题
		/// </summary>
		public string Topic { get; set; }

		/// <summary>
		/// 收到的时间
		/// </summary>
		public DateTime ReceiveDateTime { get; set; }

		/// <summary>
		/// 收到的会话
		/// </summary>
		public MqttSession Session { get; set; }

		/// <summary>
		/// 消息信息
		/// </summary>
		public MqttClientApplicationMessage Message { get; set; }

		/// <summary>
		/// 收到的次数
		/// </summary>
		public long Count { get; set; }

		/// <summary>
		/// 显示的行信息
		/// </summary>
		public DataGridViewRow ViewRow { get; set; }

		public void RenderRow( DataGridViewRow row )
		{
			row.Cells[0].Value = ID.ToString( );
			row.Cells[1].Value = Topic;
			row.Cells[2].Value = Count.ToString( );
			row.Tag = this;
			ViewRow = row;
		}


		public void RenderRow( )
		{
			if (ViewRow == null) return;
			ViewRow.Cells[0].Value = ID.ToString( );
			ViewRow.Cells[1].Value = Topic;
			ViewRow.Cells[2].Value = Count.ToString( );
		}

		private static long newId = 0;
	}


	#endregion
}
