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
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormUdpNet : HslFormContent
    {
        public FormUdpNet( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            textBox3.Text = Guid.Empty.ToString( );

        }



        private NetUdpClient udpClient = null;

        private void button1_Click( object sender, EventArgs e )
        {
            try
            {
                udpClient = new NetUdpClient( textBox1.Text, int.Parse( textBox2.Text ) );
                udpClient.Token = new Guid( textBox3.Text );

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
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


            int count = int.Parse( textBox6.Text );
            DateTime start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                OperateResult<string> read = udpClient.ReadFromServer( handle, textBox4.Text );
                if (read.IsSuccess)
                {
                    textBox8.AppendText( read.Content + Environment.NewLine );
                }
                else
                {
                    textBox8.AppendText( "Read Failed：" + read.Message + Environment.NewLine );
                }
            }
            

        }

        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox4.Clear( );
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlToken, textBox3.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox3.Text = element.Attribute( DemoDeviceList.XmlToken ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
