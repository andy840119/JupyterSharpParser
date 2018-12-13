using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Cell.Common
{
    public class Image
    {
        [JsonProperty("width")] public int Width { get; set; }

        [JsonProperty("height")] public int Height { get; set; }
    }
}