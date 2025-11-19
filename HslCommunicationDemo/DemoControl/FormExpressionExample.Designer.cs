namespace HslCommunicationDemo.DemoControl
{
	partial class FormExpressionExample
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExpressionExample));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.textBox_head1 = new System.Windows.Forms.TextBox();
			this.textBox_example1 = new System.Windows.Forms.TextBox();
			this.textBox_example2 = new System.Windows.Forms.TextBox();
			this.textBox_head2 = new System.Windows.Forms.TextBox();
			this.textBox_example3 = new System.Windows.Forms.TextBox();
			this.textBox_head3 = new System.Windows.Forms.TextBox();
			this.textBox_example4 = new System.Windows.Forms.TextBox();
			this.textBox_head4 = new System.Windows.Forms.TextBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AllowDrop = true;
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(12, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(577, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "变量 x 表示从0自增的整数，可以用作变量，表达式返回的类型作为实际数据写入的类型，下面是一些表达式例子：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "方波例子:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(101, 45);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(483, 23);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "(short)(x%2==0?10:0)";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(101, 74);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(483, 23);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "(short)(x%100)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label3.Location = new System.Drawing.Point(12, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "线性函数例子:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(101, 103);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(483, 23);
			this.textBox3.TabIndex = 6;
			this.textBox3.Text = "(short)(Math.Sin(2*Math.PI*x/100)*100)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(12, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "三角函数例子:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(101, 132);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(483, 23);
			this.textBox4.TabIndex = 8;
			this.textBox4.Text = "(short)r.Next(100,200)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label5.Location = new System.Drawing.Point(12, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "随机数例子:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(101, 164);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(483, 23);
			this.textBox5.TabIndex = 10;
			this.textBox5.Text = "(short)(Math.Sin(2*Math.PI*x/100)*100+100+r.Next(6))";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label6.Location = new System.Drawing.Point(12, 167);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 17);
			this.label6.TabIndex = 9;
			this.label6.Text = "三角函数抖动:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox1.Location = new System.Drawing.Point(588, 49);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox2.Location = new System.Drawing.Point(588, 78);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(16, 16);
			this.pictureBox2.TabIndex = 12;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox3.Location = new System.Drawing.Point(588, 107);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(16, 16);
			this.pictureBox3.TabIndex = 13;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox4.Location = new System.Drawing.Point(588, 136);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(16, 16);
			this.pictureBox4.TabIndex = 14;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox5.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox5.Location = new System.Drawing.Point(588, 168);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(16, 16);
			this.pictureBox5.TabIndex = 15;
			this.pictureBox5.TabStop = false;
			// 
			// textBox_head1
			// 
			this.textBox_head1.Location = new System.Drawing.Point(12, 225);
			this.textBox_head1.Name = "textBox_head1";
			this.textBox_head1.Size = new System.Drawing.Size(83, 23);
			this.textBox_head1.TabIndex = 16;
			this.textBox_head1.Text = "自定义1";
			// 
			// textBox_example1
			// 
			this.textBox_example1.Location = new System.Drawing.Point(101, 225);
			this.textBox_example1.Name = "textBox_example1";
			this.textBox_example1.Size = new System.Drawing.Size(483, 23);
			this.textBox_example1.TabIndex = 17;
			this.textBox_example1.Text = "(int)x";
			// 
			// textBox_example2
			// 
			this.textBox_example2.Location = new System.Drawing.Point(101, 254);
			this.textBox_example2.Name = "textBox_example2";
			this.textBox_example2.Size = new System.Drawing.Size(483, 23);
			this.textBox_example2.TabIndex = 19;
			this.textBox_example2.Text = "(int)x";
			// 
			// textBox_head2
			// 
			this.textBox_head2.Location = new System.Drawing.Point(12, 254);
			this.textBox_head2.Name = "textBox_head2";
			this.textBox_head2.Size = new System.Drawing.Size(83, 23);
			this.textBox_head2.TabIndex = 18;
			this.textBox_head2.Text = "自定义2";
			// 
			// textBox_example3
			// 
			this.textBox_example3.Location = new System.Drawing.Point(101, 283);
			this.textBox_example3.Name = "textBox_example3";
			this.textBox_example3.Size = new System.Drawing.Size(483, 23);
			this.textBox_example3.TabIndex = 21;
			this.textBox_example3.Text = "(int)x";
			// 
			// textBox_head3
			// 
			this.textBox_head3.Location = new System.Drawing.Point(12, 283);
			this.textBox_head3.Name = "textBox_head3";
			this.textBox_head3.Size = new System.Drawing.Size(83, 23);
			this.textBox_head3.TabIndex = 20;
			this.textBox_head3.Text = "自定义3";
			// 
			// textBox_example4
			// 
			this.textBox_example4.Location = new System.Drawing.Point(101, 312);
			this.textBox_example4.Name = "textBox_example4";
			this.textBox_example4.Size = new System.Drawing.Size(483, 23);
			this.textBox_example4.TabIndex = 23;
			this.textBox_example4.Text = "(int)x";
			// 
			// textBox_head4
			// 
			this.textBox_head4.Location = new System.Drawing.Point(12, 312);
			this.textBox_head4.Name = "textBox_head4";
			this.textBox_head4.Size = new System.Drawing.Size(83, 23);
			this.textBox_head4.TabIndex = 22;
			this.textBox_head4.Text = "自定义4";
			// 
			// pictureBox6
			// 
			this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox6.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox6.Location = new System.Drawing.Point(588, 227);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(16, 16);
			this.pictureBox6.TabIndex = 24;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox7.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox7.Location = new System.Drawing.Point(588, 258);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(16, 16);
			this.pictureBox7.TabIndex = 25;
			this.pictureBox7.TabStop = false;
			// 
			// pictureBox8
			// 
			this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox8.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox8.Location = new System.Drawing.Point(588, 288);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(16, 16);
			this.pictureBox8.TabIndex = 26;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox9
			// 
			this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox9.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox9.Location = new System.Drawing.Point(588, 316);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(16, 16);
			this.pictureBox9.TabIndex = 27;
			this.pictureBox9.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(224, 341);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 35);
			this.button1.TabIndex = 28;
			this.button1.Text = "保存自定义";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox10
			// 
			this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox10.Image = global::HslCommunicationDemo.Properties.Resources.Copy_6524;
			this.pictureBox10.Location = new System.Drawing.Point(588, 198);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(16, 16);
			this.pictureBox10.TabIndex = 31;
			this.pictureBox10.TabStop = false;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(101, 194);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(483, 23);
			this.textBox6.TabIndex = 30;
			this.textBox6.Text = "\"A\"+(x%100).ToString().PadLeft(7, \'0\')";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label7.Location = new System.Drawing.Point(12, 197);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 17);
			this.label7.TabIndex = 29;
			this.label7.Text = "字符串例子:";
			// 
			// FormExpressionExample
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(616, 385);
			this.Controls.Add(this.pictureBox10);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox9);
			this.Controls.Add(this.pictureBox8);
			this.Controls.Add(this.pictureBox7);
			this.Controls.Add(this.pictureBox6);
			this.Controls.Add(this.textBox_example4);
			this.Controls.Add(this.textBox_head4);
			this.Controls.Add(this.textBox_example3);
			this.Controls.Add(this.textBox_head3);
			this.Controls.Add(this.textBox_example2);
			this.Controls.Add(this.textBox_head2);
			this.Controls.Add(this.textBox_example1);
			this.Controls.Add(this.textBox_head1);
			this.Controls.Add(this.pictureBox5);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(632, 424);
			this.MinimumSize = new System.Drawing.Size(632, 424);
			this.Name = "FormExpressionExample";
			this.Text = "ExpressionExample";
			this.Load += new System.EventHandler(this.FormExpressionExample_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.TextBox textBox_head1;
		private System.Windows.Forms.TextBox textBox_example1;
		private System.Windows.Forms.TextBox textBox_example2;
		private System.Windows.Forms.TextBox textBox_head2;
		private System.Windows.Forms.TextBox textBox_example3;
		private System.Windows.Forms.TextBox textBox_head3;
		private System.Windows.Forms.TextBox textBox_example4;
		private System.Windows.Forms.TextBox textBox_head4;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
	}
}