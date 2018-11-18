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
            var jupyterText = @"{
  ""cells"": [
    {
        ""cell_type"": ""code"",
        ""execution_count"": 7,
        ""metadata"": {},
        ""outputs"": [
        {
            ""data"": {
                ""text/plain"": [
                ""3""
                ]
            },
            ""execution_count"": 7,
            ""metadata"": {},
            ""output_type"": ""execute_result""
        }
        ],
        ""source"": [
        ""1 * 3""
        ]
    }]
}";
            var documentText = Jupyter.Parse(jupyterText);
            var codeCell = documentText.Cells.FirstOrDefault() as CodeCell;

            Assert.AreEqual(CellType.Code, codeCell.CellType);//Type
            Assert.AreEqual(7, codeCell.ExecutionCount);//ExecutionCount
            Assert.AreEqual(false, codeCell.MetaData.Collapsed);//MetaData
            Assert.AreEqual(false, codeCell.MetaData.AutoScroll);//MetaData
            Assert.AreEqual(1, codeCell.Source.Count());//Source
            Assert.AreEqual("1 * 3", codeCell.Source.LastOrDefault());//Source
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
