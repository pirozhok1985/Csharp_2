using System.Drawing;

namespace AsteroidGame
{
    internal abstract class DestructiveVisualObject : myVisualObject, ICollision
    {
        public DestructiveVisualObject(Point objPosition, Point objDirection, Size objSize)
             : base(objPosition, objDirection, objSize){ }
        public Rectangle rect => new Rectangle(_Position, _ObjSize);

        public bool Collision(ICollision obj)
        {
            return obj.rect.IntersectsWith(this.rect);
        }
        public abstract void UpdateAfterCollision();
    }
}