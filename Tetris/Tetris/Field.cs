﻿using System;
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

        public static string Snapshot()
        {
            string snapshot = "Field snapshot";

            snapshot += "\n\n" + DateTime.Now.ToString() + "\n\n";
            for (int y = 0; y < _wight; y++)
            {
                for (int x = 0; x<_height; x++)
                {
                    snapshot += HeapPointBusy(x, y) ? "*" : " ";
                }
                snapshot += "\n";
            }

            return snapshot;
        }

        public static int With
        {
            get
            {
                return _wight;
            }
            set
            {
                _wight = Math.Max(value, 1);
                SetHeap();
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
                _height = Math.Max(value, 1);
                SetHeap();
                SetConsoleParametres();
            }
        }

        private static void SetHeap()
        {
            _heap = new bool[_height, _wight];
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
            return x < With && y<Heigt && _heap[y, x];
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
                    DropRows(y);
                    needReDraw = true;
                }

            }

            // Перерисовываем поле, если сдвигали строки
            if (needReDraw)
            {
                Draw();
            }

        }

        private static void DropRows(int bottom)
        {
            for (int y = bottom; y > 0; y--)
            {
                for (int x = 0; x < _wight; x++)
                {
                    _heap[y, x] = _heap[y - 1, x];
                }
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
