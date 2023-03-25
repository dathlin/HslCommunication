using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

			if (Program.Language == 2)
			{
				label_address.Text = "Address:";
				label_length.Text = "Length:";
				label_result.Text = "Result:";

				if (this.isSourceReadMode)
					button_read.Text = "r-Message";
				else
					button_read.Text = "r-Batch";
				label3.Text = "Search:";
				button_search.Text = "Search";
				button_read_random.Text = "r-random";
				button_read_word.Text = "random-word";

				label1.Text = "Byte Len: ";
				label2.Text = "TimeCount: ";
			}


			button_read.Click += Button_read_Click;
			button_search.Click += Button_search_Click;
			textBox_search.TextChanged += TextBox_search_TextChanged;

			button_read_random.Click += Button_read_random_Click;
			button_read_word.Click += Button_read_word_Click;

			button_read.MouseEnter += Button_read_MouseEnter;
			button_read.MouseLeave += Button_read_MouseLeave;
			label_tips.Text = GetTips( );

			button_read_random.MouseEnter += Button_read_random_MouseEnter;
			button_read_random.MouseLeave += Button_read_MouseLeave;

			button_read_word.MouseEnter += Button_read_word_MouseEnter;
			button_read_word.MouseLeave += Button_read_MouseLeave;

			textBox_result.MouseDown += TextBox_result_MouseDown;
			textBox_result.MouseMove += TextBox_result_MouseMove;
			textBox_result.MouseUp += TextBox_result_MouseUp; ;
		}
		private bool isMouseMove = false;

		private void TextBox_result_MouseMove( object sender, MouseEventArgs e )
		{
			if (isMouseMove)
			{
				int searchIndex = textBox_result.SelectionStart;
				if (textBox_result.SelectionLength > 0)
				{
					if (radioButton_hex.Checked)
						label4.Text = "Select: " + (searchIndex / 3) + " Len: " + textBox_result.SelectedText.ToHexBytes( ).Length;
					else
						label4.Text = "Select: " + searchIndex + " Len: " + textBox_result.SelectedText.Length;
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

		private string GetTips( ) => Program.Language == 1 ? "提示: " : "Tips: ";

		private void Button_read_word_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( ) + buttonTips3;
		}

		private void Button_read_random_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( ) + buttonTips2;
		}

		private void Button_read_MouseEnter( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( ) + buttonTips1;
		}

		private void Button_read_MouseLeave( object sender, EventArgs e )
		{
			label_tips.Text = GetTips( );
		}

		private void BatchReadControl_Load( object sender, EventArgs e )
		{
		}


		private void TextBox_search_TextChanged( object sender, EventArgs e )
		{
			index = 0;
		}

		int index = 0;
		private void Button_search_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox_search.Text ))
			{
				index = 0;
				return;
			}

			// 查看读取的字符串信息
			int searchIndex = textBox_result.Text.IndexOf( textBox_search.Text, index );
			if (searchIndex < 0)
			{
				index = 0;
				MessageBox.Show( "None find" );
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

		private void RenderReadResult( OperateResult<byte[]> read, TimeSpan cost )
		{
			if (!read.IsSuccess)
			{
				MessageBox.Show( "read failed: " + read.Message );
			}

			string timeCount = cost.TotalMilliseconds.ToString( "F0" );
			label2.Text = (Program.Language == 1 ? "耗时：" : "TimeCount: ") + timeCount + " ms";

			if (read.IsSuccess)
			{
				this.buffer = read.Content;
				label1.Text = (Program.Language == 1 ? "字节数: " : "Byte Len: ") + read.Content?.Length.ToString( );
				if (radioButton_hex.Checked)
				{
					textBox_result.Text = read.Content.ToHexString( ' ' );
				}
				else
				{
					textBox_result.Text = SoftBasic.GetAsciiStringRender( read.Content );
				}
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
			}
			else
			{
				if (readWriteNet == null)
				{
					MessageBox.Show( "Current operate not success! readWriteNet is null" );
					return;
				}

				if (!ushort.TryParse( textBox_length.Text, out ushort len ))
				{
					MessageBox.Show( "Length input wrong! " );
					return;
				}
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readWriteNet.Read( textBox_address.Text, len );
				RenderReadResult( read, DateTime.Now - start );
			}

		}

		private void Button_read_random_Click( object sender, EventArgs e )
		{
			if (button_read_random.Tag is Func<byte[], OperateResult<byte[]>> readFunc)
			{
				// 读取报文
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = readFunc( textBox_address.Text.ToHexBytes( ) );
				RenderReadResult( read, DateTime.Now - start );
			}
			else if (this.readRandom != null)
			{
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = this.readRandom(
					textBox_address.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ),
					textBox_length.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ).Select( m => ushort.Parse( m ) ).ToArray( ) );
				RenderReadResult( read, DateTime.Now - start );
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
				DateTime start = DateTime.Now;
				OperateResult<byte[]> read = this.readWordRandom(
					textBox_address.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ) );
				RenderReadResult( read, DateTime.Now - start );
			}
		}

		/// <summary>
		/// 设置当前的通信对象信息
		/// </summary>
		/// <param name="device">通信对象信息</param>
		/// <param name="address">默认的地址信息</param>
		/// <param name="tips">默认提示的消息内容</param>
		public void SetReadWriteNet( IReadWriteNet device, string address, string tips )
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


					textBox_address.Multiline = true;
					textBox_address.Height = 23 + 40;
					textBox_address.ScrollBars = ScrollBars.Vertical;
					textBox_result.Location = new Point( 56, 54 + 40 );
					label_result.Location = new Point( 3, 54 + 40 );
					label_tips.Location = new Point( 53, 32 + 40 );
					textBox_result.Size = new Size( this.Width - (845 - 683), this.Height - (318 - 238) - 40 );
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
					textBox_result.Size = new Size( this.Width - (845 - 683), this.Height - (318 - 238) );
				}
			}
		}

		private bool isSourceReadMode = false;
		private Func<string[], ushort[], OperateResult<byte[]>> readRandom;
		private Func<string[], OperateResult<byte[]>> readWordRandom;
		private IReadWriteNet readWriteNet;
		private byte[] buffer;

		private string buttonTips1 = "";
		private string buttonTips2 = "";
		private string buttonTips3= "";
	}
}
