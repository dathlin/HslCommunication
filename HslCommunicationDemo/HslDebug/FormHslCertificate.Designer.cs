namespace HslCommunicationDemo
{
	partial class FormHslCertificate
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent( )
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_verify = new System.Windows.Forms.Button();
			this.button_load = new System.Windows.Forms.Button();
			this.button_create = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox_hours = new System.Windows.Forms.TextBox();
			this.label_hours = new System.Windows.Forms.Label();
			this.textBox_createDate = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_Descriptions = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_Unique = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_KeyWord = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_NotAfter = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_NotBefore = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_To = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_From = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.textBox_pri_key = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_pub_key = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button_verify);
			this.panel1.Controls.Add(this.button_load);
			this.panel1.Controls.Add(this.button_create);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 608);
			this.panel1.TabIndex = 37;
			// 
			// button_verify
			// 
			this.button_verify.Location = new System.Drawing.Point(616, 565);
			this.button_verify.Name = "button_verify";
			this.button_verify.Size = new System.Drawing.Size(180, 39);
			this.button_verify.TabIndex = 4;
			this.button_verify.Text = "验证证书";
			this.button_verify.UseVisualStyleBackColor = true;
			this.button_verify.Click += new System.EventHandler(this.button_verify_Click);
			// 
			// button_load
			// 
			this.button_load.Location = new System.Drawing.Point(418, 565);
			this.button_load.Name = "button_load";
			this.button_load.Size = new System.Drawing.Size(180, 39);
			this.button_load.TabIndex = 3;
			this.button_load.Text = "加载证书";
			this.button_load.UseVisualStyleBackColor = true;
			this.button_load.Click += new System.EventHandler(this.button_load_Click);
			// 
			// button_create
			// 
			this.button_create.Location = new System.Drawing.Point(218, 565);
			this.button_create.Name = "button_create";
			this.button_create.Size = new System.Drawing.Size(180, 39);
			this.button_create.TabIndex = 2;
			this.button_create.Text = "创建证书";
			this.button_create.UseVisualStyleBackColor = true;
			this.button_create.Click += new System.EventHandler(this.button_create_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.textBox_hours);
			this.groupBox2.Controls.Add(this.label_hours);
			this.groupBox2.Controls.Add(this.textBox_createDate);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.textBox_Descriptions);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.textBox_Unique);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.textBox_KeyWord);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.textBox_NotAfter);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox_NotBefore);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox_To);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textBox_From);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(3, 304);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(988, 258);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "证书信息";
			// 
			// textBox_hours
			// 
			this.textBox_hours.Location = new System.Drawing.Point(316, 195);
			this.textBox_hours.Name = "textBox_hours";
			this.textBox_hours.Size = new System.Drawing.Size(115, 23);
			this.textBox_hours.TabIndex = 18;
			this.textBox_hours.Text = "0";
			// 
			// label_hours
			// 
			this.label_hours.AutoSize = true;
			this.label_hours.Location = new System.Drawing.Point(223, 198);
			this.label_hours.Name = "label_hours";
			this.label_hours.Size = new System.Drawing.Size(59, 17);
			this.label_hours.TabIndex = 17;
			this.label_hours.Text = "有效小时:";
			// 
			// textBox_createDate
			// 
			this.textBox_createDate.Location = new System.Drawing.Point(93, 195);
			this.textBox_createDate.Name = "textBox_createDate";
			this.textBox_createDate.Size = new System.Drawing.Size(115, 23);
			this.textBox_createDate.TabIndex = 16;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(11, 198);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 17);
			this.label11.TabIndex = 15;
			this.label11.Text = "发证日期:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(913, 21);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(69, 25);
			this.button1.TabIndex = 14;
			this.button1.Text = "Random";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_Descriptions
			// 
			this.textBox_Descriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Descriptions.Location = new System.Drawing.Point(453, 90);
			this.textBox_Descriptions.Multiline = true;
			this.textBox_Descriptions.Name = "textBox_Descriptions";
			this.textBox_Descriptions.Size = new System.Drawing.Size(529, 158);
			this.textBox_Descriptions.TabIndex = 13;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(450, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(227, 17);
			this.label10.TabIndex = 12;
			this.label10.Text = "额外信息(键值对+换行符): 例如： A:你好";
			// 
			// textBox_Unique
			// 
			this.textBox_Unique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Unique.Location = new System.Drawing.Point(532, 23);
			this.textBox_Unique.Name = "textBox_Unique";
			this.textBox_Unique.Size = new System.Drawing.Size(374, 23);
			this.textBox_Unique.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(450, 26);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 17);
			this.label9.TabIndex = 10;
			this.label9.Text = "唯一编号:";
			// 
			// textBox_KeyWord
			// 
			this.textBox_KeyWord.Location = new System.Drawing.Point(93, 225);
			this.textBox_KeyWord.Name = "textBox_KeyWord";
			this.textBox_KeyWord.Size = new System.Drawing.Size(338, 23);
			this.textBox_KeyWord.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(11, 228);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 17);
			this.label8.TabIndex = 8;
			this.label8.Text = "关键字:";
			// 
			// textBox_NotAfter
			// 
			this.textBox_NotAfter.Location = new System.Drawing.Point(93, 163);
			this.textBox_NotAfter.Name = "textBox_NotAfter";
			this.textBox_NotAfter.Size = new System.Drawing.Size(338, 23);
			this.textBox_NotAfter.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 166);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 17);
			this.label7.TabIndex = 6;
			this.label7.Text = "结束日期:";
			// 
			// textBox_NotBefore
			// 
			this.textBox_NotBefore.Location = new System.Drawing.Point(93, 132);
			this.textBox_NotBefore.Name = "textBox_NotBefore";
			this.textBox_NotBefore.Size = new System.Drawing.Size(338, 23);
			this.textBox_NotBefore.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "开始日期:";
			// 
			// textBox_To
			// 
			this.textBox_To.Location = new System.Drawing.Point(93, 76);
			this.textBox_To.Multiline = true;
			this.textBox_To.Name = "textBox_To";
			this.textBox_To.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_To.Size = new System.Drawing.Size(338, 50);
			this.textBox_To.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 79);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "持有者:";
			// 
			// textBox_From
			// 
			this.textBox_From.Location = new System.Drawing.Point(93, 20);
			this.textBox_From.Multiline = true;
			this.textBox_From.Name = "textBox_From";
			this.textBox_From.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_From.Size = new System.Drawing.Size(338, 50);
			this.textBox_From.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "发证人:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.textBox_pri_key);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox_pub_key);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(988, 303);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "公钥及私钥";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.radioButton1);
			this.panel2.Controls.Add(this.radioButton2);
			this.panel2.Location = new System.Drawing.Point(71, 21);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(232, 23);
			this.panel2.TabIndex = 53;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 28;
			this.label3.Text = "数据类型：";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(98, 2);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(50, 21);
			this.radioButton1.TabIndex = 15;
			this.radioButton1.Text = "HEX";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(162, 2);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(60, 21);
			this.radioButton2.TabIndex = 16;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "String";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// textBox_pri_key
			// 
			this.textBox_pri_key.AllowDrop = true;
			this.textBox_pri_key.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_pri_key.Location = new System.Drawing.Point(339, 46);
			this.textBox_pri_key.Multiline = true;
			this.textBox_pri_key.Name = "textBox_pri_key";
			this.textBox_pri_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_pri_key.Size = new System.Drawing.Size(646, 249);
			this.textBox_pri_key.TabIndex = 52;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(339, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 51;
			this.label4.Text = "私钥：";
			// 
			// textBox_pub_key
			// 
			this.textBox_pub_key.AllowDrop = true;
			this.textBox_pub_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox_pub_key.Location = new System.Drawing.Point(6, 46);
			this.textBox_pub_key.Multiline = true;
			this.textBox_pub_key.Name = "textBox_pub_key";
			this.textBox_pub_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_pub_key.Size = new System.Drawing.Size(327, 249);
			this.textBox_pub_key.TabIndex = 50;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 49;
			this.label2.Text = "公钥：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/15227913.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "RSA 证书";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 38;
			// 
			// FormHslCertificate
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel1);
			this.Name = "FormHslCertificate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Certificate Test";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button_verify;
		private System.Windows.Forms.Button button_load;
		private System.Windows.Forms.Button button_create;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox_From;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.TextBox textBox_pri_key;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_pub_key;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_NotBefore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_To;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_Unique;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_KeyWord;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox_NotAfter;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_Descriptions;
		private System.Windows.Forms.Label label10;
		private HslCommunicationDemo.DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_hours;
		private System.Windows.Forms.Label label_hours;
		private System.Windows.Forms.TextBox textBox_createDate;
		private System.Windows.Forms.Label label11;
	}
}

