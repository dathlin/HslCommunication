namespace HslCommunicationDemo.DemoControl
{
	partial class PipeSelectControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent( )
		{
			this.panel_tcp = new System.Windows.Forms.Panel();
			this.textBox_tcp_receive = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel_tcp_more = new System.Windows.Forms.LinkLabel();
			this.textBox_tcp_connectTimeout = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_tcp_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_tcp_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel_serial = new System.Windows.Forms.Panel();
			this.comboBox_com_baudrate = new System.Windows.Forms.ComboBox();
			this.linkLabel_serial_more = new System.Windows.Forms.LinkLabel();
			this.comboBox_com_port = new System.Windows.Forms.ComboBox();
			this.comboBox_com_parity = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_com_stopbits = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_com_databits = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.panel_udp = new System.Windows.Forms.Panel();
			this.linkLabel_udp_more = new System.Windows.Forms.LinkLabel();
			this.textBox_udp_receiveTimeout = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_udp_port = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_udp_ip = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox_pipe_select = new System.Windows.Forms.ComboBox();
			this.panel_mqtt = new System.Windows.Forms.Panel();
			this.linkLabel_mqtt_more = new System.Windows.Forms.LinkLabel();
			this.textBox_mqtt_name = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_mqtt_port = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox_mqtt_ip = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label_info_pipe = new System.Windows.Forms.Label();
			this.panel_dtu = new System.Windows.Forms.Panel();
			this.linkLabel_dtu_message = new System.Windows.Forms.LinkLabel();
			this.textBox_dtu_pwd = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.checkBox_dtu_back = new System.Windows.Forms.CheckBox();
			this.textBox_dtu_id = new System.Windows.Forms.TextBox();
			this.textBox_dtu_port = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.linkLabel_dtu_state = new System.Windows.Forms.LinkLabel();
			this.panel_tcp.SuspendLayout();
			this.panel_serial.SuspendLayout();
			this.panel_udp.SuspendLayout();
			this.panel_mqtt.SuspendLayout();
			this.panel_dtu.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_tcp
			// 
			this.panel_tcp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_tcp.Controls.Add(this.textBox_tcp_receive);
			this.panel_tcp.Controls.Add(this.label4);
			this.panel_tcp.Controls.Add(this.linkLabel_tcp_more);
			this.panel_tcp.Controls.Add(this.textBox_tcp_connectTimeout);
			this.panel_tcp.Controls.Add(this.label2);
			this.panel_tcp.Controls.Add(this.textBox_tcp_port);
			this.panel_tcp.Controls.Add(this.label3);
			this.panel_tcp.Controls.Add(this.textBox_tcp_ip);
			this.panel_tcp.Controls.Add(this.label1);
			this.panel_tcp.Location = new System.Drawing.Point(0, 0);
			this.panel_tcp.Name = "panel_tcp";
			this.panel_tcp.Size = new System.Drawing.Size(679, 29);
			this.panel_tcp.TabIndex = 0;
			// 
			// textBox_tcp_receive
			// 
			this.textBox_tcp_receive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_tcp_receive.Location = new System.Drawing.Point(582, 2);
			this.textBox_tcp_receive.Name = "textBox_tcp_receive";
			this.textBox_tcp_receive.Size = new System.Drawing.Size(50, 23);
			this.textBox_tcp_receive.TabIndex = 47;
			this.textBox_tcp_receive.Text = "10000";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(509, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 17);
			this.label4.TabIndex = 46;
			this.label4.Text = "接收超时：";
			// 
			// linkLabel_tcp_more
			// 
			this.linkLabel_tcp_more.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_tcp_more.AutoSize = true;
			this.linkLabel_tcp_more.Location = new System.Drawing.Point(635, 6);
			this.linkLabel_tcp_more.Name = "linkLabel_tcp_more";
			this.linkLabel_tcp_more.Size = new System.Drawing.Size(39, 17);
			this.linkLabel_tcp_more.TabIndex = 45;
			this.linkLabel_tcp_more.TabStop = true;
			this.linkLabel_tcp_more.Text = "more";
			this.linkLabel_tcp_more.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_tcp_more_LinkClicked);
			// 
			// textBox_tcp_connectTimeout
			// 
			this.textBox_tcp_connectTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_tcp_connectTimeout.Location = new System.Drawing.Point(452, 2);
			this.textBox_tcp_connectTimeout.Name = "textBox_tcp_connectTimeout";
			this.textBox_tcp_connectTimeout.Size = new System.Drawing.Size(50, 23);
			this.textBox_tcp_connectTimeout.TabIndex = 9;
			this.textBox_tcp_connectTimeout.Text = "5000";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(379, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "连接超时：";
			// 
			// textBox_tcp_port
			// 
			this.textBox_tcp_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_tcp_port.Location = new System.Drawing.Point(325, 2);
			this.textBox_tcp_port.Name = "textBox_tcp_port";
			this.textBox_tcp_port.Size = new System.Drawing.Size(50, 23);
			this.textBox_tcp_port.TabIndex = 7;
			this.textBox_tcp_port.Text = "6000";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(261, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "端口号：";
			// 
			// textBox_tcp_ip
			// 
			this.textBox_tcp_ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_tcp_ip.Location = new System.Drawing.Point(59, 3);
			this.textBox_tcp_ip.Name = "textBox_tcp_ip";
			this.textBox_tcp_ip.Size = new System.Drawing.Size(196, 23);
			this.textBox_tcp_ip.TabIndex = 5;
			this.textBox_tcp_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Ip地址：";
			// 
			// panel_serial
			// 
			this.panel_serial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_serial.Controls.Add(this.comboBox_com_baudrate);
			this.panel_serial.Controls.Add(this.linkLabel_serial_more);
			this.panel_serial.Controls.Add(this.comboBox_com_port);
			this.panel_serial.Controls.Add(this.comboBox_com_parity);
			this.panel_serial.Controls.Add(this.label5);
			this.panel_serial.Controls.Add(this.textBox_com_stopbits);
			this.panel_serial.Controls.Add(this.label6);
			this.panel_serial.Controls.Add(this.textBox_com_databits);
			this.panel_serial.Controls.Add(this.label25);
			this.panel_serial.Controls.Add(this.label26);
			this.panel_serial.Controls.Add(this.label27);
			this.panel_serial.Location = new System.Drawing.Point(0, 72);
			this.panel_serial.Name = "panel_serial";
			this.panel_serial.Size = new System.Drawing.Size(679, 29);
			this.panel_serial.TabIndex = 1;
			// 
			// comboBox_com_baudrate
			// 
			this.comboBox_com_baudrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_com_baudrate.FormattingEnabled = true;
			this.comboBox_com_baudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
			this.comboBox_com_baudrate.Location = new System.Drawing.Point(253, 2);
			this.comboBox_com_baudrate.Name = "comboBox_com_baudrate";
			this.comboBox_com_baudrate.Size = new System.Drawing.Size(80, 25);
			this.comboBox_com_baudrate.TabIndex = 46;
			this.comboBox_com_baudrate.Text = "9600";
			// 
			// linkLabel_serial_more
			// 
			this.linkLabel_serial_more.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_serial_more.AutoSize = true;
			this.linkLabel_serial_more.Location = new System.Drawing.Point(635, 5);
			this.linkLabel_serial_more.Name = "linkLabel_serial_more";
			this.linkLabel_serial_more.Size = new System.Drawing.Size(39, 17);
			this.linkLabel_serial_more.TabIndex = 45;
			this.linkLabel_serial_more.TabStop = true;
			this.linkLabel_serial_more.Text = "more";
			this.linkLabel_serial_more.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_serial_more_LinkClicked);
			// 
			// comboBox_com_port
			// 
			this.comboBox_com_port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_com_port.FormattingEnabled = true;
			this.comboBox_com_port.Location = new System.Drawing.Point(60, 2);
			this.comboBox_com_port.Name = "comboBox_com_port";
			this.comboBox_com_port.Size = new System.Drawing.Size(119, 25);
			this.comboBox_com_port.TabIndex = 41;
			// 
			// comboBox_com_parity
			// 
			this.comboBox_com_parity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_com_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_com_parity.FormattingEnabled = true;
			this.comboBox_com_parity.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
			this.comboBox_com_parity.Location = new System.Drawing.Point(568, 2);
			this.comboBox_com_parity.Name = "comboBox_com_parity";
			this.comboBox_com_parity.Size = new System.Drawing.Size(63, 25);
			this.comboBox_com_parity.TabIndex = 40;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(521, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 39;
			this.label5.Text = "奇偶：";
			// 
			// textBox_com_stopbits
			// 
			this.textBox_com_stopbits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_com_stopbits.Location = new System.Drawing.Point(489, 3);
			this.textBox_com_stopbits.Name = "textBox_com_stopbits";
			this.textBox_com_stopbits.Size = new System.Drawing.Size(25, 23);
			this.textBox_com_stopbits.TabIndex = 38;
			this.textBox_com_stopbits.Text = "1";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(433, 6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 17);
			this.label6.TabIndex = 37;
			this.label6.Text = "停止位：";
			// 
			// textBox_com_databits
			// 
			this.textBox_com_databits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_com_databits.Location = new System.Drawing.Point(402, 3);
			this.textBox_com_databits.Name = "textBox_com_databits";
			this.textBox_com_databits.Size = new System.Drawing.Size(24, 23);
			this.textBox_com_databits.TabIndex = 36;
			this.textBox_com_databits.Text = "8";
			// 
			// label25
			// 
			this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(342, 6);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 17);
			this.label25.TabIndex = 35;
			this.label25.Text = "数据位：";
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(186, 6);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 17);
			this.label26.TabIndex = 33;
			this.label26.Text = "波特率：";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(3, 6);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(59, 17);
			this.label27.TabIndex = 32;
			this.label27.Text = "Com口：";
			// 
			// panel_udp
			// 
			this.panel_udp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_udp.Controls.Add(this.linkLabel_udp_more);
			this.panel_udp.Controls.Add(this.textBox_udp_receiveTimeout);
			this.panel_udp.Controls.Add(this.label7);
			this.panel_udp.Controls.Add(this.textBox_udp_port);
			this.panel_udp.Controls.Add(this.label9);
			this.panel_udp.Controls.Add(this.textBox_udp_ip);
			this.panel_udp.Controls.Add(this.label10);
			this.panel_udp.Location = new System.Drawing.Point(0, 36);
			this.panel_udp.Name = "panel_udp";
			this.panel_udp.Size = new System.Drawing.Size(679, 29);
			this.panel_udp.TabIndex = 2;
			// 
			// linkLabel_udp_more
			// 
			this.linkLabel_udp_more.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_udp_more.AutoSize = true;
			this.linkLabel_udp_more.Location = new System.Drawing.Point(635, 5);
			this.linkLabel_udp_more.Name = "linkLabel_udp_more";
			this.linkLabel_udp_more.Size = new System.Drawing.Size(39, 17);
			this.linkLabel_udp_more.TabIndex = 44;
			this.linkLabel_udp_more.TabStop = true;
			this.linkLabel_udp_more.Text = "more";
			this.linkLabel_udp_more.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_udp_more_LinkClicked);
			// 
			// textBox_udp_receiveTimeout
			// 
			this.textBox_udp_receiveTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_udp_receiveTimeout.Location = new System.Drawing.Point(582, 2);
			this.textBox_udp_receiveTimeout.Name = "textBox_udp_receiveTimeout";
			this.textBox_udp_receiveTimeout.Size = new System.Drawing.Size(50, 23);
			this.textBox_udp_receiveTimeout.TabIndex = 11;
			this.textBox_udp_receiveTimeout.Text = "10000";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(509, 6);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 17);
			this.label7.TabIndex = 10;
			this.label7.Text = "接收超时：";
			// 
			// textBox_udp_port
			// 
			this.textBox_udp_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_udp_port.Location = new System.Drawing.Point(455, 2);
			this.textBox_udp_port.Name = "textBox_udp_port";
			this.textBox_udp_port.Size = new System.Drawing.Size(50, 23);
			this.textBox_udp_port.TabIndex = 7;
			this.textBox_udp_port.Text = "6000";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(391, 6);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = "端口号：";
			// 
			// textBox_udp_ip
			// 
			this.textBox_udp_ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_udp_ip.Location = new System.Drawing.Point(59, 3);
			this.textBox_udp_ip.Name = "textBox_udp_ip";
			this.textBox_udp_ip.Size = new System.Drawing.Size(326, 23);
			this.textBox_udp_ip.TabIndex = 5;
			this.textBox_udp_ip.Text = "127.0.0.1";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 5);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 17);
			this.label10.TabIndex = 4;
			this.label10.Text = "Ip地址：";
			// 
			// comboBox_pipe_select
			// 
			this.comboBox_pipe_select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_pipe_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_pipe_select.FormattingEnabled = true;
			this.comboBox_pipe_select.Location = new System.Drawing.Point(715, 2);
			this.comboBox_pipe_select.Name = "comboBox_pipe_select";
			this.comboBox_pipe_select.Size = new System.Drawing.Size(73, 25);
			this.comboBox_pipe_select.TabIndex = 3;
			// 
			// panel_mqtt
			// 
			this.panel_mqtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_mqtt.Controls.Add(this.linkLabel_mqtt_more);
			this.panel_mqtt.Controls.Add(this.textBox_mqtt_name);
			this.panel_mqtt.Controls.Add(this.label12);
			this.panel_mqtt.Controls.Add(this.textBox_mqtt_port);
			this.panel_mqtt.Controls.Add(this.label14);
			this.panel_mqtt.Controls.Add(this.textBox_mqtt_ip);
			this.panel_mqtt.Controls.Add(this.label15);
			this.panel_mqtt.Location = new System.Drawing.Point(0, 109);
			this.panel_mqtt.Name = "panel_mqtt";
			this.panel_mqtt.Size = new System.Drawing.Size(679, 29);
			this.panel_mqtt.TabIndex = 4;
			// 
			// linkLabel_mqtt_more
			// 
			this.linkLabel_mqtt_more.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_mqtt_more.AutoSize = true;
			this.linkLabel_mqtt_more.Location = new System.Drawing.Point(635, 6);
			this.linkLabel_mqtt_more.Name = "linkLabel_mqtt_more";
			this.linkLabel_mqtt_more.Size = new System.Drawing.Size(39, 17);
			this.linkLabel_mqtt_more.TabIndex = 44;
			this.linkLabel_mqtt_more.TabStop = true;
			this.linkLabel_mqtt_more.Text = "more";
			this.linkLabel_mqtt_more.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_mqtt_more_LinkClicked);
			// 
			// textBox_mqtt_name
			// 
			this.textBox_mqtt_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_mqtt_name.Location = new System.Drawing.Point(515, 3);
			this.textBox_mqtt_name.Name = "textBox_mqtt_name";
			this.textBox_mqtt_name.Size = new System.Drawing.Size(117, 23);
			this.textBox_mqtt_name.TabIndex = 9;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(454, 6);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 17);
			this.label12.TabIndex = 8;
			this.label12.Text = "用户名：";
			// 
			// textBox_mqtt_port
			// 
			this.textBox_mqtt_port.Location = new System.Drawing.Point(370, 2);
			this.textBox_mqtt_port.Name = "textBox_mqtt_port";
			this.textBox_mqtt_port.Size = new System.Drawing.Size(76, 23);
			this.textBox_mqtt_port.TabIndex = 7;
			this.textBox_mqtt_port.Text = "1883";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(306, 6);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 17);
			this.label14.TabIndex = 6;
			this.label14.Text = "端口号：";
			// 
			// textBox_mqtt_ip
			// 
			this.textBox_mqtt_ip.Location = new System.Drawing.Point(59, 3);
			this.textBox_mqtt_ip.Name = "textBox_mqtt_ip";
			this.textBox_mqtt_ip.Size = new System.Drawing.Size(246, 23);
			this.textBox_mqtt_ip.TabIndex = 5;
			this.textBox_mqtt_ip.Text = "127.0.0.1";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(3, 5);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 17);
			this.label15.TabIndex = 4;
			this.label15.Text = "Ip地址：";
			// 
			// label_info_pipe
			// 
			this.label_info_pipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_info_pipe.AutoSize = true;
			this.label_info_pipe.ForeColor = System.Drawing.Color.MediumOrchid;
			this.label_info_pipe.Location = new System.Drawing.Point(679, 6);
			this.label_info_pipe.Name = "label_info_pipe";
			this.label_info_pipe.Size = new System.Drawing.Size(32, 17);
			this.label_info_pipe.TabIndex = 7;
			this.label_info_pipe.Text = "管道";
			// 
			// panel_dtu
			// 
			this.panel_dtu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_dtu.Controls.Add(this.linkLabel_dtu_message);
			this.panel_dtu.Controls.Add(this.textBox_dtu_pwd);
			this.panel_dtu.Controls.Add(this.label13);
			this.panel_dtu.Controls.Add(this.checkBox_dtu_back);
			this.panel_dtu.Controls.Add(this.textBox_dtu_id);
			this.panel_dtu.Controls.Add(this.textBox_dtu_port);
			this.panel_dtu.Controls.Add(this.label11);
			this.panel_dtu.Controls.Add(this.label8);
			this.panel_dtu.Controls.Add(this.linkLabel_dtu_state);
			this.panel_dtu.Location = new System.Drawing.Point(0, 145);
			this.panel_dtu.Name = "panel_dtu";
			this.panel_dtu.Size = new System.Drawing.Size(679, 29);
			this.panel_dtu.TabIndex = 8;
			// 
			// linkLabel_dtu_message
			// 
			this.linkLabel_dtu_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_dtu_message.AutoSize = true;
			this.linkLabel_dtu_message.Location = new System.Drawing.Point(632, 6);
			this.linkLabel_dtu_message.Name = "linkLabel_dtu_message";
			this.linkLabel_dtu_message.Size = new System.Drawing.Size(44, 17);
			this.linkLabel_dtu_message.TabIndex = 49;
			this.linkLabel_dtu_message.TabStop = true;
			this.linkLabel_dtu_message.Text = "注册包";
			this.linkLabel_dtu_message.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_dtu_message_LinkClicked);
			// 
			// textBox_dtu_pwd
			// 
			this.textBox_dtu_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_dtu_pwd.Location = new System.Drawing.Point(427, 3);
			this.textBox_dtu_pwd.Name = "textBox_dtu_pwd";
			this.textBox_dtu_pwd.Size = new System.Drawing.Size(71, 23);
			this.textBox_dtu_pwd.TabIndex = 47;
			this.textBox_dtu_pwd.Text = "123456";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(381, 6);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 48;
			this.label13.Text = "密码：";
			// 
			// checkBox_dtu_back
			// 
			this.checkBox_dtu_back.AutoSize = true;
			this.checkBox_dtu_back.Checked = true;
			this.checkBox_dtu_back.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_dtu_back.Location = new System.Drawing.Point(128, 5);
			this.checkBox_dtu_back.Name = "checkBox_dtu_back";
			this.checkBox_dtu_back.Size = new System.Drawing.Size(99, 21);
			this.checkBox_dtu_back.TabIndex = 45;
			this.checkBox_dtu_back.Text = "返回注册结果";
			this.checkBox_dtu_back.UseVisualStyleBackColor = true;
			// 
			// textBox_dtu_id
			// 
			this.textBox_dtu_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_dtu_id.Location = new System.Drawing.Point(262, 3);
			this.textBox_dtu_id.Name = "textBox_dtu_id";
			this.textBox_dtu_id.Size = new System.Drawing.Size(106, 23);
			this.textBox_dtu_id.TabIndex = 9;
			this.textBox_dtu_id.Text = "12345678901";
			// 
			// textBox_dtu_port
			// 
			this.textBox_dtu_port.Location = new System.Drawing.Point(58, 3);
			this.textBox_dtu_port.Name = "textBox_dtu_port";
			this.textBox_dtu_port.Size = new System.Drawing.Size(65, 23);
			this.textBox_dtu_port.TabIndex = 7;
			this.textBox_dtu_port.Text = "10000";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(2, 7);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 17);
			this.label11.TabIndex = 6;
			this.label11.Text = "端口号：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(233, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 17);
			this.label8.TabIndex = 46;
			this.label8.Text = "ID:";
			// 
			// linkLabel_dtu_state
			// 
			this.linkLabel_dtu_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_dtu_state.LinkColor = System.Drawing.Color.Gray;
			this.linkLabel_dtu_state.Location = new System.Drawing.Point(499, 6);
			this.linkLabel_dtu_state.Name = "linkLabel_dtu_state";
			this.linkLabel_dtu_state.Size = new System.Drawing.Size(131, 17);
			this.linkLabel_dtu_state.TabIndex = 44;
			this.linkLabel_dtu_state.TabStop = true;
			this.linkLabel_dtu_state.Text = "Stopped";
			this.linkLabel_dtu_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PipeSelectControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.label_info_pipe);
			this.Controls.Add(this.panel_dtu);
			this.Controls.Add(this.panel_mqtt);
			this.Controls.Add(this.comboBox_pipe_select);
			this.Controls.Add(this.panel_udp);
			this.Controls.Add(this.panel_serial);
			this.Controls.Add(this.panel_tcp);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "PipeSelectControl";
			this.Size = new System.Drawing.Size(790, 192);
			this.Load += new System.EventHandler(this.PipeSelectControl_Load);
			this.panel_tcp.ResumeLayout(false);
			this.panel_tcp.PerformLayout();
			this.panel_serial.ResumeLayout(false);
			this.panel_serial.PerformLayout();
			this.panel_udp.ResumeLayout(false);
			this.panel_udp.PerformLayout();
			this.panel_mqtt.ResumeLayout(false);
			this.panel_mqtt.PerformLayout();
			this.panel_dtu.ResumeLayout(false);
			this.panel_dtu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel_tcp;
		private System.Windows.Forms.TextBox textBox_tcp_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_tcp_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_tcp_connectTimeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel_serial;
		private System.Windows.Forms.ComboBox comboBox_com_port;
		private System.Windows.Forms.ComboBox comboBox_com_parity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_com_stopbits;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_com_databits;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Panel panel_udp;
		private System.Windows.Forms.TextBox textBox_udp_receiveTimeout;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_udp_port;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_udp_ip;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox_pipe_select;
		private System.Windows.Forms.Panel panel_mqtt;
		private System.Windows.Forms.TextBox textBox_mqtt_port;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox_mqtt_ip;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox_mqtt_name;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.LinkLabel linkLabel_mqtt_more;
		private System.Windows.Forms.LinkLabel linkLabel_udp_more;
		private System.Windows.Forms.LinkLabel linkLabel_tcp_more;
		private System.Windows.Forms.TextBox textBox_tcp_receive;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label_info_pipe;
		private System.Windows.Forms.ComboBox comboBox_com_baudrate;
		private System.Windows.Forms.LinkLabel linkLabel_serial_more;
		private System.Windows.Forms.Panel panel_dtu;
		private System.Windows.Forms.LinkLabel linkLabel_dtu_state;
		private System.Windows.Forms.TextBox textBox_dtu_id;
		private System.Windows.Forms.TextBox textBox_dtu_port;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_dtu_pwd;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox checkBox_dtu_back;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.LinkLabel linkLabel_dtu_message;
	}
}
