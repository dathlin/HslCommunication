using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	/// <summary>
	/// 全局的设备管理类
	/// </summary>
	public class DemoDevice
	{
		public static void AddDevice( string guid, string name, HslCommunication.Core.Net.BinaryCommunication device, Image image, 
			DataTableControl dataTableControl = null, CodeExampleControl codeExampleControl = null )
		{
			lock (Devices)
			{
				if (Devices.ContainsKey( guid )) Devices.Remove( guid );
				Devices.Add( guid, new DemoDeviceItem( ) { Guid = guid, Name = name, Device = device, DeviceImage = image, DataTableControl = dataTableControl, CodeExampleControl = codeExampleControl } );
			}
		}

		public static void RemoveDevice( string guid )
		{
			lock (Devices)
			{
				if (Devices.ContainsKey( guid )) Devices.Remove( guid );
			}
		}



		public static Dictionary<string, DemoDeviceItem> Devices = new Dictionary<string, DemoDeviceItem>( );


		public static void LoadDevice( DataGridView dataGridView )
		{
			List<DemoDeviceItem> devices;
			lock (DemoDevice.Devices)
			{
				devices = DemoDevice.Devices.Values.ToList( );
			}
			DemoUtils.DataGridSpecifyRowCount( dataGridView, devices.Count );
			for (int i = 0; i < devices.Count; i++)
			{
				DataGridViewRow row = dataGridView.Rows[i];
				row.Cells[0].Value = (i + 1).ToString( );
				row.Cells[1].Value = devices[i].DeviceImage;
				row.Cells[2].Value = devices[i].Guid;
				row.Cells[3].Value = devices[i].Name;
				row.Cells[4].Value = devices[i].Device.ToString( );
				row.Tag = devices[i];
			}

			if (devices.Count > 0)
			{
				dataGridView.Rows[0].Selected = true;
			}
		}
	}

	public class DemoDeviceItem
	{
		public Image DeviceImage { get; set; }

		public string ApiName { get; set; }

		public string Guid { get; set; }

		public string Name { get; set; }

		public HslCommunication.Core.Net.BinaryCommunication Device { get; set; }

		public DataTableControl DataTableControl { get; set; }

		/// <summary>
		/// 设备实例化的代码示例控件，如果为空，则表示当前协议不支持
		/// </summary>
		public CodeExampleControl CodeExampleControl { get; set; }
	}

	public class DemoDeviceAddressItem
	{
		/// <summary>
		/// 名称或是主题
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 地址信息
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 数据类型
		/// </summary>
		public string DataType { get; set; }

		/// <summary>
		/// 长度信息
		/// </summary>
		public int Length { get; set; }


		public string GetTopic()
		{
			if ( string.IsNullOrEmpty(Name) )
			{
				return Address;
			}
			return Name;
		}

	}
}
