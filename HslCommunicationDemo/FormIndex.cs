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
			textBox1.Text = @"V11.5.0
1. DLT698: 698协议新增属性UseSecurityResquest，设置是否使用安全模式来通信，默认true，影响范围包括串口，透传，网口类，特殊的仪表需要设置 false。
2. DLT698: 新增写入时间数据到地址地址的接口，WriteDateTime( string address, DateTime time )，新增698协议的接口 IDlt698
3. FanucInterfaceNet: Fanuc机器人对象读取机器人数据时，FanucData解析字符串数据的编码可以手动调整指定。
4. MelsecFxLinksHelper: 三菱的计算机链接协议里，如果传入的报文以ENQ开头的，则认为传入原始包，不进行封包处理。
5. OmronFinsAddress: 欧姆龙的Fins协议支持CF地址，可以读取脉冲信号，地址一秒脉冲地址示例：CF1.2  新增IHostLinkCMode, IOmronFins接口。
6. 新增三菱的编程口接口 IMelsecFxSerial，新增西门子PPI接口 ISiemensPPI，永宏编程提炼接口 IFatekProgram
7. AllenBradleyNet: 批量读取地址数组的方法，传入长度数组参数由 int 改为 ushort 类型，所有的CIP协议实现了统一的IReadWriteCip接口。（可能不兼容）
8. FanucSeries0i: ReadProgram方法取消再次接收0x18的命令，因为在 32i 的机子上是会触发超时接收。
9. YamahaRCX: 雅马哈机器人新增 JogXY 接口，使用微动的方式操作六轴的动作信息，在demo界面上支持JOG的测试。
10. AllenBradleyHelper: 修复CIP协议创建命令为0x4D写入数据报文时，数据长度过大导致溢出的bug，在解析返回结果数据时增加错误捕获操作。
11. Modbus: 所有Modbus的客户端以及RTU主站类，接口IModbus新增使用功能码0x17的一条报文实现读写方法ReadWrite，虚拟服务器支持该功能码。
12. SiemensS7Net: Read( string[] address, ushort[] length )方法不仅仅根据19个长度切割，还根据长度之和是否满足200字节切割。
13. FinsTcp: Fins协议读取bool时，发现返回数据长度小于指定长度时，自动偏移地址并读取剩余数据，然后返回全部给调用者。
14. SimpleHybirdLock: 通信的混合锁新增当前锁对象等待的计数属性：LockingTick，可以用来监视锁对象的竞争情况。
15. Demo: TCP转TCP的支持二进制和ASCII格式的转换显示，完善MegMeet，Lsis的添加，批量读取控件增加提示功能。
16. HslCommunication: 大部分PLC通信的消息解析代码增加合法性验证，并且增加异常捕获，防止及其特殊的情况导致系统奔溃。
17. Demo: Demo程序大升级，测试界面支持定时读取，定时写入，写入支持动态数据变化。批量读取，报文读取，特殊功能测试优化，更加便捷。
18. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
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
