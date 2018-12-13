using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax.Metadata
{
    public class Metadata
    {
        public Metadata()
        {
            KernelInfo = new KernelInfo();
            LanguageInfo = new LanguageInfo();
        }

        [JsonProperty("kernelspec")] public KernelSpec KernelSpec { get; set; }

        [JsonProperty("kernel_info")] public KernelInfo KernelInfo { get; set; }

        [JsonProperty("language_info")] public LanguageInfo LanguageInfo { get; set; }
    }
}