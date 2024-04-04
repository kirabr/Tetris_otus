using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class ZLeft : Figure
    {
        public ZLeft()
        {
        }

        public ZLeft(Figure figure) : base(figure)
        {
        }

        public ZLeft(int a, int b, char c) : base(a, b, c)
        {
        }

        public ZLeft(int a, int b, char c, byte rotation) : base(a, b, c, rotation)
        {
        }

        public override void SetPoints()
        {
            points[0] = new Point(X, Y, Sym);
            points[1] = new Point(X, Y + 1, Sym);
            points[2] = new Point(X + 1, Y + 1, Sym);
            points[3] = new Point(X + 1, Y + 2, Sym);
        }
    }
}
