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
using HslCommunication.Profinet.Freedom;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFreedomTcpNet : HslFormContent
	{
		public FormFreedomTcpNet( )
		{
			InitializeComponent( );
			freedom = new FreedomTcpNet( );
		}


		private FreedomTcpNet freedom = null;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );


			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteDevice1.SetEnable( false );
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (freedom != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Free protocol access based on Tcp ip";
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
			freedom.LogNet = LogNet;

			freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );

			ComboBox2_SelectedIndexChanged( null, null );
			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;

			freedom.ConnectClose( );
			try
			{
				this.pipeSelectControl1.IniPipe( freedom );
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
				return;
			}

			button1.Enabled = false;
			freedom.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = freedom.ConnectServer( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );

				userControlReadWriteDevice1.SetReadWriteNet( freedom, "", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( freedom, "", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => freedom.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );


				// 设置代码示例
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( freedom, nameof( freedom.ByteTransform ) );
			}
			else
			{
				MessageBox.Show( connect.Message );
				button1.Enabled = true;
			}

		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			freedom.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );

			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );

			comboBox2.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, 0, int.Parse );
			checkBox3.Checked = GetXmlValue( element, DemoDeviceList.XmlStringReverse, false, bool.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}

}
