using System;
using System.Collections.Generic;
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
