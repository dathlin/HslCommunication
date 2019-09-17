using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using System.IO;

namespace HslCommunicationDemo
{
    public partial class FormUpdateServer : HslFormContent
    {
        public FormUpdateServer( )
        {
            InitializeComponent( );
        }

        private NetSoftUpdateServer updateServer;

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                updateServer = new NetSoftUpdateServer( );
                updateServer.FileUpdatePath = textBox3.Text;
                updateServer.LogNet = new HslCommunication.LogNet.LogNetSingle( Path.Combine( Application.StartupPath, "log.txt" ) );
                updateServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                updateServer.ServerStart( int.Parse( textBox2.Text ) );
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "启动失败：" + ex.Message );
            }
        }

        private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
        {
            Invoke( new Action( ( ) =>
             {
                 textBox4.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
             } ) );
            e.HslMessage.Cancel = true;
        }

        private void FormUpdateServer_Load( object sender, EventArgs e )
        {
            textBox3.Text = Application.StartupPath;
        }

        private void Button3_Click( object sender, EventArgs e )
        {
            textBox4.Clear( );
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            textBox4.Lines = HslCommunication.Enthernet.NetSoftUpdateServer.GetAllFiles( textBox3.Text, null ).ToArray( );
        }
    }
}
