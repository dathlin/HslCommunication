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
			textBox1.Text = @"V11.0.6
1. TcpForward: TCP转TCP类新增OnRemoteMessageReceived及OnClientMessageReceive事件，可以捕获所有的通信报文。
2. TcpForward: TCP转TCP的对象新增ConnectTimeOut属性，支持设定连接超时
3. NetSoftUpdateServer: 更新的服务器新增一个方法，GetDealSizeAndReset每秒调用即可获取当前的下载网速信息
4. AllenBradleyNet: 完善了路由信息，支持了一种特殊的路由信息的消息，格式为 1.1.2.130.133.139.61.1.0。
5. TcpFoward: TCP转发的类新增一个属性OnlineSessionsCount，获取当前在线会客户端会话数量信息。
6. SecsHsms: 新增属性 InitializationS0F0，默认为false，指示是否在初始化的时候，发送功能码 S0F0。
7. Lognet: 优化日志存储器在计算过期日志文件并删除的代码，现在触发新增文件时，才进行删除旧的文件信息。
8. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注，新官网：http://www.hsltechnology.cn/。
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
