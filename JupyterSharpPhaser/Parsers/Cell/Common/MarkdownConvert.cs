using System;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Markdig;
using Markdig.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpPhaser.Parsers.Cell.Common
{
    public class MarkdownConvert : LinesConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var document = value as MarkdownDocument;
            var merkdownTect = document.ToPositionText();

            writer.WriteValue(merkdownTect);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var lines = base.ReadJson(reader, objectType, existingValue, serializer) as Lines;

            //convert to document
            var markdowoText = lines.Text;
            var document = Markdown.Parse(markdowoText);

            //return
            return document;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}