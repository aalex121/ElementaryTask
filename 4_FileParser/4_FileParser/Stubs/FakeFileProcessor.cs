﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    public class FakeFileProcessor : ITxtFileProcessor
    {

        #region Constants
        public const string VALID_FAKE_FILE = "fake.txt";
        #endregion

        public FakeFileProcessor(TxtFileParser parser)
        {
            _parser = parser;
            _filePath = parser.FilePath;
            LargeFile = false;

            Data = new string[]
            {
                "Cats",
                "Dogs",
                "Cats",
                "Cats",
                "Dogs"
            };
        }

        public string[] Data { get; set; }

        public bool LargeFile { get; set; }

        public bool CheckFileExistance()
        {
            if (_filePath == VALID_FAKE_FILE)
            {
                return true;
            }

            return false;
        }

        public int CountLineEntries(string searchedLine)
        {
            if (Data == null)
            {
                return 0;
            }

            int entriesCount = 0;

            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == searchedLine)
                {
                    entriesCount++;
                }
            }

            return entriesCount;
        }

        public bool IsFileLarge()
        {
            return LargeFile;
        }

        public void OverwriteAllFile(string[] source)
        {
            Data = (string[])source.Clone();
        }

        public bool OverWriteLineByLine(string searchedLine, string newLineText)
        {
            bool areChangesMade = false;

            string currentLine = string.Empty;

            for (int i = 0; i < Data.Length; i++)
            {
                string parsedLine = _parser.ParseLine(Data[i], searchedLine, newLineText);

                if (Data[i] != currentLine)
                {
                    Data[i] = parsedLine;
                    areChangesMade = true;                    
                }                
            }

            return areChangesMade;
        }

        public string[] ReadAllFile()
        {
            return (string[])Data.Clone();
        }

        private TxtFileParser _parser;
        private string _filePath;        
    }
}
