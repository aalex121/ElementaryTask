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
        #region Constants
        private const int MIN_ARGS_LENGTH = 2;
        private const int MAX_ARGS_LENGTH = 3;
        #endregion

        public static void Run(string[] args)
        {
            if (args.Length < MIN_ARGS_LENGTH)
            {
                UI.ShowMessage(MessageTypes.Help);
                return;
            }

            string filePath = args[0];
            string searchLine = args[1];
            
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
        
        private static void CountLineEntries(string path, string line)
        {
            TxtFileParser parser = new TxtFileParser(path);

            if (parser.CurrentFileProcessor == null)
            {
                UI.ShowMessage(MessageTypes.FileNotFound);
                return;
            }

            int entryCount = parser.CountLineEntries(line);
            UI.ShowMessage(MessageTypes.LineEntryCount, entryCount.ToString());
        }

        private static void ChangeLines(string path, string searchLine, string newLine)
        {
            TxtFileParser parser = new TxtFileParser(path);

            if (parser.CurrentFileProcessor == null)
            {
                UI.ShowMessage(MessageTypes.FileNotFound);
                return;
            }

            if (parser.ReplaceLine(searchLine, newLine))
            {
                UI.ShowFileContent(parser);
            }
            else
            {
                UI.ShowMessage(MessageTypes.LineNotFound, newLine);
            }
        }
    }
}
