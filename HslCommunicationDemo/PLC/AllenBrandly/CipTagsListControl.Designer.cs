namespace HslCommunicationDemo.PLC.AllenBrandly
{
	partial class CipTagsListControl
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_id,
            this.Column_name,
            this.Column_type,
            this.Column_value});
			this.dataGridView1.Location = new System.Drawing.Point(3, 28);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(860, 252);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "虚拟服务器的内部变量:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(768, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 27);
			this.button1.TabIndex = 2;
			this.button1.Text = "Show Tags";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Column_id
			// 
			this.Column_id.HeaderText = "Id";
			this.Column_id.Name = "Column_id";
			this.Column_id.ReadOnly = true;
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "Name";
			this.Column_name.Name = "Column_name";
			this.Column_name.ReadOnly = true;
			this.Column_name.Width = 200;
			// 
			// Column_type
			// 
			this.Column_type.HeaderText = "Type";
			this.Column_type.Name = "Column_type";
			this.Column_type.ReadOnly = true;
			this.Column_type.Width = 150;
			// 
			// Column_value
			// 
			this.Column_value.HeaderText = "Buffer";
			this.Column_value.Name = "Column_value";
			this.Column_value.ReadOnly = true;
			this.Column_value.Width = 350;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(647, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(103, 21);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Show Buffer?";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// CipTagsListControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "CipTagsListControl";
			this.Size = new System.Drawing.Size(866, 283);
			this.Load += new System.EventHandler(this.CipTagsListControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_value;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
