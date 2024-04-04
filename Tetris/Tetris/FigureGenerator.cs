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
            int figureCode = _random.Next(0, 7);
            switch (figureCode)
            {
                case 0:
                    byte rotation = (byte)_random.Next(0, 2);
                    return new Stick(_x, _y, _c, rotation);
                case 1:
                    return new Square(_x, _y, _c);
                case 2:
                    rotation = (byte)_random.Next(0, 4);
                    return new LLeft(_x, _y, _c, rotation);
                case 3:
                    rotation = (byte)_random.Next(0, 4);
                    return new LRight(_x, _y, _c, rotation);
                case 4:
                    rotation = (byte)_random.Next(0, 4);
                    return new T(_x, _y, _c, rotation);
                case 5:
                    rotation = (byte)_random.Next(0, 2);
                    return new ZLeft(_x, _y, _c, rotation);
                case 6:
                    rotation = (byte)_random.Next(0, 2);
                    return new ZRight(_x, _y, _c, rotation);
            }
            return null;
        }
    }
}