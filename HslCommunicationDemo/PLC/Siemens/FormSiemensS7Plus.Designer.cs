namespace HslCommunicationDemo
{
    partial class FormSiemensS7Plus
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
            this.label_info = new System.Windows.Forms.Label();
            this.textBox_pdu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_localTSAP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_slot = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox_rack = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label_info);
            this.panel1.Controls.Add(this.textBox_pdu);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_localTSAP);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_slot);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.textBox_rack);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_port);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_ip);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 54);
            this.panel1.TabIndex = 0;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.ForeColor = System.Drawing.Color.Gray;
            this.label_info.Location = new System.Drawing.Point(412, 30);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(140, 17);
            this.label_info.TabIndex = 18;
            this.label_info.Text = "如果不清楚，不设置即可";
            // 
            // textBox_pdu
            // 
            this.textBox_pdu.Location = new System.Drawing.Point(365, 27);
            this.textBox_pdu.Name = "textBox_pdu";
            this.textBox_pdu.ReadOnly = true;
            this.textBox_pdu.Size = new System.Drawing.Size(40, 23);
            this.textBox_pdu.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "PDU：";
            // 
            // textBox_localTSAP
            // 
            this.textBox_localTSAP.Location = new System.Drawing.Point(93, 27);
            this.textBox_localTSAP.Name = "textBox_localTSAP";
            this.textBox_localTSAP.Size = new System.Drawing.Size(52, 23);
            this.textBox_localTSAP.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "LocalTSAP：";
            // 
            // textBox_slot
            // 
            this.textBox_slot.Location = new System.Drawing.Point(510, 2);
            this.textBox_slot.Name = "textBox_slot";
            this.textBox_slot.Size = new System.Drawing.Size(33, 23);
            this.textBox_slot.TabIndex = 11;
            this.textBox_slot.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(464, 5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 17);
            this.label24.TabIndex = 10;
            this.label24.Text = "Slot：";
            // 
            // textBox_rack
            // 
            this.textBox_rack.Location = new System.Drawing.Point(425, 2);
            this.textBox_rack.Name = "textBox_rack";
            this.textBox_rack.Size = new System.Drawing.Size(33, 23);
            this.textBox_rack.TabIndex = 9;
            this.textBox_rack.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(376, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 17);
            this.label23.TabIndex = 8;
            this.label23.Text = "Rack：";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(739, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "断开连接";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(309, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(61, 23);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "102";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(62, 2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(183, 23);
            this.textBox_ip.TabIndex = 1;
            this.textBox_ip.Text = "192.168.0.100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
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
            this.panel2.Controls.Add(this.userControlReadWriteDevice1);
            this.panel2.Location = new System.Drawing.Point(3, 92);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 549);
            this.panel2.TabIndex = 1;
            // 
            // userControlReadWriteDevice1
            // 
            this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
            this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
            this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 547);
            this.userControlReadWriteDevice1.TabIndex = 0;
            // 
            // userControlHead1
            // 
            this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8685855.html";
            this.userControlHead1.Location = new System.Drawing.Point(0, 0);
            this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
            this.userControlHead1.Name = "userControlHead1";
            this.userControlHead1.ProtocolInfo = "s7-plus";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.SupportListVisiable = true;
            this.userControlHead1.TabIndex = 2;
            this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
            // 
            // FormSiemensS7Plus
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
            this.Name = "FormSiemensS7Plus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "西门子PLC访问Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
            this.Load += new System.EventHandler(this.FormSiemens_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_slot;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_rack;
        private System.Windows.Forms.Label label23;
        protected DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_localTSAP;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pdu;
        private System.Windows.Forms.Label label6;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
		private System.Windows.Forms.Label label_info;
	}
}