namespace HslCommunicationDemo
{
    partial class FormAllenBrandly
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
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_router = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.userControlReadWriteDevice1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteDevice();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox15);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.textBox_router);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.textBox16);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(993, 56);
			this.panel1.TabIndex = 0;
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(373, 13);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(32, 23);
			this.textBox15.TabIndex = 9;
			this.textBox15.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(411, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 17);
			this.label8.TabIndex = 12;
			this.label8.Text = "Router";
			// 
			// textBox_router
			// 
			this.textBox_router.Location = new System.Drawing.Point(469, 13);
			this.textBox_router.Name = "textBox_router";
			this.textBox_router.Size = new System.Drawing.Size(134, 23);
			this.textBox_router.TabIndex = 13;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(609, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(63, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.DarkGray;
			this.label9.Location = new System.Drawing.Point(401, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(220, 17);
			this.label9.TabIndex = 14;
			this.label9.Text = "if use router, example: 1.15.2.18.1.12";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(853, 30);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(134, 23);
			this.textBox16.TabIndex = 11;
			this.textBox16.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(795, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "PortSlot";
			this.label4.Visible = false;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(329, 16);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(41, 17);
			this.label23.TabIndex = 8;
			this.label23.Text = "slot：";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(760, -1);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(232, 45);
			this.label22.TabIndex = 7;
			this.label22.Text = "变量的标签名，bool数组如果是int类型，则带i=开头访问";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(678, 10);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(76, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(269, 13);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(52, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "44818";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(215, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(141, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "192.168.0.100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 16);
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
			this.panel2.Location = new System.Drawing.Point(3, 94);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(993, 554);
			this.panel2.TabIndex = 1;
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
			this.userControlHead1.ProtocolInfo = "CIP";
			this.userControlHead1.Size = new System.Drawing.Size(1000, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(991, 552);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// FormAllenBrandly
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1000, 651);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormAllenBrandly";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AB PLC访问Demo";
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label23;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_router;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}