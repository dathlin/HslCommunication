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
using HslCommunication.Core.Net;


/***************************************************************************************************
 * 
 *     说明：本界面是Modbus-Tcp的异形客户端的创建
 *     
 *     什么是异形客户端
 *     一般的Modbus-Tcp需要主动连接服务器才能进行读写操作
 *     异形客户端的意思是不主动连接，侦听服务器的连接，然后再对服务器进行数据交换
 *     
 *     这种场景多半用于一些特殊的工业环境
 * 
 * ***************************************************************************************************/

namespace HslCommunicationDemo
{
    public partial class FormModbusAlien : HslFormContent
    {
        public FormModbusAlien( )
        {
            InitializeComponent( );
        }


        private ModbusTcpNet busTcpClient = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            userCurve1.SetLeftCurve( "A", new float[0], Color.Tomato );

            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Alien Modbus Tcp Read Demo";
                
                label3.Text = "Port:";
                label21.Text = "station";
                checkBox1.Text = "address from 0";
                button1.Text = "Connect";
                button2.Text = "Disconnect";

                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Timed reading, curve display";

                label15.Text = "Address:";
                label18.Text = "Interval";
                button27.Text = "Start";
                label17.Text = "This assumes that the type of data is determined for short:";
                label22.Text = "(11-bit ASCII characters)";
            }
        }


        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            isThreadRun = false;
        }

        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
        {
            if (result.IsSuccess)
            {
                textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString( )}" );
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender( OperateResult result, string address )
        {
            if (result.IsSuccess)
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] 写入成功" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString( )}" );
            }
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
            if(session.DTU == busTcpClient.ConnectionId)
            {
                busTcpClient.ConnectServer( session );
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

            if (!byte.TryParse( textBox15.Text, out byte station ))
            {
                MessageBox.Show( "站号输入不正确！" );
                return;
            }

            busTcpClient = new ModbusTcpNet( "127.0.0.1", port, station );
            busTcpClient.LogNet = LogNet;
            busTcpClient.AddressStartWithZero = checkBox1.Checked;

            try
            {
                busTcpClient.ConnectionId = textBox1.Text; // 设置唯一的ID
                NetworkAlienStart( port );
                busTcpClient.ConnectServer( null );        // 切换为异形客户端，并等待服务器的连接。
                userControlReadWriteOp1.SetReadWriteNet( busTcpClient, "100", true );

                MessageBox.Show( "等待服务器的连接！" );
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            busTcpClient.ConnectClose( );
            button2.Enabled = false;
            panel2.Enabled = false;
            // 通知下线
        }

        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            try
            {
                OperateResult<byte[]> read = busTcpClient.Read( textBox6.Text , ushort.Parse( textBox9.Text ) );
                if (read.IsSuccess)
                {
                    textBox10.Text = "结果：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
                }
                else
                {
                    MessageBox.Show( "读取失败：" + read.ToMessageShowString( ) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "读取失败：" + ex.Message );
            }
        }



        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            try
            {
                OperateResult<byte[]> read = busTcpClient.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
                if (read.IsSuccess)
                {
                    textBox11.Text = "结果：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
                }
                else
                {
                    MessageBox.Show( "读取失败：" + read.ToMessageShowString( ) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "读取失败：" + ex.Message );
            }
        }


        #endregion

        #region 定时器读取测试

        // 外加曲线显示

        private Thread thread = null;              // 后台读取的线程
        private int timeSleep = 300;               // 读取的间隔
        private bool isThreadRun = false;          // 用来标记线程的运行状态

        private void button27_Click( object sender, EventArgs e )
        {
            // 启动后台线程，定时读取PLC中的数据，然后在曲线控件中显示

            if (!isThreadRun)
            {
                if (!int.TryParse( textBox14.Text, out timeSleep ))
                {
                    MessageBox.Show( "间隔时间格式输入错误！" );
                    return;
                }
                button27.Text = "停止";
                isThreadRun = true;
                thread = new Thread( ThreadReadServer );
                thread.IsBackground = true;
                thread.Start( );
            }
            else
            {
                button27.Text = "启动";
                isThreadRun = false;
            }
        }

        private void ThreadReadServer()
        {
            while (isThreadRun)
            {
                Thread.Sleep( timeSleep );

                try
                {
                    OperateResult<short> read = busTcpClient.ReadInt16( textBox12.Text );
                    if (read.IsSuccess)
                    {
                        // 显示曲线
                        if (isThreadRun) Invoke( new Action<short>( AddDataCurve ), read.Content );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "读取失败：" + ex.Message );
                }

            }
        }


        private void AddDataCurve( short data )
        {
            userCurve1.AddCurveData( "A", data );
        }


        #endregion

        #region 压力测试

        private void button4_Click( object sender, EventArgs e )
        {
            PressureTest2( );
        }

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        // 压力测试，开3个线程，每个线程进行读写操作，看使用时间
        private void PressureTest2( )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
        }

        private void thread_test2( )
        {
            int count = 500;
            while (count > 0)
            {
                if (!busTcpClient.Write( "100", (short)1234 ).IsSuccess) failed++;
                if (!busTcpClient.ReadInt16( "100" ).IsSuccess) failed++;
                count--;
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
                    MessageBox.Show( "耗时：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + "失败次数：" + failed );
                } ) );
            }
        }
        
        #endregion

        #region Test Function


        private void Test1()
        {
            OperateResult<bool[]> read = busTcpClient.ReadCoil( "100", 10 );
            if(read.IsSuccess)
            {
                bool coil_100 = read.Content[0];
                // and so on 
                bool coil_109 = read.Content[9];
            }
            else
            {
                // failed
                string err = read.Message;
            }
        }


        private void Test2()
        {
            bool[] values = new bool[] { true, false, false, false, true, true, false, true, false, false };
            OperateResult write = busTcpClient.Write( "100", values );
            if (write.IsSuccess)
            {
                // success
            }
            else
            {
                // failed
                string err = write.Message;
            }

            HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseWordTransform( );
        }

        #endregion


    }
}
