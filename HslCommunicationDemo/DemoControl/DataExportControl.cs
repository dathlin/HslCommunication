using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Core;

namespace HslCommunicationDemo.DemoControl
{
	public partial class DataExportControl : UserControl
	{
		public DataExportControl( )
		{
			InitializeComponent( );

			dataGridView1.RowsAdded += DataGridView1_RowsAdded;
		}

		private void DataGridView1_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
		{
			int rowIndex = e.RowIndex - 1;
			if (rowIndex >=0 && rowIndex < dataGridView1.RowCount)
			{
				DataGridViewRow row = dataGridView1.Rows[rowIndex];
				if (row.Cells[1].Value == null)
					row.Cells[1].Value = "Byte";
			}
		}

		private void DataExportControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "Address list for export(Read(address, length)):";
				label2.Text = "Interval(ms): ";
				label3.Text = "Stop Time: ";
				label4.Text = "Save to file auto: ";
				button_select.Text = "select";
				button_start.Text = "Start";
				label5.Text = "Read logs: ";
			}
		}

		private void button_select_Click( object sender, EventArgs e )
		{
			using (SaveFileDialog sfd = new SaveFileDialog( ))
			{
				sfd.Filter = "数据文件(*.hsldata)|*.hsldata";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					textBox_path.Text = sfd.FileName;
				}
			}
		}

		public void SetReadWriteNet( IReadWriteNet device )
		{
			this.device = device;
		}

		private IReadWriteNet device;
		private Thread thread;
		private DateTime finishTime = DateTime.Now;
		private List<ReadAddress> readAddresses = new List<ReadAddress>( );
		private int threadVersion = 0;
		private FileStream fs;
		private int timeInterval = 1000;

		private void AppendLog( string text )
		{
			if (this.textBox_log.InvokeRequired)
			{
				this.textBox_log.Invoke( new Action<string>( AppendLog ), text );
				return;
			}

			try
			{
				textBox_log.AppendText( $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {text}{Environment.NewLine}" );
			}
			catch
			{

			}
		}

		private void button_start_Click( object sender, EventArgs e )
		{
			// 检测存储条件
			if (string.IsNullOrEmpty( textBox_path.Text ))
			{
				MessageBox.Show( "Save path can not be null" );
				return;
			}

			try
			{
				timeInterval = int.Parse( textBox_timer.Text );
				if (timeInterval < 0) throw new Exception( "Time Interval can not below 0" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Time Interval get failed: " + ex.Message );
				return;
			}

			finishTime = dateTimePicker1.Value;
			readAddresses.Clear( );
			for (int i = 0; i < dataGridView1.RowCount; i++)
			{
				DataGridViewRow row = dataGridView1.Rows[i];
				if (row.IsNewRow) continue;

				ReadAddress readAddress = new ReadAddress( );
				try
				{
					readAddress.Address = row.Cells[0].Value.ToString( );
					if (string.IsNullOrEmpty( readAddress.Address ))
					{
						throw new Exception( "Address null" );
					}

					readAddress.IsByte = row.Cells[1].Value.ToString( ) == "Byte";
					readAddress.Length = ushort.Parse( row.Cells[2].Value.ToString( ) );
					row.DefaultCellStyle.BackColor = dataGridView1.RowsDefaultCellStyle.BackColor;

					readAddresses.Add( readAddress );
				}
				catch (Exception ex)
				{
					row.DefaultCellStyle.BackColor = Color.Tomato;
					MessageBox.Show( $"Wrong in row[{i}]: " + ex.Message );
					return;
				}
			}
			if (readAddresses.Count == 0)
			{
				AppendLog( "No Address to read" );
				return;
			}

			try
			{
				fs = new FileStream( textBox_path.Text, FileMode.Create );
				// 先写入一些文件头信息，100个字节长度
				byte[] head = new byte[100];
				head[8] = 0x01;                                                         // 版本1
				Encoding.ASCII.GetBytes( "HSLDemo" ).CopyTo( head, 0 );                 // 
				BitConverter.GetBytes( DateTime.Now.Ticks ).CopyTo( head, 10 );
				BitConverter.GetBytes( timeInterval ).CopyTo( head, 26 );

				fs.Write( head, 0, head.Length );
			}
			catch(Exception ex)
			{
				AppendLog( $"File[{textBox_path.Text}] stream create failed: " + ex.Message );
				return;
			}

			// 开始后台读取数据信息
			thread = new Thread( ReadFromPlcAndSave );
			thread.IsBackground = true;
			threadVersion++;
			thread.Start( threadVersion );
			button_start.Enabled = false;
		}


		private void ReadFromPlcAndSave( object obj )
		{
			int threadId = (int)obj;
			long writeTick = 0;
			DateTime lastTime = DateTime.Now.AddMilliseconds( -timeInterval );

			while (true)
			{
				while (true)
				{
					Thread.Sleep( 20 );
					if (threadId != threadVersion)
					{
						AppendLog( "Thread abort!" );
						break;
					}

					if ((DateTime.Now - lastTime).TotalMilliseconds >= timeInterval)
					{
						lastTime = DateTime.Now;
						break;
					}
				}

				// 写入地址个数信息
				fs.Write( BitConverter.GetBytes( readAddresses.Count ), 0, 4 );
				DateTime readStart = DateTime.Now;
				int success = 0;
				for (int i = 0; i < readAddresses.Count; i++)
				{
					if (threadId != threadVersion)
					{
						AppendLog( "Thread abort!" );
						break;
					}

					// 写入地址
					byte[] address = Encoding.UTF8.GetBytes( readAddresses[i].Address );
					fs.Write( BitConverter.GetBytes( address.Length ), 0, 4 );
					fs.Write( address, 0, address.Length );
					// 写入长度
					fs.Write( BitConverter.GetBytes( (int)readAddresses[i].Length ), 0, 4 );

					// 写入成功或失败，成功的话，写入数据
					if (readAddresses[i].IsByte)
					{
						OperateResult<byte[]> read = this.device.Read( readAddresses[i].Address, readAddresses[i].Length );
						if (read.IsSuccess == false)
						{
							AppendLog( $"Read [{readAddresses[i].Address}] failed: " + read.Message );
							fs.WriteByte( 0xff );
						}
						else
						{
							//AppendLog( $"Read [{readAddresses[i].Address}] success " );
							success++;
							fs.WriteByte( 0x00 );
							fs.Write( BitConverter.GetBytes( read.Content.Length ), 0, 4 );
							fs.Write( read.Content, 0, read.Content.Length );
						}
					}
					else
					{
						OperateResult<bool[]> read = this.device.ReadBool( readAddresses[i].Address, readAddresses[i].Length );
						if (read.IsSuccess == false)
						{
							AppendLog( $"Read Bool[{readAddresses[i].Address}] failed: " + read.Message );
							fs.WriteByte( 0xff );
						}
						else
						{
							//AppendLog( $"Read Bool[{readAddresses[i].Address}] success " );
							success++;
							fs.WriteByte( 0x01 );
							fs.Write( BitConverter.GetBytes( read.Content.Length ), 0, 4 );
							byte[] buffer = read.Content.ToByteArray( );
							fs.Write( buffer, 0, buffer.Length );
						}
					}
				}

				writeTick++;
				Invoke( new Action( ( ) =>
				{
					label_rows.Text = "Rows: " + writeTick;
				} ) );
				AppendLog( $"Read success [{success}] times, spend: " + (DateTime.Now - readStart).TotalMilliseconds.ToString( "F0" ) );

				if (DateTime.Now > finishTime)
				{
					break;
				}

			}
			fs.Position = 18;
			fs.Write( BitConverter.GetBytes( DateTime.Now.Ticks ), 0, 8 );
			fs.Position = 30;
			fs.Write( BitConverter.GetBytes( writeTick ), 0, 8 );

			fs.Flush( );
			fs.Dispose( );
			AppendLog( "Thread finish!" );
			Invoke( new Action( ( ) =>
			{
				button_start.Enabled = true;
			} ) );
		}

		private void DataExportControl_SizeChanged( object sender, EventArgs e )
		{
			button_start.Location = new Point( (this.Width - 320 - button_start.Width) / 2 + 320, button_start.Location.Y );
		}
	}

	public class ReadAddress
	{
		/// <summary>
		/// 读取的地址信息
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 是否是字节读取
		/// </summary>
		public bool IsByte { get; set; }

		/// <summary>
		/// 读取的长度信息
		/// </summary>
		public ushort Length { get; set; }
	}
}
