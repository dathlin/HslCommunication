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
			textBox1.Text = @"V11.0.3
1. MelsecFxSerialOverTcp: 修复在启用GOT透传时，碰到特殊的报文解析异常，最终导致偶尔读写失败的bug。
2. InovanceHelper: 修复汇川PLC的AM系列时，读写M区域位地址的数据偏移不正确的bug，例如MX100.0，实际地址应该是MW50的第0位。
3. ModbusTcpServer: 新增属性StationDataIsolation，默认为false，表示server只有一个数据区，所有站号用的一个数据区。如果设置为 true，表示server给每个站号开辟一个数据区。
4. ModbusTcpServer: 修改Station站号类型为byte，删除属性StationCheck，现在不需要检查站号了。服务器侧读写数据支持了输入站号信息，例如 s=2;100，可以访问不同站号的数据。
5. FujiSPBServer: 修复富士SPB虚拟服务器再读写位数据的时候，修复地址偏移解析异常导致bug。
6. AllenBradleyServer: CIP协议的虚拟服务器修复当客户端写入bool变量时，无论写入True还是False，服务器都写入True的bug。
7. MelsecFxSerialOverTcp: 三菱的编程口协议里，读取的地址长度突破了254字节的长度限制，现在可以读取无限个bool值，或是其他类型的值。
8. HslReflectionHelper: 在MRPC及webapi接口的参数数据提取过程中，支持传入JSON对象及JSON对象的字符串，都会自动解析成正确的对象值或是JObject值。
9. MelsecA1ENet: 三菱的A1E协议，读取字及位数据时，支持了读取超过64地址长度的数据，内部自动切割重组。
10. DLT698: 初步添加DLT698.45的协议实现，使用明文的通信方式。支持读取功率，总功，电压，电流，频率，功率因数等数据。
11. XGBCnet: Lsis的XGBCnet协议修复部分的bool读写位置和真实PLC对应不上的bug，bool的读取支持了MW100.2 带小数点表示的方式。
12. XGBCnet: 支持了批量的bool数组读取功能（内部自动读取字节，解析出bool数组，不支持写入bool数组）。修复XGBFastEnet在配置XGB型号时读写数据异常的bug。
13. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注，新官网：http://www.hsltechnology.cn/。
14. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
