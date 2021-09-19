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
			textBox1.Text = @"V10.2.1
1. SiemensS7Net: 修复读写WString字符串时，乱码的情况。
2. NetSoftUpdateServer: 修复在某些情况下在线客户端数量新增后不会减少的bug。
3. demo: 字节转换工具界面增加字节数组和base64字符串的转换功能。
4. MqttServer: 当MQTTClient在加密模式下，订阅一个主题后，修复服务器仍然返回没有加密的bug，导致客户端解密失败。
5. MqttSyncClient: 修复加密模式下，使用SetPersistentConnection设置长连接，不进行ConnectServer直接第一次请求失败的bug。
6. AllenBradleyNet: 优化读取bool的功能方法，新增读取bool数组的实现。
7. NetworkDataServerBase: 所有串口类的服务器（从机），功能代码优化调整，部分的类实现报文完整性判断，实现数据瞬间回复客户端（主机）。
8. Serial: 大量的串口类的设备进行了优化，对接收结果是否结束进行判断，提高了串口通信的性能。
9. NetSoftUpdateServer: 新增另一种更新机制，更新软件在收到文件信息后，先比对MD5信息来确定是否下载更新，从而提高升级速度，仍然兼容旧的更新模式。
10. NetSoftUpdateServer配套的更新客户端，软件自动更新重新命名为 AutoUpdate, 针对差异化更新做了优化。
11. DEMO里面所有的读写PLC界面的读写字符串功能支持了可选编码，支持ASCII,UTF8,UNICODE,UNICODE-BIG,GB2312,ANSI
12. 其他一些细节的优化，和注释的完善。DEMO界面的大量优化，显示调整，DEMO使用了新的更新软件，AutoUpdate.exe
13. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
14. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
