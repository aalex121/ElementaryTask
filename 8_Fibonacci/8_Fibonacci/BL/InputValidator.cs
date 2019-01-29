using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    public static class InputValidator
    {
        #region Constants
        private const int MIN_VALID_ARGS_LENGTH = 2;
        #endregion

        public static bool ValidateUserInput(string[] args, out int start, out int end)
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
