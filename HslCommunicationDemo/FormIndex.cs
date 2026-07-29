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
			textBox1.Text = @"V12.9.2
1. InovanceEasyNetServer: 新增加汇川EasyNet协议的虚拟服务器，添加Demo测试，添加地址示例，支持客户端的所有地址。
2. OmronServer: FinTcpServer以及FinsUdpServer新增属性CopySID，用来控制返回报文是否复制SID信息，方便实际的时候配合客户端调试。
3. InovanceHelper: 汇川的型号支持了EVO系列，在demo界面上增加了EVO相关的地址示例说明，支持IX0.0   QX0.0   MW100 地址。
4. InovanceHelper: 汇川的modbus协议里，选择EVO系列的时候，增加对 MX1000.0 地址的位读写操作。
5. FanucSeries0i: 修复Fanuc的机床类，再某些特殊型号的机床遍历目录的时候，直接异常的bug。
6. SiemensS7Plus: PLC的点位地址同时支持了单引号标识，例如 'A'.'B' 也可以正确的识别，方便输入地址的时候更好的查看。
7. PanasonicHelper: Mewtocol协议使用字方式读取位地址时，当位索引指定不是16倍数的时候，提示地址输入错误，Demo界面的地址更新说明。
8. OmronHostLinkCMode: Cmode的协议（包括串口透传版本）修复读取定时器计数器位失败的异常，虚拟服务器支持TIM/CNT地址的读写功能。
9. NetworkConnectedCip: 基于连接的CIP协议基类，修复在多线程读写时，极小概率引发CIP Sequence Count序号错位的bug，导致汇川PLC接收数据超时的问题。
10.AllenBradleyServer: AB-PLC的虚拟服务器的报文响应里，对ReadFromCipCore方法进行错误捕获，防止意外的情况造成程序崩溃。
11.其它的一些小优化，针对一些报文索引可能超出范围得情况进行处理，防止极少数情况下直接奔溃的异常。
12.Doc: 官网上的在线文档增加了欧姆龙Cmode协议读写CNT/TIM的示例，增加了西门子1500得DB块在某些情况下读取数值一直是0得解决办法。
13.Demo: Demo程序的设置菜单增加设置读取bool结果显示0或1得功能，尤其是在读取大量数组的情况下，可以更快的分辨true, 还是false。
14.新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
15.本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel2.Text );
		}
	}
}
