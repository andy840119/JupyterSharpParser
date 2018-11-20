using System;
using System.Linq;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JupyterSharpPhaser.Parsers.Cell.Common
{
    /// <summary>
    /// See :
    /// https://stackoverflow.com/a/45404471/4105113
    /// </summary>
    public class LinesConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var lines = value as Lines;
            
            if(!lines.MultiLine)
                writer.WriteValue(lines.Text as string);

            //add \n
            var array = lines.Select(x => x + "\n").ToList();

            //TODO : export as array
            writer.WriteValue(JsonConvert.SerializeObject(array));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var lines = new Lines();

            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var arrayLines = token.Select(x => (string)x).Select(x => x.EndsWith("\n") ? x.TrimEnd() : x).ToList();
                lines.AddRange(arrayLines);
                lines.MultiLine = true;
            }
            else
            {
                var arrayLines = token.Value<string>().Split("\n").ToList();
                lines.AddRange(arrayLines);
                lines.MultiLine = false;
            }

            return lines;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
