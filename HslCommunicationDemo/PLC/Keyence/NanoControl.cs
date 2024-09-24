using HslCommunication;
using HslCommunication.Profinet.Keyence;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Keyence
{
	public class NanoControl : UserControl
	{
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private TextBox textBox10;
		private Label label13;
		private System.Windows.Forms.TextBox textBox6;
		private Label label_code;
		private TextBox textBox_code;
		private Label label1;

		public NanoControl( )
		{
			InitializeComponent( );
			if(Program.Language == 2)
			{
				label1.Text = "Address:";
				label13.Text = "Result:";
				button4.Text = "Annotation";
				label_code.Text = "Code:";
			}
		}

		private void InitializeComponent( )
		{
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(57, 5);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(217, 23);
			this.textBox6.TabIndex = 18;
			this.textBox6.Text = "D100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 17;
			this.label1.Text = "地址：";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(57, 35);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(722, 127);
			this.textBox10.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 37);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 15;
			this.label13.Text = "结果：";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(280, 2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 28);
			this.button4.TabIndex = 14;
			this.button4.Text = "注释";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(358, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 28);
			this.button3.TabIndex = 13;
			this.button3.Text = "plc-type";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 168);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 19;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(57, 166);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(722, 63);
			this.textBox_code.TabIndex = 20;
			// 
			// NanoControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label13);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "NanoControl";
			this.Size = new System.Drawing.Size(782, 232);
			this.Load += new System.EventHandler(this.NanoControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		public void SetDevice( KeyenceNanoSerial keyence, string address )
		{
			this.keyence = keyence;
		}

		public void SetDevice( KeyenceNanoSerialOverTcp keyence, string address )
		{
			this.keyence1 = keyence;
		}

		private KeyenceNanoSerial keyence;
		private KeyenceNanoSerialOverTcp keyence1;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<KeyencePLCS> read = keyence != null ? keyence.ReadPlcType( ) : keyence1.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox10.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<KeyencePLCS> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = keyence != null ? keyence.ReadAddressAnnotation( textBox6.Text ) : keyence1.ReadAddressAnnotation( textBox6.Text );
			if (read.IsSuccess)
			{
				textBox10.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadAddressAnnotation( \"{textBox6.Text}\" );";
		}

		private void NanoControl_Load( object sender, EventArgs e )
		{

		}
	}
}
