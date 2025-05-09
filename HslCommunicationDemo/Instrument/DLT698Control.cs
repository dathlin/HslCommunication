using HslCommunication;
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
	public class DLT698Control : UserControl
	{
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox_address;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private Label label_code;
		private TextBox textBox_code;
		private Button button1;
		private Label label1;
		private TextBox textBox_write_value;
		private TextBox textBox_station;
		private Label label3;
		private Button button_write_datetime;
		private System.Windows.Forms.TextBox textBox12;

		public DLT698Control( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox_address = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_write_value = new System.Windows.Forms.TextBox();
			this.textBox_station = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button_write_datetime = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(413, 36);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(151, 28);
			this.button7.TabIndex = 26;
			this.button7.Text = "读取原始字符串";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Enabled = false;
			this.button6.Location = new System.Drawing.Point(225, 6);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(130, 28);
			this.button6.TabIndex = 25;
			this.button6.Text = "广播时间";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(639, 6);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(106, 28);
			this.button5.TabIndex = 24;
			this.button5.Text = "写入通信地址";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox_address
			// 
			this.textBox_address.Location = new System.Drawing.Point(60, 40);
			this.textBox_address.Name = "textBox_address";
			this.textBox_address.Size = new System.Drawing.Size(347, 23);
			this.textBox_address.TabIndex = 23;
			this.textBox_address.Text = "20-00-02-00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 22;
			this.label2.Text = "地址：";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(108, 6);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(111, 28);
			this.button4.TabIndex = 21;
			this.button4.Text = "读取通信地址";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 6);
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
			this.textBox12.Location = new System.Drawing.Point(6, 99);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(768, 99);
			this.textBox12.TabIndex = 19;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(6, 206);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 27;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(56, 203);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(718, 40);
			this.textBox_code.TabIndex = 28;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(570, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(151, 28);
			this.button1.TabIndex = 29;
			this.button1.Text = "读取多个地址(;隔开)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 30;
			this.label1.Text = "值：";
			// 
			// textBox_write_value
			// 
			this.textBox_write_value.Location = new System.Drawing.Point(60, 68);
			this.textBox_write_value.Name = "textBox_write_value";
			this.textBox_write_value.Size = new System.Drawing.Size(347, 23);
			this.textBox_write_value.TabIndex = 31;
			// 
			// textBox_station
			// 
			this.textBox_station.Location = new System.Drawing.Point(425, 8);
			this.textBox_station.Name = "textBox_station";
			this.textBox_station.Size = new System.Drawing.Size(208, 23);
			this.textBox_station.TabIndex = 33;
			this.textBox_station.Text = "000000000002";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(359, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 32;
			this.label3.Text = "通信地址：";
			// 
			// button_write_datetime
			// 
			this.button_write_datetime.Location = new System.Drawing.Point(413, 65);
			this.button_write_datetime.Name = "button_write_datetime";
			this.button_write_datetime.Size = new System.Drawing.Size(106, 28);
			this.button_write_datetime.TabIndex = 34;
			this.button_write_datetime.Text = "写入日期时间";
			this.button_write_datetime.UseVisualStyleBackColor = true;
			this.button_write_datetime.Click += new System.EventHandler(this.button_write_datetime_Click);
			// 
			// DLT698Control
			// 
			this.Controls.Add(this.button_write_datetime);
			this.Controls.Add(this.textBox_station);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_write_value);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.textBox_address);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button4);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DLT698Control";
			this.Size = new System.Drawing.Size(777, 246);
			this.Load += new System.EventHandler(this.DLT698Control_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( IDlt698 dlt698, string address )
		{
			this.dlt698 = dlt698;
		}

		private IDlt698 dlt698;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult active = dlt698.ActiveDeveice( );
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
			OperateResult<string> read = dlt698.ReadAddress( );
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
			DemoUtils.ShowMessage( StringResources.Language.NotSupportedFunction );
			// 广播当前时间
			//OperateResult read = dlt698.BroadcastTime( DateTime.Now );
			//if (read.IsSuccess)
			//{
			//	textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] BroadcastTime Success";
			//}
			//else
			//{
			//	DemoUtils.ShowMessage( "Read failed: " + read.Message );
			//}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 写通信地址
			OperateResult read = dlt698.WriteAddress( textBox_address.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Write Success";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult write = dlt.WriteAddress( \"{textBox_address.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = dlt698.ReadStringArray( textBox_address.Text );
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

			textBox_code.Text = $"OperateResult<string[]> read = dlt.ReadStringArray( \"{textBox_address.Text}\" );";
		}

		private void button1_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = dlt698.ReadStringArray( textBox_address.Text.Split( new char[] { ';' } ) );
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

			textBox_code.Text = $"OperateResult<string[]> read = dlt.ReadStringArray( \"{textBox_address.Text}\" );";
		}

		private void button_write_datetime_Click( object sender, EventArgs e )
		{
			OperateResult write = dlt698.WriteDateTime( textBox_address.Text, DateTime.Parse( textBox_write_value.Text ) );
			DemoUtils.WriteResultRender( write, textBox_address.Text );
			textBox_code.Text = $"OperateResult write = dlt.WriteDateTime( \"{textBox_address.Text}\", DateTime.Parse( \"{textBox_write_value.Text}\" ) );";
		}

		private void DLT698Control_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
				label2.Text = "Address:";
				button3.Text = "Active";
				button4.Text = "Read Station";
				button6.Text = "broadcasting time";
				button5.Text = "Write Station";
				button7.Text = "Read raw string";
				label3.Text  = "Station:";
				button_write_datetime.Text = "Write DateTime";
				label1.Text  = "Value:";
			}
		}

	}
}
