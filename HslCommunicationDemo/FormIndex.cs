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
			textBox1.Text = @"V9.3.1
1. Beckhoff: 倍福PLC新增读取设备信息和设备状态的api接口。在demo界面添加测试按钮，状态码检查优化，错误时返回报文信息。
2. FanucSeries0i: 修复fanuc机床的读取宏变量解析double数据时，为0的时候解析异常的bug。
3. ABBWebApiServer：ABB机器人的虚拟服务器支持用户名和密码设置，在客户端请求数据的时间，支持账户验证。
4. Demoserver: 优化根据IP地址获取物理地址的方法，获取不到或是奇怪字符将切换线路重新获取。
5. KukaTcpNet: 新增KukaTcp通讯类，支持多变量写入的api，在demo界面增加启动，复位，停止程序的操作。
6. .Net Framwork 2.0 支持2.0的框架的dll发布，通过nuget安装即可。
7. SimpleHybirdLock: 简单混合锁添加一个当前进入锁的次数的静态属性，可以查看当前共有多少锁，等待多少锁。
8. NetworkDeviceBase: 核心交互方便增加错误捕获，异常释放锁，再throw, YamahaRCX类完善异步方法
9. NetworkBase: 增加一个线程检查超时的次数统计功能。
10. InovanceH3U: 修复汇川的3U的PLC地址类型为SM,SD时解析异常的bug。
11. Demo: HslCommunication Test Demo支持PLC及一些连接对象的参数保存功能，使用英文冒号可以分类管理。
12. WebSocketSession: 新增url属性，如果客户端请求包含url信息，例如：ws://127.0.0.1:1883/A/B?C=123, 那么url就是这个值。
13. Demo: 测试的DEMO程序，支持连接参数存储，不用再每次打开程序重新输入IP地址，端口，站号等等信息，可以存储起来，还支持分类存储。
14. 官网地址： http://www.hslcommunication.cn 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。
16. HSL的目标是打造成工业互联网的利器，工业大数据的基础，打造边缘计算平台。";
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
		MessageBox.Show( " + "\"授权失败！当前程序只能使用8小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		MessageBox.Show( " + "\"Active Failed! it can only use 8 hours\"" + @" );
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
