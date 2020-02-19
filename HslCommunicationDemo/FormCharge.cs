using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormCharge : HslFormContent
	{
		public FormCharge( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel1.Text );
		}

		private void FormCharge_Load( object sender, EventArgs e )
		{
			textBox1.Text = @"V9.0.1
1. 底层的网络在对方关闭连接后，不再等待接收，直接返回对方已关闭的错误信息，提供通信的性能。
2. 四个服务器类，complexserver, simplifyserver,mqttserver,websocketserver开发关闭客户端连接的方法，调用者可以手动操作关闭。
3. MQTT服务器新增一个客户端上线事件，包含客户端的会话参数，方便实现一些特殊的场景需求，在api文档中增加调用示例。
4. Websocket服务器新增一个客户端上线事件，包含客户端的会话参数，方便实现一些特殊的场景需求。
5. Websocket服务器添加0x0A的心跳返回，用于有些客户端的心跳验证操作。
6. RedisClient: redis相关的代码优化，调整，添加了异步api接口，本机性能测试不如同步，有待优化。
7. RedisClient: 新增基于特性的读写，自动组合键批量读取，组合哈希键批量读取操作，提升性能，详细参考api文档。写入操作不支持列表相关的特性。
8. Demo的写入byte操作的反射代码获取失败的bug修复。";
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
			FormCharge_Load( sender, e );
		}
	}
}
