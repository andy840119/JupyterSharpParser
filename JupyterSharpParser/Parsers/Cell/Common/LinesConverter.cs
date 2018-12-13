using System;
using System.Linq;
using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JupyterSharpParser.Parsers.Cell.Common
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

            if(lines == null)
                throw new ArgumentNullException($"{nameof(lines)} cannot be null.");

            if (!lines.MultiLine)
            {
                writer.WriteValue(lines.Text);
            }
            else
            {
                //add \n
                var array = lines.Select(x => x + "\n").ToList();
                var arrayString = JsonConvert.SerializeObject(array);

                //TODO : export as array
                writer.WriteValue(arrayString);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var lines = new Lines();

            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var arrayLines = token.Select(x => (string) x).Select(x => x.EndsWith("\n") ? x.TrimEnd() : x).ToList();
                lines.AddRange(arrayLines);
                lines.MultiLine = true;
            }
            else
            {
                var arrayLines = token.Value<string>().Split('\n').ToList();
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