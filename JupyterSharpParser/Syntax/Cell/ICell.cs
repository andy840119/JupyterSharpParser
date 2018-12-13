using JupyterSharpParser.Parsers.Cell;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell
{
    [JsonConverter(typeof(CellConverter))]
    public interface ICell : IJupyterObject
    {
        [JsonProperty("cell_type")] CellType CellType { get; }
    }
}