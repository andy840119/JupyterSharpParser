using System;
using System.Collections.Generic;
using System.Text;
using JupyterSharpPhaser.Syntax;
using JupyterSharpPhaser.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JupyterSharpPhaser.Test
{
    public class TestJupyterJsonRendrer
    {
        #region Utilities

        protected string ConvertDocumentToJson(JupyterDocument document)
        {
            //TODO : Real convert
            return "";
        }

        #endregion

        #region File

        [TestMethod]
        public void TestReadingJpyterDocument1()
        {
            var jupyterText = JupyterDocumentHelper.GetFileStringByFileName("Discover Sentiments in Tweets.ipynb");
            var document = Jupyter.Parse(jupyterText);

            //convert to json
            var documentJson = ConvertDocumentToJson(document);

            //convert to document again
            var document2 = Jupyter.Parse(documentJson);

            //Two class's property should be equal
            Assert.IsTrue(ClassCompareHelper.PublicInstancePropertiesEqual(document, document2));
        }

        #endregion
    }
}
