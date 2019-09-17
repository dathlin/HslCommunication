using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet.Redis;
using HslCommunication;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormRedisSubscribe : HslFormContent
    {
        public FormRedisSubscribe( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;
        }
        

        private RedisSubscribe redisSubscribe = null;

        private void button1_Click( object sender, EventArgs e )
        {
            try
            {
                List<string> lists = new List<string>( );
                if (!string.IsNullOrEmpty( textBox5.Text )) lists.Add( textBox5.Text );
                if (!string.IsNullOrEmpty( textBox6.Text )) lists.Add( textBox6.Text );
                if (!string.IsNullOrEmpty( textBox7.Text )) lists.Add( textBox7.Text );
                if (!string.IsNullOrEmpty( textBox8.Text )) lists.Add( textBox8.Text );

                if(lists.Count == 0)
                {
                    MessageBox.Show( "没有订阅的关键字！" );
                    return;
                }
                // 连接
                redisSubscribe = new RedisSubscribe( textBox1.Text, int.Parse( textBox2.Text ), lists.ToArray( ) );
                redisSubscribe.Password = textBox3.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "输入错误：" + ex.Message );
                return;
            }
            OperateResult connect = redisSubscribe.CreatePush( ShowSubscribe );

            if(connect.IsSuccess)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;
                MessageBox.Show( StringResources.Language.ConnectServerSuccess );
            }
            else
            {
                MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;

            redisSubscribe.ClosePush( );
        }

        private int count = 0;
       
        private void ShowSubscribe(string key, string content )
        {
            if (InvokeRequired)
            {
                Invoke( new Action<string, string>( ShowSubscribe ), key, content );
                return;
            }

            count++;
            label11.Text = DateTime.Now.ToString( );
            label8.Text = count.ToString( );

            textBox4.AppendText( DateTime.Now.ToString() + " : " + key );
            textBox4.AppendText( Environment.NewLine );
            textBox4.AppendText( content );
            textBox4.AppendText( Environment.NewLine );
            textBox4.AppendText( Environment.NewLine );
        }



        private Random random = new Random( );
      
    }


    #endregion
}
