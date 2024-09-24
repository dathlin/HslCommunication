namespace HslCommunicationDemo.PLC
{
    partial class FormKnx
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.data_box = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.out_box = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.Run_list_button = new System.Windows.Forms.Button();
			this.Sotp_list_button = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.addr = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.data = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.modbus_prot = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.R_PROT = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.R_IP = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.data_box);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.out_box);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(469, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(523, 112);
			this.groupBox2.TabIndex = 50;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "地址转换器";
			// 
			// data_box
			// 
			this.data_box.Location = new System.Drawing.Point(77, 27);
			this.data_box.Name = "data_box";
			this.data_box.Size = new System.Drawing.Size(65, 23);
			this.data_box.TabIndex = 28;
			this.data_box.Text = "1/1/1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 17);
			this.label8.TabIndex = 29;
			this.label8.Text = "组地址";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(159, 27);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 31;
			this.button7.Text = "地址转换";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// out_box
			// 
			this.out_box.Location = new System.Drawing.Point(77, 70);
			this.out_box.Name = "out_box";
			this.out_box.Size = new System.Drawing.Size(65, 23);
			this.out_box.TabIndex = 32;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 75);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 17);
			this.label9.TabIndex = 33;
			this.label9.Text = "modbus地址";
			// 
			// Run_list_button
			// 
			this.Run_list_button.Enabled = false;
			this.Run_list_button.Location = new System.Drawing.Point(564, 169);
			this.Run_list_button.Name = "Run_list_button";
			this.Run_list_button.Size = new System.Drawing.Size(89, 23);
			this.Run_list_button.TabIndex = 51;
			this.Run_list_button.Text = "继续列表显示";
			this.Run_list_button.UseVisualStyleBackColor = true;
			this.Run_list_button.Click += new System.EventHandler(this.Run_list_button_Click);
			// 
			// Sotp_list_button
			// 
			this.Sotp_list_button.Location = new System.Drawing.Point(469, 169);
			this.Sotp_list_button.Name = "Sotp_list_button";
			this.Sotp_list_button.Size = new System.Drawing.Size(89, 23);
			this.Sotp_list_button.TabIndex = 46;
			this.Sotp_list_button.Text = "停止列表显示";
			this.Sotp_list_button.UseVisualStyleBackColor = true;
			this.Sotp_list_button.Click += new System.EventHandler(this.Sotp_list_button_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.addr);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.data);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(469, 49);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(523, 114);
			this.groupBox1.TabIndex = 49;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "测试工具";
			// 
			// addr
			// 
			this.addr.Location = new System.Drawing.Point(53, 27);
			this.addr.Name = "addr";
			this.addr.Size = new System.Drawing.Size(65, 23);
			this.addr.TabIndex = 28;
			this.addr.Text = "1\\1\\1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 29;
			this.label5.Text = "组地址";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(159, 68);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 30;
			this.button2.Text = "bool写入";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(159, 27);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 31;
			this.button3.Text = "读取";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// data
			// 
			this.data.Location = new System.Drawing.Point(53, 70);
			this.data.Name = "data";
			this.data.Size = new System.Drawing.Size(65, 23);
			this.data.TabIndex = 32;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 75);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 17);
			this.label6.TabIndex = 33;
			this.label6.Text = "数据";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 81);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 17);
			this.label7.TabIndex = 48;
			this.label7.Text = "modbus端口";
			// 
			// modbus_prot
			// 
			this.modbus_prot.Location = new System.Drawing.Point(98, 78);
			this.modbus_prot.Name = "modbus_prot";
			this.modbus_prot.Size = new System.Drawing.Size(45, 23);
			this.modbus_prot.TabIndex = 47;
			this.modbus_prot.Text = "504";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(14, 111);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(431, 497);
			this.listBox1.TabIndex = 45;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(200, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 44;
			this.label3.Text = "设备端口";
			// 
			// R_PROT
			// 
			this.R_PROT.Location = new System.Drawing.Point(267, 49);
			this.R_PROT.Name = "R_PROT";
			this.R_PROT.Size = new System.Drawing.Size(45, 23);
			this.R_PROT.TabIndex = 43;
			this.R_PROT.Text = "3671";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 17);
			this.label4.TabIndex = 42;
			this.label4.Text = "设备IP";
			// 
			// R_IP
			// 
			this.R_IP.Location = new System.Drawing.Point(79, 49);
			this.R_IP.Name = "R_IP";
			this.R_IP.Size = new System.Drawing.Size(100, 23);
			this.R_IP.TabIndex = 41;
			this.R_IP.Text = "192.168.10.1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(340, 49);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 23);
			this.button1.TabIndex = 40;
			this.button1.Text = "启动系统";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
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
			this.userControlHead1.ProtocolInfo = "Knx";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 52;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 623);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
			this.statusStrip1.TabIndex = 53;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(323, 17);
			this.toolStripStatusLabel1.Text = "感谢上海网友（杨俊锋 QQ：136044669）提供的技术支持";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(659, 169);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(63, 23);
			this.button4.TabIndex = 54;
			this.button4.Text = "清空";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// FormKnx
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.Run_list_button);
			this.Controls.Add(this.Sotp_list_button);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.modbus_prot);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.R_PROT);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.R_IP);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormKnx";
			this.Text = "FormKnx";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.FormKnx_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox data_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox out_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Run_list_button;
        private System.Windows.Forms.Button Sotp_list_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox addr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox modbus_prot;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox R_PROT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox R_IP;
        private System.Windows.Forms.Button button1;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button4;
    }
}