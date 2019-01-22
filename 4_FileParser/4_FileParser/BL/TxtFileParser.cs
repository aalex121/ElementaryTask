using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    class TxtFileParser
    {
        #region Constants
        public const string VALID_FILE_EXTENSION = ".txt";
        private const string TEMP_FILE_NAME = "TempTxtFile.txt";
        private const string NO_FILE_MESSAGE = "No .txt file";
        private const int LARGE_FILE_SIZE = 50000000;
        #endregion

        public TxtFileParser(string inputFilePath)
        {
            if (!File.Exists(inputFilePath) ||
                    Path.GetExtension(inputFilePath) != VALID_FILE_EXTENSION)
            {
                throw new FileNotFoundException(NO_FILE_MESSAGE, inputFilePath);
            }
            
            _filePath = inputFilePath;
            _isFileLarge = IsFileLarge(inputFilePath);
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

        public bool ReplaceLine(string searchedLine, string newLineText)
        {
            bool isSuccessfull = false;

            if (_isFileLarge)
            {
                isSuccessfull = ReplaceLineInLargeFile(searchedLine, newLineText);
            }
            else
            {
                isSuccessfull = ReplaceLineInSmallFile(searchedLine, newLineText);
            }

            return isSuccessfull;
        }

        private bool ReplaceLineInSmallFile(string searchedLine, string newLineText)
        {
            int changesCount = 0;

            string[] source = File.ReadAllLines(_filePath);

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Equals(searchedLine))
                {
                    source[i] = newLineText;
                    changesCount++;
                }
            }

            File.WriteAllLines(_filePath, source);

            return changesCount > 0;
        }

        private bool ReplaceLineInLargeFile(string searchedLine, string newLineText)
        {
            int changesCount = 0;

            string currentLine = string.Empty;

            string tempFilePath = Path.Combine(Environment.CurrentDirectory, TEMP_FILE_NAME);

            using (StreamReader source = new StreamReader(_filePath))
            {
                using (StreamWriter tempFile = new StreamWriter(tempFilePath))
                {
                    while ((currentLine = source.ReadLine()) != null)
                    {
                        if (currentLine.Equals(searchedLine))
                        {
                            tempFile.WriteLine(newLineText);
                            changesCount++;
                        }
                        else
                        {
                            tempFile.WriteLine(currentLine);
                        }
                    }
                }
            }
            
            File.Delete(_filePath);
            File.Move(tempFilePath, _filePath);

            return changesCount > 0;
        }

        private static bool IsFileLarge(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return info.Length > LARGE_FILE_SIZE;            
        }

        private string _filePath;
        private bool _isFileLarge;
    }
}
