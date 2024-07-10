using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.WeCon
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetWeConLx5vAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "T0",    "定时器", bit: true, word: true, "T0~T511 位读写就是通断，字读写就是当前值" ),
				new DeviceAddressExample( "C0",    "计数器", bit: true, word: true, "C0~C255 位读写就是通断，字读写就是当前值" ),
				new DeviceAddressExample( "LC0",   "长计数器", bit: true, word: true, "LC0~LC255 位读写就是通断，int32读写就是当前值" ),
				new DeviceAddressExample( "HSC0",  "高速计数器", bit: true, word: true, "HSC0~HSC15 位读写就是通断，int32读写就是当前值" ),
				new DeviceAddressExample( "M0",    "内部继电器", bit: true, word: false, "M0~M8000" ),
				new DeviceAddressExample( "SM0",   "特殊继电器", bit: true, word: false, "SM0~SM4095" ),
				new DeviceAddressExample( "S0",    "步进继电器", bit: true, word: false, "S0~S4095" ),
				new DeviceAddressExample( "X0",    "输入继电器", bit: true, word: false, "X0~X1777  地址8进制" ),
				new DeviceAddressExample( "Y0",    "输出继电器", bit: true, word: false, "X0~X1777  地址8进制" ),
				new DeviceAddressExample( "D0",    "数据寄存器", bit: false, word: true, "D0~D7999" ),
				new DeviceAddressExample( "SD0",   "特殊寄存器", bit: false, word: true, "SD0~SD4095" ),
				new DeviceAddressExample( "R0",    "数据寄存器", bit: false, word: true, "R0~R30000" ),
				new DeviceAddressExample( "s=2;D0", "寄存器", bit: false, word: true, "支持额外指定站号信息" ),
				new DeviceAddressExample( "D0.4",   "数据寄存器", bit: true, word: false, "支持直接访问寄存器的某个位" ),
			};
		}
	}
}
