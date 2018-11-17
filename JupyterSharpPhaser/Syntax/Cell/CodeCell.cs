using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class CodeCell : ICell
    {
        public CodeCell()
        {
            MetaData = new CodeCellMetaData();
            Outputs = new List<string>();
        }

        public CellType CellType => CellType.Code;

        [JsonProperty("metadata")]
        public CodeCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("outputs")]
        public IList<string> Outputs { get; set; }
    }
}
