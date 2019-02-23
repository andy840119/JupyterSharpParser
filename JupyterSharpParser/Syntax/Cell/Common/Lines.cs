using System.Collections.Generic;
using JupyterSharpParser.Parsers.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Common
{
    [JsonConverter(typeof(LinesConverter))]
    public class Lines : List<string>, IJupyterObject
    {
        public bool MultiLine { get; set; }

        public string Text => string.Join("\n", this);
    }
}