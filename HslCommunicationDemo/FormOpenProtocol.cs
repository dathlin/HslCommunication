using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.OpenProtocol;

namespace HslCommunicationDemo
{
    public partial class FormOpenProtocol : HslFormContent
    {
        public FormOpenProtocol( )
        {
            InitializeComponent( );
        }

        private void Button1_Click( object sender, EventArgs e )
        {

            // 连接
            if (!System.Net.IPAddress.TryParse( textBox1.Text, out System.Net.IPAddress address ))
            {
                MessageBox.Show( "Ip地址输入不正确！" );
                return;
            }

            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( "端口输入格式不正确！" );
                return;
            }

            openProtocol?.ConnectClose( );
            openProtocol = new OpenProtocolNet( textBox1.Text, port );

            try
            {
                OperateResult connect = openProtocol.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( "连接成功！" );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "连接失败！" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private OpenProtocolNet openProtocol = null;

        private void FormOpenProtocol_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
        }

        private void Button_read_string_Click( object sender, EventArgs e )
        {
            try
            {
                OperateResult<string> read = openProtocol.ReadCustomer( int.Parse( textBox3.Text ),
                    int.Parse( textBox5.Text ), int.Parse( textBox6.Text ), int.Parse( textBox7.Text ), new List<string>( textBox8.Lines ) );

                if (read.IsSuccess)
                {
                    textBox4.Text = read.Content;
                }
                else
                {
                    MessageBox.Show( "Read Failed:" + read.Message );
                }
            }
            catch(Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }
    }
}
