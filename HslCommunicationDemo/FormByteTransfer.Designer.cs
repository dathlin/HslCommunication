namespace HslCommunicationDemo
{
    partial class FormByteTransfer
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.radioButton15 = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.hslPanelText1 = new HslControls.HslPanelText();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radioButton14 = new System.Windows.Forms.RadioButton();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButton13 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.button5 = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.hslPanelText1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.radioButton15);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.hslPanelText1);
			this.panel2.Controls.Add(this.radioButton14);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.radioButton13);
			this.panel2.Controls.Add(this.radioButton12);
			this.panel2.Controls.Add(this.radioButton11);
			this.panel2.Controls.Add(this.radioButton10);
			this.panel2.Controls.Add(this.radioButton9);
			this.panel2.Controls.Add(this.radioButton8);
			this.panel2.Controls.Add(this.radioButton7);
			this.panel2.Controls.Add(this.radioButton6);
			this.panel2.Controls.Add(this.radioButton5);
			this.panel2.Controls.Add(this.radioButton4);
			this.panel2.Controls.Add(this.radioButton3);
			this.panel2.Controls.Add(this.radioButton2);
			this.panel2.Controls.Add(this.radioButton1);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.textBox2);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Location = new System.Drawing.Point(15, 39);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(977, 594);
			this.panel2.TabIndex = 33;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(450, 146);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(110, 26);
			this.button4.TabIndex = 38;
			this.button4.Text = "计算MD5";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(334, 146);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(110, 26);
			this.button3.TabIndex = 37;
			this.button3.Text = "打开文件";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// radioButton15
			// 
			this.radioButton15.AutoSize = true;
			this.radioButton15.Location = new System.Drawing.Point(102, 119);
			this.radioButton15.Name = "radioButton15";
			this.radioButton15.Size = new System.Drawing.Size(77, 21);
			this.radioButton15.TabIndex = 36;
			this.radioButton15.Text = "datetime";
			this.radioButton15.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 121);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 35;
			this.label5.Text = "时间数据：";
			// 
			// hslPanelText1
			// 
			this.hslPanelText1.Controls.Add(this.textBox3);
			this.hslPanelText1.Controls.Add(this.label2);
			this.hslPanelText1.Location = new System.Drawing.Point(571, 37);
			this.hslPanelText1.Name = "hslPanelText1";
			this.hslPanelText1.Size = new System.Drawing.Size(389, 101);
			this.hslPanelText1.TabIndex = 34;
			this.hslPanelText1.Text = "时间戳转换";
			this.hslPanelText1.TextOffect = 20;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(89, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(144, 23);
			this.textBox3.TabIndex = 1;
			this.textBox3.Text = "1970-1-1 08:00:00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "起始时间：";
			// 
			// radioButton14
			// 
			this.radioButton14.AutoSize = true;
			this.radioButton14.Location = new System.Drawing.Point(166, 91);
			this.radioButton14.Name = "radioButton14";
			this.radioButton14.Size = new System.Drawing.Size(49, 21);
			this.radioButton14.TabIndex = 33;
			this.radioButton14.Text = "ansi";
			this.radioButton14.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(218, 146);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 26);
			this.button2.TabIndex = 32;
			this.button2.Text = "反向转换";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(102, 146);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 26);
			this.button1.TabIndex = 31;
			this.button1.Text = "转换";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 17);
			this.label8.TabIndex = 30;
			this.label8.Text = "字符数据：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 29;
			this.label6.Text = "浮点数据：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 28;
			this.label3.Text = "整型数据：";
			// 
			// radioButton13
			// 
			this.radioButton13.AutoSize = true;
			this.radioButton13.Location = new System.Drawing.Point(373, 91);
			this.radioButton13.Name = "radioButton13";
			this.radioButton13.Size = new System.Drawing.Size(60, 21);
			this.radioButton13.TabIndex = 27;
			this.radioButton13.Text = "utf-32";
			this.radioButton13.UseVisualStyleBackColor = true;
			// 
			// radioButton12
			// 
			this.radioButton12.AutoSize = true;
			this.radioButton12.Location = new System.Drawing.Point(311, 91);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.Size = new System.Drawing.Size(53, 21);
			this.radioButton12.TabIndex = 26;
			this.radioButton12.Text = "utf-8";
			this.radioButton12.UseVisualStyleBackColor = true;
			// 
			// radioButton11
			// 
			this.radioButton11.AutoSize = true;
			this.radioButton11.Location = new System.Drawing.Point(233, 91);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(72, 21);
			this.radioButton11.TabIndex = 25;
			this.radioButton11.Text = "unicode";
			this.radioButton11.UseVisualStyleBackColor = true;
			// 
			// radioButton10
			// 
			this.radioButton10.AutoSize = true;
			this.radioButton10.Location = new System.Drawing.Point(102, 91);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(51, 21);
			this.radioButton10.TabIndex = 24;
			this.radioButton10.Text = "ascii";
			this.radioButton10.UseVisualStyleBackColor = true;
			// 
			// radioButton9
			// 
			this.radioButton9.AutoSize = true;
			this.radioButton9.Location = new System.Drawing.Point(166, 64);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(67, 21);
			this.radioButton9.TabIndex = 23;
			this.radioButton9.Text = "double";
			this.radioButton9.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(102, 64);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(52, 21);
			this.radioButton8.TabIndex = 22;
			this.radioButton8.Text = "float";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(474, 37);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(59, 21);
			this.radioButton7.TabIndex = 21;
			this.radioButton7.Text = "ulong";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(416, 37);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(52, 21);
			this.radioButton6.TabIndex = 20;
			this.radioButton6.Text = "long";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(363, 37);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(47, 21);
			this.radioButton5.TabIndex = 19;
			this.radioButton5.Text = "uint";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Checked = true;
			this.radioButton4.Location = new System.Drawing.Point(306, 37);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(40, 21);
			this.radioButton4.TabIndex = 18;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "int";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(233, 37);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(63, 21);
			this.radioButton3.TabIndex = 17;
			this.radioButton3.Text = "ushort";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(166, 37);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(56, 21);
			this.radioButton2.TabIndex = 16;
			this.radioButton2.Text = "short";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(102, 37);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(51, 21);
			this.radioButton1.TabIndex = 15;
			this.radioButton1.Text = "byte";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 17);
			this.label1.TabIndex = 14;
			this.label1.Text = "输出：(Hex)";
			// 
			// textBox2
			// 
			this.textBox2.AllowDrop = true;
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox2.Location = new System.Drawing.Point(102, 178);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(870, 411);
			this.textBox2.TabIndex = 8;
			this.textBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox2_DragDrop);
			this.textBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox2_DragEnter);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(102, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(858, 23);
			this.textBox1.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "等待转换的值：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7703805.htmln";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Byte";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 34;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(566, 146);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(110, 26);
			this.button5.TabIndex = 39;
			this.button5.Text = "图片base64";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// FormByteTransfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormByteTransfer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "字节转换工具";
			this.Load += new System.EventHandler(this.FormByteTransfer_Load);
			this.Shown += new System.EventHandler(this.FormByteTransfer_Shown);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.hslPanelText1.ResumeLayout(false);
			this.hslPanelText1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton14;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.Label label5;
        private HslControls.HslPanelText hslPanelText1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}