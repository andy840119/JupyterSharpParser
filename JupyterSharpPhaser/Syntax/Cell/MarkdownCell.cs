using Markdig.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class MarkdownCell : ICell
    {
        public MarkdownCell()
        {
            Source = new List<string>();
        }

        public CellType CellType => CellType.Markdown;

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("source")]
        public IList<string> Source { get; set; }

        [JsonIgnore]
        public MarkdownDocument MarkdownDocument { get; set; }
    }
}
