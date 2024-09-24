using HslCommunication;
using HslCommunication.Profinet.Yokogawa;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Yokogawa
{
	public class YokogawaLinkControl : UserControl
	{
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox5;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Label label6;

		public YokogawaLinkControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(586, 69);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(158, 28);
			this.button11.TabIndex = 40;
			this.button11.Text = "DateTime";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(411, 69);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(169, 28);
			this.button10.TabIndex = 39;
			this.button10.Text = "SystemInfo";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(411, 137);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(122, 28);
			this.button9.TabIndex = 38;
			this.button9.Text = "ProgramStatus";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(475, 103);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(58, 28);
			this.button8.TabIndex = 37;
			this.button8.Text = "Stop";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(411, 103);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(58, 28);
			this.button7.TabIndex = 36;
			this.button7.Text = "Start";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(586, 35);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(158, 28);
			this.button6.TabIndex = 35;
			this.button6.Text = "随机写入读取";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(411, 35);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(169, 28);
			this.button5.TabIndex = 34;
			this.button5.Text = "随机word读取";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(586, 1);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(158, 28);
			this.button4.TabIndex = 33;
			this.button4.Text = "随机Bool写入";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox4.Location = new System.Drawing.Point(63, 75);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(342, 137);
			this.textBox4.TabIndex = 32;
			this.textBox4.Text = "true,true,true,true";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 17);
			this.label5.TabIndex = 31;
			this.label5.Text = "值：";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(411, 1);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(169, 28);
			this.button3.TabIndex = 30;
			this.button3.Text = "随机Bool读取";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(63, 7);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(342, 62);
			this.textBox5.TabIndex = 29;
			this.textBox5.Text = "Y100;Y200;M100;M300";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 28;
			this.label6.Text = "地址：";
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(9, 221);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 41;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(63, 218);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(885, 58);
			this.textBox_code.TabIndex = 42;
			// 
			// YokogawaLinkControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "YokogawaLinkControl";
			this.Size = new System.Drawing.Size(951, 279);
			this.Load += new System.EventHandler(this.YokogawaLinkControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		private YokogawaLinkTcp yokogawa;

		public void SetDevice( YokogawaLinkTcp yokogawa, string address )
		{
			this.yokogawa = yokogawa;
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 随机bool读取
			OperateResult<bool[]> read = yokogawa.ReadRandomBool( textBox5.Text.Split( new char[] { ';' } ) );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToArrayString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<bool[]> read = {DemoUtils.PlcDeviceName}.ReadRandomBool( \"{textBox5.Text}\".Split( new char[] {';'} ) );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 随机bool写入
			OperateResult write = yokogawa.WriteRandomBool( textBox5.Text.Split( new char[] { ';' } ), textBox4.Text.ToStringArray<bool>( ) );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success!" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + write.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteRandomBool( \"{textBox5.Text}\".Split( new char[] {';'} ), \"{textBox4.Text}\".ToStringArray<bool>( ) );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 随机word读取
			OperateResult<short[]> read = yokogawa.ReadRandomInt16( textBox5.Text.Split( new char[] { ';' } ) );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToArrayString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<short[]> read = {DemoUtils.PlcDeviceName}.ReadRandomInt16( \"{textBox5.Text}\".Split( new char[] {';'} ) );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 随机word写入
			OperateResult write = yokogawa.WriteRandom( textBox5.Text.Split( new char[] { ';' } ), textBox4.Text.ToStringArray<short>( ) );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success!" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + write.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteRandom( \"{textBox5.Text}\".Split( new char[] {';'} ), \"{textBox4.Text}\".ToStringArray<short>( ) );";
		}


		private void button7_Click( object sender, EventArgs e )
		{
			// start
			OperateResult start = yokogawa.Start( );
			if (start.IsSuccess) MessageBox.Show( "Started Success!" );
			else MessageBox.Show( "Started failed: " + start.ToMessageShowString( ) );

			textBox_code.Text = $"OperateResult start = {DemoUtils.PlcDeviceName}.Start( );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// stop
			OperateResult stop = yokogawa.Stop( );
			if (stop.IsSuccess) MessageBox.Show( "Stop Success!" );
			else MessageBox.Show( "Stop failed: " + stop.ToMessageShowString( ) );

			textBox_code.Text = $"OperateResult stop = {DemoUtils.PlcDeviceName}.Stop( );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// ProgramStatus
			OperateResult<int> read = yokogawa.ReadProgramStatus( );
			if (read.IsSuccess)
			{
				switch (read.Content)
				{
					case 1: textBox4.Text = "1 : RUN"; break;
					case 2: textBox4.Text = "2 : Stop"; break;
					case 3: textBox4.Text = "3 : Debug"; break;
					case 4: textBox4.Text = "4 : Rom writer"; break;
					default: textBox4.Text = read.Content.ToString( ); break;
				}
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read  = {DemoUtils.PlcDeviceName}.ReadProgramStatus( );";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// SystemInfo
			OperateResult<YokogawaSystemInfo> read = yokogawa.ReadSystemInfo( );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<YokogawaSystemInfo> read  = {DemoUtils.PlcDeviceName}.ReadSystemInfo( );";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// DateTime
			OperateResult<DateTime> read = yokogawa.ReadDateTime( );
			if (read.IsSuccess)
			{
				textBox4.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<DateTime> read  = {DemoUtils.PlcDeviceName}.ReadDateTime( );";
		}

		private void YokogawaLinkControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label6.Text = "Address:";
				label5.Text = "Value:";
				label_code.Text = "Code:";

				button3.Text = "Random-bool-read";
				button4.Text = "Random-bool-write";
				button5.Text = "Random-word-read";
				button6.Text = "Random-wrod-write";
			}
		}


	}
}
