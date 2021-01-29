using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Bullet : DestructiveVisualObject
    {
        public Bullet(Point Position, Point Direction, Size bulletSize)
            :base(Position, Direction, bulletSize){}

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, _Position.X, _Position.Y, _ObjSize.Width, _ObjSize.Height);
            g.DrawEllipse(Pens.Red, _Position.X, _Position.Y, _ObjSize.Width, _ObjSize.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            if (_Position.X > Game.Width)
                Enable = false;
        }

        public override void Reset()
        {
           base.Reset();
            _Position.X = Game.__ship.rect.X + 5;
            _Position.Y = Game.__ship.rect.Y;
        }
    }
}
