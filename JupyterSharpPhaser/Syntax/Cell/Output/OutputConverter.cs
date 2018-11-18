using JupyterSharpPhaser.Common;
using JupyterSharpPhaser.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public class OutputConverter : JsonConverter<IOutput>
    {
        protected override IOutput Create(Type objectType, JObject jObject)
        {
            var cellType = jObject.Value<string>("output_type");
            // 讀取JSON後產生對應物件實體
            // 此處透過自訂Typename屬性內容判斷生成實體類別
            switch (cellType.ToEnum<OutputType>())
            {
                case OutputType.Stream:
                    return new StreamOutput();

                case OutputType.DisplayData:
                    return new DisplayDataOutput();

                case OutputType.ExecuteResult:
                    return new ExecuteResultOutput();

                case OutputType.Error:
                    return new ErrorOutput();

                default:
                    return null;
            }
        }
    }
}
