using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class SpaceShip : DestructiveVisualObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public SpaceShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Wheat, _Position.X, _Position.Y, _ObjSize.Width,_ObjSize.Height);
        }

        public override void Update()
        {
        }
        public void Up()
        {
            if (_Position.Y > 0) _Position.Y = _Position.Y - _Position.Y;
        }
        public void Down()
        {
            if (_Position.Y < Game.Height) _Position.Y = _Position.Y + _Direction.Y;
        }
        public void Die()
        {
        }
    }
}
