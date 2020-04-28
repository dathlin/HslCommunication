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
    public partial class FormCipServer : HslFormContent
    {
        public FormCipServer( )
        {
            InitializeComponent( );
        }



        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            if(Program.Language == 2)
            {
                Text = "Cip Virtual Server [support single value]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            cipServer?.ServerClose( );
        }

        #region Server Start

        private HslCommunication.Profinet.AllenBradley.AllenBradleyServer cipServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            try
            {

                cipServer = new HslCommunication.Profinet.AllenBradley.AllenBradleyServer( );                       // 实例化对象
                cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
                
                cipServer.ServerStart( port );
                cipServer.AddTagValue( "A", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "A1", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "B", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[4],
                    IsArray = false,
                    TypeLength = 4
                } );
                cipServer.AddTagValue( "C", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[4],
                    IsArray = false,
                    TypeLength = 4
                } );
                cipServer.AddTagValue( "D", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[10],
                    IsArray = true,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "E", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "F", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[100],
                    IsArray = false,
                    TypeLength = 1
                } );
                cipServer.AddTagValue( "G", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[500],
                    IsArray = true,
                    TypeLength = 100
                } );
                cipServer.AddTagValue( "AB.C", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[10],
                    IsArray = true,
                    TypeLength = 2
                } );

                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
                userControlReadWriteServer1.SetReadWriteServer( cipServer, "A", 1 );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            cipServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] receive )
        {
            // 可以对接收到的数据进行二次处理
        }

        #endregion

    }
}
