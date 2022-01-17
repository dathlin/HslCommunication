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
			textBox1.Text = @"V10.5.0
1. ABBWebApiClient: GetRobotTarget方法，返回的数据信息，增加q4数据信息。
2. Modbus: 在modbus的派生类协议中，重写了modbus的地址转换的情况中，修复读写bool操作，因为地址中带小数点导致地址转换异常的bug。例如汇川AM系列读写QX3000.0 的bool值
3. MelsecFxSerialHelper: 三菱编程口协议的检查和校验的方法，增加try...catch，在某些特殊的情况下，会导致异常，直接奔溃。
4. NetSoftUpdateServer: 针对之前旧版的软件升级功能，增加30分钟的超时时间限制，如果30分钟后仍然没有更新完成，则自动移除会话。
5. SiemensS7: S7的地址支持大小写，且都支持带X,B,D,W的地址，比如MD100, MW100, MX100.2
6. OmronConnectedCipNet: 注册报文里的不通信超时修改为42分钟，读取short，及ushort数组时，按照994长度进行切割
7. AllenBradleyPcccNet: 支持使用0F-AB的掩码写入功能，写入一个bool值到PLC中，PCCC虚拟服务器实现了这个AB功能码，可以虚拟测试。
8. FanucInterfaceNet: 修复demo上读取WO数据时，地址偏移不正确的bug。
9. Freedom: 串口，网口的自由通信协议增加委托CheckResponseStatus，可以自定义对报文结果进行校验，完善注释。
10. DLT645: 优化数据接收部分的代码，如果数据完整，立即返回，数据前面兼容无用的字符数据。
11. INetMessage: 消息类新增方法PependedUselesByteLength( byte[] headByte )并在DLT645OverTcp消息类重写，支持前置无效的字符。
12. AllenBradleyNet：支持添加消息路由功能，默认不开启，实例化属性MessageRouter, 例如：1.15.2.18.1.1，支持在demo界面进行配置操作。
13. AllenBradleyNet: 支持遍历全局变量和局部变量。新增StructTagEnumerator( AbTagItem structTag )方法遍历结构体的成员变量信息。
14. Demo:AllenBradleyNet节点浏览的界面支持了查找数据，显示数据，结构体嵌套遍历，还支持显示当前的数据信息。
15. ModbusTcpServer的RTU接收时间调整为500ms，如果报文完整立即接收结束。
16. 本版本可能是春节前的最后一个版本了，提前祝大家新春快乐。
17 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
18. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
