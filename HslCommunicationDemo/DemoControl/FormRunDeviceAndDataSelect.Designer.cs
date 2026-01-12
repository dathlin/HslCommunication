namespace HslCommunicationDemo.DemoControl
{
	partial class FormRunDeviceAndDataSelect
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRunDeviceAndDataSelect));
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_address = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_dataType = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_length = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_name = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_image = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_form = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "当前的连接设备列表，选中需要设置的行";
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
			this.dataGridView1.Location = new System.Drawing.Point(5, 25);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(887, 323);
			this.dataGridView1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 357);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Address:";
			// 
			// textBox_address
			// 
			this.textBox_address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_address.Location = new System.Drawing.Point(264, 354);
			this.textBox_address.Name = "textBox_address";
			this.textBox_address.Size = new System.Drawing.Size(161, 23);
			this.textBox_address.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(352, 387);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(147, 40);
			this.button1.TabIndex = 4;
			this.button1.Text = "确认";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(445, 357);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "DataType:";
			// 
			// comboBox_dataType
			// 
			this.comboBox_dataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_dataType.FormattingEnabled = true;
			this.comboBox_dataType.Location = new System.Drawing.Point(532, 354);
			this.comboBox_dataType.Name = "comboBox_dataType";
			this.comboBox_dataType.Size = new System.Drawing.Size(95, 25);
			this.comboBox_dataType.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(636, 357);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Length:";
			// 
			// textBox_length
			// 
			this.textBox_length.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_length.Location = new System.Drawing.Point(692, 354);
			this.textBox_length.Name = "textBox_length";
			this.textBox_length.Size = new System.Drawing.Size(69, 23);
			this.textBox_length.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(768, 357);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "(输入大于0表示数组)";
			// 
			// textBox_name
			// 
			this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_name.Location = new System.Drawing.Point(71, 354);
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.Size = new System.Drawing.Size(105, 23);
			this.textBox_name.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 357);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 17);
			this.label6.TabIndex = 10;
			this.label6.Text = "Name:";
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
			// FormRunDeviceAndDataSelect
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(894, 446);
			this.Controls.Add(this.textBox_name);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox_length);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox_dataType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_address);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormRunDeviceAndDataSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RunDeviceSelect";
			this.Load += new System.EventHandler(this.FormRunDeviceSelect_Load);
			this.Shown += new System.EventHandler(this.FormRunDeviceSelect_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_address;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_dataType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_length;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_name;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
		private System.Windows.Forms.DataGridViewImageColumn Column_image;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_guid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_form;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_device;
	}
}