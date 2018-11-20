using System;
using JupyterSharpPhaser.Extensions;
using JupyterSharpPhaser.Parsers.Common;
using JupyterSharpPhaser.Syntax.Cell.Output;
using Newtonsoft.Json.Linq;

namespace JupyterSharpPhaser.Parsers.Cell.Output
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
