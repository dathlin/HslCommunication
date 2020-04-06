using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Toledo;
using HslCommunication;

namespace HslCommunicationDemo.Toledo
{
    public partial class FormToledoTcpServer : HslFormContent
    {
        public FormToledoTcpServer( )
        {
            InitializeComponent( );
        }

        private void FormToledoTcpServer_Load( object sender, EventArgs e )
        {

            panel2.Enabled = false;
            button2.Enabled = false;
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Toledo Tcp Server Demo";
                button1.Text = "Open";
                button2.Text = "Close";
                label7.Text = "Data receiving Area:";
                checkBox4.Text = "Whether to show time";
            }
        }

        private ToledoTcpServer toledoTcpServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox2.Text, out int port ))
            {
                MessageBox.Show( Program.Language == 1 ? "端口号输入错误！" : "Port input wrong" );
                return;
            }

            try
            {
                toledoTcpServer = new ToledoTcpServer( );
                toledoTcpServer.OnToledoStandardDataReceived += ToledoTcpServer_OnToledoStandardDataReceived;
                toledoTcpServer.ServerStart( port );
                button1.Enabled = false;
                button2.Enabled = true;

                panel2.Enabled = true;
            }
            catch(Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void ToledoTcpServer_OnToledoStandardDataReceived( object sender, ToledoStandardData e )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<object, ToledoStandardData>( ToledoTcpServer_OnToledoStandardDataReceived ) );
                return;
            }

            StringBuilder sb = new StringBuilder( );
            if (checkBox4.Checked)
                sb.Append( DateTime.Now.ToString( ) + Environment.NewLine );
            sb.Append( e.ToJsonString( ) + Environment.NewLine );
            textBox6.Text = sb.ToString( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            try
            {
                toledoTcpServer?.ServerClose( );
                button2.Enabled = false;
                button1.Enabled = true;

                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }
    }
}
