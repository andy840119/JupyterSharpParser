using JupyterSharpParser.Parsers.Cell.Common;
using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    public class StreamOutput : IOutput, IJupyterObject
    {
        public StreamOutput()
        {
            Text = new Lines();
        }

        public OutputType OutputType => OutputType.Stream;

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("text")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Text { get; set; }
    }
}