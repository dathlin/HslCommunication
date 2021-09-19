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

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteOp : UserControl
	{
		public UserControlReadWriteOp( )
		{
			InitializeComponent( );
		}

		private string[] encodings = new string[]
			{
				"ASCII",
				"Unicode",
				"Unicode-big",
				"UTF8",
				"UTF32",
				"ANSI",
				"GB2312"
			};

		private Encoding GetEncodingFromIndex(int index )
		{
			switch (index)
			{
				case 0: return Encoding.ASCII;
				case 1: return Encoding.Unicode;
				case 2: return Encoding.BigEndianUnicode;
				case 3: return Encoding.UTF8;
				case 4: return Encoding.UTF32;
				case 5: return Encoding.Default;
				case 6: return Encoding.GetEncoding( "gb2312" );
				default: return Encoding.ASCII;
			}
		}

		private void UserControlReadWriteOp_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			
			comboBox_read_encoding.DataSource = encodings;
			comboBox_write_Encoding.DataSource = encodings;
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Curve Monitor";

				label6.Text = "address:";
				label7.Text = "result:";
				label8.Text = "length:";

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
				label19.Text = "Note: The value of the string needs to be converted\r\nif array：[1,2,3]";
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
			if (string.IsNullOrEmpty( textBox8.Text ))
				textBox8.Text = address;
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

		public string GetWriteAddress( ) => textBox8.Text;

		private string address = string.Empty;
		private IReadWriteNet readWriteNet;
		private bool isAsync = false;
		private MethodInfo readByteMethod = null;
		private MethodInfo writeByteMethod = null;

		private ValueLimit valueLimit = new ValueLimit( );

		private void SetTimeSpend( int millseconds )
		{
			valueLimit.SetNewValue( millseconds );
			label2.Text = $"{valueLimit.Current} ms";
			label3.Text = $"{valueLimit.MaxValue} ms";
			label5.Text = $"{valueLimit.MinValue} ms";
		}

		private async void button_read_bool_Click( object sender, EventArgs e )
		{
			// bool
			if (isAsync)
			{
				button_read_bool.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<bool> read = await readWriteNet.ReadBoolAsync( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<bool[]> read = await readWriteNet.ReadBoolAsync( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_bool.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<bool> read = readWriteNet.ReadBool( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<bool[]> read = readWriteNet.ReadBool( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private void button_read_byte_Click( object sender, EventArgs e )
		{
			// byte，此处演示了基于反射的读取操作
			DateTime start = DateTime.Now;
			OperateResult<byte> read = (OperateResult<byte>)readByteMethod.Invoke( readWriteNet, new object[] { textBox3.Text } );
			SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
			DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
		}

		private async void button_read_short_Click( object sender, EventArgs e )
		{
			// short
			if (isAsync)
			{
				button_read_short.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<short> read = await readWriteNet.ReadInt16Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<short[]> read = await readWriteNet.ReadInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_short.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<short> read = readWriteNet.ReadInt16( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<short[]> read = readWriteNet.ReadInt16( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_ushort_Click( object sender, EventArgs e )
		{
			// ushort
			if (isAsync)
			{
				button_read_ushort.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<ushort> read = await readWriteNet.ReadUInt16Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<ushort[]> read = await readWriteNet.ReadUInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) ); 
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_ushort.Enabled = true;
			}
			else
			{

				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<ushort> read = readWriteNet.ReadUInt16( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<ushort[]> read = readWriteNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_int_Click( object sender, EventArgs e )
		{
			// int
			if (isAsync)
			{
				button_read_int.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<int> read = await readWriteNet.ReadInt32Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<int[]> read = await readWriteNet.ReadInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) ); 
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_int.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<int> read = readWriteNet.ReadInt32( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<int[]> read = readWriteNet.ReadInt32( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_uint_Click( object sender, EventArgs e )
		{
			// uint
			if (isAsync)
			{
				button_read_uint.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<uint> read = await readWriteNet.ReadUInt32Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<uint[]> read = await readWriteNet.ReadUInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_uint.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<uint> read = readWriteNet.ReadUInt32( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<uint[]> read = readWriteNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_long_Click( object sender, EventArgs e )
		{
			// long
			if (isAsync)
			{
				button_read_long.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<long> read = await readWriteNet.ReadInt64Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<long[]> read = await readWriteNet.ReadInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_long.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<long> read = readWriteNet.ReadInt64( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<long[]> read = readWriteNet.ReadInt64( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_ulong_Click( object sender, EventArgs e )
		{
			// ulong
			if (isAsync)
			{
				button_read_ulong.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<ulong> read = await readWriteNet.ReadUInt64Async( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<ulong[]> read = await readWriteNet.ReadUInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_ulong.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<ulong> read = readWriteNet.ReadUInt64( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<ulong[]> read = readWriteNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_float_Click( object sender, EventArgs e )
		{
			// float
			if (isAsync)
			{
				button_read_float.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<float> read = await readWriteNet.ReadFloatAsync( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<float[]> read = await readWriteNet.ReadFloatAsync( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_float.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<float> read = readWriteNet.ReadFloat( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<float[]> read = readWriteNet.ReadFloat( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_double_Click( object sender, EventArgs e )
		{
			// double
			if (isAsync)
			{
				button_read_double.Enabled = false;
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<double> read = await readWriteNet.ReadDoubleAsync( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<double[]> read = await readWriteNet.ReadDoubleAsync( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				button_read_double.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
				{
					DateTime start = DateTime.Now;
					OperateResult<double> read = readWriteNet.ReadDouble( textBox3.Text );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
				else
				{
					DateTime start = DateTime.Now;
					OperateResult<double[]> read = readWriteNet.ReadDouble( textBox3.Text, ushort.Parse( textBox5.Text ) );
					SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
					DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
				}
			}
		}

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// string
			if (isAsync)
			{
				button_read_string.Enabled = false;
				DateTime start = DateTime.Now;
				DemoUtils.ReadResultRender( await readWriteNet.ReadStringAsync( textBox3.Text, ushort.Parse( textBox1.Text ), 
					GetEncodingFromIndex(comboBox_read_encoding.SelectedIndex) ), textBox3.Text, textBox4 );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				button_read_string.Enabled = true;
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult<string> read = readWriteNet.ReadString( textBox3.Text, ushort.Parse( textBox1.Text ), GetEncodingFromIndex( comboBox_read_encoding.SelectedIndex ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.ReadResultRender( read, textBox3.Text, textBox4 );
			}
		}

		private async void button24_Click( object sender, EventArgs e )
		{
			// bool
			if (textBox7.Text.StartsWith("[") && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					bool[] value = textBox7.Text.ToStringArray<bool>( );
					if (isAsync)
					{
						button_write_bool.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write , textBox8.Text );
						button_write_bool.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show( "Bool Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (bool.TryParse( textBox7.Text, out bool value ))
				{
					if (isAsync)
					{
						button_write_bool.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_bool.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "Bool Data is not corrent: " + textBox7.Text );
			}
		}

		private void button23_Click( object sender, EventArgs e )
		{
			// byte，此处演示了基于反射的写入操作
			if (byte.TryParse( textBox7.Text, out byte value ))
			{
				DateTime start = DateTime.Now;
				OperateResult write = (OperateResult)writeByteMethod.Invoke( readWriteNet, new object[] { textBox8.Text, value } );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.WriteResultRender( write, textBox8.Text );
			}
			else
				MessageBox.Show( "Byte Data is not corrent: " + textBox7.Text );
		}

		private async void button22_Click( object sender, EventArgs e )
		{
			// short
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					short[] value = textBox7.Text.ToStringArray<short>( );
					if (isAsync)
					{
						button_write_short.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_short.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "short Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (short.TryParse( textBox7.Text, out short value ))
				{
					if (isAsync)
					{
						button_write_short.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_short.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "short Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button21_Click( object sender, EventArgs e )
		{
			// ushort
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					ushort[] value = textBox7.Text.ToStringArray<ushort>( );
					if (isAsync)
					{
						button_write_ushort.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_ushort.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "ushort Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (ushort.TryParse( textBox7.Text, out ushort value ))
				{
					if (isAsync)
					{
						button_write_ushort.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_ushort.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "ushort Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button20_Click( object sender, EventArgs e )
		{
			// int
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					int[] value = textBox7.Text.ToStringArray<int>( );
					if (isAsync)
					{
						button_write_int.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_int.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "int Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (int.TryParse( textBox7.Text, out int value ))
				{
					if (isAsync)
					{
						button_write_int.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_int.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "int Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button19_Click( object sender, EventArgs e )
		{
			// uint
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					uint[] value = textBox7.Text.ToStringArray<uint>( );
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "uint Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (uint.TryParse( textBox7.Text, out uint value ))
				{
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "uint Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button18_Click( object sender, EventArgs e )
		{
			// long
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					long[] value = textBox7.Text.ToStringArray<long>( );
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "long Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (long.TryParse( textBox7.Text, out long value ))
				{
					if (isAsync)
					{
						button_write_long.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_long.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "long Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button17_Click( object sender, EventArgs e )
		{
			// ulong
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					ulong[] value = textBox7.Text.ToStringArray<ulong>( );
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "ulong Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (ulong.TryParse( textBox7.Text, out ulong value ))
				{
					if (isAsync)
					{
						button_write_ulong.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_ulong.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "ulong Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button16_Click( object sender, EventArgs e )
		{
			// float
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					float[] value = textBox7.Text.ToStringArray<float>( );
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "float Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (float.TryParse( textBox7.Text, out float value ))
				{
					if (isAsync)
					{
						button_write_float.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_float.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "float Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button15_Click( object sender, EventArgs e )
		{
			// double
			if (textBox7.Text.StartsWith( "[" ) && textBox7.Text.EndsWith( "]" ))
			{
				try
				{
					double[] value = textBox7.Text.ToStringArray<double>( );
					if (isAsync)
					{
						button_write_uint.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_uint.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "float Data is not corrent: " + textBox7.Text + Environment.NewLine + ex.Message );
				}
			}
			else
			{
				if (double.TryParse( textBox7.Text, out double value ))
				{
					if (isAsync)
					{
						button_write_double.Enabled = false;
						DateTime start = DateTime.Now;
						OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
						button_write_double.Enabled = true;
					}
					else
					{
						DateTime start = DateTime.Now;
						OperateResult write = readWriteNet.Write( textBox8.Text, value );
						SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
						DemoUtils.WriteResultRender( write, textBox8.Text );
					}
				}
				else
					MessageBox.Show( "double Data is not corrent: " + textBox7.Text );
			}
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			// string
			if (isAsync)
			{
				button_write_string.Enabled = false;
				DateTime start = DateTime.Now;
				OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, textBox7.Text, GetEncodingFromIndex(comboBox_write_Encoding.SelectedIndex) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.WriteResultRender( write, textBox8.Text );
				button_write_string.Enabled = true;
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult write = readWriteNet.Write( textBox8.Text, textBox7.Text, GetEncodingFromIndex( comboBox_write_Encoding.SelectedIndex ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.WriteResultRender( write, textBox8.Text );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			using (FormCurveMonitor monitor = new FormCurveMonitor( ))
			{
				monitor.SetReadWrite( readWriteNet, address );
				monitor.ShowDialog( );
			}
		}

		private async void button2_Click( object sender, EventArgs e )
		{
			// hex
			if (isAsync)
			{
				button_write_string.Enabled = false;
				DateTime start = DateTime.Now;
				OperateResult write = await readWriteNet.WriteAsync( textBox8.Text, textBox7.Text.ToHexBytes( ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.WriteResultRender( write, textBox8.Text );
				button_write_string.Enabled = true;
			}
			else
			{
				DateTime start = DateTime.Now;
				OperateResult write = readWriteNet.Write( textBox8.Text, textBox7.Text.ToHexBytes( ) );
				SetTimeSpend( Convert.ToInt32( (DateTime.Now - start).TotalMilliseconds ) );
				DemoUtils.WriteResultRender( write, textBox8.Text );
			}
		}
	}
}
