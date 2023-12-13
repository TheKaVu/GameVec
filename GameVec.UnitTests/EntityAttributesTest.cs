using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WinXPP.GameVec.Simulated;

namespace WinXPP.GameVec.UnitTests
{
    [TestClass]
    public class EntityAttributesTest
    {
        [TestMethod]
        public void TwoAttributesOfSameNameShouldEqual()
        {
            var attr1 = new EntityAttribute("myEntityAttr");
            var attr2 = new EntityAttribute("myEntityAttr");
            Assert.AreEqual(attr1, attr2);
        }

        [TestMethod]
        public void AttributesOfSameNameHaveSameHash()
        {
            HashSet<EntityAttribute> attrs = new HashSet<EntityAttribute>();
            var attr1 = new EntityAttribute("myEntityAttr");
            var attr2 = new EntityAttribute("myEntityAttr");
            attrs.Add(attr1);
            attrs.Add(attr2);
            Assert.AreEqual(attr1.GetHashCode(), attr2.GetHashCode());
            Assert.AreEqual(1, attrs.Count);
        }

        [TestMethod]
        public void EntityAttributesStoresAttributesProperly()
        {
            var attr1 = new EntityAttribute("attr1");
            var attr2 = new EntityAttribute("attr2");
            var attr3 = new EntityAttribute("attr3");

            var attributes = new EntityAttributes.Builder()
                .Add(attr1, 1.0)
                .Add(attr2, 7.5)
                .Add(attr3, 999999.99)
                .Build();
            Assert.AreEqual(1.0, attributes.Get(attr1));
            Assert.AreEqual(7.5, attributes.Get(attr2));
            Assert.AreEqual(999999.99, attributes.Get(attr3));
        }
    }
}
