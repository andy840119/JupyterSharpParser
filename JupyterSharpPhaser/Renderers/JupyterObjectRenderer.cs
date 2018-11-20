using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers
{
    public class JupyterObjectRenderer<TRenderer, TObject> : IJupyterObjectRenderer 
        where TRenderer : RendererBase where TObject : IJupyterObject
    {

    }
}
