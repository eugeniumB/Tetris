using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        protected Point[] points = new Point[4];

        public Point[]? PointArray => points;

        protected Figure(Point p)
        {
            points[0] = new Point(p.x, p.y);
        }

        public void Draw()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].DrawPoint();
            }
        }

        //public void Move(Direction dir)
        //{
        //    Hide();
        //    foreach (Point point in points)
        //    {
        //        point.Move(dir);
        //    }
        //    Draw();
        //}

        private void Move(Point[] pList, Direction dir)
        {
            foreach (Point point in pList)
            {
                point.Move(dir);
            }
        }

        public void Hide()
        {
            foreach (Point item in points)
            {
                item.Hide();
            }
        }

        public abstract void Rotate();

        internal void TryMove(Direction dir)
        {
            Hide();
            Point[] clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach (Point p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= Console.BufferWidth - 1 || p.y >= Console.BufferHeight - 1)
                    return false;
            }
            return true;
        }

        private Point[] Clone()
        {
            Point[] newPoint = new Point[points.Length];
            for (int i = 0; i < newPoint.Length; i++)
            {
                newPoint[i] = points[i];
            }
            return newPoint;
        }
    }
}