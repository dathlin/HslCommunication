using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.BasicFramework;

namespace HslCommunicationDemo.Plugins
{
	public interface IEdgePlugins
	{
		/// <summary>
		/// 当前的插件的DLL的文件名称，例如 hugong.vulcanizer.dll
		/// </summary>
		string DllName { get; set; }

		/// <summary>
		/// 公司的名称信息
		/// </summary>
		string Company { get; set; }

		/// <summary>
		/// 当前公司的介绍信息
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// 插件的网址信息
		/// </summary>
		string Http { get; set; }

		/// <summary>
		/// 当前插件的框架信息
		/// </summary>
		string Framework { get; set; }

		/// <summary>
		/// 当前的插件的版本
		/// </summary>
		SystemVersion Version { get; set; }

		/// <summary>
		/// 当前的品牌的自定义的图标信息，需要为一个16*16大小的png,jpg格式的图片的内容
		/// </summary>
		byte[] Icon16 { get; set; }

		/// <summary>
		/// 当前插件的发布日期
		/// </summary>
		DateTime ReleaseData { get; set; }
	}
}
