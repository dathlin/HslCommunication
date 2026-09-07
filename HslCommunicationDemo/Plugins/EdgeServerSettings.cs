using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Plugin;
using HslCommunication.LogNet;
using HslCommunicationDemo.Database;

namespace HslCommunicationDemo.Plugins
{
	/// <summary>
	/// Demo存储的插件信息
	/// </summary>
	public class EdgeServerSettings
	{
		public static Dictionary<string, PluginsDefinition> Plugins { get; set; }

		/// <summary>
		/// 插件的目录信息
		/// </summary>
		public static string PluginsDirectory( ) =>
			Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Plugins" );


		public OperateResult UnloadRegisterPlugins( string dllName )
		{
			string path = dllName;
			if (path.EndsWith( ".dll" ) || path.EndsWith( ".DLL" )) path = path.RemoveLast( 4 );
			try
			{
				path = Path.Combine( PluginsDirectory( ), path );
				if (Directory.Exists( path ))
				{
					Directory.Delete( path, true );
					return OperateResult.CreateSuccessResult( );
				}
				else
					return new OperateResult( $"Current Plugins[{dllName}] not in edge server!" );
			}
			catch (Exception ex)
			{
				return new OperateResult( $"Unload Plugins[{dllName}] failed: " + ex.Message );
			}
		}

		public OperateResult<PluginsDefinition[]> GetRegisterPlugins( )
		{
			if (Plugins != null)
			{
				return OperateResult.CreateSuccessResult( Plugins.Values.ToArray( ) );
			}
			else
			{
				return OperateResult.CreateSuccessResult( new PluginsDefinition[0] );
			}
		}

		public OperateResult<int> CheckRegisterPluginsExist( string pluginsDllName, string pluginsType = "" )
		{
			string dllName = pluginsDllName;
			string path = dllName;
			if (path.EndsWith( ".dll" ) || path.EndsWith( ".DLL" )) path = path.RemoveLast( 4 );
			try
			{
				path = Path.Combine( PluginsDirectory( ), path );
				if (Directory.Exists( path ))
				{
					path = Path.Combine( path, dllName );
					return File.Exists( path ) ? OperateResult.CreateSuccessResult( 1 ) : OperateResult.CreateSuccessResult( 0 );
				}
				else
					return OperateResult.CreateSuccessResult( 0 );
			}
			catch (Exception ex)
			{
				return new OperateResult<int>( $"check Plugins[{dllName}] failed: " + ex.Message );
			}
		}

		public OperateResult UploadPluginsFile( string pluginsDllName, string fileName, byte[] content )
		{
			string path = pluginsDllName;
			if (path.EndsWith( ".dll" ) || path.EndsWith( ".DLL" )) path = path.RemoveLast( 4 );
			string filePath = Path.Combine( PluginsDirectory( ), path, fileName );
			if (!Directory.Exists( Path.Combine( PluginsDirectory( ), path ) ))
				Directory.CreateDirectory( Path.Combine( PluginsDirectory( ), path ) );
			try
			{
				File.WriteAllBytes( filePath, content );
				return OperateResult.CreateSuccessResult( );
			}
			catch (Exception ex)
			{
				return new OperateResult( ex.Message );
			}
		}

		public OperateResult LoadRegisterPlugins( string pluginsDllName, string pluginsType = "" )
		{
			string dllName = pluginsDllName;
			string path = dllName;
			if (path.EndsWith( ".dll" ) || path.EndsWith( ".DLL" )) path = path.RemoveLast( 4 );

			path = Path.Combine( PluginsDirectory( ), path );
			OperateResult<string, PluginsDefinition> plugins = LoadSinglePlugin( null, path );
			if (!plugins.IsSuccess) return OperateResult.CreateFailedResult<string>( plugins );

			if (Plugins == null) return new OperateResult<string>( "插件系统异常，对象空值！" );
			if (Plugins.ContainsKey( plugins.Content1 ))
				return new OperateResult<string>( $"当前插件[{plugins.Content1}]在边缘网关系统已经存在，无法重复加载，需要重启系统加载。" );
			else
			{
				Plugins.Add( plugins.Content1, plugins.Content2 );
				return OperateResult.CreateSuccessResult( "" );
			}
		}


		/// <summary>
		/// 用于运行时加载的插件目录信息，所有的插件，不管是设备插件，还是数据云插件，数据库插件，都是复制到这个目录下，并进行加载的
		/// </summary>
		/// <remarks>每次系统启动时就会清空一次</remarks>
		/// <returns>运行时的目录</returns>
		public static string PluginsRuntimeDirectory( ) =>
			Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "PluginsRuntime" );

		/// <summary>
		/// 加载单个的插件到边缘网关系统，返回是否加载成功的结果信息，新增插件可以在运行时加载
		/// </summary>
		/// <param name="logNet">日志对象</param>
		/// <param name="folder">插件的目录</param>
		/// <returns>是否加载成功</returns>
		public static OperateResult<string, PluginsDefinition> LoadSinglePlugin( ILogNet logNet, string folder )
		{
			DirectoryInfo directory = null;
			try
			{
				directory = new DirectoryInfo( folder );
			}
			catch (Exception ex)
			{
				return new OperateResult<string, PluginsDefinition>( "加载插件失败，原因为DirectoryInfo对象创建失败：" + ex.Message );
			}
			string pluginFileName = Path.Combine( folder, directory.Name + ".dll" );
			if (!File.Exists( pluginFileName ))
			{
				// 路径名的插件不存在
				return new OperateResult<string, PluginsDefinition>( "插件加载异常，插件路径同名的DLL文件不存在。" );
			}
			FileInfo pluginFile = null;
			try
			{
				pluginFile = new FileInfo( pluginFileName );
			}
			catch (Exception ex)
			{
				return new OperateResult<string, PluginsDefinition>( $"插件[{directory.Name}]加载异常，FileInfo创建失败：" + ex.Message );
			}

			string pluginPath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, PluginsRuntimeDirectory( ) );
			try
			{
				if (!Directory.Exists( pluginPath )) Directory.CreateDirectory( pluginPath );
				// 将插件的所有的文件都复制过去
				foreach (FileInfo fileInfo in directory.GetFiles( ))
				{
					string fileNewName = Path.Combine( pluginPath, fileInfo.Name );
					try
					{
						fileInfo.CopyTo( fileNewName, true );
					}
					catch
					{
						// 移动文件失败，说明可能已经存在了，就跳过
						continue;
					}
				}
			}
			catch (Exception ex)
			{
				return new OperateResult<string, PluginsDefinition>( $"插件[{pluginFile.Name}]加载异常，复制插件：{pluginFileName} 到网关目录失败，当前插件跳过。原因：" + ex.Message );
			}

			string pluginsNewFile = Path.Combine( pluginPath, directory.Name + ".dll" );
			Assembly assembly = null;
			Type pluginsHelperType = null;
			try
			{
				assembly = Assembly.LoadFrom( pluginsNewFile );
				pluginsHelperType = assembly.GetTypes( ).FirstOrDefault( m => m.Name == "PluginsHelper" );
				if (pluginsHelperType == null)
				{
					return new OperateResult<string, PluginsDefinition>( $"加载[{pluginFile.Name}]插件异常，原因：该插件命名空间里不存在 PluginsHelper 类！" );
				}
			}
			catch (Exception ex)
			{
				return new OperateResult<string, PluginsDefinition>( $"加载[{pluginFile.Name}]插件到程序集时发生异常，原因：" + ex.Message );
			}

			PluginsDefinition pluginsDefinition = new PluginsDefinition( );
			pluginsDefinition.DllName           = assembly.ManifestModule.Name;
			pluginsDefinition.Company           = pluginsHelperType.GetProperty( "Company" ).GetValue( null, null ) as string;
			pluginsDefinition.ReleaseData       = (DateTime)pluginsHelperType.GetProperty( "ReleaseDate" ).GetValue( null, null );
			pluginsDefinition.Description       = pluginsHelperType.GetProperty( "Description" ).GetValue( null, null ) as string;
			pluginsDefinition.Http              = pluginsHelperType.GetProperty( "Http" )?.GetValue( null, null ) as string;
			pluginsDefinition.Framework         = pluginsHelperType.GetProperty( "Framework" )?.GetValue( null, null ) as string;
			pluginsDefinition.Icon16            = pluginsHelperType.GetProperty( "Icon16" )?.GetValue( null, null ) as byte[];

			// 插件的版本号信息支持直接设置 string，不依赖hslcommunication通信库，也可以设置为 SystemVersion 类型
			PropertyInfo propertyInfoVerison = pluginsHelperType.GetProperty( "Version" );
			if (propertyInfoVerison.PropertyType == typeof( string ))
				pluginsDefinition.Version = new SystemVersion( propertyInfoVerison.GetValue( null, null ) as string );
			else
				pluginsDefinition.Version = propertyInfoVerison.GetValue( null, null ) as SystemVersion;
			// 定义插件支持的设备列表信息
			pluginsDefinition.DeviceDefinitions = new Dictionary<string, PluginsDeviceDefinition>( );
			// 插件的实际模式支持完全自由的继承实现
			object obj_devices = pluginsHelperType.GetMethod( "DeviceDefinitions" )?.Invoke( null, null );
			if (obj_devices != null)
			{
				if (obj_devices.GetType( ) == typeof( List<object> ))
				{
					List<object> list = obj_devices as List<object>;
					foreach (var item in list)
					{
						// 这是插件里完全自定义的类实现的，不依赖任何的dll组件实现的插件信息
						PluginsDeviceDefinition definition = new PluginsDeviceDefinition( item );
						definition.PluginFilePath = pluginFileName;
						AddPluginsDeviceDefinition( pluginsDefinition, logNet, definition );
					}
				}
				else if (obj_devices.GetType( ) == typeof( object[] ))
				{
					object[] list = obj_devices as object[];
					foreach (var item in list)
					{
						// 这是插件里完全自定义的类实现的，不依赖任何的dll组件实现的插件信息
						PluginsDeviceDefinition definition = new PluginsDeviceDefinition( item );
						definition.PluginFilePath = pluginFileName;
						AddPluginsDeviceDefinition( pluginsDefinition, logNet, definition );
					}
				}
			}

			return OperateResult.CreateSuccessResult( assembly.ManifestModule.Name, pluginsDefinition );
		}

		private static void AddPluginsDeviceDefinition( PluginsDefinition pluginsDefinition, ILogNet logNet, PluginsDeviceDefinition item )
		{
			if (!pluginsDefinition.DeviceDefinitions.ContainsKey( item.DeviceName ))
				pluginsDefinition.DeviceDefinitions.Add( item.DeviceName, item );
		}


		public static Dictionary<string, PluginsDefinition> LoadPlugins( ILogNet logNet, string path )
		{
			Dictionary<string, PluginsDefinition> plugins = new Dictionary<string, PluginsDefinition>( );
			string[] pluginsFolders = Directory.GetDirectories( path );

			foreach (string folder in pluginsFolders)
			{
				OperateResult<string, PluginsDefinition> load = LoadSinglePlugin( logNet, folder );
				if (!load.IsSuccess)
				{
					logNet?.WriteError( load.Message );
					continue;
				}

				plugins.Add( load.Content1, load.Content2 );
			}
			return plugins;
		}
	}
}
