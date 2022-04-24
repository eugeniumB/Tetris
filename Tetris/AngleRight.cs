﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class AngleRight : Figure
    {
        public AngleRight(Point p) : base(p)
        {
            Points[1] = new Point(p.X + 1, p.Y);
            Points[2] = new Point(p.X, p.Y - 1);
            Points[3] = new Point(p.X, p.Y - 2);
            Draw();
        }

        public override void Rotate(Point[] newPoints)
        {
            if (newPoints[3].Y + 2 == newPoints[0].Y)
                SetRight(newPoints);
            else
                if (newPoints[3].Y - 2 == newPoints[0].Y)
                SetLeft(newPoints);
            else
                if (newPoints[3].X + 2 == newPoints[0].X)
                SetDefalt(newPoints);
            else
                SetConversaly(newPoints);
        }

        private void SetConversaly(Point[] newPoints)
        {
            newPoints[1].X -= 1;
            newPoints[1].Y -= 1;
            newPoints[2].X -= 1;
            newPoints[2].Y += 1;
            newPoints[3].X -= 2;
            newPoints[3].Y += 2;
        }

        private void SetDefalt(Point[] newPoints)
        {
            newPoints[1].X += 1;
            newPoints[1].Y += 1;
            newPoints[2].X += 1;
            newPoints[2].Y -= 1;
            newPoints[3].X += 2;
            newPoints[3].Y -= 2;
        }

        private void SetLeft(Point[] newPoints)
        {
            newPoints[1].X += 1;
            newPoints[1].Y -= 1;
            newPoints[2].X -= 1;
            newPoints[2].Y -= 1;
            newPoints[3].X -= 2;
            newPoints[3].Y -= 2;
        }

        private void SetRight(Point[] newPoints)
        {
            newPoints[1].X -= 1;
            newPoints[1].Y += 1;
            newPoints[2].X += 1;
            newPoints[2].Y += 1;
            newPoints[3].X += 2;
            newPoints[3].Y += 2;
        }

    }
}
