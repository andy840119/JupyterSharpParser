using JupyterSharpParser.Parsers.Cell.Common;
using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    public class OutputData
    {
        public OutputData()
        {
            TextPlain = new Lines();
            ApplicationJson = new ApplicationJson();
        }

        [JsonProperty("text/plain")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines TextPlain { get; set; }

        [JsonProperty("image/png")] public string ImageData { get; set; }

        [JsonProperty("application/json")] public ApplicationJson ApplicationJson { get; set; }
    }

    public class ApplicationJson
    {
        [JsonProperty("json")] public string Json { get; set; }
    }
}