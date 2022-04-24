using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGTH = 4;
        public Point[] Points = new Point[LENGTH];

        protected Figure(Point p)
        {
            Points[0] = new Point(p.X, p.Y);
        }

        public void Draw()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].DrawPoint();
            }
        }

        private void Move(Point[] pList, Direction dir)
        {
            foreach (Point point in pList)
            {
                point.Move(dir);
            }
        }

        public void Hide()
        {
            foreach (Point item in Points)
            {
                item.Hide();
            }
        }

        public abstract void Rotate(Point[] newPoints);

        internal void TryRotate()
        {
            Hide();
            Point[] clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }


        internal void TryMove(Direction dir)
        {
            Hide();
            Point[] clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach (Point p in pList)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
                    return false;
            }
            return true;
        }

        private Point[] Clone()
        {
            Point[] newPoint = new Point[Points.Length];
            for (int i = 0; i < newPoint.Length; i++)
            {
                newPoint[i] = new Point(Points[i]);
            }
            return newPoint;
        }
    }
}