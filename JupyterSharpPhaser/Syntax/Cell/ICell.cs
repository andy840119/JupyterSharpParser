using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public interface ICell
    {
        [JsonProperty("cell_type")]
        CellType CellType { get; }
    }
}
