using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JupyterSharpPhaser.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpPhaser.Renderers.Json
{
    public class JsonRendrer : TextRendererBase
    {
        public JsonRendrer(TextWriter writer) : base(writer)
        {
        }

        /// <summary>
        /// Renders the specified jupyter object (returns the <see cref="Writer"/> as a render object).
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns></returns>
        public override object Render(IJupyterObject jupyterObject)
        {
            //Instead of using IJupyterObjectRenderer, just using JsonConvert instead
            var result = JsonConvert.SerializeObject(jupyterObject);

            //write to string
            Write(result);

            //return writer
            return Writer;
        }
    }
}