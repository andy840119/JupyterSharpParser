using Markdig.Renderers;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html.Renderer
{
    public class MarkdownCellRenderer : IMarkdownObjectRenderer
    {
        public bool Accept(RendererBase renderer, MarkdownObject obj)
        {
            throw new NotImplementedException();
        }

        public void Write(RendererBase renderer, MarkdownObject objectToRender)
        {
            throw new NotImplementedException();
        }
    }
}
