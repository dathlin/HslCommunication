using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    static class Program
    {
        /// <summary>
        /// 1代表中文，2代表英文
        /// </summary>
        public static int Language = 1;

        /// <summary>
        /// 是否显示相关的信息
        /// </summary>
        public static bool ShowAuthorInfomation = true;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main( )
        {
            // 授权示例
            if(!HslCommunication.Authorization.SetAuthorizationCode( "你的激活码" ))
            {
                // MessageBox.Show( "授权失败！当前程序只能使用8小时！" );
                // return;
            }


            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );


            System.Threading.ThreadPool.SetMaxThreads( 2000, 800 );
            Application.Run( new FormSelect( ) ); // FormSelect
        }
    }
}
