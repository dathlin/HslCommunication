using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Instrument
{
	internal class RkcHelper
	{
		public static DeviceAddressExample[] GetRkcAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "M1", "测量值",           false, true, "只读, ReadDouble" ),
				new DeviceAddressExample( "M2", "CT1输入值",        false, true, "只读(0.0~100.0 A), ReadDouble" ),
				new DeviceAddressExample( "M3", "CT2输入值",        false, true, "只读(0.0~100.0 A), ReadDouble" ),
				new DeviceAddressExample( "AA", "第一报警输入",     false, true, "只读,ReadDouble 0:关  1:开" ),
				new DeviceAddressExample( "AB", "第二报警输入",     false, true, "只读,ReadDouble 0:关  1:开" ),
				new DeviceAddressExample( "B1", "熄火",            false, true, "只读,ReadDouble 0:关  1:开" ),
				new DeviceAddressExample( "ER", "错误代码",        false, true, "只读,ReadDouble 0 ~ 255" ),
				new DeviceAddressExample( "SR", "运行/停止转换",    false, true, "Double 0:运行  1:停止" ),
				new DeviceAddressExample( "G1", "PID/自整定",    false, true, "Double 0:PID  1:AT" ),
				new DeviceAddressExample( "S1", "设定值(SV1)",    false, true, "Double 量程低限到量程高限" ),
				new DeviceAddressExample( "A1", "第一报警设定",    false, true, "Double -1999~9999" ),
				new DeviceAddressExample( "A2", "第二报警设定",    false, true, "Double -1999~9999" ),
				new DeviceAddressExample( "A3", "第一加热断线报警设定",    false, true, "Double 0.0 ~ 100.0 A" ),
				new DeviceAddressExample( "A4", "第二加热断线报警设定",    false, true, "Double 1.0 ~ 100.0 A" ),
				new DeviceAddressExample( "A5", "控制回路断线报警设定",    false, true, "Double 0 ~ 7200 秒" ),
				new DeviceAddressExample( "P1", "比例带(加热侧)",         false, true, "Double 0 ~ 满量程" ),
				new DeviceAddressExample( "I1", "积分时间",         false, true, "Double 0 ~ 3600 秒" ),
				new DeviceAddressExample( "D1", "微分时间",         false, true, "Double 0 ~ 3600 秒" ),
				new DeviceAddressExample( "W1", "积分饱和带宽",         false, true, "Double 比例带的1%-100%" ),
				new DeviceAddressExample( "P2", "制冷侧比例带",         false, true, "Double 比例带的1%-3000%" ),
				new DeviceAddressExample( "V1", "冷热死区",         false, true, "Double -10.0 ~ 10.0" ),
				new DeviceAddressExample( "T0", "比例周期(输出1)",         false, true, "Double 0 ~ 100 秒" ),
				new DeviceAddressExample( "T1", "比例周期(输出12",         false, true, "Double 0 ~ 100 秒" ),
				new DeviceAddressExample( "G2", "自主校正",         false, true, "Double  0:停止   1:开始" ),
				new DeviceAddressExample( "PB", "PV基准(量程低限到量程高限)",         false, true, "Double  -1999~1999 ℃" ),
			};
		}
	}
}
