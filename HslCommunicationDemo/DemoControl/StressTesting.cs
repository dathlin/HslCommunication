using HslCommunication;
using HslCommunication.Core;
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

namespace HslCommunicationDemo.PLC.Common
{
	public partial class StressTesting : UserControl
	{
		public StressTesting( )
		{
			InitializeComponent( );
		}

		#region Pressure Test

		private long currentCount = 0;
		private int repeatTimes = 1000;
		private int thread_status = 0;
		private int failed = 0;
		private string[] addresses;
		private System.Windows.Forms.Timer testProgressTimer;
		private int read_write_count = 0;
		private double time_cost = 0;
		private int check_same_count = 0;
		private int check_same_count_failed = 0;

		// 压力测试，开N个线程，每个线程进行读写操作，看使用时间

		private string GetAddressIndex( int index )
		{
			if (addresses == null) return string.Empty;
			if (addresses.Length == 0) return string.Empty;
			if (index >= addresses.Length) return addresses[addresses.Length - 1];
			return addresses[index];
		}

		private void thread_test( object obj )
		{
			string address = string.Empty;
			if (obj is int index)
			{
				address = GetAddressIndex( index );
			}
			int count = repeatTimes;
			short shortValue = 0;
			while (count > 0)
			{
				if (checkBox_write.Checked)
				{
					DateTime start = DateTime.Now;
					OperateResult write = this.readWriteNet.Write( address, shortValue );
					time_cost += (DateTime.Now - start).TotalMilliseconds;
					if (!write.IsSuccess)
					{
						Interlocked.Increment( ref failed );
					}
					Interlocked.Increment( ref read_write_count );
				}
				if (checkBox_read.Checked)
				{
					DateTime start = DateTime.Now;
					OperateResult<short> read = this.readWriteNet.ReadInt16( address );
					time_cost += (DateTime.Now - start).TotalMilliseconds;
					if (!read.IsSuccess)
					{
						Interlocked.Increment( ref failed );
					}
					else
					{
						if (checkBox_check_same.Checked)
						{
							if (read.Content == shortValue)
							{
								Interlocked.Increment( ref check_same_count );
							}
							else
							{
								Interlocked.Increment( ref check_same_count_failed );
							}
						}
					}
					Interlocked.Increment( ref read_write_count );
				}
				count--;
				Interlocked.Increment( ref currentCount );
				shortValue++;
			}
			thread_end( );
		}

		private void thread_end( )
		{
			if (Interlocked.Decrement( ref thread_status ) == 0)
			{
				// 执行完成
				Invoke( new Action( ( ) =>
				{
					button_test_start.Enabled = true;
					label_info.Text = Program.Language == 1 ? "测试完成!" : "Test Finish!";
				} ) );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_thread_count.Text, out thread_status ))
			{
				MessageBox.Show( "thread_count input wrong!" );
				return;
			}
			if (!int.TryParse( textBox_repreat_times.Text, out repeatTimes ))
			{
				MessageBox.Show( "repreat_times input wrong!" );
				return;
			}
			addresses = textBox_test_address.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries );

			failed = 0;
			check_same_count_failed = 0;
			read_write_count = 0;
			currentCount = 0;
			time_cost = 0;
			check_same_count = 0;
			label_info.Visible = true;
			label_info.Text = Program.Language == 1 ? "测试开始..." : "Test Start...";
			hslProgressBar1.Value = 0;

			for (int i = 0; i < thread_status; i++)
			{
				new Thread( new ParameterizedThreadStart( thread_test ) ) { IsBackground = true, }.Start( i );
			}
			button_test_start.Enabled = false;

			testProgressTimer = new System.Windows.Forms.Timer( );
			testProgressTimer.Interval = 1000;
			testProgressTimer.Tick += TestProgressTimer_Tick;
			testProgressTimer.Start( );
		}

		private void TestProgressTimer_Tick( object sender, EventArgs e )
		{
			if (currentCount >= repeatTimes * thread_status)
			{
				hslProgressBar1.Value = 100;
				testProgressTimer?.Stop( );
				testProgressTimer?.Dispose( );
			}
			else
			{
				double value = currentCount * 100 / (repeatTimes * thread_status * 1d);
				hslProgressBar1.Value = (int)value;
			}

			textBox_total_count.Text = read_write_count.ToString( );
			textBox_total_time.Text = (time_cost / 1000d).ToString( "F1" ) + " s";
			if (read_write_count != 0)
				textBox_avg_time.Text = (time_cost / read_write_count).ToString( "F0" ) + " ms";

			textBox_check_same.Text = check_same_count.ToString( );
			textBox_failed_count.Text = failed.ToString( );
			textBox_check_wrong.Text = check_same_count_failed.ToString( );
		}

		public void SetReadWriteNet( IReadWriteNet readWriteNet, string address )
		{
			this.readWriteNet = readWriteNet;
			this.textBox_test_address.Text = address;

			if (this.readWriteNet != null)
			{
				button_test_start.Enabled = true;
			}
		}

		#endregion

		#region Private Member

		private IReadWriteNet readWriteNet;

		#endregion

		private void StressTesting_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				groupBox_press.Text = "线程设置";
				label_thread_count.Text = "线程数量:";
				label_repeat_times.Text = "重复次数:";
				label_pressure_address.Text = "地址:";
				label3.Text = "如果每个线程地址不一样：D100;D200;D300";
				checkBox_check_same.Text = "检查写入值及读取值是否一致?";
				checkBox_continue_when_error.Text = "在读写失败时是否继续?";
				groupBox1.Text = "测试结果";
				label_pressure_progress.Text = "测试进度:";
				label1.Text = "读写总次数:";
				label2.Text = "总耗时(秒):";
				label4.Text = "平均耗时(ms):";
				label5.Text = "读写校验正确:";
				label7.Text = "失败次数:";
				label6.Text = "读写校验错误:";
				button_test_start.Text = "开始";
			}
			label_info.Visible = false;
		}
	}
}
