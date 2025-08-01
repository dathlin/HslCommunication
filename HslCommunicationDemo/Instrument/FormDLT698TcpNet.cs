﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.Instrument.DLT;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.Instrument;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormDLT698TcpNet : HslFormContent
	{
		public FormDLT698TcpNet( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private DLT698TcpNet dLT698 = null;
		private DLT698Control control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new DLT698Control( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.DLTHelper.GetDlt698Address( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "DLT698-TCP Read Demo";
				label_address.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			dLT698?.ConnectClose( );
			dLT698 = new DLT698TcpNet( textBox_station.Text);
			dLT698.LogNet = LogNet;
			dLT698.UseSecurityResquest = checkBox_useSecurityResquest.Checked;

			try
			{
				this.pipeSelectControl1.IniPipe( dLT698 );
				OperateResult connect = DeviceConnectPLC( dLT698 );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					userControlReadWriteDevice1.SetReadWriteNet( dLT698, "20-00-02-00", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( dLT698, "20-00-02-00", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => dLT698.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => dLT698.ReadByApdu( m ), "Apdu", "Apdu Message: 05 01 01 20 10 02 00 00" );

					control.SetDevice( dLT698, "20-00-02-00" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( "dlt" );
					codeExampleControl.SetCodeText( "dlt", dLT698, nameof( dLT698.Station ), nameof( dLT698.EnableCodeFE ), nameof( dLT698.UseSecurityResquest ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode );
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
			this.pipeSelectControl1.ExtraCloseAction( dLT698 );
			dLT698.ConnectClose( );
		}
		
		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( "UseSecurityResquest", checkBox_useSecurityResquest.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox_useSecurityResquest.Checked = GetXmlValue( element, "UseSecurityResquest", true, bool.Parse );


			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
