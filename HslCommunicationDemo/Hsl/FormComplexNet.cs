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
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    #region NetComplexClient


    public partial class FormComplexNet : HslFormContent
    {
        public FormComplexNet( )
        {
            InitializeComponent( );
        }

        private void FormComplexNet_Load( object sender, EventArgs e )
        {
            button2.Enabled = false;
            textBox3.Text = Guid.Empty.ToString( );
            button5.Enabled = false;
        }


        private NetComplexClient complexClient = null;


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
                // 连接 connect
                complexClient = new NetComplexClient( );
                complexClient.ClientAlias = textBox9.Text;
                complexClient.EndPointServer = new IPEndPoint( address, port );
                complexClient.Token = new Guid( textBox3.Text );
                complexClient.AcceptString += ComplexClient_AcceptString;
                complexClient.AcceptByte += ComplexClient_AcceptByte;
                complexClient.MessageAlerts += ComplexClient_MessageAlerts;
                complexClient.ClientStart( );

                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
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

        private void ComplexClient_AcceptByte( HslCommunication.Core.Net.AppSession session, NetHandle handle, byte[] data )
        {
            // 接收字节数据，
            ShowTextInfo( $"{DateTime.Now} [{session.IpEndPoint}] [{handle}] {HslCommunication.BasicFramework.SoftBasic.ByteToHexString( data )}" );
        }

        private void ComplexClient_AcceptString( HslCommunication.Core.Net.AppSession session, NetHandle handle, string data )
        {
            // 接收字符串
            ShowTextInfo( $"{DateTime.Now} [{session.IpEndPoint}] [{handle}] {data}" );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接 disconnect
            complexClient.ClientClose( );
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;
        }

        private void ShowTextInfo( string text )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<string>( ShowTextInfo ), text );
                return;
            }

            textBox8.AppendText( text + Environment.NewLine );
        }

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


            if (!int.TryParse( textBox6.Text, out int count ))
            {
                MessageBox.Show( "数据发送次数输入异常" );
                return;
            }

            for (int i = 0; i < count; i++)
            {
                complexClient.Send( handle, textBox4.Text );
            }
        }

        private void button6_Click( object sender, EventArgs e )
        {
            // 多客户端压力测试
            System.Threading.Thread thread = new System.Threading.Thread( ServerPressureTest );
            thread.IsBackground = true;
            thread.Start( );
            button6.Enabled = false;
            button5.Enabled = true;
        }

        private System.Threading.AutoResetEvent autoResetWait = new System.Threading.AutoResetEvent( false );

        private void ServerPressureTest( )
        {
            NetComplexClient[] netComplices = new NetComplexClient[100];
            for (int i = 0; i < 100; i++)
            {
                netComplices[i] = new NetComplexClient( );
                netComplices[i].EndPointServer = new IPEndPoint( IPAddress.Parse( textBox1.Text ), int.Parse( textBox2.Text ) );
                netComplices[i].ClientAlias = "Client" + (i + 1);
                netComplices[i].ClientStart( );
            }

            // 等待连接完成
            System.Threading.Thread.Sleep( 2000 );
            int index = 0;

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    netComplices[i].Send( 1, "测试消息" + (index++) );
                }
            }

            // 等待所有的都发送完成
            // System.Threading.Thread.Sleep( 2000 );
            autoResetWait.WaitOne( );


            for (int i = 0; i < 100; i++)
            {
                netComplices[i].ClientClose( );
            }


            Invoke( new Action( ( ) =>
             {
                 button6.Enabled = true;
             } ) );
        }

        private void button5_Click( object sender, EventArgs e )
        {
            autoResetWait.Set( );
            button5.Enabled = false;
        }

        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlToken, textBox3.Text );
            element.SetAttributeValue( DemoDeviceList.XmlAlias, textBox9.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox3.Text = element.Attribute( DemoDeviceList.XmlToken ).Value;
            textBox9.Text = element.Attribute( DemoDeviceList.XmlAlias ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }


    #endregion
}
