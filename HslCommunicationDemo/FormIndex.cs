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
			textBox1.Text = @"V12.6.2
1. FanucSeries0i: ReadFeedRate读取进给倍率的方法，修复在某些型号下读取值异常的bug，现在兼容性更好。
2. FanucSeries0i: 数据类FanucSysInfo, FanucOperatorMessage, ToolInformation, SysAlarm, SysAllCoors重写了tostring方法，可以直接转字符串显示数据。
3. FanucSeries0i: 修复宏变量读写时候，对数据解析和生成的时候，当遇到超大数据解析异常，反写数据异常的bug。
4. CommunicationTcpServer: 优化接收数据的代码，防止在一些及其特殊的情况下发生崩溃的bug。
5. FtpClient: 修复创建文件夹的时候，在指定多级目录的情况下，创建失败的bug，优化Demo界面的图标信息。
6. FtpServer: 新增加一个FtpServer类，在Demo上可以一键启动一个服务器，快速验证及收发文件，和Hsl得FtpClient测试通过。
7. OmronCipServer: 修复欧姆龙的虚拟CIP服务器，创建了bool[]数组变量后，从客户端读写bool值不正确的bug。
8. YRCHighEthernet: 安川机器人的高速以太网协议优化，字符串数据自动移除空字符，支持读取机器人的脉冲坐标，增加读取轴名称，Demo界面优化。
9. Demo: 新增sqlserver的数据存储功能，新增本地文件的数据存储功能，Demo可以直接将PLC数据存入数据库或是本地文件里。
10. Demo: 原始字节批量读取的控件支持了手动解析数据功能，并且读取时直接解析值显示，然后显示具体的解析的代码。
11. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
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
