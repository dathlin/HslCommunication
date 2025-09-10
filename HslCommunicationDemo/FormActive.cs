﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormActive : System.Windows.Forms.Form
	{
		public FormActive( )
		{
			InitializeComponent( );
			activePath = System.IO.Path.Combine( Application.StartupPath, "active.txt" );
			Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );
		}

		string activePath = string.Empty;

		private void button1_Click( object sender, EventArgs e )
		{
			bool active = false;
			if (textBox1.Text.Length < 100)
				active = HslCommunication.Authorization.SetAuthorizationCode( textBox1.Text );
			else
				active = HslCommunication.Authorization.SetHslCertificate( Convert.FromBase64String( textBox1.Text ) ).IsSuccess;


			if (active)
			{
				DemoUtils.ShowMessage( Program.Language == 1 ? "HslCommunication激活成功!" : "HslCommunication Activation successful!" );
				System.IO.File.WriteAllText( activePath, string.Empty, Encoding.UTF8 );
				System.IO.FileInfo fileInfo = new System.IO.FileInfo( activePath );
				string key = fileInfo.CreationTime.ToString( "yyyy-MM-dd-mm-ss" );
				HslCommunication.Core.Security.AesCryptography aesCryptography = new HslCommunication.Core.Security.AesCryptography( key + key );
				System.IO.File.WriteAllBytes( activePath, aesCryptography.Encrypt( Encoding.UTF8.GetBytes( textBox1.Text ) ) );
				DialogResult = DialogResult.OK;
			}
			else
			{
				DemoUtils.ShowMessage( Program.Language == 1 ? "HslCommunication激活失败！" : "HslCommunication Activation failed!" );
			}

			if (!string.IsNullOrEmpty( textBox2.Text ))
			{
				if (HslControls.Authorization.SetAuthorizationCode( textBox2.Text ))
				{
					string hslcontrolspath = System.IO.Path.Combine( Application.StartupPath, "controls_active.txt" );
					DemoUtils.ShowMessage( Program.Language == 1 ? "HslControls激活成功!" : "HslControls Activation successful!" );
					System.IO.File.WriteAllText( hslcontrolspath, string.Empty, Encoding.UTF8 );
					System.IO.FileInfo fileInfo = new System.IO.FileInfo( hslcontrolspath );
					string key = fileInfo.CreationTime.ToString( "yyyy-MM-dd-mm-ss" );
					HslCommunication.Core.Security.AesCryptography aesCryptography = new HslCommunication.Core.Security.AesCryptography( key + key );
					System.IO.File.WriteAllBytes( hslcontrolspath, aesCryptography.Encrypt( Encoding.UTF8.GetBytes( textBox2.Text ) ) );
					DialogResult = DialogResult.OK;
				}
				else
				{
					DemoUtils.ShowMessage( Program.Language == 1 ? "HslControls激活失败！" : "HslControls Activation failed!" );
				}
			}

		}

		private void FormActive_Load( object sender, EventArgs e )
		{

		}

		private void FormActive_Shown( object sender, EventArgs e )
		{
			ThreadPool.QueueUserWorkItem( new WaitCallback( ( m ) =>
			{
				string code = string.Empty;
				try
				{
					code = HslCommunication.BasicFramework.SoftAuthorize.GetInfo( false );
				}
				catch(Exception ex)
				{
					DemoUtils.ShowMessage( "Get Code Failed: " + ex.Message );
					return;
				}
				try
				{
					Invoke( new Action( ( ) =>
					{
						textBox3.Text = code;
					} ) );
				}
				catch
				{

				}
			} ), null );
		}
	}
}
