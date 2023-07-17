using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo.HslDebug
{
	public class PacketMessageItem
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Message { get; set; }

		#region IXmlConvert Implement

		/// <summary>
		/// 对象从xml元素解析，初始化指定的数据
		/// </summary>
		/// <param name="element">包含节点信息的Xml元素</param>
		public virtual void LoadByXmlElement( XElement element )
		{
			Name        = DataTableItem.GetXmlValue( element, nameof( Name ), Name, m => m );
			Description = DataTableItem.GetXmlValue( element, nameof( Description ), Description, m => m );
			Message     = DataTableItem.GetXmlValue( element, nameof( Message ), Message, m => m );
		}

		/// <summary>
		/// 对象解析为Xml元素，方便的存储
		/// </summary>
		/// <returns>包含节点信息的Xml元素</returns>
		public virtual XElement ToXmlElement( )
		{
			XElement element = new XElement( nameof( PacketMessageItem ) );
			element.SetAttributeValue( nameof( Name ), Name );
			if (!string.IsNullOrEmpty( Description ))
				element.SetAttributeValue( nameof( Description ), Description );
			if (!string.IsNullOrEmpty( Message ))
				element.SetAttributeValue( nameof( Message ), Message );
			return element;
		}

		#endregion

		public override string ToString( )
		{
			if (!string.IsNullOrEmpty( Name )) return Name;
			return Message;
		}
	}
}
