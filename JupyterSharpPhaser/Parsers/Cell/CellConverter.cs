using System;
using JupyterSharpPhaser.Extensions;
using JupyterSharpPhaser.Parsers.Common;
using JupyterSharpPhaser.Syntax.Cell;
using Newtonsoft.Json.Linq;

namespace JupyterSharpPhaser.Parsers.Cell
{
    public class CellConverter : JsonConverter<ICell>
    {
        protected override ICell Create(Type objectType, JObject jObject)
        {
            var cellType = jObject.Value<string>("cell_type");
            // 讀取JSON後產生對應物件實體
            // 此處透過自訂Typename屬性內容判斷生成實體類別
            switch (cellType.ToEnum<CellType>())
            {
                case CellType.Markdown:
                    return new MarkdownCell();

                case CellType.Code:
                    return new CodeCell();

                case CellType.Raw:
                    return new RawCell();

                default:
                    return null;
            }
        }
    }
}
