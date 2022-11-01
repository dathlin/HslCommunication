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
using HslCommunication.Instrument.DLT;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunication.Instrument.CJT;

namespace HslCommunicationDemo
{
    public partial class FormCJT188OverTcp : HslFormContent
    {
        public FormCJT188OverTcp( )
        {
            InitializeComponent( );
        }

        private CJT188OverTcp cjt188 = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "CJT188 Read Demo";

                label1.Text = "Com:";
                label3.Text = "baudRate:";
                label_address.Text = "station";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                button3.Text = "Active";

                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                textBox_password.Text = "Pwd:";
                textBox_op_code.Text = "Op Code:";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Special function test";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        

        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox_port.Text,out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            cjt188?.ConnectClose( );
            cjt188 = new CJT188OverTcp( textBox_station.Text );
            cjt188.IpAddress = textBox_ip.Text;
            cjt188.InstrumentType = Convert.ToByte( textBox_type.Text, 16 );
            cjt188.Port = port;
			cjt188.LogNet = LogNet;
            cjt188.EnableCodeFE = checkBox_enable_Fe.Checked;
            cjt188.StationMatch = checkBox_station_match.Checked;


			try
            {
                OperateResult connect = cjt188.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;

                    userControlReadWriteOp1.SetReadWriteNet( cjt188, "90-1F", true );
                }
                else
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
                        "Error: " + connect.ErrorCode );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            cjt188.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( cjt188, textBox6, textBox9, textBox10 );
        }

        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = cjt188.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

        private async void button3_Click( object sender, EventArgs e )
        {
            //OperateResult active = await dLT645.ActiveDeveiceAsync( );
            //if (active.IsSuccess)
            //{
            //    MessageBox.Show( "Send Active Code Success" );
            //}
            //else
            //{
            //    MessageBox.Show( "Active Code failed:" + active.Message );
            //}
        }

        private void button4_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = cjt188.ReadAddress( );
            if (read.IsSuccess)
            {
                textBox_station.Text = read.Content;
                textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Address:{read.Content}";
            }
            else
            {
                MessageBox.Show( "Read failed: " + read.Message );
            }
        }

        private async void button6_Click( object sender, EventArgs e )
        {
            // 广播当前时间
            //OperateResult read = await dLT645.BroadcastTimeAsync( DateTime.Now );
            //if (read.IsSuccess)
            //{
            //    textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] BroadcastTime Success";
            //}
            //else
            //{
            //    MessageBox.Show( "Read failed: " + read.Message );
            //}
        }

        private void button5_Click( object sender, EventArgs e )
        {
            // 写通信地址
            OperateResult read = cjt188.WriteAddress( textBox1.Text );
            if (read.IsSuccess)
            {
                textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Write Success";
            }
            else
            {
                MessageBox.Show( "Read failed: " + read.Message );
            }
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
            element.SetAttributeValue( DemoDeviceList.XmlBaudRate,  textBox_port.Text );
            element.SetAttributeValue( DemoDeviceList.XmlStation,   textBox_station.Text );
            element.SetAttributeValue( "InstrumentType",      textBox_type.Text );
            element.SetAttributeValue( "StationMatch",        checkBox_station_match.Checked.ToString( ) );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox_ip.Text      = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, DemoDeviceList.XmlIpAddress, "192.168.0.100" );
            textBox_port.Text    = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
            textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
            textBox_type.Text    = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, "InstrumentType", "19" );
            checkBox_station_match.Checked = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, "StationMatch", false );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

        private void button_read_string_array_Click( object sender, EventArgs e )
        {
            OperateResult<string[]> read = cjt188.ReadStringArray( textBox1.Text );
            if (read.IsSuccess)
            {
                textBox12.Lines = read.Content;
            }
            else
            {
                MessageBox.Show( "read failed: " + read.Message );
            }
        }
    }
}
