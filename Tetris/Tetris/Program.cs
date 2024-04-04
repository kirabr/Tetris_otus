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

            Field.With = 20;
            Field.Heigt = 25;

            for (int i = 0; i < 15; i++)
            {
                FigureGenerator fg = new FigureGenerator(Field.With / 2, 1, '*');
                Figure figure = fg.GenerateFigure();

                figure.Draw();

                while (ManeuverAvailable(figure, MoveDirection.Down))
                {
                    figure.Move(MoveDirection.Down);
                    if (Console.KeyAvailable)
                    {
                        MoveFigureByKey(figure);
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(200);
                }

                Field.FinishFigure(figure);

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
                    if (RotateAvailable(figure, RotateDirection.ClockWise))
                        figure.Rotate(RotateDirection.ClockWise);
                    break;
                case ConsoleKey.Spacebar:
                    if (RotateAvailable(figure, RotateDirection.CounterClockWise))
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
                    return !FigureStrike(figure, Strike.Left);
                case MoveDirection.Right:
                    return !FigureStrike(figure, Strike.Right);
                case MoveDirection.Down:
                    return !FigureStrike(figure, Strike.Bottom);
            }
            return false;
        }

        static bool RotateAvailable(Figure figure, RotateDirection rotateDirection)
        {

            Figure clone = new SpiritFigure(figure);
            clone.RotateFigurePoints(rotateDirection, clone.Points);
            foreach(Point p in clone.Points)
            {
                if (Field.HeapPointBusy(p.X, p.Y))
                    return false;
                if (p.X < 0 || p.X >= Field.With)
                    return false;
                if (p.Y >= Field.Heigt-1)
                    return false;
            }

            return true;

        }
    
        static bool FigureStrike(Figure figure, Strike strike)
        {
            int left = figure.Left;
            int right = figure.Right;
            int bottom = figure.Bottom;
            
            foreach(Point p in figure.Points)
            {
                if (strike == Strike.Left && p.X==left && (p.X == 0 || Field.HeapPointBusy(p.X-1,p.Y)))
                    return true;
                if (strike == Strike.Right && p.X == right && (p.X == Field.With-1 || Field.HeapPointBusy(p.X + 1, p.Y)))
                    return true;
                if (strike == Strike.Bottom && p.Y == bottom && (p.Y == Field.Heigt-1 || Field.HeapPointBusy(p.X, p.Y+1)))
                    return true;
            }

            return false;
        }
    }
}
