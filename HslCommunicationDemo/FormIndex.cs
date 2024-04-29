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
			textBox1.Text = @"V12.0.0
1. Controls: 删除controls控件，删除图标资源，FormSupport窗体移动到DEMO，FormPortraitSelect移动到hslcontrols组件，本库更加纯粹的负责通信及算法。
2. SharpList: 更改锁的机制为lock，优化了代码注释以及部分代码逻辑，提升数组长度比较大的时候的性能，提升批量增加数据时候的性能。
3. NetSoftUpdateServer: 用于程序升级的服务器修复当传送大文件（120M以上时）传送到一半会卡住，传送非常慢的bug。
4. Modbus: 修复ModbusTcp协议当设备有前置干扰码但是数据长度判断不正确的bug，ModbusRtu新增站号不匹配时持续接收匹配站号的数据。
5. SecsMessage: 修复secs消息解析的时候，屏蔽了function字段的最高位的bug，该bug会导致大于127的功能码解析异常，现在可以正确的识别。
6. FormLogNetView: 日志显示的窗体新增带日志路径的构造函数，当指定路径后，显示页面时立即显示日志内容及统计信息。
7. OmronFinsTcp: 增加对属性SID信息功能，每次请求的时候进行自增，然后校验PLC返回的数值信息，直到接收到一致为止。
8. ABBWebApiClient: GetJointTarget方法新增mechunit参数，可以指定不同单元。新增GetAnIOSignal方法。
9. CommunicationServer: 新增服务器类，可以开启TCP,UDP,SerialPort服务器，绑定事件即可接收到客户端发送的数据。
10. FujiCommandSettingType: 修复写入数据到plc，提示写入失败但是实际成功的bug; 修复西门子PPI虚拟服务器对写入结果的报文返回不正确的bug。
11. SecsHsms: 针对SendByCommand方法，如果通信异常，则自动连接操作，也就是所有的发送指令都会将管道标记为异常，下次发送时进行重连。
12. DLT645Server: 修复主站读取时站号不一致时提示校验失败的bug，修复修改站号命令失败的bug，新增属性站号是否校验。
13. HslHelper: 修复GetIpAddressFromInput方法输入ipv6地址时会导致解析失败的bug，现在同时支持输入ipv4地址，ipv6地址，域名。
14. Modbus: 新增属性EnableWriteMaskCode，默认支持掩码功能码，如果发现设备不支持，会自动切换false，使用读字修改位写字的方式来实现写位到字寄存器。
15. ModbusTcpServer: 新增自由控制是否支持掩码功能码; 台达，麦格米特，汇川，信捷的modbus类地址功能优化，并支持了部分字寄存器的写位操作。
16. ByteTransform: ByteTransformBase基类删除，字节转换类优化，两个字节的整型short,ushort将根据ABCD,CDAB时使用大端，其他情况使用小端转换。
17. AllenBradleyNet: 地址支持了x=0x52;A1 这种携带52功能码直接使用片段读写的方式，还支持了class=0x6b;0xf68f这种符号实例ID地址，服务器增加配合，修复相关bug。
18. LogNet: 存储日志因为文件占用等问题发生异常的时候，不再记录存储失败的信息，存储多次才成功的日志加入[Retry:3]标志，相关代码精简优化。
19. SecsValue: 新增加一个从string[]对象初始化的构造函数，直接生成一个list对象，包含多个字符串。
20. DLT698: DLT698协议新增客户端地址CA属性，可以配置更改，代码优化，修复读取电能量数据的扩展参数属性时，缩小倍数不正确的bug。
21. IOmronFins: FinsTcp,finsUdp,hostlink协议新增属性PlcType，可选CS/CJ 和 CV系列，在CV系列地址码略有不同，fins协议支持ReadCpuTime读取PLC时间。支持了地址 E100 当前数据区
22. BeckhoffAdsNet: 倍福后台接收数据的地方针对设备通知消息（08功能码）的情况，进行数据屏蔽操作，demo添加ig=0xF030地址格式的示例。
23. KeyenceMcNet: 修复基恩士MC协议在读取R100.5， MR100.5，LR100.5，CR100.5 地址格式转化真实位地址时地址有偏差的bug。
24. WebSocketClient: 新增方法 UseSSL( string certificateFile )支持开启证书模式，可以连接 wss 的远程服务器。WebSocketServer也做了代码优化。
25. V12: 通信类继承体系重新设计, BinaryCommunication(二进制通信)->DeviceCommunication(设备通信)->TCP,UDP,串口通信->每个设备的通信。
26. V12: 重新设计通信的管道，CommunicationPipe(通信管道)->TCP,UDP,串口,MQTT管道，前者的二进制通信类，可以随意的设置不同的管道，具体参考手册。
27. V12: 重新设计所有的虚拟PLC类，DeviceCommunication(设备通信)->DeviceServer(服务器)->各个PLC类，同时支持开启TCP，UDP，串口从站的功能。
28. Demo: 串口网口的收发数据的控件，为了方便模拟设备，输入框支持分批并且延时发送，单独一行<sleep=100>即可，数字100表示休眠的时间，可以修改其他值。
29. Demo: 修复demo的PLC测试界面里，定时读取的时候，PLC发生掉线后不停弹窗的bug，现在代码进行了优化精简。
30. 请注意，本次升级可能会造成不兼容的情况，具体需要看使用了哪部分的功能，如果简单的使用PLC类例如ModbusTcpNet可以兼容升级，如果使用了基类NetworkDeviceBase，需要替换为DeviceCommunication。
31. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
32. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
