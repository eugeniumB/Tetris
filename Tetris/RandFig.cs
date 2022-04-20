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
        private Random _rand = new Random();

        public RandFig(Point p)
        {
            _p = p;
        }

        internal Figure GetNewFigure()
        {
            if (_rand.Next(0, 5) == 0)
                return new Square(_p);
            else
                if (_rand.Next(0, 5) == 1)
                return new Stick(_p);
            else
                if (_rand.Next(0, 5) == 2)
                return new Tripod(_p);
            else
                if (_rand.Next(0, 5) == 3)
                return new AngleLeft(_p);
            else 
                return new AngleRight(_p);
        }
    }
}
