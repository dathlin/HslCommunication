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
