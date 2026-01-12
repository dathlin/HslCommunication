using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormRunDeviceAndDataSelect : Form
	{
		public FormRunDeviceAndDataSelect( )
		{
			InitializeComponent( );
		}

		private void FormRunDeviceSelect_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "For the current list of connected devices, select the rows that need to be set";
				button1.Text = "OK";
			}

			comboBox_dataType.DataSource = data_types.ToArray( );
			comboBox_dataType.SelectedIndex = 2;
		}

		private void FormRunDeviceSelect_Shown( object sender, EventArgs e )
		{
			// 加载设备列表
			DemoDevice.LoadDevice( dataGridView1 );
		}

		private List<string> data_types = new List<string>( ) { "bool", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "string_ascii", "string_unicode", "string_gb2312", "string_utf8" };


		private void button1_Click( object sender, EventArgs e )
		{
			if(string.IsNullOrEmpty( textBox_address.Text ))
			{
				MessageBox.Show( "Address can not be null!" );
				return;
			}

			if (!int.TryParse( textBox_length.Text, out int length ))
			{
				if (!string.IsNullOrEmpty( textBox_length.Text ))
				{
					MessageBox.Show( "Length input is invalid!" );
					return;
				}
			}

			if (dataGridView1.SelectedRows.Count > 0)
			{
				SelectedDevice = dataGridView1.SelectedRows[0].Tag as DemoDeviceItem;

				DeviceAddressItem = new DemoDeviceAddressItem( )
				{
					Address = textBox_address.Text,
					DataType = comboBox_dataType.SelectedItem.ToString( ),
					Name = textBox_name.Text,
					Length = string.IsNullOrEmpty( textBox_length.Text ) ? -1 : int.Parse( textBox_length.Text ),
				};


				this.DialogResult = DialogResult.OK;
				this.Close( );
			}
			else
			{
				MessageBox.Show( "Please select a device first!" );
			}
		}

		public DemoDeviceItem SelectedDevice { get; set; }

		public DemoDeviceAddressItem DeviceAddressItem { get; set; }

	}
}
