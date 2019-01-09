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
            if (UI.UserInputIsValid(args))
            {
                int width = Int32.Parse(args[0]);
                int height = Int32.Parse(args[1]);

                Chessboard board1 = new Chessboard(width, height);
                UI.DrawChessboard(board1);
            }
        }
    }
}
