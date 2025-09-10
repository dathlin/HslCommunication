namespace HslCommunicationDemo.Vip
{
	partial class HslCertificateControl
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
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button_create = new System.Windows.Forms.Button();
			this.textBox_hours = new System.Windows.Forms.TextBox();
			this.label_hours = new System.Windows.Forms.Label();
			this.textBox_createDate = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
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
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButton_java = new System.Windows.Forms.RadioButton();
			this.radioButton_dotnet = new System.Windows.Forms.RadioButton();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.Color.Gray;
			this.label14.Location = new System.Drawing.Point(430, 252);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(281, 17);
			this.label14.TabIndex = 49;
			this.label14.Text = "(一般为空，当需要绑定电脑运行时设置电脑唯一ID)";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.Color.Gray;
			this.label13.Location = new System.Drawing.Point(430, 145);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(210, 17);
			this.label13.TabIndex = 48;
			this.label13.Text = "(在此时间内允许激活，不能超过10年)";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.Gray;
			this.label12.Location = new System.Drawing.Point(430, 192);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(239, 17);
			this.label12.TabIndex = 47;
			this.label12.Text = "(激活后连续运行的小时数，小于0表示无限)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 17);
			this.label3.TabIndex = 45;
			this.label3.Text = "语言:";
			// 
			// button_create
			// 
			this.button_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_create.Location = new System.Drawing.Point(256, 420);
			this.button_create.Name = "button_create";
			this.button_create.Size = new System.Drawing.Size(180, 39);
			this.button_create.TabIndex = 44;
			this.button_create.Text = "创建证书";
			this.button_create.UseVisualStyleBackColor = true;
			this.button_create.Click += new System.EventHandler(this.button_create_Click);
			// 
			// textBox_hours
			// 
			this.textBox_hours.Location = new System.Drawing.Point(309, 189);
			this.textBox_hours.Name = "textBox_hours";
			this.textBox_hours.Size = new System.Drawing.Size(115, 23);
			this.textBox_hours.TabIndex = 43;
			this.textBox_hours.Text = "-1";
			// 
			// label_hours
			// 
			this.label_hours.AutoSize = true;
			this.label_hours.Location = new System.Drawing.Point(216, 192);
			this.label_hours.Name = "label_hours";
			this.label_hours.Size = new System.Drawing.Size(59, 17);
			this.label_hours.TabIndex = 42;
			this.label_hours.Text = "有效小时:";
			// 
			// textBox_createDate
			// 
			this.textBox_createDate.Location = new System.Drawing.Point(86, 189);
			this.textBox_createDate.Name = "textBox_createDate";
			this.textBox_createDate.ReadOnly = true;
			this.textBox_createDate.Size = new System.Drawing.Size(115, 23);
			this.textBox_createDate.TabIndex = 41;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(4, 192);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 17);
			this.label11.TabIndex = 40;
			this.label11.Text = "发证日期:";
			// 
			// textBox_Descriptions
			// 
			this.textBox_Descriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Descriptions.Location = new System.Drawing.Point(7, 301);
			this.textBox_Descriptions.Multiline = true;
			this.textBox_Descriptions.Name = "textBox_Descriptions";
			this.textBox_Descriptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Descriptions.Size = new System.Drawing.Size(714, 110);
			this.textBox_Descriptions.TabIndex = 39;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(4, 275);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(227, 17);
			this.label10.TabIndex = 38;
			this.label10.Text = "额外信息(键值对+换行符): 例如： A:你好";
			// 
			// textBox_Unique
			// 
			this.textBox_Unique.Location = new System.Drawing.Point(86, 249);
			this.textBox_Unique.Name = "textBox_Unique";
			this.textBox_Unique.Size = new System.Drawing.Size(337, 23);
			this.textBox_Unique.TabIndex = 37;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(4, 252);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 17);
			this.label9.TabIndex = 36;
			this.label9.Text = "唯一编号:";
			// 
			// textBox_KeyWord
			// 
			this.textBox_KeyWord.Location = new System.Drawing.Point(86, 219);
			this.textBox_KeyWord.Name = "textBox_KeyWord";
			this.textBox_KeyWord.ReadOnly = true;
			this.textBox_KeyWord.Size = new System.Drawing.Size(338, 23);
			this.textBox_KeyWord.TabIndex = 35;
			this.textBox_KeyWord.Text = "HslCommunication";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 222);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 17);
			this.label8.TabIndex = 34;
			this.label8.Text = "关键字:";
			// 
			// textBox_NotAfter
			// 
			this.textBox_NotAfter.Location = new System.Drawing.Point(86, 157);
			this.textBox_NotAfter.Name = "textBox_NotAfter";
			this.textBox_NotAfter.Size = new System.Drawing.Size(338, 23);
			this.textBox_NotAfter.TabIndex = 33;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 160);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 17);
			this.label7.TabIndex = 32;
			this.label7.Text = "结束日期:";
			// 
			// textBox_NotBefore
			// 
			this.textBox_NotBefore.Location = new System.Drawing.Point(86, 126);
			this.textBox_NotBefore.Name = "textBox_NotBefore";
			this.textBox_NotBefore.Size = new System.Drawing.Size(338, 23);
			this.textBox_NotBefore.TabIndex = 31;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 17);
			this.label6.TabIndex = 30;
			this.label6.Text = "开始日期:";
			// 
			// textBox_To
			// 
			this.textBox_To.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_To.Location = new System.Drawing.Point(86, 79);
			this.textBox_To.Multiline = true;
			this.textBox_To.Name = "textBox_To";
			this.textBox_To.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_To.Size = new System.Drawing.Size(635, 42);
			this.textBox_To.TabIndex = 29;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 17);
			this.label5.TabIndex = 28;
			this.label5.Text = "持有者:";
			// 
			// textBox_From
			// 
			this.textBox_From.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_From.Location = new System.Drawing.Point(86, 37);
			this.textBox_From.Multiline = true;
			this.textBox_From.Name = "textBox_From";
			this.textBox_From.ReadOnly = true;
			this.textBox_From.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_From.Size = new System.Drawing.Size(635, 36);
			this.textBox_From.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 17);
			this.label2.TabIndex = 26;
			this.label2.Text = "发证人:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButton_java);
			this.panel1.Controls.Add(this.radioButton_dotnet);
			this.panel1.Location = new System.Drawing.Point(85, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(321, 36);
			this.panel1.TabIndex = 50;
			// 
			// radioButton_java
			// 
			this.radioButton_java.AutoSize = true;
			this.radioButton_java.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.radioButton_java.Location = new System.Drawing.Point(162, 2);
			this.radioButton_java.Name = "radioButton_java";
			this.radioButton_java.Size = new System.Drawing.Size(71, 31);
			this.radioButton_java.TabIndex = 1;
			this.radioButton_java.Text = "Java";
			this.radioButton_java.UseVisualStyleBackColor = true;
			// 
			// radioButton_dotnet
			// 
			this.radioButton_dotnet.AutoSize = true;
			this.radioButton_dotnet.Checked = true;
			this.radioButton_dotnet.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.radioButton_dotnet.Location = new System.Drawing.Point(5, 2);
			this.radioButton_dotnet.Name = "radioButton_dotnet";
			this.radioButton_dotnet.Size = new System.Drawing.Size(139, 31);
			this.radioButton_dotnet.TabIndex = 0;
			this.radioButton_dotnet.TabStop = true;
			this.radioButton_dotnet.Text = "DotNet(C#)";
			this.radioButton_dotnet.UseVisualStyleBackColor = true;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.Location = new System.Drawing.Point(618, 416);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(109, 26);
			this.linkLabel1.TabIndex = 51;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "编辑模式";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
			// 
			// HslCertificateControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button_create);
			this.Controls.Add(this.textBox_hours);
			this.Controls.Add(this.label_hours);
			this.Controls.Add(this.textBox_createDate);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox_Descriptions);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox_Unique);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox_KeyWord);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox_NotAfter);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_NotBefore);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox_To);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox_From);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HslCertificateControl";
			this.Size = new System.Drawing.Size(730, 468);
			this.Load += new System.EventHandler(this.HslCertificateControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button_create;
		private System.Windows.Forms.TextBox textBox_hours;
		private System.Windows.Forms.Label label_hours;
		private System.Windows.Forms.TextBox textBox_createDate;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_Descriptions;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox_Unique;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_KeyWord;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox_NotAfter;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_NotBefore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_To;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_From;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButton_java;
		private System.Windows.Forms.RadioButton radioButton_dotnet;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
