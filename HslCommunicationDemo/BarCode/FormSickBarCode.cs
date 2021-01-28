using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Sick;

namespace HslCommunicationDemo.BarCode
{
    public partial class FormSickBarCode : HslFormContent
    {
        public FormSickBarCode( )
        {
            InitializeComponent( );
        }

        private void FormSickBarCode_Load( object sender, EventArgs e )
        {
            button11.Enabled = false;
            timer = new Timer( );
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start( );

            panel2.Enabled = false;
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            if(tcpServer!=null)
            {
                label15.Text = tcpServer.OnlineCount.ToString( );
            }
        }

        private SickIcrTcpServer tcpServer;
        private Timer timer;

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                tcpServer = new SickIcrTcpServer( );
                tcpServer.ServerStart( int.Parse( textBox2.Text ) );
                tcpServer.OnReceivedBarCode += TcpServer_OnReceivedBarCode;
                button1.Enabled = false;
                button11.Enabled = true;
                panel2.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Start Failed: " + ex.Message );
            }
        }

        private void TcpServer_OnReceivedBarCode( string ipAddress, string barCode )
        {
            Invoke( new Action( ( ) =>
             {
                 textBox1.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss  [") + ipAddress + "] BarCode[" + barCode + "]" + Environment.NewLine );
             } ) );
        }

        private void Button11_Click( object sender, EventArgs e )
        {
            tcpServer?.ServerClose( );

            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            try
            {
                System.Net.IPAddress.Parse( textBox3.Text );
                tcpServer.AddConnectBarcodeScan( textBox3.Text, int.Parse( textBox4.Text ) );
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Data Input wrong: " + HslCommunication.BasicFramework.SoftBasic.GetExceptionMessage( ex ) );
            }
        }

        private void label6_Click( object sender, EventArgs e )
        {

        }
    }
}
