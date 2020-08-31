using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.EFORT;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo.Robot
{
    public partial class FormEfort : HslFormContent
    {
        public FormEfort( )
        {
            InitializeComponent( );
        }

        private void FormEfort_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;

            threadRead = new System.Threading.Thread( ThreadReadRobot );
            threadRead.IsBackground = true;
            threadRead.Start( );

        }


        private void RenderRobotData(EfortData efortData)
        {
            if(InvokeRequired)
            {
                try
                {
                    Invoke( new Action<EfortData>( RenderRobotData ), efortData );
                }
                catch
                {

                }

                return;
            }


            textBox4.Text = efortData.PacketStart;
            textBox6.Text = efortData.PacketOrders.ToString( );
            textBox7.Text = efortData.PacketHeartbeat.ToString( );
            textBox5.Text = efortData.PacketEnd.ToString( );

            if(efortData.ErrorStatus == 1)
            {
                label13.BackColor = Color.Red;
                label12.BackColor = SystemColors.Control;
            }
            else
            {
                label13.BackColor = SystemColors.Control;
                label12.BackColor = Color.Red;
            }

            if(efortData.HstopStatus == 1)
            {
                label15.BackColor = Color.Red;
                label14.BackColor = SystemColors.Control;
            }
            else
            {
                label15.BackColor = SystemColors.Control;
                label14.BackColor = Color.Red;
            }

            if(efortData.AuthorityStatus == 1)
            {
                label18.BackColor = Color.Red;
                label17.BackColor = SystemColors.Control;
            }
            else
            {
                label18.BackColor = SystemColors.Control;
                label17.BackColor = Color.Red;
            }

            if(efortData.ServoStatus == 1)
            {
                label22.BackColor = Color.Red;
                label21.BackColor = SystemColors.Control;
            }
            else
            {
                label22.BackColor = SystemColors.Control;
                label21.BackColor = Color.Red;
            }

            if(efortData.AxisMoveStatus == 1)
            {
                label25.BackColor = Color.Red;
                label24.BackColor = SystemColors.Control;
            }
            else
            {
                label25.BackColor = SystemColors.Control;
                label24.BackColor = Color.Red;
            }

            if(efortData.ProgMoveStatus == 1)
            {
                label28.BackColor = Color.Red;
                label27.BackColor = SystemColors.Control;
            }
            else
            {
                label28.BackColor = SystemColors.Control;
                label27.BackColor = Color.Red;
            }

            if(efortData.ProgLoadStatus == 1)
            {
                label31.BackColor = Color.Red;
                label30.BackColor = SystemColors.Control;
            }
            else
            {
                label31.BackColor = SystemColors.Control;
                label30.BackColor = Color.Red;
            }

            if(efortData.ProgHoldStatus == 1)
            {
                label34.BackColor = Color.Red;
                label33.BackColor = SystemColors.Control;
            }
            else
            {
                label34.BackColor = SystemColors.Control;
                label33.BackColor = Color.Red;
            }

            if(efortData.ModeStatus == 1)
            {
                label39.BackColor = Color.Red;
                label37.BackColor = SystemColors.Control;
                label36.BackColor = SystemColors.Control;
            }
            else if(efortData.ModeStatus == 2)
            {
                label39.BackColor = SystemColors.Control;
                label37.BackColor = Color.Red;
                label36.BackColor = SystemColors.Control;
            }
            else
            {
                label39.BackColor = SystemColors.Control;
                label37.BackColor = SystemColors.Control;
                label36.BackColor = Color.Red;
            }

            label40.Text = efortData.SpeedStatus.ToString( ) + " %";
            label46.Text = efortData.ProjectName;
            label48.Text = efortData.ProgramName;
            label72.Text = efortData.DbDeviceTime.ToString( );


            textBox8.Text = GetStringFromArray( efortData.IoDOut );
            textBox9.Text = GetStringFromArray( efortData.IoDIn );
            textBox10.Text = GetStringFromArray( efortData.IoIOut );
            textBox11.Text = GetStringFromArray( efortData.IoIIn );
            textBox12.Text = efortData.ErrorText;

            textBox13.Text = efortData.DbAxisPos[0].ToString( );
            textBox20.Text = efortData.DbAxisPos[1].ToString( );
            textBox24.Text = efortData.DbAxisPos[2].ToString( );
            textBox28.Text = efortData.DbAxisPos[3].ToString( );
            textBox32.Text = efortData.DbAxisPos[4].ToString( );
            textBox36.Text = efortData.DbAxisPos[5].ToString( );
            textBox40.Text = efortData.DbAxisPos[6].ToString( );

            textBox16.Text = efortData.DbCartPos[0].ToString( );
            textBox17.Text = efortData.DbCartPos[1].ToString( );
            textBox21.Text = efortData.DbCartPos[2].ToString( );
            textBox25.Text = efortData.DbCartPos[3].ToString( );
            textBox29.Text = efortData.DbCartPos[4].ToString( );
            textBox33.Text = efortData.DbCartPos[5].ToString( );

            textBox14.Text = efortData.DbAxisSpeed[0].ToString( );
            textBox19.Text = efortData.DbAxisSpeed[1].ToString( );
            textBox23.Text = efortData.DbAxisSpeed[2].ToString( );
            textBox27.Text = efortData.DbAxisSpeed[3].ToString( );
            textBox31.Text = efortData.DbAxisSpeed[4].ToString( );
            textBox35.Text = efortData.DbAxisSpeed[5].ToString( );
            textBox39.Text = efortData.DbAxisSpeed[6].ToString( );

            textBox46.Text = efortData.DbAxisAcc[0].ToString( );
            textBox45.Text = efortData.DbAxisAcc[1].ToString( );
            textBox44.Text = efortData.DbAxisAcc[2].ToString( );
            textBox43.Text = efortData.DbAxisAcc[3].ToString( );
            textBox42.Text = efortData.DbAxisAcc[4].ToString( );
            textBox41.Text = efortData.DbAxisAcc[5].ToString( );
            textBox37.Text = efortData.DbAxisAcc[6].ToString( );

            textBox53.Text = efortData.DbAxisAccAcc[0].ToString( );
            textBox52.Text = efortData.DbAxisAccAcc[1].ToString( );
            textBox51.Text = efortData.DbAxisAccAcc[2].ToString( );
            textBox50.Text = efortData.DbAxisAccAcc[3].ToString( );
            textBox49.Text = efortData.DbAxisAccAcc[4].ToString( );
            textBox48.Text = efortData.DbAxisAccAcc[5].ToString( );
            textBox47.Text = efortData.DbAxisAccAcc[6].ToString( );
            
            textBox15.Text = efortData.DbAxisTorque[0].ToString( );
            textBox18.Text = efortData.DbAxisTorque[1].ToString( );
            textBox22.Text = efortData.DbAxisTorque[2].ToString( );
            textBox26.Text = efortData.DbAxisTorque[3].ToString( );
            textBox30.Text = efortData.DbAxisTorque[4].ToString( );
            textBox34.Text = efortData.DbAxisTorque[5].ToString( );
            textBox38.Text = efortData.DbAxisTorque[6].ToString( );

            textBox60.Text = efortData.DbAxisDirCnt[0].ToString( );
            textBox59.Text = efortData.DbAxisDirCnt[1].ToString( );
            textBox58.Text = efortData.DbAxisDirCnt[2].ToString( );
            textBox57.Text = efortData.DbAxisDirCnt[3].ToString( );
            textBox56.Text = efortData.DbAxisDirCnt[4].ToString( );
            textBox55.Text = efortData.DbAxisDirCnt[5].ToString( );
            textBox54.Text = efortData.DbAxisDirCnt[6].ToString( );

            textBox67.Text = efortData.DbAxisTime[0].ToString( );
            textBox66.Text = efortData.DbAxisTime[1].ToString( );
            textBox65.Text = efortData.DbAxisTime[2].ToString( );
            textBox64.Text = efortData.DbAxisTime[3].ToString( );
            textBox63.Text = efortData.DbAxisTime[4].ToString( );
            textBox62.Text = efortData.DbAxisTime[5].ToString( );
            textBox61.Text = efortData.DbAxisTime[6].ToString( );
        }

        private string GetStringFromArray(Array array)
        {
            StringBuilder sb = new StringBuilder( "[" );
            foreach (var item in array)
            {
                sb.Append( item.ToString( ) + "," );
            }
            sb.Append( "]" );
            return sb.ToString( );
        }




        private void RenderErrorMessage(string msg )
        {
            if(InvokeRequired)
            {
                try
                {
                    Invoke( new Action<string>( RenderErrorMessage ), msg );
                }
                catch
                {

                }
                return;
            }


            label74.Text = "异常消息：[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " + msg;
            label74.BackColor = Color.Blue;
            System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( Reset ), null );

        }



        private void Reset( object obj )
        {
            System.Threading.Thread.Sleep( 2000 );
            label74.Invoke( new Action( ( ) =>
            {
                label74.BackColor = Color.Transparent;
            } ) );
        }



        private ER7BC10 efortRobot;

        private async void button1_Click( object sender, EventArgs e )
        {
            try
            {
                // 连接
                efortRobot = new ER7BC10( textBox1.Text, int.Parse( textBox2.Text ) );
                efortRobot.ConnectTimeOut = 2000;

                OperateResult connect = await efortRobot.ConnectServerAsync( );
                if(connect.IsSuccess)
                {
                    MessageBox.Show( "连接成功" );
                    button1.Enabled = false;
                    button2.Enabled = true;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "连接失败" );
                }
            }
            catch(Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            isReadPlc = false;
            efortRobot?.ConnectClose( );
            button2.Enabled = false;
            panel2.Enabled = false;
            button1.Enabled = true;
            threadRead?.Abort( );
            button3.Enabled = true;
        }

        private async void button_read_short_Click( object sender, EventArgs e )
        {
            // 刷新数据
            OperateResult<EfortData> read = await efortRobot.ReadEfortDataAsync( );
            if(!read.IsSuccess)
            {
                MessageBox.Show( "读取失败！" + read.Message );
            }
            else
            {
                RenderRobotData( read.Content );
            }
        }


        private async void ThreadReadRobot( )
        {
            while(true)
            {
                System.Threading.Thread.Sleep( timeSpeep );
                if (isReadPlc)
                {
                    OperateResult<EfortData> read = await efortRobot.ReadEfortDataAsync( );
                    if (read.IsSuccess)
                    {
                        RenderRobotData( read.Content );
                    }
                    else
                    {
                        RenderErrorMessage( read.Message );
                    }
                }
            }
        }


        private System.Threading.Thread threadRead;
        private int timeSpeep = 1000;
        private bool isReadPlc = false;

        private void button3_Click( object sender, EventArgs e )
        {
            try
            {
                // 定时读取
                timeSpeep = int.Parse( textBox3.Text );
                isReadPlc = true;
                button3.Enabled = false;
            }
            catch(Exception ex)
            {
                // 因为有可能时间文本的格式输入错误
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private async void Timer_Tick( object sender, EventArgs e )
        {
            OperateResult<EfortData> read = await efortRobot.ReadEfortDataAsync( );
            if(read.IsSuccess)
            {
                RenderRobotData( read.Content );
            }
        }



        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
