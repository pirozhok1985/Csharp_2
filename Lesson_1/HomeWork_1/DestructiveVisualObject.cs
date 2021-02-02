using System.Drawing;

namespace AsteroidGame
{
    internal abstract class DestructiveVisualObject : VisualObject, ICollision
    {
        public DestructiveVisualObject(Point objPosition, Point objDirection, Size objSize)
             : base(objPosition, objDirection, objSize){ }
        public Rectangle rect => new Rectangle(_Position, _ObjSize);

        public bool Enable { get; set; } = true;

        public bool Collision(ICollision obj)
        {
            return obj.rect.IntersectsWith(this.rect);
        }

        public virtual void Reset()
        {
            Enable = true;
        }
        //public abstract void UpdateAfterCollision();
    }
}