using HslCommunication.Profinet.Melsec.Helper;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Melsec
{
	internal class Helper
	{
		/// <summary>
		/// 根据值设置当前的PLC编号信息，如果设置失败，返回 false, 程序停止
		/// </summary>
		/// <param name="mc"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool SetPlcNumber( IReadWriteMc mc, string input )
		{
			if (!string.IsNullOrEmpty( input ))
			{
				if (byte.TryParse( input, out byte plcNumber ))
				{
					mc.PLCNumber = plcNumber;
				}
				else
				{
					MessageBox.Show( "PLC Number input Wrong!" );
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 获取MC协议的地址示例
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetMcAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0",  "内部继电器",       true, true, "" ),
				new DeviceAddressExample( "X0",  "输入继电器",       true, true, "默认16进制，如果需要8进制，使用0开头 X011" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, true, "默认16进制，如果需要8进制，使用0开头 Y011" ),
				new DeviceAddressExample( "SM0", "SM特殊继电器",     true, true, "" ),
				new DeviceAddressExample( "S0", "步进继电器",        true, true, "" ),
				new DeviceAddressExample( "L0", "锁存继电器",        true, true, "" ),
				new DeviceAddressExample( "F0", "报警器",            true, true, "" ),
				new DeviceAddressExample( "V0", "边沿继电器",        true, true, "" ),
				new DeviceAddressExample( "B0", "链接继电器",        true, true, "16进制地址" ),
				new DeviceAddressExample( "SB0", "特殊链接继电器",   true, true, "16进制地址" ),
				new DeviceAddressExample( "DX0", "直接输入",         true, true, "16进制地址" ),
				new DeviceAddressExample( "DY0", "直接输出",         true, true, "16进制地址" ),
				new DeviceAddressExample( "TS0", "定时器触点",       true, false, "" ),
				new DeviceAddressExample( "TC0", "定时器线圈",       true, false, "" ),
				new DeviceAddressExample( "SS0", "累计定时器触点",   true, false, "" ),
				new DeviceAddressExample( "SC0", "累计定时器线圈",   true, false, "" ),
				new DeviceAddressExample( "CS0", "计数器触点",       true, false, "" ),
				new DeviceAddressExample( "CC0", "计数器线圈",       true, false, "" ),
				new DeviceAddressExample( "D0", "数据寄存器",        false, true, "" ),
				new DeviceAddressExample( "SD0", "特殊数据寄存器",   false, true, "" ),
				new DeviceAddressExample( "W0", "链接寄存器",        false, true, "16进制地址" ),
				new DeviceAddressExample( "SW0", "特殊链接寄存器",   false, true, "16进制地址" ),
				new DeviceAddressExample( "R0", "文件寄存器",        false, true, "" ),
				new DeviceAddressExample( "Z0", "变址寄存器",        false, true, "" ),
				new DeviceAddressExample( "ZR0", "ZR文件寄存器",     false, true, "" ),
				new DeviceAddressExample( "TN0", "定时器当前值",     false, true, "" ),
				new DeviceAddressExample( "SN0", "累计定时器当前值", false, true, "" ),
				new DeviceAddressExample( "CN0", "计数器当前值",     false, true, "" )
			};
		}

		public static DeviceAddressExample[] GetMc1EAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0",  "内部继电器",       true, true, "" ),
				new DeviceAddressExample( "X0",  "输入继电器",       true, true, "默认16进制，如果需要8进制，使用0开头 X011" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, true, "默认16进制，如果需要8进制，使用0开头 y011" ),
				//new DeviceAddressExample( "SM0", "SM特殊继电器",     true, true, "" ),
				new DeviceAddressExample( "S0", "步进继电器",        true, true, "" ),
				//new DeviceAddressExample( "L0", "锁存继电器",        true, true, "" ),
				new DeviceAddressExample( "F0", "报警器",            true, true, "" ),
				//new DeviceAddressExample( "V0", "边沿继电器",        true, true, "" ),
				new DeviceAddressExample( "B0", "链接继电器",        true, true, "16进制地址" ),
				//new DeviceAddressExample( "SB0", "特殊链接继电器",   true, true, "16进制地址" ),
				//new DeviceAddressExample( "DX0", "直接输入",         true, true, "16进制地址" ),
				//new DeviceAddressExample( "DY0", "直接输出",         true, true, "16进制地址" ),
				new DeviceAddressExample( "TS0", "定时器触点",       true, false, "" ),
				new DeviceAddressExample( "TC0", "定时器线圈",       true, false, "" ),
				//new DeviceAddressExample( "SS0", "累计定时器触点",   true, false, "" ),
				//new DeviceAddressExample( "SC0", "累计定时器线圈",   true, false, "" ),
				new DeviceAddressExample( "CS0", "计数器触点",       true, false, "" ),
				new DeviceAddressExample( "CC0", "计数器线圈",       true, false, "" ),
				new DeviceAddressExample( "D0", "数据寄存器",        false, true, "" ),
				//new DeviceAddressExample( "SD0", "特殊数据寄存器",   false, true, "" ),
				new DeviceAddressExample( "W0", "链接寄存器",        false, true, "16进制地址" ),
				//new DeviceAddressExample( "SW0", "特殊链接寄存器",   false, true, "16进制地址" ),
				new DeviceAddressExample( "R0", "文件寄存器",        false, true, "" ),
				//new DeviceAddressExample( "Z0", "变址寄存器",        false, true, "" ),
				//new DeviceAddressExample( "ZR0", "ZR文件寄存器",     false, true, "" ),
				new DeviceAddressExample( "TN0", "定时器当前值",     false, true, "" ),
				//new DeviceAddressExample( "SN0", "累计定时器当前值", false, true, "" ),
				new DeviceAddressExample( "CN0", "计数器当前值",     false, true, "" )
			};
		}


		public static DeviceAddressExample[] GetFxLinksAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0",  "内部继电器",       true, true, "" ),
				new DeviceAddressExample( "X0",  "输入继电器",       true, true, "8进制地址" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, true, "8进制地址" ),
				new DeviceAddressExample( "S0", "步进继电器",        true, true, "" ),
				new DeviceAddressExample( "TS0", "定时器触点",       true, false, "" ),
				new DeviceAddressExample( "CS0", "计数器触点",       true, false, "" ),
				new DeviceAddressExample( "D0", "数据寄存器",        false, true, "" ),
				new DeviceAddressExample( "R0", "文件寄存器",        false, true, "" ),
				new DeviceAddressExample( "TN0", "定时器当前值",     false, true, "" ),
				new DeviceAddressExample( "CN0", "计数器当前值",     false, true, "" ),
				new DeviceAddressExample( "s=2;D0", "数据寄存器",        false, true, "支持额外指定其他的站号信息" ),
			};
		}


		public static DeviceAddressExample[] GetFxSerialAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M0",  "内部继电器",       true, true, "" ),
				new DeviceAddressExample( "X0",  "输入继电器",       true, true, "8进制地址" ),
				new DeviceAddressExample( "Y0",  "输出继电器",       true, true, "8进制地址" ),
				new DeviceAddressExample( "S0", "步进继电器",        true, true, "" ),
				new DeviceAddressExample( "TS0", "定时器触点",       true, false, "" ),
				new DeviceAddressExample( "TC0", "定时器线圈",       true, false, "" ),
				new DeviceAddressExample( "CS0", "计数器触点",       true, false, "" ),
				new DeviceAddressExample( "CC0", "计数器线圈",       true, false, "" ),
				new DeviceAddressExample( "D0", "数据寄存器",        false, true, "" ),
				new DeviceAddressExample( "TN0", "定时器当前值",     false, true, "" ),
				new DeviceAddressExample( "CN0", "计数器当前值",     false, true, "" )
			};
		}
	}
}
