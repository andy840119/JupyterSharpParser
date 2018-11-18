using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JupyterSharpPhaser.Test
{
    [TestClass]
    public class TestJupyterDocument
    {
        #region Markdown Cell

        [TestMethod]
        public void TestMarkdownCell()
        {
            var documentText = Jupyter.Parse("");
        }

        #endregion

        #region Code Cell

        [TestMethod]
        public void TestCodeCell()
        {
        }

        [TestMethod]
        public void TestCodeCellStreamOutput()
        {
        }

        [TestMethod]
        public void TestCodeCellDisplayDataOutput()
        {
        }

        [TestMethod]
        public void TestCodeCellExecuteOutput()
        {
        }

        [TestMethod]
        public void TestCodeCellErrorOutput()
        {
        }

        #endregion

        #region RawCell

        [TestMethod]
        public void TestRawCell()
        {

        }

        #endregion

        #region MetaData

        [TestMethod]
        public void TestMetadata()
        {

        }

        #endregion
    }
}
