namespace HslCommunicationDemo
{
    partial class FormFtpServer
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
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_pasvPortRange = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox_downloadOnly = new System.Windows.Forms.CheckBox();
			this.checkBox_allow = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox_path = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_name = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.checkBox_stop = new System.Windows.Forms.CheckBox();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBox_code_create = new System.Windows.Forms.TextBox();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox_pasvPortRange);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.checkBox_downloadOnly);
			this.panel1.Controls.Add(this.checkBox_allow);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.textBox_path);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox_password);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_name);
			this.panel1.Controls.Add(this.label19);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Location = new System.Drawing.Point(6, 37);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(993, 60);
			this.panel1.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Gray;
			this.label5.Location = new System.Drawing.Point(796, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 17);
			this.label5.TabIndex = 51;
			this.label5.Text = "(50000-60000) default";
			// 
			// textBox_pasvPortRange
			// 
			this.textBox_pasvPortRange.Location = new System.Drawing.Point(677, 32);
			this.textBox_pasvPortRange.Name = "textBox_pasvPortRange";
			this.textBox_pasvPortRange.Size = new System.Drawing.Size(113, 23);
			this.textBox_pasvPortRange.TabIndex = 50;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(563, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 17);
			this.label4.TabIndex = 49;
			this.label4.Text = "Pasv Port Range：";
			// 
			// checkBox_downloadOnly
			// 
			this.checkBox_downloadOnly.AutoSize = true;
			this.checkBox_downloadOnly.Location = new System.Drawing.Point(613, 6);
			this.checkBox_downloadOnly.Name = "checkBox_downloadOnly";
			this.checkBox_downloadOnly.Size = new System.Drawing.Size(116, 21);
			this.checkBox_downloadOnly.TabIndex = 48;
			this.checkBox_downloadOnly.Text = "Download Only";
			this.checkBox_downloadOnly.UseVisualStyleBackColor = true;
			// 
			// checkBox_allow
			// 
			this.checkBox_allow.AutoSize = true;
			this.checkBox_allow.Checked = true;
			this.checkBox_allow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_allow.Location = new System.Drawing.Point(478, 6);
			this.checkBox_allow.Name = "checkBox_allow";
			this.checkBox_allow.Size = new System.Drawing.Size(129, 21);
			this.checkBox_allow.TabIndex = 47;
			this.checkBox_allow.Text = "Allow anonymous";
			this.checkBox_allow.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(477, 29);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(85, 28);
			this.button2.TabIndex = 30;
			this.button2.Text = "Select";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox_path
			// 
			this.textBox_path.Location = new System.Drawing.Point(66, 32);
			this.textBox_path.Name = "textBox_path";
			this.textBox_path.Size = new System.Drawing.Size(405, 23);
			this.textBox_path.TabIndex = 29;
			this.textBox_path.Text = "FtpServer";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "FilePath:";
			// 
			// textBox_password
			// 
			this.textBox_password.Location = new System.Drawing.Point(358, 4);
			this.textBox_password.Name = "textBox_password";
			this.textBox_password.Size = new System.Drawing.Size(113, 23);
			this.textBox_password.TabIndex = 27;
			this.textBox_password.Text = "123456";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(307, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 26;
			this.label3.Text = "密码：";
			// 
			// textBox_name
			// 
			this.textBox_name.Location = new System.Drawing.Point(207, 4);
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.Size = new System.Drawing.Size(97, 23);
			this.textBox_name.TabIndex = 25;
			this.textBox_name.Text = "admin";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(139, 7);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(56, 17);
			this.label19.TabIndex = 24;
			this.label19.Text = "用户名：";
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(825, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 23;
			this.button1.Text = "关闭";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(728, 1);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(91, 28);
			this.button7.TabIndex = 22;
			this.button7.Text = "启动";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click_1);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(59, 4);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(74, 23);
			this.textBox_port.TabIndex = 21;
			this.textBox_port.Text = "12345";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(5, 7);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 17);
			this.label20.TabIndex = 20;
			this.label20.Text = "端口号：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Enabled = false;
			this.panel2.Location = new System.Drawing.Point(6, 102);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(993, 539);
			this.panel2.TabIndex = 13;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel5);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel6);
			this.splitContainer1.Size = new System.Drawing.Size(991, 537);
			this.splitContainer1.SplitterDistance = 242;
			this.splitContainer1.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.listBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(991, 242);
			this.panel5.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Online：";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(4, 26);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(980, 208);
			this.listBox1.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.tabControl1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(991, 291);
			this.panel6.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(991, 291);
			this.tabControl1.TabIndex = 44;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(983, 261);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Log";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.checkBox_stop);
			this.panel3.Controls.Add(this.textBox_log);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(977, 255);
			this.panel3.TabIndex = 0;
			// 
			// checkBox_stop
			// 
			this.checkBox_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_stop.AutoSize = true;
			this.checkBox_stop.Location = new System.Drawing.Point(905, 6);
			this.checkBox_stop.Name = "checkBox_stop";
			this.checkBox_stop.Size = new System.Drawing.Size(54, 21);
			this.checkBox_stop.TabIndex = 46;
			this.checkBox_stop.Text = "Stop";
			this.checkBox_stop.UseVisualStyleBackColor = true;
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Location = new System.Drawing.Point(0, 0);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(898, 255);
			this.textBox_log.TabIndex = 44;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBox_code_create);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(983, 265);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Code-Create";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// textBox_code_create
			// 
			this.textBox_code_create.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_code_create.Location = new System.Drawing.Point(3, 3);
			this.textBox_code_create.Multiline = true;
			this.textBox_code_create.Name = "textBox_code_create";
			this.textBox_code_create.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code_create.Size = new System.Drawing.Size(977, 259);
			this.textBox_code_create.TabIndex = 44;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7746113.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "FTP - Server";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormFtpServer
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
			this.Name = "FormFtpServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "文件客户端窗口";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMqttFileClient_FormClosing);
			this.Load += new System.EventHandler(this.FormFileClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_name;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBox_log;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox textBox_code_create;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox textBox_path;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.CheckBox checkBox_stop;
		private System.Windows.Forms.CheckBox checkBox_allow;
		private System.Windows.Forms.CheckBox checkBox_downloadOnly;
		private System.Windows.Forms.TextBox textBox_pasvPortRange;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}