using JupyterSharpParser.Parsers.Cell.Common;
using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell
{
    public class RawCell : ICell, IJupyterObject
    {
        public RawCell()
        {
            MetaData = new RawCellMetaData();
            Source = new Lines();
        }

        public CellType CellType => CellType.Raw;

        [JsonProperty("metadata")] public RawCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Source { get; set; }
    }

    public class RawCellMetaData
    {
        [JsonProperty("format")] public string Format { get; set; }
    }
}