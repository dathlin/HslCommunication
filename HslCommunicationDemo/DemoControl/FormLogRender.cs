using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.LogNet;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormLogRender : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormLogRender( ILogNet logNet )
		{
			InitializeComponent( );
			this.logNet = logNet;


			this.logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			this.comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslMessageDegree>( );
			this.comboBox1.SelectedItem = HslMessageDegree.DEBUG;
			this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			this.checkBox_output_file.CheckedChanged += CheckBox_output_file_CheckedChanged;
		}

		HslMessageDegree hslMessageDegree = HslMessageDegree.DEBUG;
		private string regexFilter = string.Empty;
		private string logOutputFileName = string.Empty;
		private System.IO.StreamWriter logStreamWrite = null;

		private void FormLogRender_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "Log";
				label1.Text = "Degree:";
				checkBox_stop_render.Text = "Stop render textbox";
				button_regex_filter.Text = "regex-filter";
				ShowCheckBoxText( );
			}
		}

		private void ShowCheckBoxText( )
		{
			checkBox_output_file.Text = Program.Language == 1 ? $"输出到文件({this.logOutputFileName})" : $"OutPut file({this.logOutputFileName})";

		}

		private void CheckBox_output_file_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox_output_file.Checked)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog( ))
				{
					saveFileDialog.FileName = string.IsNullOrEmpty(this.logOutputFileName) ? "log.txt" : this.logOutputFileName;
					if(saveFileDialog.ShowDialog() == DialogResult.OK )
					{
						try
						{
							this.logOutputFileName = saveFileDialog.FileName;
							logStreamWrite = new System.IO.StreamWriter( this.logOutputFileName, append: true, Encoding.UTF8 );
							ShowCheckBoxText( );
							DemoUtils.ShowMessage( "Set success" );
						}
						catch( Exception ex )
						{
							this.logOutputFileName = null;
							HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
						}
					}
				}

			}
			else
			{
				logOutputFileName = string.Empty;
				logStreamWrite?.Close( );
				logStreamWrite?.Dispose( );
				logStreamWrite = null;
			}
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			hslMessageDegree = (HslMessageDegree)this.comboBox1.SelectedItem;
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				if (!checkBox_stop_render.Checked)
				{
					if (e.HslMessage.Degree <= this.hslMessageDegree)
					{
						bool render = true;
						string log = e.HslMessage.ToString( ) + Environment.NewLine;
						if (!string.IsNullOrEmpty( this.regexFilter ))
						{
							if (!Regex.IsMatch( log, this.regexFilter ))
							{
								render = false;
							}
						}

						if (!string.IsNullOrEmpty(this.logOutputFileName) && this.logStreamWrite != null)
						{
							this.logStreamWrite.Write( log );
						}

						if (render) Invoke( new Action( ( ) =>
						{
							textBox1.AppendText( log );
						} ) );
					}
				}
			}
			catch
			{
				
			}
		}

		protected override void OnClosing( CancelEventArgs e )
		{
			base.OnClosing( e );

			this.logNet.BeforeSaveToFile -= LogNet_BeforeSaveToFile;
		}


		private ILogNet logNet = null;

		private void button_regex_filter_Click( object sender, EventArgs e )
		{
			this.regexFilter = this.textBox2.Text;
		}
	}
}
