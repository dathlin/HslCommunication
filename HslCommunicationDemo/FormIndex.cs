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
			textBox1.Text = @"V12.0.3
1. MqttServer: 修复在客户端的掉线事件里如果调用RemoveAndCloseSession移除会话导致内存堆栈溢出的bug，虽然一般都不会这么写代码。
2. MqttSession: 属性DeveloperPermissions默认值修改为false，在服务器上会话登录后admin用户名默认设置为Ture，也可以自定义更改。
3. NetSupport: SocketSend及SocketSendAsync方法增加对socket空的校验，防止部分plc实例化后直接调用close直接报异常的bug。
4. HttpServer: 修改HandleRequest方法及属性HandleRequestFunc返回方法为object, 支持返回string及 byte[]，可以用来传文件，此更新为兼容的。
5. MemobusTcpNet: 安川的协议地址支持了M100,G100,I100,Q100,S100这种地址，支持超大地址，支持对位原生操作。
6. NetworkConnectedCip: 两个连接时的会话ID属性OTConnectionId及TOConnectionId修改为公开状态。
7. WebSocketClient: 新增属性GetCarryHostAndPort用来标记HTTP请求头GET是否协议HOST信息，默认为false，DEMO界面优化，添加了输出示例代码，修复某些特殊服务器连接失败的bugs。
8. OperateResult: 创建失败的类型返回方法新增一个重载的字符串参数，可以额外添加信息说明，方便后续查问题。
9. SecsHsmsServer: 新增一个PublishSecsMessage重载方法，支持指定是否要求客户端返回，修复demo上勾选要求返回失败的bug。方法SendByCommand新增带wbit是否要求返回信息的重载方法。
10. OpenProtocolNet: 修复创建报文参数异常，修复并优化demo界面问题，改从TcpNetCommunication继承，新增OpenProtocolServer配合进行本地测试。
11. BeckhoffAdsNet: 修复读取的字节数大于10000时返回数据长度不正常的bug，修复读取bool数组时返回数据数量不正确的bug，虚拟服务器修复位读取时的返回数据不正确的bug。
12. PanasonicMewtocol: 松下的Mewtocol协议支持读取 D，LD寄存器的位，地址格式为 D100.0， LD100.0 ， 影响范围包括网口及串口。
13. BeckhoffAdsServer: 修复服务器端自己读写数组的某个索引的数据的时候，提示标签不存在的bug，暂不支持客户端读读写某个索引的标签数组。
14. ModbusMappingAddress: 新增英威腾PLC的modbus地址转换实现，现在modbus可以注册这个地址转换，直接支持PLC原生地址。
15. Demo: 数据表控件支持了曲线实现功能，kuka机器人界面增加更多的地址说明，fanuc的机床添加下载程序到本地。
16. Demo: demo程序的PLC侧的数据表监视界面支持对值进行脚本运算，例如缩小100倍，输入 x/100.0  或是 x*0.01，也可以更加复杂三角函数运算
17. Demo: demo程序优化，写入bool支持输入0, 1，然后demo关闭服务器自动停掉所有的定时器及线程操作，否则将会触发异常退出。
18. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
19. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
		MessageBox.Show( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		MessageBox.Show( " + "\"Active Failed! it can only use 24 hours\"" + @" );
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
