using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_1
{
    class myVisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _ObjSize;
        private Image img = Image.FromFile("asteroid.png");

        public myVisualObject(Point pos, Point dir, Size oSize)
        {
            _Position = pos;
            _Direction = dir;
            _ObjSize = oSize;
        }

        public virtual void Draw(Graphics g)
        {
            //g.DrawEllipse(Pens.White,
            //               _Position.X,
            //               _Position.Y,
            //               _ObjSize.Width,
            //               _ObjSize.Height);
            g.DrawImage(img,
                        _Position.X,_Position.Y,
                        _ObjSize.Width,_ObjSize.Height);
        }

        public virtual void Update() 
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
    }
}
