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
using System.IO.Ports;
using HslCommunicationDemo.DemoControl;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo
{
	public partial class FormFreedomSerial : HslFormContent
	{
		public FormFreedomSerial( )
		{
			InitializeComponent( );
			freedom = new FreedomSerial( );
		}


		private FreedomSerial freedom = null;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}


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
				Text = "Free protocol access based on serial port";

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
			// 连接

			if (!int.TryParse( textBox2.Text, out int baudRate ))
			{
				MessageBox.Show( DemoUtils.BaudRateInputWrong );
				return;
			}

			if (!int.TryParse( textBox16.Text, out int dataBits ))
			{
				MessageBox.Show( DemoUtils.DataBitsInputWrong );
				return;
			}

			if (!int.TryParse( textBox17.Text, out int stopBits ))
			{
				MessageBox.Show( DemoUtils.StopBitInputWrong );
				return;
			}

			freedom?.Close( );
			freedom = new FreedomSerial( );
			freedom.LogNet = LogNet;

			freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );
			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );

			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;
			freedom.SerialPortInni( sp =>
			{
				sp.PortName = comboBox3.Text;
				sp.BaudRate = baudRate;
				sp.DataBits = dataBits;
				sp.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
				sp.Parity = comboBox1.SelectedIndex == 0 ? Parity.None : (comboBox1.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
			} );
			freedom.RtsEnable = checkBox5.Checked;

			button1.Enabled = false;
			OperateResult open = freedom.Open( );
			if (open.IsSuccess)
			{
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );

				userControlReadWriteDevice1.SetReadWriteNet( freedom, "", false );
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
				MessageBox.Show( open.Message );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			freedom.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );

			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = GetXmlValue( element, DemoDeviceList.XmlCom, "COM1", m => m );
			textBox2.Text = GetXmlValue( element, DemoDeviceList.XmlBaudRate, "9600", m => m );
			textBox16.Text = GetXmlValue( element, DemoDeviceList.XmlDataBits, "8", m => m );
			textBox17.Text = GetXmlValue( element, DemoDeviceList.XmlStopBit, "1", m => m );
			comboBox1.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlParity, 0, int.Parse );
			checkBox5.Checked = GetXmlValue( element, DemoDeviceList.XmlRtsEnable, true, bool.Parse );

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
