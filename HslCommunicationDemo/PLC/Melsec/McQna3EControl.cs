using HslCommunication;
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
	public class McQna3EControl : SpecialFeaturesControl
	{
		private Button button6;
		private Button button7;
		private Button button5;
		private Button button4;
		private Button button8;
		private Button button11;
		private Button button10;
		private GroupBox groupBox2;

		public McQna3EControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button11);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(442, 226);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "MC Functions";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(6, 59);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(92, 28);
			this.button6.TabIndex = 28;
			this.button6.Text = "plc type";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(6, 25);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(92, 28);
			this.button7.TabIndex = 29;
			this.button7.Text = "remote reset";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(300, 25);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(94, 28);
			this.button5.TabIndex = 27;
			this.button5.Text = "remote stop";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(202, 25);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(86, 28);
			this.button4.TabIndex = 26;
			this.button4.Text = "remote run";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(104, 25);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(92, 28);
			this.button8.TabIndex = 30;
			this.button8.Text = "error reset";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(200, 192);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(194, 28);
			this.button11.TabIndex = 32;
			this.button11.Text = "Wait D100 123";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(6, 192);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(190, 28);
			this.button10.TabIndex = 31;
			this.button10.Text = "Wait M100 True";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// McQna3EControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "McQna3EControl";
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		public void SetDevice( IReadWriteMc mc, string address )
		{
			this.mc = mc;
			base.SetDevice( mc, address );
		}


		private void button7_Click( object sender, EventArgs e )
		{
			// 远程重置
			OperateResult result = mc.RemoteReset( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "RemoteReset Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.ToMessageShowString( ) );
			}
		}





		private IReadWriteMc mc;

		private void button8_Click( object sender, EventArgs e )
		{
			// 错误灯恢复
			OperateResult result = mc.ErrorStateReset( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "ErrorStateReset Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.ToMessageShowString( ) );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 远程启动
			OperateResult runResult = mc.RemoteRun( );
			if (runResult.IsSuccess)
			{
				MessageBox.Show( "Run Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + runResult.ToMessageShowString( ) );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 远程停止
			OperateResult runResult = mc.RemoteStop( );
			if (runResult.IsSuccess)
			{
				MessageBox.Show( "Stop Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + runResult.ToMessageShowString( ) );
			}
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 读取型号
			OperateResult<string> readResult = mc.ReadPlcType( );
			if (readResult.IsSuccess)
			{
				MessageBox.Show( "Type:" + readResult.Content );
			}
			else
			{
				MessageBox.Show( "Failed: " + readResult.ToMessageShowString( ) );
			}
		}

		private async void button10_Click( object sender, EventArgs e )
		{
			// 等待M100为True，读取频率为间隔100ms，等待超时为30秒
			button10.Enabled = false;
			OperateResult<TimeSpan> wait = await mc.WaitAsync( "M100", true, 100, 30_000 );
			if (wait.IsSuccess)
			{
				MessageBox.Show( "Wait Success, Takes " + wait.Content.TotalSeconds.ToString( "F1" ) + " Seconds" );
			}
			else
			{
				MessageBox.Show( "Wait Failed:" + wait.Message );
			}
			button10.Enabled = true;
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// 等待D100为123，读取频率为间隔100ms，等待超时为30秒
			button11.Enabled = false;
			OperateResult<TimeSpan> wait = await mc.WaitAsync( "D100", (short)123, 100, 30_000 );
			if (wait.IsSuccess)
			{
				MessageBox.Show( "Wait Success, Takes " + wait.Content.TotalSeconds.ToString( "F1" ) + " Seconds" );
			}
			else
			{
				MessageBox.Show( "Wait Failed:" + wait.Message );
			}
			button11.Enabled = true;
		}
	}
}
