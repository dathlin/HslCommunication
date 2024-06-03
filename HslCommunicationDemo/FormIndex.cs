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
			textBox1.Text = @"V12.0.2
1. OmronFinsServer: 客户端握手报文返回时的命令码修改为1，因为在某些情况下第三方客户端会连接失败.
2. CommunicationServer: 新增管道上线事件OnClientOnline，管道下线的事件OnClientOffline
3. PipeSerialPort: 修复串口管道当设备方一直不间断发送数据的情况下导致始终不引发超时的bug，影响范围包括所有的串口类设备。
4. Lsis: lsis的代码优化，支持了DB100这种字节地址，支持直接读short，int多字节数据，修复地址转换异常的bug。
5. PanasonicMewtocol: 修复日志记录的时候不按照ASCII格式记录的bug。
6. Demo: 服务器端新增数据模拟的界面，可以使用表达式来动态执行脚本，方便生成一个特殊变化的曲线。
7. Modbus: 修复Modbus协议在DataFormat为 BADC 及 DCBA 的情况下，写入short及ushort字节不发生转换的bug，影响范围为所有modbus。
8. FanucSeries0i: 初步添加读取诊断信息方法ReadDiagnoss( int number, int length, int axis )，demo上可以直接测试，欢迎反馈信息。
9. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
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
