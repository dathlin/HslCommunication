namespace HslCommunicationDemo.PLC.AllenBrandly
{
	partial class AllenBrandlyTagTypeCacheControl
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Decs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_id,
            this.Column_TagName,
            this.Column_TypeCode,
            this.Column_Decs});
			this.dataGridView1.Location = new System.Drawing.Point(3, 27);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(819, 232);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column_id
			// 
			this.Column_id.HeaderText = "Id";
			this.Column_id.Name = "Column_id";
			this.Column_id.ReadOnly = true;
			// 
			// Column_TagName
			// 
			this.Column_TagName.HeaderText = "TagName";
			this.Column_TagName.Name = "Column_TagName";
			this.Column_TagName.ReadOnly = true;
			this.Column_TagName.Width = 300;
			// 
			// Column_TypeCode
			// 
			this.Column_TypeCode.HeaderText = "DataBits";
			this.Column_TypeCode.Name = "Column_TypeCode";
			this.Column_TypeCode.ReadOnly = true;
			this.Column_TypeCode.Width = 150;
			// 
			// Column_Decs
			// 
			this.Column_Decs.HeaderText = "Decscription";
			this.Column_Decs.Name = "Column_Decs";
			this.Column_Decs.ReadOnly = true;
			this.Column_Decs.Width = 200;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(448, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "地址使用 i=xxx[2] 写入bool值时，缓存的标签名称，以及关联的数据字节长度信息";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(746, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 2;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// AllenBrandlyTagTypeCacheControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "AllenBrandlyTagTypeCacheControl";
			this.Size = new System.Drawing.Size(825, 262);
			this.Load += new System.EventHandler(this.AllenBrandlyTagTypeCacheControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_TagName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_TypeCode;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Decs;
	}
}
