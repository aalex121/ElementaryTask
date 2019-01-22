using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    static class UI
    {
        const string RESULT_MESSAGE = "Total lucky tickets number";
        const string REQUEST_PATH_MESSAGE = "Please provide a path to algorythm test file";
        const string HELP_MESSAGE = "Please proide a valid path to .txt file, that contains \"moscow\" or \"piter\" word";
        const string USER_INPUT_MESSAGE = "Path provided";        

        public static string RequestFilePath()
        {
            Console.WriteLine(REQUEST_PATH_MESSAGE);
            string input = Console.ReadLine();

            return input;
        }

        public static void PrintHelp(string userInput)
        {
            Console.WriteLine("{0}\n{1}: {2}", HELP_MESSAGE, USER_INPUT_MESSAGE, userInput);
            Console.ReadKey();
        }

        public static void PrintTicketsCount(ulong count)
        {
            Console.WriteLine();
            Console.WriteLine("== {0}: {1} ==", RESULT_MESSAGE, count);
            Console.ReadKey();
        }
    }
}
