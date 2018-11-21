using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Metadata
{
    public class KernelSpec
    {
        [JsonProperty("display_name")] public string DisplayName { get; set; }

        [JsonProperty("language")] public string Language { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}