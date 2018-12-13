using System;
using JupyterSharpParser.Syntax;

namespace JupyterSharpParser.Renderers
{
    public abstract class RendererBase : IJupyterRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RendererBase"/> class.
        /// </summary>
        protected RendererBase()
        {
            ObjectRenderers = new ObjectRendererCollection();
        }

        /// <summary>
        /// Available 
        /// </summary>
        public ObjectRendererCollection ObjectRenderers { get; }

        public abstract object Render(IJupyterObject jupyterObject);

        /// <summary>
        /// Writes the specified Jupyter object.
        /// </summary>
        /// <typeparam name="T">A JupyterObject type</typeparam>
        /// <param name="obj">The Jupyter object to write to this renderer.</param>
        public void Write<T>(T obj) where T : IJupyterObject
        {
            if (obj == null) return;

            var objectType = obj.GetType();

            IJupyterObjectRenderer selectedRenderer = null;
            foreach (var renderer in ObjectRenderers)
                if (renderer.Accept(this, obj))
                {
                    selectedRenderer = renderer;
                    break;
                }

            if (selectedRenderer != null)
                selectedRenderer.Write(this, obj);
            else
                throw new ArgumentNullException(nameof(selectedRenderer) + " is not asigned!");
        }
    }
}