using HslCommunication;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Melsec.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Melsec
{
	public class FxLinksControl : UserControl
	{
		public FxLinksControl()
		{
			InitializeComponent( );
		}

		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Button button3;

		private void InitializeComponent( )
		{
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(183, 7);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(108, 30);
			this.button5.TabIndex = 28;
			this.button5.Text = "读取PLC型号";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(95, 7);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 30);
			this.button4.TabIndex = 27;
			this.button4.Text = "停止PLC";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(7, 7);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 30);
			this.button3.TabIndex = 26;
			this.button3.Text = "启动PLC";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(4, 163);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 29;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(69, 160);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(961, 78);
			this.textBox_code.TabIndex = 30;
			// 
			// FxLinksControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FxLinksControl";
			this.Size = new System.Drawing.Size(1033, 241);
			this.Load += new System.EventHandler(this.FxLinksControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void FxLinksControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				this.button3.Text = "Start PLC";
				this.button4.Text = "Stop PLC";
				this.button5.Text = "Read PlcType";
				this.label_code.Text = "Code:";
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult operate = melsecFxLinks.StartPLC( );
			if (!operate.IsSuccess)
			{
				MessageBox.Show( "Start Failed：" + operate.Message );
			}
			else
			{
				MessageBox.Show( "Start Success" );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.StartPLC( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult operate = melsecFxLinks.StopPLC( );
			if (!operate.IsSuccess)
			{
				MessageBox.Show( "Stop Failed：" + operate.Message );
			}
			else
			{
				MessageBox.Show( "Stop Success" );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.StopPLC( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = melsecFxLinks.ReadPlcType( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "PLC Type:" + read.Content );
			}
			else
			{
				MessageBox.Show( "Read PLC Type failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";
		}

		public void SetDevice( IReadWriteFxLinks melsecFxLinks, string address )
		{
			this.melsecFxLinks = melsecFxLinks;
		}


		private IReadWriteFxLinks melsecFxLinks;
	}
}
