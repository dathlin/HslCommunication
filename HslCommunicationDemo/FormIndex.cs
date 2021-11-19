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
			textBox1.Text = @"V10.3.0
1. AllenbrandlyNet: ExtraOnDisconnect方法增加socket的空检测操作，因为在极少数特殊情况会发生空的异常的bug。
2. OmronCipNet: 修复Write数据类型为short[]时长度不是1的bug。同步方法调用Write(string,short[])时会发生写入失败。
3. Demo: OmronHostLinkCModeOverTcp的Demo测试界面添加读取型号的功能，可以更加便捷的测试。
4. AllenBradleyNet: 重写读取字符串方法ReadString( string address, ushort length )，编码修改为UTF8
5. ReverseWordTransform: 字节变换的对象代码优化精简，ReverseWordTransform新增IsInteger16Reverse属性指示short,ushort是否发生翻转，默认翻转。适用极个别特殊的Modbus格式
6. YRC1000TcpNet: 安川的机器人的API功能大量添加，支持读取机器人坐标，各种变量信息，启动程序，停止，复位，读报警等待。
7. SiemensS7Net: 写入bool数组的方法优化，修改为先读取byte[], 修改中间的位，然后再写回去操作，可以写入一个字节的中间几个位，单元测试通过，仍然有风险，谨慎调用。
8. OmronHostLinkCMode: 修复OmronHostLinkCMode读写字节顺序颠倒的问题，新增了读取plc型号，plc状态，修改状态的功能，增加错误码文本解释。
9. OmronHostLinkCModeServer: 新增CMode协议对应的虚拟PLC服务器，初步实现了和客户端通信功能，包括串口和网口的支持，单元测试通过。
10. 添加在NET2.0，NET3.5及Standard项目缺失的SiemensFetchWriteServer, MelsecA3CServer, MelsecA1EServer, 以及安川的 memobusTcpNet
11. SiemensS7Net: 在读取单个的bool的值的时候，增加对结果数据的合法性检测，当遇到错误码时，提示错误信息。修复写入bool在某些特殊的情况下，实际成功但是提示失败的bug。
12. YRCHighEthernet: 安川机器人添加高速以太网通信，基于UDP实现，在DEMO界面可以直接原生命令测试，支持读取报警，字节，整型，字符串等变量。
13. PipeSerial, PipeSocket: 新增串口管道和网口管道，串口基类和网口基类优化重构，允许多个串口设备对象共享一个串口通道，多个网口的设备对象共享一个网口通道。
14. ModbusTcpNet:新增属性IsCheckMessageId，用于配置modbustcp协议是否检查设备返回的消息ID是否一致，默认检查，设置为False，也即是不检查ID一致。
15. MemobusTcpNet: 安川PLC的memobus协议的修复报文错误的bug，增加了线圈读写，寄存器读写，扩展寄存器的读写功能，例如扩展保持寄存器地址：x=9;100
16. Demo：测试界面添加了一个TCP转TCP的界面，可以用于两个网络连接中捕捉通信的数据报文。还有其他的一些细节优化。
17. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
18. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
