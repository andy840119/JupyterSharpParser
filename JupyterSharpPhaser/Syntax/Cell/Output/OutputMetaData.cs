using JupyterSharpPhaser.Syntax.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class OutputMetaData
    {
        [JsonProperty("image/png")]
        public Image Image { get; set; }
    }
}
