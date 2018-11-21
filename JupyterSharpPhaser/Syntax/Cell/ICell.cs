using JupyterSharpPhaser.Parsers.Cell;
using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Cell
{
    [JsonConverter(typeof(CellConverter))]
    public interface ICell : IJupyterObject
    {
        [JsonProperty("cell_type")] CellType CellType { get; }
    }
}