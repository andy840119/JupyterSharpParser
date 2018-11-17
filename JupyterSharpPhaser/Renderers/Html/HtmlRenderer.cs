using JupyterSharpPhaser.Renderers.Html.Renderer;
using Markdig.Renderers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html
{
    public class HtmlRenderer : TextRendererBase<HtmlRenderer>
    {
        public HtmlRenderer(TextWriter writer) : base(writer)
        {
            // Default block renderers
            ObjectRenderers.Add(new MarkdownCellRenderer());
            ObjectRenderers.Add(new CodeCellRenderer());
            ObjectRenderers.Add(new RawCellRenderer());
        }
    }
}
