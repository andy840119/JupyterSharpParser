using JupyterSharpPhaser.Syntax.Cell.Common;
using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class OutputMetaData
    {
        [JsonProperty("image/png")] public Image Image { get; set; }
    }
}