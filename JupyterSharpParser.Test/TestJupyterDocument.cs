using System.Linq;
using JupyterSharpParser.Syntax.Cell;
using JupyterSharpParser.Syntax.Cell.Output;
using JupyterSharpParser.Test.Helpers;
using Markdig.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace JupyterSharpParser.Test
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
            var document = Jupyter.Parse(jupyterText);
            var markdownCell = document.Cells.FirstOrDefault() as MarkdownCell;

            Assert.AreEqual(CellType.Markdown, markdownCell.CellType); //Type
            Assert.AreEqual(typeof(JObject), markdownCell.Metadata.GetType()); //Metadata
            Assert.AreEqual(4, markdownCell.MarkdownDocument.Count); //Text
            Assert.IsTrue(markdownCell.MarkdownDocument.LastOrDefault() is HeadingBlock); //Text
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
            var document = Jupyter.Parse(jupyterText);
            var kernelSpec = document.Metadata.KernelSpec;
            var kernelInfo = document.Metadata.KernelInfo;
            var languageInfo = document.Metadata.LanguageInfo;

            //Spec
            Assert.AreEqual("Python 3", kernelSpec.DisplayName);
            Assert.AreEqual("python", kernelSpec.Language);
            Assert.AreEqual("python3", kernelSpec.Name);

            //KernelInfo
            Assert.AreEqual((object) null, kernelInfo.Name);

            //LanguageInfo
            Assert.AreEqual("ipython", languageInfo.CodemirrorMode.Name);
            Assert.AreEqual("3", languageInfo.CodemirrorMode.Version);

            Assert.AreEqual(".py", languageInfo.FileExtension);
            Assert.AreEqual("text/x-python", languageInfo.MimeType);
            Assert.AreEqual("python", languageInfo.Name);
            Assert.AreEqual("python", languageInfo.NbconvertExporter);
            Assert.AreEqual("ipython3", languageInfo.PygmentsLexer);
            Assert.AreEqual("3.6.2", languageInfo.Version);

            //NbFormat
            Assert.AreEqual(4, document.NbFormat);

            //NbFormatMinor
            Assert.AreEqual(1, document.NbFormatMinor);
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
            var document = Jupyter.Parse(jupyterText);
            var codeCell = document.Cells.FirstOrDefault() as CodeCell;

            Assert.AreEqual(CellType.Code, codeCell.CellType); //Type
            Assert.AreEqual(7, codeCell.ExecutionCount); //ExecutionCount
            Assert.AreEqual(false, codeCell.MetaData.Collapsed); //MetaData
            Assert.AreEqual(false, codeCell.MetaData.AutoScroll); //MetaData
            Assert.AreEqual(1, codeCell.Source.Count()); //Source
            Assert.AreEqual("1 * 3", codeCell.Source.LastOrDefault()); //Source
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
            var document = Jupyter.Parse(jupyterText);
            var codeCell = document.Cells.FirstOrDefault() as CodeCell;
            var streamOutput = codeCell.Outputs.FirstOrDefault() as StreamOutput;

            Assert.AreEqual(OutputType.Stream, streamOutput.OutputType); //Type
            Assert.AreEqual("stdout", streamOutput.Name); //Name
            Assert.AreEqual(1, streamOutput.Text.Count()); //Text
            Assert.AreEqual("hello", streamOutput.Text.LastOrDefault()); //Text
        }

        [TestMethod]
        public void TestCodeCellDisplayDataOutput()
        {
            var jupyterText = @"{
  ""cells"": [
    {
        ""cell_type"": ""code"",
        ""execution_count"": 7,
        ""metadata"": {
            ""scrolled"": true,
            ""collapsed"": false
        },
        ""outputs"": [
        {
            ""output_type"": ""display_data"",
            ""data"": {
                ""image/png"": ""iVBORw0KGgoAAAANSUhEUgAAAT4AAAIXCAYAAAAFczJTAAAABHNCSVQICAgIfAhkiAAAAAlwSFlz\nAAALEgAACxIB0t1..."",
                ""text/plain"": ""<matplotlib.figure.Figure at 0x7f0ce3512320>""
            },
            ""metadata"": {}
        }
        ],
        ""source"": [
        ""1 * 3""
        ]
    }]
}";
            var document = Jupyter.Parse(jupyterText);
            var codeCell = document.Cells.FirstOrDefault() as CodeCell;
            var displayDataOutput = codeCell.Outputs.FirstOrDefault() as DisplayDataOutput;

            Assert.AreEqual(OutputType.DisplayData, displayDataOutput.OutputType); //Type
            Assert.AreEqual(
                "iVBORw0KGgoAAAANSUhEUgAAAT4AAAIXCAYAAAAFczJTAAAABHNCSVQICAgIfAhkiAAAAAlwSFlz\nAAALEgAACxIB0t1...",
                displayDataOutput.Data.ImageData); //Data
            Assert.AreEqual("<matplotlib.figure.Figure at 0x7f0ce3512320>",
                displayDataOutput.Data.TextPlain.Text); //Data
            Assert.AreEqual(null, displayDataOutput.MetaData.Image); //MetaData
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
                ""text/plain"": ""Hello""
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
            var document = Jupyter.Parse(jupyterText);
            var codeCell = document.Cells.FirstOrDefault() as CodeCell;
            var codeOutput = codeCell.Outputs.FirstOrDefault() as ExecuteResultOutput;

            Assert.AreEqual(OutputType.ExecuteResult, codeOutput.OutputType); //Type
            Assert.AreEqual(7, codeOutput.ExecutionCount); //ExecutionCount
            Assert.AreEqual(null, codeOutput.MetaData.Image); //MetaData
            Assert.AreEqual("Hello", codeOutput.Data.TextPlain.Text); //Data
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

            Assert.AreEqual(OutputType.Error, errorOutput.OutputType); //Type
            Assert.AreEqual("TypeError", errorOutput.Ename); //Ename
            Assert.AreEqual("'tuple' object does not support item assignment", errorOutput.Evalue); //Evalue
            Assert.AreEqual(4, errorOutput.Traceback.Count()); //Data
            Assert.AreEqual(true,
                errorOutput.Traceback.LastOrDefault()
                    .Contains("'tuple' object does not support item assignment")); //Source
        }

        #endregion

        #region File

        [TestMethod]
        public void TestReadingJpyterDocument1()
        {
            var jupyterText = JupyterDocumentHelper.GetFileStringByFileName("Discover Sentiments in Tweets.ipynb");
            var document = Jupyter.Parse(jupyterText);

            Assert.IsTrue(document != null); //Phase success
        }

        [TestMethod]
        public void TestReadingJpyterDocument2()
        {
            var jupyterText = JupyterDocumentHelper.GetFileStringByFileName("01-Python Crash Course.ipynb");
            var document = Jupyter.Parse(jupyterText);

            Assert.IsTrue(document != null); //Phase success
        }

        #endregion
    }
}