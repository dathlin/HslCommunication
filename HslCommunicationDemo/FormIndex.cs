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
			textBox1.Text = @"V10.1.2
1. feat(UltimateFileServer): 获取文件服务器的指定目录的大小的方法改为获取大小，文件数量，最后一个文件修改时间的方法，客户端同步更新GetGroupFileInfo。
2. feat(MqttServer): 获取文件服务器的指定目录的大小的方法改为获取大小，文件数量，最后一个文件修改时间的方法，客户端同步更新GetGroupFileInfo。
3. feat(UltimateFileServer): 新增一个获取指定目录所有子目录的基本信息，包含总大小，文件数量，最后一个文件修改时间，GetSubGroupFileInfos
4. feat(MqttServer): 文件服务器新增一个获取指定目录所有子目录的基本信息，包含总大小，文件数量，最后一个文件修改时间，GetSubGroupFileInfos
5. SiemensWebApi: 修复在.net standard2.0及2.1中未添加SiemensWebApi类的bug。
6. MelsecA3CNetHelper: 优化数据解析时，对错误异常的处理，增加错误捕获。
7. LSisServer: 重写串口Cnet协议的数据接收，处理，和返回，支持了单变量数据，和连续数据的读写操作。
8. XGBCnet, XGBCnetOverTcp: 重新实现了类，统一了代码，重新解析的数据内容，支持了对错误码的提取和错误消息的解析。
9. XGBCnet: 支持Read(string[]); 读取多个地址的数据信息，自动按照每16进行拆分访问。
10. memobus: 新增memobus通信协议，初步实现了读取的操作，具体还需要测试，如有网友有测试条件，可以联系我测试。
11. Yamatake: 新增山武的数字示波器的CPL协议的通信对象和虚拟服务器，分别是DigitronCPL,DigitronCPLServer
12. MqttServer, HttpServer: 使用HslMqttApi特性注册远程RPC接口时，支持对异步方法(async...await)进行注册，并进行异步调用，返回相关数据。仅支持NET451及以上。
13. HslMqttApi: 在注册RPC接口时，增加了对方法签名的解析过程，客户端可以浏览服务器接口的方法签名，清楚的看到返回类型，参数类型信息。
14. Delta: DeltaDvp系列的网口，串口协议，修复在跨区域读写M1536及D4096时，地址偏移不正确的bug。现在会自动跳转。
15. MqttServer: 修复Mqtt客户端在取消订阅时，传入多个的Topic时导致服务器解析异常的bug。
16. 官网地址： http://www.hslcommunication.cn 官网的界面全新设计过，感谢浏览关注。
17. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
