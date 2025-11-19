using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Secs.Types;
using HslCommunicationDemo.Properties;

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

		public static bool IsActive { get; private set; }

		public static DateTime StartTime = DateTime.Now;

		public static string SystemName = "欢迎登录HSL调试平台"; // "工业设备联网调试系统";

		public static DemoSettings Settings { get; private set; }

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main( )
		{
			Settings = new DemoSettings( );
			Settings.LoadFiles( );
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			// 授权示例   Authorization Example
			if (!HslCommunication.Authorization.SetAuthorizationCode( "Your Code" ))
			{
				// active failed
				// DemoUtils.ShowMessage( "授权失败！当前程序只能使用24小时！" );
				// return;
			}
			else
			{
				// active success
				// DemoUtils.ShowMessage( "授权成功！" );
				IsActive = true;
			}

			// 如果使用证书的情况
			//OperateResult active = HslCommunication.Authorization.SetHslCertificate( File.ReadAllBytes( "hsl.cert" ) );
			//if (active.IsSuccess)
			//{
			//	// active success
			//	DemoUtils.ShowMessage( "active success！" );
			//}
			//else
			//{
			//	// active failed
			//	DemoUtils.ShowMessage( "active failed: " + active.Message );
			//}
			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );

			System.Threading.ThreadPool.SetMaxThreads( 2000, 800 );
			Application.Run( new FormMain( ) ); // FormSelect
		}

		private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
		{
			Exception ex = e.ExceptionObject as Exception;
			System.IO.File.WriteAllText( "123.txt", HslCommunication.BasicFramework.SoftBasic.GetExceptionMessage( ex ) );
		}
	}
}
