using DinkToPdf;
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

            var converter = new BasicConverter(new PdfTools());

            //Conver to pdf
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent =@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut                               odio viverra, molestie lectus nec, venenatis turpis.",
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            byte[] pdf = converter.Convert(doc);

            //save
            _stream.Write(pdf,0,pdf.Length);

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