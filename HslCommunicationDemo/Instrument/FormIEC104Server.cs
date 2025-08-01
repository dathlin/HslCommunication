using HslCommunication;
using HslCommunication.Instrument.IEC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Instrument
{
	public partial class FormIEC104Server: HslFormContent
	{
		public FormIEC104Server()
		{
			InitializeComponent();
			DemoUtils.SetPanelAnchor( panel1, panel2 );

			panel2.Enabled = false;

			radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton3.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton4.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton5.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton6.CheckedChanged += RadioButton1_CheckedChanged;

			Column1.ReadOnly = true;
			Column1.Resizable = DataGridViewTriState.False;
			Column8.ReadOnly = true;
			Column8.Resizable = DataGridViewTriState.False;

			dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
		}

		private void ValueCellEndEditHelper<T>( DataGridViewCellEventArgs e, Func<string, T> trans )
		{
			if (e.ColumnIndex == 2)
			{
				try
				{
					T value = trans( dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString( ) );

					dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
					if (dataGridView1.Rows[e.RowIndex].Tag is IecValueObject<T> iecValue)
					{
						iecValue.Value = value;
					}
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage( "Set failed: " + ex.Message );
					// 如果发生了异常，重新设置回去值
					if (dataGridView1.Rows[e.RowIndex].Tag is IecValueObject<T> iecValue)
					{
						dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = iecValue.Value;
					}
				}
			}
		}


		private void DataGridView1_CellEndEdit( object sender, DataGridViewCellEventArgs e )
		{
			if (this.server == null) return;
			else if (radioButton1.Checked) ValueCellEndEditHelper( e, m => byte.Parse(m ) > 0 ? (byte) 1 : (byte)0 );  // 单点遥信
			else if (radioButton2.Checked) ValueCellEndEditHelper( e, m => byte.Parse( m ) );  // 双点遥信
			else if (radioButton3.Checked) ValueCellEndEditHelper( e, m => short.Parse( m ) );  // 归一化
			else if (radioButton4.Checked) ValueCellEndEditHelper( e, m => short.Parse( m ) );  // 标度值
			else if (radioButton5.Checked) ValueCellEndEditHelper( e, m => float.Parse( m ) );  // 标度值
			else if (radioButton6.Checked) ValueCellEndEditHelper( e, m => ParseBitArray( m ) );  // 32比特串
		}

		private uint ParseBitArray( string value )
		{
			if (value.Length != 32) throw new ArgumentException( "must be 32 of '0' or '1'" );
			bool[] array = new bool[32];
			for ( int i = 0; i < value.Length; i++ )
			{
				array[i] = value[i] != '0';
			}
			return BitConverter.ToUInt32( array.ToByteArray( ), 0 );
		}

		private void RadioButton1_CheckedChanged( object sender, EventArgs e )
		{
			if (server != null)
			{
				if (radioButton1.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.SingleYaoXin.Values );
				else if (radioButton2.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.DoubleYaoXin.Values );
				else if (radioButton3.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.YaoCeA.Values );
				else if (radioButton4.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.YaoCeB.Values );
				else if (radioButton5.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.YaoCeC.Values );
				else if (radioButton6.Checked) FormIEC104.RenderDataGridView( dataGridView1, server.BitArray.Values, FormIEC104.GetBoolArrayValue );
			}
		}


		private void FormIEC104Server_Load( object sender, EventArgs e )
		{
			dataGridView1.RowHeadersWidth = 70;
		}

		private IEC104Server server;

		private void FormIEC104Server_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button11_Click( null, EventArgs.Empty );
		}
		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse(textBox3.Text, out int port))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}
			try
			{
				server = new IEC104Server( ); 
				this.sslServerControl1.InitializeServer( server );
				server.ServerStart( port );
				server.LogNet = this.LogNet;

				panel2.Enabled = true;
				button1.Enabled = false;
				button11.Enabled = true;


				RadioButton1_CheckedChanged( null, EventArgs.Empty );

				DemoUtils.ShowMessage( "Start Success" );
			}
			catch( Exception ex )
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			server.CloseSerialSlave( );
			server.ServerClose( );

			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 上下布局
			this.splitContainer1.Orientation = Orientation.Horizontal;
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 左右布局
			this.splitContainer1.Orientation = Orientation.Vertical;
		}

	}
}
