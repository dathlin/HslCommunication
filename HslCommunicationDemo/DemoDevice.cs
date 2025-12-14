using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo
{
	/// <summary>
	/// 全局的设备管理类
	/// </summary>
	public class DemoDevice
	{



		public static void AddDevice( string guid, string name, HslCommunication.Core.Net.BinaryCommunication device )
		{
			if (Devices.ContainsKey( guid )) Devices.Remove( guid );
			Devices.Add( guid, new DemoDeviceItem( ) { Guid = guid, Name = name, Device = device } );
		}

		public static void RemoveDevice( string guid )
		{
			if (Devices.ContainsKey( guid )) Devices.Remove( guid );
		}



		public static Dictionary<string, DemoDeviceItem> Devices = new Dictionary<string, DemoDeviceItem>( );
	}

	public class DemoDeviceItem
	{
		public string ApiName { get; set; }

		public string Guid { get; set; }

		public string Name { get; set; }

		public HslCommunication.Core.Net.BinaryCommunication Device { get; set; }
	}
}
