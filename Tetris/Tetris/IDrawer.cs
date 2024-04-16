using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal interface IDrawer
    {
        void Draw(int x, int y, char sym);
        void Hide(int x, int y);
    }
}
