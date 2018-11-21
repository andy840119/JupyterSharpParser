using JupyterSharpPhaser.Syntax;

namespace JupyterSharpPhaser.Renderers.Html.Renderer
{
    public abstract class HtmlObjectRenderer<TObject> : JupyterObjectRenderer<HtmlRenderer, TObject>
        where TObject : IJupyterObject
    {
    }
}