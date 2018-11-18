using JupyterSharpPhaser.Syntax.Cell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace JupyterSharpPhaser.Test
{
    [TestClass]
    public class TestJupyterDocument
    {
        #region Markdown Cell

        [TestMethod]
        public void TestMarkdownCell()
        {
            var jupyterText = @"{
  ""cells"": [
    {
      ""cell_type"": ""markdown"",
      ""metadata"": {
        
      },
      ""source"": [
        ""___\n"",
        ""\n"",
        ""<a href='http://www.pieriandata.com'> <img src='../Pierian_Data_Logo.png' /></a>\n"",
        ""___\n"",
        ""# Python Crash Course\n"",
      ]
    }]
}";
            var documentText = Jupyter.Parse(jupyterText);
            var markdownCell = documentText.Cells.FirstOrDefault() as MarkdownCell;

            Assert.AreEqual(CellType.Markdown, markdownCell.CellType);//Type
            Assert.AreEqual(typeof(Newtonsoft.Json.Linq.JObject), markdownCell.Metadata.GetType());//Metadata
            Assert.AreEqual(5, markdownCell.Source.Count);//Count
            Assert.AreEqual("# Python Crash Course\n", markdownCell.Source.LastOrDefault());//Text
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
