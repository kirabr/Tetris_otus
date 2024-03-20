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
            Point point = new Point(3,7,'*');
            point.Draw();

            Console.ReadLine();

        }
    }
}
