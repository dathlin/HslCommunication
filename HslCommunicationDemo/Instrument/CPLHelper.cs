using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Instrument
{
	internal class CPLHelper
	{
		public static DeviceAddressExample[] GetCPLAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "501", "报警状态1",   false, true, "只读" ),
				new DeviceAddressExample( "504", "状态1/运行操作",   false, true, "读写" ),
				new DeviceAddressExample( "506", "PV(PV1)",   false, true, "只读" ),
				new DeviceAddressExample( "2001", "P-0 比例带0",   false, true, "读写" ),
				new DeviceAddressExample( "2002", "I-0 积分时间0",   false, true, "读写" ),
				new DeviceAddressExample( "2003", "D-0 微分时间0",   false, true, "读写" ),
				new DeviceAddressExample( "s=2;501", "报警状态1",   false, true, "地址可以携带站号信息" ),
			};
		}
	}
}
