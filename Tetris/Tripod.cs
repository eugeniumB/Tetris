﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Tripod : Figure
    {
        public Tripod(Point p) : base(p)
        {
            points[1] = new Point(p.x + 1, p.y);
            points[2] = new Point(p.x - 1, p.y);
            points[3] = new Point(p.x, p.y - 1);
        }

        public override void Rotate()
        {
            if (points[3].y + 1 == points[0].y)
                SetRight();
            else
                if (points[3].y - 1 == points[0].y)
                SetLeft();
            else
                if (points[3].x + 1 == points[0].x)
                SetDefalt();
            else
                SetConversaly();
        }

        private void SetConversaly()
        {
            points[1].x -= 1;
            points[1].y -= 1;
            points[2].x += 1;
            points[2].y += 1;
            points[3].x -= 1;
            points[3].y += 1;
        }

        private void SetDefalt()
        {
            points[1].x += 1;
            points[1].y += 1;
            points[2].x -= 1;
            points[2].y -= 1;
            points[3].x += 1;
            points[3].y -= 1;
        }

        private void SetLeft()
        {
            points[1].x += 1;
            points[1].y -= 1;
            points[2].x -= 1;
            points[2].y += 1;
            points[3].x -= 1;
            points[3].y -= 1;
        }

        private void SetRight()
        {
            points[1].x -= 1;
            points[1].y += 1;
            points[2].x += 1;
            points[2].y -= 1;
            points[3].x += 1;
            points[3].y += 1;
        }

    }
}
