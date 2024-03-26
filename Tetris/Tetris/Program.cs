using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Square square = new Square(4, 6, '*');
            //square.Draw();

            //ConsoleKeyInfo km;
            //do
            //{
            //    km = Console.ReadKey();
            //    switch (km.Key)
            //    {
            //        case ConsoleKey.LeftArrow:
            //            square.Move(MoveDirection.Left);
            //            break;
            //        case ConsoleKey.RightArrow:
            //            square.Move(MoveDirection.Right);
            //            break;
            //        case ConsoleKey.DownArrow:
            //            square.Move(MoveDirection.Down);
            //            break;
            //        case ConsoleKey.Enter:
            //            break;
            //        case ConsoleKey.UpArrow:
            //            square.Rotate(RotateDirection.ClockWise);
            //            break;
            //        default:
            //            break;
            //    }

            //} while (km.Key != ConsoleKey.Enter);

            Figure figure = new Stick(5, 6, '*');
            figure.Draw();

            ConsoleKeyInfo km;
            do
            {
                km = Console.ReadKey();
                switch (km.Key)
                {
                    case ConsoleKey.LeftArrow:
                        figure.Move(MoveDirection.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        figure.Move(MoveDirection.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        figure.Move(MoveDirection.Down);
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.UpArrow:
                        figure.Rotate(RotateDirection.ClockWise);
                        break;
                    case ConsoleKey.Spacebar:
                        figure.Rotate(RotateDirection.CounterClockWise);
                        break;
                    default:
                        break;
                }

            } while (km.Key != ConsoleKey.Enter);

            Console.ReadLine();
        }
    }
}
