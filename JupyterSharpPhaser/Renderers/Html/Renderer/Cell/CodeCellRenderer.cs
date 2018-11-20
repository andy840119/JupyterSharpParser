using System;
using JupyterSharpPhaser.Syntax.Cell;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class CodeCellRenderer : HtmlObjectRenderer<CodeCell>
    {
        public bool Accept(RendererBase renderer, CodeCell obj)
        {
            throw new NotImplementedException();
        }

        public void Write(RendererBase renderer, CodeCell objectToRender)
        {
            throw new NotImplementedException();
        }
    }
}
