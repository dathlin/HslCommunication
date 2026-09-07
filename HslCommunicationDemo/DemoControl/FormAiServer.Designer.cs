namespace HslCommunicationDemo.DemoControl
{
	partial class FormAiServer
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAiServer));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_url = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_image = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_form = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "AI Server:";
			// 
			// textBox_url
			// 
			this.textBox_url.Location = new System.Drawing.Point(92, 9);
			this.textBox_url.Name = "textBox_url";
			this.textBox_url.Size = new System.Drawing.Size(596, 23);
			this.textBox_url.TabIndex = 1;
			this.textBox_url.Text = "http://127.0.0.1:8731/";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(704, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 29);
			this.button1.TabIndex = 2;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(814, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 29);
			this.button2.TabIndex = 3;
			this.button2.Text = "Stop";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Regist Devices:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_id,
            this.Column_image,
            this.Column_guid,
            this.Column_form,
            this.Column_device});
			this.dataGridView1.Location = new System.Drawing.Point(15, 67);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(1006, 179);
			this.dataGridView1.TabIndex = 5;
			// 
			// Column_id
			// 
			this.Column_id.HeaderText = "Id";
			this.Column_id.Name = "Column_id";
			this.Column_id.ReadOnly = true;
			this.Column_id.Width = 80;
			// 
			// Column_image
			// 
			this.Column_image.HeaderText = "";
			this.Column_image.Name = "Column_image";
			this.Column_image.ReadOnly = true;
			this.Column_image.Width = 24;
			// 
			// Column_guid
			// 
			this.Column_guid.HeaderText = "Guid";
			this.Column_guid.Name = "Column_guid";
			this.Column_guid.ReadOnly = true;
			this.Column_guid.Width = 240;
			// 
			// Column_form
			// 
			this.Column_form.HeaderText = "Form";
			this.Column_form.Name = "Column_form";
			this.Column_form.ReadOnly = true;
			this.Column_form.Width = 180;
			// 
			// Column_device
			// 
			this.Column_device.HeaderText = "Device";
			this.Column_device.Name = "Column_device";
			this.Column_device.ReadOnly = true;
			this.Column_device.Width = 330;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 252);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Http Log:";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(15, 274);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(1006, 314);
			this.textBox2.TabIndex = 7;
			// 
			// FormAiServer
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1033, 600);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_url);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormAiServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormAiServer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAiServer_FormClosing);
			this.Load += new System.EventHandler(this.FormAiServer_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_url;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
		private System.Windows.Forms.DataGridViewImageColumn Column_image;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_guid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_form;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_device;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
	}
}