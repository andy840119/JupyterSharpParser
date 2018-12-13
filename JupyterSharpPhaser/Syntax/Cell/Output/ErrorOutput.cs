using JupyterSharpParser.Parsers.Cell.Common;
using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    public class ErrorOutput : IOutput, IJupyterObject
    {
        public ErrorOutput()
        {
            Traceback = new Lines();
        }

        public OutputType OutputType => OutputType.Error;

        [JsonProperty("ename")] public string Ename { get; set; }

        [JsonProperty("evalue")] public string Evalue { get; set; }

        [JsonProperty("traceback")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Traceback { get; set; }
    }
}