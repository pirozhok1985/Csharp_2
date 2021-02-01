using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _ObjSize;

        public VisualObject(Point pos, Point dir, Size oSize)
        {
            _Position = pos;
            _Direction = dir;
            _ObjSize = oSize;
        }

        public abstract void Draw(Graphics g);

        public abstract void Update();

    }
}
