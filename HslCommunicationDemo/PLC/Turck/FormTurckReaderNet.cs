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
using HslCommunication.Profinet.Turck;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.LogNet;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Turck;

namespace HslCommunicationDemo
{
	public partial class FormTurckReaderNet : HslFormContent
	{
		public FormTurckReaderNet( )
		{
			InitializeComponent( );
			reader_net = new ReaderNet( );
			//reader_net.LogNet = new LogNetSingle( "" );
			//reader_net.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		private ReaderNet reader_net = null;
		private TurckReaderControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new TurckReaderControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( 
				new DeviceAddressExample[]
				{
					new DeviceAddressExample( "100",    "整数地址", false, true, "" ),
					new DeviceAddressExample( "100.1",    "小数地址", false, true, "" ),
				} );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Turck Reader Demo";
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
			reader_net.ConnectClose( );
			reader_net.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( reader_net );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
				return;
			}
			OperateResult connect = DeviceConnectPLC( reader_net );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );
				//userControlReadWriteOp1.SetReadWriteNet( reader_net, "100", false );

				// 设置基本的读写信息
				userControlReadWriteDevice1.SetReadWriteNet( reader_net, "100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( reader_net, "100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => reader_net.ReadFromCoreServer( m ), string.Empty, string.Empty );
				// 特殊控件
				control.SetDevice( reader_net, "100" );


				// 设置代码示例
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( reader_net );
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
			reader_net.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( reader_net );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}

}
