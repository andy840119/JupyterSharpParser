using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class RawCell : ICell
    {
        public RawCell()
        {
            MetaData = new RawCellMetaData();
            Source = new List<string>();
        }

        public CellType CellType => CellType.Raw;

        [JsonProperty("metadata")]
        public RawCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        public IList<string> Source { get; set; }
    }

    public class RawCellMetaData
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
