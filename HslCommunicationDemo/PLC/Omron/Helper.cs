using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Omron
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetOmronAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "D0 / DM0",    "DM Area",            true, true, "支持两种写法，读取位使用 DM10.11" ),
				new DeviceAddressExample( "C0 / CIO0",   "CIO Area",           true, true, "支持两种写法，读取位使用 C10.11" ),
				new DeviceAddressExample( "W0 / WR0",    "Work Area",          true, true, "支持两种写法，读取位使用 W10.11" ),
				new DeviceAddressExample( "H0 / HR0",    "Holding Bit Area",   true, true, "支持两种写法，读取位使用 H10.11" ),
				new DeviceAddressExample( "A0 / AR0",   "Auxiliary Bit Area",  true, true, "支持两种写法，读取位使用 A10.11" ),
				new DeviceAddressExample( "E0.0 / EM0.0", "EM Area",           true, true, "支持两种写法，范围 E0.0-EF.0，读取位使用 EM1.0.0" ),
				new DeviceAddressExample( "E100 / EM100", "EM Current Area",   true, true, "E0 ~ E32767 属于 EM current bank" ),
				new DeviceAddressExample( "TIM0",   "Timer Area",              true, true, "读位就是完成标记，读字就是当前值" ),
				new DeviceAddressExample( "CNT0",   "Counter Area",            true, true, "读位就是完成标记，读字就是当前值" ),
				new DeviceAddressExample( "IR0",   "Index Register",           false, true, "只能读字" ),
				new DeviceAddressExample( "DR0",   "Data Register",            false, true, "只能读字" ),
				new DeviceAddressExample( "CF1.2",   "Condition Flags",        true, false, "只能读位" ),
			};
		}
		public static DeviceAddressExample[] GetHostlinkAddressExamples( )
		{
			List<DeviceAddressExample> list = new List<DeviceAddressExample>( GetOmronAddressExamples( ) );
			list.Add( new DeviceAddressExample( "s=2;D0", "DM Area", true, true, "支持额外指定站号信息" ) );
			return list.ToArray( );
		}

		public static DeviceAddressExample[] GetFinsCModeAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "D0 / DM0",    "DM Area",            false, true, "只能读写字，范围 DM0 ~ DM9999" ),
				new DeviceAddressExample( "C0 / CIO0",   "CIO Area",           false, true, "只能读写字，范围 CIO0 ~ CIO9999" ),
				new DeviceAddressExample( "LR",    "LR Area",                  false, true, "只能读写字，范围 LR0 ~ LR9999" ),
				new DeviceAddressExample( "H0 / HR0",    "Holding Area",       false, true, "只能读写字，范围 HR0 ~ HR511" ),
				new DeviceAddressExample( "A0 / AR0",   "Auxiliary Area",      false, true, "只能读写字，范围 AR0 ~ AR959" ),
				new DeviceAddressExample( "E0.0 / EM0.0", "EM Area",           false, true, "只能读写字，范围 EM0.0 ~ EMF.9999" ),
				new DeviceAddressExample( "TIM0",   "Timer Area",              false, true, "读字就是当前值，范围 TIM0 ~ TIM2047" ),
				new DeviceAddressExample( "CNT0",   "Counter Area",            false, true, "读字就是当前值，范围 CNT0 ~ CNT2047" ),
			};
		}
	}
}
