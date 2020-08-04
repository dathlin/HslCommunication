using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;
using System.Net;
using HslCommunication.LogNet;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormAbbServer : HslFormContent
    {
        public FormAbbServer( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            comboBox1.DataSource = new string[]
            {
                "text/html",
                "text/plain",
                "text/xml",
                "application/xml",
                "application/json"
            };

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
            }
            else
            {
            }
        }

        ABBWebApiServer httpServer;
        private void button1_Click( object sender, EventArgs e )
        {
            // 启动服务
            try
            {
                httpServer = new ABBWebApiServer( );
                httpServer.Start( int.Parse( textBox2.Text ) );
                httpServer.LogNet = new LogNetSingle( "" );
                httpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                httpServer.IsCrossDomain = checkBox1.Checked;             // 是否跨域的设置

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Started Failed:" + ex.Message );
            }
        }

        private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
        {
            Invoke( new Action( ( ) =>
             {
                 textBox4.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
             } ) );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            httpServer?.Close( );
            panel2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {

        }
    }


    #endregion
}
