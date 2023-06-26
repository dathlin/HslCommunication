using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Fuji
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetSPBAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0", "内部继电器", true, true, "读写字单位的时候，M2代表位的M32" ),
				new DeviceAddressExample( "X0", "输入继电器", true, true, "读写字单位的时候，X2代表位的X32" ),
				new DeviceAddressExample( "Y0", "输出继电器", true, true, "读写字单位的时候，Y2代表位的Y32" ),
				new DeviceAddressExample( "L0", "锁存继电器	", true, true, "" ),
				new DeviceAddressExample( "TC0", "定时器的线圈", true, true, "" ),
				new DeviceAddressExample( "TN0", "定时器的当前值", false, true, "" ),
				new DeviceAddressExample( "CC0", "计数器的线圈", true, true, "" ),
				new DeviceAddressExample( "CN0", "计数器的当前", false, true, "" ),
				new DeviceAddressExample( "D0", "数据寄存器", true, true, "读位的时候，D10.15代表第10个字的第15位" ),
				new DeviceAddressExample( "R0", "文件寄存器", true, true, "读位的时候，R10.15代表第10个字的第15位" ),
				new DeviceAddressExample( "W0", "链接寄存器", true, true, "读位的时候，W10.15代表第10个字的第15位" ),
				new DeviceAddressExample( "s=2;M0", "内部继电器", true, true, "以上所有的地址支持额外指定站号信息" ),
			};
		}
		public static DeviceAddressExample[] GetSPHAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M1.0",   "内部继电器", true, true, "" ),
				new DeviceAddressExample( "M3.0",   "内部继电器", true, true, "" ),
				new DeviceAddressExample( "M10.0",  "内部继电器", true, true, "" ),
				new DeviceAddressExample( "I0",     "输入继电器", true, true, "" ),
				new DeviceAddressExample( "Q0",     "输出继电器", true, true, "" ),
			};
		}

		public static DeviceAddressExample[] GetCSTNAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "B0",   "I/O relay 输入输出继电器",   true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "M0",   "Auxiliary relay 辅助继电器", true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "K0",   "Keep relay 保持继电器",      true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "F0",   "Special relay 特殊继电器",   true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "A0",   "Announce relay",            true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "D0",   "Differential relay",        true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "S0",   "Step control",              true, true, "Word Length: 8 bits" ),
				new DeviceAddressExample( "W9.0", "Current value of 0.1-sec timer", true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "TS0",   "Set value of time", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "TR0",   "Current value of timer", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "CS0",   "Set value of counter", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "CR0",   "Current value of counter", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "BD0",   "Data memory(BCD)", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "WL0",   "No.1 block", true, true, "P-link station 0 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W21.0", "No.2 block", true, true, "P-link station 0 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W22.0", "No.3 block", true, true, "P-link station 0 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W23.0", "No.4 block", true, true, "P-link station 0 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W24.0", "Direct I/O", true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "W25.0", "Analog work area", true, true, "Word Length: 32 bits" ),
				new DeviceAddressExample( "W26.0", "Last value of differential relay", true, true, "Word Length: 16 bits" ),
				new DeviceAddressExample( "W30.0 ~ W109.0",   "File memory", true, true, "Word Length: 16 bits or 32 bits depending on the file" ),
				new DeviceAddressExample( "W120.0", "No.1 block", true, true, "P-link station 1 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W121.0", "No.2 block", true, true, "P-link station 1 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W122.0", "No.3 block", true, true, "P-link station 1 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W123.0", "No.4 block", true, true, "P-link station 1 memory, Word Length: 16 bits" ),
				new DeviceAddressExample( "W125.0", "Calendar", true, true, "Word Length: 16 bits" ),
			};
		}
	}
}
