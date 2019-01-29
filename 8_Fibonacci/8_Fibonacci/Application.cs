using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    public static class Application
    {
        public static void Run(string[] args)
        {
            int startValue;
            int endValue;

            if (!InputValidator.ValidateUserInput(args, out startValue, out endValue))
            {
                UI.PrintHelp(args);
                return;
            }

            FibonacciRow row = new FibonacciRow(startValue, endValue);

            UI.PrintNumericRow(row);
        }
    }
}
