using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Toledo;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Toledo
{
	public partial class FormToledoSerial : HslFormContent
	{
		public FormToledoSerial( )
		{
			InitializeComponent( );
		}

		private void FormToledoSerial_Load( object sender, EventArgs e )
		{

			panel2.Enabled = false;

			hslCurve1.SetLeftCurve( "重量", null, Color.Red );
			comboBox1.SelectedIndex = 0;

			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "托利多串口调试助手";
				label1.Text = "Com口：";
				label3.Text = "波特率:";
				label22.Text = "数据位:";
				label23.Text = "停止位:";
				label24.Text = "奇偶：";
				button1.Text = "打开串口";
				button2.Text = "关闭串口";
				label7.Text = "数据接收区：";
				checkBox4.Text = "是否显示时间";
				comboBox1.DataSource = new string[] { "无", "奇", "偶" };
			}
			else
			{
				Text = "Toledo Serial Demo";
				label1.Text = "Com:";
				label3.Text = "Baud rate:";
				label22.Text = "Data bits:";
				label23.Text = "Stop bits:";
				label24.Text = "parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label7.Text = "Data receiving Area:";
				checkBox4.Text = "Whether to show time";
				comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
				checkBox1.Text = "Sum Check?";
			}
		}

		private ToledoSerial toledoSerial;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int baudRate ))
			{
				MessageBox.Show( Program.Language == 1 ? "波特率输入错误！" : "Baud rate input error" );
				return;
			}

			if (!int.TryParse( textBox16.Text, out int dataBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "数据位输入错误！" : "Data bits input error" );
				return;
			}

			if (!int.TryParse( textBox17.Text, out int stopBits ))
			{
				MessageBox.Show( Program.Language == 1 ? "停止位输入错误！" : "Stop bits input error" );
				return;
			}

			toledoSerial = new ToledoSerial( );
			toledoSerial.OnToledoStandardDataReceived += ToledoSerial_OnToledoStandardDataReceived;
			toledoSerial.LogNet = LogNet;
			toledoSerial.HasChk = checkBox1.Checked;

			toledoSerial.SerialPortInni( new Action<SerialPort>( m =>
			  {
				  m.PortName = comboBox3.Text;
				  m.BaudRate = baudRate;
				  m.DataBits = dataBits;
				  m.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
				  m.Parity = comboBox1.SelectedIndex == 0 ? Parity.None : (comboBox1.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
				  m.RtsEnable = checkBox5.Checked;
			  } ));

			try
			{
				toledoSerial.Open( );
				button1.Enabled = false;
				button2.Enabled = true;

				panel2.Enabled = true;
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private long receiveTimes = 0;
		private void ToledoSerial_OnToledoStandardDataReceived( object sender, ToledoStandardData e )
		{
			if (InvokeRequired)
			{
				Invoke( new Action<object, ToledoStandardData>( ToledoSerial_OnToledoStandardDataReceived ), sender, e );
				return;
			}

			receiveTimes++;
			StringBuilder sb = new StringBuilder( );
			if (checkBox4.Checked)
				sb.Append( DateTime.Now.ToString( ) + Environment.NewLine );
			sb.Append( e.ToJsonString( ) + Environment.NewLine );
			textBox6.Text = sb.ToString( );

			textBox1.Text = e.SourceData.ToHexString( ' ' );
			textBox3.Text = Encoding.ASCII.GetString( e.SourceData );

			toledoDataControl1.SetToledoData( e );
			hslCurve1.AddCurveData( "重量", e.Weight );
			hslDialPlate1.Value = e.Weight;

			label2.Text = "Receive Times:" + receiveTimes;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			try
			{
				toledoSerial?.Close( );
				button2.Enabled = false;
				button1.Enabled = true;

				panel2.Enabled = false;
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if (float.TryParse( textBox4.Text, out float result ))
			{
				hslCurve1.ReferenceAxisLeft.Max = result;
				hslDialPlate1.MaxValue = result;
			}
			else
			{
				MessageBox.Show( "Input Wrong" );
			}
		}



		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
