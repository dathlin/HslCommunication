using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.MegMeet
{
	internal class Helper
	{
		/// <summary>
		/// 获取MC协议的地址示例
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetMegMeetAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",  "输入继电器",       true, false, "地址8进制，范围 X0 ~ X377" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, false, "地址8进制，范围 Y0 ~ Y377" ),
				new DeviceAddressExample( "M0",  "内部继电器",       true, false, "范围 M0 ~ M10239" ),
				new DeviceAddressExample( "SM0", "特殊继电器",       true, false, "范围 SM0 ~ SM511" ),
				new DeviceAddressExample( "S0",  "状态继电器",       true, false, "范围 S0 ~ S4095" ),
				new DeviceAddressExample( "T0",  "定时器状态",       true, false, "范围 T0 ~ T511" ),
				new DeviceAddressExample( "C0",  "计数器状态",       true, false, "范围 C0 ~ C511" ),
				new DeviceAddressExample( "D0",  "数据寄存器",       false, true, "范围 D0 ~ D7999" ),
				new DeviceAddressExample( "SD0", "特殊寄存器",       false, true, "范围 SD0 ~ SD511" ),
				new DeviceAddressExample( "Z0",  "变址寄存器",       false, true, "范围 Z0 ~ Z15" ),
				new DeviceAddressExample( "T0",  "定时器当前值",     false, true, "读写字，范围 T0 ~ T511" ),
				new DeviceAddressExample( "C0",  "计数器当前值",     false, true, "读写字，字范围 C0 ~ C199 双字 C200 ~ C306" ),
				new DeviceAddressExample( "R0",  "文件寄存器",       false, true, "R0 ~ R32767" ),
				new DeviceAddressExample( "s=2;D0",  "数据寄存器",       false, true, "可以额外指定站号访问" ),
			};
		}

	}
}
