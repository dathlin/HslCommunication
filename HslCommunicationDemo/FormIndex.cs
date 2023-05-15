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
			textBox1.Text = @"V11.5.3
1. NetworkBase: 在ReceiveByMessage方法里，新增判断消息报文剩余长度小于0时，直接返回头报文信息，防止在万一接收到错乱数据导致小于0引发bug的异常。
2. FFTFilter: 傅立叶变化的Filter滤波方法，修复当数据有负数的时候，只能得到正数结果的bug，现在可以还原出带有负数情况的波形图。
3. SiemensS7Server: SiemensS7Server增加在握手报文处理时，对握手报文合法性的检查操作，防止收到一些奇怪数据时导致奔溃。
4. DLT698: 修复在UseSecurityResquest为默认True情况下，APDU指令创建不正确的bug，涵盖DLT698, DLT698TcpNet, DLT698OverTcp类。
5. FanucSeries0i: 新增根据字符串程序名读取程序的方法接口ReadProgram( string program, string path = "" )，用来支持读取非数字名称的程序号。
6. Toyota: 新增丰田工机的计算机链接协议实现，ToyoPuc 类，通过2PORT-EFR模块实现对PLC的读写数据操作，同时增加ToyoPucServer虚拟PLC进行测试。
7. DLT698: 修复698的协议中的CheckResponse，当请求类型不支持时，引发空对象的异常。
8. SerialBase: 间歇时间SleepTime允许设置0及小于0，小于0就是不进行任何休眠，三菱编程口MelsecFxSerial增加对消息完整长度的校验机制。
9. OmronCipServer: 新增欧姆龙自身的CIP服务器，支持客户端使用OmronCipNet类和OmronConnectedCipNet进行通信，支持普通点位，数组，字符串的读写操作。
10. CipServer: AllenBradleyServer和OmronCipServer支持所有的标签数据存储到文件和从文件加载的操作，demo里服务器的存储加载支持路径选择。
11. MelsecA1EServer: 新增模拟PLC的实际情况，针对bool读取长度超过256返回错误码，针对字单位读取长度超过64即返回错误。
12. MelsecA1E: MelsecA1ENet及MelsecA1EAsciiNet类修复读取bool数组时长度超过256报错的bug，MelsecA1EServer完善读取bool超过256返回错误。
13. Mewtocol: 松下的Mewtocol的串口及网口类对象新增支持读取PLC型号的方法ReadPlcType，虚拟服务器也支持了该功能码。
14. SerialBase, NetworkDoubleBase: 优化通信代码，针对Thread.Sleep方法也进行错误捕获，防止可能的异常。
15. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
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
