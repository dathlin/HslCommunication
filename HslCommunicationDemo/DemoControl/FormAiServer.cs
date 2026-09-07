using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormAiServer : HslFormContent
	{
		public FormAiServer( )
		{
			InitializeComponent( );
		}

		private void FormAiServer_Load( object sender, EventArgs e )
		{
			DemoDevice.LoadDevice( dataGridView1 );
			if (!string.IsNullOrEmpty(Program.Settings.AiServerUrl))
			{
				textBox_url.Text = Program.Settings.AiServerUrl;
			}

			if (AIGatewayService.Instance.IsStarted)
			{
				LogNetSingle logNet = new LogNetSingle( "" );
				logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

				AIGatewayService.Instance.Server.LogNet = logNet;

				textBox_url.ReadOnly = true;
				button1.Enabled = false;
				button2.Enabled = true;
			}
			else
			{
				button1.Enabled = true;
				button2.Enabled = false;
				textBox_url.ReadOnly = false;
			}

		}

		/// <summary>
		/// 关联的AI菜单
		/// </summary>
		public ToolStripMenuItem AiToolStripMenuItem { get; set; }

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				{
					textBox2.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				} ) );
			}
			catch (Exception ex)
			{
				AIGatewayService.Instance.Server.LogNet = null;
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// start
			if (AIGatewayService.Instance.IsStarted == false)
			{
				try
				{
					AIGatewayService.Instance.Start( textBox_url.Text );
					button1.Enabled = false;
					button2.Enabled = true;
					textBox_url.ReadOnly = true;


					LogNetSingle logNet = new LogNetSingle( "" );
					logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

					AIGatewayService.Instance.Server.LogNet = logNet;
					Program.Settings.AiServerUrl = textBox_url.Text;


					if (AIGatewayService.Instance.IsStarted && AiToolStripMenuItem != null)
					{
						AiToolStripMenuItem.BackColor = Color.Green;
					}
					else
					{
						AiToolStripMenuItem.BackColor = FormMain.ThemeColor;
					}
				}
				catch ( Exception ex )
				{
					DemoUtils.ShowMessage( SoftBasic.GetExceptionMessage( ex ) );
				}

			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// stop
			try
			{
				if (AIGatewayService.Instance.IsStarted)
				{
					if (AIGatewayService.Instance.Server != null)
						AIGatewayService.Instance.Server.LogNet = null;
					AIGatewayService.Instance.Stop( );
					button1.Enabled = true;
					button2.Enabled = false;
					textBox_url.ReadOnly = false;



					if (AIGatewayService.Instance.IsStarted && AiToolStripMenuItem != null)
					{
						AiToolStripMenuItem.BackColor = Color.Green;
					}
					else
					{
						AiToolStripMenuItem.BackColor = FormMain.ThemeColor;
					}
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( SoftBasic.GetExceptionMessage( ex ) );
			}
		}

		private void FormAiServer_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (AIGatewayService.Instance.Server!= null)
				AIGatewayService.Instance.Server.LogNet = null;
		}
	}
}
