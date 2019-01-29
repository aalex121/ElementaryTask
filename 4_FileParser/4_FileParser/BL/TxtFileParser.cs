using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    public class TxtFileParser
    {
        #region Constants
        public const string VALID_FILE_EXTENSION = ".txt";
        private const string TEMP_FILE_NAME = "TempTxtFile.txt";
        private const string NO_FILE_MESSAGE = "No .txt file";        
        #endregion

        public TxtFileParser(string inputFilePath)
        {   
            FilePath = inputFilePath;
            DataProviderType = DataProviderTypes.Real;
        }

        public TxtFileParser(string inputFilePath, DataProviderTypes inputDataProviderType)
        {
            FilePath = inputFilePath;
            DataProviderType = inputDataProviderType;
        }

        public string FilePath { get; private set; }

        public DataProviderTypes DataProviderType { get; private set; }

        public ITxtFileProcessor CurrentFileProcessor { get; private set; }

        public int CountLineEntries(string searchedLine)
        {
            ITxtFileProcessor fileProcessor = GetFileProcessor();
            int result = 0;

            if (fileProcessor != null)
            {
                result = fileProcessor.CountLineEntries(searchedLine);
            }

            return result;
        }

        public bool ReplaceLine(string searchedLine, string newLineText)
        {
            ITxtFileProcessor fileProcessor = GetFileProcessor();

            if (fileProcessor == null)
            {
                return false;
            }

            bool isSuccessfull = false;

            if (fileProcessor.IsFileLarge())
            {
                isSuccessfull = ReplaceLineInLargeFile(searchedLine, newLineText, fileProcessor);
            }
            else
            {
                isSuccessfull = ReplaceLineInSmallFile(searchedLine, newLineText, fileProcessor);
            }

            return isSuccessfull;
        }

        private bool ReplaceLineInSmallFile(string searchedLine, string newLineText,
            ITxtFileProcessor fileProcessor)
        {
            string[] source = fileProcessor.ReadAllFile();
            bool areChangesMade = false;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Equals(searchedLine))
                {
                    source[i] = newLineText;
                    areChangesMade = true;
                }
            }

            if (areChangesMade)
            {
                fileProcessor.OverwriteAllFile(source);
            }

            return areChangesMade;
        }

        private bool ReplaceLineInLargeFile(string searchedLine, string newLineText,
            ITxtFileProcessor fileProcessor)
        {
            bool areChangesMade = fileProcessor.OverWriteLineByLine(searchedLine, newLineText);

            return areChangesMade;
        }

        public string ParseLine(string inputLine, string searchedLine, string newLineText)
        {
            if (inputLine == searchedLine)
            {
                inputLine = newLineText;
            }

            return inputLine;
        }

        public ITxtFileProcessor GetFileProcessor()
        {
            CurrentFileProcessor = DataProviderFactory.GetFileProcessor(this);
            return CurrentFileProcessor;
        }
    }
}
