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
			textBox1.Text = @"V11.3.3
1. HslCertificate: 新增自定义的证书类，支持持有者颁发证书，对证书验证签名，例如可以使用证书实现对API接口权限验证，详细查看API文档。
2. OmronCipNet: 修复异步写入字符串时，编码无法指定ASCII之外的bug，导致无法使用UTF8写入中文。
3. ModbusTcpServer: 重新增加属性 StationCheck, ，当服务器只有一个站号的时候，设置为True表示校验客户端请求的站号，反之则不校验。
4. DLT645及DLT645OverTcp: 支持写入字符串的方法，字符串将会转为二进制并且颠倒顺序，写入到仪表里去，写int及double数组也会转字符串数组写入。
5. WebsocketServer: 服务器初步支持了SSL通信，使用证书通信，需要带私钥的证书才能成功创建，等待进一步的测试。
6. LogNetBase: 日志获取相关的存储列表的方法中，增加一个错误捕获，在极端情况下可能会因为错误异常。
7. Authorization: 激活系统的方法新增基于证书激活的方式，具体使用方法参考官网文档。
8. Demo: Demo主界面的左侧的设备列表信息改为浮动窗体，可以自由隐藏，DEMO也支持了使用证书激活。
9 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
10. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
