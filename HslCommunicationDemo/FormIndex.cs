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
			textBox1.Text = @"V11.2.1
1. SiemensPPIOverTcp: 修复在通信速率比较慢的情况下，数据包发生多次接收的时候，接收不正确的bug。
2. SecsValue: 修复在创建None类型的数据时，引发空对象的异常。
3. SecsHsms: 优化Secs协议的客户端和服务器的心跳接收，修复了和其他客户端测试连接不正常的bug，DEMO界面添加大量的测试信息。
4. CJT188: CJT188OverTcp 协议新增属性 StationMatch 用来标记是否匹配到站号一致的报文再返回，默认为false，修复读取数据失败时，直接报异常的bug。
5. SiemensS7Server: 修复西门子虚拟PLC在使用node-red的s7组件访问时频繁在线，掉线的bug，原因来自消息id不匹配。
6. DLTTransform: 当没有遇到内置转换DLT数据的时候，不再返回失败，返回数据的HEX字符串形式，用来支持扩展的情况读取。
7. HslCommunication的netstandard版本的库所依赖的System.IO.Port 版本调整为 6.0.0
8. Demo: 完善TCP/UDP调试窗体，Server端修复选择文本不显示字节长度的bug，修复关闭时连接不断开的bug，界面位置调整优化。
9. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
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
