using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class StreamOutput : IOutput
    {
        public OutputType OutputType => OutputType.Stream;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
