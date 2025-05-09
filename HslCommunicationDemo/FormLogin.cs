using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin( )
        {
            InitializeComponent( );
        }

        private void FormLogin_Load( object sender, EventArgs e )
        {
            //textBox1.Text = "admin";
            //textBox2.Text = "123456";

            string name = HslCommunicationDemo.Settings1.Default.LoginName;
            string password = HslCommunicationDemo.Settings1.Default.LoginPassword;

            textBox1.Text = name;
            textBox2.Text = password;

            if (Program.Language == 1)
                label3.Text = Program.SystemName;
            else
            {
                label1.Text = "UserName:";
                label2.Text = "Password:";
                label3.Text = "Industrial equipment debugging system";
                button1.Text = "Login";
            }

        }

        private void button1_Click( object sender, EventArgs e )
        {
            //mqttSyncClient = new MqttSyncClient( new MqttConnectionOptions( )
            //{
            //    IpAddress = "xxx.xxx.xxx.xxx",
            //    Port = 1883,
            //} );




            if (true)
            {
                HslCommunicationDemo.Settings1.Default.LoginName = textBox1.Text;
                HslCommunicationDemo.Settings1.Default.LoginPassword = textBox2.Text;
                HslCommunicationDemo.Settings1.Default.Save( );
                DialogResult = DialogResult.OK;
            }
            else
            {
                DemoUtils.ShowMessage( "用户名或密码错误，请重新输入！" );
            }
        }

        public MqttSyncClient GetMqttSyncClient() { return mqttSyncClient; }

        private MqttSyncClient mqttSyncClient;
    }
}
