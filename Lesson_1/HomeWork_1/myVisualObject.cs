﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    abstract class myVisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _ObjSize;

        public myVisualObject(Point pos, Point dir, Size oSize)
        {
            _Position = pos;
            _Direction = dir;
            _ObjSize = oSize;
        }

        public abstract void Draw(Graphics g);

        public abstract void Update();

    }
}
