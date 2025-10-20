using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.AllenBrandly
{
	public partial class AllenBrandlyTagTypeCacheControl : UserControl
	{
		public AllenBrandlyTagTypeCacheControl( )
		{
			InitializeComponent( );
		}



		public void SetDevice( HslCommunication.Profinet.AllenBradley.AllenBradleyNet allenBradley )
		{
			this.ab = allenBradley;
		}






		private HslCommunication.Profinet.AllenBradley.AllenBradleyNet ab = null;

		private void button1_Click( object sender, EventArgs e )
		{
			if (ab == null) return;
			Dictionary<string, int> tags = ab.TagValueAndDataBits;
			if (tags == null)
			{
				DemoUtils.DataGridSpecifyRowCount( dataGridView1, 0 );
				return;
			}

			DemoUtils.DataGridSpecifyRowCount( dataGridView1, tags.Count );
			int i = 0;
			foreach ( var item in tags )
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				row.Cells[0].Value = (i + 1);
				row.Cells[1].Value = item.Key;
				row.Cells[2].Value = item.Value;
				i++;
			}	
		}

		private void AllenBrandlyTagTypeCacheControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "Cached tagName and data byte length when writing a bool value to the address i=xxx[2]";
			}
		}
	}
}
