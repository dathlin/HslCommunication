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
    #region FormPushNet

    public partial class FormPushNet : HslFormContent
    {
        public FormPushNet()
        {
            InitializeComponent( );
        }

        private void FormPushNet_Load( object sender, EventArgs e )
        {
            textBox15.Text = Guid.Empty.ToString( );
            panel2.Enabled = false;

        }


        private NetPushClient pushClient;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( "端口号输入错误" );
                return;
            }

            if (string.IsNullOrEmpty( textBox3.Text ))
            {
                MessageBox.Show( "关键字不能为空" );
                return;
            }

            pushClient?.ClosePush( );
            pushClient = new NetPushClient( textBox1.Text, port, textBox3.Text );
            OperateResult create = pushClient.CreatePush( new Action<NetPushClient, string>( PushFromServer ) );
            if (create.IsSuccess)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                MessageBox.Show( "成功" );
                panel2.Enabled = true;
            }
            else
            {
                MessageBox.Show( "失败：" + create.Message );
            }
        }

        private int receiveCount = 0;

        private void PushFromServer( NetPushClient pushClient, string data )
        {
            if (IsHandleCreated) Invoke( new Action<string>( m =>
              {
                  label8.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
                  receiveCount++;
                  label9.Text = receiveCount.ToString( );
                  textBox4.Text = m;
              } ), data );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            pushClient?.ClosePush( );
            panel2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlToken, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlTopic, textBox3.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox15.Text = element.Attribute( DemoDeviceList.XmlToken ).Value;
            textBox3.Text = element.Attribute( DemoDeviceList.XmlTopic ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }


    #endregion

}
