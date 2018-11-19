using JupyterSharpPhaser.Syntax.Cell;
using JupyterSharpPhaser.Syntax.Cell.Output;
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
            var jupyterText = @"{
  ""cells"": [
    {
   ""cell_type"": ""code"",
   ""execution_count"": 22,
   ""metadata"": {},
   ""outputs"": [
    {
     ""name"": ""stdout"",
     ""output_type"": ""stream"",
     ""text"": [
      ""hello\n""
     ]
    }
   ],
   ""source"": [
    ""print(x)""
   ]
  }
 ]
}";
            var documentText = Jupyter.Parse(jupyterText);
            var codeCell = documentText.Cells.FirstOrDefault() as CodeCell;
            var streamOutput = codeCell.Outputs.FirstOrDefault() as StreamOutput;

            Assert.AreEqual(OutputType.Stream, streamOutput.OutputType);//Type
            Assert.AreEqual("stdout", streamOutput.Name);//Name
            Assert.AreEqual(1, streamOutput.Text.Count());//Text
            Assert.AreEqual("hello\n", streamOutput.Text.LastOrDefault());//Text
        }

        [TestMethod]
        public void TestCodeCellDisplayDataOutput()
        {
        }

        [TestMethod]
        public void TestCodeCellExecuteOutput()
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
            var codeOutput = codeCell.Outputs.FirstOrDefault() as ExecuteResultOutput;

            Assert.AreEqual(OutputType.ExecuteResult, codeOutput.OutputType);//Type
            Assert.AreEqual(7, codeOutput.ExecutionCount);//ExecutionCount
            Assert.AreEqual(null, codeOutput.MetaData.Image);//MetaData
            Assert.AreEqual(1, codeOutput.Data.Text.Count());//Data
            Assert.AreEqual("3", codeOutput.Data.Text.LastOrDefault());//Source
        }

        [TestMethod]
        public void TestCodeCellErrorOutput()
        {
            var jupyterText = @"{
  ""cells"": [
    {
   ""cell_type"": ""code"",
   ""execution_count"": 44,
   ""metadata"": {},
   ""outputs"": [
    {
     ""ename"": ""TypeError"",
     ""evalue"": ""'tuple' object does not support item assignment"",
     ""output_type"": ""error"",
     ""traceback"": [
      ""\u001b[0;31m---------------------------------------------------------------------------\u001b[0m"",
      ""\u001b[0;31mTypeError\u001b[0m                                 Traceback (most recent call last)"",
      ""\u001b[0;32m<ipython-input-44-97e4e33b36c2>\u001b[0m in \u001b[0;36m<module>\u001b[0;34m()\u001b[0m\n\u001b[0;32m----> 1\u001b[0;31m \u001b[0mt\u001b[0m\u001b[0;34m[\u001b[0m\u001b[0;36m0\u001b[0m\u001b[0;34m]\u001b[0m \u001b[0;34m=\u001b[0m \u001b[0;34m'NEW'\u001b[0m\u001b[0;34m\u001b[0m\u001b[0m\n\u001b[0m"",
      ""\u001b[0;31mTypeError\u001b[0m: 'tuple' object does not support item assignment""
     ]
    }
   ],
   ""source"": [
    ""t[0] = 'NEW'""
   ]
  }
 ]
}";
            var documentText = Jupyter.Parse(jupyterText);
            var codeCell = documentText.Cells.FirstOrDefault() as CodeCell;
            var errorOutput = codeCell.Outputs.FirstOrDefault() as ErrorOutput;

            Assert.AreEqual(OutputType.Error, errorOutput.OutputType);//Type
            Assert.AreEqual("TypeError", errorOutput.Ename);//Ename
            Assert.AreEqual("'tuple' object does not support item assignment", errorOutput.Evalue);//Evalue
            Assert.AreEqual(4, errorOutput.Traceback.Count());//Data
            Assert.AreEqual(true, errorOutput.Traceback.LastOrDefault().Contains("'tuple' object does not support item assignment"));//Source
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
            var jupyterText = @"{
  ""metadata"": {
  ""kernelspec"": {
   ""display_name"": ""Python 3"",
   ""language"": ""python"",
   ""name"": ""python3""
  },
  ""language_info"": {
   ""codemirror_mode"": {
    ""name"": ""ipython"",
    ""version"": 3
   },
   ""file_extension"": "".py"",
   ""mimetype"": ""text/x-python"",
   ""name"": ""python"",
   ""nbconvert_exporter"": ""python"",
   ""pygments_lexer"": ""ipython3"",
   ""version"": ""3.6.2""
  }
 },
 ""nbformat"": 4,
 ""nbformat_minor"": 1
}";
            var documentText = Jupyter.Parse(jupyterText);

            Assert.AreEqual(OutputType.Error, documentText.Metadata.ke);//Type
            Assert.AreEqual("TypeError", errorOutput.Ename);//Ename
            Assert.AreEqual("'tuple' object does not support item assignment", errorOutput.Evalue);//Evalue
            Assert.AreEqual(4, errorOutput.Traceback.Count());//Data
            Assert.AreEqual(true, errorOutput.Traceback.LastOrDefault().Contains("'tuple' object does not support item assignment"));//Source
        }

        #endregion
    }
}
