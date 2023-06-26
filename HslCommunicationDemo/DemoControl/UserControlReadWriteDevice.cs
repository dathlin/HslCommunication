using HslCommunication.Core;
using HslCommunicationDemo.PLC.Common;
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
using System.Xml.Linq;

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
				tabPage3.Text = "Thread Test";
				tabPage4.Text = "Data Table";
			}
		}

		public void SetReadWriteNet( IReadWriteNet readWrite, string address, bool isAsync = false, int strLength = 10 )
		{
			this.userControlReadWriteOp1.SetReadWriteNet( readWrite, address, isAsync, strLength );
			this.stressTesting1.SetReadWriteNet( readWrite, address );
			this.dataTableControl1.SetReadWriteNet( readWrite );
		}

		public UserControlReadWriteOp ReadWriteOpControl => this.userControlReadWriteOp1;

		public BatchReadControl BatchRead
		{
			get => this.batchReadControl1;
		}

		public BatchReadControl MessageRead
		{
			get => this.batchReadControl2;
		}

		public void AddSpecialFunctionTab( UserControl control, bool show = false, string title = null )
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
			if (string.IsNullOrEmpty( title ))
				tabPage.Text = Program.Language == 1 ? "特殊功能测试" : "Special Function";
			else
				tabPage.Text = title;

			control.Dock = DockStyle.Fill;
			tabPage.ResumeLayout( false );

			if (show) this.tabControl1.SelectTab( tabPage );
		}


		private void stressTesting1_Load( object sender, EventArgs e )
		{

		}



		public void RemoveReadBatch( )
		{
			tabControl1.TabPages.Remove( tabPage1 );
		}

		public void RemoveReadMessage( )
		{
			tabControl1.TabPages.Remove( tabPage2 );
		}

		public void GetDataTable( XElement element )
		{
			this.dataTableControl1.GetDataTable( element );
		}

		public int LoadDataTable( XElement element )
		{
			return this.dataTableControl1.LoadDataTable( element );
		}

		public void SelectTabDataTable( )
		{
			this.tabControl1.SelectTab( tabPage4 );
		}
	}
}
