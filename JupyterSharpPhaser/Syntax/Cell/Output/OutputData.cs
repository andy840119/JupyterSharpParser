using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Syntax.Cell.Common;
using JupyterSharpPhaser.Syntax.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class OutputData
    {
        public OutputData()
        {
            Text = new Lines();
            ApplicationJson = new ApplicationJson();
        }

        [JsonProperty("text/plain")]
        [JsonConverter(typeof(LinesConverter))]
        public Lines Text { get; set; }

        [JsonProperty("image/png")]
        public string ImageData { get; set; }

        [JsonProperty("application/json")]
        public ApplicationJson ApplicationJson { get; set; }
    }

    public class ApplicationJson
    {
        [JsonProperty("json")]
        public string Json { get; set; }
    }
}
