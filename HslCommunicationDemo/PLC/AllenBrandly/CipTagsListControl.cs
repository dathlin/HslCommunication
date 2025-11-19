using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.AllenBradley;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo.PLC.AllenBrandly
{
	public partial class CipTagsListControl : UserControl
	{
		public CipTagsListControl( )
		{
			InitializeComponent( );

			this.SizeChanged += CipTagsListControl_SizeChanged;
		}

		public static string GetTitle( )
		{
			if ( Program.Language == 2 ) return "Cip Tags";
			return "标签列表";
		}

		private void CipTagsListControl_SizeChanged( object sender, EventArgs e )
		{
			if ( this.Width > 500 )
			{
				Column_value.Width = dataGridView1.Width - 450 - 40 - 20;
			}
		}

		public void SetDevice( AllenBradleyServer allenBradleyServer )
		{
			this.allenBradleyServer = allenBradleyServer;
		}


		private void UpdateTagList( )
		{
			if (allenBradleyServer == null) return;
			Dictionary<string, AllenBradleyItemValue> tags = allenBradleyServer.TagValueDict;
			if (tags == null)
			{
				DemoUtils.DataGridSpecifyRowCount( dataGridView1, 0 );
				return;
			}
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, tags.Count );
			int i = 0;
			foreach (var item in tags)
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				row.Cells[0].Value = (i + 1);
				row.Cells[1].Value = item.Key;
				row.Cells[2].Value = item.Value.GetTypeName( );
				if (checkBox1.Checked)
					row.Cells[3].Value = item.Value.Buffer.ToHexString( ' ' );
				row.Tag = item.Value;
				i++;
			}
		}

		private AllenBradleyServer allenBradleyServer = null;

		private void button1_Click( object sender, EventArgs e )
		{
			UpdateTagList( );
		}

		private void CipTagsListControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				button1.Text = "刷新列表";
				Column_id.HeaderText = "序号";
				Column_name.HeaderText = "标签名";
				Column_type.HeaderText = "数据类型";
				Column_value.HeaderText = "数值内容";

				checkBox1.Text = "显示缓存";
			}
			else
			{
				label1.Text = "Internal variables of the virtual server:";
			}
		}
	}
}
