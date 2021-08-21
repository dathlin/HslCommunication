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
			textBox1.Text = @"V10.1.3
1. JSON: .NET framework的dll对newtonsoft.Json不依赖特定的版本。
2. XGBFastEnet: 修复读取单个的bool时报文不正确的bug.
3. MqttServer: 新增GetMqttSessionsByTopic方法，用来获取订阅某个主题的所有客户端列表。
4. HttpServer: 修复httpserver中文编码问题，在谷歌，微软浏览器下显示中文乱码的bug。因为Content-Type传值不正确
5. HttpServer: 修复在账户验证模式下，使用ajax跨域请求OPTIONS导致401错误的bug。
6. FujiCommandSettingType: 新增富士的CommandSettingType通信协议的实现，基于TCP访问，支持地址见API文档.
7. FujiCommandSettingTypeServer: 新增富士的CommandSettingType协议的虚拟PLC，支持B,M,K,D,W9,BD,F,A,WL,W21地址
8. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
9. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
