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
            :base(astPosition, astDirection, astSize)
        {
            _Position = astPosition;
            _Direction = astDirection;
            _ObjSize = astSize;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img, _Position.X,_Position.Y,_ObjSize.Width,_ObjSize.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X <= 0)
                _Direction.X *= -1;
            if (_Position.Y <= 0)
                _Direction.Y *= -1;

            if (_Position.X > SplashScreen.Width - _ObjSize.Width)
                _Direction.X *= -1;
            if (_Position.Y >= SplashScreen.Heigth - _ObjSize.Height - 60)
                _Direction.Y *= -1;
        }

        public override void UpdateAfterCollision()
        {
            _Position.X = 1;
        }
    }
}
