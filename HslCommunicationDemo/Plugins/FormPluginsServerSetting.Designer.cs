namespace HslCommunicationDemo.Plugins
{
	partial class FormPluginsServerSetting
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
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_port = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.Location = new System.Drawing.Point(213, 269);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(238, 57);
			this.button1.TabIndex = 0;
			this.button1.Text = "保存";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_ip,
            this.Column_port});
			this.dataGridView1.Location = new System.Drawing.Point(7, 30);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(659, 224);
			this.dataGridView1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "远程服务器列表:";
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "名称";
			this.Column_name.Name = "Column_name";
			this.Column_name.Width = 200;
			// 
			// Column_ip
			// 
			this.Column_ip.HeaderText = "域名或Ip地址";
			this.Column_ip.Name = "Column_ip";
			this.Column_ip.Width = 300;
			// 
			// Column_port
			// 
			this.Column_port.HeaderText = "端口号";
			this.Column_port.Name = "Column_port";
			// 
			// FormPluginsServerSetting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(673, 341);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPluginsServerSetting";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormPluginsServerSetting";
			this.Load += new System.EventHandler(this.FormPluginsServerSetting_Load);
			this.Shown += new System.EventHandler(this.FormPluginsServerSetting_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_ip;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_port;
	}
}