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
			textBox1.Text = @"V9.6.3
1. SickIcrTcpServer: 修复手动连接扫码设备的网络在关闭服务器后仍然会自动重连的bug。
2. SoftBasic: 删除SpliceTwoByteArray及SpliceByteArray方法，改为泛型支持的SpliceArray方法，支持任意类型拼接，添加了扩展方法支持。
3. Modbus: 支持 0x16 功能码，用于掩码操作，支持对寄存器地址的位操作，需要设备方支持，该功能仅支持商业授权使用。
4. Modbus: 读取线圈和输入线圈的长度支持任意，内部按照2000长度自动切割，读取寄存器和输入寄存器按照120自动切割，该功能商业授权特权，普通的VIP用户存在长度限制。
5. MqttSyncClient: 新增ReadRpc<T>(string topic, string payload )方法，专门用来读取注册的RPC接口的，自动json转换类型。
6. MqttSyncClientPool: 连接池优化，注释优化，添加了一些缺失的方法。该功能商业授权特权。
7. RedisClientPool: 连接池优化，注释优化。该功能商业授权特权。
8. LogNet: 日志部分新增一个 ConsoleOutput 属性，如果设置为 true，那么日志就会在控制台进行输出，等级不一样的日志，文字颜色不一样。
9. LogNet: 日志部分的记录优化调整，取消了一些底层的重复记录的日志内容，针对 MQTT, Websocket, HTTP 及虚拟PLC相关的日志记录根据信息进行优化。
10. 祝大家新年生意滚滚，身体健康，牛年大吉。
11. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
12. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
