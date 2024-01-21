using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinXPP.GameVec.Simulated
{
	public class WorldGrid
	{
		private readonly HashSet<Entity> _entities = new HashSet<Entity>();

		public HashSet<Entity> Entities => new HashSet<Entity>(_entities);

        public void SpawnEntity<T> (EntityType<T> entityType) where T : Entity, new()
		{ 
			_entities.Add(entityType.Create());
		}

		public bool Exists(Entity entity)
		{
			return _entities.Contains(entity);
		}

		public void DeleteEntity(Entity entity)
		{
			_entities.Remove(entity);
		}

		public Entity GetEntity(Guid uuid)
		{
			foreach(var entity in _entities)
			{
				if (entity.UUID == uuid) return entity;
			}
		}
    }
}
