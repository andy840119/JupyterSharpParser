using System.IO;
using System.Reflection;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Common;
using JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Output;
using JupyterSharpPhaser.Syntax;

namespace JupyterSharpPhaser.Renderers.Html
{
    public class HtmlRenderer : TextRendererBase
    {
        public HtmlRenderer(TextWriter writer,bool rendererHeaderAndFooter = false) : base(writer)
        {
            RendererHeaderAndFooter = rendererHeaderAndFooter;

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

        public bool RendererHeaderAndFooter { get; set; }

        /// <summary>
        /// Renders the specified jupyter object (returns the <see cref="Writer"/> as a render object).
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns></returns>
        public override object Render(IJupyterObject jupyterObject)
        {
            if (jupyterObject is JupyterDocument jupyterDocument)
            {
                if (RendererHeaderAndFooter)
                {
                    //Head
                    WriteHeader();

                    //Body(Start)
                    WriteHtmlBodyStart();
                }

                //Cells
                foreach (var cell in jupyterDocument.Cells) base.Render(cell);

                if (RendererHeaderAndFooter)
                {
                    //Body(End)
                    WriteHtmlBodyEnd();
                }
            }
            else
            {
                base.Render(jupyterObject);
            }

            //return writer
            return Writer;
        }

        #region Utilities

        protected virtual void WriteHeader()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "JupyterSharpPhaser.Resources.JupyterHead.html";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();

                WriteLine("<!DOCTYPE html>");
                WriteLine("<html>");
                WriteLine(result);
            }
        }

        protected virtual void WriteHtmlBodyStart()
        {
            WriteLine("<body>");

            WriteLine(@"    <div tabindex=""-1"" id=""notebook"" class=""border-box-sizing"">");
            WriteLine(@"        <div class=""container"" id=""notebook-container"">");
        }

        protected virtual void WriteHtmlBodyEnd()
        {
            WriteLine(@"        </div>");
            WriteLine(@"    </div>");

            WriteLine("</body>");
            WriteLine("</html>");
        }

        #endregion
    }
}