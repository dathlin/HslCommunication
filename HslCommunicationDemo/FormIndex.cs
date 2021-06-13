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
			textBox1.Text = @"V10.0.1
1. FatekProgram: 串口类和串口转网口透传类优化，统一一套代码来读写设备。
2. IDisposable: NetworkAlienClient, NetworkAlienClient, LogNetBase, MqttClient, MqttServer, WebSocketClient, WebSocketServer实现释放接口。
3. SiemensS7net: 新增DestTSAP属性，优化了LocalTSAP和DestTSAP属性对不同系列plc的值设置，当plc为s200系列时，支持设置自定义的值来访问plc。
4. UltimateFileServer: 文件服务器删除目录所有文件调整为直接删除整个目录，新增支持删除指定目录下所有空的子目录的功能。文件客户端新增匹配操作的方法。
5. PanasonicMcNet: 地址新增支持SD数据类型，示例SD0，返回的错误代码修改为松下的专用信息，和三菱的不一致。
6. IModbus: Modbus接口新增TranlateToModbusAddress( string, byte) 接口，只要继承重写该方法，即可轻松实现自定义地址解析转modbus地址。
7. Delta: 台达相关的类根据modbus最新的优化，全部进行优化，每个类只有一点点代码了。
8. FujiSPB: 富士的串口协议代码和串口透传代码优化，修复串口类调用异步写bool失败的bug。
9. XinJE: XinJEXCSerial重命名为 XinJESerial类，根据modbus的优化进行精简，支持了信捷系列选择，可选XC,XJ,XD，地址支持根据所选型号自动解析。
10. XinJE: 新增基于串口透传的XinJESerialOverTcp类，以及modbustcp协议的XinJETcpNet类，DEMO上支持测试。
11. Inovance: 汇川的类优化，删除原来的AM,H3U,H5U类，改用InovanceSeries枚举来区分系列，然后解析不同的地址。同时添加InovanceSerialOverTcp串口转网口类。
12. OmronFinsServer: 欧姆龙的FinsTCP虚拟服务器端支持E数据块，E0.0-E31.0 都是指同一个数据块。
13. IByteTransform: 新增二维数组的解析方法接口，主要是short,ushort,int,uint,long,ulong,float,double类型。
14. Demo: MelsecSerialOverTcp的demo界面添加是否新版的选择。
15. 如果有用到汇川，信捷的类库，请注意升级时出现不兼容，需要修改下类型，指定PLC的系列，感谢支持。
16. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
17. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
