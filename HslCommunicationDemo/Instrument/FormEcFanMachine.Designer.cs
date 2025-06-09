namespace HslCommunicationDemo.Instrument
{
    partial class FormEcFanMachine
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
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
            this.textBox_station = new System.Windows.Forms.TextBox();
            this.label_address = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.codeExampleControl1 = new HslCommunicationDemo.DemoControl.CodeExampleControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton_run_false = new System.Windows.Forms.RadioButton();
            this.radioButton_run_true = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlHead1
            // 
            this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
            this.userControlHead1.Location = new System.Drawing.Point(0, 0);
            this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
            this.userControlHead1.Name = "userControlHead1";
            this.userControlHead1.ProtocolInfo = "FFU EC 风机";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.TabIndex = 3;
            this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pipeSelectControl1);
            this.panel1.Controls.Add(this.textBox_station);
            this.panel1.Controls.Add(this.label_address);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 59);
            this.panel1.TabIndex = 4;
            // 
            // pipeSelectControl1
            // 
            this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pipeSelectControl1.Location = new System.Drawing.Point(6, 2);
            this.pipeSelectControl1.Name = "pipeSelectControl1";
            this.pipeSelectControl1.SerialBaudRate = "9600";
            this.pipeSelectControl1.SerialDataBits = "8";
            this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
            this.pipeSelectControl1.SerialStopBits = "1";
            this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.SerialPipe;
            this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
            this.pipeSelectControl1.TabIndex = 36;
            this.pipeSelectControl1.TcpPortText = "2000";
            this.pipeSelectControl1.UdpPortText = "2000";
            // 
            // textBox_station
            // 
            this.textBox_station.Location = new System.Drawing.Point(56, 32);
            this.textBox_station.Name = "textBox_station";
            this.textBox_station.Size = new System.Drawing.Size(146, 23);
            this.textBox_station.TabIndex = 7;
            this.textBox_station.Text = "1";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(8, 35);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(44, 17);
            this.label_address.TabIndex = 6;
            this.label_address.Text = "站号：";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(900, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "关闭串口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(803, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(3, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 548);
            this.panel2.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.codeExampleControl1);
            this.panel5.Location = new System.Drawing.Point(6, 285);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(985, 258);
            this.panel5.TabIndex = 2;
            // 
            // codeExampleControl1
            // 
            this.codeExampleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeExampleControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeExampleControl1.Location = new System.Drawing.Point(0, 0);
            this.codeExampleControl1.Name = "codeExampleControl1";
            this.codeExampleControl1.Size = new System.Drawing.Size(983, 256);
            this.codeExampleControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_time);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.textBox_result);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(396, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 275);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "速度读取";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(237, 239);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 29);
            this.button5.TabIndex = 9;
            this.button5.Text = "设置站号";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_result.Location = new System.Drawing.Point(6, 73);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(580, 161);
            this.textBox_result.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(60, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "2";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(359, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(161, 41);
            this.button7.TabIndex = 9;
            this.button7.Text = "读取最高转速";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "站号:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(183, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 41);
            this.button6.TabIndex = 8;
            this.button6.Text = "读取最低转速";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 41);
            this.button4.TabIndex = 7;
            this.button4.Text = "读取应急模式速度";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "速度设置区域";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(6, 159);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(372, 110);
            this.textBox3.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(104, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "设置速度";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "设置速度:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton3);
            this.panel4.Controls.Add(this.radioButton4);
            this.panel4.Location = new System.Drawing.Point(95, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 30);
            this.panel4.TabIndex = 3;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(130, 1);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 21);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "不处理";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(9, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(106, 21);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Text = "应急模式(切换)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "应急模式:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton_run_false);
            this.panel3.Controls.Add(this.radioButton_run_true);
            this.panel3.Location = new System.Drawing.Point(95, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 30);
            this.panel3.TabIndex = 1;
            // 
            // radioButton_run_false
            // 
            this.radioButton_run_false.AutoSize = true;
            this.radioButton_run_false.Location = new System.Drawing.Point(130, 3);
            this.radioButton_run_false.Name = "radioButton_run_false";
            this.radioButton_run_false.Size = new System.Drawing.Size(62, 21);
            this.radioButton_run_false.TabIndex = 1;
            this.radioButton_run_false.Text = "停止中";
            this.radioButton_run_false.UseVisualStyleBackColor = true;
            // 
            // radioButton_run_true
            // 
            this.radioButton_run_true.AutoSize = true;
            this.radioButton_run_true.Checked = true;
            this.radioButton_run_true.Location = new System.Drawing.Point(9, 3);
            this.radioButton_run_true.Name = "radioButton_run_true";
            this.radioButton_run_true.Size = new System.Drawing.Size(62, 21);
            this.radioButton_run_true.TabIndex = 0;
            this.radioButton_run_true.TabStop = true;
            this.radioButton_run_true.Text = "运行中";
            this.radioButton_run_true.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行模式:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "耗时:";
            // 
            // label_time
            // 
            this.label_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(455, 246);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(36, 17);
            this.label_time.TabIndex = 13;
            this.label_time.Text = "0 ms";
            // 
            // FormEcFanMachine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControlHead1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormEcFanMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEcFanMachine";
            this.Load += new System.EventHandler(this.FormEcFanMachine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel1;
        private DemoControl.PipeSelectControl pipeSelectControl1;
        private System.Windows.Forms.TextBox textBox_station;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton_run_false;
        private System.Windows.Forms.RadioButton radioButton_run_true;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_result;
        private DemoControl.CodeExampleControl codeExampleControl1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label5;
    }
}