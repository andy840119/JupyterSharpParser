using Newtonsoft.Json;

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