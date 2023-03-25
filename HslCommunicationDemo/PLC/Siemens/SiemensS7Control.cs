using HslCommunication;
using HslCommunication.Core.Pipe;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace HslCommunicationDemo.PLC.Siemens
{
	public class SiemensS7Control : SpecialFeaturesControl
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button_write_dtltime;
		private System.Windows.Forms.Button button_read_dtltime;
		private System.Windows.Forms.Button button_write_Date;
		private System.Windows.Forms.Button button_read_date;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button_read_string;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;

		public SiemensS7Control( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button_write_dtltime = new System.Windows.Forms.Button();
			this.button_read_dtltime = new System.Windows.Forms.Button();
			this.button_write_Date = new System.Windows.Forms.Button();
			this.button_read_date = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.button14 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button_read_string = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button_write_dtltime);
			this.groupBox2.Controls.Add(this.button_read_dtltime);
			this.groupBox2.Controls.Add(this.button_write_Date);
			this.groupBox2.Controls.Add(this.button_read_date);
			this.groupBox2.Controls.Add(this.button12);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.button11);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.button14);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Controls.Add(this.button_read_string);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.textBox7);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(526, 226);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "S7 Functions";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(317, 17);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 35;
			this.button3.Text = "订货号";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button_write_dtltime
			// 
			this.button_write_dtltime.Location = new System.Drawing.Point(383, 190);
			this.button_write_dtltime.Name = "button_write_dtltime";
			this.button_write_dtltime.Size = new System.Drawing.Size(89, 28);
			this.button_write_dtltime.TabIndex = 51;
			this.button_write_dtltime.Text = "DTL time-W";
			this.button_write_dtltime.UseVisualStyleBackColor = true;
			this.button_write_dtltime.Click += new System.EventHandler(this.button_write_dtltime_Click);
			// 
			// button_read_dtltime
			// 
			this.button_read_dtltime.Location = new System.Drawing.Point(295, 190);
			this.button_read_dtltime.Name = "button_read_dtltime";
			this.button_read_dtltime.Size = new System.Drawing.Size(82, 28);
			this.button_read_dtltime.TabIndex = 50;
			this.button_read_dtltime.Text = "DTL time-R";
			this.button_read_dtltime.UseVisualStyleBackColor = true;
			this.button_read_dtltime.Click += new System.EventHandler(this.button_read_dtltime_Click);
			// 
			// button_write_Date
			// 
			this.button_write_Date.Location = new System.Drawing.Point(383, 156);
			this.button_write_Date.Name = "button_write_Date";
			this.button_write_Date.Size = new System.Drawing.Size(89, 28);
			this.button_write_Date.TabIndex = 49;
			this.button_write_Date.Text = "日期写入";
			this.button_write_Date.UseVisualStyleBackColor = true;
			this.button_write_Date.Click += new System.EventHandler(this.button_write_Date_Click);
			// 
			// button_read_date
			// 
			this.button_read_date.Location = new System.Drawing.Point(295, 156);
			this.button_read_date.Name = "button_read_date";
			this.button_read_date.Size = new System.Drawing.Size(82, 28);
			this.button_read_date.TabIndex = 48;
			this.button_read_date.Text = "日期读取";
			this.button_read_date.UseVisualStyleBackColor = true;
			this.button_read_date.Click += new System.EventHandler(this.button_read_date_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(13, 185);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(82, 28);
			this.button12.TabIndex = 47;
			this.button12.Text = "共享测试";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(383, 121);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(89, 28);
			this.button10.TabIndex = 45;
			this.button10.Text = "WString-W";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(295, 122);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(82, 28);
			this.button11.TabIndex = 46;
			this.button11.Text = "WString-R";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(116, 191);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 17);
			this.label5.TabIndex = 44;
			this.label5.Text = "0";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(383, 87);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(89, 28);
			this.button14.TabIndex = 36;
			this.button14.Text = "字符串写入";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(383, 55);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(89, 28);
			this.button8.TabIndex = 43;
			this.button8.Text = "time写入";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button_read_string
			// 
			this.button_read_string.Location = new System.Drawing.Point(295, 88);
			this.button_read_string.Name = "button_read_string";
			this.button_read_string.Size = new System.Drawing.Size(82, 28);
			this.button_read_string.TabIndex = 37;
			this.button_read_string.Text = "字符串读取";
			this.button_read_string.UseVisualStyleBackColor = true;
			this.button_read_string.Click += new System.EventHandler(this.button_read_string_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(295, 55);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(82, 28);
			this.button7.TabIndex = 38;
			this.button7.Text = "time读取";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(17, 17);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 28);
			this.button4.TabIndex = 40;
			this.button4.Text = "热启动";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.Color.Red;
			this.label19.Location = new System.Drawing.Point(55, 117);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(147, 58);
			this.label19.TabIndex = 39;
			this.label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(219, 17);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(82, 28);
			this.button6.TabIndex = 42;
			this.button6.Text = "停止";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(119, 17);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(82, 28);
			this.button5.TabIndex = 41;
			this.button5.Text = "冷启动";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(71, 91);
			this.textBox7.Name = "textBox7";
			this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox7.Size = new System.Drawing.Size(218, 23);
			this.textBox7.TabIndex = 34;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 17);
			this.label10.TabIndex = 31;
			this.label10.Text = "地址：";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(71, 58);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(218, 23);
			this.textBox8.TabIndex = 32;
			this.textBox8.Text = "M100";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 93);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 17);
			this.label9.TabIndex = 33;
			this.label9.Text = "值：";
			// 
			// SiemensS7Control
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "SiemensS7Control";
			this.Size = new System.Drawing.Size(780, 232);
			this.Load += new System.EventHandler(this.SiemensS7Control_Load);
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		private SiemensS7Net siemensTcpNet;

		public void SetDevice( SiemensS7Net siemensTcpNet, string address )
		{
			this.siemensTcpNet = siemensTcpNet;
			base.SetDevice( siemensTcpNet, address );
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			// 热启动
			OperateResult result = await siemensTcpNet.HotStartAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 冷启动
			OperateResult result = await siemensTcpNet.ColdStartAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			// 停止
			OperateResult result = await siemensTcpNet.StopAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			// 订货号
			OperateResult<string> read = await siemensTcpNet.ReadOrderNumberAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Order Number：" + read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}

		private async void button7_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		private async void button8_Click( object sender, EventArgs e )
		{
			// time写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
		}

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			OperateResult<string> read = await siemensTcpNet.ReadStringAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			// string写入
			DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// WString 读取
			OperateResult<string> read = await siemensTcpNet.ReadWStringAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		private async void button10_Click( object sender, EventArgs e )
		{
			// WString 写入
			DemoUtils.WriteResultRender( await siemensTcpNet.WriteWStringAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
		}

		private async void button_read_date_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		private async void button_write_Date_Click( object sender, EventArgs e )
		{
			// date写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteDateAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
		}

		private async void button_read_dtltime_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDTLDataTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}
		}

		private async void button_write_dtltime_Click( object sender, EventArgs e )
		{
			// DTL时间写入操作
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteDTLTimeAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
		}

		private void label5_Click( object sender, EventArgs e )
		{

		}

		private PipeSocket pipeSocket;
		private SiemensS7Net[] siemensS = new SiemensS7Net[3];

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private long successCount = 0;
		private System.Windows.Forms.Timer timer;

		private void button12_Click( object sender, EventArgs e )
		{
			pipeSocket?.Socket?.Close( );
			pipeSocket = new PipeSocket( "127.0.0.1", 102 );
			siemensS[0] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[1] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[2] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[0].SetPipeSocket( pipeSocket );
			siemensS[1].SetPipeSocket( pipeSocket );
			siemensS[2].SetPipeSocket( pipeSocket );

			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M100" );
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M200" );
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M300" );
			button12.Enabled = false;

			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			label5.Text = successCount.ToString( );
		}

		private async void thread_test2( object add )
		{
			string address = (string)add;
			SiemensS7Net plc = address == "M100" ? siemensS[0] : address == "M200" ? siemensS[1] : siemensS[2];
			int count = 10000;
			while (count > 0)
			{
				if (!(await plc.WriteAsync( address, (short)count )).IsSuccess) failed++;
				OperateResult<short> read = await plc.ReadInt16Async( address );
				if (!read.IsSuccess) failed++;
				else
				{
					if (read.Content != count) failed++;
				}
				count--;
				successCount++;
			}
			thread_end2( );
		}

		private void thread_end2( )
		{
			if (Interlocked.Decrement( ref thread_status ) == 0)
			{
				pipeSocket?.Socket?.Close( );
				// 执行完成
				Invoke( new Action( ( ) =>
				{
					label5.Text = successCount.ToString( );
					timer.Stop( );
					button12.Enabled = true;
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}

		private void SiemensS7Control_Load( object sender, EventArgs e )
		{
			if ( Program.Language == 2)
			{
				button_read_string.Text = "r-string";
				button7.Text = "r-time";

				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button14.Text = "w-string";
				button8.Text = "w-time";

				button3.Text = "Order";
				button4.Text = "hot-start";
				button5.Text = "cold-start";
				button6.Text = "stop";

				button_read_date.Text = "r-date";
				button_write_Date.Text = "w-date";
			}
		}
	}
}
