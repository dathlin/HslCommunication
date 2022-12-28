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
			textBox1.Text = @"V11.3.1
1. Dll: 用于激活的类Authorization新增一个方法SetDllContact，用于设置提醒激活的联系方式，可以设置自定义的联系方式。
2. Demo: 修复安川的MemobusUdpNet的测试界面的点击实例化按钮后，界面还是灰的bug。
3. AllenBradleyNet: 修复ab-plc的CIP协议，当触发0x64错误码的时候，一直重复读写无法恢复成功的bug，现在会自动重连操作。
4. SiemensS7Net: 新增对DTL格式的时间数据读写的API接口，使用ReadDTLDataTime和WriteDTLTime来读写操作。
5. LogStatisticsBase: 修复当系统的时间往回调的时候引发异常的bug，原因来自索引偏移位置会变成负数。
6. websocketServer: Websocket服务器header接收订阅时，支持url转义，以及修复开启通配符模式情况下，消息驻留发送失败的bug。
7. Demo: 串口调试界面以及网口调试界面，返回的数据支持勾选自动返回，只要在发送框里提前输入数据。
8. Dlt645: DLT645的地址支持reverse标记，用来支持在某些不标准的协议的设备，数据顺序没有颠倒的情况，例如：reverse=false;02-01-01-00
9. Inovance: 汇川的AM系列的地址，支持MD的地址格式解析，同时适用于读写操作，MD100=MW200
10. SiemensS7Helper: 修复了西门子虚拟PLC及SiemensS7Net的写入字符串的同步方法，字符创长度信息和实际不匹配的bug。
11. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
12. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
