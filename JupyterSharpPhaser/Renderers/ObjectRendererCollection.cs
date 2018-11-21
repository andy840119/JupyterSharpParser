using Markdig.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers
{
    /// <summary>
    /// A collection of <see cref="IJupyterObjectRenderer"/>.
    /// </summary>
    /// <seealso cref="Markdig.Helpers.OrderedList{Markdig.Renderers.IMarkdownObjectRenderer}" />
    public class ObjectRendererCollection : OrderedList<IJupyterObjectRenderer>
    {
    }
}