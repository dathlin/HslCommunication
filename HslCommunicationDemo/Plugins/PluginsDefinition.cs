using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Plugin;
using Newtonsoft.Json;

namespace HslCommunicationDemo.Plugins
{
	public class PluginsDefinition : IEdgePlugins
	{
		/// <inheritdoc cref="IEdgePlugins.DllName"/>
		public string DllName { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Company"/>
		public string Company { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Description"/>
		public string Description { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Http"/>
		public string Http { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Framework"/>
		public string Framework { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Version"/>
		[JsonConverter( typeof( JsonSystemVersionConverter ) )]
		public SystemVersion Version { get; set; }

		/// <inheritdoc cref="IEdgePlugins.Icon16"/>
		public byte[] Icon16 { get; set; }

		/// <inheritdoc cref="IEdgePlugins.ReleaseData"/>
		public DateTime ReleaseData { get; set; }

		/// <summary>
		/// 设备定义的列表
		/// </summary>
		public Dictionary<string, PluginsDeviceDefinition> DeviceDefinitions { get; set; }

		/// <summary>
		/// 获取插件类型的字符串信息，如果没有定义的话，就使用dll本身的名字作为插件类型信息
		/// </summary>
		/// <returns>字符串内容</returns>
		public string GetPluginTypeString( )
		{
			if (this.DllName.EndsWith( ".dll", StringComparison.OrdinalIgnoreCase ))
				return this.DllName.Substring( 0, this.DllName.Length - 4 );
			return this.DllName;
		}
	}
}
