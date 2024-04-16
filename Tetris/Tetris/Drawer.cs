using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Drawer : IDrawer
    {
        public void Draw(int x, int y, char sym)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(sym);
            Console.SetCursorPosition(0, 0);
        }

        public void Hide(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}
