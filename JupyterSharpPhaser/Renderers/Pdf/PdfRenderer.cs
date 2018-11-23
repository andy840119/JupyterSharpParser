using System.IO;
using JupyterSharpPhaser.Renderers.Html;
using JupyterSharpPhaser.Syntax;
using SelectPdf;

namespace JupyterSharpPhaser.Renderers.Pdf
{
    public class PdfRenderer : RendererBase
    {
        private readonly HtmlToPdf _htmlToPdf;
        private readonly Stream _stream;

        public PdfRenderer(Stream stream, HtmlToPdf htmlToPdf = null)
        {
            _stream = stream;
            _htmlToPdf = htmlToPdf;
        }

        /// <summary>
        /// Renders the specified jupyter object (returns the <see cref="Writer"/> as a render object).
        /// </summary>
        /// <param name="jupyterObject">The jupyter object.</param>
        /// <returns></returns>
        public override object Render(IJupyterObject jupyterObject)
        {
            //using HtmlRenderer to renderer Html file
            var writer = new StringWriter();
            var renderer = new HtmlRenderer(writer)
            {
                RendererHeaderAndFooter = true
            };
            renderer.Render(jupyterObject);
            writer.Flush();
            var htmlString = writer.ToString();

            //Conver to pdf
            var convertor = _htmlToPdf ?? CreateDefauleHtmlToPdf();

            var pdfFile = convertor.ConvertHtmlString(htmlString);

            //save
            pdfFile.Save(_stream);

            //return stream
            return _stream;
        }

        protected virtual HtmlToPdf CreateDefauleHtmlToPdf()
        {
            var newConvertor = new HtmlToPdf();
            newConvertor.Options.MarginTop = 30;
            newConvertor.Options.MarginBottom = 30;
            return newConvertor;
        }
    }
}