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

namespace HslCommunicationDemo
{
    public partial class FormDLT645 : HslFormContent
    {
        public FormDLT645( )
        {
            InitializeComponent( );
        }

        private DLT645 dLT645 = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.SelectedIndex = 0;

            comboBox3.DataSource = SerialPort.GetPortNames( );
            try
            {
                comboBox3.SelectedIndex = 0;
            }
            catch
            {
                comboBox3.Text = "COM3";
            }

            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "DLT645 Read Demo";

                label1.Text = "Com:";
                label3.Text = "baudRate:";
                label22.Text = "DataBit";
                label23.Text = "StopBit";
                label24.Text = "parity";
                label21.Text = "station";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                button3.Text = "Active";

                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Special function test";

                comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        

        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox2.Text,out int baudRate ))
            {
                MessageBox.Show( DemoUtils.BaudRateInputWrong );
                return;
            }

            if (!int.TryParse( textBox16.Text, out int dataBits ))
            {
                MessageBox.Show( DemoUtils.DataBitsInputWrong );
                return;
            }

            if (!int.TryParse( textBox17.Text, out int stopBits ))
            {
                MessageBox.Show( DemoUtils.StopBitInputWrong );
                return;
            }

            dLT645?.Close( );
            dLT645 = new DLT645( textBox15.Text );

            try
            {
                dLT645.SerialPortInni( sp =>
                 {
                     sp.PortName = comboBox3.Text;
                     sp.BaudRate = baudRate;
                     sp.DataBits = dataBits;
                     sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                     sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
                 } );
                dLT645.RtsEnable = checkBox5.Checked;
                dLT645.Open( );

                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlReadWriteOp1.SetReadWriteNet( dLT645, "00-00-00-00", false );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            dLT645.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            try
            {
                OperateResult<byte[]> read = dLT645.Read( textBox6.Text, ushort.Parse( textBox9.Text ) );
                if (read.IsSuccess)
                {
					for (int i = 0; i < read.Content.Length; i++)
					{
                        read.Content[i] = (byte)(read.Content[i] - 0x33);
                    }
                    textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
                }
                else
                {
                    MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Read Failed：" + ex.Message );
            }
        }

        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = dLT645.ReadBase( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

        private void button3_Click( object sender, EventArgs e )
        {
            OperateResult active = dLT645.ActiveDeveice( );
            if (active.IsSuccess)
            {
                MessageBox.Show( "Send Active Code Success" );
            }
            else
            {
                MessageBox.Show( "Active Code failed:" + active.Message );
            }
        }

        private void button4_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = dLT645.ReadAddress( );
            if (read.IsSuccess)
            {
                textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Address:{read.Content}";
            }
            else
            {
                MessageBox.Show( "Read failed: " + read.Message );
            }
        }

        private void button6_Click( object sender, EventArgs e )
        {
            // 广播当前时间
            OperateResult read = dLT645.BroadcastTime( DateTime.Now );
            if (read.IsSuccess)
            {
                textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] BroadcastTime Success";
            }
            else
            {
                MessageBox.Show( "Read failed: " + read.Message );
            }
        }

        private void button5_Click( object sender, EventArgs e )
        {
            // 写通信地址
            OperateResult read = dLT645.WriteAddress( textBox1.Text );
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
            element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
            element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
            element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
            element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
            element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlRtsEnable, checkBox5.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
            textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
            textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
            comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
            textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
            checkBox5.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlRtsEnable ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
