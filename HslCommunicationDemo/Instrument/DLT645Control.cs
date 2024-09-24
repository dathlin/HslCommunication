using HslCommunication;
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
		private System.Windows.Forms.GroupBox groupBox1;

		public DLT645Control( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
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
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox_code);
			this.groupBox1.Controls.Add(this.label_code);
			this.groupBox1.Controls.Add(this.button_SwitchingOn);
			this.groupBox1.Controls.Add(this.button_trip);
			this.groupBox1.Controls.Add(this.textBox_valid_time);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.textBox12);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(796, 230);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DLT645 Function";
			// 
			// button_SwitchingOn
			// 
			this.button_SwitchingOn.Location = new System.Drawing.Point(618, 55);
			this.button_SwitchingOn.Name = "button_SwitchingOn";
			this.button_SwitchingOn.Size = new System.Drawing.Size(96, 28);
			this.button_SwitchingOn.TabIndex = 30;
			this.button_SwitchingOn.Text = "合闸允许";
			this.button_SwitchingOn.UseVisualStyleBackColor = true;
			this.button_SwitchingOn.Click += new System.EventHandler(this.button_SwitchingOn_Click);
			// 
			// button_trip
			// 
			this.button_trip.Location = new System.Drawing.Point(500, 55);
			this.button_trip.Name = "button_trip";
			this.button_trip.Size = new System.Drawing.Size(96, 28);
			this.button_trip.TabIndex = 29;
			this.button_trip.Text = "跳闸";
			this.button_trip.UseVisualStyleBackColor = true;
			this.button_trip.Click += new System.EventHandler(this.button_trip_Click);
			// 
			// textBox_valid_time
			// 
			this.textBox_valid_time.Location = new System.Drawing.Point(568, 25);
			this.textBox_valid_time.Name = "textBox_valid_time";
			this.textBox_valid_time.Size = new System.Drawing.Size(188, 23);
			this.textBox_valid_time.TabIndex = 28;
			this.textBox_valid_time.Text = "2024-09-18 22:34:29";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(492, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 27;
			this.label1.Text = "有效时间：";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(256, 55);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(168, 28);
			this.button7.TabIndex = 26;
			this.button7.Text = "读取原始字符串";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(214, 22);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(124, 28);
			this.button6.TabIndex = 25;
			this.button6.Text = "广播时间";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(344, 22);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(106, 28);
			this.button5.TabIndex = 24;
			this.button5.Text = "写入通信地址";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 58);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(188, 23);
			this.textBox1.TabIndex = 23;
			this.textBox1.Text = "02-01-01-00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 22;
			this.label2.Text = "地址：";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(113, 22);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(95, 28);
			this.button4.TabIndex = 21;
			this.button4.Text = "读取通信地址";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(11, 22);
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
			this.textBox12.Location = new System.Drawing.Point(11, 88);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(779, 92);
			this.textBox12.TabIndex = 19;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(8, 186);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 31;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(57, 184);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(733, 40);
			this.textBox_code.TabIndex = 32;
			// 
			// DLT645Control
			// 
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DLT645Control";
			this.Size = new System.Drawing.Size(802, 236);
			this.Load += new System.EventHandler(this.DLT645Control_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

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
				MessageBox.Show( "Send Active Code Success" );
			}
			else
			{
				MessageBox.Show( "Active Code failed:" + active.Message );
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
				MessageBox.Show( "Read failed: " + read.Message );
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
				MessageBox.Show( "Read failed: " + read.Message );
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
				MessageBox.Show( "Read failed: " + write.Message );
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
				MessageBox.Show( "Read failed: " + read.Message );
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
				MessageBox.Show( "Trip success" );
			}
			else
			{
				MessageBox.Show( "Trip failed: " + op.Message );
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
				MessageBox.Show( "SwitchingOn success" );
			}
			else
			{
				MessageBox.Show( "SwitchingOn failed: " + op.Message );
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
	}
}
