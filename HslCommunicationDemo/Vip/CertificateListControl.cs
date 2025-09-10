using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Vip
{
	public partial class CertificateListControl : UserControl
	{
		public CertificateListControl( )
		{
			InitializeComponent( );
		}



		private void RenderCertificateListHelper( List<CertificateItem> certificates )
		{
			if (certificates == null)
			{
				HslCommunicationDemo.DemoUtils.DataGridSpecifyRowCount( dataGridView1, 0 );
				return;
			}

			HslCommunicationDemo.DemoUtils.DataGridSpecifyRowCount( dataGridView1, certificates.Count );

			
			for (int i = 0; i < certificates.Count; i++)
			{
				CertificateItem item = certificates[i];
				dataGridView1.Rows[i].Cells[0].Value = item.Certificate.To;
				dataGridView1.Rows[i].Cells[1].Value = item.Certificate.NotBefore.ToString( "yyyy-MM-dd" );
				dataGridView1.Rows[i].Cells[2].Value = item.Certificate.NotAfter.ToString( "yyyy-MM-dd" );
				dataGridView1.Rows[i].Cells[3].Value = item.Certificate.CreateTime.ToString( "yyyy-MM-dd" );
				dataGridView1.Rows[i].Cells[4].Value = item.Certificate.EffectiveHours;
				dataGridView1.Rows[i].Cells[5].Value = item.Certificate.UniqueID;

				if (item.Certificate.NotAfter < DateTime.Now)
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;
				else if ((item.Certificate.NotAfter - DateTime.Now).TotalDays <= 7)
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
				else if ((item.Certificate.NotAfter - DateTime.Now).TotalDays <= 30)
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
				else
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = dataGridView1.RowsDefaultCellStyle.BackColor;
				dataGridView1.Rows[i].Tag = item;
			}
		}

		private void StatisticsCertificate( List<CertificateItem> certificates )
		{
			if (certificates == null) return;
			int valid = 0;
			int expired = 0;
			int willExpire7 = 0;
			int willExpire30 = 0;
			DateTime now = DateTime.Now;
			foreach (var item in certificates)
			{
				valid++;
				if (item.Certificate.NotAfter < now)
					expired++;
				else
				{
					if ((item.Certificate.NotAfter - now).TotalDays <= 7)
						willExpire7++;
					if ((item.Certificate.NotAfter - now).TotalDays <= 30)
						willExpire30++;
				}
			}
			label1.Text = "总计: " + valid.ToString( );
			label2.Text = "过期: " + expired.ToString( );
			label3.Text = "7天内过期: " + willExpire7.ToString( );
			label4.Text = "30天内过期: " + willExpire30.ToString( );
		}


		public void SetCertificates( MqttSyncClient rpc, List<CertificateItem> certificates )
		{
			this.rpc = rpc;
			certificateItems = certificates;
			RenderCertificateListHelper( certificateItems );
			StatisticsCertificate( certificates );
		}



		private List<CertificateItem> certificateItems = new List<CertificateItem>( );
		private MqttSyncClient rpc;

		private void label1_Click( object sender, EventArgs e )
		{
			// 显示全部 
			RenderCertificateListHelper( certificateItems );
		}

		private void label2_Click( object sender, EventArgs e )
		{
			// 显示过期
			RenderCertificateListHelper(certificateItems.Where( m => m.Certificate.NotAfter < DateTime.Now ).ToList( ));
		}

		private void label3_Click( object sender, EventArgs e )
		{
			// 显示7天内过期
			RenderCertificateListHelper( certificateItems.Where( m => m.Certificate.NotAfter < DateTime.Now.AddDays( 7 ) ).ToList( ) );
		}

		private void label4_Click( object sender, EventArgs e )
		{
			// 显示30天内过期
			RenderCertificateListHelper( certificateItems.Where( m => m.Certificate.NotAfter < DateTime.Now.AddDays( 30 ) ).ToList( ) );
		}

		private void dataGridView1_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			if (e.RowIndex < 0) return;
			if (dataGridView1.Rows[e.RowIndex].Tag is CertificateItem item)
			{
				FormHslCertificate form = new FormHslCertificate( rpc, item );
				form.StartPosition = FormStartPosition.CenterParent;
				form.ShowDialog( );
			}
		}

		private void CertificateListControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				dataGridView1.Columns[0].HeaderText = "To";
				dataGridView1.Columns[1].HeaderText = "Not Before";
				dataGridView1.Columns[2].HeaderText = "Not After";
				dataGridView1.Columns[3].HeaderText = "Create Time";
				dataGridView1.Columns[4].HeaderText = "Effective Hours";
				dataGridView1.Columns[5].HeaderText = "Unique ID";
				label5.Text = "Double click to view";
				button1.Text = "Search";

			}
		}

		private bool SearchCertificate( CertificateItem item, string keyword )
		{
			if (string.IsNullOrEmpty( keyword )) return false;
			return (item.Certificate.To.Contains( keyword ) || item.Certificate.From.Contains( keyword ) || item.Certificate.UniqueID.Contains( keyword ));
		}

		private void button1_Click( object sender, EventArgs e )
		{
			RenderCertificateListHelper( certificateItems.Where( m => SearchCertificate( m, textBox1.Text ) ).ToList( ) );
		}
	}
}
