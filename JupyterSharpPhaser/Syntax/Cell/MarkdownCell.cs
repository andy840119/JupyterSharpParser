using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public class MarkdownCell
    {
        public MarkdownCell()
        {
            Source = new List<string>();
        }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("source")]
        public IList<string> Source { get; set; }
    }
}
