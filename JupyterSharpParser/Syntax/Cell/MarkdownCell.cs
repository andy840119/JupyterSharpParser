using JupyterSharpParser.Parsers.Cell.Common;
using JupyterSharpParser.Syntax.Cell.Common;
using Markdig;
using Markdig.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell
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
        public Lines Source { get; set; }

        [JsonIgnore] public MarkdownDocument MarkdownDocument => Markdown.Parse(Source.Text);
    }
}