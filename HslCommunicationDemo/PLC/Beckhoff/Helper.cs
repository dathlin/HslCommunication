using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Beckhoff
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetDeviceAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M100",     "", true, true, "绝对地址，访问位 M100.0" ),
				new DeviceAddressExample( "I100",     "", true, true, "绝对地址，访问位 I100.0" ),
				new DeviceAddressExample( "Q100",     "", true, true, "绝对地址，访问位 Q100.0" ),
				new DeviceAddressExample( "s=abc",    "", true, true, "符号地址，abc全局变量" ),
				new DeviceAddressExample( "s=MAIN.A", "", true, true, "符号地址，A是MAIN函数地址" ),
				new DeviceAddressExample( "i=100000", "", true, true, "内存地址" ),
			};
		}
	}
}
