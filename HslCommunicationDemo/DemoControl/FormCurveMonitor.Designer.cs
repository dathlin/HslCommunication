namespace HslCommunicationDemo.DemoControl
{
	partial class FormCurveMonitor
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
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button_read_double = new System.Windows.Forms.Button();
			this.button_read_float = new System.Windows.Forms.Button();
			this.button_read_ulong = new System.Windows.Forms.Button();
			this.button_read_long = new System.Windows.Forms.Button();
			this.button_read_uint = new System.Windows.Forms.Button();
			this.button_read_int = new System.Windows.Forms.Button();
			this.button_read_ushort = new System.Windows.Forms.Button();
			this.button_read_short = new System.Windows.Forms.Button();
			this.button_read_bool = new System.Windows.Forms.Button();
			this.hslCurve1 = new HslControls.HslCurve();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(66, 11);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(185, 23);
			this.textBox3.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "地址：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(379, 11);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(102, 23);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "1000";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(286, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "时间间隔(ms)";
			// 
			// button_read_double
			// 
			this.button_read_double.Location = new System.Drawing.Point(804, 49);
			this.button_read_double.Name = "button_read_double";
			this.button_read_double.Size = new System.Drawing.Size(82, 28);
			this.button_read_double.TabIndex = 25;
			this.button_read_double.Text = "double读取";
			this.button_read_double.UseVisualStyleBackColor = true;
			this.button_read_double.Click += new System.EventHandler(this.button_read_double_Click);
			// 
			// button_read_float
			// 
			this.button_read_float.Location = new System.Drawing.Point(716, 49);
			this.button_read_float.Name = "button_read_float";
			this.button_read_float.Size = new System.Drawing.Size(82, 28);
			this.button_read_float.TabIndex = 24;
			this.button_read_float.Text = "float读取";
			this.button_read_float.UseVisualStyleBackColor = true;
			this.button_read_float.Click += new System.EventHandler(this.button_read_float_Click);
			// 
			// button_read_ulong
			// 
			this.button_read_ulong.Location = new System.Drawing.Point(628, 49);
			this.button_read_ulong.Name = "button_read_ulong";
			this.button_read_ulong.Size = new System.Drawing.Size(82, 28);
			this.button_read_ulong.TabIndex = 23;
			this.button_read_ulong.Text = "ulong读取";
			this.button_read_ulong.UseVisualStyleBackColor = true;
			this.button_read_ulong.Click += new System.EventHandler(this.button_read_ulong_Click);
			// 
			// button_read_long
			// 
			this.button_read_long.Location = new System.Drawing.Point(540, 49);
			this.button_read_long.Name = "button_read_long";
			this.button_read_long.Size = new System.Drawing.Size(82, 28);
			this.button_read_long.TabIndex = 22;
			this.button_read_long.Text = "long读取";
			this.button_read_long.UseVisualStyleBackColor = true;
			this.button_read_long.Click += new System.EventHandler(this.button_read_long_Click);
			// 
			// button_read_uint
			// 
			this.button_read_uint.Location = new System.Drawing.Point(452, 49);
			this.button_read_uint.Name = "button_read_uint";
			this.button_read_uint.Size = new System.Drawing.Size(82, 28);
			this.button_read_uint.TabIndex = 21;
			this.button_read_uint.Text = "uint读取";
			this.button_read_uint.UseVisualStyleBackColor = true;
			this.button_read_uint.Click += new System.EventHandler(this.button_read_uint_Click);
			// 
			// button_read_int
			// 
			this.button_read_int.Location = new System.Drawing.Point(364, 49);
			this.button_read_int.Name = "button_read_int";
			this.button_read_int.Size = new System.Drawing.Size(82, 28);
			this.button_read_int.TabIndex = 20;
			this.button_read_int.Text = "int读取";
			this.button_read_int.UseVisualStyleBackColor = true;
			this.button_read_int.Click += new System.EventHandler(this.button_read_int_Click);
			// 
			// button_read_ushort
			// 
			this.button_read_ushort.Location = new System.Drawing.Point(276, 49);
			this.button_read_ushort.Name = "button_read_ushort";
			this.button_read_ushort.Size = new System.Drawing.Size(82, 28);
			this.button_read_ushort.TabIndex = 19;
			this.button_read_ushort.Text = "ushort读取";
			this.button_read_ushort.UseVisualStyleBackColor = true;
			this.button_read_ushort.Click += new System.EventHandler(this.button_read_ushort_Click);
			// 
			// button_read_short
			// 
			this.button_read_short.Location = new System.Drawing.Point(188, 49);
			this.button_read_short.Name = "button_read_short";
			this.button_read_short.Size = new System.Drawing.Size(82, 28);
			this.button_read_short.TabIndex = 18;
			this.button_read_short.Text = "short读取";
			this.button_read_short.UseVisualStyleBackColor = true;
			this.button_read_short.Click += new System.EventHandler(this.button_read_short_Click);
			// 
			// button_read_bool
			// 
			this.button_read_bool.Location = new System.Drawing.Point(12, 49);
			this.button_read_bool.Name = "button_read_bool";
			this.button_read_bool.Size = new System.Drawing.Size(82, 28);
			this.button_read_bool.TabIndex = 16;
			this.button_read_bool.Text = "bool读取";
			this.button_read_bool.UseVisualStyleBackColor = true;
			this.button_read_bool.Click += new System.EventHandler(this.button_read_bool_Click);
			// 
			// hslCurve1
			// 
			this.hslCurve1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslCurve1.BackColor = System.Drawing.Color.White;
			this.hslCurve1.Location = new System.Drawing.Point(12, 83);
			this.hslCurve1.Name = "hslCurve1";
			this.hslCurve1.Size = new System.Drawing.Size(673, 453);
			this.hslCurve1.TabIndex = 26;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.BackColor = System.Drawing.Color.White;
			this.propertyGrid1.Location = new System.Drawing.Point(707, 84);
			this.propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(185, 452);
			this.propertyGrid1.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 543);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(460, 17);
			this.label2.TabIndex = 28;
			this.label2.Text = "更高级的数据分析，诊断，曲线分析，诊断，请访问下面的优秀产品：PLC-Recorder";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(490, 543);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(120, 17);
			this.linkLabel1.TabIndex = 29;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.hiddenmap.cn";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(657, 543);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 17);
			this.label3.TabIndex = 30;
			this.label3.Text = "QQ群：877456127";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(804, 15);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(82, 28);
			this.button1.TabIndex = 31;
			this.button1.Text = "取消";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormCurveMonitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 570);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.hslCurve1);
			this.Controls.Add(this.button_read_double);
			this.Controls.Add(this.button_read_float);
			this.Controls.Add(this.button_read_ulong);
			this.Controls.Add(this.button_read_long);
			this.Controls.Add(this.button_read_uint);
			this.Controls.Add(this.button_read_int);
			this.Controls.Add(this.button_read_ushort);
			this.Controls.Add(this.button_read_short);
			this.Controls.Add(this.button_read_bool);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label6);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimizeBox = false;
			this.Name = "FormCurveMonitor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "曲线的实时监控";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCurveMonitor_FormClosing);
			this.Load += new System.EventHandler(this.FormCurveMonitor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_read_double;
		private System.Windows.Forms.Button button_read_float;
		private System.Windows.Forms.Button button_read_ulong;
		private System.Windows.Forms.Button button_read_long;
		private System.Windows.Forms.Button button_read_uint;
		private System.Windows.Forms.Button button_read_int;
		private System.Windows.Forms.Button button_read_ushort;
		private System.Windows.Forms.Button button_read_short;
		private System.Windows.Forms.Button button_read_bool;
		private HslControls.HslCurve hslCurve1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}