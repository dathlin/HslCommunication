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
using HslCommunication.Instrument.Temperature;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormDAM3601 : HslFormContent
    {
        public FormDAM3601( )
        {
            InitializeComponent( );
        }


        private DAM3601 dAM3601 = null;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.SelectedIndex = 0;



            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

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
            
            // 动态生成128个 label和128个textbox
            int index = 1;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Label label = new Label( );
                    label.Text = "温度" + index;
                    label.AutoSize = true;
                    TextBox textBox = new TextBox( );
                    textBox.Width = 50;

                    label.Parent = groupBox1;
                    label.Location = new Point( j * 115 + 5, i * 25 + 72 );
                    textBox.Parent = groupBox1;
                    textBox.Location = new Point( j * 115 + 60, i * 25 + 70 );
                    allTextBox.Add( textBox );
                    index++;
                }
            }
        }

        private List<TextBox> allTextBox = new List<TextBox>( );

        private void Language( int language )
        {
            // 英文显示
            if (language == 2)
            {
                Text = "Modbus Rtu Read Demo";

                label1.Text = "Com:";
                label3.Text = "baudRate:";
                label22.Text = "DataBit";
                label23.Text = "StopBit";
                label24.Text = "parity";
                label21.Text = "station";
                checkBox1.Text = "address from 0";
                checkBox3.Text = "string reverse";
                button1.Text = "Connect";
                button2.Text = "Disconnect";

                button_read_bool.Text = "r-coil";
                


                groupBox1.Text = "read test";
            

                comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
            }
        }

        private void CheckBox3_CheckedChanged( object sender, EventArgs e )
        {
            if (dAM3601 != null)
            {
                dAM3601.IsStringReverse = checkBox3.Checked;
            }
        }

        private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (dAM3601 != null)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0: dAM3601.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
                    case 1: dAM3601.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                    case 2: dAM3601.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                    case 3: dAM3601.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                    default: break;
                }
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
                MessageBox.Show( "波特率输入错误！" );
                return;
            }

            if (!int.TryParse( textBox16.Text, out int dataBits ))
            {
                MessageBox.Show( "数据位输入错误！" );
                return;
            }

            if (!int.TryParse( textBox17.Text, out int stopBits ))
            {
                MessageBox.Show( "停止位输入错误！" );
                return;
            }


            if (!byte.TryParse(textBox15.Text,out byte station))
            {
                MessageBox.Show( "站号输入不正确！" );
                return;
            }

            dAM3601?.Close( );
            dAM3601 = new DAM3601( station );
            dAM3601.AddressStartWithZero = checkBox1.Checked;


            ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
            dAM3601.IsStringReverse = checkBox3.Checked;


            try
            {
                dAM3601.SerialPortInni( sp =>
                 {
                     sp.PortName = comboBox3.Text;
                     sp.BaudRate = baudRate;
                     sp.DataBits = dataBits;
                     sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                     sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
                 } );
                dAM3601.Open( );

                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            dAM3601.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }









        #endregion

        private void button_read_bool_Click( object sender, EventArgs e )
        {
            OperateResult<float[]> read = dAM3601.ReadAllTemperature( );
            if(!read.IsSuccess)
            {
                MessageBox.Show( "读取失败！原因：" + read.Message );
                return;
            }

            // 显示128个数据信息
            for (int i = 0; i < allTextBox.Count; i++)
            {
                allTextBox[i].Text = read.Content[i].ToString( );
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
            element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
            element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
            element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
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
            checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
            comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
            checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
