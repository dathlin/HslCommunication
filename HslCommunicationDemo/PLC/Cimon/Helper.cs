using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Cimon
{
	public class Helper
	{
		/// <summary>
		/// 获取CIMON的地址示例
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetCimonAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",  "输入继电器",       true, false, "范围 X0 ~ X511F, 也可以写成 X100.0" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, false, "范围 Y0 ~ Y511F, 也可以写成 Y100.0" ),
				new DeviceAddressExample( "M0",  "内部继电器",       true, false, "范围 M0 ~ M999F, 也可以写成 M100.0" ),
				new DeviceAddressExample( "K0",  "Keep继电器",       true, false, "范围 K0 ~ K999F, 也可以写成 K100.0" ),
				new DeviceAddressExample( "L0",  "Link继电器",       true, false, "范围 L0 ~ L999F, 也可以写成 L100.0" ),
				new DeviceAddressExample( "T0",  "定时器状态",       true, false, "范围 T0 ~ T4095, 也可以写成 T100.0" ),
				new DeviceAddressExample( "C0",  "计数器状态",       true, false, "范围 C0 ~ C4095, 也可以写成 C100.0" ),
				new DeviceAddressExample( "F0",  "Internal Flag",   true, false, "范围 F0 ~ F999F, 也可以写成 F100.0" ),
				new DeviceAddressExample( "D100.1",  "数据寄存器",       true, false, "可以读取数据寄存器的位" ),



				new DeviceAddressExample( "X0",  "输入继电器",       false, true, "读写字，范围 X0 ~ X511" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       false, true, "读写字，范围 Y0 ~ Y511" ),
				new DeviceAddressExample( "M0",  "内部继电器",       false, true, "读写字，范围 M0 ~ M511" ),
				new DeviceAddressExample( "K0",  "Keep继电器",       false, true, "读写字，范围 K0 ~ K511" ),
				new DeviceAddressExample( "L0",  "Link继电器",       false, true, "读写字，范围 L0 ~ L511" ),
				new DeviceAddressExample( "TC0",  "定时器当前值",     false, true, "读写字，范围 TC0 ~ TC4095" ),
				new DeviceAddressExample( "CC0",  "计数器当前值",     false, true, "读写字，范围 CC0 ~ CC4095" ),
				new DeviceAddressExample( "TS0",  "定时器",     false, true, "读写字，范围 TS0 ~ TS4095" ),
				new DeviceAddressExample( "CS0",  "计数器",     false, true, "读写字，范围 CS0 ~ CS4095" ),
				new DeviceAddressExample( "D0",  "数据寄存器",       false, true, "范围 D0 ~ D31999" ),
				new DeviceAddressExample( "F0",  "F寄存器",       false, true, "范围 F0 ~ F127" ),
				new DeviceAddressExample( "Z0",  "Z寄存器",       false, true, "范围 Z0 ~ Z127" ),
				new DeviceAddressExample( "S0",  "S寄存器",       false, true, "范围 S0 ~ S99" ),


				new DeviceAddressExample( "f=2;D0",  "数据寄存器",       false, true, "可以额外指定frame站号信息" ),
			};
		}
	}
}
