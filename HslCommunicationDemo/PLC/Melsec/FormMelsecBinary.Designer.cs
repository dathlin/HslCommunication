using System;

namespace HslCommunicationDemo
{
    partial class FormMelsecBinary
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
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.textBox_target_io_number = new System.Windows.Forms.TextBox();
			this.label_target_io_number = new System.Windows.Forms.Label();
			this.textBox_network_station_number = new System.Windows.Forms.TextBox();
			this.label_network_station_number = new System.Windows.Forms.Label();
			this.textBox_network_number = new System.Windows.Forms.TextBox();
			this.label_network_number = new System.Windows.Forms.Label();
			this.checkBox_string_reverse = new System.Windows.Forms.CheckBox();
			this.checkBox_EnableWriteBitToWordRegister = new System.Windows.Forms.CheckBox();
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
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.textBox_target_io_number);
			this.panel1.Controls.Add(this.label_target_io_number);
			this.panel1.Controls.Add(this.textBox_network_station_number);
			this.panel1.Controls.Add(this.label_network_station_number);
			this.panel1.Controls.Add(this.textBox_network_number);
			this.panel1.Controls.Add(this.label_network_number);
			this.panel1.Controls.Add(this.checkBox_string_reverse);
			this.panel1.Controls.Add(this.checkBox_EnableWriteBitToWordRegister);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 59);
			this.panel1.TabIndex = 0;
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(2, 1);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(785, 31);
			this.pipeSelectControl1.TabIndex = 34;
			this.pipeSelectControl1.TcpPortText = "6000";
			this.pipeSelectControl1.UdpPortText = "6000";
			// 
			// textBox_target_io_number
			// 
			this.textBox_target_io_number.Location = new System.Drawing.Point(775, 33);
			this.textBox_target_io_number.Name = "textBox_target_io_number";
			this.textBox_target_io_number.Size = new System.Drawing.Size(80, 23);
			this.textBox_target_io_number.TabIndex = 33;
			this.textBox_target_io_number.Text = "0x03FF";
			// 
			// label_target_io_number
			// 
			this.label_target_io_number.AutoSize = true;
			this.label_target_io_number.Location = new System.Drawing.Point(672, 36);
			this.label_target_io_number.Name = "label_target_io_number";
			this.label_target_io_number.Size = new System.Drawing.Size(100, 17);
			this.label_target_io_number.TabIndex = 32;
			this.label_target_io_number.Text = "TargetIONum：";
			// 
			// textBox_network_station_number
			// 
			this.textBox_network_station_number.Location = new System.Drawing.Point(620, 32);
			this.textBox_network_station_number.Name = "textBox_network_station_number";
			this.textBox_network_station_number.Size = new System.Drawing.Size(32, 23);
			this.textBox_network_station_number.TabIndex = 31;
			this.textBox_network_station_number.Text = "0";
			// 
			// label_network_station_number
			// 
			this.label_network_station_number.AutoSize = true;
			this.label_network_station_number.Location = new System.Drawing.Point(537, 35);
			this.label_network_station_number.Name = "label_network_station_number";
			this.label_network_station_number.Size = new System.Drawing.Size(91, 17);
			this.label_network_station_number.TabIndex = 30;
			this.label_network_station_number.Text = "NetStatNum：";
			// 
			// textBox_network_number
			// 
			this.textBox_network_number.Location = new System.Drawing.Point(498, 32);
			this.textBox_network_number.Name = "textBox_network_number";
			this.textBox_network_number.Size = new System.Drawing.Size(32, 23);
			this.textBox_network_number.TabIndex = 29;
			this.textBox_network_number.Text = "0";
			// 
			// label_network_number
			// 
			this.label_network_number.AutoSize = true;
			this.label_network_number.Location = new System.Drawing.Point(433, 35);
			this.label_network_number.Name = "label_network_number";
			this.label_network_number.Size = new System.Drawing.Size(69, 17);
			this.label_network_number.TabIndex = 28;
			this.label_network_number.Text = "NetNum：";
			// 
			// checkBox_string_reverse
			// 
			this.checkBox_string_reverse.AutoSize = true;
			this.checkBox_string_reverse.Location = new System.Drawing.Point(260, 34);
			this.checkBox_string_reverse.Name = "checkBox_string_reverse";
			this.checkBox_string_reverse.Size = new System.Drawing.Size(87, 21);
			this.checkBox_string_reverse.TabIndex = 27;
			this.checkBox_string_reverse.Text = "字符串颠倒";
			this.checkBox_string_reverse.UseVisualStyleBackColor = true;
			// 
			// checkBox_EnableWriteBitToWordRegister
			// 
			this.checkBox_EnableWriteBitToWordRegister.AutoSize = true;
			this.checkBox_EnableWriteBitToWordRegister.Location = new System.Drawing.Point(9, 34);
			this.checkBox_EnableWriteBitToWordRegister.Name = "checkBox_EnableWriteBitToWordRegister";
			this.checkBox_EnableWriteBitToWordRegister.Size = new System.Drawing.Size(228, 21);
			this.checkBox_EnableWriteBitToWordRegister.TabIndex = 9;
			this.checkBox_EnableWriteBitToWordRegister.Text = "Enable Write Bit To Word Register";
			this.checkBox_EnableWriteBitToWordRegister.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(890, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(793, 2);
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
			this.panel2.Location = new System.Drawing.Point(3, 97);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 545);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 543);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "MC Qna3E Binary";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormMelsecBinary
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
			this.Name = "FormMelsecBinary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "三菱PLC访问Demo";
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
		private System.Windows.Forms.CheckBox checkBox_EnableWriteBitToWordRegister;
		private System.Windows.Forms.CheckBox checkBox_string_reverse;
		private System.Windows.Forms.TextBox textBox_network_station_number;
		private System.Windows.Forms.Label label_network_station_number;
		private System.Windows.Forms.TextBox textBox_network_number;
		private System.Windows.Forms.Label label_network_number;
		private System.Windows.Forms.TextBox textBox_target_io_number;
		private System.Windows.Forms.Label label_target_io_number;
		private DemoControl.PipeSelectControl pipeSelectControl1;
	}
}