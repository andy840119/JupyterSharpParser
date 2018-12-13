using JupyterSharpPhaser.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JupyterSharpPhaser.Test
{
    [TestClass]
    public class TestJupyterPdfRenderer
    {
        #region Utilities

        protected void ConvertDocumentToHtmlFile(JupyterDocument document, string fileName, bool openFile = false)
        {
            using (var writer = FileHelper.CreateStream(fileName))
            {
                var renderer = new PdfRenderer(writer);
                renderer.Render(document);
            }

            if (openFile)
                FileHelper.ProcessFile(fileName);
        }

        #endregion

        #region File

        [TestMethod]
        public void TestReadingJpyterDocument1()
        {
            var jupyterText = JupyterDocumentHelper.GetFileStringByFileName("Discover Sentiments in Tweets.ipynb");
            var document = Jupyter.Parse(jupyterText);

            //convert to html and open
            ConvertDocumentToHtmlFile(document, "Discover Sentiments in Tweets.pdf", false);
        }

        [TestMethod]
        public void TestReadingJpyterDocument2()
        {
            var jupyterText = JupyterDocumentHelper.GetFileStringByFileName("01-Python Crash Course.ipynb");
            var document = Jupyter.Parse(jupyterText);

            //convert to html and open
            ConvertDocumentToHtmlFile(document, "01-Python Crash Course.pdf", false);
        }

        #endregion
    }
}