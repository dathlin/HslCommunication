using HslCommunication;
using HslCommunication.Core.Pipe;
using HslCommunication.Instrument.DLT;
using HslCommunication.Instrument.DLT.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Instrument
{
	public class DLT645Control : UserControl
	{
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox12;
		private Button button_SwitchingOn;
		private Button button_trip;
		private TextBox textBox_valid_time;
		private Label label1;
		private TextBox textBox_code;
		private Label label_code;
		private Panel panel1;
		private RadioButton radioButton_1200;
		private RadioButton radioButton_600;
		private Label label3;
		private RadioButton radioButton_19200;
		private RadioButton radioButton_9600;
		private RadioButton radioButton_4800;
		private RadioButton radioButton_2400;
		private Button button_change;

		public DLT645Control( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button_change = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButton_19200 = new System.Windows.Forms.RadioButton();
			this.radioButton_9600 = new System.Windows.Forms.RadioButton();
			this.radioButton_4800 = new System.Windows.Forms.RadioButton();
			this.radioButton_2400 = new System.Windows.Forms.RadioButton();
			this.radioButton_1200 = new System.Windows.Forms.RadioButton();
			this.radioButton_600 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.button_SwitchingOn = new System.Windows.Forms.Button();
			this.button_trip = new System.Windows.Forms.Button();
			this.textBox_valid_time = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_change
			// 
			this.button_change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_change.Location = new System.Drawing.Point(504, 148);
			this.button_change.Name = "button_change";
			this.button_change.Size = new System.Drawing.Size(106, 28);
			this.button_change.TabIndex = 35;
			this.button_change.Text = "修改波特率";
			this.button_change.UseVisualStyleBackColor = true;
			this.button_change.Click += new System.EventHandler(this.button_change_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel1.Controls.Add(this.radioButton_19200);
			this.panel1.Controls.Add(this.radioButton_9600);
			this.panel1.Controls.Add(this.radioButton_4800);
			this.panel1.Controls.Add(this.radioButton_2400);
			this.panel1.Controls.Add(this.radioButton_1200);
			this.panel1.Controls.Add(this.radioButton_600);
			this.panel1.Location = new System.Drawing.Point(51, 148);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(447, 28);
			this.panel1.TabIndex = 34;
			// 
			// radioButton_19200
			// 
			this.radioButton_19200.AutoSize = true;
			this.radioButton_19200.Location = new System.Drawing.Point(365, 4);
			this.radioButton_19200.Name = "radioButton_19200";
			this.radioButton_19200.Size = new System.Drawing.Size(61, 21);
			this.radioButton_19200.TabIndex = 5;
			this.radioButton_19200.Text = "19200";
			this.radioButton_19200.UseVisualStyleBackColor = true;
			// 
			// radioButton_9600
			// 
			this.radioButton_9600.AutoSize = true;
			this.radioButton_9600.Checked = true;
			this.radioButton_9600.Location = new System.Drawing.Point(285, 4);
			this.radioButton_9600.Name = "radioButton_9600";
			this.radioButton_9600.Size = new System.Drawing.Size(54, 21);
			this.radioButton_9600.TabIndex = 4;
			this.radioButton_9600.TabStop = true;
			this.radioButton_9600.Text = "9600";
			this.radioButton_9600.UseVisualStyleBackColor = true;
			// 
			// radioButton_4800
			// 
			this.radioButton_4800.AutoSize = true;
			this.radioButton_4800.Location = new System.Drawing.Point(209, 4);
			this.radioButton_4800.Name = "radioButton_4800";
			this.radioButton_4800.Size = new System.Drawing.Size(54, 21);
			this.radioButton_4800.TabIndex = 3;
			this.radioButton_4800.Text = "4800";
			this.radioButton_4800.UseVisualStyleBackColor = true;
			// 
			// radioButton_2400
			// 
			this.radioButton_2400.AutoSize = true;
			this.radioButton_2400.Location = new System.Drawing.Point(133, 4);
			this.radioButton_2400.Name = "radioButton_2400";
			this.radioButton_2400.Size = new System.Drawing.Size(54, 21);
			this.radioButton_2400.TabIndex = 2;
			this.radioButton_2400.Text = "2400";
			this.radioButton_2400.UseVisualStyleBackColor = true;
			// 
			// radioButton_1200
			// 
			this.radioButton_1200.AutoSize = true;
			this.radioButton_1200.Location = new System.Drawing.Point(63, 4);
			this.radioButton_1200.Name = "radioButton_1200";
			this.radioButton_1200.Size = new System.Drawing.Size(54, 21);
			this.radioButton_1200.TabIndex = 1;
			this.radioButton_1200.Text = "1200";
			this.radioButton_1200.UseVisualStyleBackColor = true;
			// 
			// radioButton_600
			// 
			this.radioButton_600.AutoSize = true;
			this.radioButton_600.Location = new System.Drawing.Point(3, 4);
			this.radioButton_600.Name = "radioButton_600";
			this.radioButton_600.Size = new System.Drawing.Size(47, 21);
			this.radioButton_600.TabIndex = 0;
			this.radioButton_600.Text = "600";
			this.radioButton_600.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 154);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 33;
			this.label3.Text = "波特率：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(49, 178);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(699, 40);
			this.textBox_code.TabIndex = 32;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(0, 182);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 31;
			this.label_code.Text = "代码：";
			// 
			// button_SwitchingOn
			// 
			this.button_SwitchingOn.Location = new System.Drawing.Point(610, 36);
			this.button_SwitchingOn.Name = "button_SwitchingOn";
			this.button_SwitchingOn.Size = new System.Drawing.Size(96, 28);
			this.button_SwitchingOn.TabIndex = 30;
			this.button_SwitchingOn.Text = "合闸允许";
			this.button_SwitchingOn.UseVisualStyleBackColor = true;
			this.button_SwitchingOn.Click += new System.EventHandler(this.button_SwitchingOn_Click);
			// 
			// button_trip
			// 
			this.button_trip.Location = new System.Drawing.Point(492, 36);
			this.button_trip.Name = "button_trip";
			this.button_trip.Size = new System.Drawing.Size(96, 28);
			this.button_trip.TabIndex = 29;
			this.button_trip.Text = "跳闸";
			this.button_trip.UseVisualStyleBackColor = true;
			this.button_trip.Click += new System.EventHandler(this.button_trip_Click);
			// 
			// textBox_valid_time
			// 
			this.textBox_valid_time.Location = new System.Drawing.Point(560, 6);
			this.textBox_valid_time.Name = "textBox_valid_time";
			this.textBox_valid_time.Size = new System.Drawing.Size(188, 23);
			this.textBox_valid_time.TabIndex = 28;
			this.textBox_valid_time.Text = "2024-09-18 22:34:29";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(484, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 27;
			this.label1.Text = "有效时间：";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(248, 36);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(168, 28);
			this.button7.TabIndex = 26;
			this.button7.Text = "读取原始字符串";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(206, 3);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(124, 28);
			this.button6.TabIndex = 25;
			this.button6.Text = "广播时间";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(336, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(106, 28);
			this.button5.TabIndex = 24;
			this.button5.Text = "写入通信地址";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(54, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(188, 23);
			this.textBox1.TabIndex = 23;
			this.textBox1.Text = "02-01-01-00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 22;
			this.label2.Text = "地址：";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(105, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(95, 28);
			this.button4.TabIndex = 21;
			this.button4.Text = "读取通信地址";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 28);
			this.button3.TabIndex = 20;
			this.button3.Text = "唤醒接收";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(3, 69);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(745, 76);
			this.textBox12.TabIndex = 19;
			// 
			// DLT645Control
			// 
			this.Controls.Add(this.button_change);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button_SwitchingOn);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button_trip);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.textBox_valid_time);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button7);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DLT645Control";
			this.Size = new System.Drawing.Size(751, 221);
			this.Load += new System.EventHandler(this.DLT645Control_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( IDlt645 dlt645, string address )
		{
			this.dlt645 = dlt645;
		}

		private IDlt645 dlt645;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult active = dlt645.ActiveDeveice( );
			if (active.IsSuccess)
			{
				DemoUtils.ShowMessage( "Send Active Code Success" );
			}
			else
			{
				DemoUtils.ShowMessage( "Active Code failed:" + active.Message );
			}

			textBox_code.Text = $"OperateResult active = dlt.ActiveDeveice( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = dlt645.ReadAddress( );
			if (read.IsSuccess)
			{
				//textBox_station.Text = read.Content;
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Address:{read.Content}";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = dlt.ReadAddress( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 广播当前时间
			OperateResult read = dlt645.BroadcastTime( DateTime.Now );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] BroadcastTime Success";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult result = dlt.BroadcastTime( DateTime.Now );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 写通信地址
			OperateResult write = dlt645.WriteAddress( textBox1.Text );
			if (write.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Write Success";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + write.Message );
			}

			textBox_code.Text = $"OperateResult write = dlt.WriteAddress( \"{textBox1.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = dlt645.ReadStringArray( textBox1.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Read Result: {Environment.NewLine}";
				foreach (string item in read.Content)
				{
					textBox12.AppendText( item );
					textBox12.AppendText( Environment.NewLine );
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string[]> read = dlt.ReadStringArray( \"{textBox1.Text}\" );";
		}

		private void button_trip_Click( object sender, EventArgs e )
		{
			// 跳闸
			DateTime dateTime = DateTime.Parse( textBox_valid_time.Text );
			OperateResult op = dlt645.Trip( dateTime );
			if (op.IsSuccess)
			{
				DemoUtils.ShowMessage( "Trip success" );
			}
			else
			{
				DemoUtils.ShowMessage( "Trip failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult result = dlt.Trip( DateTime.Parse( \"{textBox_valid_time.Text}\" ) );";
		}

		private void button_SwitchingOn_Click( object sender, EventArgs e )
		{
			// 合闸允许
			DateTime dateTime = DateTime.Parse( textBox_valid_time.Text );
			OperateResult op = dlt645.SwitchingOn( dateTime );
			if (op.IsSuccess)
			{
				DemoUtils.ShowMessage( "SwitchingOn success" );
			}
			else
			{
				DemoUtils.ShowMessage( "SwitchingOn failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult result = dlt.SwitchingOn( DateTime.Parse( \"{textBox_valid_time.Text}\" ) );";
		}

		private void DLT645Control_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
				button3.Text = "Active";
				button4.Text = "Read Station";
				button6.Text = "broadcasting time";
				button5.Text = "Write Station";
				button7.Text = "Read raw string";
				label1.Text = "valid time";
				label2.Text = "Address:";
				button_trip.Text = "trip";
				button_SwitchingOn.Text = "SwitchingOn";
			}
		}

		private void button_change_Click( object sender, EventArgs e )
		{
			// 修改波特率
			string baudRate = "9600";
			if (radioButton_600.Checked) baudRate = "600";
			else if (radioButton_1200.Checked) baudRate = "1200";
			else if (radioButton_2400.Checked) baudRate = "2400";
			else if (radioButton_4800.Checked) baudRate = "4800";
			else if (radioButton_9600.Checked) baudRate = "9600";
			else if (radioButton_19200.Checked) baudRate = "19200";
			OperateResult op = dlt645.ChangeBaudRate( baudRate );
			if (op.IsSuccess)
			{
				if ( Program.Language == 1)
				{
					DemoUtils.ShowMessage( "波特率修改成功，请修改波特率文本框的值，然后重新关闭打开连接。" );
				}
				else
				{
					DemoUtils.ShowMessage( "The baud rate has been successfully modified. Please adjust the baud rate textbox value and then reconnect." );
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Change BaudRate failed: " + op.Message );
			}
			textBox_code.Text = $"OperateResult result = dlt.ChangeBaudRate( \"{baudRate}\" );";
		}
	}
}
