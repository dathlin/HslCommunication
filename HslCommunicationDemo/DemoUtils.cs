using HslCommunication;
using HslCommunication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	/// <summary>
	/// DEMO程序的一些静态变量信息
	/// </summary>
	public class DemoUtils
	{

		/// <summary>
		/// 将 <see cref="DataGridView"/> 的行数控制在指定的行数
		/// </summary>
		/// <param name="dataGridView1">图标控件</param>
		/// <param name="row">指定的行数信息</param>
		public static void DataGridSpecifyRowCount( DataGridView dataGridView1, int row )
		{
			if (dataGridView1.AllowUserToAddRows)
			{
				row++;
			}
			if (dataGridView1.RowCount < row)
			{
				// 扩充
				dataGridView1.Rows.Add( row - dataGridView1.RowCount );
			}
			else if (dataGridView1.RowCount > row)
			{
				int deleteRows = dataGridView1.RowCount - row;
				for (int i = 0; i < deleteRows; i++)
				{
					dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
				}
			}
			if (row > 0)
			{
				dataGridView1.Rows[0].Cells[0].Selected = false;
			}
		}


		/// <summary>
		/// 统一的读取结果的数据解析，显示
		/// </summary>
		/// <typeparam name="T">类型对象</typeparam>
		/// <param name="result">读取的结果值</param>
		/// <param name="address">地址信息</param>
		/// <param name="textBox">输入的控件</param>
		public static void ReadResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
		{
			if (result.IsSuccess)
			{
				if (result.Content is Array)
				{
					textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {HslCommunication.BasicFramework.SoftBasic.ArrayFormat(result.Content)}{Environment.NewLine}" );
				}
				else
				{
					textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
				}
			}
			else
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Read Failed {Environment.NewLine}Reason：{result.ToMessageShowString( )}" );
			}
		}
		
		/// <summary>
		/// 统一的数据写入的结果显示
		/// </summary>
		/// <param name="result">写入的结果信息</param>
		/// <param name="address">地址信息</param>
		public static void WriteResultRender( OperateResult result, string address )
		{
			if (result.IsSuccess)
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
			}
			else
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
			}
		}

		/// <summary>
		/// 统一的数据写入的结果显示
		/// </summary>
		/// <param name="result">写入的结果信息</param>
		/// <param name="address">地址信息</param>
		public static void WriteResultRender( OperateResult result )
		{
			if (result.IsSuccess)
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"Success" );
			}
			else
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
			}
		}

		/// <summary>
		/// 统一的数据写入的结果显示
		/// </summary>
		/// <param name="result">写入的结果信息</param>
		/// <param name="address">地址信息</param>
		public static void WriteResultRender( Func<OperateResult> write, string address )
		{
			try
			{
				OperateResult result = write( );
				if (result.IsSuccess)
				{
					MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
				}
				else
				{
					MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
				}
			}
			catch(Exception ex)
			{
				// 主要是为了捕获写入的值不正确的情况
				MessageBox.Show( "Data for writting is not corrent: " + ex.Message );
			}
		}

		public static void BulkReadRenderResult( HslCommunication.Core.IReadWriteNet readWrite, TextBox addTextBox, TextBox lengthTextBox, TextBox resultTextBox )
		{
			try
			{
				OperateResult<byte[]> read = readWrite.Read( addTextBox.Text, ushort.Parse( lengthTextBox.Text ) );
				if (read.IsSuccess)
				{
					resultTextBox.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Read Failed：" + ex.Message );
			}
		}

		/// <summary>
		/// 将消息文本添加到文本显示控件上去
		/// </summary>
		/// <param name="textBox">显示的控件</param>
		/// <param name="key">关键字信息</param>
		/// <param name="message">消息文本</param>
		/// <param name="maxKeyLength">对齐长度</param>
		public static void AppendTextBox( TextBox textBox, string key, string message, int maxKeyLength = -1 )
		{
			StringBuilder sb = new StringBuilder( );
			sb.Append( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " );
			if (!string.IsNullOrEmpty( key ))
			{
				sb.Append( "[" + key + "] " );
			}
			sb.Append( message );
			sb.Append( Environment.NewLine );
			textBox.AppendText( sb.ToString( ) );
		}

		public static OperateResult<int> ParseInt( string text )
		{
			try
			{
				if (text.StartsWith( "0x" ) || text.StartsWith( "0X" ))
				{
					return OperateResult.CreateSuccessResult( Convert.ToInt32( text.Substring( 2 ), 16 ) );
				}
				else
					return OperateResult.CreateSuccessResult( Convert.ToInt32( text ) );
			}
			catch( Exception ex)
			{
				return new OperateResult<int>( "Convert Int Failed: " + ex.Message );
			}
		}

		public static readonly string IpAddressInputWrong = "IpAddress input wrong";
		public static readonly string PortInputWrong = "Port input wrong";
		public static readonly string SlotInputWrong = "Slot input wrong";
		public static readonly string BaudRateInputWrong = "Baud rate input wrong";
		public static readonly string DataBitsInputWrong = "Data bit input wrong";
		public static readonly string StopBitInputWrong = "Stop bit input wrong";



		public static string[] GetEncodings( )
		{
			return new string[]
			{
				"ASCII",
				"Unicode",
				"Unicode-big",
				"UTF8",
				"UTF32",
				"ANSI",
				"GB2312"
			};
		}

		public static Encoding GetEncodingFromIndex( int index )
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


	}
}
