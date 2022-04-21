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
        private char c;

        public Point(int x, int y, char symb = '*')
        {
            this.x = x;
            this.y = y;
            c = symb;
        }
        public void DrawPoint()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        internal void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.left:
                    x -= 1;
                    break;
                case Direction.right:
                    x += 1;
                    break;
                case Direction.down:
                    y += 1;
                    break;
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
