using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Plugins
{
	public partial class FormPluginsServerSetting : Form
	{
		public FormPluginsServerSetting( List<PluginsServerInfo> serverInfos )
		{
			this.serverInfos = serverInfos;
			InitializeComponent( );
		}

		private void FormPluginsServerSetting_Load( object sender, EventArgs e )
		{

		}

		private void FormPluginsServerSetting_Shown( object sender, EventArgs e )
		{
			if ( this.serverInfos != null )
			{
				HslCommunicationDemo.DemoUtils.DataGridSpecifyRowCount( dataGridView1, this.serverInfos.Count );
				for ( int i = 0; i < this.serverInfos.Count; i++ )
				{
					DataGridViewRow row = dataGridView1.Rows[i];
					row.Cells[0].Value = serverInfos[i].Name;
					row.Cells[1].Value = serverInfos[i].IpAddress;
					row.Cells[2].Value = serverInfos[i].Port;
				}
			}
		}




		private List<PluginsServerInfo> serverInfos;
		public List<PluginsServerInfo> ServerInfoSettings { get; set; }

		private void button1_Click( object sender, EventArgs e )
		{
			List<PluginsServerInfo> list = new List<PluginsServerInfo>( );
			for ( int i = 0; i < this.dataGridView1.RowCount; i++ )
			{
				DataGridViewRow row = this.dataGridView1.Rows[i];
				if (row.IsNewRow) continue;

				try
				{
					PluginsServerInfo serverInfo = new PluginsServerInfo( );
					serverInfo.Name = row.Cells[0].Value?.ToString( );
					serverInfo.IpAddress = row.Cells[1].Value?.ToString( ).Trim( );
					serverInfo.Port = Convert.ToInt32( row.Cells[2].Value );


					if (string.IsNullOrEmpty( serverInfo.Name ) ) serverInfo.Name = serverInfo.IpAddress;
					list.Add( serverInfo );
				}
				catch (Exception ex)
				{
					MessageBox.Show( "端口号输入异常，请重新输入" );
					return;
				}
			}

			if (list.Count == 0)
			{
				MessageBox.Show( "当前没有输入任何数据" );
			}
			else
			{
				this.ServerInfoSettings = list;
				DialogResult = DialogResult.OK;
			}

		}
	}
}
