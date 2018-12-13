using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Metadata
{
    public class KernelInfo
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
}