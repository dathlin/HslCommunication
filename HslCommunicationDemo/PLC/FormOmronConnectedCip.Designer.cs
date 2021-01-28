namespace HslCommunicationDemo
{
    partial class FormOmronConnectedCip
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.button26 = new System.Windows.Forms.Button();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button25 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.button5 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(14, 44);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 42);
			this.panel1.TabIndex = 0;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(819, 2);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(154, 45);
			this.label22.TabIndex = 7;
			this.label22.Text = "变量的标签名";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(745, 2);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(68, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "地址示例：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(629, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(522, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(269, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(84, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "44818";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(215, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(141, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "192.168.0.100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip地址：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteOp1);
			this.panel2.Controls.Add(this.groupBox5);
			this.panel2.Controls.Add(this.groupBox4);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Location = new System.Drawing.Point(14, 95);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 537);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteOp1
			// 
			this.userControlReadWriteOp1.Location = new System.Drawing.Point(11, 2);
			this.userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			this.userControlReadWriteOp1.Size = new System.Drawing.Size(954, 240);
			this.userControlReadWriteOp1.TabIndex = 5;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.button5);
			this.groupBox5.Controls.Add(this.textBox7);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.textBox5);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.textBox4);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.button4);
			this.groupBox5.Controls.Add(this.textBox3);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Location = new System.Drawing.Point(546, 243);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(419, 278);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "特殊功能测试";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(65, 161);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(331, 23);
			this.textBox7.TabIndex = 24;
			this.textBox7.Text = "1";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 164);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 17);
			this.label7.TabIndex = 23;
			this.label7.Text = "长度：";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(65, 83);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox5.Size = new System.Drawing.Size(331, 72);
			this.textBox5.TabIndex = 22;
			this.textBox5.Text = "64";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 21;
			this.label6.Text = "数据：";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(65, 53);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(331, 23);
			this.textBox4.TabIndex = 20;
			this.textBox4.Text = "C1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "类型：";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(14, 190);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(99, 28);
			this.button4.TabIndex = 18;
			this.button4.Text = "写入";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(65, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(331, 23);
			this.textBox3.TabIndex = 17;
			this.textBox3.Text = "A1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "地址：";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox11);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.button26);
			this.groupBox4.Controls.Add(this.textBox13);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Location = new System.Drawing.Point(11, 403);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(518, 118);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "CIP报文读取测试，此处需要填入完整的16进制报文字符串";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(63, 60);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox11.Size = new System.Drawing.Size(445, 52);
			this.textBox11.TabIndex = 10;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(9, 62);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 17);
			this.label14.TabIndex = 9;
			this.label14.Text = "结果：";
			// 
			// button26
			// 
			this.button26.Location = new System.Drawing.Point(426, 24);
			this.button26.Name = "button26";
			this.button26.Size = new System.Drawing.Size(82, 28);
			this.button26.TabIndex = 8;
			this.button26.Text = "报文读取";
			this.button26.UseVisualStyleBackColor = true;
			this.button26.Click += new System.EventHandler(this.button26_Click);
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(63, 27);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(357, 23);
			this.textBox13.TabIndex = 5;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(9, 30);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(44, 17);
			this.label16.TabIndex = 4;
			this.label16.Text = "报文：";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.textBox10);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.button25);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Location = new System.Drawing.Point(11, 243);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(518, 154);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "批量读取测试，分号间隔";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(426, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 15;
			this.button3.Text = "报文生成";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(306, 27);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(49, 23);
			this.textBox9.TabIndex = 12;
			this.textBox9.Text = "1";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(256, 30);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 17);
			this.label12.TabIndex = 11;
			this.label12.Text = "长度：";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(63, 60);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(445, 78);
			this.textBox10.TabIndex = 10;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(9, 62);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 9;
			this.label13.Text = "结果：";
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(361, 24);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(62, 28);
			this.button25.TabIndex = 8;
			this.button25.Text = "读取";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(63, 27);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(186, 23);
			this.textBox6.TabIndex = 5;
			this.textBox6.Text = "A1;A2";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 30);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 4;
			this.label11.Text = "地址：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/9607929.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Connected CIP";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(119, 190);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(99, 28);
			this.button5.TabIndex = 25;
			this.button5.Text = "PLC 型号";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// FormOmronConnectedCip
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormOmronConnectedCip";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Omron访问Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox9;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
		private DemoControl.UserControlReadWriteOp userControlReadWriteOp1;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button5;
	}
}