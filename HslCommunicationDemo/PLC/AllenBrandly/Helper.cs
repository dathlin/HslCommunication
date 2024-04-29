using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.AllenBrandly
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetSLCAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "A9:0", "ASCII 变量", true, true, "如果访问位 A9:0/1 或 A9:0.1" ),
				new DeviceAddressExample( "B9:0", "Bit 变量", true, true, "如果访问位 B9:0/1 或 B9:0.1" ),
				new DeviceAddressExample( "N9:0", "Integer 变量", true, true, "如果访问位 N9:0/1 或 N9:0.1" ),
				new DeviceAddressExample( "F9:0", "Floating point", true, true, "如果访问位 F9:0/1 或 F9:0.1" ),
				new DeviceAddressExample( "S9:0", "Status 变量", true, true, "如果访问位 S:0/1 或 S:0.1 ,S:0 等同于 S2:0" ),
				new DeviceAddressExample( "ST1:0", "String", true, true, "" ),
				new DeviceAddressExample( "C9:0", "Counter", true, true, "如果访问位 C9:0/1 或 C9:0.1" ),
				new DeviceAddressExample( "I9:0", "Input", true, true, "如果访问位 I9:0/1 或 I9:0.1" ),
				new DeviceAddressExample( "O9:0", "Output", true, true, "如果访问位 O9:0/1 或 O9:0.1" ),
				new DeviceAddressExample( "R9:0", "Control", true, true, "如果访问位 R9:0/1 或 R9:0.1" ),
				new DeviceAddressExample( "T9:0", "Timer", true, true, "如果访问位 T9:0/1 或 T9:0.1" ),
				new DeviceAddressExample( "L9:0", "long integer", true, true, "如果访问位 L9:0/1 或 L9:0.1" ),
			};
		}

		public static DeviceAddressExample[] GetDF1AddressExamples( )
		{
			List<DeviceAddressExample> list = new List<DeviceAddressExample>( GetSLCAddressExamples( ) );
			list.Add( new DeviceAddressExample( "s=2;N9:0", "Integer 变量", true, true, "可以携带站号信息" ) );
			list.Add( new DeviceAddressExample( "s=2;dst=1;src=2;N9:0", "Integer 变量", true, true, "可以携带目标信息，原始站号信息" ) );
			return list.ToArray( );
		}

		public static DeviceAddressExample[] GetPCCCAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "A9:0", "ASCII",           true, true, "" ),
				new DeviceAddressExample( "B2:0", "Bit",             true, true, "" ),
				new DeviceAddressExample( "N2:0", "Integer",         true, true, "" ),
				new DeviceAddressExample( "L17:0", "Long Integer",   true, true, "" ),
				new DeviceAddressExample( "ST2:0", "string",         true, true, "" ),
				new DeviceAddressExample( "F8:5", "Floating",        true, true, "" ),
				new DeviceAddressExample( "S:1/15", "Status",        true, true, "" ),
				new DeviceAddressExample( "C2:0", "Counter",         true, true, "" ),
				new DeviceAddressExample( "T2:0", "Timer",           true, true, "" ),
				new DeviceAddressExample( "I:0/15", "Input",         true, true, "" ),
				new DeviceAddressExample( "O:0/15", "Output",        true, true, "" ),
			};
		}

		public static DeviceAddressExample[] GetCIPAddressExamples( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "A1", "全局变量名", true, true, "类型一定要和PLC实际数据对应上" ),
				new DeviceAddressExample( "type=0xDA;A2", "携带类型", true, true, "当标签类型特殊时，可以手动携带类型才能正确写入" ),
				new DeviceAddressExample( "x=0x52;A3[0]", "使用片段读取", true, true, "当地址的数据非常大的时候，可以使用片段读取，地址前加 x=0x52;" ),
				new DeviceAddressExample( "class=0x6b;0xf68f", "符号实例地址", true, true, "也可以写成class=107;63119, class是类ID，右侧是实例ID" ),
				new DeviceAddressExample( "Program:MainProgram.A1", "局部变量名", true, true, "如果变量是局部的，前面带上程序名" ),
				new DeviceAddressExample( "slot=2;A1", "全局变量名", true, true, "地址也可以携带额外的slot信息" ),
				new DeviceAddressExample( "i=A[0]", "全局变量名", true, true, "如果A在PLC是基于uint类型的bool数组，可以使用这种访问每个位" ),
				new DeviceAddressExample( "B[0]", "全局变量名", true, true, "如果B是数组，则可以使用索引访问每个元素" ),
				new DeviceAddressExample( "C[0,1]", "全局变量名", true, true, "如果C是二维数组，则可以使用索引访问每个元素" )
			};
		}
	}
}