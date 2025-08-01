﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Profinet.AllenBradley;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.AllenBrandly;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormAllenBrandlyMicroCip : HslFormContent
	{
		public FormAllenBrandlyMicroCip( )
		{
			InitializeComponent( );
			allenBradleyNet = new AllenBradleyMicroCip( "192.168.0.110" );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private AllenBradleyMicroCip allenBradleyNet = null;
		private AllenBrandlyControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new AllenBrandlyControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.AllenBrandly.Helper.GetCIPAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "AllenBrandly Read PLC Demo [micro 800]";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{

			if (!byte.TryParse( textBox15.Text, out byte slot ))
			{
				DemoUtils.ShowMessage( DemoUtils.SlotInputWrong );
				return;
			}

			allenBradleyNet.Slot = slot;
			allenBradleyNet.LogNet = LogNet;

			//if (!string.IsNullOrEmpty( textBox16.Text ))
			//{
			//	allenBradleyNet.PortSlot = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox16.Text );
			//}

			try
			{
				this.pipeSelectControl1.IniPipe( allenBradleyNet );
				OperateResult connect = DeviceConnectPLC( allenBradleyNet );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( allenBradleyNet, "A1", true, 1 );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( allenBradleyNet, "A1", string.Empty );
					userControlReadWriteDevice1.BatchRead.SetReadRandom( allenBradleyNet.Read, "A1;A2" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => allenBradleyNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => allenBradleyNet.ReadEipFromServer( m ), "EIP", "EIP Message, example: " );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => allenBradleyNet.ReadCipFromServer( m ), "CIP", "CIP Message, example: " );

					control.SetDevice( allenBradleyNet, "A1" );

					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( allenBradleyNet, nameof( allenBradleyNet.Slot ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
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
			this.pipeSelectControl1.ExtraCloseAction( allenBradleyNet );
			allenBradleyNet?.ConnectClose( );
		}

		#endregion
		
		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox15.Text );
			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;


			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
