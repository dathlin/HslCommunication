using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Instrument
{
	internal class CJT188Helper
	{
		public static DeviceAddressExample[] GetCJT188Address( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "90-1F", "读计量数据",   false, false, "读double, 当前累计流量，或是特殊功能测试读取字符串数组" ),
				new DeviceAddressExample( "D1-20", "历史计量数据", false, false, "读double, 上1月结算日累计流量" ),
				new DeviceAddressExample( "D1-21", "历史计量数据", false, false, "读double, 上2月结算日累计流量" ),
				new DeviceAddressExample( "D1-22", "历史计量数据", false, false, "读double, 上3月结算日累计流量" ),
				new DeviceAddressExample( "D1-23", "历史计量数据", false, false, "读double, 上4月结算日累计流量" ),
				new DeviceAddressExample( "D1-24", "历史计量数据", false, false, "读double, 上5月结算日累计流量" ),
				new DeviceAddressExample( "D1-25", "历史计量数据", false, false, "读double, 上6月结算日累计流量" ),
				new DeviceAddressExample( "D1-26", "历史计量数据", false, false, "读double, 上7月结算日累计流量" ),
				new DeviceAddressExample( "D1-27", "历史计量数据", false, false, "读double, 上8月结算日累计流量" ),
				new DeviceAddressExample( "D1-28", "历史计量数据", false, false, "读double, 上9月结算日累计流量" ),
				new DeviceAddressExample( "D1-29", "历史计量数据", false, false, "读double, 上10月结算日累计流量" ),
				new DeviceAddressExample( "D1-2A", "历史计量数据", false, false, "读double, 上11月结算日累计流量" ),
				new DeviceAddressExample( "D1-2B", "历史计量数据", false, false, "读double, 上12月结算日累计流量" ),
				new DeviceAddressExample( "81-05", "购入金额", false, false, "读double, 序号/本次购入/累计购入/剩余购入/表状态" ),
				new DeviceAddressExample( "81-02", "价格表", false, false, "读double, 价格一/用量一/价格二/用量二/价格三" ),
				new DeviceAddressExample( "81-03", "结算日", false, false, "读double" ),
				new DeviceAddressExample( "81-04", "抄表日", false, false, "读double" ),

			};
		}
	}
}
