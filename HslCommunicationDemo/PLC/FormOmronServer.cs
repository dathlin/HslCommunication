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
    public partial class FormOmronServer : HslFormContent
    {
        public FormOmronServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            if(Program.Language == 2)
            {
                Text = "Omron Virtual Server [data support, d, a, h, c, w]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict fins protocol and only supports perfect communication with HSL components.";
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            omronFinsServer?.ServerClose( );
        }

        private HslCommunication.Profinet.Omron.OmronFinsServer omronFinsServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            try
            {

                omronFinsServer = new HslCommunication.Profinet.Omron.OmronFinsServer( );                       // 实例化对象
                omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
                omronFinsServer.ServerStart( port );

                userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
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
            omronFinsServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] receive )
        {
            // 可以进行相关的操作
        }
    }
}
