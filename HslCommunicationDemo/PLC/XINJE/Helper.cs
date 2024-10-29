using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.XINJE
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetXinJEAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "XC1/XC2/XC3/XC5/XCM/XCC", "", false, false, "", true ),
				new DeviceAddressExample( "M100", "内部继电器", true, false, "M0-M7999 M8000-M8511" ),
				new DeviceAddressExample( "S100", "流程继电器", true, false, "S0-S1023" ),
				new DeviceAddressExample( "T100", "定时器", true, false, "T0-T618  bool读写" ),
				new DeviceAddressExample( "C100", "计数器", true, false, "C0-C634  bool读写" ),
				new DeviceAddressExample( "X10.7", "输入线圈", true, false, "X0-X1037 或者X0.0-X103.7, 八进制"),
				new DeviceAddressExample( "Y10.7", "输出线圈", true, false, "Y0-Y1037 或者Y0.0-Y103.7, 八进制" ),
				new DeviceAddressExample( "D100", "数据寄存器", false, true, "D0-D8511" ),
				new DeviceAddressExample( "F100", "Flash寄存器", false, true, "F0-F5000;F8000-F8511"),
				new DeviceAddressExample( "E100", "扩展内部寄存器", false, true, "E0-E36863"),
				new DeviceAddressExample( "T100", "定时器值", false, true, "T0-T618"),
				new DeviceAddressExample( "C100", "计数器值", false, true, "C0-C634"),
				new DeviceAddressExample( "s=2;D100", "数据寄存器", false, true, "地址支持额外指定站号信息"),

				new DeviceAddressExample( "XD/XL", "", false, false, "", true ),
				new DeviceAddressExample( "M100", "内部继电器", true, false, "M0-M7999" ),
				new DeviceAddressExample( "X10.7", "输入线圈", true, false, "8进制地址，也可以带小数点表示，范围 X0-X77(本体),X10000-X11177"),
				new DeviceAddressExample( "Y10.7", "输出线圈", true, false, "8进制地址，也可以带小数点表示，Y0-Y77(本体),Y10000-Y11177" ),
				new DeviceAddressExample( "S100", "流程继电器", true, false, "范围: S0~S1023" ),
				new DeviceAddressExample( "SM100", "特殊继电器", true, false, "范围: SM0~SM2047" ),
				new DeviceAddressExample( "T100", "定时器", true, false, "范围: T0~T575"),
				new DeviceAddressExample( "C100", "计数器", true, false, "范围: C0~C575"),
				new DeviceAddressExample( "ET100", "精确定时器", true, false, "范围: ET0~ET31"),
				new DeviceAddressExample( "SEM100", "顺序功能块专用指令", true, false, "范围: SEM0~SEM31"),
				new DeviceAddressExample( "HM100", "内部继电器", true, false, "范围: HM0~HM959"),
				new DeviceAddressExample( "HT100", "定时器", true, false, "范围: HT0~HT95"),
				new DeviceAddressExample( "HC100", "计数器", true, false, "范围: HC0~HC95"),
				new DeviceAddressExample( "HSC100", "高速计数器", true, false, "范围: HSC0~HSC31"),

				new DeviceAddressExample( "D100", "数据寄存器", false, true, "一般范围: D0~D7999"),
				new DeviceAddressExample( "ID0", "本体/扩展模块/扩展BD/扩展ED", false, true, "ID0~ID99（本体）ID10X00(X为0 ~ 9表示10个模块)"),
				new DeviceAddressExample( "QD0", "本体/扩展模块/扩展BD/扩展ED", false, true, "QD0~QD99（本体）QD10X00(X为0 ~ 9表示10个模块)"),
				new DeviceAddressExample( "SD0", "特殊寄存器",            false, true, "一般范围: SD0~SD2047"),
				new DeviceAddressExample( "TD0", "定时器当前值",          false, true, "一般范围: TD0~TD575"),
				new DeviceAddressExample( "CD0", "计数器当前值",          false, true, "一般范围: CD0~CD575"),
				new DeviceAddressExample( "ETD0", "精确定时器当前值",      false, true, "一般范围: ETD0~ETD31"),
				new DeviceAddressExample( "HD0", "数据寄存器",            false, true, "一般范围: HD0~HD999"),
				new DeviceAddressExample( "HSD0", "特殊用寄存器",         false, true, "一般范围: HSD0~HSD499"),
				new DeviceAddressExample( "HTD0", "定时器当前值",         false, true, "一般范围: HTD0~HTD95"),
				new DeviceAddressExample( "HCD0", "计数器当前值",         false, true, "一般范围: HCD0~HCD95"),
				new DeviceAddressExample( "HSCD0", "高速计数器当前值",    false, true, "一般范围: HSCD0~HSCD31"),
				new DeviceAddressExample( "FD0", "FlashROM寄存器",        false, true, "一般范围: FD0~FD5119"),
				new DeviceAddressExample( "SFD0", "特殊用FlashROM寄存器", false, true, "一般范围: SFD0~SFD1999"),
				new DeviceAddressExample( "FSD0", "特殊保密寄存器",       false, true, "一般范围: FSD0~FSD47"),
				new DeviceAddressExample( "s=2;D100", "数据寄存器", false, true, "地址支持额外指定站号信息"),
			};
		}

		public static DeviceAddressExample[] GetXinJEInternalAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M100", "内部继电器", true, false, "M0-M69999" ),
				new DeviceAddressExample( "X10.7", "输入线圈", true, false, "8进制地址，也可以带小数点表示"),
				new DeviceAddressExample( "Y10.7", "输出线圈", true, false, "8进制地址，也可以带小数点表示" ),
				new DeviceAddressExample( "S100", "流程继电器", true, false, "范围: S0~S7999" ),
				new DeviceAddressExample( "HS100", "流程继电器", true, false, "范围: HS0~HS999"),
				new DeviceAddressExample( "SM100", "特殊继电器", true, false, "范围: SM0~SM4999" ),
				new DeviceAddressExample( "T100", "定时器", true, false, "范围: T0~T4999"),
				new DeviceAddressExample( "C100", "计数器", true, false, "范围: C0~C4999"),
				new DeviceAddressExample( "ET100", "精确定时器", true, false, "范围: ET0~ET39"),
				new DeviceAddressExample( "SEM100", "顺序功能块专用指令", true, false, "范围: SEM0~SEM31"),
				new DeviceAddressExample( "HM100", "内部继电器", true, false, "范围: HM0~HM11999"),
				new DeviceAddressExample( "HT100", "定时器", true, false, "范围: HT0~HT1999"),
				new DeviceAddressExample( "HC100", "计数器", true, false, "范围: HC0~HC1999"),
				new DeviceAddressExample( "HSC100", "高速计数器", true, false, "范围: HSC0~HSC39"),

				new DeviceAddressExample( "D100", "数据寄存器", false, true, "一般范围: D0~D69999"),
				new DeviceAddressExample( "ID0", "本体/扩展模块/扩展BD/扩展ED", false, true, "ID0~ID99（本体）ID10X00(X为0 ~ 9表示10个模块)"),
				new DeviceAddressExample( "QD0", "本体/扩展模块/扩展BD/扩展ED", false, true, "QD0~QD99（本体）QD10X00(X为0 ~ 9表示10个模块)"),
				new DeviceAddressExample( "SD0", "特殊寄存器",            false, true, "一般范围: SD0~SD4999"),
				new DeviceAddressExample( "TD0", "定时器当前值",          false, true, "一般范围: TD0~TD4999"),
				new DeviceAddressExample( "CD0", "计数器当前值",          false, true, "一般范围: CD0~CD4999"),
				new DeviceAddressExample( "ETD0", "精确定时器当前值",      false, true, "一般范围: ETD0~ETD39"),
				new DeviceAddressExample( "HD0", "数据寄存器",            false, true, "一般范围: HD0~HD24999"),
				new DeviceAddressExample( "HSD0", "特殊用寄存器",         false, true, "一般范围: HSD0~HSD1023"),
				new DeviceAddressExample( "HTD0", "定时器当前值",         false, true, "一般范围: HTD0~HTD1999"),
				new DeviceAddressExample( "HCD0", "计数器当前值",         false, true, "一般范围: HCD0~HCD1999"),
				new DeviceAddressExample( "HSCD0", "高速计数器当前值",    false, true, "一般范围: HSCD0~HSCD39"),
				new DeviceAddressExample( "FD0", "FlashROM寄存器",        false, true, "一般范围: FD0~FD8191"),
				new DeviceAddressExample( "SFD0", "特殊用FlashROM寄存器", false, true, "一般范围: SFD0~SFD5999"),
				new DeviceAddressExample( "FSD0", "特殊保密寄存器",       false, true, "一般范围: FSD0~FSD47"),
			};
		}

		public static DeviceAddressExample[] GetXinJEInternalServerAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M100", "内部继电器", true, false, "客户端使用XinJE TCP[专用] 的情况" ),
				new DeviceAddressExample( "SM100", "特殊继电器", true, false, "客户端使用XinJE TCP[专用] 的情况" ),

				new DeviceAddressExample( "D100", "数据寄存器", false, true, "客户端使用XinJE TCP[专用] 的情况"),
				new DeviceAddressExample( "SD0", "特殊寄存器",            false, true, "客户端使用XinJE TCP[专用] 的情况"),
				new DeviceAddressExample( "HD0", "数据寄存器",            false, true, "客户端使用XinJE TCP[专用] 的情况"),

				new DeviceAddressExample( "100", "modbus的03功能码",            false, true, "使用modbus地址，客户端使用XinJE TCP[Modbus] 的情况"),
			};
		}


	}
}
