namespace HslCommunicationDemo.Robot
{
    partial class FormYamahaRCX
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_read_command = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_read_lines = new System.Windows.Forms.TextBox();
			this.button_execute = new System.Windows.Forms.Button();
			this.textBox_result = new System.Windows.Forms.TextBox();
			this.button20 = new System.Windows.Forms.Button();
			this.button21 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
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
			this.userControlHead1.ProtocolInfo = "TCP";
			this.userControlHead1.Size = new System.Drawing.Size(986, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 30;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(2, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(982, 45);
			this.panel1.TabIndex = 31;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(508, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 24);
			this.button2.TabIndex = 18;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(399, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 24);
			this.button1.TabIndex = 17;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(325, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(54, 23);
			this.textBox2.TabIndex = 12;
			this.textBox2.Text = "23";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(285, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Port";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(85, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(194, 23);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "192.168.1.20";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "Ip Address";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Controls.Add(this.button20);
			this.panel2.Controls.Add(this.button21);
			this.panel2.Controls.Add(this.button18);
			this.panel2.Controls.Add(this.button19);
			this.panel2.Controls.Add(this.button16);
			this.panel2.Controls.Add(this.button17);
			this.panel2.Controls.Add(this.button14);
			this.panel2.Controls.Add(this.button15);
			this.panel2.Controls.Add(this.button12);
			this.panel2.Controls.Add(this.button13);
			this.panel2.Controls.Add(this.button11);
			this.panel2.Controls.Add(this.button10);
			this.panel2.Controls.Add(this.button9);
			this.panel2.Controls.Add(this.button8);
			this.panel2.Controls.Add(this.button7);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new System.Drawing.Point(2, 85);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(982, 572);
			this.panel2.TabIndex = 32;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(3, 188);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(976, 379);
			this.tabControl1.TabIndex = 42;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox_code);
			this.tabPage1.Controls.Add(this.label_code);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.textBox_read_command);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.textBox_read_lines);
			this.tabPage1.Controls.Add(this.button_execute);
			this.tabPage1.Controls.Add(this.textBox_result);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(968, 349);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Command Test";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(70, 291);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(892, 49);
			this.textBox_code.TabIndex = 31;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(6, 294);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(42, 17);
			this.label_code.TabIndex = 30;
			this.label_code.Text = "Code:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 25;
			this.label3.Text = "Command:";
			// 
			// textBox_read_command
			// 
			this.textBox_read_command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_read_command.Location = new System.Drawing.Point(83, 4);
			this.textBox_read_command.Name = "textBox_read_command";
			this.textBox_read_command.Size = new System.Drawing.Size(621, 23);
			this.textBox_read_command.TabIndex = 26;
			this.textBox_read_command.Text = "@ ？WHERE";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(712, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 17);
			this.label4.TabIndex = 27;
			this.label4.Text = "Lines:";
			// 
			// textBox_read_lines
			// 
			this.textBox_read_lines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_read_lines.Location = new System.Drawing.Point(758, 4);
			this.textBox_read_lines.Name = "textBox_read_lines";
			this.textBox_read_lines.Size = new System.Drawing.Size(56, 23);
			this.textBox_read_lines.TabIndex = 28;
			this.textBox_read_lines.Text = "1";
			// 
			// button_execute
			// 
			this.button_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_execute.Location = new System.Drawing.Point(820, 2);
			this.button_execute.Name = "button_execute";
			this.button_execute.Size = new System.Drawing.Size(137, 26);
			this.button_execute.TabIndex = 29;
			this.button_execute.Text = "Execute Command";
			this.button_execute.UseVisualStyleBackColor = true;
			this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
			// 
			// textBox_result
			// 
			this.textBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_result.Location = new System.Drawing.Point(7, 33);
			this.textBox_result.Multiline = true;
			this.textBox_result.Name = "textBox_result";
			this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_result.Size = new System.Drawing.Size(955, 255);
			this.textBox_result.TabIndex = 5;
			// 
			// button20
			// 
			this.button20.Location = new System.Drawing.Point(510, 163);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(87, 26);
			this.button20.TabIndex = 41;
			this.button20.Text = "JOG 6+";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += new System.EventHandler(this.button20_Click);
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(417, 163);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(87, 26);
			this.button21.TabIndex = 40;
			this.button21.Text = "JOG 6-";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += new System.EventHandler(this.button21_Click);
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(510, 131);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(87, 26);
			this.button18.TabIndex = 39;
			this.button18.Text = "JOG 5+";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.button18_Click);
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(417, 131);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(87, 26);
			this.button19.TabIndex = 38;
			this.button19.Text = "JOG 5-";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new System.EventHandler(this.button19_Click);
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(510, 99);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(87, 26);
			this.button16.TabIndex = 37;
			this.button16.Text = "JOG 4+";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new System.EventHandler(this.button16_Click);
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(417, 99);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(87, 26);
			this.button17.TabIndex = 36;
			this.button17.Text = "JOG 4-";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new System.EventHandler(this.button17_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(510, 67);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(87, 26);
			this.button14.TabIndex = 35;
			this.button14.Text = "JOG 3+";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(417, 67);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(87, 26);
			this.button15.TabIndex = 34;
			this.button15.Text = "JOG 3-";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(510, 35);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(87, 26);
			this.button12.TabIndex = 33;
			this.button12.Text = "JOG 2+";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(417, 35);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(87, 26);
			this.button13.TabIndex = 32;
			this.button13.Text = "JOG 2-";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(510, 3);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(87, 26);
			this.button11.TabIndex = 31;
			this.button11.Text = "JOG 1+";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(417, 3);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(87, 26);
			this.button10.TabIndex = 30;
			this.button10.Text = "JOG 1-";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(329, 35);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(81, 26);
			this.button9.TabIndex = 24;
			this.button9.Text = "Emergency";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(242, 35);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(81, 26);
			this.button8.TabIndex = 23;
			this.button8.Text = "JOINTS";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(153, 35);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(81, 26);
			this.button7.TabIndex = 22;
			this.button7.Text = "MODE";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(62, 35);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(81, 26);
			this.button6.TabIndex = 21;
			this.button6.Text = "MOTOR";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(242, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(81, 26);
			this.button5.TabIndex = 20;
			this.button5.Text = "STOP";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(153, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(81, 26);
			this.button4.TabIndex = 19;
			this.button4.Text = "RUN";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(61, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(81, 26);
			this.button3.TabIndex = 18;
			this.button3.Text = "RESET";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 7);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "Content";
			// 
			// FormYamahaRCX
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(986, 660);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormYamahaRCX";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormYamahaRCX";
			this.Load += new System.EventHandler(this.FormABBWebApi_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox_result;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button_execute;
		private System.Windows.Forms.TextBox textBox_read_lines;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_read_command;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button20;
		private System.Windows.Forms.Button button21;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textBox_code;
		private System.Windows.Forms.Label label_code;
	}
}