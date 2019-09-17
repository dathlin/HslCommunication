namespace HslCommunicationDemo
{
    partial class FormCurve
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
            this.label11 = new System.Windows.Forms.Label();
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.label12 = new System.Windows.Forms.Label();
            this.userCurve2 = new HslCommunication.Controls.UserCurve();
            this.label1 = new System.Windows.Forms.Label();
            this.userCurve3 = new HslCommunication.Controls.UserCurve();
            this.userButton8 = new HslCommunication.Controls.UserButton();
            this.userButton7 = new HslCommunication.Controls.UserButton();
            this.userButton6 = new HslCommunication.Controls.UserButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 619);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "曲线控件，此处只显示简单的一条曲线";
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.Transparent;
            this.userCurve1.ColorDashLines = System.Drawing.Color.LightGray;
            this.userCurve1.IsAbscissaStrech = true;
            this.userCurve1.Location = new System.Drawing.Point(12, 418);
            this.userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(1000, 198);
            this.userCurve1.StrechDataCountMax = 12;
            this.userCurve1.TabIndex = 33;
            this.userCurve1.Title = "信息表";
            this.userCurve1.ValueMaxLeft = 200F;
            this.userCurve1.ValueMaxRight = 200F;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(89, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(327, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "曲线控件，相对复杂的显示，2种坐标系，多条曲线同时显示";
            // 
            // userCurve2
            // 
            this.userCurve2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.userCurve2.ColorDashLines = System.Drawing.Color.DimGray;
            this.userCurve2.ColorLinesAndText = System.Drawing.Color.Gray;
            this.userCurve2.Location = new System.Drawing.Point(-1, 13);
            this.userCurve2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCurve2.Name = "userCurve2";
            this.userCurve2.Size = new System.Drawing.Size(497, 255);
            this.userCurve2.TabIndex = 36;
            this.userCurve2.ValueMaxLeft = 200F;
            this.userCurve2.ValueMaxRight = 5F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(725, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "静态曲线";
            // 
            // userCurve3
            // 
            this.userCurve3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.userCurve3.ColorDashLines = System.Drawing.Color.DimGray;
            this.userCurve3.ColorLinesAndText = System.Drawing.Color.Gray;
            this.userCurve3.Location = new System.Drawing.Point(502, 13);
            this.userCurve3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.userCurve3.Name = "userCurve3";
            this.userCurve3.Size = new System.Drawing.Size(500, 255);
            this.userCurve3.TabIndex = 38;
            this.userCurve3.ValueMaxLeft = 200F;
            this.userCurve3.ValueMaxRight = 5F;
            // 
            // userButton8
            // 
            this.userButton8.BackColor = System.Drawing.Color.Transparent;
            this.userButton8.CustomerInformation = "";
            this.userButton8.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton8.Location = new System.Drawing.Point(216, 301);
            this.userButton8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton8.Name = "userButton8";
            this.userButton8.Size = new System.Drawing.Size(78, 25);
            this.userButton8.TabIndex = 43;
            this.userButton8.UIText = "右辅助新增";
            this.userButton8.Click += new System.EventHandler(this.userButton8_Click);
            // 
            // userButton7
            // 
            this.userButton7.BackColor = System.Drawing.Color.Transparent;
            this.userButton7.CustomerInformation = "";
            this.userButton7.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton7.Location = new System.Drawing.Point(300, 301);
            this.userButton7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton7.Name = "userButton7";
            this.userButton7.Size = new System.Drawing.Size(78, 25);
            this.userButton7.TabIndex = 42;
            this.userButton7.UIText = "辅助线移除";
            this.userButton7.Click += new System.EventHandler(this.userButton7_Click);
            // 
            // userButton6
            // 
            this.userButton6.BackColor = System.Drawing.Color.Transparent;
            this.userButton6.CustomerInformation = "";
            this.userButton6.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton6.Location = new System.Drawing.Point(132, 301);
            this.userButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton6.Name = "userButton6";
            this.userButton6.Size = new System.Drawing.Size(78, 25);
            this.userButton6.TabIndex = 41;
            this.userButton6.UIText = "左辅助新增";
            this.userButton6.Click += new System.EventHandler(this.userButton6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(43, 302);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(83, 26);
            this.textBox1.TabIndex = 40;
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton1.Location = new System.Drawing.Point(384, 301);
            this.userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(78, 25);
            this.userButton1.TabIndex = 44;
            this.userButton1.UIText = "隐藏曲线";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // FormCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.userButton1);
            this.Controls.Add(this.userButton8);
            this.Controls.Add(this.userButton7);
            this.Controls.Add(this.userButton6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userCurve3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.userCurve2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.userCurve1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCurve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "曲线控件";
            this.Load += new System.EventHandler(this.FormCurve_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private HslCommunication.Controls.UserCurve userCurve1;
        private System.Windows.Forms.Label label12;
        private HslCommunication.Controls.UserCurve userCurve2;
        private System.Windows.Forms.Label label1;
        private HslCommunication.Controls.UserCurve userCurve3;
        private HslCommunication.Controls.UserButton userButton8;
        private HslCommunication.Controls.UserButton userButton7;
        private HslCommunication.Controls.UserButton userButton6;
        private System.Windows.Forms.TextBox textBox1;
        private HslCommunication.Controls.UserButton userButton1;
    }
}