namespace HslCommunicationDemo.Plugins
{
    partial class PluginsDetailsControl
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
			this.label_name = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_install_version = new System.Windows.Forms.TextBox();
			this.button_unload = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_desc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label_author = new System.Windows.Forms.Label();
			this.label_version = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label_date = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.linkLabel_url = new System.Windows.Forms.LinkLabel();
			this.label_framework = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label_files = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_name
			// 
			this.label_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_name.AutoEllipsis = true;
			this.label_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_name.Location = new System.Drawing.Point(4, 4);
			this.label_name.Name = "label_name";
			this.label_name.Size = new System.Drawing.Size(269, 23);
			this.label_name.TabIndex = 0;
			this.label_name.Text = "[插件名称]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "已安装";
			// 
			// textBox_install_version
			// 
			this.textBox_install_version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_install_version.Location = new System.Drawing.Point(54, 26);
			this.textBox_install_version.Name = "textBox_install_version";
			this.textBox_install_version.ReadOnly = true;
			this.textBox_install_version.Size = new System.Drawing.Size(156, 23);
			this.textBox_install_version.TabIndex = 2;
			// 
			// button_unload
			// 
			this.button_unload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_unload.Location = new System.Drawing.Point(215, 24);
			this.button_unload.Name = "button_unload";
			this.button_unload.Size = new System.Drawing.Size(57, 27);
			this.button_unload.TabIndex = 3;
			this.button_unload.Text = "卸载";
			this.button_unload.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "描述";
			// 
			// textBox_desc
			// 
			this.textBox_desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_desc.Location = new System.Drawing.Point(7, 77);
			this.textBox_desc.Multiline = true;
			this.textBox_desc.Name = "textBox_desc";
			this.textBox_desc.ReadOnly = true;
			this.textBox_desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_desc.Size = new System.Drawing.Size(265, 199);
			this.textBox_desc.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 280);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "作者";
			// 
			// label_author
			// 
			this.label_author.AutoSize = true;
			this.label_author.Location = new System.Drawing.Point(55, 280);
			this.label_author.Name = "label_author";
			this.label_author.Size = new System.Drawing.Size(40, 17);
			this.label_author.TabIndex = 7;
			this.label_author.Text = "[作者]";
			// 
			// label_version
			// 
			this.label_version.AutoSize = true;
			this.label_version.Location = new System.Drawing.Point(55, 300);
			this.label_version.Name = "label_version";
			this.label_version.Size = new System.Drawing.Size(40, 17);
			this.label_version.TabIndex = 9;
			this.label_version.Text = "[版本]";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 300);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "版本";
			// 
			// label_date
			// 
			this.label_date.AutoSize = true;
			this.label_date.Location = new System.Drawing.Point(55, 321);
			this.label_date.Name = "label_date";
			this.label_date.Size = new System.Drawing.Size(40, 17);
			this.label_date.TabIndex = 11;
			this.label_date.Text = "[日期]";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 321);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 17);
			this.label7.TabIndex = 10;
			this.label7.Text = "日期";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 342);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 17);
			this.label8.TabIndex = 12;
			this.label8.Text = "网址";
			// 
			// linkLabel_url
			// 
			this.linkLabel_url.AutoSize = true;
			this.linkLabel_url.Location = new System.Drawing.Point(55, 342);
			this.linkLabel_url.Name = "linkLabel_url";
			this.linkLabel_url.Size = new System.Drawing.Size(40, 17);
			this.linkLabel_url.TabIndex = 13;
			this.linkLabel_url.TabStop = true;
			this.linkLabel_url.Text = "[网址]";
			// 
			// label_framework
			// 
			this.label_framework.AutoSize = true;
			this.label_framework.Location = new System.Drawing.Point(55, 364);
			this.label_framework.Name = "label_framework";
			this.label_framework.Size = new System.Drawing.Size(40, 17);
			this.label_framework.TabIndex = 15;
			this.label_framework.Text = "[框架]";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 364);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "框架";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.label_files);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 384);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(273, 89);
			this.panel1.TabIndex = 16;
			// 
			// label_files
			// 
			this.label_files.AutoSize = true;
			this.label_files.Location = new System.Drawing.Point(52, 2);
			this.label_files.Name = "label_files";
			this.label_files.Size = new System.Drawing.Size(40, 17);
			this.label_files.TabIndex = 16;
			this.label_files.Text = "[文件]";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 15;
			this.label1.Text = "文件";
			// 
			// PluginsDetailsControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label_framework);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.linkLabel_url);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label_date);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label_version);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label_author);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_desc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button_unload);
			this.Controls.Add(this.textBox_install_version);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label_name);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "PluginsDetailsControl";
			this.Size = new System.Drawing.Size(276, 473);
			this.Load += new System.EventHandler(this.PluginsDetailsControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_install_version;
        private System.Windows.Forms.Button button_unload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel_url;
        private System.Windows.Forms.Label label_framework;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label_files;
	}
}
