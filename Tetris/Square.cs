using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Square : Figure
    {
        public Square(Point p)
        {
            points[0] = new Point(p.x, p.y);
            points[1] = new Point(p.x + 1, p.y);
            points[2] = new Point(p.x, p.y + 1);
            points[3] = new Point(p.x + 1, p.y + 1);
        }

        public override void Rotate()
        {
        }
    }
}
