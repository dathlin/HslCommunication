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
			textBox1.Text = @"V11.2.2
1. SharpList: 修复Add一个新的值的时候，每隔指定长度次数时数据丢失一次的bug。新增LastValue( )方法获取最后一个值。
2. AllenBradleyNet: ReadBool(string address, short length); 支持读取以int类型为基础的bool数组，支持从中间任意位置开始读，返回任意长度。地址前加i=,例如i=AAA[10]
3. NetSoftUpdateServer: 修复路径在linux下运行时，路径分隔符识别不正确，导致文件下载失败的bug。
4. Modbus: modbus的地址支持自定义写入功能码，例如自定义的服务器有个数据区，读使用07功能码，写使用08功能码，那么地址可以表示为 x=7;w=8;100  依然支持站号指定。
5. CJT188Helper: 修复CJT188协议再读取水表数据的时候，数据位颠倒的bug。
6. Omron: 在欧姆龙Fins协议里，当读取位数据超过1998时会发生错误，现在根据1998长度自动切割，也就是支持任意长度了。
7. ReverseBytesTransform: 修复指定DataFormat对象实例化的时候，指定DataFormat无效的bug。
8. NetworkDoubleBase: 基础的网络设备通信基类支持了使用MQTT中转读取的方式，指定mqtt对象，读Topic，写Topic就可以远程读写PLC信息。可以配合我司的边缘网关系统的设备转MQTT使用。使用手册后面推出。
9. DLT645With1997: 修复DLT645-2007解析数据异常的bug，修复读取电压倍率不对的bug。
10. ModbusHelper: 修复汇川PLC读取bool时，当指定MX500.7能读bool值，但是MX501.7 这种地址时，获取不到正确的值的bug。
11. Authorization: 支持一种在线激活方式，使用指定ip，端口，令牌获取远程激活码来激活的操作，后续扩展临时激活授权测试的功能。
12. FanucSeries0i: 读取程序的API接口ReadProgram再接收完程序后，再接收一次0x18指令的报文。
13. OmronHostLinkHelper: 欧姆龙HostLink协议在解析报文的错误码时，当解析失败时，增加错误捕获，并提示原始报文。
14. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
15. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
