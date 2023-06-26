using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.DemoControl
{

	/// <summary>
	/// 设备的地址示例
	/// </summary>
	public class DeviceAddressExample
	{
		#region Constructor

		/// <summary>
		/// 实例化一个默认的对象
		/// </summary>
		public DeviceAddressExample( )
		{

		}

		/// <summary>
		/// 指定相关的参数信息来实例化地址示例的对象
		/// </summary>
		/// <param name="address">地址的名称</param>
		/// <param name="type">地址的类型描述</param>
		/// <param name="bit">是否支持位操作</param>
		/// <param name="word">是否支持字操作</param>
		/// <param name="mark">备注</param>
		/// <param name="header">是否是标题栏操作</param>
		/// <param name="fill">是否使用名称信息填充数据标签名</param>
		/// <param name="unit">数据的单位信息</param>
		/// <param name="dataType">默认使用的数据类型，有些数据标签使用固定的读写类型信息时，可以指定</param>
		public DeviceAddressExample( string address, string type, bool bit, bool word, string mark, bool header = false, bool fill = false, string unit = "", string dataType = "" )
		{
			this.AddressExample = address;
			this.AddressType = type;
			this.BitEnable = bit;
			this.WordEnable = word;
			this.Mark = mark;
			this.IsHeader = header;
			this.FillTagNameWithAddressType = fill;
			this.Unit = unit;
			this.DataType = dataType;
		}

		#endregion

		/// <summary>
		/// 示例的地址
		/// </summary>
		public string AddressExample { get; set; }

		/// <summary>
		/// 地址类型说明
		/// </summary>
		public string AddressType { get; set; }

		/// <summary>
		/// 是否支持位操作
		/// </summary>
		public bool BitEnable { get; set; }

		/// <summary>
		/// 是否支持字操作
		/// </summary>
		public bool WordEnable { get; set; }

		/// <summary>
		/// 标记信息
		/// </summary>
		public string Mark { get; set; }

		/// <summary>
		/// 当前的地址信息是否是标题栏信息
		/// </summary>
		public bool IsHeader { get; set; }

		/// <summary>
		/// 当前数据的单位，有些特殊的设备可以指定单位信息
		/// </summary>
		public string Unit { get; set; }

		/// <summary>
		/// 是否使用地址名称信息填入节点名称信息
		/// </summary>
		public bool FillTagNameWithAddressType { get; set; } = false;

		/// <summary>
		/// 默认使用的数据类型，有些数据标签使用固定的读写类型信息时，可以指定
		/// </summary>
		public string DataType { get; set; }

		/// <inheritdoc/>
		public override string ToString( ) => $"DeviceAddressExample[{AddressExample}]";



		/// <summary>
		/// 获取标题信息
		/// </summary>
		/// <returns></returns>
		public static string GetTitle( ) => Program.Language == 1 ? "地址示例" : "Address Example";

	}
}
