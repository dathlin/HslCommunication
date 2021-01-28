using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.Core.Net;

namespace HslCommunicationDemo
{
    public partial class FormSiemensDTU : HslFormContent
    {
        public FormSiemensDTU( )
        {
            InitializeComponent( );
        }


        private SiemensS7Net siemensTcpNet = null;
        private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            comboBox1.SelectedIndex = 0;
            panel2.Enabled = false;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            Language( Program.Language );

        }

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            siemensPLCSelected = comboBox1.SelectedItem.ToString( ) == "S1200" ? SiemensPLCS.S1200 :
                comboBox1.SelectedItem.ToString( ) == "S1500" ? SiemensPLCS.S1500 :
                comboBox1.SelectedItem.ToString( ) == "S300" ? SiemensPLCS.S300 :
                comboBox1.SelectedItem.ToString( ) == "S400" ? SiemensPLCS.S400 :
                comboBox1.SelectedItem.ToString( ) == "S200" ? SiemensPLCS.S200 :
                SiemensPLCS.S200Smart;
            if (siemensPLCSelected == SiemensPLCS.S400)
            {
                textBox15.Text = "0";
                textBox16.Text = "3";
            }
            else if (siemensPLCSelected == SiemensPLCS.S1200)
            {
                textBox15.Text = "0";
                textBox16.Text = "0";
            }
            else if (siemensPLCSelected == SiemensPLCS.S300)
            {
                textBox15.Text = "0";
                textBox16.Text = "2";
            }
            else if (siemensPLCSelected == SiemensPLCS.S1500)
            {
                textBox15.Text = "0";
                textBox16.Text = "0";
            }
        }

		private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Siemens Read PLC Demo";

                label3.Text = "Port:";
                button1.Text = "Create";
                button2.Text = "Disconnect";

                button_read_string.Text = "r-string";
                button7.Text = "r-time";
                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                label10.Text = "Address:";
                label9.Text = "Value:";
                label19.Text = "Note: The value of the string needs to be converted";
                button14.Text = "w-string";
                button8.Text = "w-time";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Special function test";

                button3.Text = "Order";
                button4.Text = "hot-start";
                button5.Text = "cold-start";
                button6.Text = "stop";
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }

        #region Alien Server

        /**************************************************************************************************
         * 
         *    说明：异形服务器的创建，为异形Modbus-Tcp客户端的创建提供必要的网络支撑
         * 
         **************************************************************************************************/

        private NetworkAlienClient networkAlien = null;

        private void NetworkAlienStart( int port )
        {
            networkAlien = new NetworkAlienClient( );
            networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
            networkAlien.ServerStart( port );
        }

        private void NetworkAlien_OnClientConnected( AlienSession session )
        {
            if (session.DTU == siemensTcpNet.ConnectionId)
            {
                siemensTcpNet.ConnectServer( session );
                Invoke( new Action( ( ) =>
                {
                    panel2.Enabled = true;
                    button2.Enabled = true;
                } ) );
            }
        }

        #endregion

        #region Connect And Close

        private void button1_Click( object sender, EventArgs e )
        {
            // 连接
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( "端口输入不正确！" );
                return;
            }

            siemensTcpNet = new SiemensS7Net( siemensPLCSelected, "127.0.0.1" ); 
            if (siemensPLCSelected != SiemensPLCS.S200Smart)
            {
                siemensTcpNet.Rack = byte.Parse( textBox15.Text );
                siemensTcpNet.Slot = byte.Parse( textBox16.Text );
            }

            try
            {
                siemensTcpNet.ConnectionId = textBox1.Text; // 设置唯一的ID
                NetworkAlienStart( port );
                siemensTcpNet.ConnectServer( null );        // 切换为异形客户端，并等待服务器的连接。
                userControlReadWriteOp1.SetReadWriteNet( siemensTcpNet, "M100", true );

                MessageBox.Show( "等待服务器的连接！" );
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }

        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            siemensTcpNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 单数据读取测试


        private async void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            OperateResult<string> read = await siemensTcpNet.ReadStringAsync( textBox8.Text );
            if (read.IsSuccess)
            {
                textBox7.Text = read.Content;
            }
            else
            {
                MessageBox.Show( "Failed:" + read.Message );
            }
        }

        private async void Button7_Click( object sender, EventArgs e )
        {
            OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
            if (read.IsSuccess)
            {
                textBox7.Text = read.Content.ToString( );
            }
            else
            {
                MessageBox.Show( "Failed:" + read.Message );
            }
        }

        #endregion

        #region 单数据写入测试

        private async void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
        }


        private async void Button8_Click( object sender, EventArgs e )
        {
            // time写入
            if (DateTime.TryParse( textBox7.Text, out DateTime value ))
                DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
            else
                MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
        }


        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( siemensTcpNet, textBox6, textBox9, textBox10 );
        }

        private async void button3_Click( object sender, EventArgs e )
        {
            // 订货号
            OperateResult<string> read = await siemensTcpNet.ReadOrderNumberAsync( );
            if (read.IsSuccess)
            {
                textBox10.Text = "Order Number：" + read.Content;
            }
            else
            {
                MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
            }
        }

        #endregion

        #region 报文读取测试


        private async void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = await siemensTcpNet.ReadFromCoreServerAsync( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
            if (read.IsSuccess)
            {
                textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
            }
            else
            {
                MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
            }
        }


        #endregion

        private async void button4_Click( object sender, EventArgs e )
        {
            // 热启动
            OperateResult result = await siemensTcpNet.HotStartAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private async void button5_Click( object sender, EventArgs e )
        {
            // 冷启动
            OperateResult result = await siemensTcpNet.ColdStartAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private async void button6_Click( object sender, EventArgs e )
        {
            // 停止
            OperateResult result = await siemensTcpNet.StopAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        private long successCount = 0;
        private System.Windows.Forms.Timer timer;


        private void button9_Click( object sender, EventArgs e )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            button9.Enabled = false;

            timer = new System.Windows.Forms.Timer( );
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start( );
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            label2.Text = successCount.ToString( );
        }

        private async void thread_test1( )
        {
            int count = 100000;
            while (count > 0)
            {
                if (!(await siemensTcpNet.WriteAsync( "M100", (short)1234 )).IsSuccess) failed++;
                if (!(await siemensTcpNet.ReadInt16Async( "M100" ) ).IsSuccess) failed++;
                count--;
                successCount++;
            }
            thread_end( );
        }

        private void thread_end( )
        {
            if (Interlocked.Decrement( ref thread_status ) == 0)
            {
                // 执行完成
                Invoke( new Action( ( ) =>
                {
                    label2.Text = successCount.ToString( );
                    timer.Stop( );
                    button9.Enabled = true;
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
                } ) );
            }
        }



        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( "DTU", textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlRack, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox16.Text );
            element.SetAttributeValue( "PlcType", comboBox1.SelectedIndex );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( "DTU" ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox15.Text = element.Attribute( DemoDeviceList.XmlRack ).Value;
            textBox16.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
            comboBox1.SelectedIndex = int.Parse( element.Attribute( "PlcType" ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
