using HslCommunication;
using HslCommunication.BasicFramework;
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
	public partial class DataTableControl : UserControl
	{
		public DataTableControl( )
		{
			InitializeComponent( );
			button1.Click += Button1_Click;
			this.dataGridView1.SizeChanged += DataGridView1_SizeChanged;
		}

		public void SetReadWriteNet( IReadWriteNet device )
		{
			this.device = device;
		}

		private IReadWriteNet device;

		private void DataTableControl_Load( object sender, EventArgs e )
		{
			DataGridView1_SizeChanged( null, e );

			button1.Text = Program.Language == 1 ? "开始刷新" : "Refresh";

			if (Program.Language == 2)
			{
				Column_name.HeaderText = "Name";
				Column_address.HeaderText = "Address";
				Column_type.HeaderText = "Type";
				Column_encoding.HeaderText = "Coding";
				Column_length.HeaderText = "Len";
				Column_value.HeaderText = "Value";
				Column_unit.HeaderText = "Unit";
				Column_decs.HeaderText = "Description";

				button_from_clip.Text = "FromClip";
				button_from_file.Text = "FromFile";
				button_out_clip.Text = "ToClip";
				button_out_file.Text = "ToFile";
				label1.Text = "Interval";
			}

		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 140 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 15 : 0);
			dataGridView1.Columns[1].Width = 120 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 15 : 0);
			dataGridView1.Columns[2].Width = 80;
			dataGridView1.Columns[3].Width = 80;
			dataGridView1.Columns[4].Width = 60;
			dataGridView1.Columns[5].Width = 160 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 10 : 0);
			dataGridView1.Columns[6].Width = 60;

			int width = 0;
			for (int i = 0; i < 7; i++)
			{
				width += dataGridView1.Columns[i].Width;
			}
			dataGridView1.Columns[7].Width = dataGridView1.Width - width - 20 - 40;
		}

		private DataTableItem GetDataTableItem( DataGridViewRow dgvr )
		{
			DataTableItem dataTableItem = new DataTableItem( );
			dataTableItem.Name = dgvr.Cells[0].Value != null ? dgvr.Cells[0].Value.ToString( ) : string.Empty;
			dataTableItem.Address = dgvr.Cells[1].Value != null ? dgvr.Cells[1].Value.ToString( ) : string.Empty;
			dataTableItem.DataTypeCode = dgvr.Cells[2].Value != null ? dgvr.Cells[2].Value.ToString( ) : string.Empty;
			if (dataTableItem.DataTypeCode == "string")
			{
				if (dgvr.Cells[3].Value != null)
					dataTableItem.StringEncoding = SoftBasic.GetEnumFromString<StringEncoding>( dgvr.Cells[3].Value.ToString( ) );
				else
					dataTableItem.StringEncoding = StringEncoding.ASCII;
			}
			string length_str = dgvr.Cells[4].Value != null ? dgvr.Cells[4].Value.ToString( ) : string.Empty;
			dataTableItem.Length = string.IsNullOrEmpty( length_str ) ? -1 : Convert.ToInt32( length_str );
			dataTableItem.Unit = dgvr.Cells[6].Value != null ? dgvr.Cells[6].Value.ToString( ) : string.Empty;
			dataTableItem.Description = dgvr.Cells[7].Value != null ? dgvr.Cells[7].Value.ToString( ) : string.Empty;
			return dataTableItem;
		}

		public void GetDataTable( XElement element )
		{
			element.RemoveNodes( );
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];

				if (dgvr.Cells[2].Value == null) continue;
				if (dgvr.IsNewRow) continue;

				DataTableItem dataTableItem = GetDataTableItem( dgvr );
				element.Add( dataTableItem.ToXmlElement( ) );
			}
		}

		public int LoadDataTable( XElement element )
		{
			int count = 0;
			foreach (var item in element.Elements())
			{
				if (item.Name == nameof( DataTableItem ))
				{
					DataTableItem dataTableItem = new DataTableItem( );
					dataTableItem.LoadByXmlElement( item );

					int rowIndex = dataGridView1.Rows.Add( );
					DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];

					dgvr.Cells[0].Value = dataTableItem.Name;
					dgvr.Cells[1].Value = dataTableItem.Address;
					if (!string.IsNullOrEmpty( dataTableItem.DataTypeCode ))
					{
						dgvr.Cells[2].Value = dataTableItem.DataTypeCode;
						if (dataTableItem.DataTypeCode == "string")
						{
							dgvr.Cells[3].Value = dataTableItem.StringEncoding.ToString( );
						}
					}
					if (dataTableItem.Length >=0)
					{
						dgvr.Cells[4].Value = dataTableItem.Length.ToString( );
					}
					dgvr.Cells[6].Value = dataTableItem.Unit;
					dgvr.Cells[7].Value = dataTableItem.Description;

					count++;
				}
			}
			return count;
		}

		private Thread threadRead;
		private bool threadEnable = false;
		private int timeSleep = 1000;

		private void Button1_Click( object sender, EventArgs e )
		{
			if (device == null)
			{
				MessageBox.Show( "ReadWriteNet device is null, can not refresh! " );
				return;
			}

			if (!threadEnable)
			{
				// 启动刷新的操作
				threadEnable = true;
				button1.Text = Program.Language == 1 ? "停止刷新" : "Stop";
				button1.BackColor = Color.LimeGreen;
				timeSleep = Convert.ToInt32( textBox_time.Text );
				threadRead = new Thread( new ThreadStart( ThreadBack ) );
				threadRead.IsBackground = true;
				threadRead.Start( );
			}
			else
			{
				// 停止线程
				threadEnable = false;
				button1.Text = Program.Language == 1 ? "开始刷新" : "Refresh";
				button1.BackColor = SystemColors.Control;
			}
		}

		private void ReadByType<T>( DataGridViewRow dgvr, DataTableItem dataTableItem, Func<string, OperateResult<T>> read1, Func<string, ushort, OperateResult<T[]>> read2)
		{
			if (dataTableItem.Length <= 0)
			{
				OperateResult<T> read = read1( dataTableItem.Address );
				Invoke( new Action( ( ) =>
				{
					if (read.IsSuccess)
					{
						dgvr.Cells[5].Value = read.Content.ToString( );
					}
					else
					{
						dgvr.Cells[5].Value = string.Empty;
					}
				} ) );
			}
			else
			{
				OperateResult<T[]> read = read2( dataTableItem.Address, (ushort)dataTableItem.Length );
				Invoke( new Action( ( ) =>
				{
					if (read.IsSuccess)
					{
						dgvr.Cells[5].Value = read.Content.ToArrayString( );
					}
					else
					{
						dgvr.Cells[5].Value = string.Empty;
					}
				} ) );
			}
		}

		private void ThreadBack( )
		{
			while (threadEnable)
			{
				if (dataGridView1.FirstDisplayedCell == null) return;
				int firstRow = dataGridView1.FirstDisplayedCell.RowIndex;
				int rowCount = dataGridView1.DisplayedRowCount( true );
				//Invoke( new Action( ( ) =>
				//{
				//	label_info.Text = $"Stx[{firstRow}] Count[{rowCount}]";
				//} ) );
				for (int i = 0; i < rowCount; i++)
				{
					DataGridViewRow dgvr = dataGridView1.Rows[i + firstRow];
					if (dgvr.IsNewRow) continue;

					DataTableItem dataTableItem = GetDataTableItem( dgvr );
					if      (dataTableItem.DataTypeCode == "bool")   ReadByType( dgvr, dataTableItem, device.ReadBool, device.ReadBool );
					else if (dataTableItem.DataTypeCode == "short")  ReadByType( dgvr, dataTableItem, device.ReadInt16, device.ReadInt16 );
					else if (dataTableItem.DataTypeCode == "ushort") ReadByType( dgvr, dataTableItem, device.ReadUInt16, device.ReadUInt16 );
					else if (dataTableItem.DataTypeCode == "int")    ReadByType( dgvr, dataTableItem, device.ReadInt32, device.ReadInt32 );
					else if (dataTableItem.DataTypeCode == "uint")   ReadByType( dgvr, dataTableItem, device.ReadUInt32, device.ReadUInt32 );
					else if (dataTableItem.DataTypeCode == "long")   ReadByType( dgvr, dataTableItem, device.ReadInt64, device.ReadInt64 );
					else if (dataTableItem.DataTypeCode == "ulong")  ReadByType( dgvr, dataTableItem, device.ReadUInt64, device.ReadUInt64 );
					else if (dataTableItem.DataTypeCode == "float")  ReadByType( dgvr, dataTableItem, device.ReadFloat, device.ReadFloat );
					else if (dataTableItem.DataTypeCode == "double") ReadByType( dgvr, dataTableItem, device.ReadDouble, device.ReadDouble );
					else if (dataTableItem.DataTypeCode == "string")
					{
						int len = dataTableItem.Length < 0 ? 0 : dataTableItem.Length;
						Encoding encoding =
							dataTableItem.StringEncoding == StringEncoding.ASCII ? Encoding.ASCII :
							dataTableItem.StringEncoding == StringEncoding.ANSI ? Encoding.Default :
							dataTableItem.StringEncoding == StringEncoding.UTF16 ? Encoding.Unicode :
							dataTableItem.StringEncoding == StringEncoding.UTF16Big ? Encoding.BigEndianUnicode :
							dataTableItem.StringEncoding == StringEncoding.UTF8 ? Encoding.UTF8 :
							dataTableItem.StringEncoding == StringEncoding.GB2312 ? Encoding.GetEncoding( "gb2312" ) : Encoding.ASCII;
						OperateResult<string> read = device.ReadString( dataTableItem.Address, (ushort)len, encoding );
						Invoke( new Action( ( ) =>
						{
							if (read.IsSuccess)
							{
								dgvr.Cells[5].Value = read.Content;
							}
							else
							{
								dgvr.Cells[5].Value = string.Empty;
							}
						} ) );
					}
					else if (dataTableItem.DataTypeCode == "byte")
					{
						if (dataTableItem.Length <= 0)
						{
							OperateResult<byte[]> read = device.Read( dataTableItem.Address, 1 );
							Invoke( new Action( ( ) =>
							{
								if (read.IsSuccess)
								{
									dgvr.Cells[5].Value = read.Content[0].ToString( );
								}
								else
								{
									dgvr.Cells[5].Value = string.Empty;
								}
							} ) );
						}
						else
						{
							OperateResult<byte[]> read = device.Read( dataTableItem.Address, (ushort)dataTableItem.Length );
							Invoke( new Action( ( ) =>
							{
								if (read.IsSuccess)
								{
									dgvr.Cells[5].Value = read.Content.ToHexString( ' ' );
								}
								else
								{
									dgvr.Cells[5].Value = string.Empty;
								}
							} ) );
						}
					}

				}

				Thread.Sleep( timeSleep );
			}
		}

		private void button_out_clip_Click( object sender, EventArgs e )
		{
			// 导出到clip
			XElement element = new XElement( "DataTable" );
			GetDataTable( element );
			Clipboard.SetText( element.ToString( ) );
			MessageBox.Show( "Save success!" );
		}

		private void button_from_clip_Click( object sender, EventArgs e )
		{
			try
			{
				XElement element = XElement.Parse( Clipboard.GetText( ) );
				LoadDataTable( element );
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Load failed: " + ex.Message );
			}
		}

		private void button_out_file_Click( object sender, EventArgs e )
		{
			using (SaveFileDialog sfd = new SaveFileDialog( ))
			{
				sfd.Filter = "*XML|*.xml";
				if (sfd.ShowDialog( ) == DialogResult.OK)
				{
					XElement element = new XElement( "DataTable" );
					GetDataTable( element );

					element.Save( sfd.FileName );
					MessageBox.Show( "Save success!" );
				}
			}
		}

		private void button_from_file_Click( object sender, EventArgs e )
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
							XElement element = XElement.Parse( File.ReadAllText( ofd.FileName, Encoding.UTF8 ) ) ;
							LoadDataTable( element );
						}
						catch (Exception ex)
						{
							MessageBox.Show( "Load failed: " + ex.Message );
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Load failed: " + ex.Message );
			}
		}
    }
}
