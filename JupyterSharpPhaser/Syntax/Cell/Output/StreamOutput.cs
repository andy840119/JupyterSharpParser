using JupyterSharpPhaser.Syntax.Cell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell.Common;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class StreamOutput : IOutput , IJupyterObject
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
