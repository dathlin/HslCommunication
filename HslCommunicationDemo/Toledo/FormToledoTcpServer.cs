using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Toledo;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo.Toledo
{
    public partial class FormToledoTcpServer : HslFormContent
    {
        public FormToledoTcpServer( )
        {
            InitializeComponent( );
        }

        private void FormToledoTcpServer_Load( object sender, EventArgs e )
        {

            panel2.Enabled = false;
            button2.Enabled = false;
            Language( Program.Language );
            hslCurve1.SetLeftCurve( "重量", null, Color.Red );
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Toledo Tcp Server Demo";
                button1.Text = "Open";
                button2.Text = "Close";
                label7.Text = "Data receiving Area:";
                checkBox4.Text = "Whether to show time";
            }
        }

        private ToledoTcpServer toledoTcpServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox2.Text, out int port ))
            {
                MessageBox.Show( Program.Language == 1 ? "端口号输入错误！" : "Port input wrong" );
                return;
            }

            try
            {
                toledoTcpServer = new ToledoTcpServer( );
                toledoTcpServer.HasChk = checkBox1.Checked;
                toledoTcpServer.OnToledoStandardDataReceived += ToledoTcpServer_OnToledoStandardDataReceived;
                toledoTcpServer.ServerStart( port );
                button1.Enabled = false;
                button2.Enabled = true;

                panel2.Enabled = true;
            }
            catch(Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }
        private long receiveTimes = 0;
        private void ToledoTcpServer_OnToledoStandardDataReceived( object sender, ToledoStandardData e )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<object, ToledoStandardData>( ToledoTcpServer_OnToledoStandardDataReceived ), sender, e );
                return;
            }

            receiveTimes++;
            StringBuilder sb = new StringBuilder( );
            if (checkBox4.Checked)
                sb.Append( DateTime.Now.ToString( ) + Environment.NewLine );
            sb.Append( e.ToJsonString( ) + Environment.NewLine );
            textBox6.Text = sb.ToString( );

            textBox1.Text = e.SourceData.ToHexString( ' ' );
            textBox3.Text = Encoding.ASCII.GetString( e.SourceData );

            toledoDataControl1.SetToledoData( e );
            hslCurve1.AddCurveData( "重量", e.Weight );
            hslDialPlate1.Value = e.Weight;

            label2.Text = "Receive Times:" + receiveTimes;
        }

        private void button2_Click( object sender, EventArgs e )
        {
            try
            {
                toledoTcpServer?.ServerClose( );
                button2.Enabled = false;
                button1.Enabled = true;

                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            if (float.TryParse( textBox4.Text, out float result ))
            {
                hslCurve1.ValueMaxLeft = result;
                hslDialPlate1.MaxValue = result; 
            }
            else
            {
                MessageBox.Show( "Input Wrong" );
            }
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlSumCheck, checkBox1.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlSumCheck ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
