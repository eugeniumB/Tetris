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
            private set 
            {
                _windowWidth = value;
                Console.SetWindowSize(_windowWidth, Field.Height);
                Console.SetBufferSize(_windowWidth, Field.Height);
            }
        }

        public static int Height
        {
            get
            {
                return _windowHeight; 
            }
            private set
            { 
                _windowHeight = value; 
                Console.SetWindowSize(_windowHeight, Field.Width);
                Console.SetBufferSize(_windowHeight, Field.Width);
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

        public static void AddFigure(Figure fig)
        {
            foreach (var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static void CheckAndBreakFullString()
        {
            for (int i = 1; i < Height; i++)
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
                Redraw();
            }
        }

        private static void Redraw()
        {
            for (int j = 1; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        Drawer.DrawPoint(i, j);
                    else
                        Drawer.HidePoint(i, j);
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
