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
	public partial class AddressExampleControl : UserControl
	{
		public AddressExampleControl( )
		{
			InitializeComponent( );

			if (emptyImage == null)
			{
				emptyImage = new Bitmap( 16, 16 );
				Graphics g = Graphics.FromImage( emptyImage );
				g.Clear( Color.Transparent );
				g.Dispose( );
			}
			copyAddressToolStripMenuItem.Click += CopyAddressToolStripMenuItem_Click;
		}

		private void RequestAddressExampleControl_Load( object sender, EventArgs e )
		{
			DataGridView1_SizeChanged( sender, e );
			dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;
			dataGridView1.SizeChanged += DataGridView1_SizeChanged;

			if (Program.Language == 2)
			{
				dataGridView1.Columns[0].HeaderText = "Address Example";
				dataGridView1.Columns[1].HeaderText = "Address Meaning";
				dataGridView1.Columns[2].HeaderText = "Bit";
				dataGridView1.Columns[3].HeaderText = "Word";
				dataGridView1.Columns[4].HeaderText = "Special instructions";
			}
			else
			{
				copyAddressToolStripMenuItem.Text = "复制地址文本";
			}

		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 150;
			dataGridView1.Columns[1].Width = 185;
			dataGridView1.Columns[2].Width = 35;
			dataGridView1.Columns[3].Width = 35;
			if (dataGridView1.Width - 405 - 20 > 30)
				dataGridView1.Columns[4].Width = dataGridView1.Width - 405 - 20;
			else
				dataGridView1.Columns[4].Width = 30;
		}

		private void DataGridView1_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			if(e.RowIndex >= 0)
			{
				if(dataGridView1.Rows[e.RowIndex].Tag is DeviceAddressExample example)
				{
					OnDataGridViewRowMouseDoubleClick?.Invoke( example );
				}
			}
		}

		public delegate void OnDataGridViewRowMouseDoubleClickDelegate( DeviceAddressExample addressExample );

		/// <summary>
		/// 当用户双击了地址的某一行之后触发的事件
		/// </summary>
		public event OnDataGridViewRowMouseDoubleClickDelegate OnDataGridViewRowMouseDoubleClick;

		/// <summary>
		/// 设置当前的示例地址
		/// </summary>
		/// <param name="addressExamples">示例的地址信息</param>
		public void SetAddressExample( DeviceAddressExample[] addressExamples )
		{
			if (addressExamples == null) addressExamples = new DeviceAddressExample[0];

			DataGridSpecifyRowCount( dataGridView1, addressExamples.Length );
			for (int i = 0; i < addressExamples.Length; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = addressExamples[i].AddressExample;
				if (!addressExamples[i].IsHeader)
				{
					if (string.IsNullOrEmpty( addressExamples[i].Unit ))
						dataGridView1.Rows[i].Cells[1].Value = addressExamples[i].AddressType;
					else
						dataGridView1.Rows[i].Cells[1].Value = $"{addressExamples[i].AddressType}({addressExamples[i].Unit})";

					dataGridView1.Rows[i].Cells[2].Value = addressExamples[i].BitEnable ? "√" : " ";
					dataGridView1.Rows[i].Cells[3].Value = addressExamples[i].WordEnable ? "√" : " ";
					dataGridView1.Rows[i].Cells[4].Value = addressExamples[i].Mark;
					dataGridView1.Rows[i].Tag = addressExamples[i];
				}
				else
				{
					//dataGridView1.Rows[i].Cells[2].Value = "";
					//dataGridView1.Rows[i].Cells[3].Value = "";
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb( 160, 160, 160 );//Color.FromArgb(0xff, 0xa5, 0x50);
					dataGridView1.Rows[i].Cells[0].Style.Font = new Font( this.Font, FontStyle.Bold );
				}
			}

			if (dataGridView1.RowCount > 0 && dataGridView1.SelectedRows.Count > 0)
			{
				dataGridView1.SelectedRows[0].Selected = false;
			}
		}



		/// <summary>
		/// 将 <see cref="DataGridView"/> 的行数控制在指定的行数
		/// </summary>
		/// <param name="dataGridView1">图标控件</param>
		/// <param name="row">指定的行数信息</param>
		public static void DataGridSpecifyRowCount( DataGridView dataGridView1, int row )
		{
			if (dataGridView1.AllowUserToAddRows)
			{
				row++;
			}
			if (dataGridView1.RowCount < row)
			{
				// 扩充
				dataGridView1.Rows.Add( row - dataGridView1.RowCount );
			}
			else if (dataGridView1.RowCount > row)
			{
				int deleteRows = dataGridView1.RowCount - row;
				for (int i = 0; i < deleteRows; i++)
				{
					dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
				}
			}
			if (row > 0)
			{
				dataGridView1.Rows[0].Cells[0].Selected = false;
			}
		}

		private static Bitmap emptyImage = null;

		private void dataGridView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuStrip1.Show( dataGridView1, e.Location );
			}
		}

		private void CopyAddressToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
				{
					Clipboard.SetText( dataGridView1.SelectedRows[0].Cells[0].Value.ToString( ) );
				}
			}
		}

	}
}
