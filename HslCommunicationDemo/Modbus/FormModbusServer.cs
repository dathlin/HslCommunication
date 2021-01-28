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
using System.IO;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormModbusServer : HslFormContent
    {
        public FormModbusServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;

            if (Program.Language == 2)
            {
                Text = "Modbus Virtual Server[supports TCP and RTU, support coil and register reading and writing, input register read, discrete input read]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                checkBox2.Text = "Account Login";

                button3.Text = "filter-cli";
                label14.Text = "Com:";
                button5.Text = "Open Com";
                checkBox3.Text = "str-reverse";
            }
        }

        private void CheckBox2_CheckedChanged( object sender, EventArgs e )
        {
            if (busTcpServer != null)
            {
                busTcpServer.IsUseAccountCertificate = checkBox2.Checked;
            }
        }

        private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (busTcpServer != null)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
                    case 1: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                    case 2: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                    case 3: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                    default: break;
                }
            }
        }

        private void CheckBox3_CheckedChanged( object sender, EventArgs e )
        {
            if (busTcpServer != null)
            {
                busTcpServer.IsStringReverse = checkBox3.Checked;
            }
        }
        
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            busTcpServer?.ServerClose( );
        }

        #region Server Start


        private HslCommunication.ModBus.ModbusTcpServer busTcpServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {
                busTcpServer = new HslCommunication.ModBus.ModbusTcpServer( );                       // 实例化对象
                busTcpServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                busTcpServer.OnDataReceived += BusTcpServer_OnDataReceived;

                // add some accounts
                busTcpServer.AddAccount( "admin", "123456" );
                busTcpServer.AddAccount( "hsl", "test" );

                ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
                busTcpServer.IsStringReverse = checkBox3.Checked;

                userControlReadWriteServer1.SetReadWriteServer( busTcpServer, "100" );
                busTcpServer.ServerStart( port );

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
            busTcpServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] modbus )
        {
            // 我们可以捕获到接收到的客户端的modbus报文
        }

        #endregion

        private void button3_Click( object sender, EventArgs e )
        {
            if (busTcpServer == null)
            {
                MessageBox.Show( "Must Start Server！" );
                return;
            }
            // 信任客户端配置
            using (FormTrustedClient form = new FormTrustedClient( busTcpServer ))
            {
                form.ShowDialog( );
            }
        }

        private void button5_Click( object sender, EventArgs e )
        {
            // 启动串口
            if (busTcpServer != null)
            {
                try
                {
                    busTcpServer.StartModbusRtu( textBox10.Text );
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
            element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
            element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox10.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
            comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
            checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
	}
}
