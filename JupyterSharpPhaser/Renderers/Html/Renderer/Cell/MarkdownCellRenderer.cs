using System;
using JupyterSharpPhaser.Syntax.Cell;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class MarkdownCellRenderer : HtmlObjectRenderer<MarkdownCell>
    {
        public bool Accept(RendererBase renderer, MarkdownCell obj)
        {
            throw new NotImplementedException();
        }

        public void Write(RendererBase renderer, MarkdownCell objectToRender)
        {
            throw new NotImplementedException();
        }
    }
}
