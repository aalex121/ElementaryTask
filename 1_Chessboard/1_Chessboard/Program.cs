using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            if (InputValidator.UserInputIsValid(args))
            {
                ushort width = ushort.Parse(args[0]);
                ushort height = ushort.Parse(args[1]);

                Chessboard board = new Chessboard(width, height);
                UI.DrawChessboard(board);
            }
            else
            {
                UI.PrintHelp(UserInputErrorTypes.InvalidParams);
            }
        }
    }
}
