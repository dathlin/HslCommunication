using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HslCommunication.ModBus;
using HslCommunication.Profinet.Knx;

namespace HslCommunicationDemo.PLC
{
    public partial class FormKnx : HslFormContent
    {
        KnxUdp kNX_Connection;
        my_modbus_server my_server;

        public FormKnx( )
        {
            kNX_Connection = new KnxUdp( );
            InitializeComponent( );
        }

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                IPEndPoint loc_ip = new IPEndPoint( IPAddress.Any, 0 );
                IPEndPoint ROU_IP = new IPEndPoint( IPAddress.Parse( R_IP.Text ), int.Parse( R_PROT.Text ) );
                kNX_Connection.LocalEndpoint = loc_ip;
                kNX_Connection.RouEndpoint = ROU_IP;
                kNX_Connection.ConnectKnx( );
                Thread.Sleep( 1000 );
                if (kNX_Connection.IsConnect)
                {
                    kNX_Connection.KnxCode.GetData_msg += KNX_CODE_GetData_msg;
                    new Thread( new ThreadStart( KNX_KEEP_RUN ) ) { IsBackground = true }.Start( );
                    button1.Enabled = false;
                    my_server = new my_modbus_server( this.kNX_Connection );
                    //my_server.IsUseAccountCertificate = false;
                    my_server.ServerStart( 504 );
                    my_server.LogNet = new HslCommunication.LogNet.LogNetSingle( "logs.txt" );        // 配置日志信息
                    button2.Enabled = true;
                    button3.Enabled = true;
                    ///  kNX_Connection.KNX_CODE.knx_server_is_real(loc_ip);
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show( ee.Message );
            }
        }

        private void KNX_CODE_GetData_msg( short addr, byte len, byte[] data )
        {
            if (!Run_list_button.Enabled)
            {
                listBox1.Invoke( new Action( ( ) => listBox1.Items.Add( "地址：" + addr + " 数据长度：" + len + " 数据：" + data[0].ToString( ) ) ) );

            }
            my_server.Write( addr.ToString( ), data[0] );
        }
        void KNX_KEEP_RUN( )
        {
            try
            {
                while (true)
                {
                    kNX_Connection.KeepConnection( );

                    Thread.Sleep( 80000 );
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show( "链接断开。。。 " + ee.Message );
            }

        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            //  KEEP_RUN.Dispose();
            kNX_Connection?.DisConnectKnx( );
        }

        private void Button3_Click( object sender, EventArgs e )
        {
            try
            {
                var x = addr.Text.Split( '\\' );
                if (x.Length == 3)
                {
                    int H = int.Parse( x[0] );
                    int M = int.Parse( x[1] );
                    int L = int.Parse( x[2] );
                    if ((H > 31 || M > 7 || L > 255) || (H < 0 || M < 0 || L < 0))
                    {
                        MessageBox.Show( "地址不合法" );
                    }
                    else
                    {
                        H = H << 11;
                        M = M << 8;
                        var y = H | M | L;
                        short z = (short)y;
                        //  MessageBox.Show(y.ToString("X"));
                        kNX_Connection.ReadKnxData( z );
                    }

                }
                else
                {
                    MessageBox.Show( "地址不合法" );
                }

            }
            catch (Exception ee)
            {

                MessageBox.Show( "地址不合法  " + ee.Message );
            }

        }

        private void Button2_Click( object sender, EventArgs e )
        {
            bool is_ok;
            byte[] x = new byte[1];
            if (data.Text == "1")
            {
                x[0] = (byte)1;
                kNX_Connection.SetKnxData( kNX_Connection.KnxCode.Get_knx_addr( addr.Text, out is_ok ), 1, x );
            }
            if (data.Text == "0")
            {
                x[0] = (byte)0;
                kNX_Connection.SetKnxData( kNX_Connection.KnxCode.Get_knx_addr( addr.Text, out is_ok ), 1, x );
            }
        }

        private void button7_Click( object sender, EventArgs e )
        {
            try
            {
                var x = data_box.Text.Split( '/' );
                if (x.Length == 3)
                {
                    int H = int.Parse( x[0] );
                    int M = int.Parse( x[1] );
                    int L = int.Parse( x[2] );
                    if ((H > 31 || M > 7 || L > 255) || (H < 0 || M < 0 || L < 0))
                    {
                        MessageBox.Show( "地址不合法" );
                    }
                    else
                    {
                        H = H << 11;
                        M = M << 8;
                        var y = H | M | L;
                        short z = (short)y;
                        //  MessageBox.Show(y.ToString("X"));
                        out_box.Text = (z + 1).ToString( );
                    }

                }
                else
                {
                    MessageBox.Show( "地址不合法" );
                }

            }
            catch (Exception ee)
            {

                MessageBox.Show( "地址不合法  " + ee.Message );
            }
        }

        private void Sotp_list_button_Click( object sender, EventArgs e )
        {
            Sotp_list_button.Enabled = false;
            Run_list_button.Enabled = true;
        }

        private void Run_list_button_Click( object sender, EventArgs e )
        {
            Sotp_list_button.Enabled = true;
            Run_list_button.Enabled = false;
        }
        private void FormKnx_Load( object sender, EventArgs e )
        {

        }

        private void button4_Click( object sender, EventArgs e )
        {
            listBox1.Items.Clear( );
        }
    }


    public class my_modbus_server : ModbusTcpServer
    {
        byte[] modbus_buffer;
        KnxUdp knx_Connect;
        public my_modbus_server( KnxUdp In_knx_Connect )
        {
            knx_Connect = In_knx_Connect;
            this.OnDataReceived += My_modbus_server_OnDataReceived;///截取modbus的信号进行处理
        }

        private void My_modbus_server_OnDataReceived( object sender, object source, byte[] data )
        {
            byte[] swap = new byte[2];
            if (modbus_buffer != null)
            {
                switch (modbus_buffer[1])///获取命令码
                {
                    case ModbusInfo.WriteOneRegister:
                        {
                            var set_buff = new byte[1];
                            swap[0] = modbus_buffer[3];
                            swap[1] = modbus_buffer[2];
                            var x = (short)BitConverter.ToUInt16( swap, 0 ); //获取数据地址
                            if (modbus_buffer[5] == 1 | modbus_buffer[5] == 0)
                            {
                                set_buff[0] = modbus_buffer[5];
                                knx_Connect.SetKnxData( x, 1, set_buff );
                            }

                            break;
                        }
                    case ModbusInfo.WriteRegister:
                        {
                            var set_buff = new byte[1];
                            swap[0] = modbus_buffer[3];
                            swap[1] = modbus_buffer[2];
                            var x = (short)BitConverter.ToUInt16( swap, 0 ); //获取数据地址
                            if (modbus_buffer[8] == 1 | modbus_buffer[8] == 0)
                            {
                                set_buff[0] = modbus_buffer[8];
                                knx_Connect.SetKnxData( x, 1, set_buff );
                            }
                            break;
                        }
                }
                modbus_buffer = null;
            }
        }

        /// <summary>
        /// 截取基类的报文
        /// </summary>
        /// <param name="modbusCore"></param>
        /// <returns></returns>
        protected override byte[] ReadFromModbusCore( byte[] modbusCore )
        {
            byte[] buffer = base.ReadFromModbusCore( modbusCore );//具体事项还是交给基类处理

            switch (modbusCore[1])///改写BOOL写入实现缓存同步
            {

                case ModbusInfo.WriteOneRegister:
                    {
                        modbus_buffer = modbusCore; break;//将核心数据保存，待事件触发时进行解析
                    }
                case ModbusInfo.WriteRegister:
                    {
                        modbus_buffer = modbusCore; break;//将核心数据保存，待事件触发时进行解析
                    }
            }

            return buffer;
        }
    }
}
