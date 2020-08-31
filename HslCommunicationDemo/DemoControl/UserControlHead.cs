using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunicationDemo.Control;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlHead : UserControl
	{
		public UserControlHead( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				System.Diagnostics.Process.Start( linkLabel1.Text );
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void UserControlHead_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				label2.Text = "博客地址：";
				label4.Text = "使用协议：";
				linkLabel2.Text = "保存连接";
			}
			else
			{
				label2.Text = "Blogs:";
				label4.Text = "Protocols:";
				linkLabel2.Text = "Save Connect";
			}

			if (!Program.ShowAuthorInfomation)
			{
				label2.Visible = false;
				linkLabel1.Visible = false;
			}

			BackColor = FormSelect.ThemeColor;
		}

		[Browsable(true)]
		[Category( "HslCommunicationDemo" )]
		[DefaultValue( "http://www.hslcommunication.cn" )]
		public string HelpLink
		{
			get => linkLabel1.Text;
			set
			{
				linkLabel1.Text = value;
			}
		}

		[Browsable( true )]
		[Category( "HslCommunicationDemo" )]
		[DefaultValue( "Hsl" )]
		public string ProtocolInfo
		{
			get => label5.Text;
			set
			{
				if (string.IsNullOrEmpty( value ))
				{
					label4.Visible = false;
				}
				else
				{
					label4.Visible = true;
				}
				label5.Text = value;
			}
		}

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			if(SaveConnectEvent == null)
			{
				MessageBox.Show( new NotImplementedException( ).Message );
				return;
			}

			SaveConnectEvent?.Invoke( sender, new EventArgs( ) );
		}

		public event EventHandler<EventArgs> SaveConnectEvent;
	}

}
