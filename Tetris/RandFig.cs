using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class RandFig
    {
        private Point _p;
        private Random _rand = new();

        public RandFig(Point p)
        {
            _p = p;
        }

        internal Figure GetNewFigure()
        {
            if (_rand.Next(0, 5) == 0)
            {
                Figure f = new Square(_p);
                RandomRotate(f);
                return f;
            }
            else
                if (_rand.Next(0, 5) == 1)
            {
                Figure f = new Stick(_p);
                RandomRotate(f);
                return f;
            }
            else
                if (_rand.Next(0, 5) == 2)
            {
                Figure f = new Tripod(_p);
                RandomRotate(f);
                return f;
            }
            else
                if (_rand.Next(0, 5) == 3)
            {
                Figure f = new AngleLeft(_p);
                RandomRotate(f);
                return f;
            }
            else
            {
                Figure f = new AngleRight(_p);
                RandomRotate(f);
                return f;
            }
        }

        private void RandomRotate(Figure f)
        {
            if (_rand.Next(0, 4) == 0)
                f.TryRotate();
            else
                if (_rand.Next(0, 5) == 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    f.TryRotate();
                }
            }
            else
                if (_rand.Next(0, 5) == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    f.TryRotate();
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    f.TryRotate();
                }
            }
        }
    }
}
