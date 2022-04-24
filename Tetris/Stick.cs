using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Stick : Figure
    {
        public Stick(Point p) : base(p)
        {
            Points[1] = new Point(p.X, p.Y + 1);
            Points[2] = new Point(p.X, p.Y + 2);
            Points[3] = new Point(p.X, p.Y + 3);
            Draw();
        }

        public override void Rotate(Point[] newPoints)
        {
            if (newPoints[0].X == newPoints[1].X)
                SetHorisontal(newPoints);
            else
                SetVertical(newPoints);
        }

        private void SetVertical(Point[] newPoints)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                newPoints[i].X = newPoints[0].X;
                newPoints[i].Y = newPoints[0].Y + i;
            }
        }

        private void SetHorisontal(Point[] newPoints)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                newPoints[i].Y = newPoints[0].Y;
                newPoints[i].X = newPoints[0].X + i; 
            }
        }
    }
}
