using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Markdig.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Parsers.Common
{
    public class MarkdownConvert : LinesConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var document = value as MarkdownDocument;
            var merkdownTect = document.ToPositionText();

            writer.WriteValue(merkdownTect);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var lines = base.ReadJson(reader, objectType, existingValue, serializer) as Lines;

            //convert to document
            var markdowoText = lines.Text;
            var document = Markdig.Markdown.Parse(markdowoText);

            //return
            return document;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
