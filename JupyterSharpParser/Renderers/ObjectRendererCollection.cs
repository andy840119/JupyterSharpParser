using Markdig.Helpers;

namespace JupyterSharpParser.Renderers
{
    /// <summary>
    /// A collection of <see cref="IJupyterObjectRenderer"/>.
    /// </summary>
    /// <seealso cref="Markdig.Helpers.OrderedList{Markdig.Renderers.IMarkdownObjectRenderer}" />
    public class ObjectRendererCollection : OrderedList<IJupyterObjectRenderer>
    {
    }
}