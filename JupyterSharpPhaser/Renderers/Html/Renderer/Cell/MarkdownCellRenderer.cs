using System;
using JupyterSharpPhaser.Syntax.Cell;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class MarkdownCellRenderer : HtmlObjectRenderer<MarkdownCell>
    {
        protected override void Write(HtmlRenderer renderer, MarkdownCell obj)
        {
            throw new NotImplementedException();
        }
    }
}
