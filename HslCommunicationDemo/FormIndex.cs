using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo
{
	public partial class FormIndex : HslFormContent
	{
		public FormIndex( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel1.Text );
		}

		private void FormCharge_Load( object sender, EventArgs e )
		{
			SetUpdayeInfo( );

			if(Program.Language == 2)
			{
				Text = "Start Page";
			}

		}

		private void SetUpdayeInfo( )
		{
			textBox1.Text = @"V12.6.1
1. NetworkAlienClient: DTU服务器类新增支持了16字节的注册包数据，可以仅包含ID信息，密码视为传入000000，然后进行校验。
2. Secs: SecsHsms修复自动回复几个消息的时候，systembytes不复制一样的bug，secshsmsserver的方法PublishSecsMessage发送数据之后，返回结果携带本次发送的 systembytes 信息，方便自定义处理。
3. OpenProtocolServer: 新增MID0061订阅数据的revision2版本的的订阅，方便客户端测试，客户端DEMO新增手动配置某个MID数据解析的功能，并支持保存加载。
4. Server: 优化所有串口类协议的虚拟设备接收报文的代码，支持客户端发送时分段发送，修复DLT698串口类协议的报文完整性判断。
5. MqttServer: 新增重载方法PublishTopicPayload，payload可以指定流数据，分段加载返回，用于同步返回文件。
6. OpenEventArgs: OpenProtocol协议触发订阅事件的消息类新增属性RawData，用来表示接收到的原始字节数据，方便特殊需求的自定义解析。
7. HslTimeOut: 优化异步读写超时信号判断的线程，Thread.Sleep修改为更加稳定的同步超时信号，并增加兜底方案，因为Sleep极低概率会发生异常。
8. WebSocketServer: 新增移除指定会话的订阅信息的方法RemoveSessionTopic，相关的测试界面优化，支持查看更多的信息，支持数据转发。
9. Demo: 修复OpenProtocol的测试界面上，如果收到全空格的revision信息时，直接崩溃的bug。
10. Demo: HttpClient的测试界面，显示结果的textbox控件替换为richTextBox控件，因为前者在字符串非常大的时候，将会卡死无响应，新的控件则不会。
11. Demo: MqttServer界面及MqttClient界面支持数据转发，将设备的数据，进行发布订阅出去，以JSON数据的格式发送。
12. Demo: 优化secs得服务器客户端，增加图标信息，服务器功能码右键，新增发送SECS消息的功能。
13. Demo: 串口转网口的测试界面，修复关闭时网络资源不关闭的bug，修复点击保存连接时提示该功能没有实现的bug，新增清空及字节统计功能。
14. Demo: 新增加一个配置选择，写入成功后可以不进行弹窗操作，有需要的朋友可以在菜单的配置里查看，然后打勾操作。
15. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
16. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
		}


		private void ShowActiveCode( )
		{
			textBox1.Text = @"/// <summary>
														  /// 应用程序的主入口点。
														  /// </summary>
[STAThread]
static void Main( )
{
	// 中文授权示例
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"你的激活码\"" + @" ))
	{
		DemoUtils.ShowMessage( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		DemoUtils.ShowMessage( " + "\"Active Failed! it can only use 24 hours\"" + @" );
		return;  // quit if active failed
	}
	Application.EnableVisualStyles( );
	Application.SetCompatibleTextRenderingDefault( false );
	Application.Run( new Form1( ) );
}";
		}

		private void label15_Click( object sender, EventArgs e )
		{
			ShowActiveCode( );
		}

		private void label14_Click( object sender, EventArgs e )
		{
			SetUpdayeInfo( );
		}

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel2.Text );
		}
	}
}
