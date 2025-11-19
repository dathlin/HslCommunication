using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Core;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteOp : UserControl
	{
		public UserControlReadWriteOp( )
		{
			InitializeComponent( );

			Disposed += UserControlReadWriteOp_Disposed;
			radioButton_async.CheckedChanged += RadioButton_async_CheckedChanged;
			radioButton_sync.CheckedChanged += RadioButton_async_CheckedChanged;
		}

		private void RadioButton_async_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton_sync.Checked)
				this.isAsync = false;
			else
				this.isAsync = true;
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


			if (this.ParentForm is HslFormContent formContent)
			{
				deviceImage = formContent.DeviceImage;
			}
		}

		private void CheckBox_write_timer_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox_write_timer.Checked)
			{
				// 启动写入定时器
				if (!int.TryParse( textBox_timer_write_interval.Text, out int result ))
				{
					DemoUtils.ShowMessage( "Read time interval input wrong!" );
					return;
				}
				if (result <= 0)
				{
					DemoUtils.ShowMessage( "Read time interval can not below 0!" );
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

		private Image deviceImage = null;


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
					DemoUtils.ShowMessage( "Read time interval input wrong!" );
					return;
				}
				if (result <= 0)
				{
					DemoUtils.ShowMessage( "Read time interval can not below 0!" );
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
				label19.Text = "Note:The string can convert value\r\nif bool: true,false,0,1\r\nif array:[1,2,3], [1:100], [1*100]";
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
				checkBox_mask_duplicates.Text = "Mask duplicates?";
				textBox_read_search.Text = "Search";
				button_find_string.Text = "find";

				radioButton_sync.Text = "Sync";
				radioButton_async.Text = "Async";
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
			if (isAsync) radioButton_async.Checked = true;
			else radioButton_sync.Checked = true;

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

		private void RenderReadResult<T>( DateTime start, OperateResult<T> read, int renderResult = -1 )
		{
			SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
			if (!read.IsSuccess && checkBox_read_timer.Checked) checkBox_read_timer.Checked = false;
			ReadResultRender( read, textBox3.Text, textBox4, renderResult );
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

		public void ReadResultRender<T>( OperateResult<T> result, string address, TextBox textBox, int renderResult )
		{
			if (result.IsSuccess)
			{
				if (result.Content is Array array)
				{
					if (renderResult == 1)
					{
						StringBuilder stringBuilder = new StringBuilder( );
						stringBuilder.Append( $"[{address}] [" );
						for(int i = 0; i < array.Length; i++)
						{
							stringBuilder.Append( $"0x{array.GetValue( i ):X}" );
							if (i < array.Length - 1) stringBuilder.Append( "," );
						}
						stringBuilder.Append( "]" );
						AppendReadResult( textBox, stringBuilder.ToString( ) );
					}
					else if (renderResult == 2)
					{
						StringBuilder stringBuilder = new StringBuilder( );
						stringBuilder.Append( $"[{address}] [" );
						for (int i = 0; i < array.Length; i++)
						{
							stringBuilder.Append( GetBoolArrayRenderString( array.GetValue( i ) ) );
							if (i < array.Length - 1) stringBuilder.Append( "," );
						}
						stringBuilder.Append( "]" );
						AppendReadResult( textBox, stringBuilder.ToString( ) );
					}
					else
					{
						AppendReadResult( textBox, $"[{address}] {HslCommunication.BasicFramework.SoftBasic.ArrayFormat( result.Content )}" );
					}
				}
				else
				{
					if (renderResult == 1)
						AppendReadResult( textBox, $"[{address}] 0x{result.Content:X}" );
					else if (renderResult == 2)
					{
						AppendReadResult( textBox, $"[{address}] {GetBoolArrayRenderString(result.Content)}" );
					}
					else
						AppendReadResult( textBox, $"[{address}] {result.Content}" );
				}
			}
			else
			{
				DemoUtils.ShowMessage( DemoUtils.GetRenderTimeText( ) + $"[{address}] Read Failed {Environment.NewLine}Reason：{result.ToMessageShowString( )}" );
			}
		}

		private string GetBoolArrayRenderString<T>( T value )
		{
			Type type = value.GetType( );
			byte[] buffer = null;
			if (type == typeof( byte ))          buffer = new byte[] { (byte)(object)value };
			else if (type == typeof( short ))    buffer = BitConverter.GetBytes( (short)(object)value );
			else if (type == typeof( ushort ))   buffer = BitConverter.GetBytes( (ushort)(object)value );
			else if (type == typeof( int ))      buffer = BitConverter.GetBytes( (int)(object)value );
			else if (type == typeof( uint ))     buffer = BitConverter.GetBytes( (uint)(object)value );
			else if (type == typeof( long ))     buffer = BitConverter.GetBytes( (long)(object)value );
			else if (type == typeof( ulong ))    buffer = BitConverter.GetBytes( (ulong)(object)value );
			else if (type == typeof( float ))    buffer = BitConverter.GetBytes( (float)(object)value );
			else if (type == typeof( double ))   buffer = BitConverter.GetBytes( (double)(object)value );

			if (buffer == null)
				return $"{value}";
			else
			{
				StringBuilder stringBuilder = new StringBuilder( );
				bool[] bools = HslCommunication.BasicFramework.SoftBasic.ByteToBoolArray( buffer );
				for (int i = 0; i < bools.Length; i++)
				{
					if (i != 0 && i % 8 == 0) stringBuilder.Append( " " );
					stringBuilder.Append( bools[i] ? '1' : '0' );
				}
				return stringBuilder.ToString( );
			}
		}

		private int getRenderResult( )
		{
			if (radioButton_read_hex.Checked) return 1;
			else if (radioButton_read_bit.Checked) return 2;
			else return -1;
		}

		private async void button_read_bool_Click( object sender, EventArgs e )
		{
			// bool
			if (isAsync)
			{
				button_read_bool.Enabled = false;
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ) )
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
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
			if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
			{
				RenderReadResult( DateTime.Now, (OperateResult<byte>)readByteMethod.Invoke( readWriteNet, new object[] { textBox3.Text } ), renderResult: getRenderResult( ) );
				GetReadCode( textBox3.Text, "OperateResult<byte> read = @deviceName.ReadByte( \"" + textBox3.Text + "\" );", isArray: false );
			}
			else
			{
				RenderReadResult( DateTime.Now, readWriteNet.Read( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt16Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<short> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<short[]> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_short.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt16( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<short> read = @deviceName.ReadInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt16Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort[]> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_ushort.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt16( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ushort> read = @deviceName.ReadUInt16( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ) , renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt32Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<int> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ) , renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<int[]> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_int.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt32( textBox3.Text ) , renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<int> read = @deviceName.ReadInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ) , renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt32Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<uint> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<uint[]> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_uint.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt32( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<uint> read = @deviceName.ReadUInt32( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt64Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<long> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<long[]> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_long.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt64( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<long> read = @deviceName.ReadInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt64Async( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, await readWriteNet.ReadUInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong[]> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\", " + textBox5.Text + " );", isArray: true );
				}
				button_read_ulong.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt64( textBox3.Text ), renderResult: getRenderResult( ) );
					GetReadCode( textBox3.Text, "OperateResult<ulong> read = @deviceName.ReadUInt64( \"" + textBox3.Text + "\" );", isArray: false );
				}
				else
				{
					RenderReadResult( DateTime.Now, readWriteNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), renderResult: getRenderResult( ) );
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
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
				if (textBox5.Text == "1" || string.IsNullOrEmpty( textBox5.Text ))
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
				DateTime start = DateTime.Now;
				OperateResult<string> read = await readWriteNet.ReadStringAsync( textBox3.Text, ushort.Parse( textBox1.Text ), DemoUtils.GetEncodingFromIndex( comboBox_read_encoding.SelectedIndex ) );
				if (read.IsSuccess && read.Content != null && read.Content.Contains( "\0" )) read.Content = read.Content.Replace( "\0", "\\0" );
				RenderReadResult( start, read );
				button_read_string.Enabled = true;
				GetReadCode( textBox3.Text, "OperateResult<string> read = @deviceName.ReadString( \"" + textBox3.Text + "\", " + textBox1.Text + ", " + DemoUtils.GetEncodingTextFromIndex( comboBox_read_encoding.SelectedIndex ) + " );", isArray: false );
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult<string> read = readWriteNet.ReadString( textBox3.Text, ushort.Parse( textBox1.Text ), DemoUtils.GetEncodingFromIndex( comboBox_read_encoding.SelectedIndex ) );
				if (read.IsSuccess && read.Content != null && read.Content.Contains( "\0" )) read.Content = read.Content.Replace( "\0", "\\0" );
				RenderReadResult( start, read );
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

		private bool TransBoolValue( string value )
		{
			value = value.Trim( );
			if (value == "1") return true;
			if (value == "0") return false;
			if (value.Equals( "On", StringComparison.OrdinalIgnoreCase )) return true;
			if (value.Equals( "Off", StringComparison.OrdinalIgnoreCase )) return false;
			return bool.Parse( value );
		}

		private async void button_write_bool_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// bool
			if (input.StartsWith("[") && input.EndsWith( "]" ))
			{
				try
				{
					bool[] value = input.ToStringArray<bool>( TransBoolValue );
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
					DemoUtils.ShowMessage( "Bool Data is not corrent: " + input + Environment.NewLine + ex.Message );
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
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", " + input.ToLower( ) + " );" );
					}
					else
					{
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_bool, input );
						GetWriteCode( textBox_write_address.Text, "OperateResult write = @deviceName.Write( \"" + textBox_write_address.Text + "\", " + input.ToLower( ) + " );" );
					}
				}
				else
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "Bool Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private bool TryGetByteValue( string input, out byte value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (byte.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (input.StartsWith( "-" ))
			{
				if (sbyte.TryParse( input, out sbyte result ))
				{
					value = (byte)result;
					return true;
				}
			}
			else if (byte.TryParse( input, out value )) return true;

			value = 0;
			return false;
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

					GetWriteArrayCode( textBox_write_address.Text, value, "byte" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "byte Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				// byte，此处演示了基于反射的写入操作
				if (TryGetByteValue( input, out byte value ))
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
					DemoUtils.ShowMessage( "Byte Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private T[] GetArrayFromString<T>( string value, Func<long, int, T> funcAdd )
		{
			if (Regex.IsMatch( value, @"\[[-]?[0-9]+:[-]?[0-9]+\]" ))
			{
				MatchCollection mc = Regex.Matches( value, "[-]?[0-9]+" );
				long start = long.Parse( mc[0].Value );
				long end = long.Parse( mc[1].Value );

				T[] buffer = new T[Math.Abs(end - start) + 1];
				bool plus = start < end;
				for (int i = 0; i < buffer.Length; i++)
				{
					if (plus)
						buffer[i] = funcAdd( start, i );
					else
						buffer[i] = funcAdd( start, -i );
				}
				return buffer;
			}
			else if (Regex.IsMatch( value, @"\[[-]?[0-9]+\*[0-9]+\]" ))
			{
				MatchCollection mc = Regex.Matches( value, "[-]?[0-9]+" );
				long number = long.Parse( mc[0].Value );
				long repeat = long.Parse( mc[1].Value );

				T[] buffer = new T[repeat];
				for (int i = 0; i < buffer.Length; i++)
				{
					buffer[i] = funcAdd( number, 0 );
				}
				return buffer;
			}
			else
				return value.ToStringArray<T>( );
		}

		private bool try_get_short_value( string input, out short value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (short.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (short.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_short_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// short
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					short[] value = GetArrayFromString( input, ( m, n ) => (short)(m + n) );
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_short, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_short, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "short" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "short Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_short_value( input, out short value ))
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
					DemoUtils.ShowMessage( "short Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private bool try_get_ushort_value( string input, out ushort value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (ushort.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (ushort.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_ushort_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// ushort
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					ushort[] value = GetArrayFromString( input, ( m, n ) => (ushort)(m + n) ); ;
					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ushort, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ushort, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "ushort" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "ushort Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_ushort_value( input, out ushort value ))
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
					DemoUtils.ShowMessage( "ushort Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private bool try_get_int_value( string input, out int value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (int.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (int.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_int_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// int
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					int[] value = GetArrayFromString( input, ( m, n ) => (int)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_int, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_int, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "int" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "int Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_int_value( input, out int value ))
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
					DemoUtils.ShowMessage( "int Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}
		
		private bool try_get_uint_value( string input, out uint value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (uint.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (uint.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_uint_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// uint
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					uint[] value = GetArrayFromString( input, ( m, n ) => (uint)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_uint, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_uint, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "uint" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "uint Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_uint_value( input, out uint value ))
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
					DemoUtils.ShowMessage( "uint Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private bool try_get_long_value( string input, out long value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (long.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (long.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_long_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// long
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					long[] value = GetArrayFromString( input, ( m, n ) => (long)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_long, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_long, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "long" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "long Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_long_value( input, out long value ))
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
					DemoUtils.ShowMessage( "long Data is not corrent: " + input );
				}
			}

			if (checkBox_write_timer.Checked) this.button_write_timer = sender as Button;
		}

		private bool try_get_ulong_value( string input, out ulong value )
		{
			if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
			{
				if (ulong.TryParse( input.Substring( 2 ), NumberStyles.HexNumber, null, out value )) return true;
			}
			else if (ulong.TryParse( input, out value )) return true;
			value = 0;
			return false;
		}

		private async void button_write_ulong_Click( object sender, EventArgs e )
		{
			string input = GetWriteValueText( );
			// ulong
			if (input.StartsWith( "[" ) && input.EndsWith( "]" ))
			{
				try
				{
					ulong[] value = GetArrayFromString( input, ( m, n ) => (ulong)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_ulong, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_ulong, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "ulong" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "ulong Data is not corrent: " + input + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (try_get_ulong_value( input, out ulong value ))
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
					DemoUtils.ShowMessage( "ulong Data is not corrent: " + input );
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
					float[] value = GetArrayFromString( input, ( m, n ) => (float)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_float, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_float, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "float" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "float Data is not corrent: " + input + Environment.NewLine + ex.Message );
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
					DemoUtils.ShowMessage( "float Data is not corrent: " + input );
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
					double[] value = GetArrayFromString( input, ( m, n ) => (double)(m + n) );

					if (isAsync)
						await RenderWriteResult( ( ) => readWriteNet.WriteAsync( textBox_write_address.Text, value ), button_write_double, input );
					else
						RenderWriteResult( ( ) => readWriteNet.Write( textBox_write_address.Text, value ), button_write_double, input );

					GetWriteArrayCode( textBox_write_address.Text, value, "double" );
				}
				catch (Exception ex)
				{
					if (checkBox_write_timer.Checked) checkBox_write_timer.Checked = false;
					DemoUtils.ShowMessage( "float Data is not corrent: " + input + Environment.NewLine + ex.Message );
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
					DemoUtils.ShowMessage( "double Data is not corrent: " + input );
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
			if (deviceImage != null)
				monitor.SetProtocolImage( this.deviceImage );
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
				sb.Append( ".ToArrayString( ) );" );
			else
				sb.Append( " );" );
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
			{
				if (input.StartsWith( "0x", StringComparison.OrdinalIgnoreCase ))
					GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", " + type + ".Parse( \"" + input.Substring( 2 ) + "\", NumberStyles.HexNumber ) );" );
				else
					GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", " + type + ".Parse( \"" + input + "\" ) );" );
			}
		}

		private void GetWriteArrayCode<T>( string address, T[] values, string type )
		{
			StringBuilder stringBuilder = new StringBuilder( );
			stringBuilder.Append( "new " );
			stringBuilder.Append( type );
			stringBuilder.Append( "[] { " );
			if (values != null && values.Length > 0)
			{
				for (int i = 0; i < values.Length; i++)
				{
					if (i > 0) stringBuilder.Append( "," );
					stringBuilder.Append( values[i].ToString( ) );
				}
			}
			stringBuilder.Append( " }" );
			GetWriteCode( address, "OperateResult write = @deviceName.Write( \"" + address + "\", " + stringBuilder.ToString( ) + ");" );
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
			sb.Append( Environment.NewLine );
			sb.Append( "    Console.WriteLine( \"Write [" + address + "] failed: \" + write.Message );" );
			sb.Append( Environment.NewLine );
			sb.Append( "}" );

			MethodCodeClick?.Invoke( readWriteNet, sb.ToString( ) );
		}

		private bool read_search_entered = false;
		private int find_index = -1;
		private string find_string = string.Empty;


		private void textBox_read_search_MouseClick( object sender, MouseEventArgs e )
		{
			if (read_search_entered == false)
			{
				read_search_entered = true;

				textBox_read_search.Text = string.Empty;
				textBox_read_search.ForeColor = Color.Black;
			}
		}

		private void textBox_read_search_TextChanged( object sender, EventArgs e )
		{

		}

		private void textBox_read_search_Leave( object sender, EventArgs e )
		{
			if (read_search_entered && textBox_read_search.Text == string.Empty)
			{
				textBox_read_search.Text = Program.Language == 1 ? "搜索内容" : "Search";
				textBox_read_search.ForeColor = Color.Silver;
				read_search_entered = false;
			}
		}

		private void button_find_string_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox_read_search.Text ))
			{
				// 复原信息
				find_index = -1;
				find_string = string.Empty;
			}
			else
			{
				if (find_string != textBox_read_search.Text)
				{
					find_index = -1;
					find_string = textBox_read_search.Text;
				}

				int index = textBox4.Text.IndexOf( find_string, find_index < 0 ? 0 : find_index );
				if (index < 0)
				{
					find_index = -1;
					DemoUtils.ShowMessage( Program.Language == 1 ? "全部查找完毕，再次Enter键重新查找" : "All search is complete, Enter again to find again" );
				}
				else
				{
					int length = find_string.Length;
					textBox4.Select( index, length );
					textBox4.Focus( );
					textBox4.ScrollToCaret( );
					find_index = index + length;
				}
			}
		}
	}
}
