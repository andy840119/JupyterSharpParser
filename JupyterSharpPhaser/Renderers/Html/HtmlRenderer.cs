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
                    WriteHeaderStart();
                    WriteCssPart();
                    WriteHeaderEnd();

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

        protected virtual void WriteHeaderStart()
        {
            WriteLine("<!DOCTYPE html>");
            WriteLine("<html>");
            var beforeHeader = @"<head>
    <meta charset=""utf-8"" />
    <title>01-Python Crash Course</title>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/require.js/2.1.10/require.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js""></script>

    <style type=""text/css"">";
            WriteLine(beforeHeader);

        }

        protected virtual void WriteCssPart()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "JupyterSharpPhaser.Resources.JupyterDefaultStyle.css";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                WriteLine(result);
            }
        }

        protected virtual void WriteHeaderEnd()
        {
            var afterHeader = @"<!-- Custom stylesheet, it must be in the same directory as the html file -->
    <link rel=""stylesheet"" href=""custom.css"">

    <!-- Loading mathjax macro -->
    <!-- Load mathjax -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.1/MathJax.js?config=TeX-AMS_HTML""></script>
    <!-- MathJax configuration -->
    <script type=""text/x-mathjax-config"">
        MathJax.Hub.Config({
        tex2jax: {
        inlineMath: [ ['$','$'], [""\\("",""\\)""] ],
        displayMath: [ ['$$','$$'], [""\\["",""\\]""] ],
        processEscapes: true,
        processEnvironments: true
        },
        // Center justify equations in code and markdown cells. Elsewhere
        // we use CSS to left justify single line equations in code cells.
        displayAlign: 'center',
        ""HTML-CSS"": {
        styles: {'.MathJax_Display': {""margin"": 0}},
        linebreaks: { automatic: true }
        }
        });
    </script>
    <!-- End of mathjax configuration -->
</head>";

            WriteLine(afterHeader);
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