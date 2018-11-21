using JupyterSharpPhaser.Renderers.Html;
using JupyterSharpPhaser.Syntax;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Pdf
{
    public class PdfRenderer : RendererBase
    {
        private readonly Stream _stream;
        private readonly HtmlToPdf _htmlToPdf;

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
            var renderer = new HtmlRenderer(writer);
            renderer.Render(jupyterObject);
            writer.Flush();
            string htmlString = writer.ToString();

            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(htmlString);
            PDF.SaveAs("MyPdf.pdf");
            /*
            //Conver to pdf
            HtmlToPdf convertor = _htmlToPdf ?? CreateDefauleHtmlToPdf();
            var pdfFile = convertor.ConvertHtmlString(htmlString);
            //save
            pdfFile.Save(_stream);
            */

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