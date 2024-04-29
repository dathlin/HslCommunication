using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;

namespace HslCommunicationDemo
{
	public partial class FormByteTransfer : HslFormContent
	{
		public FormByteTransfer( )
		{
			InitializeComponent( );

			comboBox1.SelectedIndex = 3;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			switch (comboBox1.SelectedIndex)
			{
				case 0: byteTransform.DataFormat = DataFormat.ABCD; break;
				case 1: byteTransform.DataFormat = DataFormat.BADC; break;
				case 2: byteTransform.DataFormat = DataFormat.CDAB; break;
				case 3: byteTransform.DataFormat = DataFormat.DCBA; break;
			}
		}

		private IByteTransform byteTransform = new RegularByteTransform( );

		private void button1_Click( object sender, EventArgs e )
		{
			byte[] buffer = null;
			RadioButton radioButton = null;

			try
			{
				if (radioButton1.Checked)
				{
					buffer = textBox_input.Text.ToStringArray<byte>( );
					radioButton = radioButton1;
				}
				else if(radioButton2.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<short>( ) );
					radioButton = radioButton2;
				}
				else if (radioButton3.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<ushort>( ) );
					radioButton = radioButton3;
				}
				else if (radioButton4.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<int>( ) );
					radioButton = radioButton4;
				}
				else if (radioButton5.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<uint>( ) );
					radioButton = radioButton5;
				}
				else if (radioButton6.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<long>( ) );
					radioButton = radioButton6;
				}
				else if (radioButton7.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<ulong>( ) );
					radioButton = radioButton7;
				}
				else if (radioButton8.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<float>( ) );
					radioButton = radioButton8;
				}
				else if (radioButton9.Checked)
				{
					buffer = byteTransform.TransByte( textBox_input.Text.ToStringArray<double>( ) );
					radioButton = radioButton9;
				}
				else if (radioButton_ascii.Checked)
				{
					buffer = Encoding.ASCII.GetBytes( textBox_input.Text );
					if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
					radioButton = radioButton_ascii;
				}
				else if (radioButton_unicode.Checked)
				{
					buffer = Encoding.Unicode.GetBytes( textBox_input.Text );
					if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
					radioButton = radioButton_unicode;
				}
				else if (radioButton_utf8.Checked)
				{
					buffer = Encoding.UTF8.GetBytes( textBox_input.Text );
					if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
					radioButton = radioButton_utf8;
				}
				else if (radioButton_utf32.Checked)
				{
					buffer = Encoding.UTF32.GetBytes( textBox_input.Text );
					if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
					radioButton = radioButton_utf32;
				}
				else if (radioButton_ansi.Checked)
				{
					buffer = Encoding.Default.GetBytes( textBox_input.Text );
					if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
					radioButton = radioButton_ansi;
				}
				else if (radioButton_dateTime_s.Checked)
				{
					DateTime dateTime = DateTime.Parse( textBox_datetime.Text );
					double timestamp = double.Parse( textBox_input.Text );
					radioButton = radioButton_dateTime_s;

					textBox2.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " [" + textBox_input.Text + "] [" + radioButton.Text.PadRight( 7, ' ' ) + "] Time " +
					dateTime.AddSeconds(timestamp).ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine );
					return;
				}
				else if (radioButton_gb2312.Checked)
				{
					buffer = Encoding.GetEncoding( "gb2312" ).GetBytes( textBox_input.Text );
					radioButton = radioButton_gb2312;
				}
				else if (radioButton_unicode_big.Checked)
				{
					buffer = Encoding.BigEndianUnicode.GetBytes( textBox_input.Text );
					radioButton = radioButton_unicode_big;
				}
				else if (radioButton_base64.Checked)
				{
					buffer = Convert.FromBase64String( textBox_input.Text );
					radioButton = radioButton_base64;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show( ex.Message );
				return;
			}


			textBox2.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " [" + textBox_input.Text + "] ["+ radioButton.Text.PadRight(7,' ') + "] Length[" + buffer.Length + "] " +
				HslCommunication.BasicFramework.SoftBasic.ByteToHexString( buffer, ' ' ) + Environment.NewLine);
			label_byte_count.Text = buffer == null ? "0" : buffer.Length.ToString( );

		}

		private void FormByteTransfer_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "ByteTransform Tools";
				label7.Text = "Input value:";
				label3.Text = "Integer:";
				label6.Text = "Float:";
				label8.Text = "String:";
				label1.Text = "Output:\r\n(Hex)";
				button1.Text = "Conver-byte[]";
				button2.Text = "Re-conversion";
				label5.Text = "DateTime:";
				label4.Text = "Byte Count:";
				label2.Text = "Start";
				button_open_file.Text = "Open File";
				button_save_file.Text = "Save File";
				button4.Text = "Calcu MD5";
				button5.Text = "ImageBase64";
			}
		}


		private void FormByteTransfer_Shown( object sender, EventArgs e )
		{
			textBox_input.Focus( );
		}

		private string GetRenderString<T>( Func<byte[], T[]> tarns )
		{
			byte[] buffer = SoftBasic.HexStringToBytes( textBox_input.Text );
			T[] array = tarns( buffer );
			return array.Length == 1 ? array[0].ToString( ) : array.ToArrayString( );
		}

		private string GetEncodingString( Func<byte[], string> encoding )
		{
			byte[] buffer = SoftBasic.HexStringToBytes( textBox_input.Text );
			if (checkBox_isStringReverseByWord.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
			return encoding( buffer );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			string value = string.Empty;
			RadioButton radioButton = null;

			try
			{
				if (radioButton1.Checked)
				{
					value = SoftBasic.HexStringToBytes( textBox_input.Text )[0].ToString( );
					radioButton = radioButton1;
				}
				else if (radioButton2.Checked)
				{
					value = GetRenderString( m => byteTransform.TransInt16( m, 0, m.Length / 2 ) );
					radioButton = radioButton2;
				}
				else if (radioButton3.Checked)
				{
					value = GetRenderString( m => byteTransform.TransUInt16( m, 0, m.Length / 2 ) );
					radioButton = radioButton3;
				}
				else if (radioButton4.Checked)
				{
					value = GetRenderString( m => byteTransform.TransInt32( m, 0, m.Length / 4 ) );
					radioButton = radioButton4;
				}
				else if (radioButton5.Checked)
				{
					value = GetRenderString( m => byteTransform.TransUInt32( m, 0, m.Length / 4 ) );
					radioButton = radioButton5;
				}
				else if (radioButton6.Checked)
				{
					value = GetRenderString( m => byteTransform.TransInt64( m, 0, m.Length / 8 ) );
					radioButton = radioButton6;
				}
				else if (radioButton7.Checked)
				{
					value = GetRenderString( m => byteTransform.TransUInt64( m, 0, m.Length / 8 ) );
					radioButton = radioButton7;
				}
				else if (radioButton8.Checked)
				{
					value = GetRenderString( m => byteTransform.TransSingle( m, 0, m.Length / 4 ) );
					radioButton = radioButton8;
				}
				else if (radioButton9.Checked)
				{
					value = GetRenderString( m => byteTransform.TransDouble( m, 0, m.Length / 8 ) );
					radioButton = radioButton9;
				}
				else if (radioButton_ascii.Checked)
				{
					value = GetEncodingString( Encoding.ASCII.GetString );
					radioButton = radioButton_ascii;
				}
				else if (radioButton_unicode.Checked)
				{
					value = GetEncodingString( Encoding.Unicode.GetString );
					radioButton = radioButton_unicode;
				}
				else if (radioButton_utf8.Checked)
				{
					value = GetEncodingString( Encoding.UTF8.GetString );
					radioButton = radioButton_utf8;
				}
				else if (radioButton_utf32.Checked)
				{
					value = GetEncodingString( Encoding.UTF32.GetString );
					radioButton = radioButton_utf32;
				}
				else if (radioButton_ansi.Checked)
				{
					value = GetEncodingString( Encoding.Default.GetString );
					radioButton = radioButton_utf32;
				}
				else if (radioButton_gb2312.Checked)
				{
					value = GetEncodingString( Encoding.GetEncoding( "gb2312" ).GetString );
					radioButton = radioButton_gb2312;
				}
				else if (radioButton_unicode_big.Checked)
				{
					value = GetEncodingString( Encoding.BigEndianUnicode.GetString );
					radioButton = radioButton_unicode_big;
				}
				else if (radioButton_base64.Checked)
				{
					value = Convert.ToBase64String( SoftBasic.HexStringToBytes( textBox_input.Text ) );
					radioButton = radioButton_base64;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
				return;
			}


			textBox2.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " [" + textBox_input.Text + "] [" + radioButton.Text.PadRight( 7, ' ' ) + "]  " +
				value + Environment.NewLine );
		}

		private void OpenFile( string filePath )
		{
			if (File.Exists( filePath ))
			{
				byte[] content = File.ReadAllBytes( filePath );
				label_byte_count.Text = content == null ? "0" : content.Length.ToString( );

				if (radioButton_base64.Checked)
					textBox2.Text = Convert.ToBase64String( content );
				else
					textBox2.Text = SoftBasic.ByteToHexString( content, ' ', 32 );
			}
			else
			{
				MessageBox.Show( $"File[{filePath}] not exist" );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			try
			{
				if (string.IsNullOrEmpty( textBox_input.Text ))
				{
					OpenFileDialog ofd = new OpenFileDialog( );
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						textBox_input.Text = ofd.FileName;
						OpenFile( ofd.FileName );
					}
				}
				else
				{
					OpenFile( textBox_input.Text );
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Open File Failed:" + ex.Message );
			}
		}

		private void button_save_file_Click( object sender, EventArgs e )
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog( );
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes( saveFileDialog.FileName, textBox2.Text.ToHexBytes( ) );
			}
		}

		private void textBox2_DragEnter( object sender, DragEventArgs e )
		{
			if (e.Data.GetDataPresent( DataFormats.FileDrop ))
			{
				e.Effect = DragDropEffects.Link;
				this.textBox_input.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）  
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox2_DragDrop( object sender, DragEventArgs e )
		{
			string fileName = ((System.Array)e.Data.GetData( DataFormats.FileDrop )).GetValue( 0 ).ToString( );
			textBox_input.Text = fileName;

			button3_Click( sender, e );
			this.textBox_input.Cursor = System.Windows.Forms.Cursors.IBeam; //还原鼠标形状
		}

		private void button4_Click( object sender, EventArgs e )
		{
			try
			{
				if (string.IsNullOrEmpty( textBox_input.Text ))
				{
					OpenFileDialog ofd = new OpenFileDialog( );
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						textBox_input.Text = ofd.FileName;
						DateTime dateTime = DateTime.Now;
						textBox2.Text = SoftBasic.CalculateFileMD5( ofd.FileName );
						textBox2.AppendText( Environment.NewLine + "Total Coust:" + (DateTime.Now - dateTime).TotalSeconds.ToString( "F2" ) + " s" );
					}
				}
				else
				{
					DateTime dateTime = DateTime.Now;
					textBox2.Text = SoftBasic.CalculateFileMD5( textBox_input.Text );
					textBox2.AppendText( Environment.NewLine + "Total Coust:" + (DateTime.Now - dateTime).TotalSeconds.ToString( "F2" ) + " s" );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Failed:" + ex.Message );
			}
		}

		private string PrintBase64( byte[] content )
		{
			int already = 0;
			string str = Convert.ToBase64String( content );
			StringBuilder sb = new StringBuilder( );
			while (already < str.Length)
			{
				int length = Math.Min( str.Length - already, 120 );
				sb.Append( str.Substring( already, length ) );
				already += length;
				if (already < str.Length)
				{
					sb.Append( Environment.NewLine );
				}
			}
			return sb.ToString( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			try
			{
				if (!string.IsNullOrEmpty( textBox_input.Text ))
				{
					if (File.Exists( textBox_input.Text ))
					{
						byte[] content = File.ReadAllBytes( textBox_input.Text );
						textBox2.Text = PrintBase64( content );
					}
				}
				else
				{
					if (Clipboard.ContainsImage( ))
					{
						using (MemoryStream ms = new MemoryStream( ))
						{
							Clipboard.GetImage( ).Save( ms, System.Drawing.Imaging.ImageFormat.Png );
							byte[] content = ms.ToArray( );
							textBox2.Text = PrintBase64( content );
						}
					}
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button_url_encode_Click( object sender, EventArgs e )
		{
			Encoding encoding = Encoding.UTF8;
			if (radioButton_ascii.Checked) encoding = Encoding.ASCII;
			else if (radioButton_unicode.Checked) encoding = Encoding.Unicode;
			else if (radioButton_utf8.Checked) encoding = Encoding.UTF8;
			else if (radioButton_utf32.Checked) encoding = Encoding.UTF32;
			else if (radioButton_ansi.Checked) encoding = Encoding.Default;
			else if (radioButton_gb2312.Checked) encoding = Encoding.GetEncoding( "gb2312" );
			else if (radioButton_unicode_big.Checked) encoding = Encoding.BigEndianUnicode;

			textBox2.Text = SoftBasic.UrlEncode( textBox_input.Text, encoding );
		}

		private void button_url_decode_Click( object sender, EventArgs e )
		{
			Encoding encoding = Encoding.UTF8;
			if (radioButton_ascii.Checked) encoding = Encoding.ASCII;
			else if (radioButton_unicode.Checked) encoding = Encoding.Unicode;
			else if (radioButton_utf8.Checked) encoding = Encoding.UTF8;
			else if (radioButton_utf32.Checked) encoding = Encoding.UTF32;
			else if (radioButton_ansi.Checked) encoding = Encoding.Default;
			else if (radioButton_gb2312.Checked) encoding = Encoding.GetEncoding( "gb2312" );
			else if (radioButton_unicode_big.Checked) encoding = Encoding.BigEndianUnicode;

			textBox2.Text = SoftBasic.UrlDecode( textBox_input.Text, encoding );
		}

	}
}
