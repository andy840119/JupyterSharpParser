using JupyterSharpPhaser.Syntax.Cell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell.Common;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class RawCell : ICell , IJupyterObject
    {
        public RawCell()
        {
            MetaData = new RawCellMetaData();
            Source = new Lines();
        }

        public CellType CellType => CellType.Raw;

        [JsonProperty("metadata")]
        public RawCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Source { get; set; }
    }

    public class RawCellMetaData
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
