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
			textBox1.Text = @"V10.4.3
1. SerialBase: SetPipSerial重，命名为SetPipeSerial，如果有使用串口管道，则需要更改相关的名称。
2. MelsecMcDataType: 修复三菱累计定时器当前的值的地址进制转换应该为10进制，结果写成100导致转换失败的bug。
3. Keyence: 上位链路协议的串口及网口的通信类，ByteTransform的IsStringReverseByteWord调整为true，读写字符串时将两两颠倒。
4. IByteTransform: 转换接口类的注释进行完善，提示更加详细完整，中英文并行提示。
5. Vigor: 丰炜PLC的读取位和读取字的功能方法，对读取长度进行内置切割，相当于支持了无限长度的数据读取。
6. EstunTcpNet: 新增埃斯顿机器人通信类，内置定时器保持心跳，支持读取机器人的基本信息，详细见DEMO界面。
7. FanucInterfaceNet: 修复fanuc机器人的中文编码异常的bug，使用标准的GB编码解析，如果编码获取异常，需要自行nuget安装System.Text.Encoding.CodePages组件，并注册编码。
8. Device: 设备类增加ReadStruct{T}方法，根据特性从原始字节里解析出实际的数据对象。影响范围所有的设备类对象。
9. Demo: Demo程序支持了手动设置版本更新忽略提醒，忽略之后再菜单栏进行提示新版，以及增加添加激活操作功能，本地保存加密的激活码。
10. 官网地址： http://www.hslcommunication.cn 官网的界面全新设计过，感谢浏览关注。
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
