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
			textBox1.Text = @"V11.0.0
1. TcpForward: 新增TCP转TCP的类，设置本地端口及远程端口，客户端连接之后立即连接远程服务器，进行数据转发，支持多个连接，每个客户端都创建一个远程连接对象，DEMO的转发测试使用这个类。
2. BeckhoffAdsServer: 倍福的虚拟PLC修复M100.1位地址读写数据不正确的bug，支持了符号地址，支持创建符号数据，自动生成唯一的句柄地址。支持客户端批量的地址读取，也即功能码为 0xF080。
3. AllenBradleyPcccServer: 修复PCCC虚拟PLC读写地址数据解析异常的bug，导致和客户端的地址数据不一致。提炼优化地址信息。
4. NetworkDataServerBase: 优化串口接收时候的数据检测的代码，修复modbus虚拟服务器接收串口数据时，功能码为0x10时，SerialReceiveAtleastTime属性设置无效的bug。
5. XinJE: 基于modbus协议的信捷类对象，当地址是位地址时(X,Y,M等)，支持了当使用Read（字单位）读取原始字节的方法，返回原始的字节信息。
6. FanucSeries0i: Fanuc数控机床通信类，新增读取机床型号信息的api，ReadSysInfo，信息在连接初始时获取生成，后续直接读取内存。
7. FanucSeries0i: 读取程序文件及下载程序到机床支持路径参数，例如操作PATH2时只需要输入 //CNC_MEM/USER/PATH2/ 即可，新增DeleteFile的API用于删除任意路径的程序文件。
8. FanucSeries0i: 新增ReadAllDirectoryAndFile方法，用来遍历指定路径下的所有的子路径和文件的信息，文件大小使用字节为单位。
9. ISessionContext: 在MRPC的接口及HttpWebapi注册接口的方法里，参数ISessionContext新增Tag对象，方便自定义捆绑一些数据信息。
10. MqttServer: 文件服务器相关的功能增加GetGroupFromFilePath方法，从路径信息里获取到文件列表管理容器，进而可以获取单个文件的对象，在权限控制时可以更加的细致。
11. Modbus: ModbusHelper针对modbus-rtu的返回接收报文检测，增加对站号一致性的检测，如果发现站号不一样，返回错误信息。
12. ICryptography: 添加直接对字符串进行加密解密的方法，并在AesCryptography类和DesCryptography实现方法，方便直接操作。
13. OmronConnectedCipNet: 优化批量读取数组的方法，自动根据类型来切割不同的读取长度，分批次读取所有的数据信息。修复握手报文丢失Timeout时间报文的bug，导致v10.5.0以来不能读取的问题
14. OmronConnectedCipNet: 优化和PLC持续几秒钟不读写就被PLC强制断线的问题，现在支持很长的时间，修复关闭立即重连（包括意外断线重连）连接不成功，一直报错重复打开会话的异常。
15. NetworkConnectedCip: 基于连接的CIP协议里，在OpenForward初始化里，自动获取连接ID，如果失败，并尝试五次自增连接ID重新Open。
16. AllenBradleyConnectedCipNet: 新增ab的connected cip协议的实现，继承自欧姆龙的connected cip协议，重写了部分的逻辑实现，缩小了单次读取的字节上限，初步测试通过。
17. NetworkServerBase,NetworkDoubleBase: 新增属性SocketKeepAliveTime，用来设置底层的socket的KeepAlive信号，单位毫秒，默认不开启，开启后将会自动间隔的发送KeepAlive信号。
18. AllenBradleyServer: cip的虚拟服务器同时支持了基于连接的CIP的访问。标签定义类AllenBradleyItemValue新增TypeCode属性，在返回客户端数据的时候，带类型数据返回。支持bool[]节点创建。
19. SoftBasic: GetAsciiStringRender 不可见字符判断除了0x20以下，追加0x7e以上的字符。新增GetFromAsciiStringRender方法，把GetAsciiStringRender 结果反向转换回来。
20. AllenBradleyNet: 支持写入bool[]功能，支持写入byte[]数组功能（类型代号默认为0xD1），WriteTag方法支持地址携带类型信息，例如地址 type=0xD1;A[0]
21. MelsecFxSerial: 三菱的编程口协议在新版协议配置为True时，修复D8000地址以上读写不正确的bug，修复X,Y,M,S部分地址读写不正确的bug，都调整为新版的报文，支持的范围更大更准确。
22. MelsecFxSerialOverTcp: 支持通过GOT连接的方式。PanasonicMewtocol: 松下的Mewtocol协议支持了经过值及目标值。ILogNet: 日志的接口新增属性LogThreadID，用来配置是否记录线程ID的数据信息。
23. SecsHsmsServer: 新增Secs协议的虚拟服务器，支持事件自定义处理所有的消息。并添加示例的代码。Demo程序界面
24. Mqtt: MqttClient及MqttServer支持了遗言消息，客户端A在连接参数里设置了遗言主题及数据，当客户端A非正常掉线的时候，服务器即发布该遗言主题信息。
25. MqttSyncClient: 新增HslCancelToken对象，在文件上传和下载的过程中支持取消操作，MqttServer适配相应的功能实现，取消示例代码增加。
26. HttpServer: 新增Action对象DealWithHttpListenerRequest，用来处理定义的Header数据到Session会话中，实现更加复杂自定义的操作。
27. Demo: DEMO写入各种PLC的数据功能里，写入的数据支持byte数组，例如数据输入[1,2,3], 点击写入byte，就自动写入new byte[]{ 0x01, 0x02, 0x03}
28. Demo: TCP调试界面优化，新增握手报文设置。新增一个测试正则表达式的界面，增加一些常用的正则表达式的内容。CIP浏览节点界面支持正则表达式筛选节点。
29. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
30. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
