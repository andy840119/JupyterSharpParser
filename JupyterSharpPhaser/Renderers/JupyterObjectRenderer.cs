using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using Markdig.Renderers;
using Markdig.Helpers;

namespace JupyterSharpPhaser.Renderers
{
    /// <summary>
    /// <see cref="MarkdownObjectRenderer{TRenderer,TObject}"/>
    /// </summary>
    /// <typeparam name="TRenderer"></typeparam>
    /// <typeparam name="TObject"></typeparam>
    public abstract class JupyterObjectRenderer<TRenderer, TObject> : IJupyterObjectRenderer 
        where TRenderer : RendererBase where TObject : IJupyterObject
    {
        protected JupyterObjectRenderer()
        {
            TryWriters = new OrderedList<TryWriteDelegate>();
        }

        public delegate bool TryWriteDelegate(TRenderer renderer, TObject obj);

        public virtual bool Accept(RendererBase renderer, IJupyterObject obj)
        {
            return obj is TObject;
        }

        public virtual void Write(RendererBase renderer, IJupyterObject obj)
        {
            var htmlRenderer = (TRenderer)renderer;
            var typedObj = (TObject)obj;

            // Try processing
            for (int i = 0; i < TryWriters.Count; i++)
            {
                var tryWriter = TryWriters[i];
                if (tryWriter(htmlRenderer, typedObj))
                {
                    return;
                }
            }

            Write(htmlRenderer, typedObj);
        }

        /// <summary>
        /// Gets the optional writers attached to this instance.
        /// </summary>
        public OrderedList<TryWriteDelegate> TryWriters { get; }

        /// <summary>
        /// Writes the specified Markdown object to the renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="obj">The markdown object.</param>
        protected abstract void Write(TRenderer renderer, TObject obj);
    }
}
