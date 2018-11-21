using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
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

            /*
            //Conver to pdf
            HtmlToPdf convertor = _htmlToPdf ?? CreateDefauleHtmlToPdf();
            var pdfFile = convertor.ConvertHtmlString(htmlString);
            //save
            pdfFile.Save(_stream);
            */

            var pdf = GetPDF(htmlString);

            _stream.Write(pdf, 0 ,pdf.Length);

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

        public byte[] GetPDF(string pHTML) {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HtmlWorker htmlWorker = new HtmlWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }
    }
}