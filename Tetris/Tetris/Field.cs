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
        static private bool[,] _heap = new bool[_height, _wight];

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
                _heap[p.Y, p.X] = true;
            }
        }

        public static bool HeapPointBusy(int x, int y)
        {
            return _heap[y, x];
        }

        public static void ClearDropFulfillmentStrings()
        {

            bool needReDraw = false;

            for (int y = _height - 1; y > 0; y--)
            {
                // в каждой строке проверяем, полностью ли она заполнена
                bool rowfill = true;
                for (int x = 0; x < _wight; x++)
                {
                    if (!HeapPointBusy(x, y))
                    {
                        rowfill = false;
                        break;
                    }
                }

                // если строка полностью заполнена, то сдвигаем на неё строки сверху
                if (rowfill)
                {
                    DropRow(y);
                    needReDraw = true;
                }

                // Перерисовываем поле, если сдвигали строки
                if (needReDraw)
                {
                    Draw();
                }

            }

        }

        private static void DropRow(int y)
        {
            for (int x = 0; x <= _wight; x++)
            {
                _heap[x, y] = _heap[x, y - 1];
            }
        }

        private static void Draw()
        {
            for (int x = 0; x < _wight; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    char sym = HeapPointBusy(x, y) ? '*' : ' ';
                    Console.SetCursorPosition(x, y);
                    Console.Write(sym);
                }
            }
        }
    }
}
