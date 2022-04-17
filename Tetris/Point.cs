using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Point
    {
        public int x, y;
        char c;

        public Point(int x, int y, char symb = '*')
        {
            this.x = x;
            this.y = y;
            c = symb;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

    }
}
