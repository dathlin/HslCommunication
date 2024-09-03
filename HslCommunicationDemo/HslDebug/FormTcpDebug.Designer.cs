namespace HslCommunicationDemo
{
    partial class FormTcpDebug
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
			this.panel_main = new System.Windows.Forms.Panel();
			this.debugControl1 = new HslCommunicationDemo.HslDebug.DebugControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox_buffer_length = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_localPort = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel_tcp_udp = new System.Windows.Forms.Panel();
			this.radioButton_udp = new System.Windows.Forms.RadioButton();
			this.radioButton_tcp = new System.Windows.Forms.RadioButton();
			this.button_edit_hand = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel_main.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel_tcp_udp.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_main
			// 
			this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_main.Controls.Add(this.debugControl1);
			this.panel_main.Location = new System.Drawing.Point(3, 97);
			this.panel_main.Name = "panel_main";
			this.panel_main.Size = new System.Drawing.Size(998, 536);
			this.panel_main.TabIndex = 20;
			// 
			// debugControl1
			// 
			this.debugControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.debugControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.debugControl1.Location = new System.Drawing.Point(0, 0);
			this.debugControl1.Name = "debugControl1";
			this.debugControl1.Size = new System.Drawing.Size(996, 534);
			this.debugControl1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox_buffer_length);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.textBox_localPort);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.panel_tcp_udp);
			this.panel1.Controls.Add(this.button_edit_hand);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(998, 60);
			this.panel1.TabIndex = 14;
			// 
			// textBox_buffer_length
			// 
			this.textBox_buffer_length.Location = new System.Drawing.Point(635, 33);
			this.textBox_buffer_length.Name = "textBox_buffer_length";
			this.textBox_buffer_length.Size = new System.Drawing.Size(83, 23);
			this.textBox_buffer_length.TabIndex = 24;
			this.textBox_buffer_length.Text = "2048";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(562, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 23;
			this.label2.Text = "缓冲大小：";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Gray;
			this.label10.Location = new System.Drawing.Point(379, 35);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(124, 17);
			this.label10.TabIndex = 22;
			this.label10.Text = "(如果为空，自动分配)";
			// 
			// textBox_localPort
			// 
			this.textBox_localPort.Location = new System.Drawing.Point(296, 32);
			this.textBox_localPort.Name = "textBox_localPort";
			this.textBox_localPort.Size = new System.Drawing.Size(77, 23);
			this.textBox_localPort.TabIndex = 21;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(217, 35);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 17);
			this.label9.TabIndex = 20;
			this.label9.Text = "本地端口:";
			// 
			// panel_tcp_udp
			// 
			this.panel_tcp_udp.Controls.Add(this.radioButton_udp);
			this.panel_tcp_udp.Controls.Add(this.radioButton_tcp);
			this.panel_tcp_udp.Location = new System.Drawing.Point(51, 32);
			this.panel_tcp_udp.Name = "panel_tcp_udp";
			this.panel_tcp_udp.Size = new System.Drawing.Size(146, 23);
			this.panel_tcp_udp.TabIndex = 19;
			// 
			// radioButton_udp
			// 
			this.radioButton_udp.AutoSize = true;
			this.radioButton_udp.Location = new System.Drawing.Point(73, 1);
			this.radioButton_udp.Name = "radioButton_udp";
			this.radioButton_udp.Size = new System.Drawing.Size(51, 21);
			this.radioButton_udp.TabIndex = 1;
			this.radioButton_udp.Text = "UDP";
			this.radioButton_udp.UseVisualStyleBackColor = true;
			// 
			// radioButton_tcp
			// 
			this.radioButton_tcp.AutoSize = true;
			this.radioButton_tcp.Checked = true;
			this.radioButton_tcp.Location = new System.Drawing.Point(10, 1);
			this.radioButton_tcp.Name = "radioButton_tcp";
			this.radioButton_tcp.Size = new System.Drawing.Size(48, 21);
			this.radioButton_tcp.TabIndex = 0;
			this.radioButton_tcp.TabStop = true;
			this.radioButton_tcp.Text = "TCP";
			this.radioButton_tcp.UseVisualStyleBackColor = true;
			// 
			// button_edit_hand
			// 
			this.button_edit_hand.Location = new System.Drawing.Point(550, 1);
			this.button_edit_hand.Name = "button_edit_hand";
			this.button_edit_hand.Size = new System.Drawing.Size(115, 31);
			this.button_edit_hand.TabIndex = 18;
			this.button_edit_hand.Text = "编辑握手包";
			this.button_edit_hand.UseVisualStyleBackColor = true;
			this.button_edit_hand.Click += new System.EventHandler(this.button_edit_hand_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(468, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "握手包：0";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(785, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(688, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(374, 5);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(77, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "502";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(320, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Port：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(51, 5);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(258, 23);
			this.textBox_ip.TabIndex = 1;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip：";
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
			this.userControlHead1.ProtocolInfo = "TCP/UDP Clinet";
			this.userControlHead1.Size = new System.Drawing.Size(1005, 32);
			this.userControlHead1.TabIndex = 21;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(740, 35);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(94, 21);
			this.checkBox1.TabIndex = 25;
			this.checkBox1.Text = "转远程DTU?";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// FormTcpDebug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1005, 636);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel_main);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormTcpDebug";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TCP/IP调试助手";
			this.Load += new System.EventHandler(this.FormTcpDebug_Load);
			this.panel_main.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel_tcp_udp.ResumeLayout(false);
			this.panel_tcp_udp.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Button button_edit_hand;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel_tcp_udp;
		private System.Windows.Forms.RadioButton radioButton_udp;
		private System.Windows.Forms.RadioButton radioButton_tcp;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox_localPort;
		private System.Windows.Forms.Label label9;
		private HslDebug.DebugControl debugControl1;
		private System.Windows.Forms.TextBox textBox_buffer_length;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}