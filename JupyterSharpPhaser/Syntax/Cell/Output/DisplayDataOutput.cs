using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class DisplayDataOutput : IOutput , IJupyterObject
    {
        public DisplayDataOutput()
        {
            Data = new OutputData();
            MetaData = new OutputMetaData();
        }

        public OutputType OutputType => OutputType.DisplayData;

        [JsonProperty("data")]
        public OutputData Data { get; set; }

        [JsonProperty("metadata")]
        public OutputMetaData MetaData { get; set; }
    }
}
