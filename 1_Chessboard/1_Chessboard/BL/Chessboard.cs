using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chessboard
{
    class Chessboard
    {
        public Chessboard(ushort width, ushort height)
        {
            Width = width;
            Height = height;
            Init(width, height, ref _squares);
        }
        
        public ushort Width { get; private set; }
        public ushort Height { get; private set; }

        public Square this[int col, int row]
        {
            get
            {
                return _squares[col, row];
            }
        }

        public class Square
        {
            public Square(int coordX, int coordY, bool isWhite)
            {
                PositionX = coordX;
                PositionY = coordY;
                IsWhite = isWhite;
            }

            public int PositionX { get; private set; }
            public int PositionY { get; private set; }
            public bool IsWhite { get; private set; }
        }

        private Square[,] _squares;

        private static void Init(int cols, int rows, ref Square[,] squares)
        {
            bool widthIsEven = cols % 2 == 0;

            squares = new Square[rows, cols];
            bool isWhite = true;

            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < cols; k++)
                {
                    squares[i, k] = new Square(k, i, isWhite);
                    isWhite = !isWhite;
                }

                if (widthIsEven)
                {
                    isWhite = !isWhite;
                }
            }
        }
    }
}
