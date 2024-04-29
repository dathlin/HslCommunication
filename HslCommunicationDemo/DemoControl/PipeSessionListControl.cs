using HslCommunication.Core.Net;
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
	public partial class PipeSessionListControl : UserControl
	{
		public PipeSessionListControl( )
		{
			InitializeComponent( );
		}

		private void PipeSessionListControl_Load( object sender, EventArgs e )
		{
			DataGridView1_SizeChanged( sender, e );
			dataGridView1.SizeChanged += DataGridView1_SizeChanged;

			if (Program.Language == 2)
			{
				dataGridView1.Columns[1].HeaderText = "Pipe Info";
				dataGridView1.Columns[2].HeaderText = "Session ID";
				dataGridView1.Columns[3].HeaderText = "OnlineTime";
				dataGridView1.Columns[4].HeaderText = "ActiveTime";
			}
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 100;
			dataGridView1.Columns[1].Width = 200;
			dataGridView1.Columns[2].Width = 150;
			dataGridView1.Columns[3].Width = 150;
			dataGridView1.Columns[4].Width = 150;
			if (dataGridView1.Width - 550 - 20 > 30)
				dataGridView1.Columns[1].Width = dataGridView1.Width - 550 - 20;
			else
				dataGridView1.Columns[1].Width = 30;
		}

		public void SetPipeSessions( PipeSession[] sessions )
		{
			if (sessions == null) sessions = new PipeSession[0];

			AddressExampleControl.DataGridSpecifyRowCount( dataGridView1, sessions.Length );
			for (int i = 0; i < sessions.Length; i++)
			{
				PipeSession session = sessions[i];
				dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString( );

				dataGridView1.Rows[i].Cells[1].Value = $"{session.Communication})";
				dataGridView1.Rows[i].Cells[2].Value = $"{session.SessionID}";
				dataGridView1.Rows[i].Cells[3].Value = $"{session.OnlineTime}";
				dataGridView1.Rows[i].Cells[4].Value = $"{session.HeartTime}";
				dataGridView1.Rows[i].Tag = session;
			}

			if (dataGridView1.RowCount > 0 && dataGridView1.SelectedRows.Count > 0)
			{
				dataGridView1.SelectedRows[0].Selected = false;
			}
		}
	}
}
