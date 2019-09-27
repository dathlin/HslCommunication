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


    public partial class FormMqttClient : HslFormContent
    {
        public FormMqttClient( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;

            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "Mqtt客户端";
                label1.Text = "Ip地址：";
                label3.Text = "端口号：";
                button1.Text = "连接";
                button2.Text = "断开连接";
                button5.Text = "最少一次";
                button6.Text = "刚好一次";
                label7.Text = "Topic：";
                label8.Text = "主题";
                label9.Text = "Payload：";
                button3.Text = "最多一次";
                button4.Text = "清空";
                label12.Text = "接收：";
            }
            else
            {
                Text = "Mqtt Test";
                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                button5.Text = "least one";
                button6.Text = "exact one";
                label7.Text = "Topic:";
                label8.Text = "";
                label9.Text = "Payload:";
                button3.Text = "most one";
                button4.Text = "Clear";
                label12.Text = "Receive:";
            }
        }

        private MqttClient mqttClient;

        private void button1_Click( object sender, EventArgs e )
        {
            panel2.Enabled = true;
            // 连接
            MqttConnectionOptions options = new MqttConnectionOptions( )
            {
                IpAddress = textBox1.Text,
                Port = int.Parse( textBox2.Text ),
                ClientId = textBox3.Text,
            };
            if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
            {
                options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
            }

            mqttClient = new MqttClient( options );
            mqttClient.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );
            mqttClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

            OperateResult connect = mqttClient.ConnectServer( );

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

        private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
        {
            try
            {
                Invoke( new Action( ( ) =>
                 {
                     textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
                 } ) );
            }
            catch
            {

            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;

            mqttClient.ConnectClose( );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( )
            {
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
                Topic = textBox5.Text,
                Payload = Encoding.UTF8.GetBytes( textBox4.Text )
            } );

            if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
        }



        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox8.Clear( );
        }

        private void Button5_Click( object sender, EventArgs e )
        {
            OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( )
            {
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
                Topic = textBox5.Text,
                Payload = Encoding.UTF8.GetBytes( textBox4.Text )
            } );

            if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
        }

        private void Button6_Click( object sender, EventArgs e )
        {
            OperateResult send = mqttClient.PublishMessage( new MqttApplicationMessage( )
            {
                QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce,
                Topic = textBox5.Text,
                Payload = Encoding.UTF8.GetBytes( textBox4.Text )
            } );

            if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
        }

        private void Button7_Click( object sender, EventArgs e )
        {
            OperateResult send = mqttClient.SubscribeMessage( textBox5.Text );


            if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
        }

        private void Button8_Click( object sender, EventArgs e )
        {
            OperateResult send = mqttClient.UnSubscribeMessage( textBox5.Text );


            if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
        }
    }


    #endregion
}
