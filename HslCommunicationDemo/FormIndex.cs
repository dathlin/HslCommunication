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
			textBox1.Text = @"V12.6.0
1. Cip: 修复CIP协议(包括ab和欧姆龙)里，当地址里指定type信息写入数据的时候，因为type输入异常导致解析解析不正确的bug，现在读写tag均自动识别type参数。
2. FtpClient: 针对serv-U创建的FTP服务器做了适配优化，当解析文件信息时，修复解析异常直接导致奔溃的bug，现在返回错误信息。
3. FtpClient: FTP客户端适配了FileZilla Server创建的FTP服务器，支持了浏览文件，上传，下载，删除，重命名等操作。
4. NetworkWebApiBase: http请求的客户端类新增属性Timeout，用来设置请求的超时时间，代码优化，demo界面显示了请求的示例代码。
5. NetworkWebApiBase: 新增加一个RequestAsync重载方法，请求 form-data 数据，DEMO界面优化调整，支持选择上传数据格式，支持提交表单的方式请求。
6. BeckhoffAdsNet: 修复倍福的Ads协议示例化对象后先设置TargetAMSNetId再设置ip地址，导致target信息被覆盖的bug。
7. SiemensS7Net: 属性PDULength从只读修改为可读写，可以手动修改为其它值，如需恢复默认，设置-1即可
8. NetworkWebApiBase: 修复当设置了用户名密码的情况下，连接服务器仍然提示授权不对的bug，每个请求都进行设置基本账户认证。
9. InovanceComputerLink: 新增汇川的计算机链接协议，从三菱的计算机链接协议变化而来，测试虚拟服务器使用三菱FxLinksServer即可。
10. LogNet: 修复多个日志对象均绑定同一个日志文件时，因为并发存储日志到文件，导致日志奔溃的bug。
11. YuDianAIBus: 新增宇电的示控制仪表得AIBus协议实现，初步支持，实际通过测试。
12. Demo: 新增加了窗体退出的确认按钮选择，支持记录打开位置及界面大小，统一了DEMO主窗体配置菜单，所以配置信息都支持关闭保存，启动恢复配置。
13. Demo: HttpSever及MqttServer测试界面支持将DEMO其他PLC连接对象注册为RPC接口，支持卸载接口。
14. Demo: 修复Dlt645-1997 over tcp的测试界面，设置站号后连接，实际站号设置不生效的bug。
15. Demo: HttpClient的DEMO测试界面，支持用户自己缓存测试的自定义接口，然后点击右上角保存连接将用户接口保存下来，方便下次测试。
16. Demo: Demo界面的调试菜单新增记住窗体位置及大小的功能，勾选时则保存想关信息，下次打开自动复原。
17. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
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
