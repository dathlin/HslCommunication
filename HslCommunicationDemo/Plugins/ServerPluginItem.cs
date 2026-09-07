using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace HslCommunicationDemo.Plugins
{
	public class ServerPluginItem : IEdgePlugins
	{
		public string DllName
		{
			get => this.Name;
			set => this.Name = value;
		}

		/// <summary>
		/// 插件名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 公司信息
		/// </summary>
		public string Company { get; set; }

		/// <summary>
		/// 描述信息
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 网址
		/// </summary>
		public string Http { get; set; }

		/// <summary>
		/// 框架信息, net461/netstandard 可能支持一种，也可能支持两种
		/// </summary>
		public string Framework { get; set; }

		/// <summary>
		/// 版本号
		/// </summary>
		[JsonConverter( typeof( JsonSystemVersionConverter ) )]
		public HslCommunication.BasicFramework.SystemVersion Version { get; set; }

		/// <summary>
		/// 图标信息
		/// </summary>
		public byte[] Icon16 { get; set; }

		/// <summary>
		/// 更新日期
		/// </summary>
		public DateTime ReleaseData { get; set; }

		/// <summary>
		/// 更新内容
		/// </summary>
		public string UpdateLog { get; set; }

		/// <summary>
		/// 下载次数
		/// </summary>
		public long Downloads
		{
			get => this.downloadTimes;
			set => this.downloadTimes = value;
		}

		/// <summary>
		/// 当前插件的所有者，也是账户的名称，如果账户名称不一样，则不能更新，只能自己更新自己的插件
		/// </summary>
		public string Owner { get; set; }

		/// <summary>
		/// 传统框架的文件名列表
		/// </summary>
		public List<string> FrameworkFiles { get; set; }

		/// <summary>
		/// 跨平台框架的文件名列表
		/// </summary>
		public List<string> StandardFiles { get; set; }

		/// <summary>
		/// 增加一次下载次数
		/// </summary>
		public void AddDownloadTimes( )
		{
			System.Threading.Interlocked.Increment( ref this.downloadTimes );
		}

		public void LoadByXml( XElement xml )
		{
			Name = GetXmlContent( xml, "Id" );
			Version = new HslCommunication.BasicFramework.SystemVersion( GetXmlContent( xml, "Version" ) );
			Company = GetXmlContent( xml, "Company" );
			ReleaseData = DateTime.Now.Date;

			Http = GetXmlContent( xml, "Http" );
			Description = GetXmlContent( xml, "Description" );
			UpdateLog = GetXmlContent( xml, "UpdateLog" );
			string image = GetXmlContent( xml, "Image" );
			if (!string.IsNullOrEmpty( image ))
			{
				Icon16 = Convert.FromBase64String( image );
			}

			FrameworkFiles = GetFiles( xml, "FileFramework" );
			StandardFiles = GetFiles( xml, "FileStandard" );

			Framework = GetFrameworkString( );
		}


		private string GetFrameworkString( )
		{
			if (FrameworkFiles.Count == 0 && StandardFiles.Count == 0) return string.Empty;
			if (FrameworkFiles.Count > 0 && StandardFiles.Count > 0) return "net462/netstandard";
			if (FrameworkFiles.Count > 0) return "net462";
			return "netstandard";
		}

		private string GetXmlContent( XElement xml, string name )
		{
			XElement xmlElement = xml.Element( name );
			if (xmlElement == null) return string.Empty;

			return xmlElement.Value;
		}

		private List<string> GetFiles( XElement xml, string name )
		{
			List<string> list = new List<string>( );
			XElement xmlElement = xml.Element( name );
			if (xmlElement == null) return list;

			IEnumerable<XElement> xmlFiles = xmlElement.Elements( "File" );
			foreach (XElement xmlFile in xmlFiles)
			{
				string fileName = GetXmlContent( xmlFile, "Name" );
				if (!string.IsNullOrEmpty( fileName ))
				{
					list.Add( fileName );
				}
			}
			return list;
		}

		private long downloadTimes = 0;
	}
}
