using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinXPP.GameVec.Simulated;

namespace WinXPP.GameVec.IntegrationTests
{
    public class Entities
    {
        public static readonly EntityType<Asteroid> AsteroidEntity = EntityType.Register<Asteroid>("asteroid");
    }

    public class EAttributes
    {
        public static readonly EntityAttribute Size = new EntityAttribute("size");
    }

    public class Asteroid : Entity
    {
        public Asteroid() : base(Entities.AsteroidEntity, CreateAttributes(), null)
        {

        }

        public override bool IsOnGround()
        {
            throw new NotImplementedException();
        }

        public override void Move(Vec3 force)
        {
            throw new NotImplementedException();
        }

        public override void Rotate(Vec3 force)
        {
            throw new NotImplementedException();
        }

        private static EntityAttributes CreateAttributes()
        {
            return new EntityAttributes.Builder()
                .Add(EAttributes.Size, 4)
                .Build();
        }
    }


    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void Test()
        {
            Asteroid asteroid = new Asteroid();
            Assert.AreEqual(4, asteroid.Attributes.Get(EAttributes.Size));
        }
    }
}
