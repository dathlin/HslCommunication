using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HslCommunicationDemo.PLC.Lsis
{
	internal class Helper
	{
		public static DeviceAddressExample[] GetLsisCnetAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "PB0",  "",       true, true, "示例: PX100,PB100,PW100,PD100,PL100  位读取时支持 PW100.0" ),
				new DeviceAddressExample( "MB0",  "",       true, true, "示例: MX100,MB100,MW100,MD100,ML100  位读取时支持 MW100.0" ),
				new DeviceAddressExample( "LB0",  "",       true, true, "示例: LX100,LB100,LW100,LD100,LL100" ),
				new DeviceAddressExample( "KB0",  "",       true, true, "示例: KX100,KB100,KW100,KD100,KL100" ),
				new DeviceAddressExample( "FB0",  "",       true, true, "示例: FX100,FB100,FW100,FD100,FL100" ),
				new DeviceAddressExample( "TB0",  "",       true, true, "示例: TX100,TB100,TW100,TD100,TL100" ),
				new DeviceAddressExample( "CB0",  "",       true, true, "示例: CX100,CB100,CW100,CD100,CL100" ),
				new DeviceAddressExample( "DB0",  "",       true, true, "示例: DX100,DB100,DW100,DD100,DL100" ),
				new DeviceAddressExample( "SB0",  "",       true, true, "示例: SX100,SB100,SW100,SD100,SL100" ),
				new DeviceAddressExample( "QB0",  "",       true, true, "示例: QX100,QB100,QW100,QD100,QL100" ),
				new DeviceAddressExample( "ID0",  "",       true, true, "示例: IX100,IB100,IW100,ID100,IL100" ),
				new DeviceAddressExample( "NB0",  "",       true, true, "示例: NX100,NB100,NW100,ND100,NL100" ),
				new DeviceAddressExample( "UB0",  "",       true, true, "示例: UX100,UB100,UW100,UD100,UL100" ),
				new DeviceAddressExample( "ZB0",  "",       true, true, "示例: ZX100,ZB100,ZW100,ZD100,ZL100" ),
				new DeviceAddressExample( "RB0",  "",       true, true, "示例: RX100,RB100,RW100,RD100,RL100" ),
				new DeviceAddressExample( "M0",  "",       true, true, "以上地址如果不写类型，则默认都是 MW0" ),
				new DeviceAddressExample( "s=2;M0",  "",       true, true, "地址里支持携带站号" ),
			};
		}
	}
}
