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

        internal Strike TryRotate()
        {
            Hide();
            Point[] clone = Clone();
            Rotate(clone);

            Strike result = VerifyPosition(clone);
            if (result == Strike.NOTHING)
                Points = clone;
            Draw();
            return result;
        }

        internal Strike TryMove(Direction dir)
        {
            Hide();
            Point[] clone = Clone();
            Move(clone, dir);

            Strike result = VerifyPosition(clone);
            if (result == Strike.NOTHING)
                Points = clone;
            Draw();
            return result;
        }

        private Strike VerifyPosition(Point[] pList)
        {
            foreach (Point p in pList)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width)
                    return Strike.BORDER_STRIKE;

                if (p.Y >= Field.Height)
                    return Strike.DOWN_STRIKE;

                if (Field.CheckStike(p) && p.Y <= 5)
                    return Strike.GAME_OVER;

                if (Field.CheckStike(p))
                    return Strike.HEAP_STRIKE;
            }
            return Strike.NOTHING;
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