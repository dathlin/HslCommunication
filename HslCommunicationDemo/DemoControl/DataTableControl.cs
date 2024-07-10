using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.ModBus;
using HslCommunicationDemo.Control;
using HslControls;
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
			this.dataGridView1.CellContentClick += DataGridView1_CellContentClick;
			this.hslCurveHistory1.Paint += DataGridView1_Paint;
			this.hslCurveHistory1.MouseDown += DataGridView1_MouseDown;
			this.hslCurveHistory1.OnScrollChanged += HslCurveHistory1_OnScrollChanged;
			this.hslCurveHistory1.MouseMove += HslCurveHistory1_MouseMove;
			this.MouseMove += DataTableControl_MouseMove;
			this.MouseDown += DataTableControl_MouseDown;
			this.MouseUp += DataTableControl_MouseUp;
		}

		private void HslCurveHistory1_MouseMove( object sender, MouseEventArgs e )
		{
			if (this.mouseMoveTime >= DateTime.Now.AddSeconds( 5 ))
			{
				this.mouseMoveTime = DateTime.Now;
			}
		}

		private void HslCurveHistory1_OnScrollChanged( HslCurveHistory hslCurve, int scrollX, float scale, int offsetPaintScrollX )
		{
			this.mouseMoveTime = DateTime.Now;
		}

		private void DataGridView1_MouseDown( object sender, MouseEventArgs e )
		{
			Rectangle rect = new Rectangle( hslCurveHistory1.Width - 100, hslCurveHistory1.Height - 30, 98, 28 );
			if (rect.Contains( e.Location ))
			{
				using(FormPropertyModify form = new FormPropertyModify())
				{
					form.SetObject( hslCurveHistory1 );
					form.ShowDialog( );
				}
			}
		}

		private void DataGridView1_Paint( object sender, PaintEventArgs e )
		{
			Rectangle rect = new Rectangle( hslCurveHistory1.Width - 100, hslCurveHistory1.Height - 30, 98, 28 );
			e.Graphics.DrawRectangle( Pens.Gray, rect );
			e.Graphics.DrawString( Program.Language == 1 ? "曲线属性" : "Setting", this.Font, Brushes.Gray, rect, HslControls.HslHelper.StringFormatCenter );
		}

		class CurveData
		{
			public CurveData( string key )
			{
				this.Key = key;
				if (ColorIndex < CurveColors.Length)
				{
					CurveColor = CurveColors[ColorIndex].ToArgb( );
					ColorIndex++;
				}
				else
				{
					CurveColor = -1;
				}
			}

			public int CurveColor { get; set; }

			public string Key{ get; }

			public float[] Data = new float[0];

			public void Add( float value )
			{
				HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref Data, new float[] { value }, DataCount );
			}

			public void Clear( )
			{
				Data = new float[0];
			}

			public const int DataCount = 4000;
			public readonly static Color[] CurveColors = new Color[] { 
			Color.FromArgb( 0xe6, 0x19, 0x4B ), 
			Color.FromArgb( 0x3c, 0xb4, 0x4b ), 
			Color.FromArgb( 0x43, 0x63, 0xd8 ), 
			Color.FromArgb( 0xf5, 0x82, 0x31 ),
			Color.FromArgb( 0x91, 0x1e, 0xb4), 
			Color.FromArgb( 0xff, 0xe1, 0x19), 
			Color.FromArgb( 0x42, 0xd4, 0xf4), 
			Color.FromArgb( 0xf0, 0x32, 0xe6), 
			Color.FromArgb( 0x46, 0x99, 0x90), 
			Color.FromArgb( 0x9A, 0x63, 0x24),
			Color.FromArgb( 0x80, 0x00, 0x00), 
			Color.FromArgb( 0x80, 0x80, 0x00), 
			Color.FromArgb( 0x00, 0x00, 0x75 )};
			public static int ColorIndex = 0;
		}

		class CurveDataDict
		{
			private Dictionary<string, CurveData> curveValues = new Dictionary<string, CurveData>( );
			private DateTime[] dateTimes = new DateTime[0];

			public void Clear( )
			{
				foreach(CurveData curve in curveValues.Values)
				{
					curve.Clear( );
				}
				curveValues.Clear( );
			}

			public void RemoveData( string key )
			{
				if (string.IsNullOrEmpty( key )) return;
				if (curveValues.ContainsKey( key ))
				{
					curveValues.Remove( key );
				}
			}

			public void AddData<T>( string key, T value )
			{
				if (string.IsNullOrEmpty( key )) return;
				if (!curveValues.ContainsKey( key ))
				{
					// 如果不包含就创建
					CurveData data = new CurveData( key );
					data.Data = new float[dateTimes.Length];
					for (int i = 0; i < data.Data.Length; i++)
					{
						data.Data[i] = float.NaN;
					}
					curveValues.Add( key, data );
				}

				CurveData curveData = curveValues[key];
				if (curveData.Data.Length == dateTimes.Length)
				{
					HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref curveData.Data, new float[] { Convert.ToSingle( value ) }, CurveData.DataCount );
				}
			}

			public void AddDateTimes()
			{
				HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref dateTimes, new DateTime[] { DateTime.Now }, CurveData.DataCount );
				foreach (CurveData curve in curveValues.Values)
				{
					while (curve.Data.Length < dateTimes.Length)
					{
						HslCommunication.BasicFramework.SoftBasic.AddArrayData( ref curve.Data, new float[] { float.NaN }, CurveData.DataCount );
					}
				}
			}

			public void SetHistoryCurve( HslCurveHistory hslCurveHistory, DateTime time )
			{
				foreach (var item in this.curveValues.Values)
				{
					if (item.CurveColor != -1)
						hslCurveHistory.SetLeftCurve( item.Key, item.Data, Color.FromArgb( item.CurveColor ) );
					else
						hslCurveHistory.SetLeftCurve( item.Key, item.Data );
				}
				hslCurveHistory.SetDateTimes( this.dateTimes );
				if (time < DateTime.Now.AddSeconds( -5 ))
					hslCurveHistory.ScrollToRight( );
				else
					hslCurveHistory.RenderCurveUI( );
			}
		}

		private int locationY = -1;
		private bool isMouseDown = false;
		private Point mouseDownPoint = new Point( -1, -1 );
		private bool recordData = false;
		private CurveDataDict curveDataDict = new CurveDataDict( );

		private void SetControlLocation( int offset )
		{
			this.dataGridView1.Width = this.Width - 1;
			this.dataGridView1.Height = this.dataGridView1.Height + offset;

			this.hslCurveHistory1.Location = new Point( 0, this.hslCurveHistory1.Location.Y + offset );
			this.hslCurveHistory1.Height = this.hslCurveHistory1.Height - offset;
			this.hslCurveHistory1.Width = this.Width - 1;
			this.hslCurveHistory1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.locationY = this.dataGridView1.Height + 33;
		}

		private void DataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
		{
			if (e.ColumnIndex == 9)
			{
				DataGridViewCheckBoxCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[9] as DataGridViewCheckBoxCell;
				if (cell != null)
				{
					bool check = cell.Tag == null ? false : ( bool)cell.Tag;
					check = !check;
					cell.Tag = check;
					cell.Value = check;

					if (check)
					{
						// 添加到曲线里
						if (hslCurveHistory1.Visible == false)
						{
							this.dataGridView1.Width = this.Width - 1;
							this.dataGridView1.Height = (this.Height - 33) / 2 - 1;
							this.hslCurveHistory1.Height = (this.Height - 33) / 2 - 1;
							this.hslCurveHistory1.Width = this.Width - 1;
							this.hslCurveHistory1.Location = new Point( 0, (this.Height - 33) / 2 + 33);
							this.hslCurveHistory1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
							this.hslCurveHistory1.Visible = true;
							this.locationY = (this.Height - 33) / 2 + 32;
						}

						if (recordData == false)
						{
							recordData = true;    // 所有的数据开始记录
							CurveData.ColorIndex = 0;
							curveDataDict.Clear( );
						}
					}
					else 
					{
						// 如果所有的曲线选择显示都取消的话
						bool record = false;
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].IsNewRow) continue;
							if (this.dataGridView1.Rows[i].Cells[9] is DataGridViewCheckBoxCell cell1)
							{
								//bool checkTmp = cell1.Value == null ? false : (bool)cell1.Value;
								if (cell1 != null)
								{
									if (cell1.Value != null)
									{
										if ((bool)cell1.Value)
										{
											record = true;
											break;
										}
									}
									else if (cell1.Tag is bool value1)
									{
										if (value1)
										{
											record = true; 
											break;
										}
										
									}
								}
							}
						}
						if (record == false)
						{
							recordData = false;
							this.dataGridView1.Width = this.Width - 1;
							this.dataGridView1.Height = this.Height - 33;
							this.hslCurveHistory1.Visible = false;
						}
					}
				}
			}
		}

		private void DataTableControl_MouseMove( object sender, MouseEventArgs e )
		{
			if(this.hslCurveHistory1.Visible == false) { Cursor = Cursors.Default; return; }
			if (this.isMouseDown)
			{
				if (e.Location.Y < 60) { this.isMouseDown = false; return; }
				if (e.Location.Y > this.Height - 50) { this.isMouseDown = false; return; }

				int offset = e.Location.Y - this.mouseDownPoint.Y;
				SetControlLocation( offset );
				this.mouseDownPoint = e.Location;
			}
			else
			{
				this.locationY = this.dataGridView1.Height + 33;
				if (e.Location.Y < 58 || e.Location.Y > this.Height - 48) return;

				if (e.Location.Y >= this.locationY - 1 && e.Location.Y <= this.locationY + 1)
				{
					Cursor = Cursors.HSplit;

				}
				else
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void DataTableControl_MouseDown( object sender, MouseEventArgs e )
		{
			if (Cursor == Cursors.HSplit)
			{
				this.isMouseDown = true;
				this.mouseDownPoint = e.Location;
			}
		}

		private void DataTableControl_MouseUp( object sender, MouseEventArgs e )
		{
			this.isMouseDown = false;
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
				Column_expression.HeaderText = "Express";
				Column_curve.HeaderText = "Curv";

				button_from_clip.Text = "FromClip";
				button_from_file.Text = "FromFile";
				button_out_clip.Text = "ToClip";
				button_out_file.Text = "ToFile";
				label1.Text = "Interval";
				label2.Text = "Double click to write";
			}

		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[0].Width = 120 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 15 : 0);      // 数据名
			dataGridView1.Columns[1].Width = 120 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 15 : 0);      // 设备地址
			dataGridView1.Columns[2].Width = 80;                                                                      // 数据类型
			dataGridView1.Columns[3].Width = 80;                                                                      // 字符编码
			dataGridView1.Columns[4].Width = 60;                                                                      // 长度
			dataGridView1.Columns[5].Width = 150 + (dataGridView1.Width >= 1200 ? dataGridView1.Width / 10 : 0);      // 值
			dataGridView1.Columns[6].Width = 60;                                                                      // 单位
			dataGridView1.Columns[7].Width = 100;                                                                     // 表达式
			dataGridView1.Columns[9].Width = 40;                                                                      // 曲线

			int width = 0;
			for (int i = 0; i < 8; i++)
			{
				width += dataGridView1.Columns[i].Width;
			}
			width += 40;

			dataGridView1.Columns[8].Width = dataGridView1.Width - width - 20 - 40;                                   // 注释
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
			dataTableItem.Expression = dgvr.Cells[7].Value != null ? dgvr.Cells[7].Value.ToString( ) : string.Empty;
			dataTableItem.Description = dgvr.Cells[8].Value != null ? dgvr.Cells[8].Value.ToString( ) : string.Empty;
			return dataTableItem;
		}

		public void GetDataTable( XElement element )
		{
			element.SetAttributeValue( "Interval", textBox_time.Text );
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
			XAttribute attribute = element.Attribute( "Interval" );
			if (attribute != null)
			{
				textBox_time.Text = attribute.Value;
			}
			int count = 0;
			foreach (var item in element.Elements( nameof( DataTableItem ) ))
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
				if (dataTableItem.Length >= 0)
				{
					dgvr.Cells[4].Value = dataTableItem.Length.ToString( );
				}
				dgvr.Cells[6].Value = dataTableItem.Unit;
				dgvr.Cells[7].Value = dataTableItem.Expression;
				dgvr.Cells[8].Value = dataTableItem.Description;
				dgvr.Tag = dataTableItem;
				count++;
			}
			return count;
		}

		private Thread threadRead;
		private bool threadEnable = false;
		private int timeSleep = 1000;
		private DynamicExpresso.Interpreter interpreter = new DynamicExpresso.Interpreter( );
		private DateTime mouseMoveTime { get; set; } = DateTime.Now.AddMinutes( -1 );

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

		public void Close( )
		{
			if (threadEnable == true)
			{
				Button1_Click( button1, EventArgs.Empty );
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
						if (string.IsNullOrEmpty( dataTableItem.Expression ))
							dgvr.Cells[5].Value = read.Content.ToString( );
						else
						{
							dgvr.Cells[5].Value = this.interpreter.Eval( dataTableItem.Expression, new DynamicExpresso.Parameter( "x", read.Content ) );
						}

						string curveName = dataTableItem.Name;
						if (string.IsNullOrEmpty( curveName )) curveName = dataTableItem.Address;
						if (recordData && !string.IsNullOrEmpty( curveName ))
						{
							DataGridViewCheckBoxCell cell = dgvr.Cells[9] as DataGridViewCheckBoxCell;
							if (cell.Tag is bool check)
							{
								if (check)
								{
									if (string.IsNullOrEmpty( dataTableItem.Expression ))
										this.curveDataDict.AddData( curveName, read.Content );
									else
										this.curveDataDict.AddData( curveName, this.interpreter.Eval( dataTableItem.Expression, new DynamicExpresso.Parameter( "x", read.Content ) ) );
								}
								else
								{
									// 没有选择
									this.curveDataDict.RemoveData( curveName );
									this.hslCurveHistory1.RemoveCurve( curveName );
								}
							}
						}
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
						if (string.IsNullOrEmpty( dataTableItem.Expression ))
							dgvr.Cells[5].Value = read.Content.ToArrayString( );
						else
						{
							object[] array = new object[read.Content.Length];
							for (int i = 0; i < read.Content.Length; i++)
							{
								array[i] = this.interpreter.Eval( dataTableItem.Expression, new DynamicExpresso.Parameter( "x", read.Content[i] ) );
							}
							dgvr.Cells[5].Value = array.ToArrayString( );
						}
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
				Invoke( new Action( ( ) =>
				{
					if (recordData)
					{
						// 更新曲线内容
						this.curveDataDict.AddDateTimes( );
						this.curveDataDict.SetHistoryCurve( hslCurveHistory1, this.mouseMoveTime );
					}
				} ) );

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

		private void dataGridView1_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			if (e.ColumnIndex == 5 && e.RowIndex >= 0)
			{
				DataTableItem dataTableItem = GetDataTableItem( dataGridView1.Rows[e.RowIndex] );
				if (dataTableItem == null) return;
				if (string.IsNullOrEmpty( dataTableItem.Address )) return;

				object obj = dataGridView1.Rows[e.RowIndex].Cells[5].Value;
				using (FormInputNewValue form = new FormInputNewValue( obj?.ToString() ))
				{
					if (form.ShowDialog() == DialogResult.OK)
					{
						OperateResult write = OperateResult.CreateSuccessResult( );
						try
						{
							string value = form.InputValue;
							if (dataTableItem.DataTypeCode == "bool")
							{
								if (dataTableItem.Length < 0)
								{
									if (value == "1") value = "True";
									if (value == "0") value = "False";
									write = this.device.Write( dataTableItem.Address, bool.Parse( value ) );
								}
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<bool>( ) );
							}
							else if (dataTableItem.DataTypeCode == "short")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, short.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<short>( ) );
							}
							else if (dataTableItem.DataTypeCode == "ushort")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, ushort.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<ushort>( ) );
							}
							else if (dataTableItem.DataTypeCode == "int")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, int.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<int>( ) );
							}
							else if (dataTableItem.DataTypeCode == "uint")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, int.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<uint>( ) );
							}
							else if (dataTableItem.DataTypeCode == "long")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, long.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<long>( ) );
							}
							else if (dataTableItem.DataTypeCode == "float")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, float.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<float>( ) );
							}
							else if (dataTableItem.DataTypeCode == "double")
							{
								if (dataTableItem.Length < 0) write = this.device.Write( dataTableItem.Address, double.Parse( value ) );
								else write = this.device.Write( dataTableItem.Address, value.ToStringArray<double>( ) );
							}
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

								write = this.device.Write( dataTableItem.Address, value, encoding );
							}
							else
							{
								MessageBox.Show( "Not supported data type: " + dataTableItem.DataTypeCode );
								return;
							}

							if (write.IsSuccess)
							{
								MessageBox.Show( "Write Success!" );
							}
							else
							{
								MessageBox.Show( "Write Failed: " + write.Message );
							}
						}
						catch( Exception ex)
						{
							MessageBox.Show( "trans string to type " + dataTableItem.DataTypeCode + "failed: " + ex.Message );
						}

					}
				}
			}
		}
	}
}
