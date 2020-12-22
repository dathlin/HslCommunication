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
using HslCommunication.Profinet.IDCard;
using HslCommunication;
using System.IO;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormSAMTcpNet : HslFormContent
    {
        public FormSAMTcpNet( )
        {
            InitializeComponent( );
        }


        private SAMTcpNet sAMTcpNet = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );
        }


        private void Language( int language )
        {
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        

        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            sAMTcpNet?.ConnectClose( );
            sAMTcpNet = new SAMTcpNet( textBox1.Text, port );
            try
            {
                OperateResult connect = sAMTcpNet.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
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
            sAMTcpNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }




        #endregion

        #region 单数据读取测试


        private void button_sam1_Click( object sender, EventArgs e )
        {
            // 安全模块号
            OperateResult<string> read = sAMTcpNet.ReadSafeModuleNumber( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox4.Text = "Result:" + read.Content;
            }
        }

        private void button_sam2_Click( object sender, EventArgs e )
        {
            // 检查安全模块状态
            OperateResult read = sAMTcpNet.CheckSafeModuleStatus( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox4.Text = "检查安全模块状态成功";
            }
        }


        private void button_sam3_Click( object sender, EventArgs e )
        {
            // 寻找卡片
            OperateResult read = sAMTcpNet.SearchCard( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox4.Text = "寻找卡片成功";
            }
        }

        private void button_sam4_Click( object sender, EventArgs e )
        {
            // 选择卡片
            OperateResult read = sAMTcpNet.SelectCard( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox4.Text = "选择卡片成功";
            }
        }

        private void button_sam5_Click( object sender, EventArgs e )
        {
            // 读取卡片信息
            OperateResult<IdentityCard> read = sAMTcpNet.ReadCard( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox4.Text = read.Content.ToString( );
                //string tms = Encoding.Unicode.GetString( read.Content.Portrait );
                //File.WriteAllBytes( Path.Combine( Application.StartupPath, "cart.bmp" ), read.Content.Portrait );
                //MemoryStream stream = new MemoryStream( read.Content.Portrait );
                //Bitmap bitmap = BitmapFactory.decodeByteArray( image_b, 0, image_b.length );

                //stream.Dispose( );
                //pictureBox2.Image?.Dispose( );
                //pictureBox2.Image = Image.FromFile( Path.Combine( Application.StartupPath, "cart.bmp" ) );
            }
        }



        #endregion

        private void button_sam_start_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox9.Text, out int sleep ))
            {
                MessageBox.Show( "当前的数据错误，必须整数！" );
                return;
            }

            this.sleep = sleep;
            threadEnable = true;
            new Thread( new ThreadStart( ThreadBackgroundReadCard ) ) { IsBackground = true }.Start( );
            button_sam_start.Enabled = false;
            button3.Enabled = true;
        }

        private int sleep = 1000;
        private bool threadEnable = true;

        private void button3_Click( object sender, EventArgs e )
        {
            threadEnable = false;
            button_sam_start.Enabled = true;
            button3.Enabled = false;
        }

        private void ThreadBackgroundReadCard( )
        {
            while (threadEnable)
            {
                Thread.Sleep( sleep );
                OperateResult search = sAMTcpNet.SearchCard( );
                {
                    if (!search.IsSuccess)
                    {
                        continue;
                    }
                }

                Invoke( new Action( ( ) =>
                {
                    textBox10.Text = "";
                    pictureBox1.Image = null;
                } ) );
                Thread.Sleep( 100 );

                if (sAMTcpNet.SelectCard( ).IsSuccess)
                {
                    OperateResult<IdentityCard> read = sAMTcpNet.ReadCard( );
                    if (read.IsSuccess)
                    {
                        Invoke( new Action<IdentityCard>( m =>
                        {
                            textBox10.Text = read.Content.ToString( );
                            //MemoryStream stream = new MemoryStream( read.Content.Portrait );
                            //Bitmap bitmap = new Bitmap( stream );
                            //stream.Dispose( );
                            //pictureBox1.Image?.Dispose( );
                            //pictureBox1.Image = bitmap;
                        } ), read.Content );
                    }
                    else
                    {
                        Invoke( new Action( ( ) =>
                        {
                            textBox10.Text = $"读卡失败：{read.Message}";
                        } ) );
                    }
                }
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
