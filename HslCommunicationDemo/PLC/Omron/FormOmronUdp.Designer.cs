namespace HslCommunicationDemo
{
    partial class FormOmronUdp
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_plcType = new System.Windows.Forms.ComboBox();
            this.textBox_da1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_isstringreverse = new System.Windows.Forms.CheckBox();
            this.textBox_gct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_sa1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlReadWriteDevice1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteDevice();
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.textBox_sid = new System.Windows.Forms.TextBox();
            this.label_sid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_sid);
            this.panel1.Controls.Add(this.label_sid);
            this.panel1.Controls.Add(this.pipeSelectControl1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_plcType);
            this.panel1.Controls.Add(this.textBox_da1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.checkBox_isstringreverse);
            this.panel1.Controls.Add(this.textBox_gct);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBox_sa1);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 64);
            this.panel1.TabIndex = 0;
            // 
            // pipeSelectControl1
            // 
            this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pipeSelectControl1.Location = new System.Drawing.Point(4, 1);
            this.pipeSelectControl1.Name = "pipeSelectControl1";
            this.pipeSelectControl1.SerialBaudRate = "9600";
            this.pipeSelectControl1.SerialDataBits = "8";
            this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
            this.pipeSelectControl1.SerialStopBits = "1";
            this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.UdpPipe;
            this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
            this.pipeSelectControl1.TabIndex = 28;
            this.pipeSelectControl1.TcpPortText = "9600";
            this.pipeSelectControl1.UdpPortText = "9600";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(783, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Type:";
            // 
            // comboBox_plcType
            // 
            this.comboBox_plcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_plcType.FormattingEnabled = true;
            this.comboBox_plcType.Location = new System.Drawing.Point(828, 33);
            this.comboBox_plcType.Name = "comboBox_plcType";
            this.comboBox_plcType.Size = new System.Drawing.Size(109, 25);
            this.comboBox_plcType.TabIndex = 26;
            // 
            // textBox_da1
            // 
            this.textBox_da1.Location = new System.Drawing.Point(273, 35);
            this.textBox_da1.Name = "textBox_da1";
            this.textBox_da1.Size = new System.Drawing.Size(40, 23);
            this.textBox_da1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "目标网络号(DA1):";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(907, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 28);
            this.button2.TabIndex = 20;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_isstringreverse
            // 
            this.checkBox_isstringreverse.AutoSize = true;
            this.checkBox_isstringreverse.Checked = true;
            this.checkBox_isstringreverse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_isstringreverse.Location = new System.Drawing.Point(636, 37);
            this.checkBox_isstringreverse.Name = "checkBox_isstringreverse";
            this.checkBox_isstringreverse.Size = new System.Drawing.Size(127, 21);
            this.checkBox_isstringreverse.TabIndex = 19;
            this.checkBox_isstringreverse.Text = "Is string reverse?";
            this.checkBox_isstringreverse.UseVisualStyleBackColor = true;
            // 
            // textBox_gct
            // 
            this.textBox_gct.Location = new System.Drawing.Point(360, 35);
            this.textBox_gct.Name = "textBox_gct";
            this.textBox_gct.Size = new System.Drawing.Size(44, 23);
            this.textBox_gct.TabIndex = 16;
            this.textBox_gct.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "GCT:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(502, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 25);
            this.comboBox1.TabIndex = 14;
            // 
            // textBox_sa1
            // 
            this.textBox_sa1.Location = new System.Drawing.Point(115, 35);
            this.textBox_sa1.Name = "textBox_sa1";
            this.textBox_sa1.Size = new System.Drawing.Size(40, 23);
            this.textBox_sa1.TabIndex = 9;
            this.textBox_sa1.Text = "1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(110, 17);
            this.label23.TabIndex = 8;
            this.label23.Text = "本机网络号(SA1)：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(816, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
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
            this.panel2.Location = new System.Drawing.Point(3, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 541);
            this.panel2.TabIndex = 1;
            // 
            // userControlReadWriteDevice1
            // 
            this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
            this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
            this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 539);
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
            this.userControlHead1.ProtocolInfo = "Fins Udp";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.SupportListVisiable = true;
            this.userControlHead1.TabIndex = 2;
            this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
            // 
            // textBox_sid
            // 
            this.textBox_sid.Location = new System.Drawing.Point(451, 34);
            this.textBox_sid.Name = "textBox_sid";
            this.textBox_sid.Size = new System.Drawing.Size(44, 23);
            this.textBox_sid.TabIndex = 30;
            this.textBox_sid.Text = "0";
            // 
            // label_sid
            // 
            this.label_sid.AutoSize = true;
            this.label_sid.Location = new System.Drawing.Point(410, 37);
            this.label_sid.Name = "label_sid";
            this.label_sid.Size = new System.Drawing.Size(31, 17);
            this.label_sid.TabIndex = 29;
            this.label_sid.Text = "SID:";
            // 
            // FormOmronUdp
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
            this.Name = "FormOmronUdp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "欧姆龙PLC访问Demo";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_sa1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBox1;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_gct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_isstringreverse;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox_da1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_plcType;
		private System.Windows.Forms.Label label5;
		private DemoControl.PipeSelectControl pipeSelectControl1;
        private System.Windows.Forms.TextBox textBox_sid;
        private System.Windows.Forms.Label label_sid;
    }
}