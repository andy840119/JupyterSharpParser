using System.IO;

namespace JupyterSharpPhaser.Test.Helpers
{
    public class JupyterDocumentHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileStringByFileName(string fileName)
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("JupyterDocument/" + fileName))
            {
                // Read the stream to a string, and write the string to the console.
                var lines = sr.ReadToEnd();
                return lines;
            }
        }
    }
}