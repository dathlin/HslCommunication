using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.YASKAWA
{
	internal class Helper
	{

		public static DeviceAddressExample[] GetMemobusAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "100",     "[Bool] 线圈",           true, false, "读写线圈的地址" ),
				new DeviceAddressExample( "x=2;100", "[Bool] 输入继电器",     true, false, "读去输入继电器的地址" ),
				new DeviceAddressExample( "100",     "[Wrod] 保持寄存器",     false, true, "读写保持寄存器" ),
				new DeviceAddressExample( "x=4;100", "[Wrod] 输入寄存器",     false, true, "读取输入寄存器" ),
				new DeviceAddressExample( "x=9;100", "[Wrod] 扩展保持寄存器", false, true, "写入操作时，内部直接使用 0B 功能码写入" ),
				new DeviceAddressExample( "mfc=67;x=61;0", "[Bool] 位数据",  true, false, "也可以额外指定mfc的主功能码" ),
			};
		}
	}
}
