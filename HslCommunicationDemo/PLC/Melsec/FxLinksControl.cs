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
	public class FxLinksControl : SpecialFeaturesControl
	{
		public FxLinksControl()
		{
			InitializeComponent( );
		}

		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox2;

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(398, 226);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "FxLinks Function";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(194, 43);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(108, 28);
			this.button5.TabIndex = 28;
			this.button5.Text = "读取PLC型号";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(106, 43);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 28);
			this.button4.TabIndex = 27;
			this.button4.Text = "停止PLC";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(18, 43);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 26;
			this.button3.Text = "启动PLC";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// FxLinksControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "FxLinksControl";
			this.Load += new System.EventHandler(this.FxLinksControl_Load);
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void FxLinksControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				this.button3.Text = "Start PLC";
				this.button4.Text = "Stop PLC";
				this.button5.Text = "Read PlcType";
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
		}

		public void SetDevice( IReadWriteFxLinks melsecFxLinks, string address )
		{
			this.melsecFxLinks = melsecFxLinks;
			base.SetDevice( melsecFxLinks, address );
		}


		private IReadWriteFxLinks melsecFxLinks;
	}
}
