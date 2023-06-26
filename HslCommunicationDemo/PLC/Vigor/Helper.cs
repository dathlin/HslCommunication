using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Vigor
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetVigorAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",    "输入继电器", true, false, "地址8进制，范围 X0 ~ X377" ),
				new DeviceAddressExample( "Y0",    "输出继电器", true, false, "地址8进制，范围 Y0 ~ Y377" ),
				new DeviceAddressExample( "M0",    "辅助继电器", true, false, "范围 M0 ~ M8191" ),
				new DeviceAddressExample( "S0",    "步进继电器", true, false, "范围 S0 ~ S4095" ),
				new DeviceAddressExample( "SM0",   "特殊继电器", true, false, "范围 SM0 ~ SM511" ),
				new DeviceAddressExample( "TS0",   "定时器触点", true, false, "范围 TS0 ~ TS511" ),
				new DeviceAddressExample( "TC0",   "定时器线圈", true, false, "范围 TC0 ~ TC511" ),
				new DeviceAddressExample( "CS0",   "计数器触点", true, false, "范围 CS0 ~ CS255" ),
				new DeviceAddressExample( "CC0",   "计数器线圈", true, false, "范围 CC0 ~ CC255" ),
				new DeviceAddressExample( "SD0",   "特殊寄存器", false, true, "范围 SD0 ~ SD511" ),
				new DeviceAddressExample( "D0",    "寄存器", false, true, "范围 D0 ~ D8999" ),
				new DeviceAddressExample( "R0",    "R寄存器", false, true, "范围 R0 ~ R25999" ),
				new DeviceAddressExample( "T0",    "定时器当前值", false, true, "范围 T0 ~ T511" ),
				new DeviceAddressExample( "C0",    "计数器当前值", false, true, "16位计数器范围 C0 ~ C199, 32位计数器范围 C200 ~ C255" ),
				new DeviceAddressExample( "s=2;D0",    "寄存器", false, true, "支持额外指定站号信息" ),
			};
		}
	}
}
