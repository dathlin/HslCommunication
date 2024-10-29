namespace HslCommunicationDemo
{
	partial class FormHttpClient
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Rpc Apis");
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.button8 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.label10 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label_url = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_api_sign = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox_api_description = new System.Windows.Forms.TextBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.hslBarChart1 = new HslControls.HslBarChart();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_response_hex = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
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
			this.userControlHead1.ProtocolInfo = "web api";
			this.userControlHead1.Size = new System.Drawing.Size(1023, 32);
			this.userControlHead1.TabIndex = 30;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox4);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1015, 56);
			this.panel1.TabIndex = 31;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(134, 31);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(124, 21);
			this.checkBox2.TabIndex = 21;
			this.checkBox2.Text = "UseEncodingISO";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Fuchsia;
			this.label8.Location = new System.Drawing.Point(333, 36);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(208, 17);
			this.label8.TabIndex = 20;
			this.label8.Text = "if use https, the port is default 443";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(338, 14);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 21);
			this.checkBox1.TabIndex = 19;
			this.checkBox1.Text = "UseHttps";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(861, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 25);
			this.button2.TabIndex = 18;
			this.button2.Text = "close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(753, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 25);
			this.button1.TabIndex = 17;
			this.button1.Text = "open";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(635, 12);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(97, 23);
			this.textBox4.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(568, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "password";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(479, 12);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(83, 23);
			this.textBox3.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(433, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Name";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(269, 5);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(51, 23);
			this.textBox2.TabIndex = 12;
			this.textBox2.Text = "80";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(229, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Port";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(92, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(125, 23);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "Ip Address";
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.button8);
			this.panel4.Controls.Add(this.treeView1);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Location = new System.Drawing.Point(4, 97);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(259, 534);
			this.panel4.TabIndex = 33;
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button8.Location = new System.Drawing.Point(180, 2);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 2;
			this.button8.Text = "刷新";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.Location = new System.Drawing.Point(3, 28);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "节点0";
			treeNode1.Text = "Rpc Apis";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.treeView1.Size = new System.Drawing.Size(251, 499);
			this.treeView1.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(5, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(140, 17);
			this.label10.TabIndex = 0;
			this.label10.Text = "Api List: (RPC 接口列表)";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label_url);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.textBox_api_sign);
			this.panel2.Controls.Add(this.label24);
			this.panel2.Controls.Add(this.label15);
			this.panel2.Controls.Add(this.textBox_api_description);
			this.panel2.Controls.Add(this.comboBox2);
			this.panel2.Controls.Add(this.hslBarChart1);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.button7);
			this.panel2.Controls.Add(this.textBox13);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.textBox12);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Controls.Add(this.textBox7);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.textBox8);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.textBox5);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.textBox9);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new System.Drawing.Point(266, 97);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(753, 534);
			this.panel2.TabIndex = 34;
			// 
			// label_url
			// 
			this.label_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_url.AutoSize = true;
			this.label_url.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label_url.Location = new System.Drawing.Point(60, 513);
			this.label_url.Name = "label_url";
			this.label_url.Size = new System.Drawing.Size(0, 17);
			this.label_url.TabIndex = 58;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label12.Location = new System.Drawing.Point(4, 513);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(37, 17);
			this.label12.TabIndex = 57;
			this.label12.Text = "Url：";
			// 
			// textBox_api_sign
			// 
			this.textBox_api_sign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_api_sign.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_api_sign.ForeColor = System.Drawing.Color.Gray;
			this.textBox_api_sign.Location = new System.Drawing.Point(61, 38);
			this.textBox_api_sign.Name = "textBox_api_sign";
			this.textBox_api_sign.ReadOnly = true;
			this.textBox_api_sign.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_api_sign.Size = new System.Drawing.Size(683, 16);
			this.textBox_api_sign.TabIndex = 56;
			this.textBox_api_sign.Text = "[签名]";
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.AutoSize = true;
			this.label24.ForeColor = System.Drawing.Color.Gray;
			this.label24.Location = new System.Drawing.Point(-1, 37);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(40, 17);
			this.label24.TabIndex = 55;
			this.label24.Text = "[签名]";
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.Gray;
			this.label15.Location = new System.Drawing.Point(-1, 59);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 17);
			this.label15.TabIndex = 54;
			this.label15.Text = "[注释]";
			// 
			// textBox_api_description
			// 
			this.textBox_api_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_api_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_api_description.ForeColor = System.Drawing.Color.Gray;
			this.textBox_api_description.Location = new System.Drawing.Point(61, 59);
			this.textBox_api_description.Multiline = true;
			this.textBox_api_description.Name = "textBox_api_description";
			this.textBox_api_description.ReadOnly = true;
			this.textBox_api_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_api_description.Size = new System.Drawing.Size(683, 56);
			this.textBox_api_description.TabIndex = 53;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(217, 271);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(179, 25);
			this.comboBox2.TabIndex = 46;
			// 
			// hslBarChart1
			// 
			this.hslBarChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hslBarChart1.BackColor = System.Drawing.Color.White;
			this.hslBarChart1.Location = new System.Drawing.Point(445, 121);
			this.hslBarChart1.Name = "hslBarChart1";
			this.hslBarChart1.ShowBarValueFormat = "{0}";
			this.hslBarChart1.Size = new System.Drawing.Size(304, 143);
			this.hslBarChart1.TabIndex = 45;
			this.hslBarChart1.Text = "hslBarChart1";
			this.hslBarChart1.Title = "Called Infomation";
			this.hslBarChart1.UseGradient = true;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(62, 272);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(69, 25);
			this.comboBox1.TabIndex = 43;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(402, 270);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(119, 28);
			this.button7.TabIndex = 40;
			this.button7.Text = "Apis Information";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox13
			// 
			this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox13.Location = new System.Drawing.Point(667, 7);
			this.textBox13.Name = "textBox13";
			this.textBox13.ReadOnly = true;
			this.textBox13.Size = new System.Drawing.Size(81, 23);
			this.textBox13.TabIndex = 39;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(591, 11);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 17);
			this.label14.TabIndex = 38;
			this.label14.Text = "Total Time:";
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(511, 7);
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.Size = new System.Drawing.Size(70, 23);
			this.textBox12.TabIndex = 37;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(418, 11);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 17);
			this.label13.TabIndex = 36;
			this.label13.Text = "Called Count:";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(667, 270);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(81, 23);
			this.textBox7.TabIndex = 31;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(583, 272);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 30;
			this.label11.Text = "耗时：";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.radioButton_response_hex);
			this.panel3.Controls.Add(this.radioButton5);
			this.panel3.Controls.Add(this.radioButton3);
			this.panel3.Controls.Add(this.radioButton4);
			this.panel3.Location = new System.Drawing.Point(431, 301);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(242, 28);
			this.panel3.TabIndex = 26;
			// 
			// radioButton_response_hex
			// 
			this.radioButton_response_hex.AutoSize = true;
			this.radioButton_response_hex.Location = new System.Drawing.Point(181, 3);
			this.radioButton_response_hex.Name = "radioButton_response_hex";
			this.radioButton_response_hex.Size = new System.Drawing.Size(48, 21);
			this.radioButton_response_hex.TabIndex = 29;
			this.radioButton_response_hex.Text = "Hex";
			this.radioButton_response_hex.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(123, 3);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(52, 21);
			this.radioButton5.TabIndex = 28;
			this.radioButton5.Text = "Json";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(13, 3);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(50, 21);
			this.radioButton3.TabIndex = 26;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Text";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(69, 3);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(48, 21);
			this.radioButton4.TabIndex = 27;
			this.radioButton4.Text = "Xml";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(62, 341);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(686, 167);
			this.textBox8.TabIndex = 18;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(678, 301);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(71, 28);
			this.button4.TabIndex = 17;
			this.button4.Text = "清空";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(141, 270);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(70, 28);
			this.button3.TabIndex = 12;
			this.button3.Text = "读取";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(62, 121);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox5.Size = new System.Drawing.Size(377, 145);
			this.textBox5.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(-1, 121);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "Body：";
			// 
			// textBox9
			// 
			this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox9.Location = new System.Drawing.Point(62, 7);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(343, 23);
			this.textBox9.TabIndex = 9;
			this.textBox9.Text = "A";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(0, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Api：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-1, 341);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 42;
			this.label5.Text = "Response:";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(60, 300);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(428, 36);
			this.label6.TabIndex = 44;
			// 
			// FormHttpClient
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1023, 634);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormHttpClient";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormWebClient";
			this.Load += new System.EventHandler(this.FormABBWebApi_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
		private HslControls.HslBarChart hslBarChart1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox_api_sign;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox_api_description;
		private System.Windows.Forms.Label label_url;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.RadioButton radioButton_response_hex;
	}
}