using System.Diagnostics;
using System.IO;
using System.Text;

namespace JupyterSharpPhaser.Test.Helpers
{
    public class FileHelper
    {
        private static readonly string _directoryName = "Output";

        /// <summary>
        /// Create file stream
        /// </summary>
        /// <param name="saveFileName"></param>
        /// <returns></returns>
        public static StreamWriter CreateStreamWriter(string saveFileName)
        {
            //create dictionary if not exist
            if (!Directory.Exists(_directoryName))
                Directory.CreateDirectory(_directoryName);

            //Delete file if exist
            var fileFullPath = _directoryName + "/" + saveFileName;
            if (File.Exists(fileFullPath))
                File.Delete(fileFullPath);

            //create stream writer
            return new StreamWriter(File.Open(fileFullPath, FileMode.Create), Encoding.UTF8);
        }

        /// <summary>
        /// Create file stream
        /// </summary>
        /// <param name="saveFileName"></param>
        /// <returns></returns>
        public static Stream CreateStream(string saveFileName)
        {
            //create dictionary if not exist
            if (!Directory.Exists(_directoryName))
                Directory.CreateDirectory(_directoryName);

            //Delete file if exist
            var fileFullPath = Path.Combine(_directoryName, saveFileName);
            if (File.Exists(fileFullPath))
                File.Delete(fileFullPath);

            //create stream writer
            return new FileStream(fileFullPath, FileMode.CreateNew, FileAccess.Write);
        }

        /// <summary>
        /// Open file if exist
        /// </summary>
        /// <param name="fileName"></param>
        public static void ProcessFile(string fileName)
        {
            //create dictionary if not exist
            if (!Directory.Exists(_directoryName))
                return;

            //Delete file if exist
            var fileFullPath = _directoryName + "/" + fileName;

            //https://stackoverflow.com/questions/11365984/c-sharp-open-file-with-default-application-and-parameters
            Process.Start("explorer.exe ", fileFullPath);
        }
    }
}