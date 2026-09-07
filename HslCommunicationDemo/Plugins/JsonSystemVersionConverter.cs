using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.BasicFramework;
using Newtonsoft.Json;

namespace HslCommunicationDemo.Plugins
{
	internal class JsonSystemVersionConverter : JsonConverter
	{
		/// <inheritdoc/>
		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
		{
			if (value is SystemVersion sv)
			{
				writer.WriteValue( sv.ToString( ) );
			}
		}

		/// <inheritdoc/>
		public override object ReadJson( JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer )
		{
			var strValue = reader.Value.ToString( );
			return new SystemVersion( strValue );
		}

		/// <inheritdoc/>
		public override bool CanConvert( Type objectType )
		{
			return objectType == typeof( SystemVersion );
		}
	}
}
