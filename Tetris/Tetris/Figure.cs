using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal abstract class Figure
    {

        // поворот фигуры от исходного положения по часовой стрелке
        // 0 - нет поворота, 1 - на 90 градусов, 2 - 180, 3 - на 270
        protected sbyte _r;

        protected int X { get; set; }
        protected int Y { get; set; }
        // см. _r
        protected byte R { get { return (byte)_r; } }
        protected char Sym { get; set; }
        protected Point[] points = new Point[4];

        public int Top
        {
            get
            {
                int min_y = points[0].Y;
                for (int i = 1; i < points.Length; min_y = Math.Min(min_y, points[i].Y), i++) ;
                return min_y;
            }
        }
        public int Bottom
        {
            get
            {
                int max_y = points[0].Y;
                for (int i = 1; i < points.Length; max_y = Math.Max(max_y, points[i].Y), i++) ;
                return max_y;
            }
        }
        public int Left
        {
            get
            {
                int min_x = points[0].X;
                for (int i = 1; i < points.Length; min_x = Math.Min(min_x, points[i].X), i++) ;
                return min_x;
            }
        }
        public int Right
        {
            get
            {
                int max_x = points[0].X;
                for (int i = 1; i < points.Length; max_x = Math.Max(max_x, points[i].X), i++) ;
                return max_x;
            }
        }

        public Point[] Points { get { return points; } }

        protected Figure() { }

        protected Figure(int a, int b, char c)
        {
            this.X = a;
            this.Y = b;
            this.Sym = c;
            this._r = 0;

            SetPoints();
        }

        protected Figure(int a, int b, char c, byte rotation) : this(a, b, c)
        {
            this._r = (sbyte)rotation;

            SetPoints();

            switch (rotation)
            {
                case 1:
                    Rotate(RotateDirection.ClockWise);
                    break;
                case 2:
                    Rotate(RotateDirection.ClockWise);
                    Rotate(RotateDirection.ClockWise);
                    break;
                case 3:
                    Rotate(RotateDirection.CounterClockWise);
                    break;
            }

        }

        protected Figure(Figure figure)
        {
            this.X = figure.X;
            this.Y = figure.Y;
            foreach (Point p in figure.Points)
            {
                Points[Array.IndexOf(figure.Points, p)] = new Point(p.X, p.Y, ' ');
            }
        }

        public abstract void SetPoints();

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        public void Hide()
        {
            // "стираем" прежнее положение фигуры
            foreach (Point p in points)
            {
                p.C = ' ';
                p.Draw();

            }
        }

        public void Move(MoveDirection moveDirection)
        {

            // "стираем" прежнее положение фигуры
            Hide();

            // определяем новое положение фигуры
            switch (moveDirection)
            {
                case MoveDirection.Left:
                    X -= 1;
                    foreach (Point p in points)
                    {
                        p.X -= 1;
                        p.C = Sym;
                    }
                    break;
                case MoveDirection.Right:
                    X += 1;
                    foreach (Point p in points)
                    {
                        p.X += 1;
                        p.C = Sym;
                    }
                    break;
                case MoveDirection.Down:
                    Y += 1;
                    foreach (Point p in points)
                    {
                        p.Y += 1;
                        p.C = Sym;
                    }
                    break;
                default: break;
            }

            // отрисовываем фигуру
            Draw();

            Console.SetCursorPosition(0, 0);

        }

        public virtual void Rotate(RotateDirection rotateDirection)
        {
            // вращаем, перерисовываем
            Hide();
            RotateFigurePoints(rotateDirection, points);
            Draw();

            // актуализируем поля и свойства
            X = Left;
            Y = Top;
            _r += (sbyte)rotateDirection;
            if (_r == -1) _r = 3;
            if (_r == 4) _r = 0;

        }

        public void RotateFigurePoints(RotateDirection rotateDirection, Point[] points)
        {
            // определяем новое положение фигуры:
            // - определяем длину и высоту фигуры
            // - помещаем фигуру ближе к центру квадратной матрицы (размерностью минимально достаточной для помещения)
            // - из матрицы получаем новое положение точек: "смотрим" на матрицу, выполнив "поворот смотрящего"
            // против направления вращения
            int lenght = Right - Left + 1;
            int height = Bottom - Top + 1;

            int matrix_dim = Math.Max(lenght, height);

            int[,] matrix = new int[matrix_dim, matrix_dim];
            int[,] resultMatrix = new int[matrix_dim, matrix_dim];

            int x_shift = matrix_dim - lenght;
            int y_shift = matrix_dim - height;

            int top = Top;
            int left = Left;

            foreach (Point p in points)
            {
                int x_matrix = p.Y - top + y_shift;
                int y_matrix = p.X - left + x_shift;
                matrix[x_matrix, y_matrix] = 1;
            }

            int pointIndex = 0;

            for (int x_matrix = 0; x_matrix < matrix_dim; x_matrix++)
            {
                for (int y_matrix = 0; y_matrix < matrix_dim; y_matrix++)
                {
                    switch (rotateDirection)
                    {
                        case RotateDirection.ClockWise:
                            resultMatrix[y_matrix, matrix_dim - 1 - x_matrix] = matrix[x_matrix, y_matrix];
                           break;
                        case RotateDirection.CounterClockWise:
                            resultMatrix[matrix_dim - 1 - y_matrix, x_matrix] = matrix[x_matrix, y_matrix];
                            break;
                    }
                }
            }

            for (int x_matrix = 0; x_matrix < matrix_dim; x_matrix++)
            {
                for (int y_matrix = 0; y_matrix < matrix_dim; y_matrix++)
                {
                    if (resultMatrix[x_matrix, y_matrix] == 1)
                    {
                        Point point = points[pointIndex];
                        point.X = y_matrix + X;
                        point.Y = x_matrix + Y;
                        point.C = Sym;

                        pointIndex++;
                    }
                }
            }

        }
    }
}
