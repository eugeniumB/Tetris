using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Stick : Figure
    {
        public Stick(Point p)
        {
            points[0] = new Point(p.x, p.y);
            points[1] = new Point(p.x, p.y + 1);
            points[2] = new Point(p.x, p.y + 2);
            points[3] = new Point(p.x, p.y + 3);
        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
                SetHorisontal();
            else
                SetVertical();
        }

        private void SetVertical()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = points[0].x;
                points[i].y = points[0].y + i;
            }
        }

        private void SetHorisontal()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i; 
            }
        }
    }
}
