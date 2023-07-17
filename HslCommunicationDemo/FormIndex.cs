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
			textBox1.Text = @"V11.6.1
1. Demo: 保存设备的连接参数及点位数据的时候，支持了设置密码，设置密码后，加载该设备参数时，必须输入正确的密码才能打开。
2. Demo: 串口调试界面，TCP调试界面，TCP Server调试界面大幅度的调整，优化，更好的区分收发数据，以及数据长度信息。
3. Demo: 在demo界面的曲线控件界面，从实时曲线修改为历史曲线控件，新增设置颜色，曲线样式，显示最大值，最小值信息，自动滚动条往右。
4. Demo: 调试的程序在连接成功，或是打开串口之后，直接在测试界面上显示当前的连接类的示例代码，初始化参数和demo界面保持一致，方便直接复制。
5. ModbusTcpServer: modbus虚拟plc当属性UseModbusRtuOverTcp = true时，同时支持rtu over tcp报文及 ascii over tcp报文，并对 ascii 报文做了更加严格的区分，防止弄乱。
6. ModbusRtuOverTcp: 通过调整底层基类的读取空消息的报文时，可能引发数据不完整的bug，针对部分回数据断断续续的设备，现在可以读取正确的值信息。
7. AllenBradleyNet: 优化CIP协议的读写字符串功能，对长度判断更加的完善，当写入字符串时，可以指定额外的type值，例如地址为""type=0xD1;AA""，影响范围：AllenBradleyMicroCip
8. HslTimeOut: 优化超时的代码信息，单独添加超时的日志信息，如需记录，可以实例化 HslTimeOut.TimeoutLogNet 属性，并且可以获取到当前所有的超时判断次数 HslTimeOut.TimeoutDealCount
9. SecsHsms: 优化secs的代码，增加在解析secs消息的时候，对异常错误的消息捕获并记录日志，demo界面优化显示信息，并提供代码示例。
10. AllenBradleyNet: 写入字符串的时候，如果类型为 DA 的情况，则使用另外的写入方式，在microcip上测试成功。
11. PanasonicHelper: 修复松下的mewtocol协议使用字的方式写入数据到Y,R,L地址时，引发0x41错误码的bug，原因来自结尾地址偏移异常。
12. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
13. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
