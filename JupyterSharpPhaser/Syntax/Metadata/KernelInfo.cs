using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Metadata
{
    public class KernelInfo
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
}