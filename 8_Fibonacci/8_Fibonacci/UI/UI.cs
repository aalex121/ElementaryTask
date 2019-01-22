using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    static class UI
    {
        #region Constants
        private const string HELP_MESSAGE = "Please provide two integers <Start Value> <End Value>";
        private const string USER_INPUT_MESSAGE = "Your input is";
        private const string FIBONACCI_ROW_MESSAGE = "============== Fibonacci row ==============";
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key...";
        private const string NOT_AVAILABLE = "N/A";
        private const string EMPTY_LIST_MESSAGE = "Nothing here!";
        #endregion

        public static void PrintHelp(params string[] values)
        {
            string startValue = NOT_AVAILABLE;
            string endValue = NOT_AVAILABLE;

            if (values.Length >= 1)
            {
                startValue = values[0];
            }

            if (values.Length >= 2)
            {
                endValue = values[1];
            }

            Console.WriteLine(HELP_MESSAGE);
            Console.WriteLine("{0}: {1}, {2}", USER_INPUT_MESSAGE, startValue, endValue);
            Console.ReadKey();
        }

        public static void PrintNumericRow(IEnumerable<int> numericRow)
        {
            if (numericRow.Count() == 0)
            {
                Console.WriteLine(EMPTY_LIST_MESSAGE);
                Console.ReadKey();

                return;
            }

            Console.WriteLine(FIBONACCI_ROW_MESSAGE);
            Console.WriteLine();

            foreach (int item in numericRow)
            {
                Console.Write("{0}, ", item);
            }

            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }
    }
}
