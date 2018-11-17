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
            Traceback = new List<string>();
        }

        public OutputType OutputType => OutputType.Error;

        [JsonProperty("ename")]
        public string Ename { get; set; }

        [JsonProperty("evalue")]
        public string Evalue { get; set; }

        [JsonProperty("traceback")]
        public IList<string> Traceback { get; set; }
    }
}
