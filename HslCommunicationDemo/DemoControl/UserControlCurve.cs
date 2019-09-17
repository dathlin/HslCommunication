using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HslCommunication;

namespace HslCommunicationDemo.DemoControl
{
    public partial class UserControlCurve : UserControl
    {
        public UserControlCurve()
        {
            InitializeComponent( );
        }

        private void UserControlCurve_Load( object sender, EventArgs e )
        {
            if (Program.Language == 2)
            {
                groupBox5.Text = "Timed reading, curve display";
                label15.Text = "Address:";
                label18.Text = "Interval";
                button27.Text = "Start";
                label17.Text = "This assumes that the type of data is determined for short:";
            }

            userCurve1.SetLeftCurve( "A", new float[0], Color.Tomato );
        }


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
                    MessageBox.Show( "Time input wrong！" );
                    return;
                }
                button27.Text = "Stop";
                isThreadRun = true;
                thread = new Thread( ThreadReadServer );
                thread.IsBackground = true;
                thread.Start( );
            }
            else
            {
                button27.Text = "Start";
                isThreadRun = false;
            }
        }


        private void ThreadReadServer()
        {
            if (ReadWriteNet != null)
            {
                while (isThreadRun)
                {
                    Thread.Sleep( timeSleep );

                    try
                    {
                        OperateResult<short> read = ReadWriteNet.ReadInt16( textBox12.Text );
                        if (read.IsSuccess)
                        {
                            // 显示曲线
                            if (isThreadRun) Invoke( new Action<short>( AddDataCurve ), read.Content );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( "Read failed：" + ex.Message );
                    }
                }
            }
        }


        private void AddDataCurve( short data )
        {
            userCurve1.AddCurveData( "A", data );
        }

        /// <summary>
        /// 退出线程信息
        /// </summary>
        public void ThreadQuit()
        {
            isThreadRun = false;
        }

        [Browsable(false)]
        public HslCommunication.Core.IReadWriteNet ReadWriteNet { get; set; }

        [Category( "Appearance" )]
        [Description( "设置或获取默认的地址信息" )]
        [DefaultValue( "" )]
        public string AddressExample
        {
            set { textBox12.Text = value; }
            get { return textBox12.Text; }
        }
    }
}
