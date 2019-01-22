using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4_FileParser
{
    static class UI
    {
        #region Constants
        private const string HELP_MESSAGE = "Usage: <File path> <Searched line> [New line]";
        private const string FILE_NOT_FOUND = "Txt file not found!";
        private const string LINE_ENTRY_COUNT = "Line entries found";
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key...";
        private const string LINE_NOT_FOUND = "Searched line does not exist!";
        #endregion

        public static void ShowMessage(MessageTypes messageType, params string[] moreInfo)
        {
            string message = string.Empty;

            switch (messageType)
            {                
                case MessageTypes.Help:
                    message = HELP_MESSAGE;
                    break;
                case MessageTypes.FileNotFound:
                    message = FILE_NOT_FOUND;
                    break;
                case MessageTypes.LineEntryCount:
                    message = string.Format("{0}: {1}", LINE_ENTRY_COUNT, moreInfo[0]);
                    break;
                case MessageTypes.LineNotFound:
                    message = LINE_NOT_FOUND;
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void ShowFileContent(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                Console.WriteLine();

                string currentString = file.ReadLine();

                while (currentString != null)
                {
                    Console.WriteLine(currentString);
                    currentString = file.ReadLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }
    }
}
