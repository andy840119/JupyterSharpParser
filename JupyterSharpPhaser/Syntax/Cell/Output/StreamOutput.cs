using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
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
            Text = new Lines();
        }

        public OutputType OutputType => OutputType.Stream;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Text { get; set; }
    }
}
