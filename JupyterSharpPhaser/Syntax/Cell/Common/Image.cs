using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Cell.Common
{
    public class Image
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
