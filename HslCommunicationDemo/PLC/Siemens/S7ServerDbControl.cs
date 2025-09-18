using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.PLC.Siemens
{
	public partial class S7ServerDbControl : UserControl
	{
		public S7ServerDbControl( )
		{
			InitializeComponent( );


			if (Program.Language == 2)
			{
				label1.Text = "Current DB block: (excluding the built-in DB1,DB2, DB3)";
				label6.Text = "Batch add: 100-200";
			}
		}


		public void SetServer( SiemensS7Server s7Server )
		{
			this.s7Server = s7Server;

			if (dataGridView1.RowCount > 0)
			{
				for (int i = 0; i<dataGridView1.RowCount; i++)
				{
					if (dataGridView1.Rows[i].Tag is DbItem dbItem)
					{
						if (dbItem.Size > 0)
							s7Server.AddDbBlock( dbItem.DbNumber, dbItem.Size );
						else
							s7Server.AddDbBlock( dbItem.DbNumber );
					}
				}
			}
		}


		private SiemensS7Server s7Server = null;

		private void button_db_add_Click( object sender, EventArgs e )
		{
			if (int.TryParse( textBox_length.Text, out int dbSize ))
			{
				if (dbSize <= 0)
				{
					MessageBox.Show( "Db Size must be > 0" );
					return;
				}
			}
			else
			{
				MessageBox.Show( "Db Size input wrong" );
				return;
			}

			if (int.TryParse( textBox_db.Text, out int dbNumber ))
			{
				DbItem item = new DbItem( )
				{
					DbNumber = dbNumber,
					Size = dbSize,
					Name = textBox_name.Text,
					Note = textBox_desc.Text
				};
				AddDbBlocks( item );
				label_row_count.Text = "Rows: " + dataGridView1.RowCount.ToString( );
			}
			else if (Regex.IsMatch(textBox_db.Text, "^[0-9]+-[0-9]+$"))
			{
				string[] splits = textBox_db.Text.Split( '-' );
				if (int.TryParse( splits[0], out int dbStart ) && int.TryParse( splits[1], out int dbEnd ))
				{
					if (dbStart >= dbEnd)
					{
						MessageBox.Show( "Db Start must be less than Db End" );
						return;
					}
					for (int i = dbStart; i <= dbEnd; i++)
					{
						DbItem item = new DbItem( )
						{
							DbNumber = i,
							Size = dbSize,
							Name = textBox_name.Text,
							Note = textBox_desc.Text
						};
						AddDbBlocks( item );
					}
					label_row_count.Text = "Rows: " + dataGridView1.RowCount.ToString( );
				}
				else
				{
					MessageBox.Show( "Db Number input wrong" );
				}
			}
			else
			{
				MessageBox.Show( "Db Number input wrong" );
			}
		}

		private void AddDbBlocks( DbItem item )
		{
			if (item == null) return;
			if (string.IsNullOrEmpty( item.Name )) item.Name = $"DB{item.DbNumber}";
			dbItems.Add( item );
			int rowIndex = dataGridView1.Rows.Add( );
			DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];
			SetDgvr( dgvr, rowIndex, item );
			s7Server.AddDbBlock( item.DbNumber, item.Size );
		}

		private void SetDgvr( DataGridViewRow dgvr, int rowIndex, DbItem dbItem )
		{
			dgvr.Cells[0].Value = dbItem.Name;
			dgvr.Cells[1].Value = dbItem.DbNumber.ToString( );
			dgvr.Cells[2].Value = dbItem.Size.ToString( );
			dgvr.Cells[3].Value = dbItem.Note.ToString( );
			dgvr.Tag = dbItem;
		}


		private void button_db_remove_Click( object sender, EventArgs e )
		{
			if (int.TryParse( textBox_db.Text, out int dbNumber ) )
			{
				for (int i = 0; i<dataGridView1.RowCount; i++)
				{
					if (dataGridView1.Rows[i].Tag is DbItem dbItem)
					{
						if (dbItem.DbNumber == dbNumber)
						{
							dataGridView1.Rows.RemoveAt( i );
							s7Server.RemoveDbBlock( dbNumber );
							DemoUtils.ShowMessage( $"Remove DB{dbNumber} Success" );
							label_row_count.Text = "Rows: " + dataGridView1.RowCount.ToString( );
							return;
						}
					}
				}
				DemoUtils.ShowMessage( $"Remove DB{dbNumber} failed: not find db" );
			}
			else if (Regex.IsMatch( textBox_db.Text, "^[0-9]+-[0-9]+$" ))
			{
				string[] splits = textBox_db.Text.Split( '-' );
				if (int.TryParse( splits[0], out int dbStart ) && int.TryParse( splits[1], out int dbEnd ))
				{
					if (dbStart >= dbEnd)
					{
						MessageBox.Show( "Db Start must be less than Db End" );
						return;
					}
					int removeCount = 0;
					for (int i = dbStart; i <= dbEnd; i++)
					{
						for (int j = 0; j < dataGridView1.RowCount; j++)
						{
							if (dataGridView1.Rows[j].Tag is DbItem dbItem)
							{
								if (dbItem.DbNumber == i)
								{
									dataGridView1.Rows.RemoveAt( j );
									s7Server.RemoveDbBlock( i );
									removeCount++;
									break;
								}
							}
						}
					}
					DemoUtils.ShowMessage( $"Remove DB{dbStart}-{dbEnd} Success, Count: {removeCount}" );
					label_row_count.Text = "Rows: " + dataGridView1.RowCount.ToString( );
				}
				else
				{
					MessageBox.Show( "Db Number input wrong" );
				}
			}
			else
			{
				MessageBox.Show( "Db Number input wrong" );
			}
		}


		public void SaveToXElement( XElement element )
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];
				if (dgvr.IsNewRow) continue;

				if (dgvr.Tag is DbItem item)
					element.Add( item.ToXml( ) );
			}
		}

		public int LoadFromXElement( XElement element )
		{
			int count = 0;
			foreach (var item in element.Elements( "DbItem" ))
			{
				DbItem dataTableItem = new DbItem( item );

				int rowIndex = dataGridView1.Rows.Add( );
				DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];

				SetDgvr( dgvr, rowIndex, dataTableItem );
				count++;
			}

			label_row_count.Text = "Rows: " + dataGridView1.RowCount.ToString( );
			return count;
		}

		List<DbItem> dbItems = new List<DbItem>( );

		private void S7ServerDbControl_SizeChanged( object sender, EventArgs e )
		{
			// 重新设置表格的列宽
			if (this.dataGridView1.Width > 450)
			{
				Column_des.Width = dataGridView1.Width - 350 - 43 - 18;
			}
		}
	}

	public class DbItem
	{
		public DbItem( )
		{
			DbNumber = 1;
			Size = 65536;
			Name = "";
			Note = string.Empty;
		}

		public DbItem( XElement element ) : this( )
		{
			DbNumber = int.Parse( element.Attribute( "DbNumber" ).Value );
			Size = HslFormContent.GetXmlValue( element, "Size", ushort.MaxValue, int.Parse );
			Name = HslFormContent.GetXmlValue( element, "Name", "", m => m );
			Note = HslFormContent.GetXmlValue( element, "Note", "", m => m );
		}

		public int DbNumber { get; set; }
		public int Size { get; set; }
		public string Name { get; set; }
		public string Note { get; set; }

		public override string ToString( ) => $"DB{DbNumber} {Size}Byte {Name}";

		public XElement ToXml( )
		{
			return new XElement( "DbItem",
				new XAttribute( "DbNumber", DbNumber ),
				new XAttribute( "Size", Size ),
				new XAttribute( "Name", Name ),
				new XAttribute( "Note", Note ) );
		}

		public static DbItem Parse( XElement element )
		{
			return new DbItem( element );
		}
	}
}
