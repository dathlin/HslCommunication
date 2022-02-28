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
			textBox1.Text = @"V10.5.1
1. AllenBradleyNet: Write( string address, bool value )写入bool方法优化，如果是类型代号0xD3的，地址前面需要增加 ""i="" 标记。
2. PanasonicMewtocolServer: 松下虚拟PLC地址类型支持完善线圈支持X,Y,R,L, 字单位的整型支持 X,Y,R,L,D,LD,F，支持RCP及WCP指令离散读写线圈。
3. PanasonicMewtocol：松下协议及其网口类的代码优化提炼共同代码，新增加离散bool地址的读写，传入多个地址，返回一个bool数组。
4. AsciiControl: 在命名空间slCommunication.Core下面增加一个AsciiControl类，包含控制类ASCII常量定义，例如ENQ,NAK,STX,ETX等。
5. MelsecFxLinksServer: 新增三菱的FxLinks计算机链接协议的虚拟PLC，支持串口和网口透传访问，支持格式1，4切换，支持是否和校验。
6. MelsecFxLinks: 1. 同时支持了格式1，格式4，2. 支持了地址大于10000的时候使用QR,QW命令，3. 修复报文创建时数据长度及站号不是16进制的bug。
7. KeyenceNanoServer: 修复启动串口时，和上位链路客户端通信时，一直返回通信校验错误的bug，现在针对CC指令和CQ指令都能正确的返回。
8. keyenceNano: 基恩士上位链路协议的串口类和网口透传类记录报文的格式调整为ASCII码，这样更加直观。
9. NetworDataServerBase: 添加GetNewNetMessage( )及ReadFromCoreServer方法，精简所有继承的子类虚拟PLC的服务器的代码。
10. MelsecA1EServer: 修复三菱A1E协议服务器报文接收异常的bug，导致客户端读写数据不正常。
11. FatekPrograme: 永宏编程口协议读取字按照64字长度自动切割，支持了RUN,STOP，读取状态接口方法，新增对应的虚拟服务器实现。
12. SpecifiedCharacterMessage: 新增基于指定字符结尾的消息类，通过ProtocolHeadBytesLength属性变种而来，NetworkBase的ReceiveByMessage功能适配了SpecifiedCharacterMessage消息。
13. Turck: 新增图尔克的Reader协议实现，支持对字节读写，bool读写，实现了虚拟服务器，通过了单元测试，主要用来和RFID进行通信。
14. IEC104: 初步添加IEC104协议实现和解析，增加demo测试，但是目前还清楚怎么设计API和使用场景，等待继续优化，欢迎相关需求的人联系测试优化。
15. DEMO: RSA加密解密的测试界面，支持对超长的数据进行加密解密操作。
16. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
17. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
