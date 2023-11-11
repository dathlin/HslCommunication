using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Instrument
{
	internal class DLTHelper
	{

		/// <summary>
		/// 获取DLT645-2007协议的地址示例
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetDlt645Address( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "00-00-00-00", "当前组合有功总电能", false, false, "读double, 00-00-01-00到00-00-3F-00分别是组合有功费率1~63电能", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-01-00-00", "当前正向有功总电能", false, false, "读double, 00-01-01-00到00-01-3F-00分别是正向有功费率1~63电能", fill: true, unit:"kwh", dataType: "double"),
				new DeviceAddressExample( "00-02-00-00", "当前反向有功总电能", false, false, "读double, 00-02-01-00到00-02-3F-00分别是反向有功费率1~63电能", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-03-00-00", "当前组合无功总电能", false, false, "读double, 00-03-01-00到00-03-3F-00分别是组合无功费率1~63电能", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-09-00-00", "当前正向视在总电能", false, false, "读double, 00-09-01-00到00-09-3F-00分别是正向视在费率1~63电能", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-0A-00-00", "当前反向视在总电能", false, false, "读double, 00-0A-01-00到00-0A-3F-00分别是反向视在费率1~63电能", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "02-01-01-00", "A相电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "02-01-02-00", "B相电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "02-01-03-00", "C相电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "02-02-01-00", "A相电流", false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "02-02-02-00", "B相电流", false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "02-02-03-00", "C相电流", false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "02-03-00-00", "瞬时总有功功率", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, unit:"kw", dataType: "double" ),
				new DeviceAddressExample( "02-04-00-00", "瞬时总无功功率", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, unit:"kvar", dataType: "double" ),
				new DeviceAddressExample( "02-05-00-00", "瞬时总视在功率", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, unit:"kva", dataType: "double" ),
				new DeviceAddressExample( "02-06-00-00", "总功率因素", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, dataType: "double" ),
				new DeviceAddressExample( "02-07-01-00", "A相相角", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, unit:"°", dataType: "double" ),
				new DeviceAddressExample( "02-08-01-00", "A相电压波形失真度", false, false, "读double，DI1=1时表示A相，2时表示B相，3时表示C相", fill: true, unit:"%", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-01", "零线电流", false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-02", "电网频率", false, false, "读double", fill: true, unit:"HZ", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-03", "一分钟有功总平均功率", false, false, "读double", fill: true, unit:"kw", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-04", "当前有功需量", false, false, "读double", fill: true, unit:"kw", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-05", "当前无功需量", false, false, "读double", fill: true, unit:"kvar", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-06", "当前视在需量", false, false, "读double", fill: true, unit:"kva", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-07", "表内温度", false, false, "读double", fill: true, unit:"℃", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-08", "时钟电池电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-09", "停电抄表电池电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "02-80-00-0A", "内部电池工作时间", false, false, "读double", fill: true, unit:"min", dataType: "double" ),
				new DeviceAddressExample( "04-00-01-01", "日期及星期(0表示星期天)", false, false, "ReadString(\"04-00-01-01\", 4)", fill: true, dataType: "string" ),
				new DeviceAddressExample( "04-00-01-02", "时分秒", false, false, "ReadString(\"04-00-01-02\", 3)", fill: true, dataType: "string" ),
				new DeviceAddressExample( "04-00-04-03", "资产管理编码", false, false, "ReadString(\"04-00-04-03\", 32)", fill: true, dataType: "string" ),
				new DeviceAddressExample( "04-00-04-0B", "电表型号", false, false, "ReadString(\"04-00-04-0B\", 10)", fill: true, dataType: "string" ),
				new DeviceAddressExample( "04-00-04-0C", "生产日期", false, false, "ReadString(\"04-00-04-0C\", 10)", fill: true, dataType: "string" ),
			};
		}

		public static DeviceAddressExample[] GetDlt6451997Address( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "90-10", "当前正向有功总电能",   false, false, "读double, 90-11到90-1E分别是正向有功费率1~14电能",   fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "90-20", "当前反向有功总电能",   false, false, "读double, 90-21到90-2E分别是反向有功费率1~14电能",   fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "91-10", "当前正向无功总电能",   false, false, "读double, 91-11到91-1E分别是正向无功费率1~14电能",   fill: true, unit:"kvarh", dataType: "double" ),
				new DeviceAddressExample( "91-20", "当前反向无功总电能",   false, false, "读double, 91-21到91-2E分别是反向无功费率1~14电能",   fill: true, unit:"kvarh", dataType: "double" ),
				new DeviceAddressExample( "91-30", "当前一象限无功总电能", false, false, "读double, 91-31到91-3E分别是一象限无功费率1~14电能", fill: true, unit:"kvarh", dataType: "double" ),
				new DeviceAddressExample( "91-40", "当前四象限无功总电能", false, false, "读double, 91-41到91-4E分别是四象限无功费率1~14电能", fill: true, unit:"kvarh", dataType: "double" ),
				new DeviceAddressExample( "91-50", "当前二象限无功总电能", false, false, "读double, 91-51到91-5E分别是二象限无功费率1~14电能", fill: true, unit:"kvarh", dataType: "double"),
				new DeviceAddressExample( "91-60", "当前三象限无功总电能", false, false, "读double, 91-61到91-6E分别是一象限无功费率1~14电能", fill: true, unit:"kvarh", dataType: "double" ),
				new DeviceAddressExample( "B2-10", "最近一次编程时间(月日h min)", false, false, "读string" ),
				new DeviceAddressExample( "B2-12", "编程次数",            false, false, "读int",                                                                      dataType: "int" ),
				new DeviceAddressExample( "B2-14", "电池工作时间",        false, false, "读int", fill: true, unit:"min",                                              dataType: "int" ),
				new DeviceAddressExample( "B3-10", "总断相次数",          false, false, "读int", fill: true,                                                          dataType: "int" ),
				new DeviceAddressExample( "B3-20", "断相时间累计值",      false, false, "读int", fill: true, unit:"min",                                              dataType: "int" ),
				new DeviceAddressExample( "B6-11", "A相电压",             false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "B6-12", "B相电压",             false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "B6-13", "C相电压",             false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "B6-21", "A相电流",             false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "B6-22", "B相电流",             false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "B6-23", "C相电流",             false, false, "读double", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "B6-30", "瞬时有功功率", false, false, "读double，B6-31到B6-33分别表示A,B,C相有功功率", header:false, fill: true, unit:"kw" , dataType: "double"),
				new DeviceAddressExample( "B6-40", "瞬时无功功率", false, false, "读double，B6-41到B6-43分别表示A,B,C相无功功率", header:false, fill: true, unit:"kvarhA", dataType: "double" ),
				new DeviceAddressExample( "B6-50", "功率因数", false, false, "读double，B6-51到B6-53分别表示A,B,C相功率因数", header: false, fill: true),
				new DeviceAddressExample( "C0-32", "表号",   false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "C0-33", "用户号", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "C0-34", "设备码", false, false, "读string", fill: true, dataType: "string" ),
			};
		}

		/// <summary>
		/// 获取DLT698协议的地址示例列表
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetDlt698Address( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "00-00-02-00", "组合有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-10-02-00", "正向有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-20-02-00", "反向有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-30-02-00", "组合无功1总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "00-40-02-00", "组合无功2总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "10-00-02-00", "当前组合有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "10-10-02-00", "当前正向有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "10-20-02-00", "当前反向有功总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "10-30-02-00", "当前组合无功1总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "10-40-02-00", "当前组合无功2总电能", false, false, "读double, 实际是double[5]", fill: true, unit:"kwh", dataType: "double" ),
				new DeviceAddressExample( "20-00-02-00", "电压", false, false, "读double[3] 分别是电压A，电压B，电压C", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "20-01-02-00", "电流", false, false, "读double[3] 分别是电流A，电流B，电流C", fill: true, unit:"A", dataType: "double" ),
				new DeviceAddressExample( "20-02-02-00", "电压相角", false, false, "读double[3] 分别是电压A相角，电压B相角，电压C相角", fill: true, unit:"°", dataType: "double" ),
				new DeviceAddressExample( "20-03-02-00", "电压电流相角", false, false, "读double[3] 分别是电压电流相角A相角，电压电流相角B相角，电压电流相角C相角", fill: true, unit:"°", dataType: "double" ),
				new DeviceAddressExample( "20-04-02-00", "有功功率", false, false, "读double", fill: true, unit:"W", dataType: "double" ),
				new DeviceAddressExample( "20-05-02-00", "无功功率", false, false, "读double", fill: true, unit:"Var", dataType: "double" ),
				new DeviceAddressExample( "20-06-02-00", "视在功率", false, false, "读double", fill: true, unit:"VA", dataType: "double" ),
				new DeviceAddressExample( "20-0A-02-00", "功率因数", false, false, "读double", fill: true, dataType: "double" ),
				new DeviceAddressExample( "20-0F-02-00", "电网频率", false, false, "读double", fill: true, unit:"Hz", dataType: "double" ),
				new DeviceAddressExample( "20-10-02-00", "表内温度", false, false, "读double", fill: true, unit:"℃", dataType: "double" ),
				new DeviceAddressExample( "20-11-02-00", "时钟电池电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "20-12-02-00", "停电抄表电池电压", false, false, "读double", fill: true, unit:"V", dataType: "double" ),
				new DeviceAddressExample( "20-13-02-00", "时钟电池工作时间", false, false, "读double", fill: true, unit:"min", dataType: "double" ),
				new DeviceAddressExample( "20-14-02-00", "电能表运行状态字", true, false, "读string或bool，共有7组数组，每组16个位，最后一个字节表示哪一组" ),
				new DeviceAddressExample( "20-15-02-00", "电能表跟随上报状态字", true, false, "读string或bool" ),
				new DeviceAddressExample( "20-17-02-00", "当前有功需量", false, false, "读double", fill: true, unit:"kw", dataType: "double" ),
				new DeviceAddressExample( "20-18-02-00", "当前无功需量", false, false, "读double", fill: true, unit:"kvar", dataType: "double" ),
				new DeviceAddressExample( "20-19-02-00", "当前视在需量", false, false, "读double", fill: true, unit:"kva", dataType: "double" ),
				new DeviceAddressExample( "20-26-02-00", "电压不平衡率", false, false, "读double", fill: true, unit:"%", dataType: "double" ),
				new DeviceAddressExample( "20-27-02-00", "电流不平衡率", false, false, "读double", fill: true, unit:"%", dataType: "double" ),
				new DeviceAddressExample( "20-29-02-00", "负载率", false, false, "读double", fill: true, unit:"%", dataType: "double" ),
				new DeviceAddressExample( "40-00-02-00", "日期时间", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "40-01-02-00", "通信地址", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "40-02-02-00", "表号", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "40-03-02-00", "客户编号", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "40-04-02-00", "设备地理坐标", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-00-02-00", "最大需量周期", false, false, "读double", fill: true, unit:"min", dataType: "double" ),
				new DeviceAddressExample( "41-01-02-00", "滑差时间", false, false, "读double", fill: true, unit:"%", dataType: "double" ),
				new DeviceAddressExample( "41-02-02-00", "校表脉冲宽度", false, false, "读double", fill: true, unit:"ms", dataType: "double" ),
				new DeviceAddressExample( "41-03-02-00", "资产管理码", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-04-02-00", "额定电压", false, false, "读string", fill: true, unit:"V", dataType: "string" ),
				new DeviceAddressExample( "41-05-02-00", "额定电流/基本电流", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-06-02-00", "最大电流", false, false, "读string" , fill: true, dataType: "string"),
				new DeviceAddressExample( "41-07-02-00", "有功准确度等级	", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-08-02-00", "无功准确度等级	", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-09-02-00", "电能表有功常数(imp/kWh)", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-0A-02-00", "电能表无功常数(imp/kWh)", false, false, "读string", fill: true, dataType: "string" ),
				new DeviceAddressExample( "41-0B-02-00", "电能表型号", false, false, "读string", fill: true, dataType: "string" ),
			};
		}
	}
}
