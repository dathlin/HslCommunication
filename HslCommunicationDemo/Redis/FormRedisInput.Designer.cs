namespace HslCommunicationDemo.Redis
{
    partial class FormRedisInput
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(411, 231);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage1.Size = new System.Drawing.Size(403, 201);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "键值写入";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(127, 162);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 31);
			this.button1.TabIndex = 4;
			this.button1.Text = "Write";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(54, 44);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(341, 112);
			this.textBox2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Value:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(54, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(341, 23);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Key:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage2.Size = new System.Drawing.Size(403, 201);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "哈希写入";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(61, 42);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(334, 23);
			this.textBox5.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 17);
			this.label5.TabIndex = 10;
			this.label5.Text = "Field:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(129, 159);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(140, 31);
			this.button2.TabIndex = 9;
			this.button2.Text = "Write";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(61, 71);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(334, 82);
			this.textBox3.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "Value:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(61, 8);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(334, 23);
			this.textBox4.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Key:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button3);
			this.tabPage3.Controls.Add(this.textBox6);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.textBox7);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.radioButton2);
			this.tabPage3.Controls.Add(this.radioButton1);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(403, 201);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "列表写入";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(132, 162);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(140, 31);
			this.button3.TabIndex = 9;
			this.button3.Text = "Write";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(68, 66);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(327, 90);
			this.textBox6.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 17);
			this.label6.TabIndex = 7;
			this.label6.Text = "Value";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(68, 37);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(327, 23);
			this.textBox7.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 37);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 17);
			this.label7.TabIndex = 5;
			this.label7.Text = "Key:";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(225, 6);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(87, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Right Push";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(68, 6);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(78, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Left Push";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.textBox10);
			this.tabPage4.Controls.Add(this.label10);
			this.tabPage4.Controls.Add(this.button4);
			this.tabPage4.Controls.Add(this.textBox9);
			this.tabPage4.Controls.Add(this.label9);
			this.tabPage4.Controls.Add(this.textBox8);
			this.tabPage4.Controls.Add(this.label8);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(403, 201);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "批量随机";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(67, 10);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(328, 23);
			this.textBox8.TabIndex = 3;
			this.textBox8.Text = "Keys{0}";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "Key:";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(127, 157);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(140, 31);
			this.button4.TabIndex = 7;
			this.button4.Text = "Write";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(67, 39);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox9.Size = new System.Drawing.Size(328, 77);
			this.textBox9.TabIndex = 6;
			this.textBox9.Text = "Value{0}";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 17);
			this.label9.TabIndex = 5;
			this.label9.Text = "Value:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 125);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(45, 17);
			this.label10.TabIndex = 8;
			this.label10.Text = "Times:";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(67, 122);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(328, 23);
			this.textBox10.TabIndex = 9;
			this.textBox10.Text = "10000";
			// 
			// FormRedisInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 231);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormRedisInput";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Write Redis";
			this.Load += new System.EventHandler(this.FormRedisInput_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
	}
}