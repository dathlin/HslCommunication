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

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				System.Diagnostics.Process.Start( linkLabel1.Text );
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void FormCurveMonitor_Load( object sender, EventArgs e )
		{
			propertyGrid1.SelectedObject = hslCurveHistory1;
			comboBox_line_style.DataSource = SoftBasic.GetEnumValues<HslControls.CurveStyle>( );
			comboBox_type.DataSource = new string[] { "bool", "short", "ushort", "int", "uint", "long", "ulong", "float", "double" };
			comboBox_type.SelectedIndex = 1;
			// hslCurve1.SetLeftCurve( "Test", null, Color.Blue );
		}

		private IReadWriteNet readWriteNet;
		private string address = string.Empty;
		private int timeSpan = 1000;
		private string readType = string.Empty;
		private Thread thread;
		private bool isQuit = false;
		private Color lineColor = Color.Blue;
		private ValueLimit valueLimit = new ValueLimit( );
		private float[] data = new float[0];
		private DateTime[] times = new DateTime[0];

		public void SetReadWrite( IReadWriteNet readWrite, string address )
		{
			readWriteNet = readWrite;
			textBox3.Text = address;
			thread = new Thread( ThreadRead );
			thread.IsBackground = false;
			thread.Start( );

			if (readWrite != null) userControlHead1.HelpLink = readWrite.ToString( );
		}

		private void AddData( float value )
		{
			CurveStyle curveStyle = (CurveStyle)comboBox_line_style.SelectedItem;
			SoftBasic.AddArrayData( ref data, new float[] { value }, 3000 );
			SoftBasic.AddArrayData( ref times, new DateTime[] { DateTime.Now }, 3000 );
			hslCurveHistory1.SetLeftCurve( "Test", data, this.lineColor, curveStyle );
			hslCurveHistory1.SetDateTimes( times );
			hslCurveHistory1.ScrollToRight( );
			hslCurveHistory1.RenderCurveUI( );   // 这步很重要
		}

		private void ThreadRead( )
		{
			while (true)
			{
				Thread.Sleep( timeSpan );
				if (isQuit) return;

				try
				{
					if (readType == "bool")
					{
						OperateResult<bool> read = readWriteNet.ReadBool( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							  {
								  AddData( read.Content ? 100f : 0f );
								  label_value.Text = "Value: " + read.Content.ToString( );
							  } ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "short")
					{
						OperateResult<short> read = readWriteNet.ReadInt16( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "ushort")
					{
						OperateResult<ushort> read = readWriteNet.ReadUInt16( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "int")
					{
						OperateResult<int> read = readWriteNet.ReadInt32( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "uint")
					{
						OperateResult<uint> read = readWriteNet.ReadUInt32( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "long")
					{
						OperateResult<long> read = readWriteNet.ReadInt64( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "ulong")
					{
						OperateResult<ulong> read = readWriteNet.ReadUInt64( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "float")
					{
						OperateResult<float> read = readWriteNet.ReadFloat( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
					else if (readType == "double")
					{
						OperateResult<double> read = readWriteNet.ReadDouble( address );
						if (read.IsSuccess)
						{
							if (!isQuit) Invoke( new Action( ( ) =>
							{
								AddData( (float)read.Content );
								valueLimit.SetNewValue( read.Content );
								ShowValueLimit( valueLimit );
								label_value.Text = "Value: " + read.Content.ToString( );
							} ) );
						}
						else
						{
							MessageBox.Show( "Read Failed" );
							return;
						}
					}
				}
				catch
				{
					if (isQuit) break;
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
					this.lineColor = dialog.Color;
					this.label_color.BackColor = dialog.Color;
				}
			}
		}

		private void ShowValueLimit( ValueLimit valueLimit )
		{
			//label_value.Text = "Value: " + valueLimit.Current;
			label_value_max.Text = "Max: " + valueLimit.MaxValue;
			label_value_min.Text = "Min: " + valueLimit.MinValue;
			label_value_avg.Text = "Avg: " + valueLimit.Average;
			label_value_tick.Text = "Tick: " + valueLimit.Count;
		}

		private void button_read_Click( object sender, EventArgs e )
		{
			CurveStyle curveStyle = (CurveStyle)comboBox_line_style.SelectedItem;
			hslCurveHistory1.RemoveAllCurve( );
			valueLimit = new ValueLimit( );
			data = new float[0]; 
			times = new DateTime[0];
			hslCurveHistory1.SetLeftCurve( "Test", null, this.lineColor, curveStyle );
			readType = comboBox_type.Text;
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			button_read.Enabled = false;
		}

		private void button_cancel_Click( object sender, EventArgs e )
		{
			readType = string.Empty;
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			button_read.Enabled = true;
		}
	}
}
