using HslCommunication.Core;
using HslCommunication.Core.Net;
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

			allControls.Add( batchReadControl1 );
			allControls.Add( batchReadControl2 );
			allControls.Add( stressTesting1 );
			allControls.Add( dataExportControl1 );
			allControls.Add( debugRemoteControl1 );
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
				tabPage5.Text = "Data Export";
				tabPage6.Text = "Simulate";
				tabPage7.Text = "Debug Remote";
			}

			batchReadControl2.IsSourceReadMode = true;
		}

		private List<UserControl> allControls = new List<UserControl>( );

		public void SetEnable( bool enbale )
		{
			userControlReadWriteOp1.Enabled = enbale;
			pictureBox1.Enabled = enbale;

			if (enbale == false)
			{
				this.dataSimulateControl1.Close( );
				this.debugRemoteControl1.Close( );
				this.dataTableControl1.Close( );
			}

			for (int i = 0; i < allControls.Count; i++)
			{
				allControls[i].Enabled = enbale;
			}

		}

		public void SetReadWriteNet( IReadWriteNet readWrite, string address, bool isAsync = false, int strLength = 10 )
		{
			this.userControlReadWriteOp1.SetReadWriteNet( readWrite, address, isAsync, strLength );
			this.stressTesting1.SetReadWriteNet( readWrite, address );
			this.dataTableControl1.SetReadWriteNet( readWrite );
			this.dataExportControl1.SetReadWriteNet( readWrite );
			this.dataSimulateControl1.SetReadWriteNet( readWrite );
			this.debugRemoteControl1.SetCommunication( readWrite as BinaryCommunication );
		}

		public void SetDeviceVariableName( string name )
		{
			this.batchReadControl1.SetVariableName( name );
			this.batchReadControl2.SetVariableName( name );
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
			if (control != null)
			{
				DemoUtils.AddSpecialFunctionTab( this.tabControl1, control, show, title );
				if (control is AddressExampleControl)
				{

				}
				else
				{
					allControls.Add( control );
					if (control is CodeExampleControl codeExampleControl)
					{
						this.userControlReadWriteOp1.MethodCodeClick += ( object sender, string e ) =>
						{
							codeExampleControl.ReaderReadCode( e );
						};
					}
				}
			}
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
			element.RemoveNodes( );
			this.dataTableControl1.GetDataTable( element );
			this.dataSimulateControl1.GetSimulateTable( element );
		}

		public int LoadDataTable( XElement element )
		{
			int count = this.dataTableControl1.LoadDataTable( element );
			this.dataSimulateControl1.LoadSimulateTable( element );
			return count;
		}

		public void SelectTabDataTable( )
		{
			this.tabControl1.SelectTab( tabPage4 );
		}

		private bool showReadWrite = true;
		private void pictureBox1_Click( object sender, EventArgs e )
		{
			// 点击调整界面
			if (showReadWrite)
			{
				showReadWrite = false;
				pictureBox1.Image = Properties.Resources.view_16xLG;
				this.userControlReadWriteOp1.Visible = false;
				this.tabControl1.Location = new Point( 0, 0 );
				this.tabControl1.Size = new Size( this.Width, this.Height );
			}
			else
			{
				showReadWrite = true;
				pictureBox1.Image = Properties.Resources.shortcut_16xLG;
				this.userControlReadWriteOp1.Visible = true;
				this.tabControl1.Location = new Point( 0, 272);
				this.tabControl1.Size = new Size( this.Width, this.Height - 272 );
			}
		}

		#region 数据模拟和点位信息变更检测

		public bool HasTableChanged()
		{
			return this.dataTableControl1.HasTableChanged( ) || this.dataSimulateControl1.HasTableChanged( );
		}

		#endregion
	}
}
