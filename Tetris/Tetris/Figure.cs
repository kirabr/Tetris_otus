﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Figure
    {
        protected int x, y;
        protected byte r;
        protected char sym;
        protected Point[] points = new Point[4];


        protected Figure() { }

        protected Figure(int a, int b, char c)
        {
            this.x = a;
            this.y = b;
            this.sym = c;
            this.r = 0;

            SetPoints();
        }

        protected Figure(int a, int b, char c, byte rotation) : this(a, b, c)
        {
            this.r = rotation;

            SetPoints();
        }

        public virtual void SetPoints() { }

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        public void Move(MoveDirection moveDirection)
        {
            // "стираем" прежнее положение фигуры
            foreach (Point p in points)
            {
                p.c = ' ';
                p.Draw();
            }

            // определяем новое положение фигуры
            switch (moveDirection)
            {
                case MoveDirection.Left: 
                    x -= 1; 
                    foreach (Point p in points) 
                    { 
                        p.x -= 1;
                        p.c = sym;
                    }
                    break;
                case MoveDirection.Right:
                    x += 1; 
                    foreach (Point p in points) 
                    { 
                        p.x += 1;
                        p.c = sym;
                    }
                    break;
                case MoveDirection.Down: 
                    y += 1; 
                    foreach (Point p in points) 
                    { 
                        p.y += 1;
                        p.c = sym;
                    }
                    break;
                default: break;
            }

            // отрисовываем фигуру
            Draw();

        }

        public virtual void Rotate(RotateDirection rotateDirection)
        {
            // "стираем" прежнее положение фигуры
            // готовим данные для поворота фигуры - определяем минимальные и максимальные координаты x, y
            int xmin = points[0].x, xmax = points[0].x, ymin = points[0].y, ymax = points[0].y;
            foreach (Point p in points)
            {
                p.c = ' ';
                p.Draw();

                //xmin = Math.Min(xmin, p.x);
                xmax = Math.Max(xmax, p.x);
                //ymin = Math.Min(ymin, p.y);
                ymax = Math.Max(ymax, p.y);
            }

            // определяем новое положение фигуры:
            // - определяем длину и высоту фигуры как разность минимальных и максимальных координат
            // - помещаем фигуру ближе к центру матрицы 4х4
            // - из матрицы получаем новое положение точек
            int lenght = xmax - x + 1;
            int height = ymax - y + 1;

            int matrix_dim = Math.Max(lenght, height);

            int[,] matrix = new int[matrix_dim, matrix_dim];

            int x_figure_center = lenght - lenght / 2;
            int y_figure_center = height - height / 2;

            foreach (Point p in points)
            {
                int x_matrix = 1 + y_figure_center - (p.y - y);
                int y_matrix = 1 + x_figure_center - (p.x - x);
                matrix[x_matrix, y_matrix] = 1;
            }

            int pointIndex = 0;

            switch (rotateDirection)
            {
                case RotateDirection.ClockWise:
                    for (int x_matrix = 0; x_matrix < 4; x_matrix++)
                    {
                        for (int y_matrix = 0; y_matrix < 4; y_matrix++)
                        {
                            if (matrix[3 - x_matrix, y_matrix] == 0)
                                continue;

                            points[pointIndex].x = 3 - x_matrix + x;
                            points[pointIndex].y = y_matrix + y;
                            points[pointIndex].c = sym;

                            x = Math.Min(x, points[pointIndex].x);
                            y = Math.Min(y, points[pointIndex].y);

                            pointIndex++;

                        }
                    }
                    break;

                case RotateDirection.CounterClockWise:
                    for (int x_matrix = 0; x_matrix < 4; x_matrix++)
                    {
                        for (int y_matrix = 0; y_matrix < 4; y_matrix++)
                        {
                            if (matrix[x_matrix, 3- y_matrix] == 0)
                                continue;

                            points[pointIndex].x = x_matrix + x;
                            points[pointIndex].y = 3 - y_matrix + y;
                            points[pointIndex].c = sym;

                            x = Math.Min(x, points[pointIndex].x);
                            y = Math.Min(y, points[pointIndex].y);

                            pointIndex++;

                        }
                    }
                    break;
            }

            // отрисовываем фигуру
            Draw();

        }
    }
}
