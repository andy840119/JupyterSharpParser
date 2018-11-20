using JupyterSharpPhaser.Renderers.Html.Renderer;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Common;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Output;
using JupyterSharpPhaser.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html
{
    public class HtmlRenderer : TextRendererBase
    {
        public HtmlRenderer(TextWriter writer) : base(writer)
        {
            //Cell renderer
            ObjectRenderers.Add(new MarkdownCellRenderer());
            ObjectRenderers.Add(new CodeCellRenderer());
            ObjectRenderers.Add(new RawCellRenderer());

            //Common renderer
            ObjectRenderers.Add(new LinesRenderer());

            //Output renderer
            ObjectRenderers.Add(new DisplayDataOutputRenderer());
            ObjectRenderers.Add(new ErrorOutputRenderer());
            ObjectRenderers.Add(new ExecuteResultOutputRenderer());
            ObjectRenderers.Add(new StreamOutputRenderer());
        }

        #region Utilities

        protected virtual void WriteHeader()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MyCompany.MyProduct.MyFile.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                WriteLine("<!DOCTYPE html>");
                WriteLine("<html>");
                WriteLine(result);
            } 
        }

        protected void WriteHtmlBodyStart()
        {
            WriteLine("<body>");
        }

        protected void WriteHtmlBodyEnd()
        {
            WriteLine("</body>");
            WriteLine("</html>");
        }

        #endregion

        /// <summary>
        /// Renders the specified jupyter object (returns the <see cref="Writer"/> as a render object).
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns></returns>
        public override object Render(IJupyterObject jupyterObject)
        {
            if (jupyterObject is JupyterDocument jupyterDocument)
            {
                //Head
                WriteHeader();

                //Body(Start)
                WriteHtmlBodyStart();

                //Cells
                foreach (var cell in jupyterDocument.Cells)
                {
                    base.Render(jupyterObject);
                }
                    
                //Body(Emd)
                WriteHtmlBodyEnd();
            }
            else
            {
                base.Render(jupyterObject);
            }

            //return writer
            return Writer;
        }
    }
}
