using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JupyterSharpPhaser.Common
{
    /// <summary>
    /// See :
    /// https://stackoverflow.com/a/45404471/4105113
    /// </summary>
    public class ArrayToStringJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value as string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                var arrayResult = string.Join("", token as JArray);
                return arrayResult;
            }

            string stringResult = token.Value<string>();
            return stringResult;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
