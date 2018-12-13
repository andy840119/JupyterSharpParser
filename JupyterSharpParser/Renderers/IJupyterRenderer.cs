using JupyterSharpParser.Syntax;

namespace JupyterSharpParser.Renderers
{
    public interface IJupyterRenderer
    {
        /// <summary>
        /// Gets the object renderers that will render <see cref="IJupyterObject"/> elements.
        /// </summary>
        ObjectRendererCollection ObjectRenderers { get; }

        /// <summary>
        /// Renders the specified jupyter object.
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns>The result of the rendering.</returns>
        object Render(IJupyterObject jupyterObject);
    }
}