using JupyterSharpParser.Syntax.Cell.Common;

namespace JupyterSharpParser.Renderers.Html.Renderer.Cell.Common
{
    public class LinesRenderer : HtmlObjectRenderer<Lines>
    {
        protected override void Write(HtmlRenderer renderer, Lines obj)
        {
            renderer.WriteLine(@"<pre>");

            //TODO : renderer language style
            renderer.WriteLine(@"<span>" + obj.Text + "</span>");
            renderer.WriteLine(@"</pre>");
        }
    }
}