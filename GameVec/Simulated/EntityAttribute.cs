using System;

namespace WinXPP.GameVec.Simulated
{
    public readonly struct EntityAttribute
    {
        public string Name { get; }

        public EntityAttribute(string name)
        {
            Name = name;
        }

        public static bool operator ==(EntityAttribute left, EntityAttribute right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(EntityAttribute left, EntityAttribute right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            return obj is EntityAttribute attribute &&
                   Name.Equals(attribute.Name);
        }

        public override int GetHashCode()
        {
            return 1969571243 + Name.GetHashCode();
        }
    }
}
