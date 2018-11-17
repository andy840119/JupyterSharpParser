using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    public enum OutputType
    {
        [EnumMember(Value = "stream")]
        Stream,

        [EnumMember(Value = "display_data")]
        DisplayData,

        [EnumMember(Value = "execute_result")]
        ExecuteResult,

        [EnumMember(Value = "error")]
        Error,
    }
}
