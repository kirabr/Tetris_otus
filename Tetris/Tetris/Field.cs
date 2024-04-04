using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {

        static private int _wight = 30;
        static private int _height = 40;
        static private bool[,] _heap = new bool[_wight, _height];

        public static int With
        {
            get
            {
                return _wight;
            }
            set
            {
                _wight = value;
                SetConsoleParametres();
            }
        }
        public static int Heigt
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                 SetConsoleParametres();
            }
        }

        private static void SetConsoleParametres()
        {
            Console.SetWindowSize(_wight, _height);
            Console.SetBufferSize(_wight, _height);
        }

        public static void FinishFigure(Figure figure)
        {
            foreach (Point p in figure.Points)
            {
                _heap[p.X, p.Y] = true;
            }
        }

        public static bool HeapPointBusy(int x, int y)
        {
            return _heap[x, y];
        }
    }
}
