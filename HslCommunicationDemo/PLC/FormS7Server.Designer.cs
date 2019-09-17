namespace HslCommunicationDemo
{
    partial class FormS7Server
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
            this.label11 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button_read_string = new System.Windows.Forms.Button();
            this.button_read_double = new System.Windows.Forms.Button();
            this.button_read_float = new System.Windows.Forms.Button();
            this.button_read_ulong = new System.Windows.Forms.Button();
            this.button_read_long = new System.Windows.Forms.Button();
            this.button_read_uint = new System.Windows.Forms.Button();
            this.button_read_int = new System.Windows.Forms.Button();
            this.button_read_ushort = new System.Windows.Forms.Button();
            this.button_read_short = new System.Windows.Forms.Button();
            this.button_read_bool = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(14, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 45);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(343, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(447, 41);
            this.label11.TabIndex = 29;
            this.label11.Text = "本服务器不是严格的s7协议，仅支持和HSL组件完美通信。";
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(235, 8);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 28);
            this.button11.TabIndex = 28;
            this.button11.Text = "关闭服务";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(796, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "连接异形客户端";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "启动服务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(65, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "102";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(14, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 537);
            this.panel2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(414, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 36);
            this.label15.TabIndex = 17;
            this.label15.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(225, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(183, 36);
            this.label16.TabIndex = 16;
            this.label16.Text = "在线客户端：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(82, 263);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "显示接收到的数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(11, 293);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(954, 229);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "运行日志：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.button22);
            this.groupBox2.Controls.Add(this.button24);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(546, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 247);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单数据写入测试";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(144, 207);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 28);
            this.button10.TabIndex = 21;
            this.button10.Text = "定时写";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(78, 207);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 28);
            this.button9.TabIndex = 20;
            this.button9.Text = "存储";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 207);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 28);
            this.button8.TabIndex = 19;
            this.button8.Text = "加载";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(329, 24);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 28);
            this.button7.TabIndex = 18;
            this.button7.Text = "byte写入";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(61, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(148, 88);
            this.label19.TabIndex = 17;
            this.label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(331, 198);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(82, 28);
            this.button14.TabIndex = 16;
            this.button14.Text = "字符串写入";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(331, 164);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(82, 28);
            this.button15.TabIndex = 15;
            this.button15.Text = "double写入";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(229, 164);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(82, 28);
            this.button16.TabIndex = 14;
            this.button16.Text = "float写入";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(331, 129);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(82, 28);
            this.button17.TabIndex = 13;
            this.button17.Text = "ulong写入";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(226, 129);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(82, 28);
            this.button18.TabIndex = 12;
            this.button18.Text = "long写入";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(331, 95);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(82, 28);
            this.button19.TabIndex = 11;
            this.button19.Text = "uint写入";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(226, 95);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(82, 28);
            this.button20.TabIndex = 10;
            this.button20.Text = "int写入";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(329, 61);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(82, 28);
            this.button21.TabIndex = 9;
            this.button21.Text = "ushort写入";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(226, 61);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(82, 28);
            this.button22.TabIndex = 8;
            this.button22.Text = "short写入";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(226, 24);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(82, 28);
            this.button24.TabIndex = 6;
            this.button24.Text = "位写入";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(63, 56);
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox7.Size = new System.Drawing.Size(132, 23);
            this.textBox7.TabIndex = 5;
            this.textBox7.Text = "False";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "值：";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(63, 27);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(132, 23);
            this.textBox8.TabIndex = 3;
            this.textBox8.Text = "M100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.button_read_string);
            this.groupBox1.Controls.Add(this.button_read_double);
            this.groupBox1.Controls.Add(this.button_read_float);
            this.groupBox1.Controls.Add(this.button_read_ulong);
            this.groupBox1.Controls.Add(this.button_read_long);
            this.groupBox1.Controls.Add(this.button_read_uint);
            this.groupBox1.Controls.Add(this.button_read_int);
            this.groupBox1.Controls.Add(this.button_read_ushort);
            this.groupBox1.Controls.Add(this.button_read_short);
            this.groupBox1.Controls.Add(this.button_read_bool);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单数据读取测试";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(415, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 28);
            this.button6.TabIndex = 19;
            this.button6.Text = "byte读取";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(358, 195);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(41, 23);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "10";
            // 
            // button_read_string
            // 
            this.button_read_string.Location = new System.Drawing.Point(415, 192);
            this.button_read_string.Name = "button_read_string";
            this.button_read_string.Size = new System.Drawing.Size(82, 28);
            this.button_read_string.TabIndex = 16;
            this.button_read_string.Text = "字符串读取";
            this.button_read_string.UseVisualStyleBackColor = true;
            this.button_read_string.Click += new System.EventHandler(this.button_read_string_Click);
            // 
            // button_read_double
            // 
            this.button_read_double.Location = new System.Drawing.Point(415, 158);
            this.button_read_double.Name = "button_read_double";
            this.button_read_double.Size = new System.Drawing.Size(82, 28);
            this.button_read_double.TabIndex = 15;
            this.button_read_double.Text = "double读取";
            this.button_read_double.UseVisualStyleBackColor = true;
            this.button_read_double.Click += new System.EventHandler(this.button_read_double_Click);
            // 
            // button_read_float
            // 
            this.button_read_float.Location = new System.Drawing.Point(315, 158);
            this.button_read_float.Name = "button_read_float";
            this.button_read_float.Size = new System.Drawing.Size(82, 28);
            this.button_read_float.TabIndex = 14;
            this.button_read_float.Text = "float读取";
            this.button_read_float.UseVisualStyleBackColor = true;
            this.button_read_float.Click += new System.EventHandler(this.button_read_float_Click);
            // 
            // button_read_ulong
            // 
            this.button_read_ulong.Location = new System.Drawing.Point(415, 124);
            this.button_read_ulong.Name = "button_read_ulong";
            this.button_read_ulong.Size = new System.Drawing.Size(82, 28);
            this.button_read_ulong.TabIndex = 13;
            this.button_read_ulong.Text = "ulong读取";
            this.button_read_ulong.UseVisualStyleBackColor = true;
            this.button_read_ulong.Click += new System.EventHandler(this.button_read_ulong_Click);
            // 
            // button_read_long
            // 
            this.button_read_long.Location = new System.Drawing.Point(315, 124);
            this.button_read_long.Name = "button_read_long";
            this.button_read_long.Size = new System.Drawing.Size(82, 28);
            this.button_read_long.TabIndex = 12;
            this.button_read_long.Text = "long读取";
            this.button_read_long.UseVisualStyleBackColor = true;
            this.button_read_long.Click += new System.EventHandler(this.button_read_long_Click);
            // 
            // button_read_uint
            // 
            this.button_read_uint.Location = new System.Drawing.Point(415, 90);
            this.button_read_uint.Name = "button_read_uint";
            this.button_read_uint.Size = new System.Drawing.Size(82, 28);
            this.button_read_uint.TabIndex = 11;
            this.button_read_uint.Text = "uint读取";
            this.button_read_uint.UseVisualStyleBackColor = true;
            this.button_read_uint.Click += new System.EventHandler(this.button_read_uint_Click);
            // 
            // button_read_int
            // 
            this.button_read_int.Location = new System.Drawing.Point(315, 90);
            this.button_read_int.Name = "button_read_int";
            this.button_read_int.Size = new System.Drawing.Size(82, 28);
            this.button_read_int.TabIndex = 10;
            this.button_read_int.Text = "int读取";
            this.button_read_int.UseVisualStyleBackColor = true;
            this.button_read_int.Click += new System.EventHandler(this.button_read_int_Click);
            // 
            // button_read_ushort
            // 
            this.button_read_ushort.Location = new System.Drawing.Point(415, 56);
            this.button_read_ushort.Name = "button_read_ushort";
            this.button_read_ushort.Size = new System.Drawing.Size(82, 28);
            this.button_read_ushort.TabIndex = 9;
            this.button_read_ushort.Text = "ushort读取";
            this.button_read_ushort.UseVisualStyleBackColor = true;
            this.button_read_ushort.Click += new System.EventHandler(this.button_read_ushort_Click);
            // 
            // button_read_short
            // 
            this.button_read_short.Location = new System.Drawing.Point(315, 56);
            this.button_read_short.Name = "button_read_short";
            this.button_read_short.Size = new System.Drawing.Size(82, 28);
            this.button_read_short.TabIndex = 8;
            this.button_read_short.Text = "short读取";
            this.button_read_short.UseVisualStyleBackColor = true;
            this.button_read_short.Click += new System.EventHandler(this.button_read_short_Click);
            // 
            // button_read_bool
            // 
            this.button_read_bool.Location = new System.Drawing.Point(315, 19);
            this.button_read_bool.Name = "button_read_bool";
            this.button_read_bool.Size = new System.Drawing.Size(82, 28);
            this.button_read_bool.TabIndex = 6;
            this.button_read_bool.Text = "位读取";
            this.button_read_bool.UseVisualStyleBackColor = true;
            this.button_read_bool.Click += new System.EventHandler(this.button_read_bool_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(63, 56);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(233, 164);
            this.textBox4.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "结果：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(63, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(233, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "M100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "地址：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "长度：";
            // 
            // userControlHead1
            // 
            this.userControlHead1.BackColor = System.Drawing.Color.MediumPurple;
            this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/10425797.html";
            this.userControlHead1.Location = new System.Drawing.Point(0, 0);
            this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
            this.userControlHead1.Name = "userControlHead1";
            this.userControlHead1.ProtocolInfo = "s7";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.TabIndex = 2;
            // 
            // FormS7Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.userControlHead1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormS7Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s7虚拟服务器【数据支持I，Q，M，DB块读写，DB块只有一个，无论是DB1.1还是DB100.1都是指同一个】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
            this.Load += new System.EventHandler(this.FormSiemens_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button_read_string;
        private System.Windows.Forms.Button button_read_double;
        private System.Windows.Forms.Button button_read_float;
        private System.Windows.Forms.Button button_read_ulong;
        private System.Windows.Forms.Button button_read_long;
        private System.Windows.Forms.Button button_read_uint;
        private System.Windows.Forms.Button button_read_int;
        private System.Windows.Forms.Button button_read_ushort;
        private System.Windows.Forms.Button button_read_short;
        private System.Windows.Forms.Button button_read_bool;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label11;
        private DemoControl.UserControlHead userControlHead1;
    }
}