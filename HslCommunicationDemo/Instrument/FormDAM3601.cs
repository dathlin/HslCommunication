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
using HslCommunication.Instrument.Temperature;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormDAM3601 : HslFormContent
	{
		public FormDAM3601( )
		{
			InitializeComponent( );
		}


		private DAM3601 dAM3601 = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;



			comboBox_dataformat.SelectedIndex = 2;
			comboBox_dataformat.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox_stringreverse.CheckedChanged += CheckBox3_CheckedChanged;

			Language( Program.Language );
			
			// 动态生成128个 label和128个textbox
			int index = 1;
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Label label = new Label( );
					label.Text = "温度" + index;
					label.AutoSize = true;
					TextBox textBox = new TextBox( );
					textBox.Width = 50;

					label.Parent = groupBox1;
					label.Location = new Point( j * 115 + 5, i * 25 + 72 );
					textBox.Parent = groupBox1;
					textBox.Location = new Point( j * 115 + 60, i * 25 + 70 );
					allTextBox.Add( textBox );
					index++;
				}
			}
		}

		private List<TextBox> allTextBox = new List<TextBox>( );

		private void Language( int language )
		{
			// 英文显示
			if (language == 2)
			{
				Text = "Modbus Rtu Read Demo";
				label21.Text = "station";
				checkBox_startwith0.Text = "address from 0";
				checkBox_stringreverse.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button_read_bool.Text = "r-coil";
				groupBox1.Text = "read test";
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (dAM3601 != null)
			{
				dAM3601.IsStringReverse = checkBox_stringreverse.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (dAM3601 != null)
			{
				switch (comboBox_dataformat.SelectedIndex)
				{
					case 0: dAM3601.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: dAM3601.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: dAM3601.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: dAM3601.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}


		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			
		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse(textBox_station.Text,out byte station))
			{
				MessageBox.Show( "站号输入不正确！" );
				return;
			}

			dAM3601?.Close( );
			dAM3601 = new DAM3601( station );
			dAM3601.AddressStartWithZero = checkBox_startwith0.Checked;
			dAM3601.LogNet = LogNet;


			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
			dAM3601.IsStringReverse = checkBox_stringreverse.Checked;


			try
			{
				this.pipeSelectControl1.IniPipe( dAM3601 );
				OperateResult open = DeviceConnectPLC( dAM3601 );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
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
			dAM3601.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
			this.pipeSelectControl1.ExtraCloseAction( dAM3601 );
		}









		#endregion

		private void button_read_bool_Click( object sender, EventArgs e )
		{
			OperateResult<float[]> read = dAM3601.ReadAllTemperature( );
			if(!read.IsSuccess)
			{
				MessageBox.Show( "读取失败！原因：" + read.Message );
				return;
			}

			// 显示128个数据信息
			for (int i = 0; i < allTextBox.Count; i++)
			{
				allTextBox[i].Text = read.Content[i].ToString( );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox_startwith0.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox_dataformat.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox_stringreverse.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, DemoControl.SettingPipe.SerialPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox_startwith0.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
			comboBox_dataformat.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox_stringreverse.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
