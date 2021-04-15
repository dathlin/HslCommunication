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
			textBox1.Text = @"V9.7.0
1. OmronFinsNet, OmronFinsUdp, HostLink: 地址的解析优化，在读取的API方法里，自动按照500长度进行切割，可以由 ReadSplits 更改。
2. FanucSeriesOi: fanuc数控机床支持R数据的读取，参考API： ReadRData(int start, int end)
3. HslExtension: 新增从字节数组获取位值的扩展方法: GetBoolValue( this byte[] bytes, int bytIndex, int boolIndex )
4. FatekProgram: 地址解析优化，修复 RT,RC地址解析不正确的bug，读取的字及位长度自动切割，调用不受长度限制。
5. SoftBasic: 添加设置byte数据的某个位的方法SetBoolOnByteIndex，也可以调用byte的扩展方法，byte.SetBoolByIndex(2, true) 就是设置第二位为true
6. FujiSPHNet: 新增支持富士的SPH以太网协议，支持M1.0, M3.0, M10.0, I0, Q0地址的读写操作，支持位的读写操作。写位需要谨慎，先读字，修改位，再写入。
7. net20, net35, net451三个框架版本的项目引用 http.web 组件，用来修复 HttpServer 里url携带中文时，会导致解析乱码的情况，现在支持了中文的api接口注册，中文参数。
8. HttpServer: 使用了注册RPC接口时，返回调用方的数据内容格式调整为json格式，方便postman等测试工具识别内容。
9. FujiSPHServer: 新增富士SPH协议的虚拟服务器，支持和FujiSPHNet进行测试通信。支持的地址是一致的。
10. KeyenceNanoSerial: 基恩士的上位链路协议优化，支持了B，VB的bool读写，W，VM的字读写，新增bool数组写入功能。
11. KeyenceNanoSerial: 支持了plc型号读取，状态读取，注释读取，扩展缓存器的读写，错误代码提示携带更详细文本，适用于 KeyenceNanoSerialOverTcp
12. KeyenceNanoServer: 新增基恩士上位链路协议的虚拟服务器，可以和 KeyenceNanoSerialOverTcp 进行通信测试。
13. KeyenceSR2000: 基恩士扫描的协议的错误提示信息新增了英文模式下的注释，原来的只有中文的提示。
14. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
