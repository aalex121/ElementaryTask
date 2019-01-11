using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chessboard
{
    static class UI
    {
        const string SQUARE_SYMBOL = "  ";
        
        public static void DrawChessboard(Chessboard board)
        {
            int width = board.Width;
            int height = board.Height;

            Console.Clear();

            Console.SetCursorPosition(BOARD_OFFSET_X, BOARD_OFFSET_Y);
            
            for (int i = 0; i < height; i++)
            {
                Console.CursorLeft = BOARD_OFFSET_X;

                for (int k = 0; k < width; k++)
                {
                    if (board[i, k].IsWhite)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.Write(SQUARE_SYMBOL);                                    
                }

                Console.CursorTop++;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();            
        }

        public static bool UserInputIsValid(string[] args)
        {
            bool fOk = false;
            UserInputErrorTypes currentError = UserInputErrorTypes.None;

            if (args.Length < MIN_USER_PARAMS_COUNT)
            {
                currentError = UserInputErrorTypes.NoParamsGiven;
            }
            else
            {
                if (!InputParamsAreValid(args))
                {
                    currentError = UserInputErrorTypes.InvalidParams;
                }
            }
            

            if (currentError == UserInputErrorTypes.None)
            {
                fOk = true;
            }
            else
            {
                PrintHelp(currentError);
            }

            return fOk;
        }

        public static void PrintHelp(UserInputErrorTypes error)
        {
            string noParamsErrorMessage = "Two parameters: WIDTH and HEIGHT are required.";

            string invalidParamsErrorMessage = string.Format("WIDTH must be an integer in range from 1 to {0}\n", MAX_BOARD_WIDTH);
            invalidParamsErrorMessage += string.Format("HEIGHT must be an integer in range from 1 to {0}\n", MAX_BOARD_HEIGHT);
            
            switch (error)
            {
                case UserInputErrorTypes.None:
                    break;
                case UserInputErrorTypes.InvalidParams:
                    Console.WriteLine(invalidParamsErrorMessage);
                    break;
                case UserInputErrorTypes.NoParamsGiven:
                    Console.WriteLine(noParamsErrorMessage);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        private const int BOARD_OFFSET_X = 4;
        private const int BOARD_OFFSET_Y = 2;
        private const int MAX_BOARD_WIDTH = 16;
        private const int MAX_BOARD_HEIGHT = 16;
        private const int MIN_USER_PARAMS_COUNT = 2;

        private static bool InputParamsAreValid(string[] args)
        {
            bool fOk = false;
            int inputWidth = 0;
            int inputHeight = 0;

            if (Int32.TryParse(args[0], out inputWidth) && Int32.TryParse(args[1], out inputHeight))
            {
                if (inputWidth > 0 && inputWidth <= MAX_BOARD_WIDTH &&
                    inputHeight > 0 && inputHeight <= MAX_BOARD_HEIGHT)
                {
                    fOk = true;
                }
            }

            return fOk;
        }
    }
}
