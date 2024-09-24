using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.ModBus;

namespace HslCommunicationDemo
{
    public partial class FormTrustedClient : System.Windows.Forms.Form
    {
        public FormTrustedClient( HslCommunication.ModBus.ModbusTcpServer modbusTcpServer )
        {
            InitializeComponent( );
            this.modbusTcpServer = modbusTcpServer;
        }

        private HslCommunication.ModBus.ModbusTcpServer modbusTcpServer;

        private void FormTrustedClient_Load( object sender, EventArgs e )
        {
            string[] clients = modbusTcpServer.GetTrustedClients( );
            for (int i = 0; i < clients.Length; i++)
            {
                textBox1.AppendText( clients[i] + Environment.NewLine );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            // 保存
            string[] address = textBox1.Text.Split( new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries );
            if(address.Length > 0)
            {
                modbusTcpServer.SetTrustedIpAddress( new List<string>( address ) );
            }
            else
            {
                modbusTcpServer.SetTrustedIpAddress( null );
            }
            MessageBox.Show( "成功" );
            Close( );
        }
    }
}
