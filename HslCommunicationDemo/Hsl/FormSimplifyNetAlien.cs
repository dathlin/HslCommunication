using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
    public partial class FormSimplifyNetAlien : HslFormContent
    {
        public FormSimplifyNetAlien( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;

        }



        private NetSimplifyClient simplifyClient = new NetSimplifyClient( );
        

        private void button3_Click( object sender, EventArgs e )
        {
            // 数据发送
            NetHandle handle = new NetHandle( );
            if (textBox5.Text.IndexOf( '.' ) >= 0)
            {
                string[] values = textBox5.Text.Split( '.' );
                handle = new NetHandle( byte.Parse( values[0] ), byte.Parse( values[1] ), ushort.Parse( values[2] ) );
            }
            else
            {
                handle = int.Parse( textBox5.Text );
            }


            int count = int.Parse( textBox6.Text );
            DateTime start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                OperateResult<string> read = simplifyClient.ReadFromServer( handle, textBox4.Text );
                if (read.IsSuccess)
                {
                    textBox8.AppendText( read.Content + Environment.NewLine );
                }
                else
                {
                    MessageBox.Show( "读取失败：" + read.ToMessageShowString( ) );
                }
            }

            textBox7.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );

        }

        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox8.Clear( );
        }


        private void button1_Click_1( object sender, EventArgs e )
        {

            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( "端口输入不正确！" );
                return;
            }
            

            simplifyClient = new NetSimplifyClient( textBox1.Text, port );

            try
            {
                simplifyClient.ConnectionId = textBox1.Text; // 设置唯一的ID
                NetworkAlienStart( port );
                simplifyClient.ConnectServer( null );        // 切换为异形客户端，并等待服务器的连接。


                MessageBox.Show( "等待服务器的连接！" );
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        #region Alien Server

        /**************************************************************************************************
         * 
         *    说明：异形服务器的创建，为异形Modbus-Tcp客户端的创建提供必要的网络支撑
         * 
         **************************************************************************************************/

        private NetworkAlienClient networkAlien = null;

        private void NetworkAlienStart( int port )
        {
            networkAlien = new NetworkAlienClient( );
            networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
            networkAlien.ServerStart( port );
        }

        private void NetworkAlien_OnClientConnected(  PipeDtuNet session )
        {
            if (session.DTU == simplifyClient.ConnectionId)
            {
                //simplifyClient.setd( session );
                Invoke( new Action( ( ) =>
                {
                    panel2.Enabled = true;
                    button2.Enabled = true;
                } ) );
            }
        }



        #endregion
    }
}
