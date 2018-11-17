using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Metadata
{
    public class KernelInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
