namespace HslCommunicationDemo.Plugins
{ 
	partial class FormPluginsInstall
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
			this.label1 = new System.Windows.Forms.Label();
			this.button_selectfile = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button_upload = new System.Windows.Forms.Button();
			this.label_progress = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.hslProgressBar1 = new HslControls.HslProgressBar();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "选择文件列表：";
			// 
			// button_selectfile
			// 
			this.button_selectfile.Location = new System.Drawing.Point(110, 8);
			this.button_selectfile.Name = "button_selectfile";
			this.button_selectfile.Size = new System.Drawing.Size(121, 25);
			this.button_selectfile.TabIndex = 1;
			this.button_selectfile.Text = "选择文件";
			this.button_selectfile.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(17, 40);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(698, 198);
			this.textBox1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "插件名称：";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(86, 253);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(629, 23);
			this.textBox2.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 291);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "安装进度：";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(86, 287);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(588, 23);
			this.progressBar1.TabIndex = 6;
			// 
			// button_upload
			// 
			this.button_upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_upload.Location = new System.Drawing.Point(281, 326);
			this.button_upload.Name = "button_upload";
			this.button_upload.Size = new System.Drawing.Size(169, 47);
			this.button_upload.TabIndex = 7;
			this.button_upload.Text = "上传";
			this.button_upload.UseVisualStyleBackColor = true;
			// 
			// label_progress
			// 
			this.label_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_progress.AutoSize = true;
			this.label_progress.Location = new System.Drawing.Point(680, 291);
			this.label_progress.Name = "label_progress";
			this.label_progress.Size = new System.Drawing.Size(35, 17);
			this.label_progress.TabIndex = 8;
			this.label_progress.Text = "(0/0)";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(12, 386);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(630, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "注意：需要根据服务器的运行环境来安装指定环境的插件，通常是.Net Framework4.6.1及以上或是.net standard2.1";
			// 
			// hslProgressBar1
			// 
			this.hslProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslProgressBar1.CustmerTextTranslate = null;
			this.hslProgressBar1.Location = new System.Drawing.Point(110, 8);
			this.hslProgressBar1.Name = "hslProgressBar1";
			this.hslProgressBar1.ProgressStyle = HslControls.ProgressStyle.Percent;
			this.hslProgressBar1.Size = new System.Drawing.Size(605, 23);
			this.hslProgressBar1.TabIndex = 10;
			// 
			// FormPluginsInstall
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(727, 410);
			this.Controls.Add(this.hslProgressBar1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label_progress);
			this.Controls.Add(this.button_upload);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button_selectfile);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPluginsInstall";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "安装/更新 插件信息";
			this.Load += new System.EventHandler(this.FormPluginsInstall_Load);
			this.Shown += new System.EventHandler(this.FormPluginsInstall_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_selectfile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label4;
		private HslControls.HslProgressBar hslProgressBar1;
	}
}