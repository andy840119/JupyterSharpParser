using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using Markdig.Renderers;
using Markdig.Syntax;

namespace JupyterSharpPhaser.Renderers
{
    /// <summary>
    /// <see cref="IMarkdownObjectRenderer"/>
    /// </summary>
    public interface IJupyterObjectRenderer
    {
        /// <summary>
        /// Accepts the specified <see cref="IJupyterObject"/>.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="obj">The Jupyter object.</param>
        /// <returns><c>true</c> If this renderer is accepting to render the specified Jupyter object</returns>
        bool Accept(RendererBase renderer, IJupyterObject obj);

        /// <summary>
        /// Writes the specified <see cref="IJupyterObject"/> to the <see cref="renderer"/>.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="objectToRender">The object to render.</param>
        void Write(RendererBase renderer, IJupyterObject objectToRender);
    }
}