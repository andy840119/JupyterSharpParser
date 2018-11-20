using JupyterSharpPhaser.Syntax.Cell;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html.Renderer
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
