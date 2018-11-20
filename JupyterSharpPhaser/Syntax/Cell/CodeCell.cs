using JupyterSharpPhaser.Syntax.Cell.Common;
using JupyterSharpPhaser.Syntax.Cell.Output;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell.Common;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class CodeCell : ICell , IJupyterObject
    {
        public CodeCell()
        {
            MetaData = new CodeCellMetaData();
            Source = new Lines();
            Outputs = new List<IOutput>();
        }

        public CellType CellType => CellType.Code;

        [JsonProperty("execution_count")]
        public int ExecutionCount { get; set; }

        [JsonProperty("metadata")]
        public CodeCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Source { get; set; }

        [JsonProperty("outputs")]
        public IList<IOutput> Outputs { get; set; }
    }

    public class CodeCellMetaData
    {
        [JsonProperty("collapsed")]
        public bool Collapsed { get; set; }

        [JsonProperty("autoscroll")]
        public bool AutoScroll { get; set; }
    }
}
