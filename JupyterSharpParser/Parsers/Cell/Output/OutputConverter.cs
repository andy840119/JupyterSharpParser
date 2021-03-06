﻿using System;
using JupyterSharpParser.Extensions;
using JupyterSharpParser.Parsers.Common;
using JupyterSharpParser.Syntax.Cell.Output;
using Newtonsoft.Json.Linq;

namespace JupyterSharpParser.Parsers.Cell.Output
{
    public class OutputConverter : JsonConverter<IOutput>
    {
        protected override IOutput Create(Type objectType, JObject jObject)
        {
            var cellType = jObject.Value<string>("output_type");

            // select cell from type
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