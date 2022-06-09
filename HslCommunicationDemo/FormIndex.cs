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
			textBox1.Text = @"V11.0.1
1. HslExtension: 新增了一些扩展方法，现在可以直接从short，int类型获取位及设置位的功能，例如 bool value = shortValue.GetBoolByIndex(10); 设置位也是同理。
2. DLT645: Demo界面优化，无论是串口的，还是网口的，都支持了密码及操作者ID的输入。修复了站号输入后，但是站号初始化不成功的bug。
3. LogStatisticsBase: 当传入的长度为-1时，表示不限制长度信息，会一直的新增。
4. Upgrade.exe: 用于自动升级更新的项目重新优化，支持了下载时候的网速显示，支持了下载百分比显示，删除了自动创建快捷方式的代码。
5. SerialBase: 初始化串口的方法SerialPortInni( string portName )支持格式化的输入，例如COM3-9600-8-N-1，COM5-19200-7-E-2。
6. MelsecFxSerialOverTcp: 当启动GOT透传时，修复报文封装不正确导致写入失败，读写值不正常的bug。
7. InovanceHelper): 汇川的PLC针对M地址的寄存器，支持使用 MX0.0 来对位进行读取操作。支持了MB100读取byte类型的数据。
8. Demo: 在Demo所有的设备通信测试界面，几乎所有的设备都支持了显示报文信息，想要查看通信的报文协议，菜单里点击 报文日志 。
9. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
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
