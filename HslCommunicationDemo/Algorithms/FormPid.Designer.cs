namespace HslCommunicationDemo.Algorithms
{
    partial class FormPid
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.button2 = new System.Windows.Forms.Button();
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "P:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0.7";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(222, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0.4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "I:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(392, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "D:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(589, 58);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "DeadBlock:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(95, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Value:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "set value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.Transparent;
            this.userCurve1.IsAbscissaStrech = true;
            this.userCurve1.Location = new System.Drawing.Point(12, 151);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(980, 482);
            this.userCurve1.StrechDataCountMax = 100;
            this.userCurve1.TabIndex = 0;
            this.userCurve1.ValueMaxLeft = 400F;
            this.userCurve1.ValueMaxRight = 400F;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(720, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 24);
            this.button2.TabIndex = 13;
            this.button2.Text = "set para";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // userControlHead1
            // 
            this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlHead1.Location = new System.Drawing.Point(0, 0);
            this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
            this.userControlHead1.Name = "userControlHead1";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.TabIndex = 9;
            // 
            // FormPid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userControlHead1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userCurve1);
            this.Name = "FormPid";
            this.Text = "FormPid";
            this.Load += new System.EventHandler(this.FormPid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HslCommunication.Controls.UserCurve userCurve1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}