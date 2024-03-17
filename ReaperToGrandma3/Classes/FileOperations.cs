using System.Collections.Generic;
using System.Linq;

namespace ReaperToGrandma3.Classes
{
    public class FileOperations
    {
        public List<string> ListCsvFilesInRootFolder()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            var files = System.IO.Directory.GetFiles(strWorkPath, "*.csv").ToList();

            return files;

        }
    }
}
