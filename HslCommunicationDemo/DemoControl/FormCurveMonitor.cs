using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Core;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslControls;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormCurveMonitor : HslFormContent
	{
		public FormCurveMonitor( )
		{
			InitializeComponent( );
		}

		class LineItem
		{
			public LineItem() { }

			public string Address { get; set; } = string.Empty;

			public string Name { get; set; } = string.Empty;

			public string Type { get; set; } = "short";

			public Color Color { get; set; } = Color.Blue;

			public CurveStyle Style { get; set; } = CurveStyle.Curve;

			public float Value { get; set; } = 0f;

			public float[] Data = new float[0];

			public ValueLimit ValueLimit = new ValueLimit( );

			public void SetValue( int dataCountMax, int countMin )
			{
				ValueLimit.SetNewValue( this.Value );
				SoftBasic.AddArrayData( ref Data, new float[] { this.Value }, dataCountMax );
				if ( Data.Length < countMin )
				{
					Data = SoftBasic.SpliceArray( GetFloatNaN( countMin - Data.Length ), Data );
				}
			}

			private float[] GetFloatNaN( int count )
			{
				float[] result = new float[count];
				for (int i = 0; i < count; i++)
				{
					result[i] = float.NaN;
				}
				return result;
			}

			public string GetCurveName( )
			{
				if (string.IsNullOrEmpty( Name ))
				{
					return Address;
				}
				else
				{
					return Name;
				}
			}
		}


		private void FormCurveMonitor_Load( object sender, EventArgs e )
		{
			propertyGrid1.SelectedObject = hslCurveHistory1;
			comboBox_line_style.DataSource = SoftBasic.GetEnumValues<HslControls.CurveStyle>( );
			comboBox_type.DataSource = new string[] { "bool", "short", "ushort", "int", "uint", "long", "ulong", "float", "double" };
			comboBox_type.SelectedIndex = 1;
			// hslCurve1.SetLeftCurve( "Test", null, Color.Blue );

			this.userControlHead1.SetText1( Program.Language == 1 ? "连接对象:" : "Device:" );
		}

		private IReadWriteNet readWriteNet;
		private int timeSpan = 1000;
		private Thread thread;
		private bool isQuit = false;
		private DateTime[] times = new DateTime[0];
		private bool threadReadEnable = false;
		private int dataCountMax = 3000; // 最大的数据个数，超过这个个数就会被清除掉
		private List<LineItem> lineItems = new List<LineItem>( );
		private object lockObject = new object( );

		public void SetReadWrite( IReadWriteNet readWrite, string address )
		{
			readWriteNet = readWrite;
			textBox_curve_address.Text = address;
			thread = new Thread( ThreadRead );
			thread.IsBackground = false;
			thread.Start( );

			if (readWrite != null) userControlHead1.HelpLink = readWrite.ToString( );
		}

		private void button_timer_start_Click( object sender, EventArgs e )
		{
			try
			{
				timeSpan = int.Parse( textBox1.Text );
				dataCountMax = int.Parse( textBox2.Text );
				threadReadEnable = true;
				button_timer_start.Enabled = false;
				button_timer_stop.Enabled = true;
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "时间间隔必须是数字！" );
				return;
			}
		}
		private void button_timer_stop_Click( object sender, EventArgs e )
		{
			threadReadEnable = false;
			button_timer_start.Enabled = true;
			button_timer_stop.Enabled = false;
		}

		private void ThreadRead( )
		{
			while (true)
			{
				Thread.Sleep( timeSpan );
				if (isQuit) return;
				if (readWriteNet == null) continue;
				if (threadReadEnable == false) continue;

				LineItem[] lineItems = null;
				lock (lockObject)
				{
					lineItems = this.lineItems.ToArray( );
				}

				DateTime start = DateTime.Now;
				for ( int i = 0; i < lineItems.Length; i ++)
				{
					if (isQuit) return;
					LineItem lineItem = lineItems[i];
					if (string.IsNullOrEmpty( lineItem.Address )) continue;
					if (string.IsNullOrEmpty( lineItem.Type )) continue;

					if (lineItem.Type == "bool")
					{
						OperateResult<bool> read = readWriteNet.ReadBool( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content ? 100f : 0f;
						}
						else
						{
							DemoUtils.ShowMessage( $"Read [{lineItem.Address}] Failed: " + read.Message );
							return;
						}
					}
					else if (lineItem.Type == "short")
					{
						OperateResult<short> read = readWriteNet.ReadInt16( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( $"Read [{lineItem.Address}] Failed: " + read.Message );
							return;
						}
					}
					else if (lineItem.Type == "ushort")
					{
						OperateResult<ushort> read = readWriteNet.ReadUInt16( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "int")
					{
						OperateResult<int> read = readWriteNet.ReadInt32( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "uint")
					{
						OperateResult<uint> read = readWriteNet.ReadUInt32( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "long")
					{
						OperateResult<long> read = readWriteNet.ReadInt64( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "ulong")
					{
						OperateResult<ulong> read = readWriteNet.ReadUInt64( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "float")
					{
						OperateResult<float> read = readWriteNet.ReadFloat( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
					else if (lineItem.Type == "double")
					{
						OperateResult<double> read = readWriteNet.ReadDouble( lineItem.Address );
						if (read.IsSuccess)
						{
							if (!isQuit) lineItem.Value = (float)read.Content;
						}
						else
						{
							DemoUtils.ShowMessage( "Read Failed" );
							return;
						}
					}
				}
				try
				{
					if (lineItems.Length == 0) continue;
					if (!isQuit) Invoke( new Action( ( ) =>
					{
						SoftBasic.AddArrayData( ref times, new DateTime[] { DateTime.Now }, dataCountMax );
						hslCurveHistory1.SetDateTimes( times );
						// 统一更新数据
						for (int i = 0; i < lineItems.Length; i++)
						{
							LineItem lineItem = lineItems[i];
							lineItem.SetValue( dataCountMax, times.Length );

							hslCurveHistory1.SetLeftCurve( lineItem.GetCurveName( ), lineItem.Data, lineItem.Color, lineItem.Style );
						}

						hslCurveHistory1.ScrollToRight( );
						hslCurveHistory1.RenderCurveUI( );   // 这步很重要
						 // 更新数据表

						RenderLineItems( lineItems );
						label_time_cost.Text = $"{(DateTime.Now - start ).TotalMilliseconds:F0} ms";
					} ) );
				}
				catch( Exception ex )
				{

				}

				if (isQuit) break;
			}
		}

		private async void FormCurveMonitor_FormClosing( object sender, FormClosingEventArgs e )
		{
			isQuit = true;
			await Task.Delay( 200 );
		}

		private void label_color_Click( object sender, EventArgs e )
		{
			using(ColorDialog dialog = new ColorDialog( ))
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					this.label_color.BackColor = dialog.Color;
				}
			}
		}

		private void button_read_Click( object sender, EventArgs e )
		{
			//times = new DateTime[0];
			if (string.IsNullOrEmpty( textBox_curve_address.Text ))
			{
				DemoUtils.ShowMessage( "地址不能为空！" );
				return;
			}

			LineItem lineItem = new LineItem( );
			lineItem.Address = textBox_curve_address.Text;
			if (string.IsNullOrEmpty( textBox_curve_name.Text ))
				lineItem.Name = lineItem.Address;
			else
				lineItem.Name = textBox_curve_name.Text;
			lineItem.Type = comboBox_type.Text;
			lineItem.Color = label_color.BackColor;
			lineItem.Style = (CurveStyle)comboBox_line_style.SelectedItem;

			lock (lockObject)
			{
				if (lineItems.Any( m => m.GetCurveName( ) == lineItem.GetCurveName( ) ))
				{
					DemoUtils.ShowMessage( "当前地址已经存在，请修改后重新添加！" );
					return;
				}
				lineItems.Add( lineItem );
			}

			if (tabControl1.SelectedTab != tabPage2)
			{
				tabControl1.SelectedTab = tabPage2;

			}

			RenderLineItems( lineItems.ToArray( ) );
		}

		private Image GetImageColor( Color color )
		{
			Bitmap bitmap = new Bitmap( 16, 16 );
			using (Graphics g = Graphics.FromImage( bitmap ))
			{
				g.Clear( color );
			}
			return bitmap;
		}

		private void RenderLineItems( LineItem[] lineItems )
		{
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, lineItems == null ? 0 : lineItems.Length );
			if (lineItems == null || lineItems.Length == 0)
			{
				return;
			}

			for ( int i = 0; i < lineItems.Length; i++ )
			{
				LineItem item = lineItems[i];
				if (dataGridView1.Rows[i].Tag is LineItem line)
				{
					if (object.ReferenceEquals( line, item ))
					{
						dataGridView1.Rows[i].Cells[2].Value = item.Value;
						dataGridView1.Rows[i].Cells[3].Value = item.ValueLimit.MaxValue;
						dataGridView1.Rows[i].Cells[4].Value = item.ValueLimit.MinValue;
					}
					else
					{
						dataGridView1.Rows[i].Cells[0].Value = item.GetCurveName( );
						dataGridView1.Rows[i].Cells[1].Value = GetImageColor( item.Color );
						dataGridView1.Rows[i].Cells[2].Value = item.Value;
						dataGridView1.Rows[i].Cells[3].Value = item.ValueLimit.MaxValue;
						dataGridView1.Rows[i].Cells[4].Value = item.ValueLimit.MinValue;
						dataGridView1.Rows[i].Tag = item;
					}
				}
				else
				{
					dataGridView1.Rows[i].Cells[0].Value = item.GetCurveName( );
					dataGridView1.Rows[i].Cells[1].Value = GetImageColor( item.Color );
					dataGridView1.Rows[i].Cells[2].Value = item.Value;
					dataGridView1.Rows[i].Cells[3].Value = item.ValueLimit.MaxValue;
					dataGridView1.Rows[i].Cells[4].Value = item.ValueLimit.MinValue;
					dataGridView1.Rows[i].Tag = item;
				}
			}
		}

		private void button_cancel_Click( object sender, EventArgs e )
		{
			// 移除曲线
			string name = textBox_curve_address.Text;
			if (!string.IsNullOrEmpty( textBox_curve_name.Text ))
				name = textBox_curve_name.Text;

			lock (lockObject)
			{
				lineItems.RemoveAll( m => m.GetCurveName( ) == name );
			}

			hslCurveHistory1.RemoveCurve( name );
			hslCurveHistory1.RenderCurveUI( );
			RenderLineItems( lineItems.ToArray( ) );
		}

		private void button_clear_all_Click( object sender, EventArgs e )
		{
			// 清除所有的曲线数据
			lock (lockObject)
			{
				lineItems.Clear( );
				times = new DateTime[0];
			}
			hslCurveHistory1.RemoveAllCurve( );
			RenderLineItems( lineItems.ToArray( ) );
		}
	}
}
