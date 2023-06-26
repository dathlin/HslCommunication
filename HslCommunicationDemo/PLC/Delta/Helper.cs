using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Delta
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetDeviceAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "ES/EX/SS 系列", "", false, false, "", true ),
				new DeviceAddressExample( "S0-S127", "", true, false, "" ),
				new DeviceAddressExample( "X0-X177", "输入继电器", true, false, "只读操作，地址8进制" ),
				new DeviceAddressExample( "Y0-Y177", "输出继电器", true, false, "地址8进制" ),
				new DeviceAddressExample( "T0-T127", "定时器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "C0-C127 C232-C255", "计数器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "M0-M1279", "内部继电器", true, false, "" ),
				new DeviceAddressExample( "D0-D1311", "数据寄存器", false, true, "" ),

				new DeviceAddressExample( "SA/SX/SC 系列", "", false, false, "", true ),
				new DeviceAddressExample( "S0-S1023", "", true, false, "" ),
				new DeviceAddressExample( "X0-X177", "输入继电器", true, false, "只读操作，地址8进制" ),
				new DeviceAddressExample( "Y0-Y177", "输出继电器", true, false, "地址8进制" ),
				new DeviceAddressExample( "T0-T255", "定时器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "C0-C199 C200-C255", "计数器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "M0-M4095", "内部继电器", true, false, "" ),
				new DeviceAddressExample( "D0-D4999", "数据寄存器", false, true, "" ),

				new DeviceAddressExample( "SA/SX/SC 系列", "", false, false, "", true ),
				new DeviceAddressExample( "S0-S1023", "", true, false, "" ),
				new DeviceAddressExample( "X0-X377", "输入继电器", true, false, "只读操作，地址8进制" ),
				new DeviceAddressExample( "Y0-Y377", "输出继电器", true, false, "地址8进制" ),
				new DeviceAddressExample( "T0-T255", "定时器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "C0-C199 C200-C255", "计数器", true, true, "如果是读位，就是通断继电器，如果是读字，就是当前值" ),
				new DeviceAddressExample( "M0-M4095", "内部继电器", true, false, "" ),
				new DeviceAddressExample( "D0-D9999", "数据寄存器", false, true, "" ),
			};
		}
	}
}
