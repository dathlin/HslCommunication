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
			textBox1.Text = @"V9.6.6
1. SoftCRC16: 计算CRC16的辅助方法，开放预置值的设定，可以自由的指定。
2. FanucSeries0i: 新增一个读取机床系统语言的api，读取之后将会自动切换语言，暂不支持根据消息自动匹配编码解析。
3. SiemensS7Net: OperateResult<byte[]> Read( string[] address, ushort[] length )接口添加RPC支持
4. NetworkDataServerBase: OnDataReceived事件签名修改为DataReceivedDelegate( object sender, object source, byte[] data )，追加一个source参数，可用来获取客户端IP地址，具体看api文档
5. NetworkDoubleBase: 增加LocalBinding属性，如果需要绑定本地ip或是端口的，可以设置，所有的网络类PLC都支持绑定本地的ip端口操作了。
6. NetworkUdpBase: 增加LocalBinding属性，如果需要绑定本地ip或是端口的，可以设置，所有的网络类PLC都支持绑定本地的ip端口操作了。
7. SiemensS7Net: 完善异步的PDU自动长度信息，新增AI,AQ地址的读写，地址格式：AI0,AQ0，欢迎大家测试。
8. OmronFinsNet: 欧姆龙FINSTCP协议的SA1机制调整为自动获取，不需要在手动设置，修复错误信息文本和错误码不匹配的bug。
9. MqttClient: 修复在网络异常导致正在重连服务器的时候，调用ConnectClose方法后，后台仍然不停的重连服务器的BUG。
10. NetworkDeviceSoloBase: 删除这个文件，并优化相关的串口透传类。全部改为继承自：NetworkDeviceBase
11. NetworkDataServerBase: 所有派生类的虚拟服务器，包括modbus，s7, mc, fins等服务器全部支持设置是否允许远程写入操作，modbus的demo界面添加是否允许的选项。
12. WebSocketClient: 修复客户量的Request报文少一个换行信号在某些服务器会连接失败的bug，新增两个发送数据的api，发送数据更加的灵活。
13. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
14. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
