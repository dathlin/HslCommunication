using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;

namespace HslCommunicationDemo
{
    public partial class FormGeSRTPServer : HslFormContent
    {
        public FormGeSRTPServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            if(Program.Language == 2)
            {
                Text = "Ge SRTP Virtual Server[data support I,Q,M,T,SA,SB,SC,S,G,AI,AQ,R]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict ge SRTP protocol and only supports perfect communication with HSL components.";
            }
        }
        
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            geSRTPServer?.ServerClose( );
        }

        #region Server Start


        private HslCommunication.Profinet.GE.GeSRTPServer geSRTPServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {
                geSRTPServer = new HslCommunication.Profinet.GE.GeSRTPServer( );                       // 实例化对象
                geSRTPServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                geSRTPServer.OnDataReceived += BusTcpServer_OnDataReceived;
                
                geSRTPServer.ServerStart( port );

                userControlReadWriteServer1.SetReadWriteServer( geSRTPServer, "R1" );
                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            geSRTPServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] receive )
        {
            // 可以对报文二次处理
        }

        #endregion
    }
}
