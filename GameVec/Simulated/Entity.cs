using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinXPP.GameVec.Simulated
{
    public abstract class Entity
    {
        public string Id { get; }
        public Vec3 Position { get; set; }
        public Vec3 Rotation { get; set; }
        public Vec3 Head { get; }
        public Vec3 Facing { get; set; }
        public bool AllowCollision { get; set; }
        public bool IsMovable { get; }

        public Entity(/*EntityType type*/)
        {
            /*
            Id = type.GenerateId();
            IsMovable = type.IsMovable;
             */
        }

        public abstract void Move(Vec3 movement);
    }
}
