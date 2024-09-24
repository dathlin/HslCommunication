using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using System.Threading;
using HslCommunication.Profinet.LSIS;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormLsisFEnet : HslFormContent
	{
		public FormLsisFEnet( )
		{
			InitializeComponent( );
			fastEnet = new LSFastEnet( );
		}


		private LSFastEnet fastEnet = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			cboxModel.DataSource = Enum.GetNames( typeof( LSCpuInfo ) );
			cboxCompanyID.SelectedIndex = 0;

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Lsis.Helper.GetLsisCnetAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Lsis Read PLC Demo";
			   

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
			if(!byte.TryParse(textBox_slot.Text, out byte slot ))
			{
				MessageBox.Show( DemoUtils.SlotInputWrong );
				return;
			}

			if (!byte.TryParse( textBox_baseNo.Text, out byte baseNo ))
			{
				MessageBox.Show( "BaseNo input wrong" );
				return;
			}

			fastEnet.SlotNo = slot;
			fastEnet.BaseNo = baseNo;
			fastEnet.SetCpuType = cboxModel.Text;
			fastEnet.CompanyID = cboxCompanyID.Text;
			fastEnet.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( fastEnet );
				OperateResult connect = DeviceConnectPLC( fastEnet );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( fastEnet, "MB100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( fastEnet, "MB100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => fastEnet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( fastEnet, nameof( fastEnet.SlotNo ), nameof( fastEnet.BaseNo ), nameof( fastEnet.SetCpuType ), nameof( fastEnet.CompanyID ) );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			fastEnet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( fastEnet );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlCpuType, cboxModel.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, cboxCompanyID.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox_slot.Text );
			element.SetAttributeValue( "BaseNo", textBox_baseNo.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			cboxModel.Text = element.Attribute( DemoDeviceList.XmlCpuType ).Value;
			cboxCompanyID.Text = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox_slot.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
			textBox_baseNo.Text = GetXmlValue( element, "BaseNo", textBox_baseNo.Text, m => m );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
