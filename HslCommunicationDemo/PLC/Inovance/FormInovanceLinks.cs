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
using HslCommunication.Profinet.Melsec;
using HslCommunication;
using System.Xml.Linq;
using System.IO.Ports;
using HslCommunicationDemo.PLC.Melsec;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Profinet.Omron;
using System.Diagnostics;

namespace HslCommunicationDemo
{
	public partial class FormInovanceLinks : HslFormContent
	{
		public FormInovanceLinks( )
		{
			InitializeComponent( );
			inovance = new HslCommunication.Profinet.Inovance.InovanceComputerLink( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private HslCommunication.Profinet.Inovance.InovanceComputerLink inovance = null;
		private FxLinksControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			try
			{
				comboBox_format.SelectedIndex = 1;
			}
			catch
			{
			}

			Language( Program.Language );
			this.pipeSelectControl1.SetButtonReference( button1, button2 );

			control = new FxLinksControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetFxLinksAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Inovance Read PLC Demo";
				label21.Text = "Station:";
				label22.Text = "TimeOut:";
				checkBox1.Text = "SumCheck?";

				label2.Text = "Format:";
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
			inovance?.Close( );
			inovance = new HslCommunication.Profinet.Inovance.InovanceComputerLink( );
			inovance.LogNet = LogNet;
			
			try
			{
				this.pipeSelectControl1.IniPipe( inovance );
				inovance.Station = byte.Parse( textBox15.Text );
				inovance.WaittingTime = byte.Parse( textBox18.Text );
				inovance.SumCheck = checkBox1.Checked;
				inovance.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );

				OperateResult open = DeviceConnectPLC( inovance );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( inovance, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( inovance, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => inovance.ReadFromCoreServer( m ), string.Empty, string.Empty );
					control.SetDevice( inovance, "D100" );

					// 设置示例的代码
					List<string> paras = new List<string>( );
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( inovance, nameof( inovance.Station ), nameof( inovance.WaittingTime ), nameof( inovance.SumCheck ), nameof( inovance.Format ) );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
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
			this.pipeSelectControl1.ExtraCloseAction( inovance );
			inovance?.Close( );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox18.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSumCheck, checkBox1.Checked );
			element.SetAttributeValue( "OmronFormat", comboBox_format.SelectedIndex );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox18.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlSumCheck ).Value );
			comboBox_format.SelectedIndex = GetXmlValue( element, "OmronFormat", comboBox_format.SelectedIndex, int.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
