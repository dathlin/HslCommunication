using HslCommunication;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace HslCommunicationDemo.PLC.Cimon
{
	public partial class FormCimonHmiProtocol: HslFormContent
	{
		public FormCimonHmiProtocol()
		{
			InitializeComponent();
		}


		private HslCommunication.Profinet.Cimon.CimonHmiProtocol cimon = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormCimonHmiProtocol_Load( object sender, EventArgs e )
		{

			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Cimon.Helper.GetCimonAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "CimonHmiProtocol Read Demo";

				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接PLC操作
			if (!byte.TryParse( textBox15.Text, out byte station ))
			{
				DemoUtils.ShowMessage( "FrameNo input is wrong！" );
				return;
			}

			cimon?.ConnectClose( );
			cimon = new HslCommunication.Profinet.Cimon.CimonHmiProtocol( );
			cimon.FrameNo = station;
			cimon.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( cimon );
				OperateResult connect = DeviceConnectPLC( cimon );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( cimon, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( cimon, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => cimon.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );


					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( cimon, nameof( cimon.FrameNo ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
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
			cimon.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( cimon );
		}

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
