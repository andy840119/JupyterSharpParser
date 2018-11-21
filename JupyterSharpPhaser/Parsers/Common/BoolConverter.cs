using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JupyterSharpPhaser.Parsers.Common
{
    /// <summary>
    /// See :
    /// https://stackoverflow.com/a/45404471/4105113
    /// </summary>
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool) value ? "1" : "0");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Boolean)
                return (bool) token;
            return token.ToString() != "0";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}