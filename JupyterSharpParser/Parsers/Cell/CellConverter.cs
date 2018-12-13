using System;
using JupyterSharpParser.Extensions;
using JupyterSharpParser.Parsers.Common;
using JupyterSharpParser.Syntax.Cell;
using Newtonsoft.Json.Linq;

namespace JupyterSharpParser.Parsers.Cell
{
    public class CellConverter : JsonConverter<ICell>
    {
        protected override ICell Create(Type objectType, JObject jObject)
        {
            var cellType = jObject.Value<string>("cell_type");

            // select cell from type
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