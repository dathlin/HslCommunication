namespace HslCommunicationDemo
{
    partial class FormTcpServer
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
            this.panel_tcp_udp = new System.Windows.Forms.Panel();
            this.radioButton_udp = new System.Windows.Forms.RadioButton();
            this.radioButton_tcp = new System.Windows.Forms.RadioButton();
            this.button_close = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
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
            this.panel_main.Location = new System.Drawing.Point(3, 82);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1016, 561);
            this.panel_main.TabIndex = 20;
            // 
            // debugControl1
            // 
            this.debugControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.debugControl1.Location = new System.Drawing.Point(0, 0);
            this.debugControl1.Name = "debugControl1";
            this.debugControl1.Size = new System.Drawing.Size(1014, 559);
            this.debugControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_buffer_length);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel_tcp_udp);
            this.panel1.Controls.Add(this.button_close);
            this.panel1.Controls.Add(this.button_start);
            this.panel1.Controls.Add(this.textBox_port);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 43);
            this.panel1.TabIndex = 14;
            // 
            // textBox_buffer_length
            // 
            this.textBox_buffer_length.Location = new System.Drawing.Point(376, 9);
            this.textBox_buffer_length.Name = "textBox_buffer_length";
            this.textBox_buffer_length.Size = new System.Drawing.Size(83, 23);
            this.textBox_buffer_length.TabIndex = 26;
            this.textBox_buffer_length.Text = "2048";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "缓冲大小：";
            // 
            // panel_tcp_udp
            // 
            this.panel_tcp_udp.Controls.Add(this.radioButton_udp);
            this.panel_tcp_udp.Controls.Add(this.radioButton_tcp);
            this.panel_tcp_udp.Location = new System.Drawing.Point(144, 6);
            this.panel_tcp_udp.Name = "panel_tcp_udp";
            this.panel_tcp_udp.Size = new System.Drawing.Size(148, 29);
            this.panel_tcp_udp.TabIndex = 6;
            // 
            // radioButton_udp
            // 
            this.radioButton_udp.AutoSize = true;
            this.radioButton_udp.Location = new System.Drawing.Point(73, 4);
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
            this.radioButton_tcp.Location = new System.Drawing.Point(10, 4);
            this.radioButton_tcp.Name = "radioButton_tcp";
            this.radioButton_tcp.Size = new System.Drawing.Size(48, 21);
            this.radioButton_tcp.TabIndex = 0;
            this.radioButton_tcp.TabStop = true;
            this.radioButton_tcp.Text = "TCP";
            this.radioButton_tcp.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            this.button_close.Enabled = false;
            this.button_close.Location = new System.Drawing.Point(582, 7);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(91, 28);
            this.button_close.TabIndex = 5;
            this.button_close.Text = "关闭服务";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(485, 7);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(91, 28);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "启动服务";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(62, 9);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(76, 23);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "502";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port：";
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
            this.userControlHead1.ProtocolInfo = "TCP/UDP Server";
            this.userControlHead1.Size = new System.Drawing.Size(1023, 32);
            this.userControlHead1.TabIndex = 21;
            this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
            // 
            // FormTcpServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1023, 645);
            this.Controls.Add(this.userControlHead1);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTcpServer";
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
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Panel panel_tcp_udp;
		private System.Windows.Forms.RadioButton radioButton_udp;
		private System.Windows.Forms.RadioButton radioButton_tcp;
		private HslDebug.DebugControl debugControl1;
		private System.Windows.Forms.TextBox textBox_buffer_length;
		private System.Windows.Forms.Label label2;
	}
}