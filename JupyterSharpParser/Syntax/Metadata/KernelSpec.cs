using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Metadata
{
    public class KernelSpec
    {
        [JsonProperty("display_name")] public string DisplayName { get; set; }

        [JsonProperty("language")] public string Language { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}