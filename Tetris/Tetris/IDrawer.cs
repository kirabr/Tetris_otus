using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal interface IDrawer
    {
        void Draw(int x, int y);
        void Hide(int x, int y);
        void FieldInit(int widht, int height);
        void GameOver();
    }
}
