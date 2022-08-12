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
			textBox1.Text = @"V11.0.5
1. ModbusAsciiOverTcp: 新增modbusascii协议的串口转网口透传的通信类。
2. DeltaSerialAsciiOverTcp: 新增一个台达的ASCII通信协议的串口转网口透传通信类，和其他的基于modbus的台达类一致的用法，一致的地址格式。
3. FujiCommandSettingType: 修复FujiCommandSettingType及其虚拟服务器再解析地址不正确的bug，导致大量的其他地址解析失败，并完善了注释说明。
4. MelsecFxSerial: 新增属性AutoChangeBaudRate，默认false，当设置为true时，在串口打开时会和PLC交互改变PLC默认的波特率。
5. SerialBase: 新增串口类基类属性ReceiveEmptyDataCount，用来表示接收空白数据次数，然后判断接收完成的标记，单次耗费的时间是 SleepTime。
6. Modbus: DEMO相关的界面都默认的DataFormat都调整为 CDAB，因为大多数的设备数据大小端都是这个格式。
7. OmronConnectedCipNet: 新增IReadWriteCip接口，欧姆龙的基于连接的CIP协议实现了日期及时间的读写接口。
8. MqttServer: MQTT服务器支持向自定义规则的客户端会话发布指定的主题数据，详细查看PublishTopicPayload重载方法
9. MqttSyncClient: 上传文件到服务器的功能接口里新增流数据的上传，需要指定服务器保存的文件的名称。
10. NetworkConnectedCip: 基于连接的CIP协议的连接id信息初始化时及赋予一个随机数，增加一个新的错误描述信息，连接过多的错误。
11. Upgrade.exe: 用于更新的exe修复当文件长度为0时，导致百分比计算异常的bug。
12. OmronFinsAddress: 欧姆龙FINS协议的地址，增加支持了定时器TIM,计数器CNT，索引寄存器IR，数据寄存器DR的读写。
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
