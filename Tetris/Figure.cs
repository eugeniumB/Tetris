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

        public void Draw()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].DrawPoint();
            }
        }

        public void Move(Direction dir)
        {
            foreach (Point point in points)
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
     
    }
}