namespace HslCommunicationDemo
{
    partial class FormSAMSerial
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
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button_sam_start = new System.Windows.Forms.Button();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.button_sam5 = new System.Windows.Forms.Button();
			this.button_sam4 = new System.Windows.Forms.Button();
			this.button_sam3 = new System.Windows.Forms.Button();
			this.button_sam2 = new System.Windows.Forms.Button();
			this.button_sam1 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.comboBox3);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox17);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox16);
			this.panel1.Controls.Add(this.label25);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label26);
			this.panel1.Controls.Add(this.label27);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 46);
			this.panel1.TabIndex = 0;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(71, 8);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(67, 25);
			this.comboBox3.TabIndex = 40;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
			this.comboBox1.Location = new System.Drawing.Point(557, 9);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(59, 25);
			this.comboBox1.TabIndex = 25;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(504, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 24;
			this.label1.Text = "奇偶：";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(461, 9);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(23, 23);
			this.textBox17.TabIndex = 23;
			this.textBox17.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(395, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 22;
			this.label3.Text = "停止位：";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(355, 9);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(24, 23);
			this.textBox16.TabIndex = 21;
			this.textBox16.Text = "8";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(286, 12);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 17);
			this.label25.TabIndex = 20;
			this.label25.Text = "数据位：";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(211, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(67, 23);
			this.textBox2.TabIndex = 19;
			this.textBox2.Text = "115200";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(144, 12);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 17);
			this.label26.TabIndex = 18;
			this.label26.Text = "波特率：";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(8, 12);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(59, 17);
			this.label27.TabIndex = 16;
			this.label27.Text = "Com口：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(875, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭串口";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(778, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "打开串口";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Location = new System.Drawing.Point(3, 83);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 560);
			this.panel2.TabIndex = 1;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.pictureBox1);
			this.groupBox3.Controls.Add(this.textBox10);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.button_sam_start);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Location = new System.Drawing.Point(11, 243);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(977, 306);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "定时读取测试";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(782, 60);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(189, 240);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(63, 60);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(713, 240);
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
			// button_sam_start
			// 
			this.button_sam_start.Location = new System.Drawing.Point(181, 24);
			this.button_sam_start.Name = "button_sam_start";
			this.button_sam_start.Size = new System.Drawing.Size(82, 28);
			this.button_sam_start.TabIndex = 8;
			this.button_sam_start.Text = "启动读取";
			this.button_sam_start.UseVisualStyleBackColor = true;
			this.button_sam_start.Click += new System.EventHandler(this.button_sam_start_Click);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(63, 27);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(102, 23);
			this.textBox9.TabIndex = 7;
			this.textBox9.Text = "100";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 30);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 4;
			this.label11.Text = "间隔：";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.button_sam5);
			this.groupBox1.Controls.Add(this.button_sam4);
			this.groupBox1.Controls.Add(this.button_sam3);
			this.groupBox1.Controls.Add(this.button_sam2);
			this.groupBox1.Controls.Add(this.button_sam1);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(11, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(977, 234);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "单数据读取测试";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Location = new System.Drawing.Point(833, 58);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(138, 162);
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			// 
			// button_sam5
			// 
			this.button_sam5.Location = new System.Drawing.Point(462, 24);
			this.button_sam5.Name = "button_sam5";
			this.button_sam5.Size = new System.Drawing.Size(92, 28);
			this.button_sam5.TabIndex = 12;
			this.button_sam5.Text = "读取身份证";
			this.button_sam5.UseVisualStyleBackColor = true;
			this.button_sam5.Click += new System.EventHandler(this.button_sam5_Click);
			// 
			// button_sam4
			// 
			this.button_sam4.Location = new System.Drawing.Point(370, 24);
			this.button_sam4.Name = "button_sam4";
			this.button_sam4.Size = new System.Drawing.Size(82, 28);
			this.button_sam4.TabIndex = 11;
			this.button_sam4.Text = "选择卡片";
			this.button_sam4.UseVisualStyleBackColor = true;
			this.button_sam4.Click += new System.EventHandler(this.button_sam4_Click);
			// 
			// button_sam3
			// 
			this.button_sam3.Location = new System.Drawing.Point(282, 24);
			this.button_sam3.Name = "button_sam3";
			this.button_sam3.Size = new System.Drawing.Size(82, 28);
			this.button_sam3.TabIndex = 10;
			this.button_sam3.Text = "寻找卡片";
			this.button_sam3.UseVisualStyleBackColor = true;
			this.button_sam3.Click += new System.EventHandler(this.button_sam3_Click);
			// 
			// button_sam2
			// 
			this.button_sam2.Location = new System.Drawing.Point(164, 24);
			this.button_sam2.Name = "button_sam2";
			this.button_sam2.Size = new System.Drawing.Size(112, 28);
			this.button_sam2.TabIndex = 9;
			this.button_sam2.Text = "检测安全模块状态";
			this.button_sam2.UseVisualStyleBackColor = true;
			this.button_sam2.Click += new System.EventHandler(this.button_sam2_Click);
			// 
			// button_sam1
			// 
			this.button_sam1.Location = new System.Drawing.Point(63, 24);
			this.button_sam1.Name = "button_sam1";
			this.button_sam1.Size = new System.Drawing.Size(95, 28);
			this.button_sam1.TabIndex = 8;
			this.button_sam1.Text = "安全模块号";
			this.button_sam1.UseVisualStyleBackColor = true;
			this.button_sam1.Click += new System.EventHandler(this.button_sam1_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(63, 56);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(764, 164);
			this.textBox4.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 17);
			this.label7.TabIndex = 4;
			this.label7.Text = "结果：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 2;
			this.label6.Text = "地址：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "SAM";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormSAMSerial
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
			this.Name = "FormSAMSerial";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "身份证阅读器的SAM协议Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_sam5;
        private System.Windows.Forms.Button button_sam4;
        private System.Windows.Forms.Button button_sam3;
        private System.Windows.Forms.Button button_sam2;
        private System.Windows.Forms.Button button_sam1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_sam_start;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ComboBox comboBox3;
	}
}