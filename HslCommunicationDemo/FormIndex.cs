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
			textBox1.Text = @"V11.3.0
1. byte[]: 类型byte[]新增加一个扩展方法，ReverseByWord，直接可以调用按照字反转字节数据信息。
2. OmronCipNet: 欧姆龙的CIP协议优化，写入数组时，根据地址是否带索引，来自动确认写入的长度信息。
3. MelsecMcServer: MC协议的虚拟PLC部分，在二进制下支持了随机字读取（0403）和块读取（0406）的功能码。
4. WebSocketServer: 现在服务端新增属性：TopicWildcard，如果客户端使用通配符订阅数据点。规则和MQTT的通配符一致。
5. HttpServer: 修复request.ContentType为空的情况下引发的异常，原因来自对文件上传的判断。
6. SiemensS7Net: 修复西门子PLC在不连接的情况下，直接同步方法读写PLC相关的值的时候，因为pdu初始值不正常导致第一次读写失败的bug。
7. Demo: Tcp的服务器调试界面里，修复点击发送客户端时，发送的数据不显示的bug。
8. DLT645With1997OverTcp: 修复使用异步ReadDoubleAsync读取数据的时候，数据结果解析不正确的bug。
9. OpenProtocolNet: 完善开放以太网协议，并且基本测试通过，支持自定义的功能码读取，支持订阅操作。
10. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
11. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
