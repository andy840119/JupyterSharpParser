using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Markdig.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class MarkdownCell : ICell
    {
        public CellType CellType => CellType.Markdown;

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Source { get; set; }

        [JsonIgnore]
        public MarkdownDocument MarkdownDocument { get; set; }
    }
}
