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
			textBox1.Text = @"V12.0.1
1. MqttServer: 当启动文件服务器时，客户端进行文件上传，下载，删除触发的OnFileChangedEvent事件里添加一个属性：映射文件名称。
2. PipeSslNet: 新增基于 SSL/TLS 的管道信息类 PipeSslNet, 从PipeTcpNet类继承实现，可以配合 HslCommunication 自身的虚拟服务器实现加密通信，防止抓包。
3. CommunicationTcpServer: TCP服务器基类代码优化，添加对SSL/TLS的支持，签名修改：ThreadPoolLogin( PipeTcpNet pipe, IPEndPoint endPoint ) 这里如有使用可能不兼容升级。
4. ModbusTcpServer: 修复当DataFormat配置DCAB时，解析客户端的报文的时候，导致地址及长度信息高地位弄反的bug。
5. PipeSerialPort: 串口管道新增属性DtrEnable控制，表示串行通信中是否启用数据终端就绪 (Drt) 信号
6. WebSocketHelper: websocket消息接收使用了管道的实现，删除了原先部分多余的代码，mqtt管道公开一些额外的参数信息。
7. DeviceSerialPort: 当串口管道调用关闭方法Close的时候，修复管道被重新指定其他非串口管道时，连接不会关闭的bug。
8. DeviceCommunication: 设备类基类重新添加Dispose接口，然后调用管道的Dispose, 方便代码升级考虑兼容性。
9. BeckhoffAdsNet: 修复管道配置为SSL及自动获取AMS的情况下，获取ams不使用ssl的bug。
10. DeviceTcpNet: 重新添加回方法SetPersistentConnection()并标记弃用的状态，方便部分用户升级的时候可以保持向后兼容。
11. DLT645-2007, DLT645-1997, DLT698添加无参的构造方法，这样DEMO生成的示例代码就可以复制使用，然后优化DEMO上的界面。
12. MelsecMcServer: 三菱的虚拟服务器针对字地址支持了bool读写操作，也就是ReadBool(""D100.1"")，写入也是一样。
13. HttpServer: 注册接口的时候，支持输入参数HttpListenerRequest request时，自动传入客户端的请求头，方便进行二次分析处理。
14. Wecon: demo新增维控PLC的测试界面，如何实例化相关的对象及支持的地址列表参考demo界面上的地址示例及代码示例。
15. KeyenceNanoServer: 针对客户端单次读写的数据长度从256，提升到1000长度，因为上位链路协议在某些型号里是1000长度的。
16. Omron: 修复欧姆龙CV系列的情况下，针对CIO数据区执行bool写入操作异常的bug，原因来自PLC不支持bool的写入CIO功能码，使用读字修改位写字来实现。
17. Inovance: 修复了Modbus协议地址映射后，针对写入字地址的位情况下可能引发了bug，修复汇川的AM系列读写QX，MX位不匹配的bug。
18. PipeSerialPort: 优化串口管道的数据接收机制，当定义了报文消息的完整性校验对象后，就不再以收到空数据为终结点，如果数据不完整，就一直接收到超时为止。
19. ModbusRtu: 修复当设备的数据分段延时返回的时候，设备数据的内容刚好符合一些错误规律的时候，会直接返回部分的报文给调用者，然后判断出 crc异常
20. MqttClient: 修复调用ConnectServerAsync方法连接的情况下触发的OnClientConnected事件中，获取IsConnected属性还是未连接的bug。
21. LSis: 删除原来按照XGB,XGK这种命名方式，改为了LsCnet, LSFastEnet类，具体类型的实例化，可以参考demo程序生成的代码示例。
22. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
23. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
