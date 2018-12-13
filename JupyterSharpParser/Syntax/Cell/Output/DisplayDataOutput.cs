using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    public class DisplayDataOutput : IOutput, IJupyterObject
    {
        public DisplayDataOutput()
        {
            Data = new OutputData();
            MetaData = new OutputMetaData();
        }

        public OutputType OutputType => OutputType.DisplayData;

        [JsonProperty("data")] public OutputData Data { get; set; }

        [JsonProperty("metadata")] public OutputMetaData MetaData { get; set; }
    }
}