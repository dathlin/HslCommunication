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
			textBox1.Text = @"V10.4.1
1. Delta: 台达的DVP系列，当地址带站号时，并且出现了跨地址切割时，修复站号丢失的bug。跨地址指跨越M1536,D4096地址。
2. Delta: 台达AS系列的地址 SR 地址支持输入 SR0 以及 sr0
3. 针对FinsTcp协议及ADS协议的剩余字节解析，本来是int类型，现在加了最大长度10000的限制，防止异常攻击时导致申请内存过大而奔溃。
4. Inovance: 汇川相关的PLC的数据排列规则调整为 CDAB，DEMO上的选择也默认改为这个。
5. MelsecFxSerial: 移除三菱编程口协议最小接收回复报文2字节的限制，实际测试有时候只需要一个字节就可以了，否则会一直处于接收超时。
6. ByteTransform: TransBool的方法的偏移和长度均修改为以位为单位，具体调用API时查看注释说明，长度为10就表示10个长度的bool。
7. AllenBradleySLCNet,AllenBradleyPcccNet: 地址支持ST10:2这种字符串地址，并在AllenBradleyPcccNet上实现动态读取字符串，长度为0或没有，则自动长度。
8. AllenBradleySLCNet,AllenBradleyPcccNet: 以及SLC的协议地址支持了 L17:0 的地址，长整型类型
9. VigorSerial,VigorSerialOverTcp: 新增丰炜PLC的编程口协议及透传类，支持VS系列，地址支持动态站号信息，例如 s=2;D100
10. VigorServer: 新增丰炜的虚拟PLC，模拟了VS系列的通信，可以和对应的客户端进行数据读写测试，位地址支持 X,Y,M,S，字地址支持 D,R,SD
11. MelsecFxSerial: 三菱的编程口协议及其透传类添加一个激活PLC的API方法ActivePlc，在某些特殊的PLC读写数据之前，需要先调用一下。
12. Modbus:Modbus所有协议的ReadFromCoreServe(byte[])增加特别的注释，只需要传递modbus核心报文即可，不管tcp,还是rtu,还是ascii，都是一样的。
13. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
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
