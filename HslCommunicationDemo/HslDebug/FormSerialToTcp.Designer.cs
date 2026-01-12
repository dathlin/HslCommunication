namespace HslCommunicationDemo
{
    partial class FormSerialToTcp
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
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox_rts = new System.Windows.Forms.CheckBox();
			this.comboBox_com = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox_stop = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox_data_bits = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_baut = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button_clear = new System.Windows.Forms.Button();
			this.label_tcp_serial_length = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label_serial_tcp_length = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox_show_hex = new System.Windows.Forms.CheckBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.checkBox_show_send = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.checkBox_rts);
			this.panel1.Controls.Add(this.comboBox_com);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.textBox_stop);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.textBox_data_bits);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_baut);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 37);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1019, 70);
			this.panel1.TabIndex = 7;
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(75, 36);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(118, 23);
			this.textBox_port.TabIndex = 19;
			this.textBox_port.Text = "502";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 18;
			this.label2.Text = "Tcp Port：";
			// 
			// checkBox_rts
			// 
			this.checkBox_rts.AutoSize = true;
			this.checkBox_rts.Location = new System.Drawing.Point(601, 9);
			this.checkBox_rts.Name = "checkBox_rts";
			this.checkBox_rts.Size = new System.Drawing.Size(84, 21);
			this.checkBox_rts.TabIndex = 17;
			this.checkBox_rts.Text = "RtsEnable";
			this.checkBox_rts.UseVisualStyleBackColor = true;
			// 
			// comboBox_com
			// 
			this.comboBox_com.FormattingEnabled = true;
			this.comboBox_com.Location = new System.Drawing.Point(58, 4);
			this.comboBox_com.Name = "comboBox_com";
			this.comboBox_com.Size = new System.Drawing.Size(111, 25);
			this.comboBox_com.TabIndex = 16;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
			this.comboBox1.Location = new System.Drawing.Point(526, 6);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(59, 25);
			this.comboBox1.TabIndex = 15;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(483, 9);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(44, 17);
			this.label24.TabIndex = 14;
			this.label24.Text = "奇偶：";
			// 
			// textBox_stop
			// 
			this.textBox_stop.Location = new System.Drawing.Point(453, 6);
			this.textBox_stop.Name = "textBox_stop";
			this.textBox_stop.Size = new System.Drawing.Size(23, 23);
			this.textBox_stop.TabIndex = 13;
			this.textBox_stop.Text = "1";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(394, 9);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(56, 17);
			this.label23.TabIndex = 12;
			this.label23.Text = "停止位：";
			// 
			// textBox_data_bits
			// 
			this.textBox_data_bits.Location = new System.Drawing.Point(357, 6);
			this.textBox_data_bits.Name = "textBox_data_bits";
			this.textBox_data_bits.Size = new System.Drawing.Size(24, 23);
			this.textBox_data_bits.TabIndex = 11;
			this.textBox_data_bits.Text = "8";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(295, 9);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 17);
			this.label22.TabIndex = 10;
			this.label22.Text = "数据位：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(325, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭转换";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(213, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "打开转换";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_baut
			// 
			this.textBox_baut.Location = new System.Drawing.Point(242, 6);
			this.textBox_baut.Name = "textBox_baut";
			this.textBox_baut.Size = new System.Drawing.Size(47, 23);
			this.textBox_baut.TabIndex = 3;
			this.textBox_baut.Text = "9600";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(173, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "波特率：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Com口：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.button_clear);
			this.panel2.Controls.Add(this.label_tcp_serial_length);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.label_serial_tcp_length);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.checkBox_show_hex);
			this.panel2.Controls.Add(this.textBox6);
			this.panel2.Controls.Add(this.checkBox_show_send);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Location = new System.Drawing.Point(4, 110);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1019, 547);
			this.panel2.TabIndex = 13;
			// 
			// button_clear
			// 
			this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_clear.Location = new System.Drawing.Point(904, 1);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(108, 28);
			this.button_clear.TabIndex = 27;
			this.button_clear.Text = "Clear";
			this.button_clear.UseVisualStyleBackColor = true;
			this.button_clear.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_tcp_serial_length
			// 
			this.label_tcp_serial_length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_tcp_serial_length.AutoSize = true;
			this.label_tcp_serial_length.Location = new System.Drawing.Point(310, 524);
			this.label_tcp_serial_length.Name = "label_tcp_serial_length";
			this.label_tcp_serial_length.Size = new System.Drawing.Size(15, 17);
			this.label_tcp_serial_length.TabIndex = 26;
			this.label_tcp_serial_length.Text = "0";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(224, 524);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 17);
			this.label8.TabIndex = 25;
			this.label8.Text = "Tcp-Serial：";
			// 
			// label_serial_tcp_length
			// 
			this.label_serial_tcp_length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_serial_tcp_length.AutoSize = true;
			this.label_serial_tcp_length.Location = new System.Drawing.Point(93, 524);
			this.label_serial_tcp_length.Name = "label_serial_tcp_length";
			this.label_serial_tcp_length.Size = new System.Drawing.Size(15, 17);
			this.label_serial_tcp_length.TabIndex = 24;
			this.label_serial_tcp_length.Text = "0";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 524);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 17);
			this.label4.TabIndex = 23;
			this.label4.Text = "Serial-Tcp：";
			// 
			// checkBox_show_hex
			// 
			this.checkBox_show_hex.AutoSize = true;
			this.checkBox_show_hex.Checked = true;
			this.checkBox_show_hex.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_hex.Location = new System.Drawing.Point(356, 6);
			this.checkBox_show_hex.Name = "checkBox_show_hex";
			this.checkBox_show_hex.Size = new System.Drawing.Size(135, 21);
			this.checkBox_show_hex.TabIndex = 22;
			this.checkBox_show_hex.Text = "是否使用二进制通信";
			this.checkBox_show_hex.UseVisualStyleBackColor = true;
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(7, 30);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(1004, 490);
			this.textBox6.TabIndex = 21;
			// 
			// checkBox_show_send
			// 
			this.checkBox_show_send.AutoSize = true;
			this.checkBox_show_send.Checked = true;
			this.checkBox_show_send.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_send.Location = new System.Drawing.Point(146, 6);
			this.checkBox_show_send.Name = "checkBox_show_send";
			this.checkBox_show_send.Size = new System.Drawing.Size(123, 21);
			this.checkBox_show_send.TabIndex = 19;
			this.checkBox_show_send.Text = "是否显示发送数据";
			this.checkBox_show_send.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 7);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "数据接收区：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Serial To Tcp";
			this.userControlHead1.Size = new System.Drawing.Size(1028, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormSerialToTcp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1028, 659);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormSerialToTcp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "串口转TCP调试工具";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSerialToTcp_FormClosing);
			this.Load += new System.EventHandler(this.FormSerialDebug_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_stop;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_data_bits;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_baut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox checkBox_show_send;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_com;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.CheckBox checkBox_rts;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_show_hex;
		private System.Windows.Forms.Label label_tcp_serial_length;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label_serial_tcp_length;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button_clear;
	}
}