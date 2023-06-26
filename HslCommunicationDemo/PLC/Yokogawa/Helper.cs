using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Yokogawa
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetYokogawaAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "X0",     "Input relay 输入继电器",           true, false, "十进制地址" ),
				new DeviceAddressExample( "Y0",     "Output relay 输出继电器",           true, false, "" ),
				new DeviceAddressExample( "M0",     "Special relay 特殊继电器",           true, false, "" ),
				new DeviceAddressExample( "I0",     "Internal relay 内部继电器",           true, false, "" ),
				new DeviceAddressExample( "E0",     "Shared relay 共享继电器",           true, false, "" ),
				new DeviceAddressExample( "T0",     "Timer relay 定时器",           true, false, "定时器线圈" ),
				new DeviceAddressExample( "C0",     "Counter relay 计数器",           true, false, "计数器线圈" ),
				new DeviceAddressExample( "L0",     "Link relay 链接继电器",           true, false, "" ),
				new DeviceAddressExample( "D0",     "Data register 数据寄存器",           false, true, "" ),
				new DeviceAddressExample( "B0",     "File register 文件寄存器",           false, true, "" ),
				new DeviceAddressExample( "F0",     "Cache register 缓冲寄存器",           false, true, "" ),
				new DeviceAddressExample( "R0",     "Shared register 共享寄存器",           false, true, "" ),
				new DeviceAddressExample( "V0",     "Index register 索引寄存器",           false, true, "" ),
				new DeviceAddressExample( "Z0",     "Special register 特殊寄存器",           false, true, "" ),
				new DeviceAddressExample( "W0",     "Link register 链接寄存器",           false, true, "" ),
				new DeviceAddressExample( "CN0",    "Counter current value 计数器当前值",  false, true, "" ),
				new DeviceAddressExample( "TN0",    "Timer current value 定时器当前值",     false, true, "" ),
				new DeviceAddressExample( "Special:cpu=1;unit=0;slot=1;100",     "特殊模块数据",           false, true, "cpu是可选的，仅支持企业用户调用" ),
			};
		}
	}
}
