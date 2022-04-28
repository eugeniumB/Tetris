using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class Field
    {
        private static int _windowHeight = 10;
        private static int _windowWidth = 15;

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

        public static void CheckFullString()
        {
            for (int i = 1; i < Height; i++)
            {
                int num = 1;
                for (int j = 1; j < Width; j++)
                {
                    if (_heap[i][j])
                        num++;
                }
                if (num == Width)
                    BreakStroke(i);
            }
        }

        private static void BreakStroke(int numstroke)
        {
            Console.SetCursorPosition(0, numstroke);
            for (int i = 0; i < Width; i++)
            {
                Console.Write(" ");
            }
            for (int i = numstroke; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _heap[i][j] = false;
                }
            }
            for (int i = numstroke; i >= 1; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    if(_heap[i][j])
                    {
                        _heap[i + 1][j] = true;
                        _heap[i][j] = false;
                    }
                }
            }
        }
    }
}
