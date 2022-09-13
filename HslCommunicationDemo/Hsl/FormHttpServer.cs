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
using HslCommunication.Profinet.AllenBradley;
using HslCommunication.Reflection;
using HslCommunication.Core;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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

        private AllenBradleyPcccNet pcccNet;
        private SiemensS7Net siemens;
        private HttpServer httpServer;

        private void button1_Click( object sender, EventArgs e )
        {
            // 启动服务
            try
            {
                siemens = new SiemensS7Net( SiemensPLCS.S1200, "127.0.0.1" );
                siemens.SetPersistentConnection( );
                pcccNet = new AllenBradleyPcccNet( "127.0.0.1" );
                pcccNet.SetPersistentConnection( );

                httpServer = new HttpServer( );
                httpServer.Start( int.Parse( textBox2.Text ) );
                httpServer.HandleRequestFunc = HandleRequest;
                httpServer.IsCrossDomain = checkBox1.Checked;                        // 是否跨域的设置
                httpServer.RegisterHttpRpcApi( "", this );
                httpServer.RegisterHttpRpcApi( "Siemens", siemens );                 // 注册一个西门子PLC的服务接口的示例
                httpServer.RegisterHttpRpcApi( "TimeOut", typeof( HslTimeOut ) );    // 注册的类的静态方法和静态属性
                httpServer.RegisterHttpRpcApi( "PCCC", pcccNet );
                httpServer.DealWithHttpListenerRequest = DealWithHttpListenerRequest;
                if (checkBox2.Checked) httpServer.SetLoginAccessControl( new HslCommunication.MQTT.MqttCredential[] {
                new HslCommunication.MQTT.MqttCredential("admin", "123456")} );

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Started Failed:" + ex.Message );
            }
        }

        private void DealWithHttpListenerRequest( HttpListenerRequest request, ISessionContext session )
        {
            // 获取ClientID信息
            string[] values = request.Headers.GetValues( "ClientID" );
            if (values?.Length > 0)
            {
                session.ClientId = values[0];
            }
        }

        private Dictionary<string, string> getWeb = new Dictionary<string, string>( );
        private Dictionary<string, string> postWeb = new Dictionary<string, string>( );
        private Random random = new Random( );

        private void RenderGetPost( )
        {
            List<string> list = new List<string>( );
            foreach (var item in getWeb.Keys)
            {
                list.Add( $"[GET] " + item );
            }
            foreach (var item in postWeb.Keys)
            {
                list.Add( $"[POST] " + item );
            }
            listBox1.DataSource = list;
        }

        [HslMqttApi( HttpMethod = "POST" )]
        public OperateResult CheckAccount( ISessionContext session, string name, string password )
        {
            if (string.IsNullOrEmpty( session.ClientId ))
            {
                if (name != "admin") return new OperateResult( "用户名错误" );
                if (password != "123456") return new OperateResult( "密码错误" );
                return OperateResult.CreateSuccessResult( );
            }
            else
            {
                return new OperateResult( "ClientID: " + session.ClientId );
            }
        }

        [HslMqttApi( HttpMethod = "GET" )]
        public OperateResult CheckAccountChinese( string name, string password )
        {
            if (name != "张三") return new OperateResult( "用户名错误" );
            if (password != "123456") return new OperateResult( "密码错误" );
            return OperateResult.CreateSuccessResult( );
        }

        [HslMqttApi( HttpMethod = "GET" )]
        public OperateResult 检查AccountChinese( string name, string password )
        {
            if (name != "张三") return new OperateResult( "用户名错误" );
            if (password != "123456") return new OperateResult( "密码错误" );
            return OperateResult.CreateSuccessResult( );
        }

        [HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
        public async Task<short> ReadDatabaseAsync( string abc = "123" )
        {
            await Task.Delay( 1000 );
            return await Task.FromResult( short.Parse( abc ) );
        }

        [HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
        public Task WriteDatabaseAsync( string abc = "123" )
        {
            return Task.Delay( 500 );
        }

        [HslMqttApi( HttpMethod = "GET" )]
        public int GetHslCommunication( int id )
        {
            return id + 1;
        }

        [HslMqttApi( HttpMethod = "POST" )]
        public int GetTest( int id )
        {
            return id + 1;
        }

        [HslMqttApi( HttpMethod = "POST" )]
        public string GetJObjectTest( JObject json )
        {
            return json.ToString( );
        }


        [HslMqttApi( "读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度" )]
        public short ReadFloat( ISessionContext context, string address, short length = 12345 )
        {
            // 这里举例，只控制账户hsl才能有效
            if (context?.UserName != "hsl") return -100;
            return (short)random.Next( 10000 );
        }

        [HslMqttApi( "读取设备的信息，address: 设备的地址 length: 读取的数据长度" )]
        public OperateResult<int, string> ReadABC( string address )
        {
            return OperateResult.CreateSuccessResult( random.Next( 1000 ), "成功:" + address );
        }

        private string HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )
        {
            if (request.RawUrl.StartsWith( "/FormHttpServer/" ))
            {
                // /FormHttpServer/CheckAccount            { "name" : "admin", "password" : "123456" }
                return HttpServer.HandleObjectMethod( request, request.RawUrl, data, this, action: null ).Result;
            }
            else
            {
                if (request.HttpMethod == "GET")
                {
                    if (getWeb.ContainsKey( request.RawUrl ))
                    {
                        response.AddHeader( "Content-type", $"{comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                        return getWeb[request.RawUrl];
                    }
                    else
                    {
                        response.AddHeader( "Content-type", $"{comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
                        // return HttpServer.HandleObjectMethod( request, data, this );
                        return "123456";
                    }
                }
                else if (request.HttpMethod == "POST")
                {
                    // POST示例，在data中可以上传复杂的数据，长度不限制的
                    if (postWeb.ContainsKey( request.RawUrl ))
                    {
                        response.AddHeader( "Content-type", $"{comboBox1.SelectedItem.ToString( )}; charset=utf-8" );
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
            if (getWeb.ContainsKey( textBox5.Text ))
            {
                getWeb[textBox5.Text] = textBox4.Text;
            }
            else
            {
                getWeb.Add( textBox5.Text, textBox4.Text );
            }
            RenderGetPost( );

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
            RenderGetPost( );

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
