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
			textBox1.Text = @"V10.1.0
1. Melsec: 三菱的MC协议TCP，UDP，二进制，ASCII代码优化，一套代码实现，新增IReadWriteMc接口，针对MC协议的设备通用读写类
2. NetworkUdpBase: 新增LogMsgFormatBinary属性，可以指示当前的数据交互报文记录时按照ASCII编码显示，或是二进制显示。
3. DTSU6606Serial: 德力西的电表的读取方法ReadElectricalParameters支持HslMqttApi特性，方便MRPC及WEBAPI接口服务注册。
4. Demo: Modbus rtu的demo界面的报文读取取消crc封装，因为内部已经集成封装。
5. Melsec: 统一 MelsecMcNet, MelsecMcUdp, MelsecMcAsciiNet, MelsecMcAsciiUdp, MelsecMcRNet的代码逻辑结构，修复了ASCII格式类的一些bug。
6. MelsecMcServer: 三菱的虚拟服务器限制了bool读取长度7168限制字读取长度960，三菱MC客户端的bool读取支持自动切割。
7. OmronHostLink: OmronHostLink及OmronHostLinkOverTcp代码优化，完善错误代码文本提示，增加返回命令和发送命令校验的操作。
8. HslExtension: ToStringArray的扩展方法支持对GUID的解析功能，不支持.net20, .net35
9. NetworkDataServerBase: 修复数据类服务器在主动关闭引擎时，在线客户端的数量未及时复原的bug，影响范围，所有的虚拟PLC服务器。
10. OmronHostLinkServer: 新增欧姆龙HostLink协议的虚拟PLC，支持网口和串口的进行读写操作。优化hostlink协议的客户端错误代码含义展示，优化数据接收机制。
11. Demo: httpclient界面支持对https接口测试，在内容请求的header支持添加content-type信息，提供了一些选项。
12. SimensWebApi: 新增NetworkWebApiDevice设备类，实现IReadWritteNet接口，新增SimensWebApi类，用于西门子1500的webapi接口，可实现读写标签变量信息。
13. FanucSeries0i: fanuc的通信类支持NC程序文件的上传和下载，删除，设置主程序号，启动加工操作。修复刀具信息读取时，某个刀具信息失败导致读取失败的bug。
14. AllenBradleyServer: ab-plc的虚拟服务器支持会话id的生成，支持对客户端校验会话id是否一致。
15. Melsec: MC协议的类支持对字地址按照位读取，例如读取D100.5 开始的3个位，使用ReadBool(""D100.5"", 3)即可
16. NetworkBase: 优化ReceiveByMessage及异步版本的性能，减少一次内容数据的拷贝操作，提升内存利用效率，提升读写的性能。
17. SiemensS7Net: 西门子s7协议的地址支持 VB100, VW100, VD100的写法。
18. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
19. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
