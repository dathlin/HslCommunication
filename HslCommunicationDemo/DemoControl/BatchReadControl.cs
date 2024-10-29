using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.Device;
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

namespace HslCommunicationDemo.DemoControl
{
	public partial class BatchReadControl : UserControl
	{
		public BatchReadControl( )
		{
			InitializeComponent( );

			button_read_word.Visible = false;
			button_read_random.Visible = false;
			if (this.isSourceReadMode)
			{
				button_write.Visible = false;
			}
			if (Program.Language == 2)
			{
				label_address.Text = "Address:";
				label_length.Text = "Length:";
				label_result.Text = "Result:";

				if (this.isSourceReadMode)
				{
					button_read.Text = "r-Message";
				}
				else
				{
					button_read.Text = "r-Batch";
					button_write.Text = "w-Batch";
				}
				label3.Text = "Search:";
				button_search.Text = "Search";
				button_read_random.Text = "r-random";
				button_read_word.Text = "random-word";

				label1.Text = "Byte Len: ";
				label2.Text = "TimeCount: ";
				label4.Text = get_selected( );

				label_code.Text = "Code:";
				checkBox1.Text = "RegularExp";
				checkBox_word_reverse.Text = "R-Word";
			}


			button_read.Click += Button_read_Click;
			button_write.Click += Button_write_Click;
			button_search.Click += Button_search_Click;
			textBox_search.TextChanged += TextBox_search_TextChanged;

			button_read_random.Click += Button_read_random_Click;
			button_read_word.Click += Button_read_word_Click;

			button_read.MouseEnter += Button_read_MouseEnter;
			button_read.MouseLeave += Button_read_MouseLeave;
			label_tips.Text = GetTips( string.Empty );

			button_read_random.MouseEnter += Button_read_random_MouseEnter;
			button_read_random.MouseLeave += Button_read_MouseLeave;

			button_read_word.MouseEnter += Button_read_word_MouseEnter;
			button_read_word.MouseLeave += Button_read_MouseLeave;

			textBox_result.MouseDown += TextBox_result_MouseDown;
			textBox_result.MouseMove += TextBox_result_MouseMove;
			textBox_result.MouseUp += TextBox_result_MouseUp;

			comboBox1.SelectedIndex = 0;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			checkBox_word_reverse.CheckedChanged += CheckBox_word_reverse_CheckedChanged;
		}

		private void CheckBox_word_reverse_CheckedChanged( object sender, EventArgs e )
		{
			RenderReadBytes( this.buffer );
		}

		private string get_selected( )
		{
			if (Program.Language == 2) return "Selected: ";
			else return "已选择：";
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			RenderReadBytes( this.buffer );
		}


		private bool isMouseMove = false;

		private void TextBox_result_MouseMove( object sender, MouseEventArgs e )
		{
			if (isMouseMove)
			{
				int searchIndex = textBox_result.SelectionStart;
				if (textBox_result.SelectionLength > 0)
				{
					int selsectIndex = comboBox1.SelectedIndex;

					if (selsectIndex == 0)
						label4.Text = get_selected( ) + (searchIndex / 3) + " Len: " + textBox_result.SelectedText.ToHexBytes( ).Length;
					else
						label4.Text = get_selected( ) + searchIndex + " Len: " + textBox_result.SelectedText.Length;
				}
			}
		}

		private void TextBox_result_MouseDown( object sender, MouseEventArgs e )
		{
			isMouseMove = true;
		}

		private void TextBox_result_MouseUp( object sender, MouseEventArgs e )
		{
			isMouseMove = false;
		}

		private string GetTips( string tips )
		{
			string head = Program.Language == 1 ? "提示: " : "Tips: ";
			if (!string.IsNullOrEmpty( tips ))
				return head + tips;
			else
				return head;
		}

		private void Button_read_word_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( buttonTips3 );
		}

		private void Button_read_random_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( buttonTips2 );
		}

		private void Button_read_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( buttonTips1 );
		}

		private void Button_read_MouseLeave( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( string.Empty );
		}

		private void BatchReadControl_Load( object sender, EventArgs e )
		{
		}


		private void TextBox_search_TextChanged( object sender, EventArgs e )
		{
			index = 0;
		}

		int index = 0;
		private string lastRegexPatter = string.Empty;
		private int lastRegexIndex = 0;

		private void Button_search_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox_search.Text ))
			{
				index = 0;
				return;
			}

			if (checkBox1.Checked)
			{
				// 使用正则的表达式
				if (textBox_search.Text != lastRegexPatter)
				{
					lastRegexIndex = 0;
					lastRegexPatter = textBox_search.Text;
				}

				MatchCollection mc = Regex.Matches( textBox_result.Text, textBox_search.Text );
				if (mc.Count == 0)
				{
					index = 0;
					DemoUtils.ShowMessage( Program.Language == 2 ? "None find" : "没有查询到" );
				}
				else
				{
					if (lastRegexIndex >= mc.Count)
					{
						DemoUtils.ShowMessage( Program.Language == 2 ? "No more find, start search again" : "已经查询到末尾，没有发现更多的，再次点击重新查询" );
						lastRegexIndex = 0;
						return;
					}

					Match match = mc[lastRegexIndex];
					index = match.Index + 1;
					textBox_result.Select( match.Index, match.Length );
					// 每隔3减1
					label_index.Text = "Index:" + (match.Index - match.Index / 3);
					textBox_result.Focus( );

					lastRegexIndex++;
				}
			}
			else
			{
				// 查看读取的字符串信息
				int searchIndex = textBox_result.Text.IndexOf( textBox_search.Text, index );
				if (searchIndex < 0)
				{
					index = 0;
					DemoUtils.ShowMessage( Program.Language == 2 ? "None find" : "没有查询到" );
				}
				else
				{
					index = searchIndex + 1;
					textBox_result.Select( searchIndex, textBox_search.Text.Length );
					// 每隔3减1
					label_index.Text = "Index:" + (searchIndex - searchIndex / 3);
					textBox_result.Focus( );
				}
			}
		}

		private void RenderReadBytes( byte[] buffer )
		{
			if (checkBox_word_reverse.Checked) buffer = SoftBasic.BytesReverseByWord( buffer );
			int selectIndex = comboBox1.SelectedIndex;
			if (selectIndex == 0)
			{
				textBox_result.Text = buffer.ToHexString( ' ' );
			}
			else if (selectIndex == 1)
			{
				textBox_result.Text = SoftBasic.GetAsciiStringRender( buffer );
			}
			else if (selectIndex == 2)
			{
				textBox_result.Text = buffer.ToArrayString<byte>( );
			}
			else if (selectIndex == 3)
			{
				short[] value = readWriteNet.ByteTransform.TransInt16( buffer, 0, buffer.Length / 2 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 4)
			{
				ushort[] value = readWriteNet.ByteTransform.TransUInt16( buffer, 0, buffer.Length / 2 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 5)
			{
				int[] value = readWriteNet.ByteTransform.TransInt32( buffer, 0, buffer.Length / 4 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 6)
			{
				uint[] value = readWriteNet.ByteTransform.TransUInt32( buffer, 0, buffer.Length / 4 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 7)
			{
				float[] value = readWriteNet.ByteTransform.TransSingle( buffer, 0, buffer.Length / 4 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 8)
			{
				double[] value = readWriteNet.ByteTransform.TransDouble( buffer, 0, buffer.Length / 8 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 9)
			{
				long[] value = readWriteNet.ByteTransform.TransInt64( buffer, 0, buffer.Length / 8 );
				textBox_result.Text = value.ToArrayString( );
			}
			else if (selectIndex == 10)
			{
				ulong[] value = readWriteNet.ByteTransform.TransUInt64( buffer, 0, buffer.Length / 8 );
				textBox_result.Text = value.ToArrayString( );
			}
		}

		private void RenderReadResult( OperateResult<byte[]> read, TimeSpan cost )
		{
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "read failed: " + read.ToMessageShowString( ) );
			}

			string timeCount = cost.TotalMilliseconds.ToString( "F0" );
			label2.Text = (Program.Language == 1 ? "耗时：" : "TimeCount: ") + timeCount + " ms";

			if (read.IsSuccess)
			{
				this.buffer = read.Content;
				label1.Text = (Program.Language == 1 ? "字节数: " : "Byte Len: ") + read.Content?.Length.ToString( );
				RenderReadBytes( read.Content );
			}
		}

		private void Button_read_Click( object sender, EventArgs e )
		{
			if (button_read.Tag is Func<byte[], OperateResult<byte[]>> readFunc)
			{
				// 读取完整的报文
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readFunc( textBox_address.Text.ToHexBytes( ) );
				RenderReadResult( read, DateTime.Now - start );

				textBox_code.Text = $"OperateResult<byte[]> read = {variableName}.ReadFromCoreServer( \"{textBox_address.Text}\".ToHexBytes( ), true, false );  // 完整的报文";
			}
			else
			{
				if (readWriteNet == null)
				{
					DemoUtils.ShowMessage( "Current operate not success! readWriteNet is null" );
					return;
				}

				if (!ushort.TryParse( textBox_length.Text, out ushort len ))
				{
					DemoUtils.ShowMessage( "Length input wrong! " );
					return;
				}
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readWriteNet.Read( textBox_address.Text, len );
				RenderReadResult( read, DateTime.Now - start );
				textBox_code.Text = $"OperateResult<byte[]> read = {variableName}.Read( \"{textBox_address.Text}\", {len} );";
			}
		}

		private void Button_write_Click( object sender, EventArgs e )
		{
			if (readWriteNet == null)
			{
				DemoUtils.ShowMessage( "Current operate not success! readWriteNet is null" );
				return;
			}

			int selectIndex = comboBox1.SelectedIndex;
			if (selectIndex == 0)
			{
				buffer = textBox_result.Text.ToHexBytes( );
			}
			else if (selectIndex == 1)
			{
				buffer = SoftBasic.GetFromAsciiStringRender( textBox_result.Text );
			}
			else if (selectIndex == 2)
			{
				buffer = textBox_result.Text.ToStringArray<byte>( );
			}
			else if (selectIndex == 3)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<short>( ) );
			}
			else if (selectIndex == 4)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<ushort>( ) );
			}
			else if (selectIndex == 5)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<int>( ) );
			}
			else if (selectIndex == 6)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<uint>( ) );
			}
			else if (selectIndex == 7)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<float>( ) );
			}
			else if (selectIndex == 8)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<double>( ) );
			}
			else if (selectIndex == 9)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<long>( ) );
			}
			else if (selectIndex == 10)
			{
				buffer = readWriteNet.ByteTransform.TransByte( textBox_result.Text.ToStringArray<ulong>( ) );
			}

			if (buffer == null)
			{
				DemoUtils.ShowMessage( "data is empty!" );
				return;
			}

			DateTime start = DateTime.Now;
			OperateResult write = readWriteNet.Write( textBox_address.Text, buffer );

			string timeCount = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" );
			label2.Text = (Program.Language == 1 ? "耗时：" : "TimeCount: ") + timeCount + " ms";

			if (!write.IsSuccess)
			{
				DemoUtils.ShowMessage( "write failed: " + write.ToMessageShowString( ) );
			}
			else
			{
				DemoUtils.ShowMessage( "write success!" );
			}

			// 显示回写的代码
			textBox_code.Text = $"OperateResult write = {variableName}.Write( \"{textBox_address.Text}\", \"{buffer.ToHexString( ' ' )}\".ToHexBytes( ) );";
		}

		private void Button_read_random_Click( object sender, EventArgs e )
		{
			if (button_read_random.Tag is Func<byte[], OperateResult<byte[]>> readFunc)
			{
				// 读取报文
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readFunc( textBox_address.Text.ToHexBytes( ) );
				RenderReadResult( read, DateTime.Now - start );

				// 读取普通报文
				textBox_code.Text = $"OperateResult<byte[]> read = {variableName}.ReadFromCoreServer( \"{textBox_address.Text}\".ToHexBytes( ) );";
			}
			else if (this.readRandom != null)
			{
				string[] address = textBox_address.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries );
				ushort[] length = textBox_length.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ).Select( m => ushort.Parse( m ) ).ToArray( );

				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = this.readRandom( address, length );
				RenderReadResult( read, DateTime.Now - start );


				// 这里还得反射一下
				textBox_code.Text = $"OperateResult<byte[]> read = {variableName}.{this.readRandom.Method.Name}( " +
					$"new string[] {{{address.ToArrayString( "\"{0}\"" ).Trim( new char[] { '[', ']' } )}}}, " +
					$"new ushort[] {{{length.ToArrayString( ).Trim( new char[] { '[', ']' } )}}} );";
			}
		}

		private void Button_read_word_Click( object sender, EventArgs e )
		{
			if (button_read_word.Tag is Func<byte[], OperateResult<byte[]>> readFunc)
			{
				// 读取报文
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readFunc( textBox_address.Text.ToHexBytes( ) );
				RenderReadResult( read, DateTime.Now - start );


			}
			else if (this.readWordRandom != null)
			{
				string[] address = textBox_address.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries );
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = this.readWordRandom( address );
				RenderReadResult( read, DateTime.Now - start );

				// 这里还得反射一下
				textBox_code.Text = $"OperateResult<byte[]> read = {variableName}.{this.readWordRandom.Method.Name}( new string[] {{{address.ToArrayString("\"{0}\"").Trim( new char[] {'[',']'} )}}} );";
				//GetTips( string.Empty );
			}
		}

		/// <summary>
		/// 设置当前的通信对象信息
		/// </summary>
		/// <param name="device">通信对象信息</param>
		/// <param name="address">默认的地址信息</param>
		/// <param name="tips">默认提示的消息内容</param>
		public void SetReadWriteNet( DeviceCommunication device, string address, string tips )
		{
			this.readWriteNet = device;
			this.textBox_address.Text = address;
			this.buttonTips1 = tips;
		}

		/// <summary>
		/// 设置随机读取的方式
		/// </summary>
		/// <param name="read">随机读取的方法</param>
		/// <param name="tips">默认提示的地址信息</param>
		public void SetReadRandom( Func<string[], ushort[], OperateResult<byte[]>> read, string tips )
		{
			button_read_random.Visible = true;
			this.readRandom = read;
			this.buttonTips2 = (Program.Language == 1 ? "随机读取，输入多个地址及长度信息，';'间隔，例如：" : "Random reading, enter multiple address and length information, ';'Intervals, for example:") + tips;
		}

		/// <summary>
		/// 设置随机字读取的方式
		/// </summary>
		/// <param name="read">随机字读取的方法</param>
		/// <param name="tips">默认提示的地址信息</param>
		public void SetReadWordRandom( Func<string[], OperateResult<byte[]>> read, string tips )
		{
			button_read_word.Visible = true;
			this.readWordRandom = read;
			this.buttonTips3 = tips; 
			this.buttonTips2 = (Program.Language == 1 ? "随机字读取，输入多个地址，';'间隔，例如：" : "Random word reading, enter multiple address, ';'Intervals, for example:") + tips;
		}

		/// <summary>
		/// 将当前的控件设置为报文读取的方式
		/// </summary>
		/// <param name="read">报文读取的方法</param>
		/// <param name="buttomName">按钮的名称</param>
		/// <param name="tips">默认提示的文本信息</param>
		public void SetReadSourceBytes( Func<byte[], OperateResult<byte[]>> read, string buttomName, string tips )
		{
			if (string.IsNullOrEmpty( buttomName ))
			{
				this.button_read.Tag = read;
				this.buttonTips1 = Program.Language == 1 ? "请输入完整的二进制报文，全部的报文信息" : "Please enter the complete binary message, all the message information";
				if (!string.IsNullOrEmpty( tips ))
					this.textBox_address.Text = tips;
			}
			else if (button_read_random.Tag == null)
			{
				this.button_read_random.Visible = true;
				this.button_read_random.Text = buttomName;
				this.button_read_random.Tag = read;
				this.buttonTips2 = tips;
			}
			else if (button_read_word.Tag == null)
			{
				this.button_read_word.Visible = true;
				this.button_read_word.Text = buttomName;
				this.button_read_word.Tag = read;
				this.buttonTips3 = tips;
			}
		}

		public void SetVariableName( string name )
		{
			this.variableName = name;
		}

		/// <summary>
		/// 获取或设置当前是否报文读取的模式
		/// </summary>
		[Browsable(true)]
		[Description( "获取或设置当前是否报文读取的模式" )]
		public bool IsSourceReadMode
		{
			get => this.isSourceReadMode;
			set
			{
				this.isSourceReadMode = value;
				if (value)
				{
					label_length.Visible = false;
					textBox_length.Visible = false;

					textBox_address.Text = "";
					textBox_address.Width = textBox_result.Width;
					label_address.Text = Program.Language == 1 ? "报文:" : "Message:";
					button_read.Text = Program.Language == 1 ? "完整报文" : "r-Message";
					button_write.Visible = false;


					textBox_address.Multiline = true;
					textBox_address.Height = 23 + 40;
					textBox_address.ScrollBars = ScrollBars.Vertical;
					textBox_result.Location = new Point( 56, 54 + 40 );
					label_result.Location = new Point( 3, 54 + 40 );
					label_tips.Location = new Point( 53, 32 + 40 );
					textBox_result.Size = new Size( this.Width - (845 - 683), this.Height - (318 - 191) - 40 );
				}
				else
				{
					label_length.Visible = true;
					textBox_length.Visible = true;

					textBox_address.Width = textBox_result.Width - (683 - 412);
					label_address.Text = Program.Language == 1 ? "地址:" : "Address:";
					button_read.Text = Program.Language == 1 ? "批量读取" : "Batch Read";

					label_tips.Location = new Point( 53, 32 );
					textBox_address.Height = 23;
					textBox_address.Multiline = false;
					textBox_address.ScrollBars = ScrollBars.None;

					label_result.Location = new Point( 3, 54 );
					textBox_result.Location = new Point( 56, 54 );
					textBox_result.Size = new Size( this.Width - (845 - 683), this.Height - (318 - 191) );
				}
			}
		}

		private bool isSourceReadMode = false;
		private Func<string[], ushort[], OperateResult<byte[]>> readRandom;
		private Func<string[], OperateResult<byte[]>> readWordRandom;
		private DeviceCommunication readWriteNet;
		private byte[] buffer;

		private string buttonTips1 = "";
		private string buttonTips2 = "";
		private string buttonTips3= "";

		private string variableName = "[变量名]";
	}
}
