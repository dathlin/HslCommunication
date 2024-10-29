using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Core;
using System.Reflection;
using HslCommunication;
using HslCommunication.LogNet;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteOp : UserControl
	{
		public UserControlReadWriteOp( )
		{
			InitializeComponent( );

			Disposed += UserControlReadWriteOp_Disposed;
		}

		private void UserControlReadWriteOp_Disposed( object sender, EventArgs e )
		{
			if (checkBox_read_timer.Checked) checkBox_read_timer.Checked = false;
			if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
		}

		private string[] encodings = DemoUtils.GetEncodings( );
		private Timer timer_read;
		private Button button_read_timer;

		private Timer timer_write;
		private Button button_write_timer;
		private long read_tick_count;
		public event EventHandler<string> MethodCodeClick;

		private void UserControlReadWriteOp_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			
			comboBox_read_encoding.DataSource = encodings;
			comboBox_write_Encoding.DataSource = encodings;

			checkBox_read_timer.CheckedChanged += CheckBox_read_timer_CheckedChanged;
			checkBox_write_timer.CheckedChanged += CheckBox_write_timer_CheckedChanged;
		}

		private void CheckBox_write_timer_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox_write_timer.Checked)
			{
				// 启动写入定时器
				if (!int.TryParse( textBox_timer_write_interval.Text, out int result ))
				{
					MessageBox.Show( "Read time interval input wrong!" );
					return;
				}
				if (result <= 0)
				{
					MessageBox.Show( "Read time interval can not below 0!" );
					return;
				}

				timer_write?.Dispose( );
				timer_write = new Timer( );
				timer_write.Interval = result;
				timer_write.Tick += Timer_write_Tick; ;
				timer_write.Start( );
				this.button_write_timer = null;
			}
			else
			{
				timer_write?.Dispose( );
				timer_write = null;
				this.button_write_timer = null;
			}
		}

		public void Close( )
		{
			if (checkBox_read_timer.Checked) checkBox_read_timer.Checked = false;
			if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
		}

		private void Timer_write_Tick( object sender, EventArgs e )
		{
			this.button_write_timer?.PerformClick( );
		}

		private void CheckBox_read_timer_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox_read_timer.Checked)
			{
				// 启动定时器
				if (!int.TryParse(textBox_read_timer_interval.Text, out int result ))
				{
					MessageBox.Show( "Read time interval input wrong!" );
					return;
				}
				if (result <= 0)
				{
					MessageBox.Show( "Read time interval can not below 0!" );
					return;
				}

				timer_read?.Dispose( );
				timer_read = new Timer( );
				timer_read.Interval = result;
				timer_read.Tick += Timer_read_Tick;
				timer_read.Start( );
				this.button_read_timer = null;
				this.read_tick_count = 0;
			}
			else
			{
				timer_read?.Dispose( );
				timer_read = null;
				this.button_read_timer = null;
				this.timerValue = int.MinValue;
			}
		}

		private void Timer_read_Tick( object sender, EventArgs e )
		{
			button_read_timer?.PerformClick( );
			if (button_read_timer != null)
			{
				read_tick_count++;
				label17.Text = (Program.Language == 1 ? "次数: " : "Freq: ") + this.read_tick_count.ToString( );
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Curve Monitor";

				label6.Text = "address:";
				label7.Text = "result:";
				label8.Text = "length:";
				label17.Text = "Freq: 0";

				button_read_bool.Text = "Read Bit";
				button_read_byte.Text = "r-byte";
				button_read_short.Text = "r-short";
				button_read_ushort.Text = "r-ushort";
				button_read_int.Text = "r-int";
				button_read_uint.Text = "r-uint";
				button_read_long.Text = "r-long";
				button_read_ulong.Text = "r-ulong";
				button_read_float.Text = "r-float";
				button_read_double.Text = "r-double";
				button_read_string.Text = "r-string";

				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note:The string can convert value\r\nif bool: true,false,0,1\r\nif array：[1,2,3]";
				button_write_bool.Text = "Write Bit";
				button_write_short.Text = "w-short";
				button_write_ushort.Text = "w-ushort";
				button_write_int.Text = "w-int";
				button_write_uint.Text = "w-uint";
				button_write_long.Text = "w-long";
				button_write_ulong.Text = "w-ulong";
				button_write_float.Text = "w-float";
				button_write_double.Text = "w-double";
				button_write_string.Text = "w-string";
				button_write_hex.Text = "w-hex";

				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";

				button_write_byte.Text = "w-byte";
				button1.Text = "Curve";
				label1.Text = "Time-Cost:";
				label12.Text = "Encoding:";
				label13.Text = "Encoding:";
				checkBox_read_timer.Text = "Timer Read";
				checkBox_write_timer.Text = "Timer Write";

				label16.Text = "if write 1-100, value input {1:100}";
				checkBox_mask_duplicates.Text = "Mask duplicates value";

			}
			else
			{

			}
		}

		public void EnableRKC( )
		{
			button_read_bool.Enabled = false;
			button_read_byte.Enabled = false;
			button_read_short.Enabled = false;
			button_read_ushort.Enabled = false;
			button_read_int.Enabled = false;
			button_read_uint.Enabled = false;
			button_read_long.Enabled = false;
			button_read_ulong.Enabled = false;
			button_read_float.Enabled = false;
			button_read_string.Enabled = false;

			button_write_bool.Enabled = false;
			button_write_byte.Enabled = false;
			button_write_short.Enabled = false;
			button_write_ushort.Enabled = false;
			button_write_int.Enabled = false;
			button_write_uint.Enabled = false;
			button_write_long.Enabled = false;
			button_write_ulong.Enabled = false;
			button_write_float.Enabled = false;
			button_write_hex.Enabled = false;
			button_write_string.Enabled = false;
		}

		public void SetReadWriteNet( IReadWriteNet readWrite, string address, bool isAsync = false, int strLength = 10 )
		{
			this.isAsync = isAsync;
			this.address = address;
			if(string.IsNullOrEmpty( textBox3.Text ))
				textBox3.Text = address;
			if (string.IsNullOrEmpty( textBox_write_address.Text ))
				textBox_write_address.Text = address;
			textBox1.Text = strLength.ToString( );
			readWriteNet = readWrite;
			Type type = readWrite.GetType( );
			readByteMethod = type.GetMethod( "ReadByte", new Type[] { typeof(string) } );
			if (readByteMethod == null) button_read_byte.Enabled = false;

			try
			{
				writeByteMethod = type.GetMethod( "Write", new Type[] { typeof( string ), typeof( byte ) } );
				if (writeByteMethod == null) button_write_byte.Enabled = false;
			}
			catch
			{
				button_write_byte.Enabled = false;
			}
		}

		public string GetWriteAddress( ) => textBox_write_address.Text;

		private string address = string.Empty;
		private IReadWriteNet readWriteNet;
		private bool isAsync = false;
		private MethodInfo readByteMethod = null;
		private MethodInfo writeByteMethod = null;
		private string readValueLast = string.Empty;
		private string readTimeLast = string.Empty;
		private long readValueRepeatTimes = 1;

		private ValueLimit valueLimit = new ValueLimit( );

		private void SetTimeSpend( int millseconds )
		{
			valueLimit.SetNewValue( millseconds );
			label2.Text = $"{valueLimit.Current} ms";
			label3.Text = $"{valueLimit.MaxValue} ms";
			label5.Text = $"{valueLimit.MinValue} ms";
			label18.Text = $"{valueLimit.Average:F0} ms";
			label21.Text = $"{valueLimit.Count}";
		}

		private void RenderReadResult<T>( DateTime start, OperateResult<T> read )
		{
			SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
			if (!read.IsSuccess && checkBox_read_timer.Checked) checkBox_read_timer.Checked = false;
			ReadResultRender( read, textBox3.Text, textBox4 );
		}

		private void AppendReadResult( TextBox textBox, string text )
		{

			if (!checkBox_mask_duplicates.Checked)
				textBox.AppendText( DemoUtils.GetRenderTimeText( ) + $"{text}{Environment.NewLine}" );
			else
			{
				if (readValueLast == text)
				{
					readValueRepeatTimes++;
					// 重复显示的话，屏蔽读取的值操作
					if (textBox.Lines.Length > 0)
					{
						string[] lines = textBox.Lines;
						if (string.IsNullOrEmpty( lines[lines.Length - 1] ))
						{
							lines[lines.Length - 2] = readTimeLast + $"[{readValueRepeatTimes}] {text}";
							textBox.Text = string.Join( Environment.NewLine, lines );
							textBox.SelectionStart = textBox.Text.Length;
							textBox.ScrollToCaret( );
						}
						else
						{
							lines[lines.Length - 1] = readTimeLast + $"[{readValueRepeatTimes}] {text}";
							textBox.Text = string.Join( Environment.NewLine, lines );
							textBox.AppendText( Environment.NewLine );
						}
					}
				}
				else
				{
					readValueRepeatTimes = 1; // 不一样的值
					readTimeLast = DemoUtils.GetRenderTimeText( );
                    textBox.AppendText( readTimeLast + $"{text}{Environment.NewLine}" );
				}
				readValueLast = text;
			}
		}

		public void ReadResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
		{
			if (result.IsSuccess)
			{
				if (result.Content is Array)
				{
					AppendReadResult( textBox, $"[{address}] {HslCommunication.BasicFramework.SoftBasic.ArrayFormat( result.Content )}" );
				}
				else
				{
					AppendReadResult( textBox, $"[{address}] {result.Content}" );
				}
			}
			else
			{
				DemoUtils.ShowMessage( DemoUtils.GetRenderTimeText( ) + $"[{address}] Read Failed {Environment.NewLine}Reason：{result.ToMessageShowString( )}" );
			}
		}

		private async void button_read_bool_Click( object sender, EventArgs e )
		{
			// bool
			if (isAsync)
			{
				button_read_bool.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadBoolAsync( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<bool> read = @deviceName.ReadBool( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadBoolAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<bool[]> read = @deviceName.ReadBool( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_bool.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadBool( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<bool> read = @deviceName.ReadBool( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadBool( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<bool[]> read = @deviceName.ReadBool( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private void button_read_byte_Click( object sender, EventArgs e )
		{
			// byte，此处演示了基于反射的读取操作
			if (textBox5.Text == "1")
			{
				RenderReadResult( DateTime.Now, (OperateResult<byte>)readByteMethod.Invoke( readWriteNet, new object[] { textBox3.Text } ) );
				GetReadCode( textBox3.Text, "OperateResult<byte> read = @deviceName.ReadByte( \"" + textBox3.Text + "\" );", isArray: false );
			}
			else
			{
				RenderReadResult( DateTime.Now, readWriteNet.Read( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
				GetReadCode( textBox3.Text, "OperateResult<byte[]> read = @deviceName.Read( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_short_Click( object sender, EventArgs e )
		{
			// short
			if (isAsync)
			{
				button_read_short.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt16Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<short> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<short[]> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_short.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt16( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<short> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<short[]> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_ushort_Click( object sender, EventArgs e )
		{
			// ushort
			if (isAsync)
			{
				button_read_ushort.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt16Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort[]> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_ushort.Enabled = true;
			}
			else
			{

				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt16( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort[]> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_int_Click( object sender, EventArgs e )
		{
			// int
			if (isAsync)
			{
				button_read_int.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt32Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<int> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<int[]> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_int.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt32( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<int> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<int[]> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_uint_Click( object sender, EventArgs e )
		{
			// uint
			if (isAsync)
			{
				button_read_uint.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt32Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<uint> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<uint[]> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_uint.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt32( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<uint> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<uint[]> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_long_Click( object sender, EventArgs e )
		{
			// long
			if (isAsync)
			{
				button_read_long.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt64Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<long> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<long[]> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_long.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt64( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<long> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<long[]> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_ulong_Click( object sender, EventArgs e )
		{
			// ulong
			if (isAsync)
			{
				button_read_ulong.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt64Async( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong[]> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_ulong.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt64( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong[]> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_float_Click( object sender, EventArgs e )
		{
			// float
			if (isAsync)
			{
				button_read_float.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadFloatAsync( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<float> read = @deviceName.ReadFloat( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadFloatAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<float[]> read = @deviceName.ReadFloat( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_float.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadFloat( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<float> read = @deviceName.ReadFloat( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadFloat( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<float[]> read = @deviceName.ReadFloat( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_double_Click( object sender, EventArgs e )
		{
			// double
			if (isAsync)
			{
				button_read_double.Enabled = false;
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadDoubleAsync( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<double> read = @deviceName.ReadDouble( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadDoubleAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<double[]> read = @deviceName.ReadDouble( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_double.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadDouble( textBox3.Text ) );
					GetReadCode( textBox3.Text, "OperateResult<double> read = @deviceName.ReadDouble( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadDouble( textBox3.Text, ushort.Parse( textBox5.Text ) ) );
					GetReadCode( textBox3.Text, "OperateResult<double[]> read = @deviceName.ReadDouble( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// string
			if (isAsync)
			{
				button_read_string.Enabled = false;
				RenderReadResult( DateTime.Now, await readWriteNet.ReadStringAsync( textBox3.Text, ushort.Parse( textBox1.Text ), DemoUtils.GetEncodingFromIndex( comboBox_read_encoding.SelectedIndex ) ) );
				button_read_string.Enabled = true;
				GetReadCode( textBox3.Text, "OperateResult<string> read = @deviceName.ReadString( \"" + textBox3.Text + "\", " + textBox1.Text + ", " + DemoUtils.GetEncodingTextFromIndex( comboBox_read_encoding.SelectedIndex ) + " );", isArray: false );
			}
			else
			{
				RenderReadResult( DateTime.Now, readWriteNet.ReadString( textBox3.Text, ushort.Parse( textBox1.Text ), DemoUtils.GetEncodingFromIndex( comboBox_read_encoding.SelectedIndex ) ) );
				GetReadCode( textBox3.Text, "OperateResult<string> read = @deviceName.ReadString( \"" + textBox3.Text + "\", " + textBox1.Text + ", " + DemoUtils.GetEncodingTextFromIndex( comboBox_read_encoding.SelectedIndex ) + " );", isArray: false );
			}

			if (checkBox_read_timer.Checked) this.button_read_timer = sender as Button;
		}

		private int timerValue = int.MinValue;

		private string GetWriteValueText( )
		{
			if (checkBox_write_timer.Checked && Regex.IsMatch( textBox_write_text.Text, @"\{[\d-]+:[\d-]+\}" ))
			{
				MatchCollection mc = Regex.Matches( textBox_write_text.Text, @"[\d-]+" );
				if (mc.Count == 2)
				{
					int start = Convert.ToInt32( mc[0].Value );
					int end   = Convert.ToInt32( mc[1].Value );

					if (start < end)
					{
						if (timerValue < start || timerValue >= end) 
							timerValue = start;
						else 
							timerValue++;
					}
					else
					{
						if (timerValue > start || timerValue <= end)
							timerValue = start;
						else
							timerValue--;
					}
					return timerValue.ToString( );
				}
				return textBox_write_text.Text;
			}
			else
			{
				return textBox_write_text.Text;
			}
		}

		private void RenderWriteResult( Func<OperateResult> writeFunc, Button button, string input )
		{
			if (isAsync) button.Enabled = false;

			DateTime start = DateTime.Now;
			OperateResult write = writeFunc( );
			SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );

			if (isAsync) button.Enabled = true;
			if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
			WriteResultRender( write, textBox_write_address.Text, input );
		}

		private async Task RenderWriteResult( Func<Task<OperateResult>> writeFunc, Button button, string input )
		{
			if (isAsync) button.Enabled = false;

			DateTime start = DateTime.Now;
			OperateResult write = await writeFunc( );
			SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );

			if (isAsync) button.Enabled = true;
			if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
			WriteResultRender( write, textBox_write_address.Text, input );
		}

		private async void button_write_bool_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// bool
			if (input.StartsWith("[") && input.EndsWith( "]" ))
			{
				try
				{
					bool[] value = input.ToStringArray<bool>( );
					if (isAsync)
					{
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_bool, input );
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", \"" + input + "\".ToStringArray<bool>( ) );" );
					}
					else
					{
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_bool, input );
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", \"" + input + "\".ToStringArray<bool>( ) );" );
					}
				}
				catch(Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "Bool Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (input == "1") input = "True";
				if (input == "0") input = "False";
				if (bool.TryParse( input, out bool value ))
				{
					if (isAsync)
					{
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_bool, input );
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", " + input + " );" );
					}
					else
					{
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_bool, input );
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", " + input + " );" );
					}
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "Bool Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_byte_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					byte[] value = input.ToStringArray<byte>( );
					if (isAsync)
					{
						button_write_short.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox_write_address.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						button_write_short.Enabled = true;
						if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
						WriteResultRender( write, textBox_write_address.Text, string.Empty );
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox_write_address.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
						WriteResultRender( write, textBox_write_address.Text, string.Empty );
					}

					GetWriteCode( textBox_write_address.Text, input, "byte", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "byte Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				// byte，此处演示了基于反射的写入操作
				if (byte.TryParse( input, out byte value ))
				{
					DateTime start = DateTime.Now;
					OperateResult write = (OperateResult)writeByteMethod.Invoke( readWriteNet, new object[] { textBox_write_address.Text, value } );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					WriteResultRender( write, textBox_write_address.Text, input );

					GetWriteCode( textBox_write_address.Text, input, "byte", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "Byte Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_short_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// short
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					short[] value = input.ToStringArray<short>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_short, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_short, input );

					GetWriteCode( textBox_write_address.Text, input, "short", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "short Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (short.TryParse( input, out short value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_short, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_short, input );

					GetWriteCode( textBox_write_address.Text, input, "short", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "short Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_ushort_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// ushort
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					ushort[] value = input.ToStringArray<ushort>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ushort, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ushort, input );

					GetWriteCode( textBox_write_address.Text, input, "ushort", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "ushort Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (ushort.TryParse( input, out ushort value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ushort, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ushort, input );

					GetWriteCode( textBox_write_address.Text, input, "ushort", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "ushort Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_int_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// int
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					int[] value = input.ToStringArray<int>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_int, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_int, input );

					GetWriteCode( textBox_write_address.Text, input, "int", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "int Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (int.TryParse( input, out int value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_int, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_int, input );

					GetWriteCode( textBox_write_address.Text, input, "int", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "int Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_uint_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// uint
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					uint[] value = input.ToStringArray<uint>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_uint, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_uint, input );

					GetWriteCode( textBox_write_address.Text, input, "uint", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "uint Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (uint.TryParse( input, out uint value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_uint, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_uint, input );

					GetWriteCode( textBox_write_address.Text, input, "uint", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "uint Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_long_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// long
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					long[] value = input.ToStringArray<long>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_long, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_long, input );

					GetWriteCode( textBox_write_address.Text, input, "long", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "long Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (long.TryParse( input, out long value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_long, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_long, input );

					GetWriteCode( textBox_write_address.Text, input, "long", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "long Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_ulong_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// ulong
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					ulong[] value = input.ToStringArray<ulong>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ulong, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ulong, input );

					GetWriteCode( textBox_write_address.Text, input, "ulong", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "ulong Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (ulong.TryParse( input, out ulong value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ulong, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ulong, input );

					GetWriteCode( textBox_write_address.Text, input, "ulong", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "ulong Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_float_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// float
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					float[] value = input.ToStringArray<float>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_float, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_float, input );

					GetWriteCode( textBox_write_address.Text, input, "float", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "float Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (float.TryParse( input, out float value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_float, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_float, input );

					GetWriteCode( textBox_write_address.Text, input, "float", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "float Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_double_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// double
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					double[] value = input.ToStringArray<double>( );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_double, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_double, input );

					GetWriteCode( textBox_write_address.Text, input, "double", isArray: true );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "float Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (double.TryParse( input, out double value ))
				{
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_double, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_double, input );

					GetWriteCode( textBox_write_address.Text, input, "double", isArray: false );
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					MessageBox.Show( "double Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_string_Click( object sender, EventArgs e )
		{
			// string
			if (isAsync)
			{
				button_write_string.Enabled = false;
				DateTime start = DateTime.Now;
				OperateResult write;
				if (comboBox_write_Encoding.SelectedIndex == 0)
					write = await readWriteNet.WriteAsync( textBox_write_address.Text, textBox_write_text.Text );
				else
					write = await readWriteNet.WriteAsync( textBox_write_address.Text, textBox_write_text.Text, DemoUtils.GetEncodingFromIndex( comboBox_write_Encoding.SelectedIndex ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );

				if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
				WriteResultRender( write, textBox_write_address.Text, string.Empty );
				button_write_string.Enabled = true;
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult write;
				if (comboBox_write_Encoding.SelectedIndex == 0)
					write = readWriteNet.Write( textBox_write_address.Text, textBox_write_text.Text );
				else
					write = readWriteNet.Write( textBox_write_address.Text, textBox_write_text.Text, DemoUtils.GetEncodingFromIndex( comboBox_write_Encoding.SelectedIndex ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
				WriteResultRender( write, textBox_write_address.Text, string.Empty );

			}

			GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", \"" + textBox_write_text.Text + "\", " + DemoUtils.GetEncodingTextFromIndex( comboBox_write_Encoding.SelectedIndex ) + " ) );" );
			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private async void button_write_hex_Click( object sender, EventArgs e )
		{
			// hex
			if (isAsync)
			{
				button_write_string.Enabled = false;
				DateTime start = DateTime.Now;
				OperateResult write = await readWriteNet.WriteAsync( textBox_write_address.Text, textBox_write_text.Text.ToHexBytes( ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
				WriteResultRender( write, textBox_write_address.Text, string.Empty );
				button_write_string.Enabled = true;
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult write = readWriteNet.Write( textBox_write_address.Text, textBox_write_text.Text.ToHexBytes( ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				if (!write.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
				WriteResultRender( write, textBox_write_address.Text, string.Empty );
			}

			GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", \"" + textBox_write_text.Text + "\".ToHexBytes( ) ) );" );
			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		public void WriteResultRender( OperateResult result, string address, string input )
		{
			if (checkBox_write_timer.Checked && result.IsSuccess)
				label16.Text = DateTime.Now.ToString( "HH:mm:ss" ) + " Write Success: " + input;
			else
				DemoUtils.WriteResultRender( result, address );

			if (!result.IsSuccess && checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			FormCurveMonitor monitor = new FormCurveMonitor( );
			monitor.SetReadWrite( readWriteNet, address );
			FormMain.Form.ShowDockForm( monitor );
		}


		private void GetReadCode( string address, string method, bool isArray )
		{
			//OperateResult<short[]> read = readWriteNet.ReadInt16(  );
			//if (read.IsSuccess)
			//{
			//	Console.WriteLine( "Read [" + address + "] Success, Value: " + read.Content.ToArrayString( ) );
			//}
			//else
			//{
			//	Console.WriteLine( "Read [" + address + "] failed: " + read.Message );
			//}
			if (checkBox_read_timer.Checked) return;  // 开启定时器不显示

			StringBuilder sb = new StringBuilder( );
			sb.Append( "// 当前读取操作的代码 The code for the current read operation" );
			sb.Append( Environment.NewLine );
			sb.Append( method );
			sb.Append( Environment.NewLine );
			sb.Append( "if (read.IsSuccess)" );
			sb.Append( Environment.NewLine );
			sb.Append( "{" );
			sb.Append( Environment.NewLine );
			sb.Append( "    Console.WriteLine( \"Read [" + address + "] Success, Value: \" + read.Content" );
			if (isArray)
				sb.Append( ".ToArrayString( ) " );
			else
				sb.Append( ";" );
			sb.Append( Environment.NewLine );
			sb.Append( "}" );
			sb.Append( Environment.NewLine );
			sb.Append( "else" );
			sb.Append( Environment.NewLine );
			sb.Append( "{" );
			sb.Append( Environment.NewLine );
			sb.Append( "    Console.WriteLine( \"Read [" + address + "] failed: \" + read.Message );" );
			sb.Append( Environment.NewLine );
			sb.Append( "}" );

			MethodCodeClick?.Invoke( readWriteNet, sb.ToString( ) );
		}

		private void GetWriteCode( string address, string input, string type, bool isArray )
		{
			if (isArray)
				GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", \"" + input + "\".ToStringArray<" + type + ">( ) );" );
			else
				GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", " + type + ".Parse( \"" + input + "\" ) );" );
		}

		private void GetWriteCode( string address, string method )
		{
			//OperateResult write = readWriteNet.Write( address, "value" );
			//if (write.IsSuccess)
			//{
			//	Console.WriteLine( "Write [" + address + "] success" );
			//}
			//else
			//{
			//	Console.WriteLine( "Write [" + address + "] failed: " + write.Message );
			//}
			if (checkBox_write_timer.Checked) return;  // 开启定时器不显示

			StringBuilder sb = new StringBuilder( );
			sb.Append( "// 当前写入操作的代码 The code for the current write operation" );
			sb.Append( Environment.NewLine );
			sb.Append( method );
			sb.Append( Environment.NewLine );
			sb.Append( "if (write.IsSuccess)" );
			sb.Append( Environment.NewLine );
			sb.Append( "{" );
			sb.Append( Environment.NewLine );
			sb.Append( "    Console.WriteLine( \"Write [" + address + "] success\" );" );
			sb.Append( Environment.NewLine );
			sb.Append( "}" );
			sb.Append( Environment.NewLine );
			sb.Append( "else" );
			sb.Append( Environment.NewLine );
			sb.Append( "{" );
			sb.Append( "    Console.WriteLine( \"Write [" + address + "] failed: \" + write.Message );" );
			sb.Append( Environment.NewLine );
			sb.Append( "}" );

			MethodCodeClick?.Invoke( readWriteNet, sb.ToString( ) );
		}

	}
}
