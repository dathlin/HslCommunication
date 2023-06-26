using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Ge
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetDeviceAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "I1", "Discrete Inputs",      true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "Q1", "Discrete Outputs",     true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "M1", "Discrete Internals",   true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "T1", "Discrete Temporaries", true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "SA1", "SA Discrete",         true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "SB1", "SB Discrete",         true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "SC1", "SC Discrete",         true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "S1", "S Discrete",           true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "G1", "Genius Global Data",   true,  true, "注意：读位和字节，属于不同的地址" ),
				new DeviceAddressExample( "AI1", "Analog Inputs",       false, true, "虽然读取的时候，长度是字节，但是实际是字单位的，所以不支持 ReadByte" ),
				new DeviceAddressExample( "QI1", "Analog Outputs",      false, true, "虽然读取的时候，长度是字节，但是实际是字单位的，所以不支持 ReadByte" ),
				new DeviceAddressExample( "R1", "Registers",            false, true, "虽然读取的时候，长度是字节，但是实际是字单位的，所以不支持 ReadByte" ),
			};
		}
	}
}
