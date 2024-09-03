using HslCommunication.BasicFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	internal class DataTableItem
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public int Length { get; set; } = -1;

		public string DataTypeCode { get; set; }

		public string Unit { get; set; } = "";

		public StringEncoding StringEncoding { get; set; }

		public string Expression { get; set; }  // 表达式 例如  x * 0.1 + 10     x 就是读取的输入值

		#region IXmlConvert Implement

		/// <summary>
		/// 对象从xml元素解析，初始化指定的数据
		/// </summary>
		/// <param name="element">包含节点信息的Xml元素</param>
		public virtual void LoadByXmlElement( XElement element )
		{
			Name = GetXmlValue( element, nameof( Name ), Name, m => m );
			Description = GetXmlValue( element, nameof( Description ), Description, m => m );
			Address = element.Attribute( nameof( Address ) ).Value;
			DataTypeCode = GetXmlValue( element, nameof( DataTypeCode ), DataTypeCode, m => m ).ToLower( );
			Length = GetXmlValue( element, nameof( Length ), Length, int.Parse );
			Unit = GetXmlValue( element, nameof( Unit ), Unit, m => m );
			StringEncoding = GetXmlEnum( element, nameof( StringEncoding ), StringEncoding.ASCII );
			Expression = GetXmlValue( element, nameof( Expression ), Expression, m => m );
		}

		/// <summary>
		/// 对象解析为Xml元素，方便的存储
		/// </summary>
		/// <returns>包含节点信息的Xml元素</returns>
		public virtual XElement ToXmlElement( )
		{
			XElement element = new XElement( nameof( DataTableItem ) );
			element.SetAttributeValue( nameof( Name ), Name );
			if (!string.IsNullOrEmpty( Description ))
				element.SetAttributeValue( nameof( Description ), Description );
			element.SetAttributeValue( nameof( Address ), Address );
			element.SetAttributeValue( nameof( DataTypeCode ), DataTypeCode );
			if (Length != -1)
				element.SetAttributeValue( nameof( Length ), Length );
			if (!string.IsNullOrEmpty( Unit ))
				element.SetAttributeValue( nameof( Unit ), Unit );
			if (DataTypeCode == "string")
				element.SetAttributeValue( nameof( StringEncoding ), StringEncoding.ToString( ) );
			if (!string.IsNullOrEmpty( Expression ))
				element.SetAttributeValue( nameof( Expression ), Expression );
			return element;
		}

		#endregion



		/// <summary>
		/// 从XElement中提取相关的属性信息，如果不存在，就返回默认值
		/// </summary>
		/// <typeparam name="T">最终的类型信息</typeparam>
		/// <param name="element">元素内容</param>
		/// <param name="name">属性的名称</param>
		/// <param name="defaultValue">默认提供的值</param>
		/// <param name="trans">转换方式</param>
		/// <returns>最终的值</returns>
		public static T GetXmlValue<T>( XElement element, string name, T defaultValue, Func<string, T> trans )
		{
			XAttribute attribute = element.Attribute( name );
			if (attribute == null) return defaultValue;

			try
			{
				return trans( attribute.Value );
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <inheritdoc cref="GetXmlValue{T}(XElement, string, T, Func{string, T})"/>
		public static T GetXmlEnum<T>( XElement element, string name, T defaultValue ) where T : struct
		{
			XAttribute attribute = element.Attribute( name );
			if (attribute == null) return defaultValue;

			try
			{
				return SoftBasic.GetEnumFromString<T>( attribute.Value );
			}
			catch
			{
				return defaultValue;
			}
		}
	}

	public enum StringEncoding
	{
		/// <summary>
		/// ASCII编码，一般英文的都是这个编码
		/// </summary>
		ASCII,

		/// <summary>
		/// ASCII的扩展编码，常见于windows系统
		/// </summary>
		ANSI,

		/// <summary>
		/// 万国码，一般网页用这个编码
		/// </summary>
		UTF8,

		/// <summary>
		/// Unicode编码，支持中文
		/// </summary>
		UTF16,

		/// <summary>
		/// 大端的Unicode编码，支持中文
		/// </summary>
		UTF16Big,

		/// <summary>
		/// 国标2312编码，中文操作系统使用的编码信息
		/// </summary>
		GB2312,

	}
}
