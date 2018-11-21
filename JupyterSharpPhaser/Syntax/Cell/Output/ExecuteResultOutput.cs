using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class ExecuteResultOutput : IOutput, IJupyterObject
    {
        public ExecuteResultOutput()
        {
            Data = new OutputData();
            MetaData = new OutputMetaData();
        }

        public OutputType OutputType => OutputType.ExecuteResult;

        [JsonProperty("execution_count")] public int ExecutionCount { get; set; }

        [JsonProperty("data")] public OutputData Data { get; set; }

        [JsonProperty("metadata")] public OutputMetaData MetaData { get; set; }
    }
}