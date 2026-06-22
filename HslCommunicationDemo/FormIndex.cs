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
			textBox1.Text = @"V12.9.0
1. AllenBradleyNet: 新增属性ContextIdAutoIncrement，用来设置通信报文里的上下文消息ID是否自增，默认为true, 设置false可以支持科伺PLC的通信。
2. OrientalMotorEipNet: 修复接收一段时间后，就收不到数据的bug，新增收不到数据时直接返回失败，提示调用者，Demo界面的显示数据接收情况优化，显示数据不影响数据接收。
3. HttpServer: 修复Http的服务器，在某些特殊情况下，发生处理response异常直接导致系统崩溃的bug，感谢网友反馈。
4. PanasonicMcNet: 松下的MC协议的地址输入，支持了 DT 写法，D100 = DT100， 方便使用松下习惯的地址，Demo界面的地址增加说明。
5. Modbus: modbus的地址支持了16进制的格式，带H结尾表示十六进制，例如 100H， FFFFH，修复起始地址从1开始的时候，输入读取 65536 的地址报错的异常。
6. Modbus: 修复数据变换为 BADC 及 DCBA 时，设备支持掩码功能码的时候，读写bool不一致的异常。
7. AllenBradleyNet: 修复AB-plc的CIP协议里，当使用分批次读取结构体数组时，返回数据部分丢失的bug，原因来自偏移位置计算不正确。
8. AllenBradleyNet: 普通的写入方法也支持了结构体数据，然后片段读取结构体数组时，实际分了多次报文的情况下，除第一次报文外，移除后续每次报文的结构体标识，方便调用者解析数据，直接根据长度即可。
9. XinJEServer: 信捷专用协议虚拟服务器支持了HM的位读写地址，然后Demo界面支持了设置DataFormat设置的功能。
10. SiemensS7Plus: 重新设计根据标签名查找LID地址方法，删除属性BrowseTagNameOnConnect，连接即可以读取标签地址，自动解析操作。Demo界面分数据块加载点位表，支持了嵌套的结构体数组的标签地址显示。
11. Demo: 新增科伺的PLC测试界面，实际使用欧姆龙的CIP协议来通信，但是必须设置属性 ContextIdAutoIncrement=false, 才能通信，具体参考示例代码。
12. Demo: Demo界面里关于汇川的H5U、Easy系列的modbus的示例地址，独立出来，修复之前显示不正确的bug。
13. Demo: Mqtt服务器客户端的主题统计控件，增加了调整表格框大小的功能，增加清除当前所有缓存主题的功能，方便测试。
14. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
15. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
