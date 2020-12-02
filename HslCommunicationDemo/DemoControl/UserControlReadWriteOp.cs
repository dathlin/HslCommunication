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

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteOp : UserControl
	{
		public UserControlReadWriteOp( )
		{
			InitializeComponent( );
		}

		private void UserControlReadWriteOp_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
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
				button24.Text = "Write Bit";
				button22.Text = "w-short";
				button21.Text = "w-ushort";
				button20.Text = "w-int";
				button19.Text = "w-uint";
				button18.Text = "w-long";
				button17.Text = "w-ulong";
				button16.Text = "w-float";
				button15.Text = "w-double";
				button14.Text = "w-string";
				button2.Text = "w-hex";

				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";

				button23.Text = "w-byte";
				button1.Text = "Curve Monitor";
			}
		}

		public void SetReadWriteNet( IReadWriteNet readWrite, string address, bool isAsync = false, int strLength = 10 )
		{
			this.isAsync = isAsync;
			this.address = address;
			textBox3.Text = address;
			textBox8.Text = address;
			textBox1.Text = strLength.ToString( );
			readWriteNet = readWrite;
			Type type = readWrite.GetType( );
			readByteMethod = type.GetMethod( "ReadByte", new Type[] { typeof(string) } );
			if (readByteMethod == null) button_read_byte.Enabled = false;

			try
			{
				writeByteMethod = type.GetMethod( "Write", new Type[] { typeof( string ), typeof( byte ) } );
				if (writeByteMethod == null) button23.Enabled = false;
			}
			catch
			{
				button23.Enabled = false;
			}
		}

		public string GetWriteAddress( ) => textBox8.Text;

		private string address = string.Empty;
		private IReadWriteNet readWriteNet;
		private bool isAsync = false;
		private MethodInfo readByteMethod = null;
		private MethodInfo writeByteMethod = null;

		private async void button_read_bool_Click( object sender, EventArgs e )
		{
			// bool
			if (isAsync)
			{
				button_read_bool.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadBoolAsync( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadBoolAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_bool.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadBool( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private void button_read_byte_Click( object sender, EventArgs e )
		{
			// byte，此处演示了基于反射的读取操作
			DemoUtils.ReadResultRender( (OperateResult<byte>)readByteMethod.Invoke( readWriteNet, new object[] { textBox3.Text } ), textBox3.Text, textBox4 );
		}

		private async void button_read_short_Click( object sender, EventArgs e )
		{
			// short
			if (isAsync)
			{
				button_read_short.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt16Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_short.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_ushort_Click( object sender, EventArgs e )
		{
			// ushort
			if (isAsync)
			{
				button_read_ushort.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt16Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt16Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_ushort.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_int_Click( object sender, EventArgs e )
		{
			// int
			if (isAsync)
			{
				button_read_int.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt32Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_int.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_uint_Click( object sender, EventArgs e )
		{
			// uint
			if (isAsync)
			{
				button_read_uint.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt32Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt32Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_uint.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_long_Click( object sender, EventArgs e )
		{
			// long
			if (isAsync)
			{
				button_read_long.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt64Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_long.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_ulong_Click( object sender, EventArgs e )
		{
			// ulong
			if (isAsync)
			{
				button_read_ulong.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt64Async( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadUInt64Async( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_ulong.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_float_Click( object sender, EventArgs e )
		{
			// float
			if (isAsync)
			{
				button_read_float.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadFloatAsync( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadFloatAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_float.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadFloat( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_double_Click( object sender, EventArgs e )
		{
			// double
			if (isAsync)
			{
				button_read_double.Enabled = false;
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( await readWriteNet.ReadDoubleAsync( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( await readWriteNet.ReadDoubleAsync( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
				button_read_double.Enabled = true;
			}
			else
			{
				if (textBox5.Text == "1")
					DemoUtils.ReadResultRender( readWriteNet.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
				else
					DemoUtils.ReadResultRender( readWriteNet.ReadDouble( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
			}
		}

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// string
			if (isAsync)
			{
				button_read_string.Enabled = false;
				DemoUtils.ReadResultRender( await readWriteNet.ReadStringAsync( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
				button_read_string.Enabled = true;
			}
			else
				DemoUtils.ReadResultRender( readWriteNet.ReadString( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
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
						button24.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button24.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button24.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button24.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
				DemoUtils.WriteResultRender( (OperateResult)writeByteMethod.Invoke( readWriteNet, new object[] { textBox8.Text, value } ), textBox8.Text );
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
						button22.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button22.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button22.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button22.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button21.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button21.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button21.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button21.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button20.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button20.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button20.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button20.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button18.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button18.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button17.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button17.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button16.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button16.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button19.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button19.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
						button15.Enabled = false;
						DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
						button15.Enabled = true;
					}
					else
						DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, value ), textBox8.Text );
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
				button14.Enabled = false;
				DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
				button14.Enabled = true;
			}
			else
				DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
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
				button14.Enabled = false;
				DemoUtils.WriteResultRender( await readWriteNet.WriteAsync( textBox8.Text, textBox7.Text.ToHexBytes( ) ), textBox8.Text );
				button14.Enabled = true;
			}
			else
				DemoUtils.WriteResultRender( readWriteNet.Write( textBox8.Text, textBox7.Text.ToHexBytes( ) ), textBox8.Text );
		}
	}
}
