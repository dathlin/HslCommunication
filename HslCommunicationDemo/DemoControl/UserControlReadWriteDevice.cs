using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteDevice : UserControl
	{
		public UserControlReadWriteDevice( )
		{
			InitializeComponent( );
		}

		private void UserControlReadWriteDevice_Load( object sender, EventArgs e )
		{
			// 加载的事件
			if (Program.Language == 2)
			{
				tabPage1.Text = "Batch Read";
				tabPage2.Text = "Frame Message Read";
			}
		}

		public UserControlReadWriteOp ReadWriteOp
		{ 
			get => this.userControlReadWriteOp1;
		}

		public BatchReadControl BatchRead
		{
			get => this.batchReadControl1;
		}

		public BatchReadControl MessageRead
		{
			get => this.batchReadControl2;
		}


		public void AddSpecialFunctionTab( UserControl control )
		{
			TabPage tabPage = new TabPage( );
			tabPage.SuspendLayout( );
			this.tabControl1.Controls.Add( tabPage );

			tabPage.BackColor = System.Drawing.SystemColors.Control;
			tabPage.Controls.Add( control );
			tabPage.Location = new System.Drawing.Point( 4, 26 );
			tabPage.Name = "tabPage3";
			tabPage.Padding = new System.Windows.Forms.Padding( 3 );
			tabPage.Size = new System.Drawing.Size( 946, 252 );
			tabPage.TabIndex = 0;
			tabPage.Text = Program.Language == 1 ? "特殊功能测试" : "Special Function";

			control.Dock = DockStyle.Fill;
			tabPage.ResumeLayout( false );

		}
	}
}
