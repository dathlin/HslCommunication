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
			textBox1.Text = @"V12.2.0
1. MelsecMcServer: 对客户端的功能码支持了读取型号，远程run，远程stop，远程reset，错误状态恢复，方便客户端进行测试
2. FanucSeries0i: 修复ReadFanucAxisLoad在某些型号读取异常的bug，修复读取系统状态在某些型号读取异常bug，新增读取主轴负载及程序号的方法。
3. RemoteConnectInfo: 优化了DTU连接类，虚拟服务器可以直接连接远程DTU服务器，然后返回连接对象，支持进一步控制操作，例如断开，DEMO相关界面优化。
4. MelsecFxSerial: 三菱的编程口协议支持写入bool数组到指定地址里去，不过前提条件是bool数组长度是16的倍数，且位起始地址也需要为16的倍数。
5. SiemensS7Server: 修复S7虚拟服务器读写bool数组失败，提示不支持的bug，现在可以正确的读取和写入bool数组操作了。
6. Keyence: 基恩士上位链路协议客户端支持直接字单位读写位线圈的地址，虚拟服务器同步支持这些命令操作，Demo界面优化。
7. ModbusInfo： modbusASCII协议提取真实数据的时候，遇到中间有0d0a结束字符的时候，自动截断操作。
8. ToyoPuc: 丰田工机协议写入位数据到字地址的时候，直接提示写入失败，防止错误写入的情况，因为没有这样的功能码操作。
9. ToyoPuc: 丰田工机协议新增随机字读取的方法ReadRandom(string[])，虚拟服务器ToyoPucServer也支持了该功能码。
10. SecsValue: 格式化输出代码样式的时候，支持format属性，设置true后自动换行，更加符合阅读，DEMO测试界面的客户端优化，支持设置自动回发数据，支持可选显示XML和代码样式等。
11. OpenProtocolNet: 新增属性KeepAliveMessageEnable控制是否启用心跳，修复设置管道的方式下导致订阅数据接收不到的bug，DEMO界面优化增加MID0106和MID0107的数据解析。
12. BeckhoffAdsNet: 修复再直接设置管道的情况下，可能忘记设置管道的UseServerActivePush属性导致数据在某些特殊情况下不正确的bug，现在都自动设置。
13. Demo: 测试工具中批量读取原始字节数据的时候，展示的类型新增boolarray类型选择，自动转为bool数组，表示为0,1 方便大家查看。
14. Demo: Demo界面的原始字节读取结果数据框使用等宽字体，然后支持手动设置每行显示的数据个数，不同类型的数据做了自动对齐操作。
15. Demo: 程序界面显示报文交互日志窗体时，该窗体新增过滤功能，支持日志等级，正则表达式过滤，支持输出到本地的txt文件。
16. Demo: 界面优化，点击写入bool数组的功能按钮时，输入bool数组支持0,1表示，简化输入，例如 [1,0,1,0]
17. Demo: FormKeyenceSR2000: 界面优化，点击按钮自动显示调用的代码，连接失败提示更加详细的内容。
18. Demo: 各种类型读写控件UserControlReadWriteOp基本数据的读写界面新增加搜索文本的功能，方便快速定位数据。
19. Demo: 点位变量表控件DataTableControl中，在导入数据的时候，如果碰到不支持的数据类型，错误提示进行了优化，更方便的查找问题。
20. Demo: 网口、串口的调试界面收发的数据的显示格式，从只能一样的设置，修改为支持设置不一样的格式，例如发送是ASCII，接收是二进制。
21. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
22. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
