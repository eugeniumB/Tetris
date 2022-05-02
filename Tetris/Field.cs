using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class Field
    {
        private static int _windowHeight = 20;
        private static int _windowWidth = 20;
        private static int _score = 0;
        public static int Width
        {
            get 
            { 
                return _windowWidth;
            }
        }

        public static int Height
        {
            get
            {
                return _windowHeight; 
            }
        }

        public static int Score { get => _score; set => _score = value; }

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void AddFigure(Figure figure)
        {
            foreach (var p in figure.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static void CheckAndBreakFullString(Figure figure)
        {
            int yMax = 1;
            foreach(Point p in figure.Points)
            {
                yMax = Math.Max(yMax, p.Y);
            }
            for (int i = yMax - 4; i <= yMax; i++)
            {
                int num = 0;
                for (int j = 0; j < Width; j++)
                {
                    if (_heap[i][j])
                        num++;
                }
                if (num == Width)
                {
                    BreakStroke(i);
                    Score += 100;
                }
                Redraw(yMax);
            }
        }

        private static void Redraw(int yMax)
        {
            for (int j = yMax - 4; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        DrawerProvider.Drawer.DrawPoint(i, j);
                    else
                        DrawerProvider.Drawer.HidePoint(i, j);
                }
            }
        }

        private static void BreakStroke(int numstroke)
        {
            for (int i = numstroke; i > 0; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    if(i == 0)
                        _heap[i][j] = false;
                    else
                        _heap[i][j] = _heap[i - 1][j];
                }
            }
        }
    }
}
