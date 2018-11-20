using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html.Renderer
{
    public abstract class HtmlObjectRenderer<TObject> : JupyterObjectRenderer<HtmlRenderer,TObject> where TObject : IJupyterObject
    {
    }
}
