using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Panasonic;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.PLC.Panasonic;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormPanasonicMew : HslFormContent
	{
		public FormPanasonicMew( )
		{
			InitializeComponent( );
		}


		private PanasonicMewtocol panasonicMewtocol = null;
		private MewtocolControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new MewtocolControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetMewtocolAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Panasonic Read PLC Demo";
				label21.Text = "station";
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
			if (!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "Plc Station input wrong!" );
				return;
			}

			panasonicMewtocol?.Close( );
			panasonicMewtocol = new PanasonicMewtocol( station );
			panasonicMewtocol.LogNet = LogNet;

			
			try
			{
				this.pipeSelectControl1.IniPipe( panasonicMewtocol );
				OperateResult open = DeviceConnectPLC( panasonicMewtocol );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( panasonicMewtocol, "R0", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( panasonicMewtocol, "R0", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => panasonicMewtocol.ReadFromCoreServer( m ), string.Empty, string.Empty );
					control.SetDevice( panasonicMewtocol, "R0" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( panasonicMewtocol, nameof( panasonicMewtocol.Station ) );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
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
			panasonicMewtocol.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( panasonicMewtocol );
		}
		

		#endregion

		#region Test Function
		
		private void Test1()
		{
			OperateResult<bool[]> read = panasonicMewtocol.ReadBool( "100", 10 );
			if(read.IsSuccess)
			{
				bool coil_100 = read.Content[0];
				// and so on 
				bool coil_109 = read.Content[9];
			}
			else
			{
				// failed
				string err = read.Message;
			}
		}


		private void Test2()
		{
			bool[] values = new bool[] { true, false, false, false, true, true, false, true, false, false };
			OperateResult write = panasonicMewtocol.Write( "100", values );
			if (write.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
				string err = write.Message;
			}

		}


		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
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
