using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Stick:Figure
    {

        public Stick() : base() { }

        public Stick(int a, int b, char c) : base(a, b, c) { }

        public Stick(int a, int b, char c, byte r) : base(a, b, c, r) { }
        
        public override void SetPoints()
        {
            points[0] = new Point(X, Y, Sym);
            points[1] = new Point(X, Y+1, Sym);
            points[2] = new Point(X, Y+2, Sym);
            points[3] = new Point(X, Y+3, Sym);
        }

    }
}
