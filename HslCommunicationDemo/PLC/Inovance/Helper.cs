using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Inovance
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetInovanceAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "AM400-800/AC/AP", "", false, false, "", true ),
				new DeviceAddressExample( "Q0.0", "输出", true, false, "	Q0.0-Q8191.7 或是 Q0-Q65535" ),
				new DeviceAddressExample( "IX0.0", "输入", true, false, "IX0.0-IX8191.7 或是 I0-I65535" ),
				new DeviceAddressExample( "MX0.0", "M寄存器", true, false, "MX0.0-MX1000.10" ),
				new DeviceAddressExample( "MW0", "M寄存器", false, true, "MW0-MW65535" ),
				new DeviceAddressExample( "MD0", "M寄存器", false, true, "MD100 = MW200" ),
				new DeviceAddressExample( "MB0", "M寄存器", false, true, "MB100 = MW50 必须偶数的地址" ),
				new DeviceAddressExample( "SM0", "", false, true, "AM600系列还支持 SM0-SM65535" ),
				new DeviceAddressExample( "SD0", "", false, true, "AM600系列还支持 SDW0-SDW65535" ),
				new DeviceAddressExample( "s=2;SD0", "", false, true, "以上所有地址支持额外指定站号" ),

				new DeviceAddressExample( "H3U及H5U", "", false, false, "", true ),
				new DeviceAddressExample( "M0",  "中间继电器", true, false, "M0-M7679，M8000-M8511" ),
				new DeviceAddressExample( "SM0", "中间继电器", true, false, "SM0-SM1023" ),
				new DeviceAddressExample( "S0",  "中间继电器", true, false, "S0-S4095" ),
				new DeviceAddressExample( "T0",  "定时器", true, true, "T0-T511，读bool就是线圈，读字就是当前值" ),
				new DeviceAddressExample( "C0",  "计数器", true, true, "C0-C255，读bool就是线圈，读字就是当前值" ),
				new DeviceAddressExample( "X0",  "输入", true, false, "X0-X377 或者X0.0-X37.7" ),
				new DeviceAddressExample( "Y0",  "输出", true, false, "Y0-Y377 或者Y0.0-Y37.7" ),
				new DeviceAddressExample( "D0",  "数据寄存器", false, true, "D0-D8511" ),
				new DeviceAddressExample( "SD0", "特殊寄存器", false, true, "SD0-SD1023" ),
				new DeviceAddressExample( "R0",  "文件寄存器", false, true, "R0-R32767" ),
				new DeviceAddressExample( "s=2;SD0", "", false, true, "以上所有地址支持额外指定站号" ),

			};
		}
	}
}
