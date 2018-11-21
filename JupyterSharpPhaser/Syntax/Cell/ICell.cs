using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell;

namespace JupyterSharpPhaser.Syntax.Cell
{
    [JsonConverter(typeof(CellConverter))]
    public interface ICell : IJupyterObject
    {
        [JsonProperty("cell_type")] CellType CellType { get; }
    }
}