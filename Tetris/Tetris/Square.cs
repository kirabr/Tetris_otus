using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Square:Figure
    {

        public Square() : base() { }
        
        public Square(int a, int b, char c) : base(a,b,c) { }
        
        public override void SetPoints()
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x+1, y, sym);
            points[2] = new Point(x,y+1, sym);
            points[3] = new Point(x+1,y+1, sym);
        }

        public override void Rotate(RotateDirection rotateDirection) { }

    }
}
