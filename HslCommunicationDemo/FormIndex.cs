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
			textBox1.Text = @"V12.7.0
1. SiemensS7Server: 修复子类SiemensPPIServer在客户端写入长度大于1的bool数组的时候，实际数据写入不正确的bug。
2. ModbusTcpServer: 修复启用地址映射的时候，针对bool读写时，还是提示地址解析失败的bug。
3. AllenBradleyServer: CIP虚拟服务器修复远程客户端写入字符串为空的时候，实际数据不清空的bug。
4. AllenBradleyServer: 修复标签是中文且数组的情况下，远程客户端读写时地址解析异常的bug，修复二维及以上数组解析异常的bug。
5. AllenBradleyServer: AB-PLC的虚拟服务器支持了读写特性的功能码，目前无论读写哪个实例，特性，都是同一个数据块，方便测试。
6. PortMappingServer: 新增加端口映射，反向代理的服务器类，支持随机端口范围设置，支持用户自定义端口号，官网提供免费测试。
7. OpenProtocolNet: Open协议属性ExtraSubscribeMID类型调整，现在支持自定义返回MID信息，支持覆盖已经支持的订阅数据的返回MID，如有使用该属性，升级不兼容。
8. InovanceEasyNet: 新增汇川Easy521系列的专属协议，支持读取X,Y,M,B,S,D,R,W, UW2100010数据地址，Demo添加相关的界面及地址示例。
9. FanucSeries0i: 修复读取进给倍率ReadFeedRate方法在某些特殊型号读取值不正确的bug。
10. Demo: 设备的列表界面，下面新增一个图标，可以控制协议分类的顺序，在默认，A-Z, Z-A三种方式顺序切换，自动保存，支持重启。
11. Demo: 修复设备监视界面得点位变量表界面，当输入脚本时，该脚本存在异常时，直接程序崩溃的bug，现在显示错误信息。
12. Demo: Demo界面的modbus协议，仪器仪表，openprotocol，secs等协议的界面也支持查看支持列表功能，等待大家去完善。
13. Demo: 优化上传型号到服务器的界面，中英文优化，增加提示信息，上传人名称及联系方式自动记忆上次输入。
14. Demo: 修复Demo程序写入字符串到设备时，无论是PLC,Modbus还是虚拟PLC时，生成的示例代码里，地址信息不正确的bug。
15. Demo: Demo程序的服务器，当用户使用Demo上传设备支持型号信息时，将自动存入缓存，等待管理员审批，审批通过后写入文件。
16. Demo: Redis浏览的界面优化，调整为使用+号来展开，修复右键菜单操作时数据块编号不正确的bug。
17. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
18. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
		DemoUtils.ShowMessage( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		DemoUtils.ShowMessage( " + "\"Active Failed! it can only use 24 hours\"" + @" );
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

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel2.Text );
		}
	}
}
