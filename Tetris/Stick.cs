using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Stick
    {
        Point[] points = new Point[4];

        public Stick(Point p)
        {
            points[0] = new Point(p.x, p.y);
            points[1] = new Point(p.x + 1, p.y);
            points[2] = new Point(p.x + 2, p.y);
            points[3] = new Point(p.x + 3, p.y);
        }
        public void DrawStick()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Draw();
            }
        }

    }
}
