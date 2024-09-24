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
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using HslCommunicationDemo.PLC.Siemens;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormSiemensWebApi : HslFormContent
	{
		public FormSiemensWebApi( )
		{
			InitializeComponent( );
			siemensTcpNet = new SiemensWebApi( );
		}


		private SiemensWebApi siemensTcpNet = null;
		private SiemensWebApiControl webApiControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			userControlReadWriteDevice1.RemoveReadBatch( );
			userControlReadWriteDevice1.RemoveReadMessage( );

			webApiControl = new SiemensWebApiControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( webApiControl, true );


			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
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
			if(!int.TryParse(textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			siemensTcpNet.IpAddress = textBox1.Text;
			siemensTcpNet.Port = port;
			siemensTcpNet.LogNet = LogNet;
			//siemensTcpNet.LocalBinding = new System.Net.IPEndPoint( System.Net.IPAddress.Parse( "127.0.0.1" ), 12345 );
			try
			{
				siemensTcpNet.UserName = textBox15.Text;
				siemensTcpNet.Password = textBox16.Text;

				OperateResult connect = siemensTcpNet.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );
					// 设置读写操作
					userControlReadWriteDevice1.SetReadWriteNet( siemensTcpNet, "\"全局DB\".Static_14", false );
					// 设置特殊功能测试
					webApiControl.SetReadWriteNet( siemensTcpNet );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( siemensTcpNet, nameof( siemensTcpNet.UserName ), nameof( siemensTcpNet.Password ) );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message );
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
			siemensTcpNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
		}
		
		#endregion



		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox16.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			OperateResult<double> read = await siemensTcpNet.ReadVersionAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( read.Content.ToString( ) );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			OperateResult read = await siemensTcpNet.ReadPingAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Ping Success" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}
		}
	}
}
