using JupyterSharpPhaser.Parsers.Cell.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Markdig;
using Markdig.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class MarkdownCell : ICell, IJupyterObject
    {
        public MarkdownCell()
        {
            Source = new Lines();
        }

        public CellType CellType => CellType.Markdown;

        [JsonProperty("metadata")] public object Metadata { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Source { get; set; }

        [JsonIgnore] public MarkdownDocument MarkdownDocument => Markdown.Parse(Source.Text);
    }
}