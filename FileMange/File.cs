using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYH.BlukInsertTest.FileMange
{
    public class File
    {
        public static string strFilePath = @"D:\学习\ASP.NET\QYH.BlukInsertTest";

        public static async void WriteTextAsync(string text, string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(strFilePath + @"\" + fileName + ".txt"))
            {
                await outputFile.WriteAsync(text);
            }
        }

        public static void AppendText(string text, string fileName)
        {
            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(strFilePath + @"\" + fileName + ".txt",true))
            {
                outputFile.WriteLine(text);
            }
        }
    }
}
