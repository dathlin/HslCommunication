using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Keyence
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetKeyenceMcAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "R015/R0.15 (XF,X1A0)",  "输入继电器",       true, true, "字+位组合(16)，或是三菱的X地址，范围: R00000~R99915" ),
				new DeviceAddressExample( "R015/R0.15 (YF,Y1A0)",  "输出继电器",       true, true, "字+位组合(16)，或是三菱的Y地址，范围: R00000~R99915" ),
				new DeviceAddressExample( "B0",  "链接继电器",              true, true, "地址16进制，范围: B0~B7FFF" ),
				new DeviceAddressExample( "MR000/MR0.0",  "内部辅助继电器",        true, true, "字+位组合(16)，范围: MR00000~MR99915" ),
				new DeviceAddressExample( "LR015/LR0.15",  "锁存继电器",           true, true, "字+位组合(16)，范围: LR00000~LR99915" ),
				new DeviceAddressExample( "CR015/CR0.15",  "控制继电器",           true, true, "字+位组合(16)，范围: CR0000~CR7915" ),
				new DeviceAddressExample( "CM0",    "控制寄存器",           true, true, "范围: CM0000~CM5999" ),
				new DeviceAddressExample( "DM0",    "数据寄存器",           false, true, "范围: DM00000~DM65534" ),
				new DeviceAddressExample( "EM0",    "扩展数据寄存器",       false, true, "范围: EM00000~EM65534" ),
				new DeviceAddressExample( "FM0",    "文件寄存器",           false, true, "FM00000~FM32767" ),
				new DeviceAddressExample( "ZF0",    "文件寄存器",           false, true, "ZF000000~ZF524287" ),
				new DeviceAddressExample( "W0",     "链路寄存器",           false, true, "16进制地址，范围: W0000~W7FFF" ),
				new DeviceAddressExample( "TN0",    "定时器当前值",         false, true, "范围: TN0000~TN3999" ),
				new DeviceAddressExample( "TS0",    "定时器触点",           true, false, "范围: TS0000~TS3999" ),
				new DeviceAddressExample( "TC0",    "定时器线圈",           true, false, "范围: TC0000~TC3999" ),
				new DeviceAddressExample( "CN0",    "计数器当前值",         false, true, "范围: TN0000~TN3999" ),
				new DeviceAddressExample( "CS0",    "计数器触点",           true, false, "范围: CS0000~CS3999" ),
				new DeviceAddressExample( "CC0",    "计数器线圈",           true, false, "范围: CC0000~CC3999" ),
			};
		}

		public static DeviceAddressExample[] GetKeyenceKvAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "R015/R0.15",  "R继电器",         true, true, "字+位组合(16)，范围: R00000~R99915" ),
				new DeviceAddressExample( "B0",  "链接继电器",              true, true, "地址16进制，范围: B0~B3FFF" ),
				new DeviceAddressExample( "MR000/MR0.0",  "内部辅助继电器", true, true, "字+位组合(16)，范围: MR00000~MR99915" ),
				new DeviceAddressExample( "LR015/LR0.15",  "锁存继电器",    true, true, "字+位组合(16)，范围: LR00000~LR99915" ),
				new DeviceAddressExample( "CR015/CR0.15",  "控制继电器",    true, true, "字+位组合(16)，范围: CR0000~CR3915" ),
				new DeviceAddressExample( "T0",    "定时器线圈",            true, true, "范围: T0000 ~ T3999" ),
				new DeviceAddressExample( "C0",    "计数器线圈",            true, true, "范围: C0000 ~ C3999" ),
				new DeviceAddressExample( "CTC0",  "高速计数器线圈",        true, true, "范围: CTC0 ~ CTC3" ),
				new DeviceAddressExample( "CTH0",  "高速计数器",            true, true, "范围: CTH0 ~ CTH1" ),
				new DeviceAddressExample( "VB0",   "字线圈",                true, true, "16进制，范围: VB0000 ~ VB3FFF" ),

				new DeviceAddressExample( "CM0",    "控制寄存器",           false, true, "范围: CM0000~CM5999" ),
				new DeviceAddressExample( "DM0",    "数据寄存器",           false, true, "范围: DM00000~DM65534" ),
				new DeviceAddressExample( "EM0",    "扩展数据寄存器",       false, true, "范围: EM00000~EM65534" ),
				new DeviceAddressExample( "FM0",    "文件寄存器",           false, true, "FM00000~FM32767" ),
				new DeviceAddressExample( "ZF0",    "文件寄存器",           false, true, "ZF000000~ZF131071" ),
				new DeviceAddressExample( "W0",     "链路寄存器",           false, true, "16进制地址，范围: W0000~W3FFF" ),
				new DeviceAddressExample( "TM0",    "临时数据寄存器",       false, true, "范围: TM000~TM511" ),
				new DeviceAddressExample( "Z0",     "变址寄存器",           false, true, "范围: Z1~Z12" ),
				new DeviceAddressExample( "TC0",    "定时器当前值",         false, true, "范围: TC0000~TC3999" ),
				new DeviceAddressExample( "TS0",    "定时器设定值",         false, true, "范围: TS0000~TS3999" ),
				new DeviceAddressExample( "CC0",    "计数器当前值",         false, true, "范围: CC0000~CC3999" ),
				new DeviceAddressExample( "CS0",    "计数器设定值",         false, true, "范围: CS0000~CS3999" ),
				new DeviceAddressExample( "CTC0",   "高速计数器设定值",     false, true, "范围: CTC0~CTC3" ),
				new DeviceAddressExample( "T0",     "数字微调器",           false, true, "范围: AT0~AT7" ),
				new DeviceAddressExample( "VM",     "字存储器",            false, true, "范围: VM0~VM59999" ),
				new DeviceAddressExample( "unit=0;100",     "扩展存储器模块",            false, true, "读取扩展模块的数据，仅限企业用户" ),
			};
		}
	}
}
