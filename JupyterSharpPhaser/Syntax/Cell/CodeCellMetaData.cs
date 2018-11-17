using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class CodeCellMetaData : ICellMetaData
    {
        [JsonProperty("collapsed")]
        public bool Collapsed { get; set; }

        [JsonProperty("autoscroll")]
        public bool AutoScroll { get; set; }
    }
}
