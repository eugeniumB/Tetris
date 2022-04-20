using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Tripod : Figure
    {
        public Tripod(Point p)
        {
            points[0] = new Point(p.x, p.y);
            points[1] = new Point(p.x + 1, p.y);
            points[2] = new Point(p.x - 1, p.y);
            points[3] = new Point(p.x, p.y - 1);
        }

        public override void Rotate()
        {
            if (points[2].y == points[2].y - 1)
                SetRight();
            else
                if (points[2].y == points[2].y + 1)
                SetLeft();
            else
                if (points[3].y == points[2].y - 1)
                SetDefalt();
            else
                SetConversaly()

        }

        private void SetConversaly()
        {
            throw new NotImplementedException();
        }

        private void SetDefalt()
        {
            throw new NotImplementedException();
        }

        private void SetLeft()
        {
            throw new NotImplementedException();
        }

        private void SetRight()
        {
            throw new NotImplementedException();
        }

    }
}
