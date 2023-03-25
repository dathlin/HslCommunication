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
	public class YokogawaLinkControl : SpecialFeaturesControl
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
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;

		public YokogawaLinkControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
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
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button11);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.button9);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(650, 223);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "YokogawaLink";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(539, 87);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(111, 28);
			this.button11.TabIndex = 40;
			this.button11.Text = "DateTime";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(422, 87);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(111, 28);
			this.button10.TabIndex = 39;
			this.button10.Text = "SystemInfo";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(422, 155);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(118, 28);
			this.button9.TabIndex = 38;
			this.button9.Text = "ProgramStatus";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(486, 121);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(58, 28);
			this.button8.TabIndex = 37;
			this.button8.Text = "Stop";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(422, 121);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(58, 28);
			this.button7.TabIndex = 36;
			this.button7.Text = "Start";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(539, 53);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(111, 28);
			this.button6.TabIndex = 35;
			this.button6.Text = "随机写入读取";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(422, 53);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(111, 28);
			this.button5.TabIndex = 34;
			this.button5.Text = "随机word读取";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(539, 19);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(111, 28);
			this.button4.TabIndex = 33;
			this.button4.Text = "随机Bool写入";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox4.Location = new System.Drawing.Point(74, 93);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(342, 120);
			this.textBox4.TabIndex = 32;
			this.textBox4.Text = "true,true,true,true";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 17);
			this.label5.TabIndex = 31;
			this.label5.Text = "值：";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(422, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(111, 28);
			this.button3.TabIndex = 30;
			this.button3.Text = "随机Bool读取";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(74, 25);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(342, 62);
			this.textBox5.TabIndex = 29;
			this.textBox5.Text = "Y100;Y200;M100;M300";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 28;
			this.label6.Text = "地址：";
			// 
			// YokogawaLinkControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "YokogawaLinkControl";
			this.Size = new System.Drawing.Size(904, 229);
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}


		private YokogawaLinkTcp yokogawa;

		public void SetDevice( YokogawaLinkTcp yokogawa, string address )
		{
			this.yokogawa = yokogawa;
			base.SetDevice( yokogawa, address );
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
		}


		private void button7_Click( object sender, EventArgs e )
		{
			// start
			OperateResult start = yokogawa.Start( );
			if (start.IsSuccess) MessageBox.Show( "Started Success!" );
			else MessageBox.Show( "Started failed: " + start.ToMessageShowString( ) );
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// stop
			OperateResult stop = yokogawa.Stop( );
			if (stop.IsSuccess) MessageBox.Show( "Stop Success!" );
			else MessageBox.Show( "Stop failed: " + stop.ToMessageShowString( ) );
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
		}
	}
}
