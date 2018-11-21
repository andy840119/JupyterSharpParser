using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JupyterSharpPhaser.Syntax.Cell
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CellType
    {
        [EnumMember(Value = "markdown")] Markdown,

        [EnumMember(Value = "code")] Code,

        [EnumMember(Value = "raw")] Raw,
    }
}