using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chessboard
{
    static class UI
    {
        #region Constants
        public const ushort MAX_BOARD_WIDTH = 12;
        public const ushort MAX_BOARD_HEIGHT = 12;
        private const string SQUARE_SYMBOL = "  ";
        private const string NO_PARAMS_ERROR_MESSAGE = "Two parameters: WIDTH and HEIGHT are required.";
        private const string WIDTH_WORD = "Width";
        private const string HEIGHT_WORD = "Height";
        private const string REQUIREMENT_PHRASE = "must be an integer in range from 1 to";
        #endregion

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

        public static void PrintHelp(UserInputErrorTypes error)
        {            
            string invalidParamsErrorMessage = string.Format("{0} {1} {2}\n{3} {4} {5}", 
                WIDTH_WORD, REQUIREMENT_PHRASE, MAX_BOARD_WIDTH, HEIGHT_WORD, REQUIREMENT_PHRASE, MAX_BOARD_HEIGHT);            
            
            switch (error)
            {                
                case UserInputErrorTypes.InvalidParams:
                    Console.WriteLine(invalidParamsErrorMessage);
                    break;
                case UserInputErrorTypes.NoParamsGiven:
                    Console.WriteLine(NO_PARAMS_ERROR_MESSAGE);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        private const int BOARD_OFFSET_X = 4;
        private const int BOARD_OFFSET_Y = 2;               
    }
}
