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
			textBox1.Text = @"V9.6.2
1. OmronConnectedCipNet: 新增欧姆龙的基于连接的CIP实现，测试读写欧姆龙PLC成功，支持数组读写，详细参考API文档，欧姆龙的CIP请使用本类。
2. AllenBradleyNet: 修复当自动重连时，连接的ID 还是上次的 ID 导致读写失败的bug。
3. DLT645: 点对点模式下，在读取地址域的时候，新增读取成功后即修改当前的地址域信息，也即是在打开串口后，读取地址域即可通信。
4. DLT645: 修复有些数据格式不一致导致读取数据不正常的bug，已经测试可以读取功率，能耗，电压电流，电表基本信息，还支持自定义的解析格式。
5. NetworkAlienClient: DTU客户端增加对连接客户端的注册包的数据校验，修复数据意外的情况导致程序奔溃的bug。
6. Demo: 在 演示程序里，Modbus的DTU的示例界面，修复 ID 设置时，结果设置到 IP 导致异常的bug。另外增加西门子的DTU演示界面。
7. LSisServer: 修复同一地址，数据读写不对的bug，和 XGKFastEnet 客户端读写测试通过，包括bool类型地址，字地址
8. GeSRTPNet: 新增 GE-PLC（通用电气） 的SRTP协议实现的客户端，支持I,Q,M,T,SA,SB,SC,S,G 的位和字节读写，支持 AI,AQ,R 的字读写操作。
9. GeSRTPServer: 新增 GE 的 SRTP 协议的虚拟PLC，支持和 GeSRTPNet 通信测试。支持类型和客户端支持的一致。
10. MqttServer: 在启动文件服务功能时，增加对分类路径，以及文件名的合法性进行校验，防止注入特殊字符攻击及意外bug。
11. MqttSession: 新增一个方法，GetTopics() 用于获取当前的会话对象所订阅的主题的副本数据。
12. PanasonicMewtocol: 修复 Mewtocol及串口转网口类，在批量读取 bool 数组地址解析不准确的bug。
13. MelsecCipNet: 新增三菱的CIP协议功能，PLC使用了 QJ71EIP71 模块时就需要使用本类来访问。
14. SickIcrTcpServer: 修复当关闭服务器的时候，现有的连接没有关闭的bug，没有关闭的话，仍然会接收到来自设备发来的条码信息。
15. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
16. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
