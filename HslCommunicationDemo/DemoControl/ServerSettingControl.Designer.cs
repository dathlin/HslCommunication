namespace HslCommunicationDemo.DemoControl
{
	partial class ServerSettingControl
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
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_tcp_udp = new System.Windows.Forms.ComboBox();
			this.comboBox_ipv4 = new System.Windows.Forms.ComboBox();
			this.textBox_local_ip = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button_close = new System.Windows.Forms.Button();
			this.button_start_sertial = new System.Windows.Forms.Button();
			this.textBox_serialPort = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.button_start = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(60, 2);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(56, 23);
			this.textBox_port.TabIndex = 5;
			this.textBox_port.Text = "502";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "端口号：";
			// 
			// comboBox_tcp_udp
			// 
			this.comboBox_tcp_udp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_tcp_udp.FormattingEnabled = true;
			this.comboBox_tcp_udp.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "Both"});
			this.comboBox_tcp_udp.Location = new System.Drawing.Point(121, 1);
			this.comboBox_tcp_udp.Name = "comboBox_tcp_udp";
			this.comboBox_tcp_udp.Size = new System.Drawing.Size(60, 25);
			this.comboBox_tcp_udp.TabIndex = 6;
			// 
			// comboBox_ipv4
			// 
			this.comboBox_ipv4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_ipv4.FormattingEnabled = true;
			this.comboBox_ipv4.Items.AddRange(new object[] {
            "IPv4",
            "IPv6"});
			this.comboBox_ipv4.Location = new System.Drawing.Point(187, 1);
			this.comboBox_ipv4.Name = "comboBox_ipv4";
			this.comboBox_ipv4.Size = new System.Drawing.Size(60, 25);
			this.comboBox_ipv4.TabIndex = 7;
			// 
			// textBox_local_ip
			// 
			this.textBox_local_ip.Location = new System.Drawing.Point(310, 2);
			this.textBox_local_ip.Name = "textBox_local_ip";
			this.textBox_local_ip.Size = new System.Drawing.Size(112, 23);
			this.textBox_local_ip.TabIndex = 48;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(253, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 17);
			this.label4.TabIndex = 47;
			this.label4.Text = "本地ip：";
			// 
			// button_close
			// 
			this.button_close.Enabled = false;
			this.button_close.Location = new System.Drawing.Point(518, 0);
			this.button_close.Name = "button_close";
			this.button_close.Size = new System.Drawing.Size(83, 28);
			this.button_close.TabIndex = 53;
			this.button_close.Text = "关闭服务";
			this.button_close.UseVisualStyleBackColor = true;
			this.button_close.Click += new System.EventHandler(this.button_close_Click);
			// 
			// button_start_sertial
			// 
			this.button_start_sertial.Location = new System.Drawing.Point(807, 0);
			this.button_start_sertial.Name = "button_start_sertial";
			this.button_start_sertial.Size = new System.Drawing.Size(91, 28);
			this.button_start_sertial.TabIndex = 52;
			this.button_start_sertial.Text = "启动串口";
			this.button_start_sertial.UseVisualStyleBackColor = true;
			this.button_start_sertial.Click += new System.EventHandler(this.button_start_sertial_Click);
			// 
			// textBox_serialPort
			// 
			this.textBox_serialPort.Location = new System.Drawing.Point(660, 3);
			this.textBox_serialPort.Name = "textBox_serialPort";
			this.textBox_serialPort.Size = new System.Drawing.Size(144, 23);
			this.textBox_serialPort.TabIndex = 51;
			this.textBox_serialPort.Text = "COM4-9600-8-N-1";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(606, 6);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 17);
			this.label14.TabIndex = 50;
			this.label14.Text = "串口：";
			// 
			// button_start
			// 
			this.button_start.Location = new System.Drawing.Point(428, 0);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(83, 28);
			this.button_start.TabIndex = 49;
			this.button_start.Text = "启动服务";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.button_start_Click);
			// 
			// ServerSettingControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.button_close);
			this.Controls.Add(this.button_start_sertial);
			this.Controls.Add(this.textBox_serialPort);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.button_start);
			this.Controls.Add(this.textBox_local_ip);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox_ipv4);
			this.Controls.Add(this.comboBox_tcp_udp);
			this.Controls.Add(this.textBox_port);
			this.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "ServerSettingControl";
			this.Size = new System.Drawing.Size(904, 30);
			this.Load += new System.EventHandler(this.ServerSettingControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_tcp_udp;
		private System.Windows.Forms.ComboBox comboBox_ipv4;
		private System.Windows.Forms.TextBox textBox_local_ip;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button_close;
		private System.Windows.Forms.Button button_start_sertial;
		private System.Windows.Forms.TextBox textBox_serialPort;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button_start;
	}
}
