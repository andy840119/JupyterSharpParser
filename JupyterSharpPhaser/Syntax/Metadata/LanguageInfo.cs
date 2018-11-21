using Newtonsoft.Json;

namespace JupyterSharpPhaser.Syntax.Metadata
{
    public class LanguageInfo
    {
        public LanguageInfo()
        {
            CodemirrorMode = new CodemirrorMode();
        }

        [JsonProperty("codemirror_mode")] public CodemirrorMode CodemirrorMode { get; set; }

        [JsonProperty("file_extension")] public string FileExtension { get; set; }

        [JsonProperty("mimetype")] public string MimeType { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("nbconvert_exporter")] public string NbconvertExporter { get; set; }

        [JsonProperty("pygments_lexer")] public string PygmentsLexer { get; set; }

        [JsonProperty("version")] public string Version { get; set; }
    }

    public class CodemirrorMode
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("version")] public string Version { get; set; }
    }
}