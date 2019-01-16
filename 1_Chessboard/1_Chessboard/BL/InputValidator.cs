using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chessboard
{
    static class InputValidator
    {
        const ushort MIN_USER_PARAMS_COUNT = 2;        

        public static bool UserInputIsValid(string[] args)
        {
            bool fOk = false;

            if (args.Length < MIN_USER_PARAMS_COUNT)
            {
                UI.PrintHelp(UserInputErrorTypes.NoParamsGiven);
            }
            else
            {
                fOk = InputParamsAreValid(args);
            }

            return fOk;
        }

        private static bool InputParamsAreValid(string[] args)
        {
            bool fOk = false;
            ushort inputWidth = 0;
            ushort inputHeight = 0;

            if (ushort.TryParse(args[0], out inputWidth) && ushort.TryParse(args[1], out inputHeight))
            {
                if (inputWidth > 0 && inputWidth <= UI.MAX_BOARD_WIDTH &&
                        inputHeight > 0 && inputHeight <= UI.MAX_BOARD_HEIGHT)
                {
                    fOk = true;
                }
            }

            return fOk;
        }
    }
}
