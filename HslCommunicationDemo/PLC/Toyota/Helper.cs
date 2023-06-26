using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Toyota
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetToyotaAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "K0",    "保持继电器", true, true, "地址使用16进制，范围 K0 ~ K2FF" ),
				new DeviceAddressExample( "V0",    "特殊继电器", true, true, "地址使用16进制，范围 V0 ~ VFF" ),
				new DeviceAddressExample( "T0",    "定时器",     true, true, "地址使用16进制，范围 T0 ~ T1FF" ),
				new DeviceAddressExample( "C0",    "计数器",     true, true, "地址使用16进制，范围 C0 ~ C1FF" ),
				new DeviceAddressExample( "L0",    "链接继电器", true, true, "地址使用16进制，范围 L0 ~ L7FF" ),
				new DeviceAddressExample( "X0",    "输入继电器", true, true, "地址使用16进制，范围 X0 ~ X7FF" ),
				new DeviceAddressExample( "Y0",    "输出继电器", true, true, "地址使用16进制，范围 Y0 ~ Y7FF" ),
				new DeviceAddressExample( "M0",    "内部继电器", true, true, "地址使用16进制，范围 M0 ~ M7FF" ),
				new DeviceAddressExample( "S0",    "特殊寄存器", false, true, "地址使用16进制，范围 S0 ~ S3FF" ),
				new DeviceAddressExample( "N0",    "定时器计数器当前值", false, true, "地址使用16进制，范围 N0 ~ N1FF" ),
				new DeviceAddressExample( "R0",    "链接寄存器", false, true, "地址使用16进制，范围 R0 ~ R7FF" ),
				new DeviceAddressExample( "D0",    "数据寄存器", false, true, "地址使用16进制，范围 D0 ~ D2FFF" ),
				new DeviceAddressExample( "B0",    "文件寄存器", false, true, "地址使用16进制，范围 B0 ~ B1FFF" ),
				new DeviceAddressExample( "EK0",    "扩展保持继电器", true, true, "地址使用16进制，范围 EK0 ~ EKFFF" ),
				new DeviceAddressExample( "EV0",    "扩展特殊继电器", true, true, "地址使用16进制，范围 EV0 ~ EVFFF" ),
				new DeviceAddressExample( "ET0",    "扩展定时器",     true, true, "地址使用16进制，范围 ET0 ~ ET7FF" ),
				new DeviceAddressExample( "EC0",    "扩展计数器",     true, true, "地址使用16进制，范围 EC0 ~ EC7FF" ),
				new DeviceAddressExample( "EL0",    "扩展链接继电器", true, true, "地址使用16进制，范围 EL0 ~ EL1FFF" ),
				new DeviceAddressExample( "EX0",    "扩展输入继电器", true, true, "地址使用16进制，范围 EX0 ~ EX7FF" ),
				new DeviceAddressExample( "EY0",    "扩展输出继电器", true, true, "地址使用16进制，范围 EY0 ~ EY7FF" ),
				new DeviceAddressExample( "EM0",    "扩展内部继电器", true, true, "地址使用16进制，范围 EM0 ~ EM1FFF" ),
				new DeviceAddressExample( "ES0",    "扩展特殊寄存器", false, true, "地址使用16进制，范围 ES0 ~ ES7FF" ),
				new DeviceAddressExample( "ENO",    "扩展当前值寄存器", false, true, "地址使用16进制，范围 EN0 ~ EN7FF" ),
				new DeviceAddressExample( "H0",    "扩展设置定寄存器", false, true, "地址使用16进制，范围 H0 ~ H7FF" ),
				new DeviceAddressExample( "U0",    "扩展数据寄存器", false, true, "地址使用16进制，范围 U0 ~ U7FFF" ),
				new DeviceAddressExample( "GX0",    "扩展输入继电器", false, true, "地址使用16进制，范围 GX0 ~ GXFFFF" ),
				new DeviceAddressExample( "GY0",    "扩展输出继电器", false, true, "地址使用16进制，范围 GY0 ~ GYFFFF" ),
				new DeviceAddressExample( "GM0",    "扩展内部继电器", false, true, "地址使用16进制，范围 GM0 ~ GMFFFF" ),
				new DeviceAddressExample( "EB0",    "扩展文件寄存器", false, true, "范围 EB0 ~ EB7FFF, EB8000 ~ EBFFFF, EB10000 ~ EB17FFF, EM18000 ~ EB1FFFF" ),
				new DeviceAddressExample( "prg=1;D0", "指定程序号的数据寄存器", false, true, "上述所有非扩展地址均支持另外指定程序号参数" ),
			};
		}
	}
}
