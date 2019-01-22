using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    static class Application
    {
        #region Constants
        private const int MIN_VALID_ARGS_LENGTH = 2;
        #endregion

        public static void Run(string[] args)
        {
            int startValue;
            int endValue;

            if (!ValidateUserInput(args, out startValue, out endValue))
            {
                UI.PrintHelp(args);
                return;
            }

            FibonacciRow row = new FibonacciRow(startValue, endValue);

            UI.PrintNumericRow(row);
        }

        private static bool ValidateUserInput(string[] args, out int start, out int end)
        {
            bool isValid = false;
            start = 0;
            end = 0;

            if (args.Length >= MIN_VALID_ARGS_LENGTH)
            {
                isValid = int.TryParse(args[0], out start) && int.TryParse(args[1], out end);
            }

            return isValid;
        }
    }
}
