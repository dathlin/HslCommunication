using DynamicExpresso;
using HslCommunication;
using HslCommunication.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class DataSimulateControl : UserControl
	{
		public DataSimulateControl( )
		{
			InitializeComponent( );

			button_start.Click += Button_start_Click;
			button_finish.Click += Button_finish_Click;

			dataGridView1.SizeChanged += DataGridView1_SizeChanged;
			button_finish.Enabled = false;

			toClipToolStripMenuItem.Click += ToClipToolStripMenuItem_Click;
			fromClipToolStripMenuItem.Click += FromClipToolStripMenuItem_Click;
			toFileToolStripMenuItem.Click +=ToFileToolStripMenuItem_Click;
			fromFileToolStripMenuItem.Click += FromFileToolStripMenuItem_Click;
			rowDeleteToolStripMenuItem.Click += RowDeleteToolStripMenuItem_Click;
		}

		private void RowDeleteToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if (this.dataGridView1.SelectedRows.Count > 0)
			{
				StringBuilder deleteRows = new StringBuilder( );
				List<DataGridViewRow> rows = new List<DataGridViewRow>( );
				for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
				{
					deleteRows.Append( $"\"{this.dataGridView1.SelectedRows[i].Cells[1].Value}\"" );
					deleteRows.Append( "," );
					rows.Add( this.dataGridView1.SelectedRows[i] );
				}

				string msg = "是否删除设备地址为: " + deleteRows.ToString( ) + " 所有的行，共计 " + rows.Count + " 行";
				if (Program.Language == 2) msg = "Delete Address: " + deleteRows.ToString( ) + " all lines，total: " + rows.Count + " line";
				if (MessageBox.Show( msg, "Delete Check", MessageBoxButtons.YesNo ) == DialogResult.Yes)
				{
					// 确认删除这些行
					for (int i = 0; i < rows.Count; i++)
					{
						if (rows[i].IsNewRow == false) dataGridView1.Rows.Remove( rows[i] );
					}
				}
			}
			else
			{
				// 就删除某一行
				if (dataGridView1.SelectedCells.Count > 0)
				{
					DataGridViewCell cell = dataGridView1.SelectedCells[0];
					if (dataGridView1.Rows[cell.RowIndex].IsNewRow == true) return;

					string msg = $"是否删除设备地址为: {dataGridView1.Rows[cell.RowIndex].Cells[1].Value} 的行";
					if (Program.Language == 2) msg = $"Delete Address: {dataGridView1.Rows[cell.RowIndex].Cells[1].Value} line?";
					if (MessageBox.Show( msg, "Delete Check", MessageBoxButtons.YesNo ) == DialogResult.Yes)
					{
						// 确认删除这些行
						dataGridView1.Rows.Remove( dataGridView1.Rows[cell.RowIndex] );
					}
				}
			}
		}

		private void FromFileToolStripMenuItem_Click( object sender, EventArgs e )
		{
			try
			{
				using (OpenFileDialog ofd = new OpenFileDialog( ))
				{
					ofd.Filter = "*XML|*.xml";
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						try
						{
							XElement element = XElement.Parse( File.ReadAllText( ofd.FileName, Encoding.UTF8 ) );
							LoadSimulateTable( element );
						}
						catch (Exception ex)
						{
							DemoUtils.ShowMessage( "Load failed: " + ex.Message );
						}
					}
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Load failed: " + ex.Message );
			}
		}

		private void ToFileToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using (SaveFileDialog sfd = new SaveFileDialog( ))
			{
				sfd.Filter = "*XML|*.xml";
				if (sfd.ShowDialog( ) == DialogResult.OK)
				{
					XElement element = new XElement( "SimulateTable" );
					GetSimulateTable( element );

					element.Save( sfd.FileName );
					DemoUtils.ShowMessage( "Save success!" );
				}
			}
		}



		private void FromClipToolStripMenuItem_Click( object sender, EventArgs e )
		{
			try
			{
				XElement element = XElement.Parse( Clipboard.GetText( ) );
				LoadSimulateTable( element );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Load failed: " + ex.Message );
			}
		}

		private void ToClipToolStripMenuItem_Click( object sender, EventArgs e )
		{
			XElement element = new XElement( "SimulateTable" );
			GetSimulateTable( element );
			Clipboard.SetText( element.ToString( ) );
			DemoUtils.ShowMessage( "Save success!" );
		}


		private void DataSimulateControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				dataGridView1.Columns[0].HeaderText = "Name";
				dataGridView1.Columns[1].HeaderText = "Address";
				dataGridView1.Columns[2].HeaderText = "Time(ms)";
				dataGridView1.Columns[3].HeaderText = "Expression";
				dataGridView1.Columns[4].HeaderText = "CurrentValue";
				dataGridView1.Columns[5].HeaderText = "Mark";

				button_start.Text = "Start";
				button_finish.Text = "Stop";
				button_onece.Text = "Once";
				label1.Text = "Right-click the to delete, import, export";
				linkLabel1.Text = "Expression Example";
			}
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 120;
			dataGridView1.Columns[1].Width = 120;
			dataGridView1.Columns[2].Width = 100;
			dataGridView1.Columns[3].Width = 280;
			dataGridView1.Columns[4].Width = (dataGridView1.Width - 620 - 62) / 2;
			dataGridView1.Columns[5].Width = (dataGridView1.Width - 620 - 62) / 2;
		}

		public void SetReadWriteNet( IReadWriteNet readwtite ){
			this.readWrite = readwtite;

			DataGridView1_SizeChanged( null, EventArgs.Empty );
		}

		private List<SimulateWrite> writes = new List<SimulateWrite>( );
		private Thread threadWrite;
		private IReadWriteNet readWrite;
		private bool threadEnable = true;

		private void Button_start_Click( object sender, EventArgs e )
		{
			if (readWrite == null) return;

			List<SimulateWrite> tmp = new List<SimulateWrite>( );
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];

				if (dgvr.Cells[1].Value == null) continue;
				if (dgvr.IsNewRow) continue;

				try
				{
					SimulateWrite dataTableItem = GetSimulateWrite( dgvr );
					dataTableItem.Script = new DynamicExpresso.Interpreter( );
					dataTableItem.Script.Eval( dataTableItem.Express, new Parameter( "x", 0 ), new Parameter( "r", HslCommunication.Core.HslHelper.HslRandom ) );
					dataTableItem.Dgvr = dgvr;
					dataTableItem.ExecuteTime = DateTime.Now.AddDays( -1 );
					tmp.Add( dataTableItem );
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage( $"Row[{i}] has wrong value: " + ex.Message );
					return;
				}
			}

			threadWrite?.Abort( );
			writes = tmp;
			threadEnable = true;
			threadWrite = new Thread( new ThreadStart( ThreadWriteMethod ) );
			threadWrite.IsBackground = true;
			threadWrite.Start( );
			button_start.Enabled = false;
			button_finish.Enabled = true;
		}
		private void Button_finish_Click( object sender, EventArgs e )
		{
			//threadWrite?.Abort( );
			threadEnable = false;
			button_start.Enabled = true;
			button_finish.Enabled = false;
			ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolCheckState ), 123 );
		}

		public void Close( )
		{
			if (threadEnable)
			{
				Button_finish_Click( button_finish, EventArgs.Empty );
			}
		}

		private void ThreadPoolCheckState( object obj )
		{
			Thread.Sleep( 200 );
			if (threadWrite != null && threadEnable == false && threadWrite.ThreadState == ThreadState.Running) threadWrite?.Abort( );
		}

		private void RunOnce()
		{

		}

		private void ThreadWriteMethod()
		{
			while(threadEnable)
			{
				HslCommunication.Core.HslHelper.ThreadSleep( 20 );

				for (int i = 0; i < writes.Count; i++)
				{
					if (threadEnable == false) return;

					SimulateWrite simulate = writes[i];
					if ((DateTime.Now - simulate.ExecuteTime).TotalMilliseconds > simulate.Time)
					{
						List<Parameter> parameters = new List<Parameter>( );
						parameters.Add( new Parameter( "x", simulate.X ) );
						parameters.Add( new Parameter( "r", HslCommunication.Core.HslHelper.HslRandom ) );
						object value = simulate.Script.Eval( simulate.Express, parameters.ToArray( ) );
						if (value == null) continue;
						Type type = value.GetType( );

						OperateResult writeResult = null;
						if (type == typeof( bool )) writeResult = readWrite.Write( simulate.Address, (bool)value );
						else if (type == typeof( bool[] )) writeResult = readWrite.Write( simulate.Address, (bool[])value );
						else if (type == typeof( short )) writeResult = readWrite.Write( simulate.Address, (short)value );
						else if (type == typeof( short[] )) writeResult = readWrite.Write( simulate.Address, (short[])value );
						else if (type == typeof( byte )) writeResult = readWrite.Write( simulate.Address, new byte[] { (byte)value } );
						else if (type == typeof( byte[] )) writeResult = readWrite.Write( simulate.Address, (byte[])value );
						else if (type == typeof( int )) writeResult = readWrite.Write( simulate.Address, (int)value );
						else if (type == typeof( int[] )) writeResult = readWrite.Write( simulate.Address, (int[])value );
						else if (type == typeof( long )) writeResult = readWrite.Write( simulate.Address, (long)value );
						else if (type == typeof( long[] )) writeResult = readWrite.Write( simulate.Address, (long[])value );
						else if (type == typeof( float )) writeResult = readWrite.Write( simulate.Address, (float)value );
						else if (type == typeof( float[] )) writeResult = readWrite.Write( simulate.Address, (float[])value );
						else if (type == typeof( double )) writeResult = readWrite.Write( simulate.Address, (double)value );
						else if (type == typeof( double[] )) writeResult = readWrite.Write( simulate.Address, (double[])value );
						else if (type == typeof( string )) writeResult = readWrite.Write( simulate.Address, (string)value );
						else
						{
							Invoke( new Action( ( ) =>
							{
								DemoUtils.ShowMessage( $"Write address[{simulate.Address}] failed, type[{type.Name}] is not supported" );
							} ) );
							return;
						}
						if (threadEnable == false) return;
						try
						{
							Invoke( new Action( ( ) =>
							{
								simulate.Dgvr.Cells[4].Value = value;
							} ) );
						}
						catch (System.InvalidOperationException)
						{
							return;
						}

						if (writeResult.IsSuccess)
						{

						}
						else
						{
							Invoke( new Action( ( ) =>
							{
								DemoUtils.ShowMessage( $"Write address[{simulate.Address}] failed: {writeResult.Message}" );
								simulate.Dgvr.Cells[1].Selected = true;
							} ) );
							return;
						}
						simulate.ExecuteTime = DateTime.Now;
						simulate.X++;

					}
				}
			}
		}

		private void button_onece_Click( object sender, EventArgs e )
		{
			if (readWrite == null) return;

			List<SimulateWrite> tmp = new List<SimulateWrite>( );
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];

				if (dgvr.Cells[1].Value == null) continue;
				if (dgvr.IsNewRow) continue;

				try
				{
					SimulateWrite dataTableItem = GetSimulateWrite( dgvr );
					dataTableItem.Script = new DynamicExpresso.Interpreter( );
					dataTableItem.Script.Eval( dataTableItem.Express, new Parameter( "x", 0 ), new Parameter( "r", HslCommunication.Core.HslHelper.HslRandom ) );
					dataTableItem.Dgvr = dgvr;
					dataTableItem.ExecuteTime = DateTime.Now.AddDays( -1 );
					tmp.Add( dataTableItem );
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage( $"Row[{i}] has wrong value: " + ex.Message );
					return;
				}
			}

			DateTime dateTime = DateTime.Now;
			for (int i = 0; i < tmp.Count; i++)
			{
				SimulateWrite simulate = tmp[i];
				if ((DateTime.Now - simulate.ExecuteTime).TotalMilliseconds > simulate.Time)
				{
					List<Parameter> parameters = new List<Parameter>( );
					parameters.Add( new Parameter( "x", simulate.X ) );
					parameters.Add( new Parameter( "r", HslCommunication.Core.HslHelper.HslRandom ) );
					object value = simulate.Script.Eval( simulate.Express, parameters.ToArray( ) );
					if (value == null) continue;
					Type type = value.GetType( );

					OperateResult writeResult = null;
					if (type == typeof( bool )) writeResult = readWrite.Write( simulate.Address, (bool)value );
					else if (type == typeof( bool[] )) writeResult = readWrite.Write( simulate.Address, (bool[])value );
					else if (type == typeof( short )) writeResult = readWrite.Write( simulate.Address, (short)value );
					else if (type == typeof( short[] )) writeResult = readWrite.Write( simulate.Address, (short[])value );
					else if (type == typeof( byte )) writeResult = readWrite.Write( simulate.Address, new byte[] { (byte)value } );
					else if (type == typeof( byte[] )) writeResult = readWrite.Write( simulate.Address, (byte[])value );
					else if (type == typeof( int )) writeResult = readWrite.Write( simulate.Address, (int)value );
					else if (type == typeof( int[] )) writeResult = readWrite.Write( simulate.Address, (int[])value );
					else if (type == typeof( long )) writeResult = readWrite.Write( simulate.Address, (long)value );
					else if (type == typeof( long[] )) writeResult = readWrite.Write( simulate.Address, (long[])value );
					else if (type == typeof( float )) writeResult = readWrite.Write( simulate.Address, (float)value );
					else if (type == typeof( float[] )) writeResult = readWrite.Write( simulate.Address, (float[])value );
					else if (type == typeof( double )) writeResult = readWrite.Write( simulate.Address, (double)value );
					else if (type == typeof( double[] )) writeResult = readWrite.Write( simulate.Address, (double[])value );
					else if (type == typeof( string )) writeResult = readWrite.Write( simulate.Address, (string)value );
					else
					{
						DemoUtils.ShowMessage( $"Write address[{simulate.Address}] failed, type[{type.Name}] is not supported" );
						return;
					}

					try
					{
						simulate.Dgvr.Cells[4].Value = value;
					}
					catch (System.InvalidOperationException)
					{
						return;
					}

					if (writeResult.IsSuccess)
					{
						simulate.ExecuteTime = DateTime.Now;
						simulate.X++;
					}
					else
					{
						DemoUtils.ShowMessage( $"Write address[{simulate.Address}] failed: {writeResult.Message}" );
						simulate.Dgvr.Cells[1].Selected = true;
						return;
					}
				}
			}

			DemoUtils.ShowMessage( "Write all address success! timecost : " + (DateTime.Now - dateTime).TotalMilliseconds.ToString( "F0" ) + " ms" );
		}

		public SimulateWrite GetSimulateWrite( DataGridViewRow dgvr )
		{
			SimulateWrite simulateWrite = new SimulateWrite( );
			simulateWrite.Name = dgvr.Cells[0].Value?.ToString( );
			simulateWrite.Address = dgvr.Cells[1].Value?.ToString( );
			simulateWrite.Time = int.Parse( dgvr.Cells[2].Value?.ToString( ) );
			simulateWrite.Express = dgvr.Cells[3].Value?.ToString( );
			simulateWrite.Mark = dgvr.Cells[5].Value?.ToString( );
			return simulateWrite;
		}

		public void GetSimulateTable( XElement element )
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];

				if (dgvr.Cells[1].Value == null) continue;
				if (dgvr.IsNewRow) continue;

				SimulateWrite dataTableItem = GetSimulateWrite( dgvr );
				element.Add( dataTableItem.ToXmlElement( ) );
			}
		}

		public int LoadSimulateTable( XElement element )
		{
			int count = 0;
			foreach (var item in element.Elements( nameof( SimulateWrite ) ))
			{
				SimulateWrite dataTableItem = new SimulateWrite( );
				dataTableItem.LoadByXmlElement( item );

				int rowIndex = dataGridView1.Rows.Add( );
				DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];

				dgvr.Cells[0].Value = dataTableItem.Name;
				dgvr.Cells[1].Value = dataTableItem.Address;
				dgvr.Cells[2].Value = dataTableItem.Time.ToString( );
				dgvr.Cells[3].Value = dataTableItem.Express;
				dgvr.Cells[5].Value = dataTableItem.Mark;
				dgvr.Tag = dataTableItem;
				count++;
			}
			return count;
		}

		private void linkLabel1_Click( object sender, EventArgs e )
		{
			FormExpressionExample form = new FormExpressionExample( );
			form.StartPosition = FormStartPosition.CenterParent;
			form.ShowDialog( this );
			form.Dispose( );
		}

		private void dataGridView1_CellMouseClick( object sender, DataGridViewCellMouseEventArgs e )
		{
		}
	}

	public class SimulateWrite
	{
		public string Name { get; set; }

		public string Address{ get; set; }

		public int Time { get; set; } = 100;

		public string Express{ get; set; }

		public string Mark{ get; set; }

		public DynamicExpresso.Interpreter Script{ get; set; }

		public long X { get; set; }

		public DateTime ExecuteTime { get; set; } = DateTime.Now;

		public DataGridViewRow Dgvr{ get; set; }



		public XElement ToXmlElement( )
		{
			XElement element = new XElement( nameof( SimulateWrite ) );
			element.SetAttributeValue( nameof( Name ), Name );
			element.SetAttributeValue( nameof( Address ), Address );
			element.SetAttributeValue( nameof( Time ), Time );
			element.SetAttributeValue( nameof( Express ), Express );
			element.SetAttributeValue( nameof( Mark ), Mark );
			return element;
		}

		public void LoadByXmlElement( XElement element )
		{
			this.Name    = DataTableItem.GetXmlValue( element, nameof( Name ),    Name,     m => m );
			this.Address = DataTableItem.GetXmlValue( element, nameof( Address ), Address,  m => m );
			this.Time    = DataTableItem.GetXmlValue( element, nameof( Time ),    Time,     int.Parse );
			this.Express = DataTableItem.GetXmlValue( element, nameof( Express ), Express,  m => m );
			this.Mark    = DataTableItem.GetXmlValue( element, nameof( Mark ),    Mark, m => m );
		}

	}
}
