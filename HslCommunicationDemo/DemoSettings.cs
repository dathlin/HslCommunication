using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo
{
	public class DemoSettings
	{
		public DemoSettings()
		{
			path = Path.Combine( System.Windows.Forms.Application.StartupPath, "DemoSettings.txt" );
		}


		public bool ShowDeviceList { get; set; } = false;
		public bool NewVersionIngored {  get; set; } = false;

		public Point Location { get; set; } = new Point( -1, -1 );
		public Size Size { get; set; } = new Size( 800, 600 );

		/// <summary>
		/// 操作时间是否显示毫秒
		/// </summary>
		public bool ShowTimeOfMilliseconds { get; set; } = false;

		/// <summary>
		/// 窗体是否置顶显示
		/// </summary>
		public bool TopMost { get; set; } = false;

		/// <summary>
		/// 窗体关闭时是否需要确认
		/// </summary>
		public bool ConfirmCloseWindow { get; set; } = false;

		/// <summary>
		/// 窗体的大小是否固定
		/// </summary>
		public bool PenelSizeFixed { get; set; } = false;

		/// <summary>
		/// 界面写入成功后不弹窗显示结果
		/// </summary>
		public bool WriteSuccessNotShowWindow { get; set; } = false;

		/// <summary>
		/// 上传设备的名称，主要是为了让管理员审核的时候能够知道是谁上传的设备信息，方便联系
		/// </summary>
		public string UploadDeviceName { get; set; } = string.Empty;

		/// <summary>
		/// 上传设备的联系方式，主要是为了让管理员审核的时候能够知道是什么设备，方便联系
		/// </summary>
		public string UploadDeviceContact { get; set; } = string.Empty;

		/// <summary>
		/// 显示列表的模式，0：默认，1：A-Z，2：Z-A  点击来回切换
		/// </summary>
		public int RenderListMode { get; set; } = 0;

		public void LoadFiles( )
		{
			lock(lock_settings)
			{
				try
				{
					if (File.Exists( path ))
					{
						JObject json = JObject.Parse( System.IO.File.ReadAllText( path, Encoding.UTF8 ) );
						ShowDeviceList = GetValue( json, nameof( ShowDeviceList ), false );
						NewVersionIngored = GetValue( json, nameof( NewVersionIngored ), false );

						string location = GetValue( json, nameof( Location ), "-1,-1" );
						string[] locations = location.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
						if (locations.Length == 2)
						{
							Location = new Point( int.Parse( locations[0] ), int.Parse( locations[1] ) );
						}

						string size = GetValue( json, nameof( Size ), "800,600" );
						string[] sizes = size.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
						if (sizes.Length == 2)
						{
							Size = new Size( int.Parse( sizes[0] ), int.Parse( sizes[1] ) );
						}

						ConfirmCloseWindow           = GetValue( json, nameof( ConfirmCloseWindow ),        false );
						PenelSizeFixed               = GetValue( json, nameof( PenelSizeFixed ),            false );
						TopMost                      = GetValue( json, nameof( TopMost ),                   false );
						ShowTimeOfMilliseconds       = GetValue( json, nameof( ShowTimeOfMilliseconds ),    false );
						WriteSuccessNotShowWindow    = GetValue( json, nameof( WriteSuccessNotShowWindow ), false );
						UploadDeviceName             = GetValue( json, nameof( UploadDeviceName ),          string.Empty );
						UploadDeviceContact          = GetValue( json, nameof( UploadDeviceContact ),       string.Empty );
						RenderListMode               = GetValue( json, nameof( RenderListMode ),            0 );
					}
				}
				catch
				{

				}
			}
		}

		public void SaveFiles( )
		{
			lock (lock_settings)
			{
				JObject json = new JObject( );
				json.Add( nameof( ShowDeviceList ), ShowDeviceList );
				json.Add( nameof( NewVersionIngored ), NewVersionIngored );
				json.Add( nameof( Location ), $"{Location.X},{Location.Y}" );
				json.Add( nameof( Size ), $"{Size.Width},{Size.Height}" );
				json.Add( nameof( ConfirmCloseWindow ), ConfirmCloseWindow );
				json.Add( nameof( PenelSizeFixed ), PenelSizeFixed );
				json.Add( nameof( TopMost ), TopMost );
				json.Add( nameof( ShowTimeOfMilliseconds ), ShowTimeOfMilliseconds );
				json.Add( nameof( WriteSuccessNotShowWindow ), WriteSuccessNotShowWindow );
				json.Add( nameof( UploadDeviceName ), UploadDeviceName );
				json.Add( nameof( UploadDeviceContact ), UploadDeviceContact );
				json.Add( nameof( RenderListMode ), RenderListMode );
				File.WriteAllText( path, json.ToString( ), Encoding.UTF8 );
			}
		}

		private T GetValue<T>( JObject json, string key, T defaultValue )
		{
			if (json == null) return defaultValue;
			if (json.ContainsKey( key ) == false) return defaultValue;
			return json[key].Value<T>( );
		}

		private object lock_settings = new object();
		private string path = string.Empty;
	}
}
