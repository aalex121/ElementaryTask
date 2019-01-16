using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    static class Application
    {
        const int MIN_ARGS_LENGTH = 2;
        const int MAX_ARGS_LENGTH = 3;        

        public static void Run(string[] args)
        {
            if (args.Length < MIN_ARGS_LENGTH)
            {
                UI.ShowMessage(MessageTypes.Help);
                return;
            }

            string filePath = Path.GetFullPath(args[0]);                    

            string searchLine = args[1];

            if (ValidateFilePathInput(filePath))
            {
                if (args.Length >= MAX_ARGS_LENGTH)
                {
                    string newLine = args[2];
                    ChangeLines(filePath, searchLine, newLine);
                }
                else
                {
                    CountLineEntries(filePath, searchLine);
                }
            }
            else
            {
                UI.ShowMessage(MessageTypes.FileNotFound);
            }
            
        }

        private static bool ValidateFilePathInput(string path)
        {
            bool isValid = false;

            if (File.Exists(path))
            {
                isValid = Path.GetExtension(path) == TxtFileParser.VALID_FILE_EXTENSION;                              
            }

            return isValid;
        }

        private static void CountLineEntries(string path, string line)
        {
            TxtFileParser parser = new TxtFileParser(path);
            int entryCount = parser.CountLineEntries(line);

            UI.ShowMessage(MessageTypes.LineEntryCount, entryCount.ToString());
        }

        private static void ChangeLines(string path, string searchLine, string newLine)
        {
            TxtFileParser parser = new TxtFileParser(path);

            if (parser.ReplaceLine(searchLine, newLine))
            {
                UI.ShowFileContent(path);
            }
            else
            {
                UI.ShowMessage(MessageTypes.LineNotFound, newLine);
            }
        }
    }
}
