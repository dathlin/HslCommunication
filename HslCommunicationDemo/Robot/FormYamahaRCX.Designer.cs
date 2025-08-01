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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox_keepmove = new System.Windows.Forms.CheckBox();
			this.button25 = new System.Windows.Forms.Button();
			this.button26 = new System.Windows.Forms.Button();
			this.button27 = new System.Windows.Forms.Button();
			this.button24 = new System.Windows.Forms.Button();
			this.button23 = new System.Windows.Forms.Button();
			this.button22 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button20 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button21 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textBox_result = new System.Windows.Forms.TextBox();
			this.button_execute = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_read_command = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(2, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(982, 45);
			this.panel1.TabIndex = 31;
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(3, 6);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(785, 31);
			this.pipeSelectControl1.TabIndex = 35;
			this.pipeSelectControl1.TcpPortText = "23";
			this.pipeSelectControl1.UdpPortText = "23";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(890, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(83, 27);
			this.button2.TabIndex = 18;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(795, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 27);
			this.button1.TabIndex = 17;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Controls.Add(this.textBox_result);
			this.panel2.Controls.Add(this.button_execute);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.textBox_read_command);
			this.panel2.Location = new System.Drawing.Point(2, 85);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(982, 572);
			this.panel2.TabIndex = 32;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 17);
			this.label4.TabIndex = 44;
			this.label4.Text = "Result:";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.checkBox_keepmove);
			this.panel3.Controls.Add(this.button25);
			this.panel3.Controls.Add(this.button26);
			this.panel3.Controls.Add(this.button27);
			this.panel3.Controls.Add(this.button24);
			this.panel3.Controls.Add(this.button23);
			this.panel3.Controls.Add(this.button22);
			this.panel3.Controls.Add(this.button10);
			this.panel3.Controls.Add(this.button3);
			this.panel3.Controls.Add(this.button20);
			this.panel3.Controls.Add(this.button4);
			this.panel3.Controls.Add(this.button5);
			this.panel3.Controls.Add(this.button6);
			this.panel3.Controls.Add(this.button21);
			this.panel3.Controls.Add(this.button7);
			this.panel3.Controls.Add(this.button18);
			this.panel3.Controls.Add(this.button8);
			this.panel3.Controls.Add(this.button19);
			this.panel3.Controls.Add(this.button9);
			this.panel3.Controls.Add(this.button16);
			this.panel3.Controls.Add(this.button11);
			this.panel3.Controls.Add(this.button17);
			this.panel3.Controls.Add(this.button13);
			this.panel3.Controls.Add(this.button14);
			this.panel3.Controls.Add(this.button12);
			this.panel3.Controls.Add(this.button15);
			this.panel3.Location = new System.Drawing.Point(599, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(378, 253);
			this.panel3.TabIndex = 43;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(2, 218);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 17);
			this.label1.TabIndex = 49;
			this.label1.Text = "(按下开始动作，松开结束动作)";
			// 
			// checkBox_keepmove
			// 
			this.checkBox_keepmove.AutoSize = true;
			this.checkBox_keepmove.Location = new System.Drawing.Point(5, 195);
			this.checkBox_keepmove.Name = "checkBox_keepmove";
			this.checkBox_keepmove.Size = new System.Drawing.Size(99, 21);
			this.checkBox_keepmove.TabIndex = 48;
			this.checkBox_keepmove.Text = "连续动作模式";
			this.checkBox_keepmove.UseVisualStyleBackColor = true;
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(291, 195);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(81, 26);
			this.button25.TabIndex = 47;
			this.button25.Text = "DO_2";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// button26
			// 
			this.button26.Location = new System.Drawing.Point(291, 163);
			this.button26.Name = "button26";
			this.button26.Size = new System.Drawing.Size(81, 26);
			this.button26.TabIndex = 46;
			this.button26.Text = "DO_1";
			this.button26.UseVisualStyleBackColor = true;
			this.button26.Click += new System.EventHandler(this.button26_Click);
			// 
			// button27
			// 
			this.button27.Location = new System.Drawing.Point(291, 131);
			this.button27.Name = "button27";
			this.button27.Size = new System.Drawing.Size(81, 26);
			this.button27.TabIndex = 45;
			this.button27.Text = "DO_0";
			this.button27.UseVisualStyleBackColor = true;
			this.button27.Click += new System.EventHandler(this.button27_Click);
			// 
			// button24
			// 
			this.button24.Location = new System.Drawing.Point(202, 195);
			this.button24.Name = "button24";
			this.button24.Size = new System.Drawing.Size(81, 26);
			this.button24.TabIndex = 44;
			this.button24.Text = "DI_2";
			this.button24.UseVisualStyleBackColor = true;
			this.button24.Click += new System.EventHandler(this.button24_Click);
			// 
			// button23
			// 
			this.button23.Location = new System.Drawing.Point(202, 163);
			this.button23.Name = "button23";
			this.button23.Size = new System.Drawing.Size(81, 26);
			this.button23.TabIndex = 43;
			this.button23.Text = "DI_1";
			this.button23.UseVisualStyleBackColor = true;
			this.button23.Click += new System.EventHandler(this.button23_Click);
			// 
			// button22
			// 
			this.button22.Location = new System.Drawing.Point(202, 131);
			this.button22.Name = "button22";
			this.button22.Size = new System.Drawing.Size(81, 26);
			this.button22.TabIndex = 42;
			this.button22.Text = "DI_0";
			this.button22.UseVisualStyleBackColor = true;
			this.button22.Click += new System.EventHandler(this.button22_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(3, 3);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(87, 26);
			this.button10.TabIndex = 30;
			this.button10.Text = "JOG 1-";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
			this.button10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(199, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(81, 26);
			this.button3.TabIndex = 18;
			this.button3.Text = "RESET";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button20
			// 
			this.button20.Location = new System.Drawing.Point(96, 163);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(87, 26);
			this.button20.TabIndex = 41;
			this.button20.Text = "JOG 6+";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += new System.EventHandler(this.button20_Click);
			this.button20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button20_MouseDown);
			this.button20.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(291, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(81, 26);
			this.button4.TabIndex = 19;
			this.button4.Text = "RUN";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(200, 67);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(81, 26);
			this.button5.TabIndex = 20;
			this.button5.Text = "STOP";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(200, 35);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(81, 26);
			this.button6.TabIndex = 21;
			this.button6.Text = "MOTOR";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(3, 163);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(87, 26);
			this.button21.TabIndex = 40;
			this.button21.Text = "JOG 6-";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += new System.EventHandler(this.button21_Click);
			this.button21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button21_MouseDown);
			this.button21.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(291, 35);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(81, 26);
			this.button7.TabIndex = 22;
			this.button7.Text = "MODE";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(96, 131);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(87, 26);
			this.button18.TabIndex = 39;
			this.button18.Text = "JOG 5+";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.button18_Click);
			this.button18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button18_MouseDown);
			this.button18.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(200, 99);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(81, 26);
			this.button8.TabIndex = 23;
			this.button8.Text = "JOINTS";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(3, 131);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(87, 26);
			this.button19.TabIndex = 38;
			this.button19.Text = "JOG 5-";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new System.EventHandler(this.button19_Click);
			this.button19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button19_MouseDown);
			this.button19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(291, 99);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(81, 26);
			this.button9.TabIndex = 24;
			this.button9.Text = "Emergency";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(96, 99);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(87, 26);
			this.button16.TabIndex = 37;
			this.button16.Text = "JOG 4+";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new System.EventHandler(this.button16_Click);
			this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button16_MouseDown);
			this.button16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(96, 3);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(87, 26);
			this.button11.TabIndex = 31;
			this.button11.Text = "JOG 1+";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button11_MouseDown);
			this.button11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(3, 99);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(87, 26);
			this.button17.TabIndex = 36;
			this.button17.Text = "JOG 4-";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new System.EventHandler(this.button17_Click);
			this.button17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button17_MouseDown);
			this.button17.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(3, 35);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(87, 26);
			this.button13.TabIndex = 32;
			this.button13.Text = "JOG 2-";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			this.button13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button13_MouseDown);
			this.button13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(96, 67);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(87, 26);
			this.button14.TabIndex = 35;
			this.button14.Text = "JOG 3+";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			this.button14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button14_MouseDown);
			this.button14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(96, 35);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(87, 26);
			this.button12.TabIndex = 33;
			this.button12.Text = "JOG 2+";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button12_MouseDown);
			this.button12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(3, 67);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(87, 26);
			this.button15.TabIndex = 34;
			this.button15.Text = "JOG 3-";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.button15_Click);
			this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button15_MouseDown);
			this.button15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(3, 262);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(976, 305);
			this.tabControl1.TabIndex = 42;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(968, 275);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Command List";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dataGridView1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(962, 269);
			this.panel4.TabIndex = 33;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(956, 263);
			this.dataGridView1.TabIndex = 32;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "功能名称";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 150;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "YAMAHA CX240";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 240;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "YAMAHA CX340";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 240;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "备注";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 300;
			// 
			// textBox_result
			// 
			this.textBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_result.Location = new System.Drawing.Point(81, 108);
			this.textBox_result.Multiline = true;
			this.textBox_result.Name = "textBox_result";
			this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_result.Size = new System.Drawing.Size(512, 148);
			this.textBox_result.TabIndex = 5;
			// 
			// button_execute
			// 
			this.button_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_execute.Location = new System.Drawing.Point(504, 6);
			this.button_execute.Name = "button_execute";
			this.button_execute.Size = new System.Drawing.Size(92, 26);
			this.button_execute.TabIndex = 29;
			this.button_execute.Text = "Command";
			this.button_execute.UseVisualStyleBackColor = true;
			this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 25;
			this.label3.Text = "Command:";
			// 
			// textBox_read_command
			// 
			this.textBox_read_command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_read_command.Location = new System.Drawing.Point(81, 9);
			this.textBox_read_command.Multiline = true;
			this.textBox_read_command.Name = "textBox_read_command";
			this.textBox_read_command.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_read_command.Size = new System.Drawing.Size(417, 93);
			this.textBox_read_command.TabIndex = 26;
			this.textBox_read_command.Text = "@？WHERE";
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormYamahaRCX_FormClosing);
			this.Load += new System.EventHandler(this.FormABBWebApi_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DemoControl.PipeSelectControl pipeSelectControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_keepmove;
    }
}