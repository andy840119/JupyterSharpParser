using JupyterSharpParser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Output
{
    public class OutputMetaData
    {
        [JsonProperty("image/png")] public Image Image { get; set; }
    }
}