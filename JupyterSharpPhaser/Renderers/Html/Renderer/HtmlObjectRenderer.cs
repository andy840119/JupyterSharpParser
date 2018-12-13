using JupyterSharpParser.Syntax;

namespace JupyterSharpParser.Renderers.Html.Renderer
{
    public abstract class HtmlObjectRenderer<TObject> : JupyterObjectRenderer<HtmlRenderer, TObject>
        where TObject : IJupyterObject
    {
    }
}