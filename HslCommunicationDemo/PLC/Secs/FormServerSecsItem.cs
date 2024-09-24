using HslCommunication.Secs.Types;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static HslCommunicationDemo.FormSecsGem;

namespace HslCommunicationDemo.PLC.Secs
{
	public partial class FormServerSecsItem : Form
	{
		public FormServerSecsItem( SecsTreeItem treeItem, bool server )
		{
			InitializeComponent( );
			this.treeItem = treeItem;
			this.server = server;
		}

		private void FormServerSecsItem_Load( object sender, EventArgs e )
		{
			DeviceAddressExample[] examples = FormSecsGem.GetSecsAddress( );
			StringBuilder stringBuilder = new StringBuilder( );
			for (int i = 0; i < examples.Length; i++)
			{
				stringBuilder.Append( examples[i].Mark );
			}
			textBox_example.Text = stringBuilder.ToString( );


			if (Program.Language == 2)
			{
				button_ok.Text = "OK";
			}

			if (!this.server)
			{
				textBox_data_back.ReadOnly = true;
			}
		}



		private void FormServerSecsItem_Shown( object sender, EventArgs e )
		{
			if (this.treeItem != null) ShowSecsTreeItem( this.treeItem );
		}

		private void ShowSecsTreeItem( SecsTreeItem treeItem )
		{
			textBox_device_s.Text = treeItem.S.ToString( );
			textBox_device_f.Text = treeItem.F.ToString( );
			checkBox_device_w.Checked = treeItem.W;
			textBox_name.Text = treeItem.Description;

			textBox_stream.Text = treeItem.S.ToString( );
			textBox_function.Text = (treeItem.F + 1).ToString( );

			if (server)
			{
				if (treeItem.Value != null)
					textBox_data_back.Text = treeItem.Value.ToXElement( ).ToString( );

				if (treeItem.ValueSingular != null)
				{
					textBox_device_send.Text = treeItem.ValueSingular.ToXElement( ).ToString( );
				}
			}
			else
			{
				if (treeItem.Value != null)
					textBox_device_send.Text = treeItem.Value.ToXElement( ).ToString( );

				if (treeItem.ValueSingular != null)
				{
					textBox_data_back.Text = treeItem.ValueSingular.ToXElement( ).ToString( );
				}
			}

		}


		private SecsTreeItem treeItem;
		private bool server = true;

		public SecsTreeItem SecsTreeItem { get; private set; }

		private void button_ok_Click( object sender, EventArgs e )
		{
			try
			{
				byte S = byte.Parse( textBox_device_s.Text );
				byte F = byte.Parse( textBox_device_f.Text );
				bool W = checkBox_device_w.Checked;
				string decs = textBox_name.Text;
				SecsValue secsValue1 = new SecsValue( );
				SecsValue secsValue2 = null;

				if (this.server)
				{
					if (!string.IsNullOrEmpty( textBox_data_back.Text )) secsValue1 = new SecsValue( XElement.Parse( textBox_data_back.Text ) );
					if (!string.IsNullOrEmpty( textBox_device_send.Text )) secsValue2 = new SecsValue( XElement.Parse( textBox_device_send.Text ) );
				}
				else
				{
					if (!string.IsNullOrEmpty( textBox_data_back.Text )) secsValue2 = new SecsValue( XElement.Parse( textBox_data_back.Text ) );
					if (!string.IsNullOrEmpty( textBox_device_send.Text )) secsValue1 = new SecsValue( XElement.Parse( textBox_device_send.Text ) );
				}

				SecsTreeItem = new SecsTreeItem( S, F, W, secsValue1, decs, secsValue2 );
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Input failed: " + ex.Message );
			}
		}
	}
}
