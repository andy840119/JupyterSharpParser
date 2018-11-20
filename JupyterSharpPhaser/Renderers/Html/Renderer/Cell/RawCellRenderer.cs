using JupyterSharpPhaser.Syntax.Cell;
using Markdig.Renderers;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html.Renderer
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
