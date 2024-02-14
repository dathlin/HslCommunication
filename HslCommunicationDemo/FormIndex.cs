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
			textBox1.Text = @"V11.8.2
1. OmronFinsNetHelper: 欧姆龙的Fins协议的从错误码获取消息文本的方法修复部分错误码获取文本不匹配的bug。
2. MqttServer: MQTT服务器针对每个会话的客户端(针对客户端启用了RSA加密的情况)使用临时生成的AES随机密钥，防止AES密钥被伪装客户端获取。
3. NetworkDoubleBase类的ConnectClose方法以及ConnectCloseAsync方法取消了锁操作，一般建议系统退出时再调用一次，demo上接收超时时可以立即关闭连接。
4. NetworkBase类以及NetworkDoubleBase类所有的异步操作方法添加.ConfigureAwait( false )操作，防止在部分特殊的情况下使用异步导致死锁卡死UI
5. MqttServer: 支持MqttSyncClient客户端获取服务器当前的所有的所有在线的会话信息，并增加发布的topic统计功能，也就是客户端可以远程查看服务器在线会话，需要开发者权限帐户。
6. DEMO MqttServer服务器的测试界面显示的内容优化，显示了在线客户端的详细信息，显示了客户端发布的主题的基本信息。
7. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
8. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
