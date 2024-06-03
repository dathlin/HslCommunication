namespace HslCommunicationDemo
{
    partial class FormLsisFEnet
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
			this.textBox_baseNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.label4 = new System.Windows.Forms.Label();
			this.cboxCompanyID = new System.Windows.Forms.ComboBox();
			this.cboxModel = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_slot = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.textBox_baseNo);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cboxCompanyID);
			this.panel1.Controls.Add(this.cboxModel);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox_slot);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(4, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 66);
			this.panel1.TabIndex = 0;
			// 
			// textBox_baseNo
			// 
			this.textBox_baseNo.Location = new System.Drawing.Point(204, 37);
			this.textBox_baseNo.Name = "textBox_baseNo";
			this.textBox_baseNo.Size = new System.Drawing.Size(52, 23);
			this.textBox_baseNo.TabIndex = 16;
			this.textBox_baseNo.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(137, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 17);
			this.label1.TabIndex = 15;
			this.label1.Text = "BaseNo：";
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(5, 4);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
			this.pipeSelectControl1.TabIndex = 14;
			this.pipeSelectControl1.TcpPortText = "2004";
			this.pipeSelectControl1.UdpPortText = "2004";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(446, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 17);
			this.label4.TabIndex = 13;
			this.label4.Text = "CompanyID:";
			// 
			// cboxCompanyID
			// 
			this.cboxCompanyID.FormattingEnabled = true;
			this.cboxCompanyID.Items.AddRange(new object[] {
            "LSIS-XGT",
            "LGIS-GLOGA",
            "MASTER-K"});
			this.cboxCompanyID.Location = new System.Drawing.Point(533, 36);
			this.cboxCompanyID.Name = "cboxCompanyID";
			this.cboxCompanyID.Size = new System.Drawing.Size(89, 25);
			this.cboxCompanyID.TabIndex = 12;
			// 
			// cboxModel
			// 
			this.cboxModel.FormattingEnabled = true;
			this.cboxModel.Location = new System.Drawing.Point(357, 36);
			this.cboxModel.Name = "cboxModel";
			this.cboxModel.Size = new System.Drawing.Size(71, 25);
			this.cboxModel.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(295, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "cpuType:";
			// 
			// textBox_slot
			// 
			this.textBox_slot.Location = new System.Drawing.Point(69, 37);
			this.textBox_slot.Name = "textBox_slot";
			this.textBox_slot.Size = new System.Drawing.Size(52, 23);
			this.textBox_slot.TabIndex = 9;
			this.textBox_slot.Text = "3";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(7, 40);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(42, 17);
			this.label15.TabIndex = 8;
			this.label15.Text = "Slot：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(897, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(799, 4);
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
			this.panel2.Location = new System.Drawing.Point(4, 105);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 537);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 535);
			this.userControlReadWriteDevice1.TabIndex = 0;
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
			this.userControlHead1.ProtocolInfo = "Fast Enet 协议";
			this.userControlHead1.Size = new System.Drawing.Size(1005, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 3;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormLsisFEnet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1005, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormLsisFEnet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LSIS PLC访问Demo";
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
        private System.Windows.Forms.TextBox textBox_slot;
        private System.Windows.Forms.Label label15;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.ComboBox cboxModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxCompanyID;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
		private DemoControl.PipeSelectControl pipeSelectControl1;
		private System.Windows.Forms.TextBox textBox_baseNo;
		private System.Windows.Forms.Label label1;
	}
}