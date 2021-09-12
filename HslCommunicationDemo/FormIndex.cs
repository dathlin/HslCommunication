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
			textBox1.Text = @"V10.2.0
1. NetSoftUpdateServer: 代码优化，新增一个OnlineSessionss属性，用来获取当前正在更新的客户端的数量。
2. RSAHelper: 提供了从PEM格式的私钥和公钥创建RSA对象的辅助方法，还提供了RSA对象导出PEM格式的私钥公钥方法。支持加密解密超长数据
3. RSACryptoServiceProvider: 增加RSA对象的扩展方法GetPEMPrivateKey及GetPEMPublicKey方便快捷的获取PEM格式的公钥和私钥，扩展加密解密超长数据。
4. SerialBase: 串口基类新增虚方法CheckReceiveDataComplete用于检查报文是否接收完成，一旦接收完成，立即返回，增加通信性能。
5. ModbusRtu: 重写了CheckReceiveDataComplete方法，根据功能码的不同来判断当前的数据长度是否完整，以此判断报文是否完整。
6. ModbusAscii: 重写了CheckReceiveDataComplete方法，根据开头及结尾的固定字符来是否指定值，以此判断报文是否完整。
7. ModbusTcpServer: 优化服务器的串口接收功能，现在回复报文很快。1. 先接收串口数据，再Sleep。2. 增加数据完整性校验，一旦成功，立即返回报文。
8. ModbusTcpServer: 新增属性RequestDelayTime，设置非0时用来防止有客户端疯狂进行请求而导致服务器的CPU占用率上升问题。
9. MelsecA1EServer: 新增MC-A1E协议的虚拟服务器，支持了二进制和ASCII格式，已经配合客户端通过单元测试。
10. AesCryptography, DesCryptography: 新增AES及DES加密解密对象，使用密钥实例化即可加密解密操作。
11. MQTTServer: 在原有的基础上增加了加密的功能，如果MQTTClient，MQTTSyncClient启用加密功能，那么数据的传输就是加密的，无法抓包破解账户名密码及交互数据。
12. AllenBradleyNet: cip协议支持了日期，日期时间的读写操作，这样omron的plc的cip协议也支持了日期时间的读写，在omroncip的demo上添加测试操作。
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
