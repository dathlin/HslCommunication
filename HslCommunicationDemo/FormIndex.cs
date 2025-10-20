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
			textBox1.Text = @"V12.5.2
1. OmronHostLinkCModeServer: 修复CMode协议的虚拟服务器，在客户端执行远程写入操作的时候，导致数据错位的bug。
2. OmronCipServer: 修复欧姆龙PLC的CIP虚拟服务器在客户端读取数组索引时，返回数据不正确的bug，优化字符串标签读写时候的数据包大小。
3. AllenBradleyNet: 在写入地址 i=A[10] 这类地址时，写入位到PLC里的整数方法现在支持SINT,INT,DINT,LINT类型，同时支持 i=A.10 这种地址格式。
4. Modbus: Modbus协议里，设置DataFormat为BADC，DCBA时，读取""100.0""的bool数组时，调整为小端模式，跟随DataFormat变化。
5. AllenBradleyHelper: ab-cip的协议支持二维数组的地址格式，同时支持了A[1,2]格式和 A[1][2] 格式，修复原本二维数组地址输入后面格式解析异常的bug。
6. PipeTcpNet: 优化TCP管道的异常消息号计数的功能，优化连接及重新连接的部分代码。
7. HttpServer: 修复HttpServer服务器启动后，手动关闭服务的时候，不停的反复触发异常日志记录的bug。
8. Demo: 倍福的ADS协议新增一个地址示例说明，如果是TWINCAT2的情况，全局变量地址前加一个点，例如 s=.A
9. Demo: HttpClient的webapi测试界面，当get请求时，参数在body里输入时，修复数组的参数解析不正确的bug。
10. Demo: 在所有设备测试读取界面，显示读取到的单个变量值时，在十进制和十六进制之外，支持显示二进制的数据内容。
11. Demo: 修复虚拟服务器在生成示例代码的时候，如果绑定了本地的ip地址，结果生成代码异常的bug。
12. Demo: 西门子的虚拟服务器手动添加DB块的时候，支持直接生成示例代码，方便显示复制。
13. Demo: 修复DEMO已经保存的测试界面，重新保存不一样的名字窗口时，两个菜单指向一致的小问题。
14. Demo: 已保存的窗体双击打开时，修复之前的bug，现在改为绑定配置的GUID码，无论树形控件怎么刷新都支持重新打开旧的。
15. Demo: 保存列表双击当前的树形图窗体时，优先显示已经打开的窗体界面，如果需要新的窗体，可以鼠标右键菜单操作。
16. Demo: 测试界面的""点位变量""和""数据模拟""支持导入导出CSV格式字符串到剪贴板，可以直接复制到Excel，数据模拟界面可以自己设置常用表达式。
17. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
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
