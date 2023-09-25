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
			textBox1.Text = @"V11.6.3
1. ModbusTcpServer: 当客户端使用了0xff的站号（10进制为255）的时候，将自动忽略对站号的校验，直接可以进行读写操作。
2. SiemensS7Net: 新增强制位ForceBool方法，以及取消强制CancelAllForce方法，目前针对200smart测试通过，支持对I,Q的点位强制操作。
3. OmronFinsServer: 优化返回的报文信息，方便wireshark软件抓包进行分析操作，识别到正确的Fins协议。
4. SiemensS7Net: 西门子s7协议的报文中，消息号id修改为自增，修复了在某些特殊的200smart型号读取超时的异常。
5. OmronCipNet, OmronConnectedCipNet: 读取字符串的方法，在解析字符串数据内容的时候，增加错误捕获，并返回数据的二进制内容。
6. NetworkDeviceBase: 写入数据的几个类型的重载方法，也更改为虚方法，支持子类重写操作。
7. SiemensS7Net: 新增方法  Write( string[] address, List&lt;byte[]> data )支持同时写入多个数据块的地址数据，SiemensS7Server也支持多个数据块的写入功能。
8. Melsec: 三菱的协议MelsecA1ENet，MelsecA1EAsciiNet, MelsecFxLinks(含串口及以太网), MelsecA3CNet(含串口及以太网), 读取bool时支持字地址的位，例如 D100.0
9. CJT188Helper: 水表协议188修复再某些特殊的情况下解析结算累积量异常时，导致读取当前累积量也失败的bug。
10. OmronFinsNet: 新增属性 ReceiveUntilEmpty, 默认false，设置true后可以在一些及其特殊的场景里防止数据错误的情况。
11. LogNetManagment: 日志管理对象的一个静态方法优化，增加错误捕获，防止极小概率的意外情况。
12. SiemensS7Plus: 新增基于s7plus协议的通信对象，使用SSL/TLS加密通信，支持读写数据，不需要开启put/get，支持遍历点位，仅支持.net framework平台，还需要依赖两个openssl的C++库。
13. Demo: 支持将PLC数据定时读取，然后导出到单个文件。然后可以在虚拟服务器上进行加载文件，然后定时写入，可以本地模拟现场设备数据。
14. Demo: 原始字节的批量读取功能显示效果，新增整型显示，当切换hex，ascii，整型的时候，自动更新显示数据，更加便捷。
15. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
16. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
