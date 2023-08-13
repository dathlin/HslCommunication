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
			textBox1.Text = @"V11.6.2
1. YRCHighEthernet: 新增ReadManagementTimeSpan接口，用来读取持续的时间，返回的是字符串信息。完善demo界面，提供示例代码信息。
2. NetworkDoubleBase: 新增一个发送前的报文头设置属性 SendBeforeHex，当使用lora中转通信时，可以设置为lora站号，例如00 00 00 02
3. ModbusUdpServer: 新增基于UDP通信的ModbusUdpServer虚拟服务器类，在demo界面上的ModbusTcpServer启动时，可选TCP还是UDP功能，方便测试。
4. MelsecFxLinksOverTcp: 修复属性 WaittingTime 可以设置0xF 以上值的bug，实际这个值不允许设置 0x0f 以上。
5. XinJEServer: 当服务器站号不一致的时候，并且服务器设置检查站号的情况，直接返回站号不一致的错误消息。
6. KeyenceNanoServer: 基恩士的上位链路虚拟PLC的字符串是否反转默认设置 true, 如果需要，手动修改server.ByteTransform.IsStringReverseByteWord
7. FanucSeries0i: 新增方法 ReadAxisNames 读取轴名称以及 ReadSpindleNames读取主轴名称。
8. IEC104: 添加总召唤方法TotalSubscriptions，优化值解析的过程，Demo界面进行了优化，显示报文的时候，显示其对应的功能说明，api文档新增示例。
9. AllenBradleyNet: 修复当PLC对象修改了ByteTransform.DataFormat的值后，导致读取PLC时提示会话ID不一致的bug。
10. DEMO: 在TCP Server调试的界面上，增加保存当前界面的配置参数的功能，连带配置的报文列表也一并存储。
11. DEMO: 修复DebugControl控件在窗体拖动时，重复触发发送数据按钮的bug，多来回拖动后将会导致程序异常卡顿。
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
