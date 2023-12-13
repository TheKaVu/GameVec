using System;

namespace WinXPP.GameVec.Simulated
{
    public abstract class Entity
    {
        /*protected IModel Model { get; }*/

        public Guid UUID { get; }
        public Vec3 Position { get; set; }
        public virtual Vec3 Rotation { get; set; }
        public virtual Vec3 Facing { get; set; }
        public virtual Vec3 Head { get => Position; }
        public virtual bool HasColision { get; }
        public EntityType Type { get; } 
        public EntityAttributes Attributes { get; }
        public IHitbox Hitbox { get; }

        /*public ModelState ModelState { get => Model.State; } */

        protected Entity(EntityType type, EntityAttributes attributes, IHitbox hitbox)
        {
            UUID = Guid.NewGuid();
            Type = type;
            Attributes = attributes;
            Hitbox = hitbox;
            /*Model = type.GetNewModel()*/
        }

        public abstract void Move(Vec3 force);
        public abstract void Rotate(Vec3 force);
        public abstract bool IsOnGround();
    }
}
