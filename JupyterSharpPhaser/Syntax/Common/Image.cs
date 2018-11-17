using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Common
{
    public class Image
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
