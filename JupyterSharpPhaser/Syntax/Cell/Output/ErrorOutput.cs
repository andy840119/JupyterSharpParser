using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class ErrorOutput : IOutput
    {
        public ErrorOutput()
        {
            Traceback = new Lines();
        }

        public OutputType OutputType => OutputType.Error;

        [JsonProperty("ename")]
        public string Ename { get; set; }

        [JsonProperty("evalue")]
        public string Evalue { get; set; }

        [JsonProperty("traceback")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Traceback { get; set; }
    }
}
