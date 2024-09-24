using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Siemens;

namespace HslCommunicationDemo.PLC.Siemens
{
	public partial class SiemensS7WriteControl : UserControl
	{
		public SiemensS7WriteControl( )
		{
			InitializeComponent( );


			dataGridView1.Rows.Add( );
			dataGridView1.Rows[0].Cells[0].Value = "M100";
			dataGridView1.Rows[0].Cells[1].Value = "short";
			dataGridView1.Rows[0].Cells[2].Value = "1";


			this.dataGridView1.SizeChanged += DataGridView1_SizeChanged;
			this.label_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Write( string[] address, List<byte[]> data );";
		}

		private void SiemensS7WriteControl_Load( object sender, EventArgs e )
		{
			DataGridView1_SizeChanged( dataGridView1, e );

			if (Program.Language == 2)
			{
				button7.Text = "Single Msg Write";
			}
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 150;
			dataGridView1.Columns[1].Width = 100;

			int width = dataGridView1.Width - 150 - 100 - 20 - 40;

			dataGridView1.Columns[2].Width = width < 100 ? 100 : width;
		}

		public void SetDevice( SiemensS7Net siemensTcpNet, string address )
		{
			this.siemens = siemensTcpNet;
		}

		/**
		 * bool
		 * byte
short
ushort
int
uint
long
ulong
float
double
string
hex
		 * */
		private SiemensS7Net siemens;

		private void button7_Click( object sender, EventArgs e )
		{
			List<string> adds = new List<string>( );
			List<byte[]> buffer = new List<byte[]>( );

			for (int i = 0; i < dataGridView1.RowCount; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];
				if (dgvr.IsNewRow) continue;

				adds.Add( dgvr.Cells[0].Value.ToString( ) );
				if (dgvr.Cells[2].Value != null && dgvr.Cells[1].Value != null)
				{
					string dataType = dgvr.Cells[1].Value.ToString( );
					if (dataType == "byte")
						buffer.Add( dgvr.Cells[2].Value.ToString( ).ToStringArray<byte>( ) );
					else if (dataType == "short")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<short>( ) ) );
					else if (dataType == "ushort")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<ushort>( ) ) );
					else if (dataType == "int")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<int>( ) ) );
					else if (dataType == "uint")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<uint>( ) ) );
					else if (dataType == "long")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<long>( ) ) );
					else if (dataType == "ulong")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<ulong>( ) ) );
					else if (dataType == "float")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<float>( ) ) );
					else if (dataType == "double")
						buffer.Add( siemens.ByteTransform.TransByte( dgvr.Cells[2].Value.ToString( ).ToStringArray<double>( ) ) );
					else if (dataType == "hex")
						buffer.Add( dgvr.Cells[2].Value.ToString( ).ToHexBytes( ) );
				}
				else
				{
					buffer.Add( null );
				}
			}

			OperateResult write = this.siemens.Write( adds.ToArray( ), buffer );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success" );
			}
			else
			{
				MessageBox.Show( "Write failed: " + write.Message );
			}
		}
	}
}
