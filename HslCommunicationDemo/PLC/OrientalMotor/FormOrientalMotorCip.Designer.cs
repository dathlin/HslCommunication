namespace HslCommunicationDemo
{
    partial class FormOrientalMotorCip
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
			this.textBox_timeout = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_rpi = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_runIdle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_udp_port = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteDevice1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteDevice();
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
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox_timeout);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBox_rpi);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_runIdle);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox_udp_port);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 63);
			this.panel1.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Gray;
			this.label5.Location = new System.Drawing.Point(742, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 17);
			this.label5.TabIndex = 15;
			this.label5.Text = "(1,2,4,8,16,32,64,128,256)";
			// 
			// textBox_timeout
			// 
			this.textBox_timeout.Location = new System.Drawing.Point(673, 34);
			this.textBox_timeout.Name = "textBox_timeout";
			this.textBox_timeout.Size = new System.Drawing.Size(63, 23);
			this.textBox_timeout.TabIndex = 14;
			this.textBox_timeout.Text = "2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(556, 37);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 17);
			this.label4.TabIndex = 13;
			this.label4.Text = "ActualTimeout(s):";
			// 
			// textBox_rpi
			// 
			this.textBox_rpi.Location = new System.Drawing.Point(478, 34);
			this.textBox_rpi.Name = "textBox_rpi";
			this.textBox_rpi.Size = new System.Drawing.Size(72, 23);
			this.textBox_rpi.TabIndex = 12;
			this.textBox_rpi.Text = "100";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(386, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 17);
			this.label3.TabIndex = 11;
			this.label3.Text = "RPITime(ms):";
			// 
			// textBox_runIdle
			// 
			this.textBox_runIdle.Location = new System.Drawing.Point(285, 34);
			this.textBox_runIdle.Name = "textBox_runIdle";
			this.textBox_runIdle.Size = new System.Drawing.Size(94, 23);
			this.textBox_runIdle.TabIndex = 10;
			this.textBox_runIdle.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(215, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Run/Idle:";
			// 
			// textBox_udp_port
			// 
			this.textBox_udp_port.Location = new System.Drawing.Point(98, 34);
			this.textBox_udp_port.Name = "textBox_udp_port";
			this.textBox_udp_port.ReadOnly = true;
			this.textBox_udp_port.Size = new System.Drawing.Size(96, 23);
			this.textBox_udp_port.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "CIP I/O Port:";
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(5, 5);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
			this.pipeSelectControl1.TabIndex = 6;
			this.pipeSelectControl1.TcpPortText = "44818";
			this.pipeSelectControl1.UdpPortText = "44818";
			this.pipeSelectControl1.Load += new System.EventHandler(this.pipeSelectControl1_Load);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(901, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(806, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 101);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 542);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 540);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.orientalmotor.com.cn/";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Connected Implicit CIP";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormOrientalMotorCip
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
			this.Name = "FormOrientalMotorCip";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OrientalMotor访问Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DemoControl.UserControlHead userControlHead1;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
		private DemoControl.PipeSelectControl pipeSelectControl1;
		private System.Windows.Forms.TextBox textBox_udp_port;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_runIdle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_rpi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_timeout;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}