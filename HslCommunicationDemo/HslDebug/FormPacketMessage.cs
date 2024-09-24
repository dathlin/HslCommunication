using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormPacketMessage : System.Windows.Forms.Form
	{
		public FormPacketMessage( List<PacketMessageItem> list )
		{
			InitializeComponent( );
			packetMessages = list;
		}

		private void FormPacketMessage_Load( object sender, EventArgs e )
		{
			DataGridView1_SizeChanged( sender, e );
			dataGridView1.SizeChanged += DataGridView1_SizeChanged;

			if (Program.Language == 2)
			{
				dataGridView1.Columns[0].HeaderText = "Name";
				dataGridView1.Columns[1].HeaderText = "Message Content";
				dataGridView1.Columns[2].HeaderText = "Decs";
			}

			if (this.packetMessages?.Count > 0)
			{
				SetAddressExample( this.packetMessages );
			}
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 150;
			dataGridView1.Columns[1].Width = dataGridView1.Width - 350 - 20 - 40;
			dataGridView1.Columns[2].Width = 200;
		}


		/// <summary>
		/// 设置当前的示例地址
		/// </summary>
		/// <param name="addressExamples">示例的地址信息</param>
		public void SetAddressExample( List<PacketMessageItem> list )
		{
			if (list == null) list = new List<PacketMessageItem>( );

			AddressExampleControl.DataGridSpecifyRowCount( dataGridView1, list.Count );
			for (int i = 0; i < list.Count; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = list[i].Name;
				dataGridView1.Rows[i].Cells[1].Value = list[i].Message;
				dataGridView1.Rows[i].Cells[2].Value = list[i].Description;
			}
		}

		private PacketMessageItem GetDataTableItem( DataGridViewRow dgvr )
		{
			PacketMessageItem item = new PacketMessageItem( );
			item.Name = dgvr.Cells[0].Value != null ? dgvr.Cells[0].Value.ToString( ) : string.Empty;
			item.Message = dgvr.Cells[1].Value != null ? dgvr.Cells[1].Value.ToString( ) : string.Empty;
			item.Description = dgvr.Cells[2].Value != null ? dgvr.Cells[2].Value.ToString( ) : string.Empty;
			return item;
		}

		public List<PacketMessageItem> PacketMessages { get; set; }

		private List<PacketMessageItem> packetMessages;

		private void button1_Click( object sender, EventArgs e )
		{
			// 保存按钮
			List<PacketMessageItem> list = new List<PacketMessageItem>( );

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];

				if (dgvr.Cells[1].Value == null) continue;
				if (dgvr.IsNewRow) continue;

				PacketMessageItem item = GetDataTableItem( dgvr );
				list.Add( item );
			}

			PacketMessages = list;
			DialogResult = DialogResult.OK;
		}

	}
}
