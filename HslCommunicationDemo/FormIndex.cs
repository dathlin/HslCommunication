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
			textBox1.Text = @"V12.6.4
1. FtpServer: 修复FTP服务器收到CMD命令时，当没有空格时引发异常的bug，修复Demo里FTP代码生成的一点小问题。
2. Cip: AB得CIP协议，地址格式支持了实例特性的地址，格式为 class=1;attr=3;2  标识类id为1，实例为2，特性为 3 的地址，可以进行读写操作。
3. ABBRobot: 移除abb机器人的server，放到demo里测试，Demo客户端支持浏览API接口列表，abb机器人类优化代码，部分接口支持传入参数对象。
4. ByteTransformHelper: 优化代码，使用Then链式编程来处理多个参数的方法，修复GetResultFromOther十个泛型参数方法的判断异常。
5. ModbusTcpServer: Modbus服务器新增地址映射功能，可以自由注入地址映射关系，Demo界面上增加库里其它Modbus设备相关的地址映射选择。
6. Socket: 修复通信库创建Socket的时候，在某些特殊的运行环境下(有网友反馈ARM32下的.net8，也不是绝对的)可能导致异常的bug。
7. MqttServer: 新增OnClientSubscribe事件，当客户端订阅主题的时候触发，通过返回值可以控制客户端是否可以订阅这些主题内容。
8. FanucSeries0i: 修复fanuc机床读取进给倍率，在某些特殊的型号上读取值不正确的bug。
9. FtpServer: FTP服务器支持了CWD ..及CDUP命令，默认编码修改为GB2312,通过OPTS切换UTF8编码，支持了FileZilla客户端连接下载。
10. ToyoPucServer: 丰田工机的虚拟PLC得地址支持了位得格式，例如 D100.0   D100.10  然后使用bool读写操作，和客户端保持一致。
11. Doc: fanuc机床类增加一个说明，在跨平台框架下，需要安装codepage组件，并且注册编码，然后设置 gb2312 编码，才能正确解析字符串不乱码。
12. Demo: Demo界面新增加一个端口映射的功能测试，可以将本地的设备ip及端口，映射到服务器的端口上，HSL提供免费30分钟连续映射测试。
13. Demo: Demo界面上的读取，写入地址数据的功能里，针对地址进行了记忆操作，自动记忆12个地址，方便快速切换，支持保存。
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
