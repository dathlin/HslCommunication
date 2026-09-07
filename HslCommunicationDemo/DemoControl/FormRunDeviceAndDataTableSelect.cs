using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormRunDeviceAndDataTableSelect : Form
	{
		public FormRunDeviceAndDataTableSelect( )
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

			this.dataTableControl1.SetDataTableRowSelect( ); // 只能选择，不能编辑
		}

		private void FormRunDeviceSelect_Shown( object sender, EventArgs e )
		{
			// 加载设备列表
			DemoDevice.LoadDevice( dataGridView1 );
		}

		private void dataGridView1_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
		{
			if (e.RowIndex >= 0)
			{
				dataGridView1.Rows[e.RowIndex].Selected = true;

				SelectedDevice = dataGridView1.SelectedRows[0].Tag as DemoDeviceItem;
				if (SelectedDevice != null && SelectedDevice.DataTableControl != null) {
					XElement element = new XElement( "DataTable" );
					this.dataTableControl1.ClearAllRows( );
					SelectedDevice.DataTableControl.GetDataTable( element );
					this.dataTableControl1.LoadDataTable( element );
				}
				

				//this.DialogResult = DialogResult.OK;
				//this.Close( );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{

			if (dataGridView1.SelectedRows.Count > 0)
			{
				SelectedDevice = dataGridView1.SelectedRows[0].Tag as DemoDeviceItem;

				DeviceAddressItem = new DemoDeviceAddressItem( )
				{

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
