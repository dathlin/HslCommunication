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
			textBox1.Text = @"V12.3.1
1. SecsHsmsServer: 新增方法PublishSecsMessage( byte stream, byte function, SecsValue data, uint messageId, bool wBit )，可以发布的时候手动控制系统数据。
2. HslExtension: 优化地址判断方法StartsWithAndNumber，支持了对负数的地址判断，因为台达等PLC存在负数地址的情况，例如 D-3530
3. CommunicationTcpServer: 修复TCP服务器在linux系统运行时，某些特殊情况调用 ServerClose 后会异常奔溃的bug。
4. WebSocketServer: 服务器端新增方法 public void PublishAllClientPayload( byte[] payload ) 使用opcode = 2来发送二进制的数据消息，DEMO界面优化显示。
5. PipeSslNet: 新增属性 SslProtocols 可以自定义控制SSL协议的版本，CommunicationTcpServer新增方法 SetSslPipeAction 可用于设置SSL的自定义属性。
6. PipeTcpNet: 新增属性 CloseOnRecvTimeOutTick，当使用同步方法读写PLC数据时，想要实现超时几次内不关闭当前的连接对象，就设置该属性，注意，只对同步方法有效。
7. TcpForward: TCP转发类接收到双方数据后，顺序调整为先转发再重新接收数据，修复在某些连续发送的场景下导致数据接收顺序错乱的bug。
8. AllenBradleyNet: 当使用了i=的地址格式写入单个的bool的值的时候，修复地址为单个dint类型时，提示数据不存在的bug。
9. MelsecFxSerial: 优化三菱编程口协议对报文完整性的判断，就算读取的报文前面出现 3F 3F 3F字节，也可以正确的识别和解析数据。
10. HttpServer: 内部日志记录针对所有的请求操作及url信息，耗时进行记录操作，新增属性 LogHttpBody 默认false，设置true可以记录body数据，跨域属性默认为 true。
11. HttpServer: 新增属性LogHttpHeader，用于表示日志是否记录请求头的信息，DEMO界面优化，支持日志设置请求头或是Body数据。
12. ModbusRtu: 修复当收到CRC16不正确的报文时，却表现为接收超时的bug，现在会直接返回并提示CRC不正确，当站号不一致时，还是会持续接收直到有指定站号数据或是引发超时。
13. Modbus: IModbus接口新增属性WordReadBatchLength，表示批量读取时自动切割的长度信息，默认根据120长度分批读取，现在开放修改。
14. MqttServer: 修改继承体系，从V12版本的CommunicationTcpServer继承实现，支持了SSL/TLS加密通信功能，优化了Demo界面的部分显示信息，测试了连续几万次的发布接收功能。
15. MelsecMcRNet: 修复三菱R系列的协议情况下，命令码中部分内容不正确的bug，此前一直读写不了R系列的PLC，需要使用普通MC协议。
16. OmronCipNet: 修复欧姆CIP协议写入单个bool数据到PLC失败的bug，修复bool数组读取解析异常，支持从数组中间位置开始读取。
17. SecsHsms: 方法SendByCommand返回携带消息ID信息，方便二次处理，修复SecsValue在某些值信息为空的情况下转成SML字符串时异常的bug。
18. SecsHsmsServer: 服务器侧新增一个同步方法ReadSecsMessage读取客户端的返回数据信息，该方法内部有锁，线程安全的。
19. OmronCMode: 欧姆龙的HostLinkCMode支持了读写位的操作，实际是通过读写字间接实现的，修复了HostLinkCModeServer当客户端读取EM地址失败的bug。
20. Demo: demo界面的模拟数据写入测试界面新增单次测试，如果碰到地址异常，自动选中该单元格，修复设备保存时模拟数据界面不保存的bug。
21. Demo: DEMO界面上选择串口管道的时候，额外属性里新增ReceiveTimeOut属性，可以设置超时时间了，参数支持保存加载，支持示例代码生成。
22. Demo: 修复CJT188及串口透传类，在DEMO中生成示例代码的时候，实际复制到项目出错的bug，现在可以正确的生成代码。
23. Demo: 修复DEMO界面的点位变量表，请求间歇没设置直接启动报错的bug，该信息也存储到XML里，当设备关闭时，点位变量表也根据停止读取刷新。
24. Demo: fanuc机床的程序测试界面增加特殊情况下载失败的信息提示，openprotocol界面增加实际代码显示，方便复制。
25. Demo: 修复demo碰到激活码不正确的情况下，启动弹窗的bug，现在不再弹窗操作。http服务器和websocket服务器的界面控件支持滚动条。
26. Demo: 测试工具界面的写入地址的数据，支持输入连续数组，例如数组1,2,3,...,100，直接输入 [1:100] 即可，然后点击写入的类型。
27. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
28. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
	}
}
