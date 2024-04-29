namespace HslCommunicationDemo.Algorithms
{
    partial class FourierTransform
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
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.userButton1 = new HslControls.HslButton();
			this.userCurve5  = new HslControls.HslCurve();
			this.userCurve6  = new HslControls.HslCurve();
			this.userCurve3  = new HslControls.HslCurve();
			this.userCurve4  = new HslControls.HslCurve();
			this.userCurve2  = new HslControls.HslCurve();
			this.userCurve1  = new HslControls.HslCurve();
			this.userButton2 = new HslControls.HslButton();
			this.userButton3 = new HslControls.HslButton();
			this.userButton4 = new HslControls.HslButton( );
			this.textBox_curve3 = new System.Windows.Forms.TextBox();
			this.textBox_curve2 = new System.Windows.Forms.TextBox();
			this.userButton5 = new HslControls.HslButton( );
			this.textBox_curve1 = new System.Windows.Forms.TextBox();
			this.userButton6 = new HslControls.HslButton( );
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(404, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 17);
			this.label5.TabIndex = 10;
			this.label5.Text = "FFT 快速离散傅立叶变换";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 17);
			this.label1.TabIndex = 14;
			this.label1.Text = "方波及变换后的波形";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 17);
			this.label3.TabIndex = 17;
			this.label3.Text = "正弦波及变换后的波形";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 445);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 17);
			this.label6.TabIndex = 20;
			this.label6.Text = "混合波及变换后的波形";
			// 
			// userButton1
			// 
			this.userButton1.BackColor = System.Drawing.Color.Transparent;
			this.userButton1.CustomerInformation = "";
			this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton1.Location = new System.Drawing.Point(918, 25);
			this.userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton1.Name = "userButton1";
			this.userButton1.Size = new System.Drawing.Size(78, 25);
			this.userButton1.TabIndex = 21;
			this.userButton1.Text = "专用图形";
			this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
			// 
			// userCurve5
			// 
			this.userCurve5.BackColor = System.Drawing.Color.Transparent;
			this.userCurve5.IsAbscissaStrech = true;
			this.userCurve5.Location = new System.Drawing.Point(510, 459);
			this.userCurve5.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
			this.userCurve5.Name = "userCurve5";
			this.userCurve5.Size = new System.Drawing.Size(463, 190);
			this.userCurve5.StrechDataCountMax = 256;
			this.userCurve5.TabIndex = 19;
			// 
			// userCurve6
			// 
			this.userCurve6.BackColor = System.Drawing.Color.Transparent;
			this.userCurve6.IsAbscissaStrech = true;
			this.userCurve6.Location = new System.Drawing.Point(24, 459);
			this.userCurve6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			this.userCurve6.Name = "userCurve6";
			this.userCurve6.Size = new System.Drawing.Size(463, 190);
			this.userCurve6.StrechDataCountMax = 256;
			this.userCurve6.TabIndex = 18;
			this.userCurve6.ReferenceAxisLeft.Max = 10F;
			this.userCurve6.ReferenceAxisRight.Max = 10F;
			this.userCurve6.ReferenceAxisLeft.Min = -10F;
			this.userCurve6.ReferenceAxisRight.Min = -10F;
			// 
			// userCurve3
			// 
			this.userCurve3.BackColor = System.Drawing.Color.Transparent;
			this.userCurve3.IsAbscissaStrech = true;
			this.userCurve3.Location = new System.Drawing.Point(510, 255);
			this.userCurve3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			this.userCurve3.Name = "userCurve3";
			this.userCurve3.Size = new System.Drawing.Size(463, 190);
			this.userCurve3.StrechDataCountMax = 256;
			this.userCurve3.TabIndex = 16;
			// 
			// userCurve4
			// 
			this.userCurve4.BackColor = System.Drawing.Color.Transparent;
			this.userCurve4.IsAbscissaStrech = true;
			this.userCurve4.Location = new System.Drawing.Point(24, 255);
			this.userCurve4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.userCurve4.Name = "userCurve4";
			this.userCurve4.Size = new System.Drawing.Size(463, 190);
			this.userCurve4.StrechDataCountMax = 256;
			this.userCurve4.TabIndex = 15;
			this.userCurve4.ReferenceAxisLeft.Max = 12F;
			this.userCurve4.ReferenceAxisRight.Max = 12F;
			this.userCurve4.ReferenceAxisLeft.Min = -3F;
			this.userCurve4.ReferenceAxisRight.Min = -3F;
			// 
			// userCurve2
			// 
			this.userCurve2.BackColor = System.Drawing.Color.Transparent;
			this.userCurve2.IsAbscissaStrech = true;
			this.userCurve2.Location = new System.Drawing.Point(510, 43);
			this.userCurve2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.userCurve2.Name = "userCurve2";
			this.userCurve2.Size = new System.Drawing.Size(463, 190);
			this.userCurve2.StrechDataCountMax = 256;
			this.userCurve2.TabIndex = 13;
			// 
			// userCurve1
			// 
			this.userCurve1.BackColor = System.Drawing.Color.Transparent;
			this.userCurve1.IsAbscissaStrech = true;
			this.userCurve1.Location = new System.Drawing.Point(24, 43);
			this.userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userCurve1.Name = "userCurve1";
			this.userCurve1.Size = new System.Drawing.Size(463, 190);
			this.userCurve1.StrechDataCountMax = 256;
			this.userCurve1.TabIndex = 12;
			this.userCurve1.ReferenceAxisLeft.Max = 10F;
			this.userCurve1.ReferenceAxisRight.Max = 10F;
			// 
			// userButton2
			// 
			this.userButton2.BackColor = System.Drawing.Color.Transparent;
			this.userButton2.CustomerInformation = "";
			this.userButton2.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton2.Location = new System.Drawing.Point(918, 236);
			this.userButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton2.Name = "userButton2";
			this.userButton2.Size = new System.Drawing.Size(78, 25);
			this.userButton2.TabIndex = 22;
			this.userButton2.Text = "专用图形";
			this.userButton2.Click += new System.EventHandler(this.userButton2_Click);
			// 
			// userButton3
			// 
			this.userButton3.BackColor = System.Drawing.Color.Transparent;
			this.userButton3.CustomerInformation = "";
			this.userButton3.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton3.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton3.Location = new System.Drawing.Point(918, 437);
			this.userButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton3.Name = "userButton3";
			this.userButton3.Size = new System.Drawing.Size(78, 25);
			this.userButton3.TabIndex = 23;
			this.userButton3.Text = "专用图形";
			this.userButton3.Click += new System.EventHandler(this.userButton3_Click);
			// 
			// userButton4
			// 
			this.userButton4.BackColor = System.Drawing.Color.Transparent;
			this.userButton4.CustomerInformation = "";
			this.userButton4.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton4.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton4.Location = new System.Drawing.Point(823, 437);
			this.userButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton4.Name = "userButton4";
			this.userButton4.Size = new System.Drawing.Size(78, 25);
			this.userButton4.TabIndex = 24;
			this.userButton4.Text = "逆变操作";
			this.userButton4.Click += new System.EventHandler(this.userButton4_Click);
			// 
			// textBox_curve3
			// 
			this.textBox_curve3.Location = new System.Drawing.Point(717, 439);
			this.textBox_curve3.Name = "textBox_curve3";
			this.textBox_curve3.Size = new System.Drawing.Size(100, 23);
			this.textBox_curve3.TabIndex = 25;
			this.textBox_curve3.Text = "0";
			// 
			// textBox_curve2
			// 
			this.textBox_curve2.Location = new System.Drawing.Point(717, 238);
			this.textBox_curve2.Name = "textBox_curve2";
			this.textBox_curve2.Size = new System.Drawing.Size(100, 23);
			this.textBox_curve2.TabIndex = 27;
			this.textBox_curve2.Text = "0";
			// 
			// userButton5
			// 
			this.userButton5.BackColor = System.Drawing.Color.Transparent;
			this.userButton5.CustomerInformation = "";
			this.userButton5.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton5.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton5.Location = new System.Drawing.Point(823, 236);
			this.userButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton5.Name = "userButton5";
			this.userButton5.Size = new System.Drawing.Size(78, 25);
			this.userButton5.TabIndex = 26;
			this.userButton5.Text = "逆变操作";
			this.userButton5.Click += new System.EventHandler(this.userButton5_Click);
			// 
			// textBox_curve1
			// 
			this.textBox_curve1.Location = new System.Drawing.Point(717, 27);
			this.textBox_curve1.Name = "textBox_curve1";
			this.textBox_curve1.Size = new System.Drawing.Size(100, 23);
			this.textBox_curve1.TabIndex = 29;
			this.textBox_curve1.Text = "0";
			// 
			// userButton6
			// 
			this.userButton6.BackColor = System.Drawing.Color.Transparent;
			this.userButton6.CustomerInformation = "";
			this.userButton6.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.userButton6.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.userButton6.Location = new System.Drawing.Point(823, 25);
			this.userButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userButton6.Name = "userButton6";
			this.userButton6.Size = new System.Drawing.Size(78, 25);
			this.userButton6.TabIndex = 28;
			this.userButton6.Text = "逆变操作";
			this.userButton6.Click += new System.EventHandler(this.userButton6_Click);
			// 
			// FourierTransform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1017, 669);
			this.Controls.Add(this.textBox_curve1);
			this.Controls.Add(this.userButton6);
			this.Controls.Add(this.textBox_curve2);
			this.Controls.Add(this.userButton5);
			this.Controls.Add(this.textBox_curve3);
			this.Controls.Add(this.userButton4);
			this.Controls.Add(this.userButton3);
			this.Controls.Add(this.userButton2);
			this.Controls.Add(this.userButton1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.userCurve5);
			this.Controls.Add(this.userCurve6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.userCurve3);
			this.Controls.Add(this.userCurve4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.userCurve2);
			this.Controls.Add(this.userCurve1);
			this.Controls.Add(this.label5);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FourierTransform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "傅立叶变换";
			this.Load += new System.EventHandler(this.傅立叶变换_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private HslControls.HslCurve userCurve1;
		private HslControls.HslCurve userCurve2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HslControls.HslCurve userCurve3;
        private HslControls.HslCurve userCurve4;
        private System.Windows.Forms.Label label6;
        private HslControls.HslCurve userCurve5;
        private HslControls.HslCurve userCurve6;
        private HslControls.HslButton userButton1;
        private HslControls.HslButton userButton2;
        private HslControls.HslButton userButton3;
		private HslControls.HslButton userButton4;
		private System.Windows.Forms.TextBox textBox_curve3;
		private System.Windows.Forms.TextBox textBox_curve2;
		private HslControls.HslButton userButton5;
		private System.Windows.Forms.TextBox textBox_curve1;
		private HslControls.HslButton userButton6;
	}
}