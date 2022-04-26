using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Square : Figure
    {
        public Square(Point p) : base(p)
        {
            Points[1] = new Point(p.X + 1, p.Y);
            Points[2] = new Point(p.X, p.Y + 1);
            Points[3] = new Point(p.X + 1, p.Y + 1);
            Draw();
        }

        public override void Rotate(Point[] newPoints)
        {
        }
    }
}
