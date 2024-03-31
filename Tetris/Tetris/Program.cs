using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(30, 40);
            Figure figure1 = new Stick(5, 15, '*');
            figure1.Draw();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    MoveFigureByKey(figure1);
                }
            }

            for (int i = 0; i < 15; i++)
            {
                FigureGenerator fg = new FigureGenerator(20, 2, '*');
                Figure figure = fg.GenerateFigure();

                figure.Draw();

                while (ManeuverAvailable(figure, MoveDirection.Down))
                {
                    figure.Move(MoveDirection.Down);
                    if (Console.KeyAvailable)
                    {
                        MoveFigureByKey(figure);
                    }
                    Thread.Sleep(200);
                }

                Thread.Sleep(200);
            }

            Console.ReadLine();
        }

        static void MoveFigureByKey(Figure figure)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (ManeuverAvailable(figure, MoveDirection.Left))
                        figure.Move(MoveDirection.Left);
                    break;
                case ConsoleKey.RightArrow:
                    if (ManeuverAvailable(figure, MoveDirection.Right))
                        figure.Move(MoveDirection.Right);
                    break;
                case ConsoleKey.DownArrow:
                    if (ManeuverAvailable(figure, MoveDirection.Down))
                        figure.Move(MoveDirection.Down);
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.UpArrow:
                    if (RotateAvailable(figure))
                        figure.Rotate(RotateDirection.ClockWise);
                    break;
                case ConsoleKey.Spacebar:
                    if (RotateAvailable(figure))
                        figure.Rotate(RotateDirection.CounterClockWise);
                    break;
                default:
                    break;
            }
        }

        static bool ManeuverAvailable(Figure figure, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    return figure.Left > Console.WindowLeft + 1;
                case MoveDirection.Right:
                    return figure.Right < Console.WindowWidth - 1;
                case MoveDirection.Down:
                    return figure.Bottom < Console.WindowHeight - 1;
            }
            return false;
        }

        static bool RotateAvailable(Figure figure)
        {

            // если ширина фигуры не меньше её высоты, то повернуть гарантировано можно
            if (figure.Right - figure.Left >= figure.Bottom - figure.Top)
                return true;

            // если от стенки до противоположного края фигуры - половина или менее её максимального размера,
            // то повернуть не удастся
            float lenght = figure.Bottom - figure.Top + 1;
            int distance = Math.Min(figure.Right - Console.WindowLeft, (Console.WindowWidth - 1) - figure.Left);
            return distance > lenght / 2;

        }
    }
}
