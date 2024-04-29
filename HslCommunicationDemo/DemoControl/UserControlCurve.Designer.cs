namespace HslCommunicationDemo.DemoControl
{
    partial class UserControlCurve
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

            isThreadRun = false;
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.userCurve1 = new HslControls.HslCurve();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button27);
            this.groupBox5.Controls.Add(this.textBox14);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.textBox12);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.userCurve1);
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(419, 278);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "定时读取，曲线显示";
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(343, 25);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(70, 28);
            this.button27.TabIndex = 9;
            this.button27.Text = "启动";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(267, 28);
            this.textBox14.Name = "textBox14";
            this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox14.Size = new System.Drawing.Size(70, 21);
            this.textBox14.TabIndex = 8;
            this.textBox14.Text = "300";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(208, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 7;
            this.label18.Text = "间隔：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(76, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(215, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "此处假设确定了数据的类型，为short：";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(78, 27);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(118, 21);
            this.textBox12.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "地址：";
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.userCurve1.Location = new System.Drawing.Point(13, 82);
            this.userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(400, 189);
            this.userCurve1.TabIndex = 0;
            this.userCurve1.ReferenceAxisLeft.Max = 200F;
            this.userCurve1.ReferenceAxisRight.Max = 200F;
            // 
            // UserControlCurve
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Name = "UserControlCurve";
            this.Size = new System.Drawing.Size(420, 279);
            this.Load += new System.EventHandler(this.UserControlCurve_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label15;
        private HslControls.HslCurve userCurve1;
    }
}
