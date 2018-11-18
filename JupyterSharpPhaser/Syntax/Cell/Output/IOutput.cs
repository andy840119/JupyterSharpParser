using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    [JsonConverter(typeof(OutputConverter))]
    public interface IOutput
    {
        [JsonProperty("output_type")]
        OutputType OutputType { get; }
    }
}
