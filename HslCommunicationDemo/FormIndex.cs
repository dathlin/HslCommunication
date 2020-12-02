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
			textBox1.Text = @"V9.5.3
1. ModbusRtuOverTcp: 更改继承，直接从NetworkDeviceBase进行继承，通过单元测试
2. YokogawaLinkTcp: 新增横河PLC的二进制通讯类，支持X,Y,I,E,M,T,C,L,D,B,F,R,V,Z,W,TN,CN读写，部分高级API商业授权用户才能使用，例如读取PLC信息。
3. YokogawaLinkServer: 新增横河PLC的二进制格式的虚拟PLC，模拟的真实的PLC的通信机制，实现了读写长度的限制，以及错误信号的返回。
4. Networkdoublebase: ReadFromCoreServer( byte[] send, bool hasResponseData ) 新增是否等待数据返回的属性，可以用于某些不需要数据返回的命令。
5. Networkbase： 修复异步接收数据时，某些情况下长度为0导致连接关闭的bug。
6. FetchWriteServer: 新增西门子fetch/Write协议的虚拟PLC，支持虚拟数据的读写，通信。
7. MelsecFxSerialOverTcp: 修改继承体系，从NetworkDeviceBase继承，和MelsecFxSerial的IsStringReverseByteWord调整为true;
8. 文件引擎服务器修复路径大小写导致的bug问题，文件客户端支持检查文件是否存在的方法，检查文件是否存在。
9. MqttServer: 远程调用的MRPC的参数支持自定义类型，通过JSON转换，将字符串转换为实体类。还有其他的优化。
10. DeltaDvpSerial, DeltaDvpSerialAscii, DeltaDvpTcpNet: 添加台达的通信类，输入台达的地址即可，会自动转换实际的modbus地址。
11. 所有的虚拟PLC的服务器均调整为商业授权用户专享，还有一些高级的API，具体看api注释是否带有[商业授权]字样，基本的数据读写功能将一直对个人用户开放。
12. Demo: 数据读写示例的界面，写入现在支持批量写入，数据写[1,2,3]，然后写入short，就是写入short数组了。
13. 普通VIP的个人使用不再限制100个PLC对象，连续运行时间调整为10年，高级的一些API限制商用，参考注释是否带[商业授权]字样。
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
