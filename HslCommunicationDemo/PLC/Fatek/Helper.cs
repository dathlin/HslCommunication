using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Fatek
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetDeviceAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M100",  "内部继电器",     true, true, "范围 M0 ~ M9999" ),
				new DeviceAddressExample( "X10",   "输入继电器",     true, true, "范围 X0 ~ X9999" ),
				new DeviceAddressExample( "Y10",   "输出继电器",     true, true, "范围 Y0 ~ Y9999" ),
				new DeviceAddressExample( "S100",  "步进继电器",     true, true, "范围 S0 ~ S9999" ),
				new DeviceAddressExample( "T100",  "定时器的触点",   true, true, "范围 T0 ~ T9999" ),
				new DeviceAddressExample( "RT100", "定时器的当前值", false, true, "范围 RT0 ~ RT9999" ),
				new DeviceAddressExample( "C100",  "计数器的触点",   true, true, "范围 C0 ~ C9999" ),
				new DeviceAddressExample( "RC100", "计数器的当前",   false, true, "范围 RC0 ~ RC9999" ),
				new DeviceAddressExample( "D100",  "数据寄存器",     false, true, "范围 D0 ~ D65535" ),
				new DeviceAddressExample( "R100",  "文件寄存器",     false, true, "范围 R0 ~ R65535" ),
				new DeviceAddressExample( "s=2;M100",  "内部继电器",     true, true, "以上所有地址支持额外地址站号信息" ),
			};
		}
	}
}
