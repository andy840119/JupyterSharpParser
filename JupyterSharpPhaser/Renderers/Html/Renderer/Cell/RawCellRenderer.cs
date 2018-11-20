using System;
using JupyterSharpPhaser.Syntax.Cell;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class RawCellRenderer : HtmlObjectRenderer<RawCell>
    {
        public bool Accept(RendererBase renderer, RawCell obj)
        {
            throw new NotImplementedException();
        }

        public void Write(RendererBase renderer, RawCell objectToRender)
        {
            throw new NotImplementedException();
        }
    }
}
