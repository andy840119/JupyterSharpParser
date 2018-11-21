using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JupyterSharpPhaser.Syntax.Cell.Output
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OutputType
    {
        [EnumMember(Value = "stream")] Stream,

        [EnumMember(Value = "display_data")] DisplayData,

        [EnumMember(Value = "execute_result")] ExecuteResult,

        [EnumMember(Value = "error")] Error,
    }
}