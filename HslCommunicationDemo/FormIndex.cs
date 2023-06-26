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
			textBox1.Text = @"V11.6.0
1. DLT645: DLT645-2007 新增对设备返回的报文进行和校验码校验的步骤，如果校验失败，返回错误信息。
2. MelsecA1EAsciiNet: 修复在字读取长度超过64字时，或是bool读取超过256位时，读取结果不正确的bug。现在支持读取任意的长度数据。
3. AllenBradleyServe: 修复AllenBradleyServer及OmronCipServer在配置了写入时创建新标签后，写入字符串数据仍然报错，提示标签不存在的bug。
4. IDlt645: DLT645接口新增Password属性及OpCode，方便在通信时动态修改这两个参数，主要针对DLT645/2007的,对于 DLT645/1997 协议来说无效
5. MelsecMcServer: 修复MC虚拟服务器在ASCII模式下，写入D之外的寄存器，但是仍然写入D寄存器的bug，影响范围包括A3CServer。
6. Melsec: 三菱的MC协议开放属性 PlcNumner，可以自由的设置，表示PLC编号。影响范围:MelsecMcNet, MelsecMcAsciiNet, MelsecMcUdp, MelsecMcAsciiUdp
7. OmronFinsServer: 欧姆龙的FinTcp协议的虚拟PLC支持了CF数据地址，无论是服务器上，还是通过客户端来读写CF数据都可以正确的读取。
8. FanucSeries0i: 客户端demo修复删除程序，只能删除主目录的程序号的bug，现在可以删除任意指定路径的程序文件信息。
9. WebsocketServer: websocket服务器运行时，当客户端使用火狐浏览器连接服务器时，修复检测websocket连接失败的bug。
10. ToyoPuc: 修复丰田工机PLC中，当地址是 U0 及 H0 的时候，地址输入解析不正确的bug，原先的bug是忽略第一个数字。
11. AllenBradleyServer: CIP虚拟服务器优化通信的细节，正确的设置了基于连接模式下的各种连接ID信息，当PLC使用MSG模块读写虚拟PLC时也顺利通过。
12. Demo: HslCommunicationDemo程序几乎所有的设备测试界面的线程压力测试界面单独拎出来，显示单次通信的平均耗时。
13. Demo: HslCommunicationDemo程序几乎所有的设备测试界面增加设备的地址示例说明，带地址示例，含义，部分PLC提供地址范围说明。
14. Demo: HslCommunicationDemo程序几乎所有的设备测试界面增加数据点位表的功能，可以配置点位表，保存，加载，然后多个点位同时刷新。
15. .net standard 框架的dll依赖的 System.IO.Ports 版本由 6.0.0 升级到 7.0.0。
16. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
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
