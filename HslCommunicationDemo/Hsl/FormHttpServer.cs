using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using HslCommunication;
using System.Net;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Reflection;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormHttpServer : HslFormContent
    {
        public FormHttpServer( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            comboBox1.DataSource = new string[]
            {
                "text/html",
                "text/plain",
                "text/xml",
                "application/xml",
                "application/json"
            };

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
            }
            else
            {
            }
        }

        private SiemensS7Net siemens;
        private HttpServer httpServer;

        private void button1_Click( object sender, EventArgs e )
        {
            // 启动服务
            try
            {
                siemens = new SiemensS7Net( SiemensPLCS.S1200, "127.0.0.1" );
                siemens.SetPersistentConnection( );

                httpServer = new HttpServer( );
                httpServer.Start( int.Parse( textBox2.Text ) );
                httpServer.HandleRequestFunc = HandleRequest;
                httpServer.IsCrossDomain = checkBox1.Checked;                        // 是否跨域的设置
                httpServer.RegisterHttpRpcApi( "", this );
                httpServer.RegisterHttpRpcApi( "Siemens", siemens );                 // 注册一个西门子PLC的服务接口的示例
                httpServer.RegisterHttpRpcApi( "TimeOut", typeof( HslTimeOut ) );    // 注册的类的静态方法和静态属性

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Started Failed:" + ex.Message );
            }
        }

        private Dictionary<string, string> returnWeb = new Dictionary<string, string>( );
        private Dictionary<string, string> postWeb = new Dictionary<string, string>( );

        [HslMqttApi( HttpMethod = "POST" )]
        public OperateResult CheckAccount(string name, string password )
        {
            if (name != "admin") return new OperateResult( "用户名错误" );
            if (password != "123456") return new OperateResult( "密码错误" );
            return OperateResult.CreateSuccessResult( );
        }

        [HslMqttApi( HttpMethod = "GET" )]
        public int GetHslCommunication( int id )
        {
            return id + 1;
        }

        private string HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )
        {
            if (request.RawUrl.StartsWith( "/FormHttpServer/" ))
            {
                // /FormHttpServer/CheckAccount            { "name" : "admin", "password" : "123456" }
                return HttpServer.HandleObjectMethod( request, data, this );
            }
            else
            {
                if (request.HttpMethod == "GET")
                {
                    if (returnWeb.ContainsKey( request.RawUrl ))
                    {
                        response.AddHeader( "Content-type", $"Content-Type: {comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                        return returnWeb[request.RawUrl];
                    }
                    else
                    {
                        response.AddHeader( "Content-type", $"Content-Type: {comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                        // return HttpServer.HandleObjectMethod( request, data, this );
                        return "123456";
                    }
                }
                else if (request.HttpMethod == "POST")
                {
                    // POST示例，在data中可以上传复杂的数据，长度不限制的
                    if (postWeb.ContainsKey( request.RawUrl ))
                    {
                        response.AddHeader( "Content-type", $"Content-Type: {comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                        return postWeb[request.RawUrl];
                    }
                }
                else
                {

                }
                return string.Empty;
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            // 设置GET
            if (returnWeb.ContainsKey( textBox5.Text ))
            {
                returnWeb[textBox5.Text] = textBox4.Text;
            }
            else
            {
                returnWeb.Add( textBox5.Text, textBox4.Text );
            }
        }

        private void Button7_Click( object sender, EventArgs e )
        {
            // 设置POST
            if (postWeb.ContainsKey( textBox5.Text ))
            {
                postWeb[textBox5.Text] = textBox4.Text;
            }
            else
            {
                postWeb.Add( textBox5.Text, textBox4.Text );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 请求
            webBrowser1.Url = new Uri( textBox1.Text );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            httpServer?.Close( );
            panel2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox4_TextChanged( object sender, EventArgs e )
        {

        }
    }


    #endregion
}
