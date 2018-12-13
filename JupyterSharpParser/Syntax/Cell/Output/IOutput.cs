using JupyterSharpParser.Parsers.Cell.Output;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    [JsonConverter(typeof(OutputConverter))]
    public interface IOutput : IJupyterObject
    {
        [JsonProperty("output_type")] OutputType OutputType { get; }
    }
}