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
			textBox1.Text = @"V11.5.2
1. OmronCipNet: 修复写入单个Byte数据对象，或是奇数长度的byte[]时，plc报错31错误码的异常，现在可以正常的写入了。
2. SiemensS7Net: 西门子批量读取地址数组的方法里，原先总长度按照200字节切割变更为按照自动获取的pdu长度进行切割。
3. MqttClient: Mqtt客户端的连接类MqttConnectionOptions新增属性UseSSL指示是否开始SSL/TLS加密功能，验证证书时修复服务器名称输入错误导致有些服务器连接失败的bug。
4. NetworkUdpBase: 优化UDP通信基类，增加设置获取PipeSocket方法, 支持设置多个端口，因网络读取失败时自动切换另一个端口。
5. Modbus: ModbusRtu设备在提取接收到的报文时，校验数据长度并且如果发现长度太长，则按照标准报文长度切割，即使后面跟0xFF扰码也能正确读取
6. Memobus, DigitronCPL, MegMeet, Delta 相关的通信类，补全缺失的 MPRC 接口注册功能。
7. Demo: 三菱相关的PLC测试界面在连接PLC失败的时候，原先只提示连接失败，现在提示更加详细的信息。
8. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
9. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
