namespace HslCommunicationDemo
{
    partial class FormMcServer
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.borderPanel3 = new HslCommunicationDemo.DemoControl.BorderPanel();
			this.radioButton_ipv6 = new System.Windows.Forms.RadioButton();
			this.radioButton_ipv4 = new System.Windows.Forms.RadioButton();
			this.borderPanel2 = new HslCommunicationDemo.DemoControl.BorderPanel();
			this.radioButton_udp = new System.Windows.Forms.RadioButton();
			this.radioButton_tcp = new System.Windows.Forms.RadioButton();
			this.borderPanel1 = new HslCommunicationDemo.DemoControl.BorderPanel();
			this.radioButton_ascii = new System.Windows.Forms.RadioButton();
			this.radioButton_binary = new System.Windows.Forms.RadioButton();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox_serialPort = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.sslServerControl1 = new HslCommunicationDemo.DemoControl.SslServerControl();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.radioButton_both = new System.Windows.Forms.RadioButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.borderPanel3.SuspendLayout();
			this.borderPanel2.SuspendLayout();
			this.borderPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.borderPanel3);
			this.panel1.Controls.Add(this.borderPanel2);
			this.panel1.Controls.Add(this.borderPanel1);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.textBox_serialPort);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.button11);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.sslServerControl1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 68);
			this.panel1.TabIndex = 0;
			// 
			// borderPanel3
			// 
			this.borderPanel3.Controls.Add(this.radioButton_ipv6);
			this.borderPanel3.Controls.Add(this.radioButton_ipv4);
			this.borderPanel3.Location = new System.Drawing.Point(428, 4);
			this.borderPanel3.Name = "borderPanel3";
			this.borderPanel3.Size = new System.Drawing.Size(113, 28);
			this.borderPanel3.TabIndex = 36;
			// 
			// radioButton_ipv6
			// 
			this.radioButton_ipv6.AutoSize = true;
			this.radioButton_ipv6.Location = new System.Drawing.Point(59, 3);
			this.radioButton_ipv6.Name = "radioButton_ipv6";
			this.radioButton_ipv6.Size = new System.Drawing.Size(50, 21);
			this.radioButton_ipv6.TabIndex = 1;
			this.radioButton_ipv6.Text = "IPv6";
			this.radioButton_ipv6.UseVisualStyleBackColor = true;
			// 
			// radioButton_ipv4
			// 
			this.radioButton_ipv4.AutoSize = true;
			this.radioButton_ipv4.Checked = true;
			this.radioButton_ipv4.Location = new System.Drawing.Point(5, 3);
			this.radioButton_ipv4.Name = "radioButton_ipv4";
			this.radioButton_ipv4.Size = new System.Drawing.Size(50, 21);
			this.radioButton_ipv4.TabIndex = 0;
			this.radioButton_ipv4.TabStop = true;
			this.radioButton_ipv4.Text = "IPv4";
			this.radioButton_ipv4.UseVisualStyleBackColor = true;
			// 
			// borderPanel2
			// 
			this.borderPanel2.Controls.Add(this.radioButton_udp);
			this.borderPanel2.Controls.Add(this.radioButton_tcp);
			this.borderPanel2.Controls.Add(this.radioButton_both);
			this.borderPanel2.Location = new System.Drawing.Point(263, 4);
			this.borderPanel2.Name = "borderPanel2";
			this.borderPanel2.Size = new System.Drawing.Size(162, 28);
			this.borderPanel2.TabIndex = 35;
			// 
			// radioButton_udp
			// 
			this.radioButton_udp.AutoSize = true;
			this.radioButton_udp.Location = new System.Drawing.Point(51, 3);
			this.radioButton_udp.Name = "radioButton_udp";
			this.radioButton_udp.Size = new System.Drawing.Size(51, 21);
			this.radioButton_udp.TabIndex = 1;
			this.radioButton_udp.Text = "Udp";
			this.radioButton_udp.UseVisualStyleBackColor = true;
			// 
			// radioButton_tcp
			// 
			this.radioButton_tcp.AutoSize = true;
			this.radioButton_tcp.Checked = true;
			this.radioButton_tcp.Location = new System.Drawing.Point(4, 3);
			this.radioButton_tcp.Name = "radioButton_tcp";
			this.radioButton_tcp.Size = new System.Drawing.Size(47, 21);
			this.radioButton_tcp.TabIndex = 0;
			this.radioButton_tcp.TabStop = true;
			this.radioButton_tcp.Text = "Tcp";
			this.radioButton_tcp.UseVisualStyleBackColor = true;
			// 
			// borderPanel1
			// 
			this.borderPanel1.Controls.Add(this.radioButton_ascii);
			this.borderPanel1.Controls.Add(this.radioButton_binary);
			this.borderPanel1.Location = new System.Drawing.Point(128, 4);
			this.borderPanel1.Name = "borderPanel1";
			this.borderPanel1.Size = new System.Drawing.Size(131, 28);
			this.borderPanel1.TabIndex = 34;
			// 
			// radioButton_ascii
			// 
			this.radioButton_ascii.AutoSize = true;
			this.radioButton_ascii.Location = new System.Drawing.Point(68, 3);
			this.radioButton_ascii.Name = "radioButton_ascii";
			this.radioButton_ascii.Size = new System.Drawing.Size(57, 21);
			this.radioButton_ascii.TabIndex = 1;
			this.radioButton_ascii.Text = "ASCII";
			this.radioButton_ascii.UseVisualStyleBackColor = true;
			// 
			// radioButton_binary
			// 
			this.radioButton_binary.AutoSize = true;
			this.radioButton_binary.Checked = true;
			this.radioButton_binary.Location = new System.Drawing.Point(4, 3);
			this.radioButton_binary.Name = "radioButton_binary";
			this.radioButton_binary.Size = new System.Drawing.Size(62, 21);
			this.radioButton_binary.TabIndex = 0;
			this.radioButton_binary.TabStop = true;
			this.radioButton_binary.Text = "Binary";
			this.radioButton_binary.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(904, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(84, 28);
			this.button5.TabIndex = 33;
			this.button5.Text = "启动串口";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox_serialPort
			// 
			this.textBox_serialPort.Location = new System.Drawing.Point(762, 6);
			this.textBox_serialPort.Name = "textBox_serialPort";
			this.textBox_serialPort.Size = new System.Drawing.Size(136, 23);
			this.textBox_serialPort.TabIndex = 32;
			this.textBox_serialPort.Text = "COM4-9600-8-N-1";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(717, 9);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 17);
			this.label14.TabIndex = 31;
			this.label14.Text = "串口：";
			// 
			// button11
			// 
			this.button11.Enabled = false;
			this.button11.Location = new System.Drawing.Point(630, 3);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(83, 28);
			this.button11.TabIndex = 28;
			this.button11.Text = "关闭服务";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(543, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(64, 6);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(61, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "6000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// sslServerControl1
			// 
			this.sslServerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sslServerControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sslServerControl1.Location = new System.Drawing.Point(4, 33);
			this.sslServerControl1.Name = "sslServerControl1";
			this.sslServerControl1.Size = new System.Drawing.Size(988, 30);
			this.sslServerControl1.TabIndex = 37;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteServer1);
			this.panel2.Location = new System.Drawing.Point(3, 105);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 540);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteServer1
			// 
			this.userControlReadWriteServer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteServer1.Location = new System.Drawing.Point(3, 3);
			this.userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			this.userControlReadWriteServer1.Size = new System.Drawing.Size(989, 532);
			this.userControlReadWriteServer1.TabIndex = 0;
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
			this.userControlHead1.ProtocolInfo = "MC Qna3E Server";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// radioButton_both
			// 
			this.radioButton_both.AutoSize = true;
			this.radioButton_both.Location = new System.Drawing.Point(105, 3);
			this.radioButton_both.Name = "radioButton_both";
			this.radioButton_both.Size = new System.Drawing.Size(53, 21);
			this.radioButton_both.TabIndex = 2;
			this.radioButton_both.Text = "Both";
			this.radioButton_both.UseVisualStyleBackColor = true;
			// 
			// FormMcServer
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
			this.Name = "FormMcServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "mc虚拟服务器【数据支持，bool是M,X,Y，字操作是x,y,m,d,w】";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.borderPanel3.ResumeLayout(false);
			this.borderPanel3.PerformLayout();
			this.borderPanel2.ResumeLayout(false);
			this.borderPanel2.PerformLayout();
			this.borderPanel1.ResumeLayout(false);
			this.borderPanel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button11;
        private DemoControl.UserControlHead userControlHead1;
        private DemoControl.UserControlReadWriteServer userControlReadWriteServer1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox_serialPort;
		private System.Windows.Forms.Label label14;
		private DemoControl.BorderPanel borderPanel1;
		private System.Windows.Forms.RadioButton radioButton_ascii;
		private System.Windows.Forms.RadioButton radioButton_binary;
		private DemoControl.BorderPanel borderPanel2;
		private System.Windows.Forms.RadioButton radioButton_udp;
		private System.Windows.Forms.RadioButton radioButton_tcp;
		private DemoControl.BorderPanel borderPanel3;
		private System.Windows.Forms.RadioButton radioButton_ipv6;
		private System.Windows.Forms.RadioButton radioButton_ipv4;
		private DemoControl.SslServerControl sslServerControl1;
		private System.Windows.Forms.RadioButton radioButton_both;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}