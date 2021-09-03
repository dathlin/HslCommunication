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
			textBox1.Text = @"V10.1.4
1. NetworkAlienClient: DTU(异形)服务器增加对报文的固定头的检查。
2. NetworkServerBase: 连接异形DTU(异形)的server的方法ConnectHslAlientClient支持密码输入。
3. NetworkDoubleBase: 当设置DTU会话时，修复恰好正在读取导致报文错乱的bug，初始化成功才成功切换DTU。
4. McServer: 修复三菱的MC虚拟服务器在ASCII模式下，远程客户端读写B继电器时，地址解析异常的bug。
5. LSisServer: 修复LSisServer在客户端读写位时，PX20之类的地址时，写入true不成功的bug。
6. TemperatureController: 新增RKC的数字式温度控制器的读写类，地址支持M1,M2,M3,等等
7. TemperatureControllerOverTcp: 新增RKC的数字式温度控制器的网口透传读写类，地址支持M1,M2,M3,等等
8. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
9. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
