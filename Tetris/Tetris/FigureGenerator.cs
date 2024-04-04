using System;

namespace Tetris
{
    internal class FigureGenerator
    {
        private readonly int _x;
        private readonly int _y;
        private readonly char _c;

        readonly Random _random = new Random();

        public FigureGenerator(int x, int y, char c)
        {
            this._x = x;
            this._y = y;
            this._c = c;
        }

        internal Figure GenerateFigure()
        {
            int figureCode = _random.Next(0, 2);
            switch (figureCode)
            {
                case 0:
                    byte rotation = (byte)_random.Next(0, 2);
                    return new Stick(_x, _y, _c, rotation);
                case 1:
                    return new Square(_x, _y, _c);
            }
            return null;
        }
    }
}