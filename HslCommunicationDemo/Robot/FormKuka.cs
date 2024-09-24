using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Robot.KUKA;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormKuka : HslFormContent
	{
		public FormKuka( )
		{
			InitializeComponent( );
		}


		private KukaAvarProxyNet kuka = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			
			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( 
				new DeviceAddressExample[]
				{
					new DeviceAddressExample( "$OV_PRO",    "OV_PRO variable",   false, false, "ReadString / ReadStringAsync" ),
					new DeviceAddressExample( "$OV_JOG",    "OV_JOG variable",   false, false, "ReadString / ReadStringAsync" ),
					new DeviceAddressExample( "$AXIS_ACT",  "AXIS_ACT variable", false, false, "ReadString / ReadStringAsync" ),
					new DeviceAddressExample( "$AUT",      "",  false, false, "[String] “自动模式”信号声明" ),
					new DeviceAddressExample( "$AXIS_INT",      "",  false, false, "[String] 中断时机器人的位置" ),
					new DeviceAddressExample( "$MODE_OP",   "MODE_OP variable",  false, false, "[String] 显示当前操作模式" ),
					new DeviceAddressExample( "$OUT[1]",    "OUT[1] variable",   false, false, "ReadString / ReadStringAsync" ),
					new DeviceAddressExample( "$ACC_C",      "",  false, false, "[String] 在主运行中的轨迹、旋转和转动加速度" ),
					new DeviceAddressExample( "$ACT_TOOL",      "",  false, false, "[String] 当前的刀具坐标系统号" ),
					new DeviceAddressExample( "$COSYS",      "",  false, false, "[String] 步进坐标系统" ),
					new DeviceAddressExample( "$COUNT_I[32]",      "",  false, false, "String 自由使用整数变量" ),
					new DeviceAddressExample( "$PHGINFO",      "",  false, false, "[String] KCP CPU和软件版本的系列号" ),
					new DeviceAddressExample( "$POS_ACT",      "",  false, false, "[String] 笛卡儿坐标系中当前机器人位置" ),
					new DeviceAddressExample( "$POS_FOR",      "",  false, false, "[String] 笛卡儿坐标系中当前运动程序段的目标位置" ),
					new DeviceAddressExample( "$PRO_IP.NAME[32]",      "",  false, false, "[String] 主运行的程序段名称" ),
					new DeviceAddressExample( "$PRO_IP.SNR_C",      "",  false, false, "[String] 提前运行的程序段号" ),
					new DeviceAddressExample( "$PRO_START",      "",  false, false, "[String] 开始程序/命令执行" ),
					new DeviceAddressExample( "$ROBROOT",      "",  false, false, "[String] 机器人在world坐标系中的位置" ),
					new DeviceAddressExample( "$ROBTRAFO",      "",  false, false, "[String] 机器人名称" ),
					new DeviceAddressExample( "$TIME_POS[n]",      "",  false, false, "[String] 轴定位时间" ),
					new DeviceAddressExample( "$TOOL.A",      "",  false, false, "[String] 绕Z轴旋转" ),
					new DeviceAddressExample( "$KR_SERIALNO",      "",  false, false, "[String] 机器人序列号" ),
					new DeviceAddressExample( "$MODEL_NAME",      "",  false, false, "[String] 机器人类" ),
					new DeviceAddressExample( "$JUS_TOOL_NO",      "",  false, false, "[String] EMT 控制当前的刀具号" ),
					new DeviceAddressExample( "tool_data[1]", "frame variable",  false, false, "ReadString / ReadStringAsync" ),
				} );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Kuka Robot Demo";

				label1.Text = "Ip:";
				label2.Text = "You need to install a VB program on the robot controller, which comes from github: ";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "address:";
				label7.Text = "result:";
				label5.Text = "If you need more robot system variable names, please become an enterprise user object, thanks for the support.";


				button_read_string.Text = "r-string";


				label10.Text = "Address:";
				label9.Text = "Value:";

				button14.Text = "w-string";

				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
		}


		#region Connect And Close


		private async void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( "端口输入格式不正确！" );
				return;
			}
			
			kuka?.ConnectClose( );
			kuka = new KukaAvarProxyNet( textBox1.Text, port );
			kuka.LogNet = this.LogNet;

			try
			{
				OperateResult connect = await kuka.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置代码示例
					codeExampleControl.SetCodeText( "robot", kuka );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private async void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			await kuka.ConnectCloseAsync( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 单数据读取测试
		

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			DemoUtils.ReadResultRender( await kuka.ReadStringAsync( textBox3.Text ), textBox3.Text, textBox4 );

			textBox_code.Text = $"OperateResult<byte[]> read = kuka.Read( \"{textBox3.Text}\" )";
		}


		#endregion

		#region 单数据写入测试
		

		private async void button14_Click( object sender, EventArgs e )
		{
			// string写入
			try
			{
				DemoUtils.WriteResultRender( await kuka.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );


				textBox_code.Text = $"OperateResult write = kuka.Write( \"{textBox8.Text}\", \"{textBox7.Text}\" )";
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				System.Diagnostics.Process.Start( linkLabel1.Text );
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}
	}
	
}
