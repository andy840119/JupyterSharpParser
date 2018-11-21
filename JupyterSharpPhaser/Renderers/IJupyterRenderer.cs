using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers
{
    public interface IJupyterRenderer
    {
        /// <summary>
        /// Gets the object renderers that will render <see cref="Block"/> and <see cref="Inline"/> elements.
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