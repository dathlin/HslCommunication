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
using System.Net;

namespace HslCommunicationDemo
{
    #region NetComplexClient


    public partial class FormPlainSocket : HslFormContent
    {
        public FormPlainSocket( )
        {
            InitializeComponent( );
        }

        private void FormComplexNet_Load( object sender, EventArgs e )
        {
            button2.Enabled = false;
        }


        private NetPlainSocket plainSocket = null;


        private void button1_Click( object sender, EventArgs e )
        {

            if (!IPAddress.TryParse( textBox1.Text, out IPAddress address ))
            {
                MessageBox.Show( "IP地址填写不正确" );
                return;
            }

            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( "port填写不正确" );
                return;
            }

            try
            {
                plainSocket = new NetPlainSocket( textBox1.Text, port );
                plainSocket.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );                 // 不生成文件，仅仅触发BeforeSaveToFile事件
                plainSocket.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                plainSocket.ReceivedString += PlainSocket_ReceivedString;
                if (radioButton1.Checked) plainSocket.Encoding = Encoding.ASCII;
                if (radioButton2.Checked) plainSocket.Encoding = Encoding.Default;
                if (radioButton3.Checked) plainSocket.Encoding = Encoding.Unicode;
                if (radioButton4.Checked) plainSocket.Encoding = Encoding.UTF8;

                OperateResult connect = plainSocket.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( "Connect Success!" );
                    button1.Enabled = false;
                    button2.Enabled = true;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "Connect Failed:" + connect.Message );
                }
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
        {
            Invoke( new Action( ( ) =>
            {
                textBox8.AppendText( e.HslMessage.ToString() + Environment.NewLine );
            } ) );
        }

        private void PlainSocket_ReceivedString( string obj )
        {
            ShowTextInfo( $" {obj}" );
        }

        private void ComplexClient_MessageAlerts( string text )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<string>( ComplexClient_MessageAlerts ), text );
                return;
            }

            label11.Text =  text;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接 disconnect
            plainSocket.ConnectClose( );
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void ShowTextInfo( string text )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<string>( ShowTextInfo ), text );
                return;
            }

            textBox8.AppendText( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " : " + text + Environment.NewLine );
        }

        private void button3_Click( object sender, EventArgs e )
        {

            if (!int.TryParse( textBox6.Text, out int count ))
            {
                MessageBox.Show( "数据发送次数输入异常" );
                return;
            }

            int failed = 0;
            for (int i = 0; i < count; i++)
            {
                if(!plainSocket.SendString( textBox4.Text ).IsSuccess)
                {
                    failed++;
                }
            }
            if (failed > 0) MessageBox.Show( "Send Faield count: " + failed );
        }

    }


    #endregion
}
