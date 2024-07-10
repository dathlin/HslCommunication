using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Invt
{
	public class Helper
	{
		public static DeviceAddressExample[] GetInvtAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0",    "内部继电器",  bit: true, word: false, "M0~M32767" ),
				new DeviceAddressExample( "S0",    "步进继电器",  bit: true, word: false, "S0~S4095" ),
				new DeviceAddressExample( "X0",    "输入继电器",  bit: true, word: false, "X0~X1777  地址8进制" ),
				new DeviceAddressExample( "Y0",    "输出继电器",  bit: true, word: false, "X0~X1777  地址8进制" ),
				new DeviceAddressExample( "T0",    "定时器",      bit: true, word: true, "T0~T399 位读写就是通断，字读写就是当前值" ),
				new DeviceAddressExample( "C0",    "计数器",      bit: true, word: true, "C0~C255 位读写就是通断，字读写就是当前值" ),
				new DeviceAddressExample( "D0",    "数据寄存器",  bit: false, word: true, "D0~D32767" ),
				new DeviceAddressExample( "R0",    "数据寄存器",  bit: false, word: true, "R0~R16383" ),
				new DeviceAddressExample( "Z0",    "变址寄存器",  bit: false, word: true, "Z0~Z15" ),
				new DeviceAddressExample( "s=2;D0", "寄存器",     bit: false, word: true, "支持额外指定站号信息" ),
				new DeviceAddressExample( "D0.4",   "数据寄存器", bit: true, word: false, "支持直接访问寄存器的某个位" ),
			};
		}
	}
}
