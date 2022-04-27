using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class Field
    {
        private static int _windowHeight = 30;
        private static int _windowWidth = 40;

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

    }
}
