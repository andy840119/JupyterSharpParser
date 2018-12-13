using System;
using System.IO;
using JupyterSharpParser.Syntax;

namespace JupyterSharpParser.Renderers
{
    /// <summary>
    /// A text based <see cref="IJupyterRenderer"/>.
    /// </summary>
    /// <seealso cref="RendererBase" />
    public abstract class TextRendererBase : RendererBase
    {
        private TextWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRendererBase"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected TextRendererBase(TextWriter writer)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));

            // By default we output a newline with '\n' only even on Windows platforms
            Writer.NewLine = "\n";
        }

        /// <summary>
        /// Gets or sets the writer.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">if the value is null</exception>
        public TextWriter Writer
        {
            get => writer;
            set => writer = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Writes the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>This instance</returns>
        public void Write(string content)
        {
            Writer.Write(content);
        }

        /// <summary>
        /// Writes the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>This instance</returns>
        public void WriteLine(string content)
        {
            Writer.WriteLine(content);
        }

        /// <summary>
        /// Renders the specified jupyter object (returns the <see cref="Writer"/> as a render object).
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns></returns>
        public override object Render(IJupyterObject jupyterObject)
        {
            Write(jupyterObject);
            return Writer;
        }
    }
}