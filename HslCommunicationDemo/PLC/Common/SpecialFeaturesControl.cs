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
	public partial class SpecialFeaturesControl : UserControl
	{
		public SpecialFeaturesControl( )
		{
			InitializeComponent( );
		}

		#region Pressure Test

		private long currentCount = 0;
		private int repeatTimes = 1000;
		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private System.Windows.Forms.Timer testProgressTimer;

		// 压力测试，开3个线程，每个线程进行读写操作，看使用时间

		private void thread_test( )
		{
			int count = repeatTimes;
			while (count > 0)
			{
				if (checkBox_write.Checked)
				{
					OperateResult write = readWriteNet.Write( textBox_test_address.Text, (short)1234 );
					if (!write.IsSuccess) failed++;
				}
				if (checkBox_read.Checked)
				{
					if (!readWriteNet.ReadInt16( textBox_test_address.Text ).IsSuccess) failed++;
				}
				count--;
				Interlocked.Increment( ref currentCount );
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
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
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

			failed = 0;
			thread_time_start = DateTime.Now;
			currentCount = 0;

			for (int i = 0; i < thread_status; i++)
			{
				new Thread( new ThreadStart( thread_test ) ) { IsBackground = true, }.Start( );
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
				label_progress.Text = "100%";
				testProgressTimer?.Stop( );
				testProgressTimer?.Dispose( );
			}
			else
			{
				double value = currentCount * 100 / (repeatTimes * thread_status * 1d);
				label_progress.Text = value.ToString( "F0" ) + "%";
			}
		}

		public void SetDevice( IReadWriteNet readWriteNet, string address )
		{
			this.readWriteNet = readWriteNet;
			this.textBox_test_address.Text = address;
		}

		#endregion

		#region Private Member

		private IReadWriteNet readWriteNet;

		#endregion
	}
}
