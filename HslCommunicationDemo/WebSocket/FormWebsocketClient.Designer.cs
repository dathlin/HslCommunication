namespace HslCommunicationDemo
{
    partial class FormWebsocketClient
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
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button_ssl_file = new System.Windows.Forms.Button();
			this.textBox_ssl_ca = new System.Windows.Forms.TextBox();
			this.checkBox_SSL = new System.Windows.Forms.CheckBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.checkBox_logHex = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_hex = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.button_ssl_file);
			this.panel1.Controls.Add(this.textBox_ssl_ca);
			this.panel1.Controls.Add(this.checkBox_SSL);
			this.panel1.Controls.Add(this.textBox5);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.textBox11);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Location = new System.Drawing.Point(3, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 97);
			this.panel1.TabIndex = 7;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(897, 72);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(57, 17);
			this.linkLabel1.TabIndex = 27;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "<Code>";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(669, 38);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(143, 21);
			this.checkBox2.TabIndex = 26;
			this.checkBox2.Text = "GET 携带 Host 信息?";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// button_ssl_file
			// 
			this.button_ssl_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_ssl_file.Location = new System.Drawing.Point(779, 66);
			this.button_ssl_file.Name = "button_ssl_file";
			this.button_ssl_file.Size = new System.Drawing.Size(91, 28);
			this.button_ssl_file.TabIndex = 25;
			this.button_ssl_file.Text = "FILE";
			this.button_ssl_file.UseVisualStyleBackColor = true;
			this.button_ssl_file.Click += new System.EventHandler(this.button_ssl_file_Click);
			// 
			// textBox_ssl_ca
			// 
			this.textBox_ssl_ca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_ssl_ca.Location = new System.Drawing.Point(62, 69);
			this.textBox_ssl_ca.Name = "textBox_ssl_ca";
			this.textBox_ssl_ca.Size = new System.Drawing.Size(711, 23);
			this.textBox_ssl_ca.TabIndex = 24;
			// 
			// checkBox_SSL
			// 
			this.checkBox_SSL.AutoSize = true;
			this.checkBox_SSL.Location = new System.Drawing.Point(8, 71);
			this.checkBox_SSL.Name = "checkBox_SSL";
			this.checkBox_SSL.Size = new System.Drawing.Size(51, 21);
			this.checkBox_SSL.TabIndex = 23;
			this.checkBox_SSL.Text = "证书";
			this.checkBox_SSL.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(498, 6);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(291, 23);
			this.textBox5.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.label7.Location = new System.Drawing.Point(249, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(206, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "主题只对hsl的websocket服务器有效";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(62, 38);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(181, 23);
			this.textBox3.TabIndex = 17;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "主题：";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(929, 36);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(51, 23);
			this.textBox11.TabIndex = 15;
			this.textBox11.Text = "5000";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(845, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "连接超时：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(892, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(795, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(392, 7);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(65, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "1883";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(337, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(59, 7);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(274, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip地址：";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(460, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 17);
			this.label10.TabIndex = 22;
			this.label10.Text = "url：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label8.Location = new System.Drawing.Point(495, 33);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(145, 17);
			this.label8.TabIndex = 20;
			this.label8.Text = "url举例: /A/B?C=123456";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.checkBox_logHex);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.checkBox1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.radioButton2);
			this.panel2.Controls.Add(this.radioButton1);
			this.panel2.Controls.Add(this.textBox8);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Location = new System.Drawing.Point(3, 136);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 507);
			this.panel2.TabIndex = 13;
			// 
			// checkBox_logHex
			// 
			this.checkBox_logHex.AutoSize = true;
			this.checkBox_logHex.Location = new System.Drawing.Point(8, 240);
			this.checkBox_logHex.Name = "checkBox_logHex";
			this.checkBox_logHex.Size = new System.Drawing.Size(81, 21);
			this.checkBox_logHex.TabIndex = 30;
			this.checkBox_logHex.Text = "Log Hex?";
			this.checkBox_logHex.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(364, 182);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(100, 25);
			this.comboBox1.TabIndex = 29;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(291, 186);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 17);
			this.label11.TabIndex = 28;
			this.label11.Text = "Encoding:";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(209, 185);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(65, 21);
			this.checkBox1.TabIndex = 27;
			this.checkBox1.Text = "Mask?";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.radioButton_hex);
			this.panel3.Controls.Add(this.radioButton5);
			this.panel3.Controls.Add(this.radioButton3);
			this.panel3.Controls.Add(this.radioButton4);
			this.panel3.Location = new System.Drawing.Point(559, 179);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(243, 28);
			this.panel3.TabIndex = 26;
			// 
			// radioButton_hex
			// 
			this.radioButton_hex.AutoSize = true;
			this.radioButton_hex.Location = new System.Drawing.Point(3, 3);
			this.radioButton_hex.Name = "radioButton_hex";
			this.radioButton_hex.Size = new System.Drawing.Size(48, 21);
			this.radioButton_hex.TabIndex = 29;
			this.radioButton_hex.Text = "Hex";
			this.radioButton_hex.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(165, 3);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(52, 21);
			this.radioButton5.TabIndex = 28;
			this.radioButton5.Text = "Json";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(55, 3);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(50, 21);
			this.radioButton3.TabIndex = 26;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Text";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(111, 3);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(48, 21);
			this.radioButton4.TabIndex = 27;
			this.radioButton4.Text = "Xml";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(479, 174);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(74, 21);
			this.radioButton2.TabIndex = 25;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "追加显示";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(479, 193);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(74, 21);
			this.radioButton1.TabIndex = 24;
			this.radioButton1.Text = "覆盖显示";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(107, 214);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(881, 288);
			this.textBox8.TabIndex = 18;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(4, 217);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 17);
			this.label12.TabIndex = 19;
			this.label12.Text = "Receive：";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(921, 180);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(68, 28);
			this.button4.TabIndex = 17;
			this.button4.Text = "清空";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(105, 180);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(91, 28);
			this.button3.TabIndex = 12;
			this.button3.Text = "发送";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(105, 3);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(883, 171);
			this.textBox4.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 6);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "Payload：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12303098.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "WebSocket";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormWebsocketClient
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
			this.Name = "FormWebsocketClient";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Websocket客户端";
			this.Load += new System.EventHandler(this.FormClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox checkBox_logHex;
		private System.Windows.Forms.RadioButton radioButton_hex;
		private System.Windows.Forms.CheckBox checkBox_SSL;
		private System.Windows.Forms.Button button_ssl_file;
		private System.Windows.Forms.TextBox textBox_ssl_ca;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}