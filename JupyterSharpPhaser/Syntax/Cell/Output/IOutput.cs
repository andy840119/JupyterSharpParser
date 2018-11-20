using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Parsers.Cell.Output;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    [JsonConverter(typeof(OutputConverter))]
    public interface IOutput : IJupyterObject
    {
        [JsonProperty("output_type")]
        OutputType OutputType { get; }
    }
}
