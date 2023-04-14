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
			textBox1.Text = @"V11.5.1
1. MelsecFxSerial: MelsecFxSerial的报文日志记录格式调整为ASCII格式，当设备的日志实例化时，就会自动当前的通信日志。
2. IReadWriteMc,IReadWriteA3C: 新增属性EnableWriteBitToWordRegister，当开启后支持往D寄存器写入位数据，实现方式为读字，修改位，写字操作，具体风险查看该属性说明。
3. KeyenceMcNet, KeyenceMcAsciiNet: 基恩士的MC协议的通信，修复ZR地址因为地址进制导致读取不到正确地址的bug，现在使用16进制地址表示。
4. KeyenceMcNet, KeyenceMcAsciiNet: 地址兼容了基恩士自己的地址格式，可以直接输入 DM100, FM100, EM100, MR015, 或是直接 MR1.2 等
5. HslHelper: 新增属性LockLimit表示竞争锁上限(默认1000)，NetworkDoubleBase,NetworkUdpBase,SerialBase检测当锁竞争达LockLimit次时，直接返回失败，不在增加竞争。
6. HslTimeOut: 检查socket超时部分的功能代码，当处于linux系统下时，在确认超时close之前，增加一个 Disconnect操作，解决特殊情况close会卡时间的bug。
7. HslHelper: HslHelper新增属性UseAsyncLock, 标记本通信库的单个通信对象在异步通信的时候是否使用异步锁，默认True, 当使用控制台或是纯后台线程采集时，配置 False 更好。
8. Modbus: 在写入单个的short及ushort值时，默认使用06功能码，现在支持如果在地址里使用w标记，例如 w=16;100  时，写入时报文就使用16功能码。
9. TcpForward: 新增属性CacheSize，表示中转时候的数据缓存大小，默认是2048
10. Net2.0, 3.5, Standard项目添加缺失的类：VigorServer, OmronHostLinkCModeServer, MelsecFxLinksServer, KeyenceDLEN1
11. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
12. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
