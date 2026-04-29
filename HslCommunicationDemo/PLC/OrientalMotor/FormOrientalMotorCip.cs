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
using HslCommunication.Profinet.Omron;
using HslCommunication;
using HslCommunication.Profinet.AllenBradley;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.AllenBrandly;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Profinet.OrientalMotor;
using HslCommunicationDemo.PLC.OrientalMotor;
using HslCommunication.Core;

namespace HslCommunicationDemo
{
	public partial class FormOrientalMotorCip : HslFormContent
	{
		public FormOrientalMotorCip( )
		{
			InitializeComponent( );
			orientalEip = new OrientalMotorEipNet( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private OrientalMotorEipNet orientalEip = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private OrientalMotorControl motorControl;

		public static Dictionary<string,DeviceAddressExample[]> GetCIPAddressExamples( )
		{
			DeviceAddressExample[] input = new DeviceAddressExample[]
			{
				new DeviceAddressExample( "input[0]", "遥控 I/O（R-OUT）", false, true, "short读取" ),
				new DeviceAddressExample( "input[2]", "程序 No. 选择", false, true, "short读取" ),
				new DeviceAddressExample( "input[4] ~ input[7]", "控制器控制", false, true, "byte读取，32个位" ),
				new DeviceAddressExample( "input[8]", "JOG 运行响应（用户坐标系）", false, true, "short读取" ),
				new DeviceAddressExample( "input[10]", "微动运行响应（用户坐标系）", false, true, "short读取" ),
				new DeviceAddressExample( "input[12]", "JOG 运行响应（轴）", false, true, "short读取，十六个位" ),
				new DeviceAddressExample( "input[14]", "微动运行响应（轴）", false, true, "short读取，十六个位" ),
				new DeviceAddressExample( "input[16]", "运行失败代码", false, true, "short读取" ),
				new DeviceAddressExample( "input[18]", "控制器的当前 Alarm", false, true, "short读取" ),
				new DeviceAddressExample( "input[20] ~ input[23]", "控制器的 Information", false, true, "byte读取" ),
				new DeviceAddressExample( "input[24] ~ input[31]", "轴的当前 Alarm 代码（轴 1 ～ 8）", false, true, "byte读取" ),
				new DeviceAddressExample( "input[32]", "运行模式显示", false, true, "short读取, 0：自动模式、1：运行禁止模式" ),
				new DeviceAddressExample( "input[34]", "当前的机器人类型", false, true, "byte读取, 0：无设定、1：笛卡尔坐标、2：SCARA、3：关节" ),
				new DeviceAddressExample( "input[35]", "轴数", false, true, "byte读取" ),
				new DeviceAddressExample( "input[36] ~ input[39]", "控制器﻿任意监视 0", false, true, "byte读取" ),
				new DeviceAddressExample( "input[40] ~ output[43]", "控制器﻿任意监视 1", false, true, "byte读取" ),
				new DeviceAddressExample( "input[44] ~ output[47]", "控制器﻿任意监视 2", false, true, "byte读取" ),
				new DeviceAddressExample( "input[48] ~ output[51]", "控制器﻿任意监视 3", false, true, "byte读取" ),
				new DeviceAddressExample( "input[52]", "（DD）反映 TRIG_R", false, true, "short读取" ),
				new DeviceAddressExample( "input[54]", "（DD）状态", false, true, "short读取" ),
				new DeviceAddressExample( "input[56]", "（DD）运行方式 _R", false, true, "short读取" ),
				new DeviceAddressExample( "input[58]", "（DD）轴选择 _R", false, true, "byte读取" ),
				new DeviceAddressExample( "input[59]", "（DD）TCP 运行对象坐标选择 _R ", false, true, "byte读取" ),
				new DeviceAddressExample( "input[60]", "检测位置﻿X 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[64]", "检测位置﻿Y 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[68]", "检测位置﻿Z 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[72]", "检测位置﻿Rx 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[76]", "检测位置﻿Ry 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[80]", "检测位置﻿Rz 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[84]", "检测位置﻿E 坐标", false, true, "int读取" ),
				new DeviceAddressExample( "input[88]", "预约", false, true, "int读取" ),
				new DeviceAddressExample( "input[92]", "TCP 检测速度（X、Y、Z）", false, true, "int读取" ),
				new DeviceAddressExample( "input[96]", "当前的手系", false, true, "short读取,０：不对应、1：右手系、 ﻿2：左手系" ),
			};
			DeviceAddressExample[] output = new DeviceAddressExample[]
			{
				new DeviceAddressExample( "output[0]", "遥控I/O（R-IN）", false, true, "short写入" ),
				new DeviceAddressExample( "output[2]", "程序 No. 选择", false, true, "short写入" ),
				new DeviceAddressExample( "output[4] ~ output[7]", "控制器控制输入", false, true, "byte写入" ),
				new DeviceAddressExample( "output[8]", "JOG 运行输入", false, true, "short写入" ),
				new DeviceAddressExample( "output[10]", "微动运行输入", false, true, "short写入" ),
				new DeviceAddressExample( "output[12]", "JOG 运行输入（轴）", false, true, "short写入" ),
				new DeviceAddressExample( "output[14]", "微动运行输入（轴）", false, true, "short写入" ),
				new DeviceAddressExample( "output[16]", "JOG 运行速度（X、Y、Z、Tx、Ty、Tz）", false, true, "int 写入" ),
				new DeviceAddressExample( "output[20] ~ output[23]", "JOG 运行速度（Rx、Ry、Rz）", false, true, "byte写入" ),
				new DeviceAddressExample( "output[24] ~ output[27]", "JOG 运行速度（E）", false, true, "int写入" ),
				new DeviceAddressExample( "output[28] ~ output[31]", "JOG 运行速度（轴）", false, true, "int写入" ),
				new DeviceAddressExample( "output[32]", "JOG 运行移动量（X、Y、Z）", false, true, "int写入" ),
				new DeviceAddressExample( "output[36]", "JOG 运行移动量（Rx、Ry、Rz）", false, true, "int写入" ),
				new DeviceAddressExample( "output[40]", "JOG 运行移动量（E）", false, true, "int写入" ),
				new DeviceAddressExample( "output[44]", "JOG 运行移动量（轴）", false, true, "int写入" ),
				new DeviceAddressExample( "output[48]", "预约", false, true, "" ),
				new DeviceAddressExample( "output[52]", "（DD）反映 TRIG", false, true, "short写入" ),
				new DeviceAddressExample( "output[54]", "预约", false, true, "byte写入" ),
				new DeviceAddressExample( "output[56]", "（DD）运行方式", false, true, "short写入" ),
				new DeviceAddressExample( "output[58]", "（DD）轴选择", false, true, "byte写入" ),
				new DeviceAddressExample( "output[59]", "（DD）TCP 运行对象坐标选择", false, true, "byte写入" ),
				new DeviceAddressExample( "output[60]", "（DD）位置﻿X 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[64]", "（DD）位置﻿Y 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[68]", "（DD）位置﻿Z 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[72]", "（DD）位置﻿Rx 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[76]", "（DD）位置﻿Ry 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[80]", "（DD）位置﻿Rz 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[84]", "（DD）位置﻿E 坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[88]", "预约", false, true, "" ),
				new DeviceAddressExample( "output[92]", "（DD）速度", false, true, "int写入" ),
				new DeviceAddressExample( "output[96]", "（DD）加速斜率", false, true, "int写入" ),
				new DeviceAddressExample( "output[100]", "（DD）减速斜率", false, true, "int写入" ),
				new DeviceAddressExample( "output[104]", "（DD）位置（轴）", false, true, "int写入" ),
				new DeviceAddressExample( "output[108]", "（DD）末端执行器运行方式", false, true, "short写入" ),
				new DeviceAddressExample( "output[110]", "（DD）末端执行器压推电流", false, true, "short写入" ),
				new DeviceAddressExample( "output[112]", "（DD）PTP 运行﻿手系选择", false, true, "short写入" ),
				new DeviceAddressExample( "output[114]", "（DD）圆弧插补运行﻿设定方法", false, true, "short写入" ),
				new DeviceAddressExample( "output[116]", "（DD）圆弧插补运行﻿半径", false, true, "int写入" ),
				new DeviceAddressExample( "output[120]", "（DD）圆弧插补运行﻿X 中心坐标 /﻿X 经由点坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[124]", "（DD）圆弧插补运行﻿Y 中心坐标 /Y 经由点坐标", false, true, "int写入" ),
				new DeviceAddressExample( "output[128]", "（DD）拱形插补运行﻿上升高度", false, true, "int写入" ),
				new DeviceAddressExample( "output[132]", "（DD）拱形插补运行﻿最大高度", false, true, "int写入" ),
				new DeviceAddressExample( "output[136]", "（DD）拱形插补运行﻿下降开始高度", false, true, "int写入" ),
				new DeviceAddressExample( "output[140]", "（DD）托板 No. 选择", false, true, "int写入" ),
			};
			return new Dictionary<string, DeviceAddressExample[]>
			{
				{ "Input", input },
				{ "Output", output }
			};
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			this.pipeSelectControl1.SetButtonReference( button1, button2 );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( GetCIPAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			motorControl = new OrientalMotorControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( motorControl, false, "Motor Data" );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteDevice1, e );
			if (e.Cancel) return;

			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		#region Connect And Close


		private void button1_Click( object sender, EventArgs e )
		{
			orientalEip.LogNet = LogNet;
			orientalEip.ConnectTimeOut = 5000;

			try
			{
				orientalEip.RunIdleHeader = textBox_runIdle.Text.StartsWith( "0x" ) ? Convert.ToUInt32( textBox_runIdle.Text.Substring( 2 ), 16 ) : Convert.ToUInt32( textBox_runIdle.Text );
				orientalEip.RPITime = Convert.ToUInt32( textBox_rpi.Text );
				orientalEip.ActualTimeout = Convert.ToInt32( textBox_timeout.Text );
				this.pipeSelectControl1.IniPipe( orientalEip );
				OperateResult connect = DeviceConnectPLC( orientalEip );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );
					textBox_udp_port.Text = orientalEip.CipIoPort.ToString( );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( orientalEip, "input[48]", true, 1 );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( orientalEip, "input[48]", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => orientalEip.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					// TODO EIP及CIP的例子填充

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( orientalEip, nameof( orientalEip.RunIdleHeader ), nameof( orientalEip.RPITime ), nameof( orientalEip.ActualTimeout ) );
					motorControl.SetMotor( orientalEip );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( orientalEip );
			orientalEip?.ConnectClose( );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( nameof( orientalEip.RunIdleHeader ), textBox_runIdle.Text );
			element.SetAttributeValue( nameof( orientalEip.RPITime ), textBox_rpi.Text );
			element.SetAttributeValue( nameof( orientalEip.ActualTimeout ), textBox_timeout.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			textBox_runIdle.Text = GetXmlValue( element, nameof( orientalEip.RunIdleHeader ), "0", m => m );
			textBox_rpi.Text = GetXmlValue( element, nameof( orientalEip.RPITime ), "100", m => m );
			textBox_timeout.Text = GetXmlValue( element, nameof( orientalEip.ActualTimeout ), "2", m => m );
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void pipeSelectControl1_Load( object sender, EventArgs e )
		{

		}
	}
}
