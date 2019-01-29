using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_FileParser
{
    public interface ITxtFileProcessor
    {
        int CountLineEntries(string searchedLine);
        string[] ReadAllFile();
        void OverwriteAllFile(string[] source);
        bool OverWriteLineByLine(string searchedLine, string newLineText);
        bool IsFileLarge();
        bool CheckFileExistance();
    }
}
