using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo.Algorithms
{
    public partial class FormConnectPool : HslFormContent
    {
        public FormConnectPool( )
        {
            InitializeComponent( );
        }

        private void FormConnectPool_Load( object sender, EventArgs e )
        {
            label1.Text = "我们都知道线程池是为了高效的利用线程资源而设计的，此处的连接池也是为了高效的使用连接对象设计的，这个连接对象可以是任何的东西，西门子PLC，Modbus Tcp，Redis，数据库，自定义的连接等等。"+
                "主需要服务器端支持多连接即可，比如三菱的端口就不支持多连接的功能，所以不能使用连接池。本节目的代码是演示了一个西门子连接池，根据案例可以扩充其他的连接池。";





            siemensConnect = new HslCommunication.Algorithms.ConnectPool.ConnectPool<SiemensConnector>( ( ) => { return new SiemensConnector( "192.168.1.195" ); } );
            siemensConnect.MaxConnector = 10;         // 同时存在的最大连接数
            siemensConnect.ConectionExpireTime = 30;  // 连接多久不用就自动回收释放，单位秒
            
        }



        private HslCommunication.Algorithms.ConnectPool.ConnectPool<SiemensConnector> siemensConnect = null;           // 西门子对象的连接池

        private void button1_Click( object sender, EventArgs e )
        {
            // 这里的代码在单线程程序情况下，没有什么效果，但是在多线程情况下可以显著提升性能。
            // 举例，此处要访问PLC的一个数据
            SiemensConnector connector = siemensConnect.GetAvailableConnector( );
            short m100 = connector.GetSiemens( ).ReadInt16( "M100" ).Content;

            // 使用完毕后归还连接
            siemensConnect.ReturnConnector( connector );


            int online = siemensConnect.UsedConnector;
        }
    }



    public class SiemensConnector : HslCommunication.Algorithms.ConnectPool.IConnector
    {
        #region 构造方法

        public SiemensConnector( string ipAddress )
        {
            siemens = new HslCommunication.Profinet.Siemens.SiemensS7Net( HslCommunication.Profinet.Siemens.SiemensPLCS.S1200, ipAddress );
        }

        #endregion

        #region IConnector 实现


        /// <summary>
        /// 指示当前的连接是否在使用用
        /// </summary>
        public bool IsConnectUsing { get; set; }


        /// <summary>
        /// 唯一的GUID码
        /// </summary>
        public string GuidToken { get; set; }


        /// <summary>
        /// 最新一次使用的时间
        /// </summary>
        public DateTime LastUseTime { get; set; }


        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open( )
        {
            // 设置常连接。如果是Redis，可以连接服务器，数据库也是一样
            siemens.ConnectServer( );
        }


        /// <summary>
        /// 关闭并释放
        /// </summary>
        public void Close( )
        {
            // 关闭连接
            siemens.ConnectClose( );
        }

        #endregion

        #region Public Member

        /// <summary>
        /// 获取当前的连接对象，方便进行数据交互
        /// </summary>
        /// <returns></returns>
        public HslCommunication.Profinet.Siemens.SiemensS7Net GetSiemens( )
        {
            return siemens;
        }

        #endregion


        #region Private Member

        private HslCommunication.Profinet.Siemens.SiemensS7Net siemens;        // 连接对象

        #endregion
    }



}
