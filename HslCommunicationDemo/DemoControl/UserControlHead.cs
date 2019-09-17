using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                label20.Text = "作者：Richard Hu";
            }
            else
            {
                label2.Text = "Blogs:";
                label4.Text = "Protocols:";
                label20.Text = "Author:Richard Hu";
            }

            label20.Text = "Version: V" + HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( );

            if (!Program.ShowAuthorInfomation)
            {
                label2.Visible = false;
                linkLabel1.Visible = false;
                label20.Visible = false;
            }

            BackColor = Color.FromArgb( 128, 128, 255 );
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
    }
}
