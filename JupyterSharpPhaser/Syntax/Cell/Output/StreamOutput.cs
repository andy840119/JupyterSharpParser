using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class StreamOutput : IOutput
    {
        public StreamOutput()
        {
            Text = new List<string>();
        }

        public OutputType OutputType => OutputType.Stream;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        public IList<string> Text { get; set; }
    }
}
