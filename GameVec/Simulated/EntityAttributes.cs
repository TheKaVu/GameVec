using System.Collections.Generic;

namespace WinXPP.GameVec.Simulated
{
    public class EntityAttributes
    {
        public static readonly EntityAttributes Empty = new EntityAttributes(new Dictionary<EntityAttribute, double>());

        private readonly Dictionary<EntityAttribute, double> _attributes;

        private EntityAttributes(Dictionary<EntityAttribute, double> attributes) {
            _attributes = new Dictionary<EntityAttribute, double>(attributes);
        }

        public double Get(EntityAttribute attr)
        {
            return _attributes[attr];
        }


        public class Builder
        {
            private readonly Dictionary<EntityAttribute, double> _attributes = new Dictionary<EntityAttribute, double>();
            
            public Builder() { }

            public Builder Add(EntityAttribute attr, double value)
            {
                _attributes[attr] = value;
                return this;
            }

            public EntityAttributes Build()
            {
                return new EntityAttributes(_attributes);
            }
        }
    }
}
