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
				new DeviceAddressExample( "100",     "[Word] 保持寄存器",     false, true, "读写保持寄存器" ),
				new DeviceAddressExample( "x=4;100", "[Word] 输入寄存器",     false, true, "读取输入寄存器" ),
				new DeviceAddressExample( "x=9;100", "[Word] 扩展保持寄存器", false, true, "写入操作时，内部直接使用 0B 功能码写入" ),
				new DeviceAddressExample( "mfc=67;x=61;0", "[Bool] 位数据",  true, false, "也可以额外指定mfc的主功能码" ),

                new DeviceAddressExample( "M100",    "[Word] 保持寄存器",     false, true, "使用43主功能码实现，支持超大地址" ),
                new DeviceAddressExample( "G100",    "[Word] 数据寄存器",     false, true, "使用43主功能码实现，支持超大地址" ),
                new DeviceAddressExample( "I100",    "[Word] 输入寄存器",     false, true, "使用43主功能码实现，支持超大地址" ),
                new DeviceAddressExample( "O100",    "[Word] 输出寄存器",     false, true, "使用43主功能码实现，支持超大地址" ),
                new DeviceAddressExample( "S100",    "[Word] 系统寄存器",     false, true, "使用43主功能码实现，支持超大地址" ),

				new DeviceAddressExample( "M100.0",    "[Word] 保持寄存器",     true, false, "对字进行位读写操作，地址也可以写成MB1000" ),
				new DeviceAddressExample( "S100.0",    "[Word] 系统寄存器",     true, false, "对字进行位读写操作，地址也可以写成SB1000" ),
				new DeviceAddressExample( "G100.0",    "[Word] 数据寄存器",     true, false, "对字进行位读写操作，地址也可以写成GB1000" ),

			};
		}
	}
}
