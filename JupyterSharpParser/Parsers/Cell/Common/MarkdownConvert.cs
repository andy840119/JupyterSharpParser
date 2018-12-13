using System;
using JupyterSharpParser.Syntax.Cell.Common;
using Markdig;
using Markdig.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpParser.Parsers.Cell.Common
{
    public class MarkdownConvert : LinesConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var document = value as MarkdownDocument;

            if (document == null)
                throw new ArgumentNullException($"{nameof(document)} cannot be null.");

            var markdownText = document.ToPositionText();

            writer.WriteValue(markdownText);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var lines = base.ReadJson(reader, objectType, existingValue, serializer) as Lines;

            if (lines == null)
                throw new ArgumentNullException($"{nameof(lines)} cannot be null.");

            //convert to document
            var markdownText = lines.Text;
            var document = Markdown.Parse(markdownText);

            //return
            return document;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}