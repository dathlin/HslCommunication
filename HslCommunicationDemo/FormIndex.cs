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
			textBox1.Text = @"V10.0.0
1. V10版本：本来上个版本就应该定为V10版本，因为已经内核优化，出现不兼容更新，所以这个版本果断设定为V10版本。
2. SerialBase: 修复在串口异常的情况下，会抛出异常的bug，是上个版本的问题，现在会返回失败的OperateResult对象。
3. ShineInLightSourceController: 新增昱行智造科技（深圳）有限公司的光源控制器的通信对象，主要用于视觉的打光操作。
4. MqttSession：Mqtt的会话信息增加一个object Tag属性，用来自己绑定一些自定义的数据。
5. SerialBase: 串口初始化的方法修改为虚方法，允许在继承类里进行重写，修改一些默认参数信息。
6. NetworkBase: 修复ReceiveAsync异步方法在length=-1时，对方关闭时返回仍然为成功的bug，只有在极少数情况下会触发。
7. ModbusTcpServer: 新增一个属性UseModbusRtuOverTcp，只要设置为True，就可以创建ModbusRtuOverTcp的对应的服务器，使用TCP传送RTU报文。
8. HttpServer: 新增SetLoginAccessControl( MqttCredential[] credentials )方法，用于增加默认的账户控制，如果传入null，则不启动账户控制。
9. IReadWriteDevice: 新增设备读写接口，继承自IReadWriteNet，然后所有设备实现IReadWriteDevice接口，相关继承关系优化，接口增加ReadFromCoreServer。
10. All: 统一所有的设备核心层打包报文方法名为:PackCommandWithHeader 解包的方法名为UnpackResponseContent，允许重写实现自定义操作。
11. Omron: 对OmronFinsTcp和OmronFinsUdp的通信层大幅度优化，统一代码规则，新增run，stop，读取cpu数据，cpu状态的高级方法。
12. DTSU6606Serial: 新增德力西电表的采集类，基于modbusrtu实现，ReadElectricalParameters方法可以直接获取电表相关参数。
13. HslExtension: 有两个获取byte的位的方法，功能重复，删除GetBoolOnIndex方法，使用GetBoolByIndex方法。
14. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
