using System;

namespace TiltMaze
{
    class MazeChamber
    {
        static Random rand = new Random();

        public MazeChamber(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X { protected set; get; }

        public int Y { protected set; get; }

        public int Width { protected set; get; }

        public int Height { protected set; get; }

        public MazeChamber Chamber1 { protected set; get; }

        public MazeChamber Chamber2 { protected set; get; }

        public int Divide(bool divideWidth)
        {
            if (divideWidth)
            {
                int col = rand.Next(X + 1, X + Width - 1);
                Chamber1 = new MazeChamber(X, Y, col - X, Height);
                Chamber2 = new MazeChamber(col, Y, X + Width - col, Height);
                return col;
            }
            else
            {
                int row = rand.Next(Y + 1, Y + Height - 1);
                Chamber1 = new MazeChamber(X, Y, Width, row - Y);
                Chamber2 = new MazeChamber(X, row, Width, Y + Height - row);
                return row;
            }
        }
    }
}