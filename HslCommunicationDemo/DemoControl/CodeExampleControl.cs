using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Core.Device;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using HslCommunication.MQTT;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Robot.ABB;
using HslCommunication.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class CodeExampleControl : UserControl
	{
		public CodeExampleControl( )
		{
			InitializeComponent( );
		}

		public static string GetTitle( ) => Program.Language == 1 ? "代码示例" : "Code Example";

		/// <summary>
		/// 设置当前的文本信息
		/// </summary>
		/// <param name="code">代码信息</param>
		public void SetCodeText( string code )
		{
			this.textBox1.Text = code;
		}

		private static object GetObject( object obj, string names )
		{
			int index = names.IndexOf( '.' );
			if (index < 0) return obj;

			string name = names.Substring( 0, index );
			PropertyInfo propertyInfo = obj.GetType( ).GetProperty( name );
			if (propertyInfo == null) return null;

			return GetObject( propertyInfo.GetValue( obj ), names.Substring( index + 1 ) );
		}

		private static string GetPropertyName( string name )
		{
			int index = name.IndexOf( '.' );
			if (index < 0) return name;

			return name.Substring( name.LastIndexOf( '.' ) + 1 );
		}

		private static void SetPropties( string iniName, StringBuilder stringBuilder, object obj, params string[] props )
		{
			if (props != null && props.Length > 0)
			{
				for (int i = 0; i < props.Length; i++)
				{
					// 这里需要判断带小数点的情况
					string name = props[i];

					if (name.StartsWith( "HslCommunication.ModBus.ModbusMappingAddress." ))
					{
						stringBuilder.Append( $"{iniName}.RegisteredAddressMapping( {name} );    // 重新指定地址映射，这一行很关键" );
						stringBuilder.AppendLine( );
						continue;
					}

					string propertyName = GetPropertyName( name );
					object propertyObj = GetObject( obj, name );
					if (propertyObj == null) continue;

					stringBuilder.Append( $"{iniName}." );
					stringBuilder.Append( name );
					stringBuilder.Append( " = " );

					PropertyInfo propertyInfo = propertyObj.GetType( ).GetProperty( propertyName );
					if (propertyInfo.PropertyType == typeof( string ))
					{
						stringBuilder.Append( "\"" );
						stringBuilder.Append( propertyInfo.GetValue( propertyObj ).ToString( ) );
						stringBuilder.Append( "\"" );
					}
					else if (propertyInfo.PropertyType.IsSubclassOf( typeof( Enum ) ))
					{
						stringBuilder.Append( propertyInfo.PropertyType.FullName );
						stringBuilder.Append( "." );
						stringBuilder.Append( propertyInfo.GetValue( propertyObj ).ToString( ) );
					}
					else
					{
						if (propertyInfo.PropertyType == typeof( bool ))
						{
							stringBuilder.Append( propertyInfo.GetValue( propertyObj ).ToString( ).ToLower( ) );
						}
						else if (propertyInfo.PropertyType == typeof( HslCommunication.Profinet.AllenBradley.MessageRouter ))
						{
							byte[] router = ((HslCommunication.Profinet.AllenBradley.MessageRouter)propertyInfo.GetValue( propertyObj )).GetRouter( );
							stringBuilder.Append( "new HslCommunication.Profinet.AllenBradley.MessageRouter( \"" + router.ToHexString( ' ' ) + "\".ToHexBytes( ) )" );
						}
						else if (propertyInfo.PropertyType == typeof( Encoding ))
						{
							Encoding encoding = (Encoding)propertyInfo.GetValue( propertyObj );
							if (encoding == Encoding.ASCII) stringBuilder.Append( "System.Text.Encoding.ASCII" );
							else if (encoding == Encoding.Default) stringBuilder.Append( "System.Text.Encoding.Default" );
							else if (encoding == Encoding.UTF8) stringBuilder.Append( "System.Text.Encoding.UTF8" );
							else if (encoding == Encoding.Unicode) stringBuilder.Append( "System.Text.Encoding.Unicode" );
							else if (encoding == Encoding.BigEndianUnicode) stringBuilder.Append( "System.Text.Encoding.BigEndianUnicode" );
							else stringBuilder.Append( "System.Text.Encoding.Default" );
						}
						else if (propertyInfo.PropertyType == typeof( TimeSpan ))
						{
							TimeSpan ts = (TimeSpan)propertyInfo.GetValue( propertyObj );
							if (ts.TotalSeconds >= 1)
								stringBuilder.Append( $"TimeSpan.FromSeconds( {ts.TotalSeconds} )" );
							else
								stringBuilder.Append( $"TimeSpan.FromMilliseconds( {ts.TotalMilliseconds} )" );
						}
						else if (propertyInfo.PropertyType == typeof( MqttCredential ))
						{
							MqttCredential mqttCredential = propertyInfo.GetValue( propertyObj ) as MqttCredential;
							if (mqttCredential == null)
								stringBuilder.Append( "null" );
							else
								stringBuilder.Append( "new " + propertyInfo.PropertyType.FullName + $"( \"{mqttCredential.UserName}\",\"{mqttCredential.Password}\" )" );
						}
						else if (propertyInfo.PropertyType == typeof( MqttApplicationMessage ))
						{
							MqttApplicationMessage message = propertyInfo.GetValue( propertyObj ) as MqttApplicationMessage;

							if (message == null)
								stringBuilder.Append( "null" );
							else
							{
								stringBuilder.Append( "new " + propertyInfo.PropertyType.FullName + $"( );" );
								stringBuilder.AppendLine( );
								SetPropties( $"{iniName}." + name, stringBuilder, message, nameof( MqttApplicationMessage.Topic ), nameof( MqttApplicationMessage.Payload ), nameof( MqttApplicationMessage.Retain ) );
								return;
							}
						}
						else if (propertyInfo.PropertyType == typeof( HslCommunication.Core.IByteTransform ))
						{
							HslCommunication.Core.IByteTransform transform = propertyInfo.GetValue( propertyObj ) as HslCommunication.Core.IByteTransform;
							stringBuilder.Append( "new " + transform.GetType( ).FullName + "( );" );
							stringBuilder.AppendLine( );

							SetPropties( iniName, stringBuilder, obj, new string[] { $"{name}.DataFormat", $"{name}.IsStringReverseByteWord" } );
							continue;
						}
						else if (propertyInfo.PropertyType == typeof( byte[] ))
						{
							byte[] buffer = propertyInfo.GetValue( propertyObj ) as byte[];

							if (buffer == null)
								stringBuilder.Append( "null" );
							else
								stringBuilder.Append( "\"" + buffer.ToHexString( ) + $"\".ToHexBytes( )" );
						}
						else
						{
							stringBuilder.Append( propertyInfo.GetValue( propertyObj ).ToString( ) );
						}
					}

					stringBuilder.Append( ";" );
					stringBuilder.AppendLine( );
				}
			}
			if (obj.GetType() == typeof( HslCommunication.Profinet.Beckhoff.BeckhoffAdsNet ))
			{
				if (obj is HslCommunication.Profinet.Beckhoff.BeckhoffAdsNet plc)
				{
					if (!plc.UseAutoAmsNetID)
					{
						stringBuilder.Append( "plc.SetSenderAMSNetId( \"" );
						stringBuilder.Append( plc.GetSenderAMSNetId( ) );
						stringBuilder.Append( "\" );" );
						stringBuilder.AppendLine( );

						stringBuilder.Append( "plc.SetTargetAMSNetId( \"" );
						stringBuilder.Append( plc.GetTargetAMSNetId( ) );
						stringBuilder.Append( "\" );" );
						stringBuilder.AppendLine( );
					}
				}
			}
		}

		public void SetCodeText( NetworkDoubleBase network, params string[] props )
		{
			SetCodeText( "plc", network, props );
		}

		public void SetCodeText( DeviceTcpNet network, params string[] props )
		{
			SetCodeText( "plc", network, props );
		}

		public void SetCodeText( DeviceUdpNet network, params string[] props )
		{
			SetCodeText( "plc", network, props );
		}

		public void SetCodeText( string deviceName, string com, NetworkServerBase serverBase, params string[] props )
		{
			StringBuilder stringBuilder = CreateFromObject( serverBase, deviceName );
			SetPropties( deviceName, stringBuilder, serverBase, props );

			stringBuilder.Append( deviceName + ".ServerStart( " + serverBase.Port + " );" );
			stringBuilder.AppendLine( );
			if (!string.IsNullOrEmpty( com ))
			{
				stringBuilder.Append( deviceName + ".StartSerialSlave( \"" + com + "\" );" );
				stringBuilder.AppendLine( );
			}
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( string deviceName, string com, CommunicationServer serverBase, params string[] props )
		{
			StringBuilder stringBuilder = CreateFromObject( serverBase, deviceName );
			SetPropties( deviceName, stringBuilder, serverBase, props );

			stringBuilder.Append( deviceName + ".ServerStart( " + serverBase.Port + " );" );
			stringBuilder.AppendLine( );
			if (!string.IsNullOrEmpty( com ))
			{
				stringBuilder.Append( deviceName + ".SerialReceiveAtleastTime = " + serverBase.SerialReceiveAtleastTime + ";" );
				stringBuilder.AppendLine( );

				stringBuilder.Append( deviceName + ".StartSerialSlave( \"" + com + "\" );" );
				stringBuilder.AppendLine( );
			}
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( string deviceName, string com, DeviceServer serverBase, params string[] props )
		{
			StringBuilder stringBuilder = CreateFromObject( serverBase, deviceName );
			SetPropties( deviceName, stringBuilder, serverBase, props );

			stringBuilder.Append( deviceName + ".ActiveTimeSpan = TimeSpan.Parse( \"" + serverBase.ActiveTimeSpan.ToString( ) + "\" );" );
			stringBuilder.AppendLine( );
			stringBuilder.Append( deviceName + ".EnableIPv6 = " + serverBase.EnableIPv6.ToString( ).ToLower( ) + ";" );
			stringBuilder.AppendLine( );
			if (serverBase.IsTcpMode)
				stringBuilder.Append( deviceName + ".ServerStart( " + serverBase.Port + " );" );
			else
				stringBuilder.Append( deviceName + ".ServerStart( " + serverBase.Port + ", false );" );
			stringBuilder.AppendLine( );
			if (!string.IsNullOrEmpty( com ))
			{
				stringBuilder.Append( deviceName + ".SerialReceiveAtleastTime = " + serverBase.SerialReceiveAtleastTime + ";" );
				stringBuilder.AppendLine( );

				stringBuilder.Append( deviceName + ".StartSerialSlave( \"" + com + "\" );" );
				stringBuilder.AppendLine( );
			}
			this.textBox1.Text = stringBuilder.ToString( );
		}


		public void SetCodeText( string deviceName, NetworkDoubleBase network, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( network, deviceName );
			SetPropties( deviceName, stringBuilder, network, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( string deviceName, DeviceTcpNet device, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( device, deviceName );
			SetPropties( deviceName, stringBuilder, device, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( string deviceName,TcpNetCommunication device, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( device, deviceName );
			SetPropties( deviceName, stringBuilder, device, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( string deviceName, DeviceUdpNet device, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( device, deviceName );
			SetPropties( deviceName, stringBuilder, device, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( NetworkWebApiBase network, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( network );
			SetPropties( "plc", stringBuilder, network, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( DeviceWebApi network, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( network );
			SetPropties( "plc", stringBuilder, network, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public void SetCodeText( NetworkUdpBase network, params string[] props )
		{
			SetCodeText( "plc", network, props );
		}
		public void SetCodeText( string deviceName, NetworkUdpBase network, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( network, deviceName );
			SetPropties( deviceName, stringBuilder, network, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}


		public void SetCodeText( DeviceSerialPort network, params string[] props )
		{
			SetCodeText( "plc", network, props );
		}


		public void SetCodeText( string deviceName, DeviceSerialPort network, params string[] props )
		{
			StringBuilder stringBuilder = CreateStringBulider( network, deviceName );
			SetPropties( deviceName, stringBuilder, network, props );
			this.textBox1.Text = stringBuilder.ToString( );
		}

		public static StringBuilder CreateStringBulider( NetworkWebApiBase network )
		{
			if (network == null) return new StringBuilder( );

			StringBuilder sb = new StringBuilder( );
			sb.Append( network.GetType( ).FullName );
			sb.Append( " plc = new " );
			sb.Append( network.GetType( ).FullName );
			if (network.GetType( ) == typeof( ABBWebApiClient ))
			{
				ABBWebApiClient aBBWebApi = (ABBWebApiClient)network;
				sb.Append( $"( \"{aBBWebApi.IpAddress}\", {aBBWebApi.Port}, \"{aBBWebApi.UserName}\", \"{aBBWebApi.Password}\" );" );
				sb.AppendLine( );
				return sb;
			}
			else
			{
				sb.Append( "( );" );
			}

			sb.AppendLine( );
			sb.Append( "plc.IpAddress = \"" + network.IpAddress + "\";" );
			sb.AppendLine( );
			sb.Append( "plc.Port = " + network.Port + ";" );
			sb.AppendLine( );
			return sb;
		}
		public static StringBuilder CreateStringBulider( DeviceWebApi network )
		{
			if (network == null) return new StringBuilder( );

			StringBuilder sb = new StringBuilder( );
			sb.Append( network.GetType( ).FullName );
			sb.Append( " plc = new " );
			sb.Append( network.GetType( ).FullName );
			sb.Append( $"( \"{network.IpAddress}\", {network.Port}, \"{network.UserName}\", \"{network.Password}\" );" );
			sb.AppendLine( );
			return sb;
		}

		private static StringBuilder CreateFromObject( object obj, string deviceName )
		{
			string name = obj.GetType( ).FullName;
			StringBuilder sb = new StringBuilder( );
			sb.Append( name );
			sb.Append( $" {deviceName} = new " );
			sb.Append( name );
			if (obj.GetType( ) == typeof( SiemensS7Net ))
			{
				SiemensPLCS siemensPLCS = (SiemensPLCS)obj.GetType( ).GetField( "CurrentPlc", BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( obj );
				sb.Append( $"( HslCommunication.Profinet.Siemens.SiemensPLCS.{siemensPLCS} );" );
			}
			else
			{
				sb.Append( "( );" );
			}
			sb.AppendLine( );

			return sb;
		}

		public static StringBuilder CreateStringBulider( MqttSyncClient network )
		{
			if (network == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( network.ConnectionOptions, "options" );
			SetPropties( "options", sb, network.ConnectionOptions, nameof( MqttConnectionOptions.IpAddress ), nameof( MqttConnectionOptions.Port ),
				nameof( MqttConnectionOptions.ClientId ), nameof( MqttConnectionOptions.UseRSAProvider ), nameof( MqttConnectionOptions.Credentials ),
				nameof( MqttConnectionOptions.ConnectTimeout ) );

			sb.Append( network.GetType().FullName + $" rpc = new {network.GetType( ).FullName}( options );" );
			sb.AppendLine( );
			sb.Append( "rpc.SetPersistentConnection( );" );
			sb.AppendLine( );
			return sb;
		}

		public static StringBuilder CreateStringBulider( MqttClient mqttClient )
		{
			if (mqttClient == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( mqttClient.ConnectionOptions, "options" );
			SetPropties( "options", sb, mqttClient.ConnectionOptions, nameof( MqttConnectionOptions.IpAddress ), nameof( MqttConnectionOptions.Port ),
				nameof( MqttConnectionOptions.ClientId ), nameof( MqttConnectionOptions.UseRSAProvider ), nameof( MqttConnectionOptions.Credentials ),
				nameof( MqttConnectionOptions.CleanSession ), nameof( MqttConnectionOptions.UseSSL ), nameof( MqttConnectionOptions.SSLSecure),
				nameof( MqttConnectionOptions.CertificateFile), nameof( MqttConnectionOptions.KeepAlivePeriod ), nameof( MqttConnectionOptions.KeepAliveSendInterval ),
				nameof( MqttConnectionOptions.WillMessage ));

			sb.Append( mqttClient.GetType( ).FullName + $" mqtt = new {mqttClient.GetType( ).FullName}( options );" );
			sb.AppendLine( );
			return sb;
		}

		private static void CreateCommunicationPipe( StringBuilder sb, CommunicationPipe pipe, string deviceName )
		{
			if (pipe.GetType( ) == typeof( PipeTcpNet ) || pipe.GetType( ) == typeof( PipeSslNet ) || pipe.GetType( ) == typeof( PipeUdpNet ))
			{
				PipeTcpNet pipeTcpNet = pipe as PipeTcpNet;
				sb.Append( deviceName + $".CommunicationPipe = new {pipeTcpNet.GetType( ).FullName}(\"{pipeTcpNet.Host}\", {pipeTcpNet.Port})" );
				sb.AppendLine( );
				sb.Append( "{" );
				sb.AppendLine( );
				if (pipe.GetType( ) != typeof( PipeUdpNet ))
				{
					sb.Append( $"    ConnectTimeOut = {pipeTcpNet.ConnectTimeOut},    // 连接超时时间，单位毫秒" );
					sb.AppendLine( );
				}
				sb.Append( $"    ReceiveTimeOut = {pipeTcpNet.ReceiveTimeOut},    // 接收设备数据反馈的超时时间" );
				sb.AppendLine( );
				sb.Append( $"    SleepTime = {pipeTcpNet.SleepTime}," );
				sb.AppendLine( );
				sb.Append( $"    SocketKeepAliveTime = {pipeTcpNet.SocketKeepAliveTime}," );
				sb.AppendLine( );
				sb.Append( $"    IsPersistentConnection = {pipeTcpNet.IsPersistentConnection.ToString( ).ToLower()}," );
				sb.AppendLine( );
				if (pipeTcpNet.LocalBinding != null)
				{
					//pipeTcpNet.LocalBinding = new System.Net.IPEndPoint( System.Net.IPAddress.Parse( pipeTcpNet.LocalBinding.Address.ToString( ) ), pipeTcpNet.LocalBinding.Port );
					sb.Append( $"    LocalBinding = new System.Net.IPEndPoint( System.Net.IPAddress.Parse( \"{pipeTcpNet.LocalBinding.Address}\" ), {pipeTcpNet.LocalBinding.Port} )," );
					sb.AppendLine( );
				}
				sb.Append( "};" );
				sb.AppendLine( );
			}
			else if (pipe.GetType( ) == typeof( PipeSerialPort ))
			{
				PipeSerialPort pipeSerialPort = pipe as PipeSerialPort;
				sb.Append( $"{pipeSerialPort.GetType( ).FullName} pipe =  new {pipeSerialPort.GetType( ).FullName}( );" );
				sb.AppendLine( );
				sb.Append( $"pipe.SerialPortInni( \"{pipeSerialPort.GetPipe( ).ToFormatString( )}\" );" );
				sb.AppendLine( );
				sb.Append( $"pipe.RtsEnable = {pipeSerialPort.RtsEnable.ToString( ).ToLower( )};" );
				sb.AppendLine( );
				sb.Append( $"pipe.DtrEnable = {pipeSerialPort.DtrEnable.ToString( ).ToLower( )};" );
				sb.AppendLine( );
				sb.Append( $"pipe.SleepTime = {pipeSerialPort.SleepTime};" );
				sb.AppendLine( );
				sb.Append( deviceName + $".CommunicationPipe = pipe;" );
				sb.AppendLine( );
			}
			else if (pipe.GetType( ) == typeof( PipeMqttClient ))
			{
				PipeMqttClient pipeMqttClient = pipe as PipeMqttClient;

				sb.Append( $"HslCommunication.MQTT.MqttClient mqttClient = new HslCommunication.MQTT.MqttClient( new HslCommunication.MQTT.MqttConnectionOptions( ){{" );
				sb.AppendLine( );
				sb.Append( $"    IpAddress = \"{pipeMqttClient.MqttClient.ConnectionOptions.HostName}\"," );
				sb.AppendLine( );
				sb.Append( $"    Port = {pipeMqttClient.MqttClient.ConnectionOptions.Port}," );
				sb.AppendLine( );
				if (pipeMqttClient.MqttClient.ConnectionOptions.Credentials != null)
				{
					sb.Append( $"    Credentials = new HslCommunication.MQTT.MqttCredential( \"{pipeMqttClient.MqttClient.ConnectionOptions.Credentials.UserName}\", \"{pipeMqttClient.MqttClient.ConnectionOptions.Credentials.Password}\" )," );
					sb.AppendLine( );
				}
				sb.Append( $"    ClientId = \"{pipeMqttClient.MqttClient.ConnectionOptions.ClientId}\"," );
				sb.AppendLine( );
				sb.Append( $"    UseRSAProvider = {pipeMqttClient.MqttClient.ConnectionOptions.UseRSAProvider.ToString( ).ToLower( )}," );
				sb.AppendLine( );
				sb.Append( "} );" );
				sb.AppendLine( );
				sb.Append( deviceName + $".CommunicationPipe = new {pipeMqttClient.GetType( ).FullName}( mqttClient, \"{pipeMqttClient.ReadTopic}\", \"{pipeMqttClient.WriteTopic}\" );" );
				sb.AppendLine( );

			}
		}

		public static StringBuilder CreateStringBulider( NetworkDoubleBase network, string deviceName )
		{
			if (network == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( network, deviceName );
			sb.Append( deviceName + ".IpAddress = \"" + network.IpAddress + "\";" );
			sb.AppendLine( );
			sb.Append( deviceName + ".Port = " + network.Port + ";" );
			sb.AppendLine( );
			sb.Append( deviceName + ".ConnectTimeOut = " + network.ConnectTimeOut + ";     // 连接超时，单位毫秒" );
			sb.AppendLine( );
			sb.Append( deviceName + ".ReceiveTimeOut = " + network.ReceiveTimeOut + ";     // 接收超时，单位毫秒" );
			sb.AppendLine( );
			return sb;
		}

		public static StringBuilder CreateStringBulider( DeviceTcpNet device, string deviceName )
		{
			if (device == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( device, deviceName );
			CreateCommunicationPipe( sb, device.CommunicationPipe, deviceName );
			return sb;
		}

		public static StringBuilder CreateStringBulider( DeviceUdpNet device, string deviceName )
		{
			if (device == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( device, deviceName );
			CreateCommunicationPipe( sb, device.CommunicationPipe, deviceName );
			return sb;
		}

		public static StringBuilder CreateStringBulider( TcpNetCommunication device, string deviceName )
		{
			if (device == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( device, deviceName );
			CreateCommunicationPipe( sb, device.CommunicationPipe, deviceName );
			return sb;
		}

		public static StringBuilder CreateStringBulider( NetworkUdpBase network, string deviceName )
		{
			if (network == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( network, deviceName );

			sb.Append( deviceName + ".IpAddress = \"" + network.IpAddress + "\";" );
			sb.AppendLine( );
			sb.Append( deviceName + ".Port = " + network.Port + ";" );
			sb.AppendLine( );
			sb.Append( deviceName + ".ReceiveTimeout = " + network.ReceiveTimeout + ";   // 接收超时，单位毫秒" );
			sb.AppendLine( );
			return sb;
		}
		
		public static StringBuilder CreateStringBulider( DeviceSerialPort device, string deviceName )
		{
			if (device == null) return new StringBuilder( );

			StringBuilder sb = CreateFromObject( device, deviceName );
			CreateCommunicationPipe( sb, device.CommunicationPipe, deviceName );
			return sb;
		}
	}
}
