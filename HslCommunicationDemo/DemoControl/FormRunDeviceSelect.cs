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
	public partial class FormRunDeviceSelect : Form
	{
		public FormRunDeviceSelect( )
		{
			InitializeComponent( );
		}

		private void FormRunDeviceSelect_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "For the current list of connected devices, select the rows that need to be set";
				label2.Text = "Redir API name:";

				button1.Text = "OK";
			}
		}

		private void FormRunDeviceSelect_Shown( object sender, EventArgs e )
		{
			// 加载设备列表
			LoadDevice( );
		}

		private void LoadDevice( )
		{
			List<DemoDeviceItem> devices = DemoDevice.Devices.Values.ToList( );
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, devices.Count );
			for (int i = 0; i < devices.Count; i++)
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				row.Cells[0].Value = (i + 1).ToString( );
				row.Cells[1].Value = devices[i].Guid;
				row.Cells[2].Value = devices[i].Name;
				row.Cells[3].Value = devices[i].Device.ToString( );
				row.Tag = devices[i];
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				SelectedDevice = dataGridView1.SelectedRows[0].Tag as DemoDeviceItem;
				SelectedDevice.ApiName = textBox1.Text;
				this.DialogResult = DialogResult.OK;
				this.Close( );
			}
			else
			{
				MessageBox.Show( "Please select a device first!" );
			}
		}

		public DemoDeviceItem SelectedDevice { get; set; }

		private void dataGridView1_CellClick( object sender, DataGridViewCellEventArgs e )
		{
			if (e.RowIndex < dataGridView1.RowCount)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
				if (row.Tag is DemoDeviceItem item)
				{
					if (string.IsNullOrEmpty( item.Name ))
					{
						string tmp = item.Device.ToString( );
						if (tmp.Contains("<"))
						{
							tmp = tmp.Substring( 0, tmp.IndexOf( "<" ) );
						}

						if (tmp.Contains( "[" ))
						{
							tmp = tmp.Substring( 0, tmp.IndexOf( "[" ) );
						}

						textBox1.Text = tmp;
					}
					else
					{
						string tmp = item.Name.Replace( ":", "/" );
						textBox1.Text = tmp;
					}
				}
			}
		}
	}
}
