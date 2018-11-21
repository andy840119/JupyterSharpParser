using JupyterSharpPhaser.Parsers;
using JupyterSharpPhaser.Syntax;
using Markdig;
using System;

namespace JupyterSharpPhaser
{
    public class Jupyter
    {
        /// <summary>
        /// Parses the specified Jupyter text into an Document <see cref="JupyterDocument"/>
        /// </summary>
        /// <param name="jupyterText">Jupyter text</param>
        /// <returns>Jupyter document</returns>
        /// <exception cref="System.ArgumentNullException">if Jupyter text variable is null</exception>
        public static JupyterDocument Parse(string jupyterText)
        {
            if (string.IsNullOrEmpty(jupyterText))
                throw new ArgumentNullException(nameof(jupyterText));

            return Parse(jupyterText, null);
        }

        /// <summary>
        /// Parses the specified Jupyter text into an Document <see cref="JupyterDocument"/>
        /// </summary>
        /// <param name="jupyterText">Jupyter text.</param>
        /// <param name="pipeline">The pipeline used for the parsing.</param>
        /// <returns>Jupyter document</returns>
        /// <exception cref="System.ArgumentNullException">if Jupyter text variable is null</exception>
        public static JupyterDocument Parse(string jupyterText, MarkdownPipeline pipeline)
        {
            if (string.IsNullOrEmpty(jupyterText))
                throw new ArgumentNullException(nameof(jupyterText));

            pipeline = pipeline ?? new MarkdownPipelineBuilder().Build();

            return JupyterParser.Parse(jupyterText, pipeline);
        }
    }
}