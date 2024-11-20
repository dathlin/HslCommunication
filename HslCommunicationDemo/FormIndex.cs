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
			textBox1.Text = @"V12.1.3
1. NetworkWebApiBase: 修复webapi基类实例化后，仍然继续设置IpAddress属性时，实际请求地址不更新的bug。
2. LogNet: 日志类新增属性EncoderShouldEmitUTF8Identifier可以控制UTF编码的是否包含BOM头，默认为 true，如果不需要BOM头，可以设置为false
3. LogNetDateTime: 日期时间类型的日志新增一个实例化方法，可以同时指定文件大小，超过指定大小即自动拆分日志文件。
4. CommunicationTcpServer: 修复tcp的服务器在.net8等环境里运行的时候，在关闭服务器的时候，弹出未捕获的异常的bug，现在可以正确的关闭。
5. IEC104: 修复IEC104协议在接收某些特殊情况的报文数据导致解析异常，直接退出程序的bug，现在会进行日志的输出。
6. LogNetAnalysisControl: 日志分析的控件界面新增一个\0转义的选择框，解决日志消息里带有\0的情况导致显示阶段的问题。
7. DLT698Helper: 修复DLT698.45协议里，在某些特殊的设备上，时间数据不存在导致解析异常崩溃的bug，现在直接返回异常的时间内容。
8. HttpServer: HttpServer及MqttServer服务器新增卸载单个API接口的方法 UnRegisterHttpRpcApiSingle( string apiTopic )
9. BinaryCommunication: 所有设备的基类当因通信失败的时候，返回当前管道的基本信息，例如ip端口，或是串口的端口，方便查错。
10. HslStructAttribute: 结构体偏移字节特性新增字符串解析模式属性，可以解析普通字符串，西门子等字符串，结构体解析的属性支持了自定义类，会继续解析子类操作。
11. Demo: 显示弹窗的信息框优化，使用了自定义的窗体显示消息本文，根据文本的内容大小，来自动调整当前窗体的大小，并且父窗体居中显示。
12. Demo: 模拟数据写入的地方，支持使用随机数，使用r表示，例如 (short)r.Next(100,200) 表示100-200的随机数，最后转short类型。
13. LogNet: 日志部分的demo界面部分字符串再英文状态时，显示英文信息，优化相关的界面的测试功能。
14. Demo: 欧姆龙的虚拟服务器支持配置DataFormat及是否字符串反转的功能，所有设备的数据导出功能增加随时停止的按钮。
15. Demo: PLC测试界面读取字符串的时候，如果碰到\0 字符的时候，原先直接截断显示，对大家造成困扰，现在直接转义为 \0 显示，请注意查看
16. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
17. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
