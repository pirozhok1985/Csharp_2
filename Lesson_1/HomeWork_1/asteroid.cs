using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class asteroid : DestructiveVisualObject
    {
        private Image img = Properties.Resources.asteroid;
        public asteroid(Point astPosition, Point astDirection, Size astSize)
            :base(astPosition, astDirection, astSize){}

        public override void Draw(Graphics g)
        {
            g.DrawImage(img, _Position.X,_Position.Y,_ObjSize.Width,_ObjSize.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            //_Position.Y += _Direction.Y;

            if (_Position.X <= 0)
                _Position.X = Game.Width + _ObjSize.Width;
            //if (_Position.Y <= 0)
            //    _Direction.Y *= -1;

            //if (_Position.X > Game.Width - _ObjSize.Width)
            //    _Direction.X *= -1;
            //if (_Position.Y >= Game.Height - _ObjSize.Height - 60)
            //    _Direction.Y *= -1;
        }

        public override void Reset()
        {
            base.Reset();
            Random r = new Random();
            _Position.X = 650 + r.Next(0, Game.__AstCount) * 40;
            _Position.Y = r.Next(0, Game.Height - 40);
        }
    }
}
