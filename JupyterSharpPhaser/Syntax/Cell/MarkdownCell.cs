using JupyterSharpPhaser.Syntax.Cell.Common;
using Markdig.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell.Common;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class MarkdownCell : ICell , IJupyterObject
    {
        public MarkdownCell()
        {
            Source = new MarkdownDocument();
        }

        public CellType CellType => CellType.Markdown;

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(MarkdownConvert))]
        public MarkdownDocument Source { get; set; }

        [JsonIgnore]
        public MarkdownDocument MarkdownDocument => Source;
    }
}
