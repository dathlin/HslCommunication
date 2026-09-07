using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Device;
using HslCommunication.Core.Pipe;
using HslCommunication.Core.Plugin;
using HslCommunication.MQTT;
using HslCommunication.Profinet;
using HslCommunication.Profinet.Melsec;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Melsec;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo
{
	public partial class FormPluginsNet : HslFormContent
	{
		public FormPluginsNet( PluginsDeviceDefinition deviceDefinition )
		{
			InitializeComponent( );

			try
			{
				if (!string.IsNullOrEmpty( deviceDefinition.Http )) this.userControlHead1.HelpLink = deviceDefinition.Http;

				this.deviceDefinition = deviceDefinition;
				object deviceObj = deviceDefinition.DeviceObject.Assembly.CreateInstance( deviceDefinition.DeviceObject.FullName );
				this.device = new DevicePluginNet( deviceObj );

				MethodInfo method = deviceDefinition.DeviceObject.GetMethod( "GetDeviceAddressExamples" );
				if (method != null)
				{
					object address = method.Invoke( deviceObj, null );
					if (address is List<object> list)
					{
						// 如果来自自定义的插件里，完全自定义的一个方法
						List<DeviceAddressExample> result = new List<DeviceAddressExample>( );
						foreach (object item in list)
						{
							try
							{
								result.Add( new DeviceAddressExample( item ) );
							}
							catch
							{

							}
						}

						if (result.Count > 0) defalutAddress = result[0].AddressExample;
						addressExamples = result.ToArray( );
					}
				}

				MethodInfo pipeMethod = deviceDefinition.DeviceObject.GetMethod( "DefaultCommunicationPipe" );
				if (pipeMethod != null)
				{
					string pipeDecs = pipeMethod.Invoke( deviceObj, null ) as string;
					if (pipeDecs != null)
					{
						if (pipeDecs.StartsWith( "TCP:", StringComparison.OrdinalIgnoreCase ))
						{
							string[] splits = pipeDecs.Substring( 4 ).Split( new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries );
							pipeSelectControl1.SettingPipe = SettingPipe.TcpPipe;
							if (splits.Length > 0) pipeSelectControl1.TcpIpText = splits[0];
							if (splits.Length > 1) pipeSelectControl1.TcpPortText = splits[1];
						}
						else if (pipeDecs.StartsWith( "UDP:", StringComparison.OrdinalIgnoreCase ))
						{
							string[] splits = pipeDecs.Substring( 4 ).Split( new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries );
							pipeSelectControl1.SettingPipe = SettingPipe.UdpPipe;
							if (splits.Length > 0) pipeSelectControl1.UdpIpText = splits[0];
							if (splits.Length > 1) pipeSelectControl1.UdpPortText = splits[1];
						}
						else if (pipeDecs.StartsWith( "COM", StringComparison.OrdinalIgnoreCase ))
						{
							string[] splits = pipeDecs.Split( new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries );
							pipeSelectControl1.SettingPipe = SettingPipe.SerialPipe;
							if (splits.Length > 0) pipeSelectControl1.SerialPortText = splits[0]; // COM3
							if (splits.Length > 1) pipeSelectControl1.SerialBaudRate = splits[1]; // 9600
							if (splits.Length > 2) pipeSelectControl1.SerialDataBits = splits[2]; // 8
							if (splits.Length > 3) pipeSelectControl1.SerialParity = splits[3] == "N" ? System.IO.Ports.Parity.None : splits[3] == "O" ? System.IO.Ports.Parity.Odd : splits[3] == "E" ? System.IO.Ports.Parity.Even : System.IO.Ports.Parity.Space;
							if (splits.Length > 4) pipeSelectControl1.SerialStopBits = splits[4];
						}
					}
				}

				dataFormatDefault = this.device.ByteTransform.DataFormat;
				if (this.device.ByteTransform.DataFormat == HslCommunication.Core.DataFormat.ABCD) comboBox1.SelectedIndex = 0;
				else if (this.device.ByteTransform.DataFormat == HslCommunication.Core.DataFormat.BADC) comboBox1.SelectedIndex = 1;
				else if (this.device.ByteTransform.DataFormat == HslCommunication.Core.DataFormat.CDAB) comboBox1.SelectedIndex = 2;
				else if (this.device.ByteTransform.DataFormat == HslCommunication.Core.DataFormat.DCBA) comboBox1.SelectedIndex = 3;
			}
			catch (Exception ex) 
			{
				DemoUtils.ShowMessage( ex.Message + Environment.NewLine + ex.StackTrace );
			}
			DemoUtils.SetPanelAnchor( panel1, panel2 );


			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (this.device != null)
			{
				switch(comboBox1.SelectedIndex)
				{
					case 0: this.device.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: this.device.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: this.device.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: this.device.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
				}
			}
		}

		private PluginsDeviceDefinition deviceDefinition = null;
		private DeviceAddressExample[] addressExamples = new DeviceAddressExample[0];
		private DevicePluginNet device;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private string defalutAddress = "";
		private HslCommunication.Core.DataFormat dataFormatDefault = HslCommunication.Core.DataFormat.ABCD;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			this.pipeSelectControl1.SetButtonReference( button1, button2 );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( addressExamples );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) ) ;

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				if (string.IsNullOrEmpty( this.deviceDefinition.DeviceName ))
					Text = "PluginDeviceDemo";
				else
					Text = this.deviceDefinition.DeviceName + "Demo";
			}
			else
			{
				if (string.IsNullOrEmpty( this.deviceDefinition.DeviceName ))
					Text = "插件设备访问Demo";
				else
					Text = this.deviceDefinition.DeviceName + "访问Demo";
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
			device.ConnectClose( );
			device.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( device );
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage( ex );
				return;
			}

			OperateResult connect = DeviceConnectPLC( device );

			if (connect.IsSuccess)
			{
				DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;

				userControlReadWriteDevice1.SetEnable( true );

				// 设置子控件的读取能力
				userControlReadWriteDevice1.SetReadWriteNet( device, defalutAddress, true );
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( device, defalutAddress, "" );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => device.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

				// 设置代码示例
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );

				codeExampleControl.SetPluginsCodeText( device, this.deviceDefinition.PluginFilePath, this.deviceDefinition.DeviceName );
			}
			else
			{
				DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
			}
		}


		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( device );
			device?.ConnectClose( );
		}

		#endregion



		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );

			this.userControlReadWriteDevice1.GetDataTable( element );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( "SaveImageKey", this.deviceDefinition.ImageKey );
			element.SetAttributeValue( "PluginFileName", this.deviceDefinition.PluginFilePath );
			element.SetAttributeValue( "PluginDeviceName", this.deviceDefinition.DeviceName );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			comboBox1.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, 0, int.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}

}
