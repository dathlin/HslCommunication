using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;
using System.Net;
using HslCommunication.LogNet;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormAbbServer : HslFormContent
    {
        public FormAbbServer( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            comboBox1.DataSource = new string[]
            {
                "text/html",
                "text/plain",
                "text/xml",
                "application/xml",
                "application/json"
            };

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
            }
            else
            {
            }
        }

        ABBWebApiServer httpServer;
        private void button1_Click( object sender, EventArgs e )
        {
            // 启动服务
            try
            {
                httpServer = new ABBWebApiServer( );
                httpServer.SetLoginAccount( textBox3.Text, textBox1.Text );
                httpServer.Start( int.Parse( textBox2.Text ) );
                httpServer.LogNet = new LogNetSingle( "" );
                httpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                httpServer.IsCrossDomain = checkBox1.Checked;             // 是否跨域的设置

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Started Failed:" + ex.Message );
            }
        }

        private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
        {
            Invoke( new Action( ( ) =>
             {
                 if(showLog) textBox4.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
             } ) );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            httpServer?.Close( );
            panel2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {

        }

        private bool showLog = true;

        private void linkLabel3_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            textBox4.Clear( );
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // 停止
            showLog = false;
        }

        private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // 继续
            showLog = true;
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox3.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlCrossDomain, checkBox1.Checked );
            element.SetAttributeValue( DemoDeviceList.XmlContentType, comboBox1.SelectedIndex );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox3.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
            textBox1.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
            checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlCrossDomain ).Value );
            comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlContentType ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }


    #endregion
}
