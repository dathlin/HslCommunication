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

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormCurveMonitor : Form
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
			propertyGrid1.SelectedObject = hslCurve1;
			hslCurve1.SetLeftCurve( "Test", null );
		}

		private IReadWriteNet readWriteNet;
		private string address = string.Empty;
		private int timeSpan = 1000;
		private string readType = string.Empty;
		private Thread thread;
		private bool isQuit = false;

		public void SetReadWrite( IReadWriteNet readWrite, string address )
		{
			readWriteNet = readWrite;
			textBox3.Text = address;
			thread = new Thread( ThreadRead );
			thread.IsBackground = false;
			thread.Start( );
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
								  if (read.Content) hslCurve1.AddCurveData( "Test", 1 );
								  else hslCurve1.AddCurveData( "Test", 0 );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", read.Content );
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
								hslCurve1.AddCurveData( "Test", (float)read.Content );
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
					if (isQuit) break; ;
				}

				if (isQuit) break;
			}
		}

		private async void FormCurveMonitor_FormClosing( object sender, FormClosingEventArgs e )
		{
			isQuit = true;
			await Task.Delay( 200 );
		}

		private void SetEnable(bool enable )
		{
			button_read_bool.Enabled = enable;
			button_read_short.Enabled = enable;
			button_read_ushort.Enabled = enable;
			button_read_int.Enabled = enable;
			button_read_uint.Enabled = enable;
			button_read_long.Enabled = enable;
			button_read_ulong.Enabled = enable;
			button_read_float.Enabled = enable;
			button_read_double.Enabled = enable;
		}

		private void button_read_bool_Click( object sender, EventArgs e )
		{
			readType = "bool";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_byte_Click( object sender, EventArgs e )
		{
			readType = "byte";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_short_Click( object sender, EventArgs e )
		{
			readType = "short";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_ushort_Click( object sender, EventArgs e )
		{
			readType = "ushort";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_int_Click( object sender, EventArgs e )
		{
			readType = "int";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_uint_Click( object sender, EventArgs e )
		{
			readType = "uint";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_long_Click( object sender, EventArgs e )
		{
			readType = "long";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_ulong_Click( object sender, EventArgs e )
		{
			readType = "ulong";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_float_Click( object sender, EventArgs e )
		{
			readType = "float";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button_read_double_Click( object sender, EventArgs e )
		{
			readType = "double";
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( false );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			readType = string.Empty;
			address = textBox3.Text;
			timeSpan = int.Parse( textBox1.Text );
			SetEnable( true );
		}
	}
}
