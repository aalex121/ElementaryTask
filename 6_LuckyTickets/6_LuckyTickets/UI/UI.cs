using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    static class UI
    {
        #region Constants
        private const string RESULT_MESSAGE = "Total lucky tickets number";
        private const string REQUEST_PATH_MESSAGE = "Please provide a path to algorythm test file";
        private const string HELP_MESSAGE = "Please proide a valid path to .txt file, that contains \"moscow\" or \"piter\" word";
        private const string USER_INPUT_MESSAGE = "Path provided";
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key...";
        private const string EXCEPTION_MESSAGE = "Exception caught!";
        #endregion

        public static string RequestFilePath()
        {
            Console.WriteLine(REQUEST_PATH_MESSAGE);
            string input = Console.ReadLine();

            return input;
        }

        public static void PrintHelp(string userInput)
        {
            Console.WriteLine("{0}\n{1}: {2}", HELP_MESSAGE, USER_INPUT_MESSAGE, userInput);
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        public static void PrintTicketsCount(ulong count)
        {
            Console.WriteLine();
            Console.WriteLine("== {0}: {1} ==", RESULT_MESSAGE, count);
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        public static void PrintExceptionMessage(Exception ex)
        {
            Console.WriteLine(EXCEPTION_MESSAGE);
            Console.WriteLine(ex.ToString());
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }
    }
}
