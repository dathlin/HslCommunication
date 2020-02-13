using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormCharge : HslFormContent
	{
		public FormCharge( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel1.Text );
		}

		private void FormCharge_Load( object sender, EventArgs e )
		{
			textBox1.Text = @"V9.0.0
1. 宣布V9版本脱胎换骨，浴火重生，C#版本的组件库底层网络大幅重构，删除一直以来的伪异步，原先的通过改为纯同步，并从底层提供完整的异步方法。
2. 注意：不兼容升级，影响范围，MQTT协议的事件，网络的同步设置，西门子的PPI协议取消WriteByte方法，改为和其他一样的Write(string address,byte value)重载了，升级请谨慎测试。
3. 所有的PLC通讯类，机器人类通讯类，Modbus通讯类，身份证类，包括 IReadWriteNet 接口都实现了异步的操作，针对NET45以上及Standard平台。
4. MQTT协议修改触发的消息事件，返回session信息，支持自定义返回数据信息，支持当前消息的发布拦截操作，服务器主送发布的消息支持是否驻留，默认主题驻留。
5. 新增websocket协议的服务器，客户端，问答客户端。支持直接从C#的后台发送数据到网页前端，支持订阅操作。详细见demo的操作。
6. ComplexNet,SimplifyNet,PushNet,FileNet这几个网络引擎代码优化，初步测试OK。
7. SoftBasic: 新增方法SpliceStringArray，用来合并字符串信息。增加了ByteToHexString的空校验。
8. HttpServer: 异步优化，修复读取数据时可能长度不足的bug。
9. YRC1000: 安川机器人修改无法读取的bug，目前已经测试通过，感谢网友的支持。
10. Java: 修复ab-plc读取失败的错误信息，原因来自一个强制转换失败的错误。
11. 本版本改动较多，尽管我已经仔细测试过，但是仍然不可避免存在一些bug，欢迎大家使用，测试，有问题可以报告给我，相信hsl组件会变的更加强大。
12. 本版本依然是商业授权的，如果需要测试，可以付费240rmb，加入vip群，可以将hsl用于测试环境和研究学术用途，欢迎大家加我的支付宝好友，hsl200909@163.com
13. 加油，武汉！加油，中国！疫情之后，无人自动化工厂将会获得更大的关注和发展，我辈当自强。";
		}


		private void ShowActiveCode( )
		{
			textBox1.Text = @"
		/// <summary>
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
			FormCharge_Load( sender, e );
		}
	}
}
