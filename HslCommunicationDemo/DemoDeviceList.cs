using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	/// <summary>
	/// 使用XML技术来对配置的信息进行保存
	/// </summary>
	public class DemoDeviceList
	{
		/// <summary>
		/// 默认的实例化方法
		/// </summary>
		public DemoDeviceList( )
		{
			xElement = new XElement( "DeviceList" );
		}

		/// <summary>
		/// 新增一个新的设备参数信息，如果这个设备信息已经存在，就覆盖它
		/// </summary>
		/// <param name="device"></param>
		public void AddDevice( XElement device )
		{
			XElement element = null;
			foreach (var item in xElement.Elements( ))
			{
				if(item.Attribute( XmlGuid ) == device.Attribute( XmlGuid ))
				{
					element = item;
					break;
				}
			}

			if(element != null)
			{
				// 更新原来的element
				foreach (var item in device.Attributes())
				{
					element.SetAttributeValue( item.Name, item.Value );
				}
			}
			else
			{
				xElement.Add( device );
			}
		}

		/// <summary>
		/// 删除一个设备信息
		/// </summary>
		/// <param name="device"></param>
		public void DeleteDevice( XElement device )
		{
			XElement element = null;
			foreach (var item in xElement.Elements( ))
			{
				if (item.Attribute( XmlGuid ) == device.Attribute( XmlGuid ))
				{
					element = item;
					break;
				}
			}

			if (element != null) element.Remove( );
		}

		public void SetDevices(XElement element )
		{
			xElement = element;
		}

		/// <summary>
		/// 获取所有的设备的保存信息
		/// </summary>
		public XElement GetDevices => xElement;


		private XElement xElement;                      // 核心保存的设备列表信息
		public static readonly string XmlName = "Name";
		public static readonly string XmlGuid = "Guid";
		public static readonly string XmlType = "Type";
        public static readonly string XmlEncrypt = "EncryptXml";
		public static readonly string XmlEncrypt2 = "EncryptKeyXml";
		public static readonly string XmlIpAddress = "IP";
		public static readonly string XmlPort = "Port";
		public static readonly string XmlConnectTimeOut = "ConnectTimeOut";
		public static readonly string XmlReceiveTimeOut = "ReceiveTimeOut";
		public static readonly string XmlRack = "Rack";
		public static readonly string XmlSlot = "Slot";
		public static readonly string XmlCom = "ComPort";
		public static readonly string XmlBaudRate = "BaudRate";
		public static readonly string XmlDataBits = "DataBit";
		public static readonly string XmlStopBit = "StopBit";
		public static readonly string XmlParity = "Parity";
		public static readonly string XmlStation = "Station";
		public static readonly string XmlTimeout = "Timeout";
		public static readonly string XmlSumCheck = "SumCheck";
		public static readonly string XmlBinary = "Binary";
		public static readonly string XmlAddressStartWithZero = "AddressStartWithZero";
		public static readonly string XmlDataFormat = "DataFormat";
		public static readonly string XmlStringReverse = "StringReverse";
		public static readonly string XmlUserName = "UserName";
		public static readonly string XmlPassword = "Password";
		public static readonly string XmlRtsEnable = "RtsEnable";
		public static readonly string XmlNetNumber = "NetNumber";
		public static readonly string XmlUnitNumber = "UnitNumber";
		public static readonly string XmlChangeSA1 = "ChangeSA1";
		public static readonly string XmlPCUnitNumber = "PCUnitNumber";
		public static readonly string XmlDeviceId = "DeviceId";
		public static readonly string XmlCpuType = "CpuType";
		public static readonly string XmlCompanyID = "CompanyID";
		public static readonly string XmlTarget = "Target";
		public static readonly string XmlSender = "Sender";
		public static readonly string XmlTagCache = "TagCache";
		public static readonly string XmlKeepLive = "KeepLive";
		public static readonly string XmlTopic = "Topic";
		public static readonly string XmlUrl = "Url";
		public static readonly string XmlRetureMessage = "ReturnMessage";
		public static readonly string XmlCrossDomain = "CrossDomain";
		public static readonly string XmlContentType = "ContentType";
		public static readonly string XmlToken = "Token";
		public static readonly string XmlAlias = "Alias";
		public static readonly string XmlFilePath = "FilePath";
	}
}
