namespace HslCommunicationDemo.DemoControl
{
    partial class UserControlReadWriteServer
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
            this.userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
            this.button10 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userControlReadWriteOp1
            // 
            this.userControlReadWriteOp1.Location = new System.Drawing.Point(3, 1);
            this.userControlReadWriteOp1.Name = "userControlReadWriteOp1";
            this.userControlReadWriteOp1.Size = new System.Drawing.Size(954, 240);
            this.userControlReadWriteOp1.TabIndex = 0;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(855, 242);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 28);
            this.button10.TabIndex = 29;
            this.button10.Text = "定时写";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(406, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 36);
            this.label15.TabIndex = 26;
            this.label15.Text = "0";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(789, 242);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 28);
            this.button9.TabIndex = 28;
            this.button9.Text = "存储";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(217, 235);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(183, 36);
            this.label16.TabIndex = 25;
            this.label16.Text = "在线客户端：";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(722, 242);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 28);
            this.button8.TabIndex = 27;
            this.button8.Text = "加载";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(74, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "显示日志数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 276);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(954, 226);
            this.textBox1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "运行日志：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 28);
            this.button1.TabIndex = 30;
            this.button1.Text = "连接异形服务器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserControlReadWriteServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControlReadWriteOp1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserControlReadWriteServer";
            this.Size = new System.Drawing.Size(960, 505);
            this.Load += new System.EventHandler(this.UserControlReadWriteServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControlReadWriteOp userControlReadWriteOp1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
