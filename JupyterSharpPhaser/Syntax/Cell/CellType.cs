using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell
{
    public enum CellType
    {
        [EnumMember(Value = "markdown")]
        Markdown,

        [EnumMember(Value = "code")]
        Code,

        [EnumMember(Value = "raw")]
        Raw,
    }
}
