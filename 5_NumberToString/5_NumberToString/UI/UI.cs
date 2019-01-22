using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToString
{
    static class UI
    {
        #region Constants
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key...";
        private const string HELP_MESSAGE = "Please provide an integer in range:";
        #endregion

        public static void ShowMessage(UIMessageTypes message)
        {
            string messageText = string.Empty;

            switch (message)
            {   
                case UIMessageTypes.HelpMessage:
                    messageText = _helpMessage;
                    break;
                default:
                    break;
            }

            if (messageText != string.Empty)
            {
                Console.WriteLine(messageText);
                Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
                Console.ReadKey();
            }
        }

        public static void ShowResult(int numberInt, string numberString)
        {
            Console.WriteLine();
            Console.WriteLine("{0} -> {1}", numberInt, numberString);
            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        private static readonly string _helpMessage = string.Format("{0} {1} - {2}",
            HELP_MESSAGE, int.MinValue, int.MaxValue);
    }
}
