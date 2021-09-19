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
using System.Xml.Linq;
using HslCommunication.Profinet.Melsec;

namespace HslCommunicationDemo
{
    public partial class FormMcA3CServer : HslFormContent
    {
        public FormMcA3CServer( )
        {
            InitializeComponent( );
            mcNetServer = new MelsecA3CServer( );                       // 实例化对象
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox2.SelectedIndex = 0;
            comboBox1.DataSource = System.IO.Ports.SerialPort.GetPortNames( );

            if(Program.Language == 2)
            {
                Text = "MC Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict mc protocol and only supports perfect communication with HSL components.";
            }

			checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
        }

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
            if (mcNetServer != null)
            {
                mcNetServer.Format = int.Parse( comboBox2.SelectedItem.ToString( ) );
            }
        }

		private void CheckBox2_CheckedChanged( object sender, EventArgs e )
		{
			if (mcNetServer != null)
			{
                mcNetServer.SumCheck = checkBox2.Checked;
            }
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            mcNetServer?.ServerClose( );
        }

        #region Server Start

        private MelsecA3CServer mcNetServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {
                mcNetServer.SumCheck = checkBox2.Checked;
                mcNetServer.Format = int.Parse( comboBox2.SelectedItem.ToString( ) );
                mcNetServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                //mcNetServer.OnDataReceived += MelsecMcServer_OnDataReceived;
                mcNetServer.ServerStart( port );
                userControlReadWriteServer1.SetReadWriteServer( mcNetServer, "D100" );

                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button5_Click( object sender, EventArgs e )
        {
			if (mcNetServer != null)
			{
                mcNetServer.StartSerialSlave( comboBox1.SelectedItem.ToString( ) );
                button5.Enabled = false;
            }
        }
        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            mcNetServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void MelsecMcServer_OnDataReceived( object sender,  object source, byte[] receive )
        {
            // 我们可以捕获到接收到的客户端的modbus报文
            // 如果是TCP接收的
            if (source is HslCommunication.Core.Net.AppSession session)
            {
                // 获取当前客户的IP地址
                string ip = session.IpAddress;
            }

            // 如果是串口接收的
            if (source is System.IO.Ports.SerialPort serialPort)
            {
                // 获取当前的串口的名称
                string portName = serialPort.PortName;
            }
        }

        #endregion


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlBinary, checkBox2.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            checkBox2.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlBinary ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

	}
}
