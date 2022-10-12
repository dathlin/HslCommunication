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
			textBox1.Text = @"V11.1.1
1. Demo: 修复山武设备串口通讯调试界面，站号设置无效的bug。
2. MelsecMcServer： MC协议的虚拟服务器支持L寄存器的读写操作，原先的D寄存器范围为 D0~D65535 扩展到 D0~D131071
3. MqttSession: Mqtt会话新增属性DeveloperPermissions，标记开发者权限，服务器可以自由控制会话是否具有遍历MRPC接口的权限。
4. DLT: DLT645及DLT698协议及其网口透传类新增属性：EnableCodeFE, 莫认false，当设置为True时每次发报文到设备时都会追加FEFEFEFE的指令头。
5. OmronConnectedCipNet: 新增属性ConnectionTimeoutMultiplier用来设置异常超时时间，默认02表示32秒。
6. SiemensS7Server: 优化握手报文的数据信息，现在支持了node-red的s7功能节点的读写数据，支持了s7netplus组件的连接及读写。
7. SoftBasic: 新增从XML元素获取泛型值的便捷方法，DEMO程序的一些界面优化，串口调试界面优化，webapi服务器接口界面支持接口存储。
8. OmronFinsTcp: FinsTcp协议优化，在接收fins消息报文时，即使前面有多个无用字节数据，依然可以正确的接收并处理数据。
9. SiemensS7Server: 西门子的s7虚拟服务器的DB块优化，采用词典存储，内置DB1，2，3，其他DB块需要使用AddDbBlock方法来手动增加，否则无法读写。
10. YokogawaLinkServer: 修复横河PLC虚拟服务器的读取bool数据时，无论输入什么地址类型，都会读取m寄存器的bug。
11. HslExtension: ToHexString 的扩展方法以及SoftBasic.ByteToHexString 方法在转换byte[]到string时，支持格式化的参数，默认 {0:X2}
12. SerialBase: 修复在特殊情况下读取数据导致没有响应，也不触发超时的bug，优化modbusrtu在错误码报文下的接收完成判断。
13. MemobusTcpNet: 安川PLC修复读写扩展寄存器失败的bug，通信细节进行优化，支持对扩展寄存器的随机字读取和写入操作。并增加MemobusUdpNet类，基于UDP的实现。
14. MemobusTcpServer: 新增加安川PLC的虚拟服务器实现，支持功能码为 01 02 03 04 05 06 08 09 0A 0B 0D 0E 0F 10
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
