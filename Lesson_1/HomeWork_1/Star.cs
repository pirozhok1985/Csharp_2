﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, Size StarSize)
            :base(Position, Direction, StarSize){}

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.White, _Position.X, _Position.Y, _Position.X + _ObjSize.Width, _Position.Y + _ObjSize.Width);
            g.DrawLine(Pens.White, _Position.X, _Position.Y + _ObjSize.Width, _Position.X + _ObjSize.Width, _Position.Y);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            if (_Position.X < 0)
                _Position.X = Game.Width + _ObjSize.Width;
        }
    }
}
