using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Device;
using HslCommunication.Enthernet;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo
{
	/// <summary>
	/// Built-in AI gateway that exposes the connected Demo devices through HttpServer.
	/// </summary>
	public sealed class AIGatewayService
	{
		public static readonly AIGatewayService Instance = new AIGatewayService( );

		private HttpServer server;
		private int collectionIdSeed = 0;
		private readonly Dictionary<string, GatewayCollectionTask> collections = new Dictionary<string, GatewayCollectionTask>( );
		private readonly object collectionLock = new object( );

		public string BaseUrl { get; private set; }

		public bool IsStarted => server != null;

		public string LastError { get; private set; } = string.Empty;

		public HttpServer Server => this.server;

		private AIGatewayService( )
		{
		}

		public bool Start( string prefix = null )
		{
			if (server != null) return true;
			try
			{
				HttpServer httpServer = new HttpServer( )
				{
					IsCrossDomain = true,
					ServerEncoding = Encoding.UTF8
				};
				httpServer.HandleRequestFunc = HandleRequest;
				if (string.IsNullOrEmpty( prefix ))
				{
					httpServer.Start( DefaultBaseUrl );
				}
				else
				{
					if (int.TryParse( prefix, out int port ))
					{
						httpServer.Start( port );
					}
					else
					{
						httpServer.Start( prefix );
					}
				}
				
				server = httpServer;
				BaseUrl = prefix ?? DefaultBaseUrl;
				LastError = string.Empty;
				return true;
			}
			catch (Exception ex)
			{
				LastError = ex.Message;
				DemoUtils.ShowMessage( "Start AI gateway Service faild: " + SoftBasic.GetExceptionMessage( ex ) );
				return false;
			}
		}

		public void Stop( )
		{
			lock (collectionLock)
			{
				foreach (GatewayCollectionTask task in collections.Values)
				{
					task.StopRequested = true;
				}
				collections.Clear( );
			}

			if (server != null)
			{
				server.Close( );
				server = null;
			}
		}

		private object HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )
		{
			response.ContentType = "application/json; charset=utf-8";
			string path = request.RawUrl;
			int index = path.IndexOf( '?' );
			if (index >= 0) path = path.Substring( 0, index );
			string route = path.Trim( '/' ).ToLowerInvariant( );

			if (route.Length == 0 || route == "api" || route == "help")
			{
				return ServiceInfo( ).ToString( );
			}
			else if (route == "api/health" || route == "health")
			{
				return ServiceInfo( ).ToString( );
			}
			else if (route == "api/devices" || route == "devices")
			{
				return ListDevices( ).ToString( );
			}
			else if (route == "api/points" || route == "points")
			{
				return GetDataTablePoints( request, data ).ToString( );
			}
			else if (route == "api/devicecode" || route == "devicecode" || route == "api/code" || route == "code")
			{
				return GetDeviceExampleCode( request, data ).ToString( );
			}
			else if (route == "api/read" || route == "read")
			{
				return ReadDevice( request, data ).ToString( );
			}
			else if (route == "api/collect" || route == "collect")
			{
				return StartCollect( request, data ).ToString( );
			}
			else if (route == "api/collection" || route == "collection")
			{
				return GetCollection( request, data ).ToString( );
			}
			else if (route == "api/stop" || route == "stop")
			{
				return StopCollection( request, data ).ToString( );
			}

			return ErrorJson( "Unknown API: " + route ).ToString( );
		}

		private JObject ServiceInfo( )
		{
			int count = 0;
			lock (DemoDevice.Devices)
			{
				count = DemoDevice.Devices.Count;
			}
			return new JObject
			{
				["success"] = true,
				["service"] = "HslCommunicationDemo AI Gateway",
				["baseUrl"] = BaseUrl,
				["started"] = IsStarted,
				["deviceCount"] = count,
				["endpoints"] = new JArray
				{
					"GET /api/health",
					"GET /api/devices",
					"GET/POST /api/points",
					"GET/POST /api/devicecode",
					"GET/POST /api/read",
					"GET/POST /api/collect",
					"GET /api/collection",
					"GET/POST /api/stop"
				}
			};
		}

		private JObject ListDevices( )
		{
			JArray devices = new JArray( );
			lock (DemoDevice.Devices)
			{
				foreach (KeyValuePair<string, DemoDeviceItem> pair in DemoDevice.Devices)
				{
					DemoDeviceItem item = pair.Value;
					string name = item.Name;
					if (string.IsNullOrEmpty( name )) name = item.Device == null ? pair.Key : item.Device.ToString( );

					devices.Add( new JObject
					{
						["guid"] = pair.Key,
						["name"] = name,
						["deviceType"] = item.Device == null ? string.Empty : item.Device.GetType( ).Name,
						["description"] = item.Device == null ? string.Empty : item.Device.ToString( )
					} );
				}
			}

			return new JObject
			{
				["success"] = true,
				["count"] = devices.Count,
				["devices"] = devices
			};
		}

		private JObject GetDataTablePoints( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string deviceId = GetParameter( request, body, "guid", "device" );
			DemoDeviceItem item = FindDevice( deviceId );
			if (item == null) return ErrorJson( "Device not found. Call /api/devices first." );

			DataTableControl table = item.DataTableControl;
			if (table == null || table.IsDisposed)
			{
				return ErrorJson( "The selected device has no associated address table." );
			}

			List<DataTableItem> items;
			try
			{
				if (table.InvokeRequired)
				{
					items = (List<DataTableItem>)table.Invoke( (Func<List<DataTableItem>>)table.GetDataTableItems );
				}
				else
				{
					items = table.GetDataTableItems( );
				}
			}
			catch (Exception ex)
			{
				return ErrorJson( "Read address table failed: " + ex.Message );
			}

			JArray points = new JArray( );
			foreach (DataTableItem tableItem in items)
			{
				if (string.IsNullOrEmpty( tableItem.Address )) continue;
				if (string.IsNullOrEmpty( tableItem.DataTypeCode )) continue;

				JObject point = new JObject
				{
					["name"] = tableItem.Name,
					["address"] = tableItem.Address,
					["type"] = tableItem.DataTypeCode
				};
				if (tableItem.Length >= 0) point["length"] = tableItem.Length;
				if (!string.IsNullOrEmpty( tableItem.Unit )) point["unit"] = tableItem.Unit;
				if (!string.IsNullOrEmpty( tableItem.Description )) point["description"] = tableItem.Description;
				if (!string.IsNullOrEmpty( tableItem.Expression )) point["expression"] = tableItem.Expression;
				if (tableItem.DataTypeCode == "string")
				{
					point["encoding"] = tableItem.StringEncoding.ToString( );
				}
				points.Add( point );
			}

			return new JObject
			{
				["success"] = true,
				["device"] = GetDisplayName( item ),
				["deviceType"] = item.Device == null ? string.Empty : item.Device.GetType( ).Name,
				["count"] = points.Count,
				["points"] = points
			};
		}

		private JObject GetDeviceExampleCode( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string deviceId = GetParameter( request, body, "guid", "device" );
			DemoDeviceItem item = FindDevice( deviceId );
			if (item == null) return ErrorJson( "Device not found. Call /api/devices first." );

			CodeExampleControl codeControl = item.CodeExampleControl;
			if (codeControl == null || codeControl.IsDisposed)
			{
				return ErrorJson( "The selected device has no associated code example control." );
			}

			string code;
			try
			{
				if (codeControl.InvokeRequired)
				{
					code = (string)codeControl.Invoke( (Func<string>)codeControl.GetDeviceNewCode );
				}
				else
				{
					code = codeControl.GetDeviceNewCode( );
				}
			}
			catch (Exception ex)
			{
				return ErrorJson( "Read device code failed: " + ex.Message );
			}

			return new JObject
			{
				["success"] = true,
				["device"] = GetDisplayName( item ),
				["deviceType"] = item.Device == null ? string.Empty : item.Device.GetType( ).Name,
				["language"] = "csharp",
				["code"] = code
			};
		}

		private JObject ReadDevice( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string deviceId = GetParameter( request, body, "guid", "device" );
			DemoDeviceItem item = FindDevice( deviceId );
			if (item == null) return ErrorJson( "Device not found. Call /api/devices first." );

			DeviceCommunication device = item.Device as DeviceCommunication;
			if (device == null) return ErrorJson( "The selected device does not support generic address read." );

			string address = GetParameter( request, body, "address" );
			if (string.IsNullOrEmpty( address )) return ErrorJson( "address is required." );

			string type = GetParameter( request, body, "type" );
			if (string.IsNullOrEmpty( type )) type = "short";
			type = type.ToLowerInvariant( );

			string lengthText = GetParameter( request, body, "length" );
			int length;
			if (string.IsNullOrEmpty( lengthText ))
			{
				length = type.StartsWith( "string" ) ? 0 : 1;
			}
			else if (!int.TryParse( lengthText, out length ))
			{
				return ErrorJson( "length must be an integer." );
			}
			if (length < 0) return ErrorJson( "length cannot be negative." );

			string encodingName = GetParameter( request, body, "encoding" );
			encodingName = ResolveEncodingName( type, encodingName );
			Encoding encoding = ParseEncoding( encodingName );
			if (encoding == null) return ErrorJson( "Unsupported encoding: " + encodingName );

			OperateResult<object> read = ReadValue( device, address, type, length, encoding );
			if (!read.IsSuccess) return ErrorJson( read.Message );

			return new JObject
			{
				["success"] = true,
				["timestamp"] = DateTime.Now.ToString( "O" ),
				["device"] = GetDisplayName( item ),
				["address"] = address,
				["type"] = type,
				["value"] = read.Content == null ? JValue.CreateNull( ) : JToken.FromObject( read.Content )
			};
		}

		private JObject StartCollect( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string deviceId = GetParameter( request, body, "guid", "device" );
			DemoDeviceItem item = FindDevice( deviceId );
			if (item == null) return ErrorJson( "Device not found. Call /api/devices first." );

			DeviceCommunication device = item.Device as DeviceCommunication;
			if (device == null) return ErrorJson( "The selected device does not support generic address read." );

			string address = GetParameter( request, body, "address" );
			if (string.IsNullOrEmpty( address )) return ErrorJson( "address is required." );

			string type = GetParameter( request, body, "type" );
			if (string.IsNullOrEmpty( type )) type = "short";
			type = type.ToLowerInvariant( );

			string intervalText = GetParameter( request, body, "intervalMs" );
			if (!int.TryParse( intervalText, out int intervalMs )) intervalMs = 1000;
			if (intervalMs < 100) intervalMs = 100;
			if (intervalMs > 3600000) intervalMs = 3600000;

			string secondsText = GetParameter( request, body, "seconds" );
			if (!int.TryParse( secondsText, out int seconds )) seconds = 60;
			if (seconds < 1) seconds = 1;
			if (seconds > 86400) seconds = 86400;

			string lengthText = GetParameter( request, body, "length" );
			int length;
			if (string.IsNullOrEmpty( lengthText ))
			{
				length = type.StartsWith( "string" ) ? 0 : 1;
			}
			else if (!int.TryParse( lengthText, out length ))
			{
				return ErrorJson( "length must be an integer." );
			}

			string encodingName = GetParameter( request, body, "encoding" );
			encodingName = ResolveEncodingName( type, encodingName );
			Encoding encoding = ParseEncoding( encodingName );
			if (encoding == null) return ErrorJson( "Unsupported encoding: " + encodingName );

			int maxPoints = seconds * 1000 / intervalMs + 1;
			GatewayCollectionTask task = new GatewayCollectionTask( )
			{
				Id = "c-" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) + "-" + NextCollectionId( ),
				DeviceId = deviceId,
				Address = address,
				Type = type,
				Length = length,
				Encoding = encoding,
				IntervalMs = intervalMs,
				EndTime = DateTime.Now.AddSeconds( seconds ),
				MaxPoints = maxPoints
			};

			lock (collectionLock)
			{
				collections[task.Id] = task;
			}

			Thread thread = new Thread( new ThreadStart( ( ) => RunCollection( task ) ) );
			thread.IsBackground = true;
			thread.Start( );

			return new JObject
			{
				["success"] = true,
				["collectionId"] = task.Id,
				["device"] = GetDisplayName( item ),
				["address"] = address,
				["type"] = type,
				["intervalMs"] = intervalMs,
				["seconds"] = seconds,
				["endpoint"] = "/api/collection?id=" + task.Id
			};
		}

		private JObject GetCollection( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string id = GetParameter( request, body, "id" );
			if (string.IsNullOrEmpty( id )) return ErrorJson( "id is required." );

			GatewayCollectionTask task;
			lock (collectionLock)
			{
				if (!collections.TryGetValue( id, out task )) return ErrorJson( "collection not found: " + id );
			}

			JArray samples;
			lock (task.Samples)
			{
				samples = new JArray( task.Samples );
			}

			JObject result = new JObject
			{
				["success"] = true,
				["collectionId"] = id,
				["running"] = task.FinishTime == null,
				["sampleCount"] = samples.Count,
				["errorCount"] = Volatile.Read( ref task.ErrorCount ),
				["startTime"] = task.StartTime.ToString( "O" ),
				["samples"] = samples
			};
			if (task.FinishTime != null)
			{
				result["finishTime"] = task.FinishTime.Value.ToString( "O" );
			}

			JObject analysis = ComputeAnalysis( samples );
			if (analysis != null) result["analysis"] = analysis;
			return result;
		}

		private JObject StopCollection( HttpListenerRequest request, string data )
		{
			JObject body = ParseBody( data );
			string id = GetParameter( request, body, "id" );
			if (string.IsNullOrEmpty( id )) return ErrorJson( "id is required." );

			lock (collectionLock)
			{
				if (collections.TryGetValue( id, out GatewayCollectionTask task ))
				{
					task.StopRequested = true;
					return new JObject { ["success"] = true, ["stopped"] = id };
				}
			}
			return ErrorJson( "collection not found: " + id );
		}

		private void RunCollection( GatewayCollectionTask task )
		{
			// Sample at fixed target times. If an operation overruns the interval,
			// reset the next target to now + interval instead of catch-up sampling.
			DateTime nextSampleTime = task.StartTime.AddMilliseconds( task.IntervalMs );
			while (!task.StopRequested && DateTime.Now < task.EndTime)
			{
				int waitMilliseconds = (int)(nextSampleTime - DateTime.Now).TotalMilliseconds;
				if (waitMilliseconds > 0) Thread.Sleep( waitMilliseconds );

				if (task.StopRequested || DateTime.Now >= task.EndTime) break;

				int sampleCount;
				lock (task.Samples)
				{
					sampleCount = task.Samples.Count;
				}
				if (sampleCount >= task.MaxPoints) break;

				DemoDeviceItem item = FindDevice( task.DeviceId );
				DeviceCommunication device = item?.Device as DeviceCommunication;
				if (device == null)
				{
					Interlocked.Increment( ref task.ErrorCount );
					nextSampleTime = nextSampleTime.AddMilliseconds( task.IntervalMs );
					if (nextSampleTime <= DateTime.Now)
					{
						nextSampleTime = DateTime.Now.AddMilliseconds( task.IntervalMs );
					}
					continue;
				}

				OperateResult<object> read = ReadValue( device, task.Address, task.Type, task.Length, task.Encoding );
				if (read.IsSuccess)
				{
					JObject sample = new JObject
					{
						["t"] = DateTime.Now.ToString( "O" ),
						["value"] = read.Content == null ? JValue.CreateNull( ) : JToken.FromObject( read.Content )
					};
					lock (task.Samples)
					{
						task.Samples.Add( sample );
					}
				}
				else
				{
					Interlocked.Increment( ref task.ErrorCount );
				}

				nextSampleTime = nextSampleTime.AddMilliseconds( task.IntervalMs );
				if (nextSampleTime <= DateTime.Now)
				{
					nextSampleTime = DateTime.Now.AddMilliseconds( task.IntervalMs );
				}
			}
			task.FinishTime = DateTime.Now;
		}

		private static OperateResult<object> ReadValue( DeviceCommunication device, string address, string type, int length, Encoding encoding )
		{
			ushort safeLength = (ushort)Math.Max( 0, length );
			try
			{
				switch (type)
				{
					case "bool":
						return ToObjectResult( device.ReadBool( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "short":
					case "int16":
						return ToObjectResult( device.ReadInt16( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "ushort":
					case "uint16":
						return ToObjectResult( device.ReadUInt16( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "int":
					case "int32":
						return ToObjectResult( device.ReadInt32( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "uint":
					case "uint32":
						return ToObjectResult( device.ReadUInt32( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "long":
					case "int64":
						return ToObjectResult( device.ReadInt64( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "ulong":
					case "uint64":
						return ToObjectResult( device.ReadUInt64( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "float":
						return ToObjectResult( device.ReadFloat( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "double":
						return ToObjectResult( device.ReadDouble( address, safeLength == 0 ? (ushort)1 : safeLength ), length != 1 );
					case "string":
					case "string_ascii":
					case "string_utf8":
					case "string_unicode":
					case "string_gb2312":
						{
							OperateResult<string> readString = device.ReadString( address, safeLength, encoding );
							return readString.IsSuccess ? OperateResult.CreateSuccessResult<object>( readString.Content ) : OperateResult.CreateFailedResult<object>( readString );
						}
					case "bytes":
					case "bytearray":
					case "hex":
						{
							if (safeLength == 0) return new OperateResult<object>( "length is required for bytes." );
							OperateResult<byte[]> readBytes = device.Read( address, safeLength );
							if (!readBytes.IsSuccess) return OperateResult.CreateFailedResult<object>( readBytes );
							return OperateResult.CreateSuccessResult<object>( string.Join( " ", readBytes.Content.Select( m => m.ToString( "X2" ) ) ) );
						}
					default:
						return new OperateResult<object>( "Unsupported type: " + type );
				}
			}
			catch (Exception ex)
			{
				return new OperateResult<object>( "Read failed: " + ex.Message );
			}
		}

		private static OperateResult<object> ToObjectResult<T>( OperateResult<T[]> read, bool keepArray )
		{
			if (!read.IsSuccess) return OperateResult.CreateFailedResult<object>( read );
			if (keepArray) return OperateResult.CreateSuccessResult<object>( read.Content );
			return OperateResult.CreateSuccessResult<object>( read.Content.Length > 0 ? (object)read.Content[0] : (object)null );
		}

		private static JObject ParseBody( string data )
		{
			if (string.IsNullOrEmpty( data )) return new JObject( );
			try
			{
				return JObject.Parse( data );
			}
			catch
			{
				return new JObject( );
			}
		}

		private static string GetParameter( HttpListenerRequest request, JObject body, params string[] names )
		{
			foreach (string name in names)
			{
				string value = request.QueryString[name];
				if (!string.IsNullOrEmpty( value )) return value;
				if (body != null && body[name] != null) return body[name].ToString( );
			}
			return null;
		}

		private static Encoding ParseEncoding( string name )
		{
			if (string.IsNullOrEmpty( name ) || name.Equals( "ascii", StringComparison.OrdinalIgnoreCase )) return Encoding.ASCII;
			if (name.Equals( "utf8", StringComparison.OrdinalIgnoreCase ) || name.Equals( "utf-8", StringComparison.OrdinalIgnoreCase )) return Encoding.UTF8;
			if (name.Equals( "unicode", StringComparison.OrdinalIgnoreCase ) || name.Equals( "utf16", StringComparison.OrdinalIgnoreCase )) return Encoding.Unicode;
			if (name.Equals( "gb2312", StringComparison.OrdinalIgnoreCase ) || name.Equals( "gbk", StringComparison.OrdinalIgnoreCase )) return Encoding.GetEncoding( "gb2312" );
			return null;
		}

		private static string ResolveEncodingName( string type, string encodingName )
		{
			if (!string.IsNullOrEmpty( encodingName )) return encodingName;
			if (type == "string_utf8") return "utf8";
			if (type == "string_unicode") return "unicode";
			if (type == "string_gb2312") return "gb2312";
			return "ascii";
		}

		private static DemoDeviceItem FindDevice( string deviceId )
		{
			if (string.IsNullOrEmpty( deviceId )) return null;
			lock (DemoDevice.Devices)
			{
				foreach (KeyValuePair<string, DemoDeviceItem> pair in DemoDevice.Devices)
				{
					DemoDeviceItem item = pair.Value;
					if (pair.Key == deviceId) return item;
					if (item.Name == deviceId) return item;
					if (item.Device != null && item.Device.ToString( ) == deviceId) return item;
				}
			}
			return null;
		}

		private static string GetDisplayName( DemoDeviceItem item )
		{
			if (!string.IsNullOrEmpty( item.Name )) return item.Name;
			return item.Device == null ? item.Guid : item.Device.ToString( );
		}

		private int NextCollectionId( )
		{
			lock (collectionLock)
			{
				return ++collectionIdSeed;
			}
		}

		private static JObject ComputeAnalysis( JArray samples )
		{
			List<double> values = new List<double>( );
			foreach (JToken sample in samples)
			{
				JToken token = sample["value"];
				if (token == null) continue;
				if (token.Type == JTokenType.Integer || token.Type == JTokenType.Float)
				{
					values.Add( token.Value<double>( ) );
				}
				else if (token.Type == JTokenType.Boolean)
				{
					values.Add( token.Value<bool>( ) ? 1 : 0 );
				}
			}

			if (values.Count == 0) return null;
			double avg = values.Average( );
			double sumSquare = values.Sum( m => m * m );
			double stddev = Math.Sqrt( Math.Max( 0, sumSquare / values.Count - avg * avg ) );
			return new JObject
			{
				["count"] = values.Count,
				["min"] = values.Min( ),
				["max"] = values.Max( ),
				["avg"] = avg,
				["stddev"] = stddev
			};
		}

		private static JObject ErrorJson( string message )
		{
			return new JObject
			{
				["success"] = false,
				["message"] = message
			};
		}

		private const string DefaultBaseUrl = "http://127.0.0.1:8731/";

		private class GatewayCollectionTask
		{
			public string Id { get; set; }

			public string DeviceId { get; set; }

			public string Address { get; set; }

			public string Type { get; set; }

			public int Length { get; set; }

			public Encoding Encoding { get; set; }

			public int IntervalMs { get; set; }

			public DateTime EndTime { get; set; }

			public int MaxPoints { get; set; }

			public readonly DateTime StartTime = DateTime.Now;

			public readonly JArray Samples = new JArray( );

			public int ErrorCount = 0;

			public volatile bool StopRequested = false;

			public DateTime? FinishTime = null;
		}
	}
}
