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
using HslCommunication;
using HslCommunication.Profinet.Yokogawa;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Yokogawa;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormYokogawaLinkTcp : HslFormContent
	{
		public FormYokogawaLinkTcp( )
		{
			InitializeComponent( );
			yokogawa = new YokogawaLinkTcp( );
			yokogawa.ConnectTimeOut = 2000;
		}


		private YokogawaLinkTcp yokogawa = null;
		private YokogawaLinkControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new YokogawaLinkControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Yokogawa.Helper.GetYokogawaAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Yokogawa Read PLC Demo";

				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{

			if (!byte.TryParse( textBox16.Text, out byte cpu ))
			{
				MessageBox.Show( "Cpu Number input wrong！" );
				return;
			}
			
			yokogawa.CpuNumber = cpu;
			yokogawa.LogNet = LogNet;
			try
			{
				this.pipeSelectControl1.IniPipe( yokogawa );
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
				return;
			}

			OperateResult connect = DeviceConnectPLC( yokogawa );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );

				//userControlReadWriteOp1.SetReadWriteNet( yokogawa, "D100", false );

				// 设置基本的读写信息
				userControlReadWriteDevice1.SetReadWriteNet( yokogawa, "D100", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( yokogawa, "D100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => yokogawa.ReadFromCoreServer( m, hasResponseData: true, usePackAndUnpack: false ), string.Empty, string.Empty );
				control.SetDevice( yokogawa, "D100" );

				// 设置示例代码
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( yokogawa, nameof( yokogawa.CpuNumber ) );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
					"Error: " + connect.ErrorCode );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			yokogawa.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( yokogawa );
		}
		

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
