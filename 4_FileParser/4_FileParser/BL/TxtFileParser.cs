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
            CurrentFileProcessor = DataProviderFactory.GetFileProcessor(this);
        }

        public TxtFileParser(string inputFilePath, DataProviderTypes inputDataProviderType)
        {
            FilePath = inputFilePath;
            DataProviderType = inputDataProviderType;
            CurrentFileProcessor = DataProviderFactory.GetFileProcessor(this);
        }

        public string FilePath { get; private set; }

        public DataProviderTypes DataProviderType { get; private set; }

        public ITxtFileProcessor CurrentFileProcessor { get; private set; }

        public int CountLineEntries(string searchedLine)
        {
            int result = 0;

            if (CurrentFileProcessor != null)
            {
                result = CurrentFileProcessor.CountLineEntries(searchedLine);
            }

            return result;
        }

        public bool ReplaceLine(string searchedLine, string newLineText)
        {
            if (CurrentFileProcessor == null)
            {
                return false;
            }

            bool isSuccessfull = false;

            if (CurrentFileProcessor.IsFileLarge())
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
            string[] source = CurrentFileProcessor.ReadAllFile();
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
                CurrentFileProcessor.OverwriteAllFile(source);
            }

            return areChangesMade;
        }

        private bool ReplaceLineInLargeFile(string searchedLine, string newLineText)
        {
            bool areChangesMade = CurrentFileProcessor.OverWriteLineByLine(searchedLine, newLineText);

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
    }
}
