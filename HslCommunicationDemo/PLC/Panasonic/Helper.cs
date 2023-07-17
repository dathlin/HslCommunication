using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Panasonic
{
	internal class Helper
	{
		/// <inheritdoc cref="DeviceNode.GetDeviceAddressExamples"/>
		public static DeviceAddressExample[] GetMCAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",   "外部输入继电器",     true, false, "X33 等同于 X3.3" ),
				new DeviceAddressExample( "Y0",   "外部输出继电器",     true, false, "Y33 等同于 Y3.3" ),
				new DeviceAddressExample( "R2.1", "内部继电器",         true, false, "R21 等同于 R2.1" ),
				new DeviceAddressExample( "TN0",  "定时器(当前值)",     true, false, "读写字" ),
				new DeviceAddressExample( "TS0",  "定时器(触点)",       true, false, "读写bool" ),
				new DeviceAddressExample( "CN0",  "计数器(当前值)",     true, false, "读写字" ),
				new DeviceAddressExample( "CS0",  "计数器(触点)",       true, false, "读写bool" ),
				new DeviceAddressExample( "L2.1", "链接继电器",         true, false, "L21 等同于 L2.1" ),
				new DeviceAddressExample( "D0",   "数据寄存器 DT",      false, true, "" ),
				new DeviceAddressExample( "LD0",  "链接寄存器 LD",      false, true, "" ),
				new DeviceAddressExample( "SD0",  "特殊数据寄存器",     false, true, "" ),
			};
		}

		/// <inheritdoc cref="DeviceNode.GetDeviceAddressExamples"/>
		public static DeviceAddressExample[] GetMewtocolAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",    "外部输入继电器", true, false, "X33 等同于 X3.3" ),
				new DeviceAddressExample( "Y0",    "外部输出继电器", true, false, "Y33 等同于 Y3.3" ),
				new DeviceAddressExample( "R2.1",  "内部继电器",     true, false, "R21 等同于 R2.1" ),
				new DeviceAddressExample( "SR2.1", "特殊内部继电器", true, false, "SR21 等同于 SR2.1" ),
				new DeviceAddressExample( "T0",    "定时器",         true, false, "" ),
				new DeviceAddressExample( "C0",    "计数器",         true, false, "" ),
				new DeviceAddressExample( "L2.1",  "链接继电器",     true, false, "L21 等同于 L2.1" ),
				new DeviceAddressExample( "D0",    "数据寄存器 DT",  false, true, "" ),
				new DeviceAddressExample( "LD0",   "链接寄存器 LD",  false, true, "" ),
				new DeviceAddressExample( "F0",    "文件寄存器 FL",  false, true, "" ),
				new DeviceAddressExample( "S0",    "目标值 SV",      false, true, "" ),
				new DeviceAddressExample( "K0",    "经过值 EV",      false, true, "" ),
				new DeviceAddressExample( "IX",    "索引寄存器 IX",  false, true, "" ),
				new DeviceAddressExample( "IY",    "索引寄存器 IY",  false, true, "" ),
				new DeviceAddressExample( "s=2;R2.1",  "内部继电器",     true, false, "支持额外指定其他的站号信息" ),
			};
		}
	}
}
