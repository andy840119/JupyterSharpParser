using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Syntax.Cell.Common;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Common
{
    public class LinesRenderer : HtmlObjectRenderer<Lines>
    {
        protected override void Write(HtmlRenderer renderer, Lines obj)
        {
            renderer.WriteLine(@"<pre>");
            renderer.WriteLine(@"   <span></span>");

            //TODO : renderer language style
            renderer.WriteLine(@"   <span>" + obj.Text + "</span>");
            renderer.WriteLine(@"</pre>");
        }
    }
}
