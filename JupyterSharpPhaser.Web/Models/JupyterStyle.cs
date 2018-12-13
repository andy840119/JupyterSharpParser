using System.ComponentModel;

namespace JupyterSharpParser.Web.Models
{
    /// <summary>
    /// See :
    /// Theme downloaded from https://github.com/dunovank/jupyter-themes
    /// </summary>
    public enum JupyterStyle
    {
        [Description("Chesterish")]
        Chesterish,

        [Description("Grade3")]
        Grade3,

        [Description("Gruvboxd")]
        Gruvboxd,

        [Description("Gruvboxl")]
        Gruvboxl,

        [Description("Monokai")]
        Monokai,

        [Description("Oceans16")]
        Oceans16,

        [Description("Onedork")]
        Onedork,

        [Description("Solarizedd")]
        Solarizedd,

        [Description("Solarizedl")]
        Solarizedl
    }
}
