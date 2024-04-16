using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public void Draw()
        {
            DrawerProvider.Drawer.Draw(X, Y, C);
        }

        public Point(int a, int b, char symb) 
        {
            X = a; 
            Y = b; 
            C = symb;
        }
    }
}
