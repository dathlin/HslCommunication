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
			textBox1.Text = @"V12.5.1
1. KeyenceKvOld: 修复当设备网络问题掉线的时候，读取结果仍然还是成功的bug，原因来自失败的时候返回了错误的对象。
2. SiemensS7Server: 新增DB块数据区时支持指定长度，优化客户端和服务器读写超过地址范围时提示错误，DEMO界面支持存储加载增加的DB块信息，显示优化。
3. AllenBradleyNet: 新增方法OperateResult<AbTagValue[]> ReadTags( string[] address, ushort[] length )每个标签返回一个AbTagValue对象，包含类型及二进制数据。
4. AllenBradleyServer: AB的虚拟服务器新增加对客户端同时读取多个数据的支持，一条报文实现读取返回结果操作，客户端测试通过。
5. Server: SiemensS7Server, OmronFinsServer, GeSRTPServer, AllenBradleyServer, AllenBradleyPcccServer这种有握手包的虚拟服务器新增对串口通信的支持。
6. ModbusRtu: 优化ModbusRtu数据包的报文接收完整性的判断，修复极少部分情况下接收部分报文却判断为报文完整的bug。
7. Demo: PLC测试界面的数据模拟子界面，支持右键菜单操作，删除行，导出，导入数据，然后优化脚本的提示及复制功能，部分中英文界面优化。
8. Demo: 修复PLC测试界面不关闭连接，直接打叉关闭的情况下，远程调试功能处于打开状态时，端口号不释放的bug。
9. Demo: Demo界面的HttpClient测试界面，当使用了GET测试功能，参数写到body里时，测试请求的时候会自动解析参数赋值到url中，示例url显示实际带参数的url(调整为可复制)。
10. Demo: 修复Demo程序菜单栏的激活界面刚打开就直接关闭，几秒后直接提示闪退的bug。
11. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
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
		DemoUtils.ShowMessage( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		DemoUtils.ShowMessage( " + "\"Active Failed! it can only use 24 hours\"" + @" );
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
