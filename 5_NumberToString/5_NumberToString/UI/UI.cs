using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToString
{
    static class UI
    {
        const string PRESS_ANY_KEY_MESSAGE = "Press any key...";

        public static void ShowMessage(UIMessageTypes message)
        {
            string messageText = "";

            switch (message)
            {   
                case UIMessageTypes.None:
                    break;
                case UIMessageTypes.HelpMessage:
                    messageText = HELP_MESSAGE;
                    break;
                default:
                    break;
            }

            Console.WriteLine(messageText);
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        public static void ShowResult(int numberInt, string numberString)
        {
            Console.WriteLine();
            Console.WriteLine("{0} -> {1}", numberInt, numberString);
            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        private static readonly string HELP_MESSAGE = string.Format("Please input an integer between {0} and {1}",
            int.MinValue, int.MaxValue);
    }
}
