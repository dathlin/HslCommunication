using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Modbus
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetModbusAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "100",             "[Bool] 线圈",          true, false, "读写BOOL时，有些设备表示为 000100" ),
				new DeviceAddressExample( "x=2;100",         "[Bool] 输入线圈",      true, false, "读写BOOL，有些设备表示为 100100" ),
				new DeviceAddressExample( "100",             "[Word] 保持寄存器",    false, true, "有些设备会表示为 400100" ),
				new DeviceAddressExample( "x=4;100",         "[Word] 输入寄存器",    false, true, "有些设备会表示为 300100" ),
				new DeviceAddressExample( "100.1",           "[Bool] 寄存器bool操作", true, false, "写入时掩码0x16功能码，如果不支持，读字修改位写字" ),
				new DeviceAddressExample( "s=2;100",         "[Bool] 线圈",          true, false, "读取线圈支持携带站号信息，额外指定站号" ),
				new DeviceAddressExample( "s=2;100",         "[Word] 保持寄存器",    false, true, "读取保持寄存器支持携带站号信息，额外指定站号" ),
				new DeviceAddressExample( "format=DCBA;100", "[Word] 保持寄存器",    false, true, "读写int,uint,long,ulong,float,double支持强制指定格式" ),
				new DeviceAddressExample( "s=2;x=4;100",     "[Word] 输入寄存器",    false, true, "读取站号2，输入寄存器数据" ),
				new DeviceAddressExample( "w=16;100",        "[Word] 保持寄存器",    true, false, "Write(string, short)时，使用0x10功能码写入" ),
				new DeviceAddressExample( "x=7;w=8;100",     "自定义规则时",         false, true, "读取使用7功能码，写入使用8功能码" ),
			};
		}
	}
}
