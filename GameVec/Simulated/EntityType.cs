using System;
using System.Collections.Generic;

namespace WinXPP.GameVec.Simulated
{
    public class EntityType<T> : EntityType where T : Entity, new()
    {
        internal EntityType(string typeId/*, ModelAssembler modelAssembler*/) : base(typeId/*, modelAssembler*/) { }

        internal T Create()
        {
            return new T();
        }
    }

    public class EntityType
    {
        private static readonly Dictionary<Type, EntityType> _registered = new Dictionary<Type, EntityType>();
        
        public static EntityType<T> Register<T>(string typeId) where T : Entity, new() 
        {
            if(_registered.ContainsKey(typeof(T))) throw new EntityTypeDoubleRegistrationException();

            EntityType<T> entityType = new EntityType<T>(typeId);
            _registered.Add(typeof(T), entityType);
            return entityType;
        }

        /*private readonly ModelAssembler _modelAssembler;*/
        public string TypeId { get; }

        public EntityType(string typeId /*ModelAssembler modelAssembler*/)
        {
            TypeId = typeId;
            /*_modelAssembler = modelAssembler;*/
        }

        /*public IModel GetNewModel()
        {
            return _modelAssembler.Assemble();
        }*/
    }
}
