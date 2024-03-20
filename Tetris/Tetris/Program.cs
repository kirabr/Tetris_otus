using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            point.x = 3;
            point.y = 7;
            point.c = '*';
            point.Draw();

            Console.ReadLine();

        }
    }
}
