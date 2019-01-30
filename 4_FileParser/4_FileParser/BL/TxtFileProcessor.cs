using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    public class TxtFileProcessor : ITxtFileProcessor
    {
        #region Constants
        public const string VALID_FILE_EXTENSION = ".txt";
        private const int LARGE_FILE_SIZE = 50000000;        
        #endregion

        public TxtFileProcessor(TxtFileParser parser)
        {
            _parser = parser;
            _filePath = Path.GetFullPath(parser.FilePath);
        }               

        public int CountLineEntries(string searchedLine)
        {
            int entriesCount = 0;

            using (StreamReader file = new StreamReader(_filePath))
            {
                string currentLine = null;

                do
                {
                    currentLine = file.ReadLine();

                    if (currentLine != null)
                    {
                        if (currentLine.Equals(searchedLine))
                        {
                            entriesCount++;
                        }
                    }

                } while (currentLine != null);
            }

            return entriesCount;
        }

        public string[] ReadAllFile()
        {
            return File.ReadAllLines(_parser.FilePath);            
        }

        public void OverwriteAllFile(string[] source)
        {
            File.WriteAllLines(_filePath, source);
        }

        public bool OverWriteLineByLine(string searchedLine, string newLineText)
        {
            bool areChangesMade = false;
            string currentLine = string.Empty;
            string tempFilePath = Path.GetTempFileName();

            using (StreamReader source = new StreamReader(_filePath))
            {
                using (StreamWriter tempFile = new StreamWriter(tempFilePath))
                {
                    while ((currentLine = source.ReadLine()) != null)
                    {
                        string parsedLine = _parser.ParseLine(currentLine, searchedLine, newLineText);

                        if (parsedLine != currentLine)
                        {
                            currentLine = parsedLine;
                            areChangesMade = true;
                        } 

                        tempFile.WriteLine(currentLine);
                    }
                }
            }

            File.Delete(_filePath);
            File.Move(tempFilePath, _filePath);

            return areChangesMade;
        }

        public bool IsFileLarge()
        {
            FileInfo info = new FileInfo(_filePath);
            return info.Length > LARGE_FILE_SIZE;
        }

        public bool CheckFileExistance()
        {            
            return File.Exists(_filePath);
        }

        private string _filePath;        
        private readonly TxtFileParser _parser;
    }
}
