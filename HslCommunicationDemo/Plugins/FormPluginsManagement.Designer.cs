namespace HslCommunicationDemo.Plugins
{
    partial class FormPluginsManagement
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
			this.pluginsListControl1 = new HslCommunicationDemo.Plugins.PluginsListControl();
			this.label1 = new System.Windows.Forms.Label();
			this.pluginsDetailsControl1 = new HslCommunicationDemo.Plugins.PluginsDetailsControl();
			this.textBox_search = new System.Windows.Forms.TextBox();
			this.button_search = new System.Windows.Forms.Button();
			this.button_install = new System.Windows.Forms.Button();
			this.linkLabel_refresh = new System.Windows.Forms.LinkLabel();
			this.hslButton1 = new HslControls.HslButton();
			this.label2 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pluginsListControl1
			// 
			this.pluginsListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pluginsListControl1.AutoScroll = true;
			this.pluginsListControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pluginsListControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pluginsListControl1.Location = new System.Drawing.Point(3, 32);
			this.pluginsListControl1.Name = "pluginsListControl1";
			this.pluginsListControl1.Size = new System.Drawing.Size(517, 456);
			this.pluginsListControl1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LightGreen;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Location = new System.Drawing.Point(67, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "已安装";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// pluginsDetailsControl1
			// 
			this.pluginsDetailsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pluginsDetailsControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pluginsDetailsControl1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pluginsDetailsControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pluginsDetailsControl1.Location = new System.Drawing.Point(3, 33);
			this.pluginsDetailsControl1.Name = "pluginsDetailsControl1";
			this.pluginsDetailsControl1.Size = new System.Drawing.Size(275, 455);
			this.pluginsDetailsControl1.TabIndex = 2;
			// 
			// textBox_search
			// 
			this.textBox_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_search.Location = new System.Drawing.Point(3, 3);
			this.textBox_search.Name = "textBox_search";
			this.textBox_search.Size = new System.Drawing.Size(443, 23);
			this.textBox_search.TabIndex = 3;
			// 
			// button_search
			// 
			this.button_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_search.Location = new System.Drawing.Point(452, 2);
			this.button_search.Name = "button_search";
			this.button_search.Size = new System.Drawing.Size(68, 25);
			this.button_search.TabIndex = 4;
			this.button_search.Text = "搜索";
			this.button_search.UseVisualStyleBackColor = true;
			// 
			// button_install
			// 
			this.button_install.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_install.Location = new System.Drawing.Point(3, 3);
			this.button_install.Name = "button_install";
			this.button_install.Size = new System.Drawing.Size(275, 25);
			this.button_install.TabIndex = 5;
			this.button_install.Text = "从本地安装/更新插件";
			this.button_install.UseVisualStyleBackColor = true;
			// 
			// linkLabel_refresh
			// 
			this.linkLabel_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_refresh.AutoSize = true;
			this.linkLabel_refresh.Location = new System.Drawing.Point(768, 38);
			this.linkLabel_refresh.Name = "linkLabel_refresh";
			this.linkLabel_refresh.Size = new System.Drawing.Size(32, 17);
			this.linkLabel_refresh.TabIndex = 6;
			this.linkLabel_refresh.TabStop = true;
			this.linkLabel_refresh.Text = "刷新";
			// 
			// hslButton1
			// 
			this.hslButton1.CornerRadius = 10;
			this.hslButton1.CustomerInformation = null;
			this.hslButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.hslButton1.Location = new System.Drawing.Point(1, 1);
			this.hslButton1.Name = "hslButton1";
			this.hslButton1.OriginalColor = System.Drawing.Color.Honeydew;
			this.hslButton1.Size = new System.Drawing.Size(110, 31);
			this.hslButton1.TabIndex = 7;
			this.hslButton1.Text = "设备插件";
			// 
			// label2
			// 
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label2.ForeColor = System.Drawing.Color.DarkGray;
			this.label2.Location = new System.Drawing.Point(10, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "浏览";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(1, 58);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Size = new System.Drawing.Size(805, 491);
			this.splitContainer1.SplitterDistance = 520;
			this.splitContainer1.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox_search);
			this.panel1.Controls.Add(this.pluginsListControl1);
			this.panel1.Controls.Add(this.button_search);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 491);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button_install);
			this.panel2.Controls.Add(this.pluginsDetailsControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(281, 491);
			this.panel2.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(559, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "服务器:";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(612, 6);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(163, 25);
			this.comboBox1.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Image = global::HslCommunicationDemo.Properties.Resources.settings;
			this.label4.Location = new System.Drawing.Point(781, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 18);
			this.label4.TabIndex = 14;
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// FormPluginsManagement
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(805, 551);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.hslButton1);
			this.Controls.Add(this.linkLabel_refresh);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.KeyPreview = true;
			this.Name = "FormPluginsManagement";
			this.Text = "Plugins-";
			this.Load += new System.EventHandler(this.FormPluginsManagement_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private PluginsListControl pluginsListControl1;
        private System.Windows.Forms.Label label1;
        private PluginsDetailsControl pluginsDetailsControl1;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_install;
        private System.Windows.Forms.LinkLabel linkLabel_refresh;
        private HslControls.HslButton hslButton1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
	}
}