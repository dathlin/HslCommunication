using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Fuji;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.IO;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormFujiSPBServer : HslFormContent
    {
        public FormFujiSPBServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

            if (Program.Language == 2)
            {
                Text = "Modbus Virtual Server[supports TCP and RTU, support coil and register reading and writing, input register read, discrete input read]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";

                label14.Text = "Com:";
                button5.Text = "Open Com";
                checkBox3.Text = "str-reverse";
            }
        }

        private void CheckBox3_CheckedChanged( object sender, EventArgs e )
        {
            if (sPBServer != null)
            {
                sPBServer.IsStringReverse = checkBox3.Checked;
            }
        }
        
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            sPBServer?.ServerClose( );
        }

        #region Server Start


        private FujiSPBServer sPBServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {
                sPBServer = new FujiSPBServer( );                       // 实例化对象
                sPBServer.Station = int.Parse( textBox1.Text );
                sPBServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                sPBServer.OnDataReceived += BusTcpServer_OnDataReceived;

                // add some accounts
                sPBServer.AddAccount( "admin", "123456" );
                sPBServer.AddAccount( "hsl", "test" );

                sPBServer.IsStringReverse = checkBox3.Checked;

                userControlReadWriteServer1.SetReadWriteServer( sPBServer, "D100" );
                sPBServer.ServerStart( port );

                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            sPBServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] modbus )
        {
            // 我们可以捕获到接收到的客户端的modbus报文
        }

        #endregion

        private void button5_Click( object sender, EventArgs e )
        {
            // 启动串口
            if (sPBServer != null)
            {
                try
                {
                    sPBServer.StartSerial( textBox10.Text );
                    button5.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show( "Start Failed：" + ex.Message );
                }
            }
            else
            {
                MessageBox.Show( "Start tcp server first please!" );
            }
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlCom, textBox10.Text );
            element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox10.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
            checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

		private void panel1_Paint( object sender, PaintEventArgs e )
		{

		}
	}
}
