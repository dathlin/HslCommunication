namespace HslCommunicationDemo
{
    partial class FormModbusAlien
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
			this.textBox_dtu = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox_station = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.textBox_dtu);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox_station);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 42);
			this.panel1.TabIndex = 0;
			// 
			// textBox_dtu
			// 
			this.textBox_dtu.Location = new System.Drawing.Point(460, 7);
			this.textBox_dtu.Name = "textBox_dtu";
			this.textBox_dtu.Size = new System.Drawing.Size(171, 23);
			this.textBox_dtu.TabIndex = 11;
			this.textBox_dtu.Text = "12345678901";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(399, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "DTU ID：";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(287, 9);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(106, 21);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "首地址从0开始";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox_station
			// 
			this.textBox_station.Location = new System.Drawing.Point(219, 7);
			this.textBox_station.Name = "textBox_station";
			this.textBox_station.Size = new System.Drawing.Size(58, 23);
			this.textBox_station.TabIndex = 7;
			this.textBox_station.Text = "1";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(165, 10);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(44, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "站号：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(875, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(772, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "创建";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(74, 7);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(76, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "10000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(639, 10);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(97, 17);
			this.label22.TabIndex = 12;
			this.label22.Text = "(11位ASCII字符)";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 80);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 564);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 562);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7885368.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Modbus Tcp - dtu";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormModbusAlien
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
			this.Name = "FormModbusAlien";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modbus Tcp 异形客户端测试";
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
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_station;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_dtu;
        private System.Windows.Forms.Label label1;
        private DemoControl.UserControlHead userControlHead1;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}