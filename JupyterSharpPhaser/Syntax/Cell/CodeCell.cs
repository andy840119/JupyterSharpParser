using JupyterSharpPhaser.Syntax.Cell.Output;
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
            Source = new List<string>();
            Outputs = new List<IOutput>();
        }

        public CellType CellType => CellType.Code;

        [JsonProperty("execution_count")]
        public int ExecutionCount { get; set; }

        [JsonProperty("metadata")]
        public CodeCellMetaData MetaData { get; set; }

        [JsonProperty("source")]
        public IList<string> Source { get; set; }

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
