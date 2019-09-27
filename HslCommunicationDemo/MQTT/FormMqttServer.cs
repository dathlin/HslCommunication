using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.MQTT;
using HslCommunication;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormMqttServer : HslFormContent
    {
        public FormMqttServer( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;

            Language( Program.Language );

            timer1s = new Timer( );
            timer1s.Interval = 1000;
            timer1s.Tick += Timer1s_Tick;
            timer1s.Start( );
        }

        private void Timer1s_Tick( object sender, EventArgs e )
        {
            if (mqttServer != null)
            {
                label2.Text = "Online Count:" + mqttServer.OnlineCount;
            }
        }

        private Timer timer1s;

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "Mqtt服务器";
                label3.Text = "端口：";
                button1.Text = "启动服务";
                button2.Text = "关闭服务";
                button5.Text = "广播指定ip";
                label7.Text = "Topic：";
                label8.Text = "主题";
                label9.Text = "Payload：";
                button3.Text = "广播所有";
                button4.Text = "清空";
                label12.Text = "接收：";
            }
            else
            {
                Text = "Mqtt Test";
                label3.Text = "Port:";
                button1.Text = "Start";
                button2.Text = "Close";
                button5.Text = "Publish Id";
                label7.Text = "Topic:";
                label8.Text = "";
                label9.Text = "Payload:";
                button3.Text = "Publish all";
                button4.Text = "Clear";
                label12.Text = "Receive:";
            }
        }

        private MqttServer mqttServer;

        private void button1_Click( object sender, EventArgs e )
        {
            try
            {
                mqttServer = new MqttServer( );
                mqttServer.OnClientApplicationMessageReceive += MqttServer_OnClientApplicationMessageReceive;
                if (checkBox1.Checked)
                {
                    mqttServer.ClientVerification += MqttServer_ClientVerification;
                }

                mqttServer.ServerStart( int.Parse( textBox2.Text ) );
                mqttServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
                mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;
                MessageBox.Show( "Start Success" );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Start Failed : " + ex.Message );
            }
        }

        private int MqttServer_ClientVerification( string clientId, string userName, string passwrod )
        {
            if(userName == "admin" && passwrod == "123456")
            {
                return 0; // 成功
            }
            else
            {
                return 5; // 账号密码验证失败
            }
        }

        private void MqttServer_OnClientApplicationMessageReceive( MqttClientApplicationMessage message )
        {
            Invoke( new Action( ( ) =>
            {
                textBox8.AppendText( $"Cliend Id[{message.ClientId}] Topic:[{message.Topic}] Payload:[{Encoding.UTF8.GetString( message.Payload )}]" + Environment.NewLine );
            } ) );
        }

        private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
        {
            Invoke( new Action( ( ) =>
             {
                 textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
             } ) );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;

            mqttServer.ServerClose( );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            mqttServer.PublishAllClientTopicPayload( textBox5.Text, Encoding.UTF8.GetBytes( textBox4.Text ) );
        }



        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox8.Clear( );
        }

        private void Button5_Click( object sender, EventArgs e )
        {
            mqttServer.PublishTopicPayload( textBox1.Text, textBox5.Text, Encoding.UTF8.GetBytes( textBox4.Text ) );
        }

        private void button6_Click_1( object sender, EventArgs e )
        {
            mqttServer.PublishTopicPayload( textBox5.Text, Encoding.UTF8.GetBytes( textBox4.Text ) );
        }
    }


    #endregion
}
