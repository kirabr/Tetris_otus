using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Drawer : IDrawer
    {
        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write('*');
            Console.SetCursorPosition(0, 0);
        }

        public void Hide(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }

        public void FieldInit(int widht, int height)
        {
            Console.SetWindowSize(widht, height);
            Console.SetBufferSize(widht, height);
        }

        public void GameOver()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game over");
            Console.ReadLine();
        }
    }
}
