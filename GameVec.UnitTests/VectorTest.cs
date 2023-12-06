using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WinXPP.GameVec.UnitTests
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void VectorShouldEqualVectorOfSameCoords()
        {
            Assert.AreEqual(new Vec2(3, 4), new Vec2(3, 4));
            Assert.AreEqual(new Vec3(3, 4, 5), new Vec3(3, 4, 5));
            Assert.AreEqual(new Vec4(1, 3, 4, 5), new Vec4(1, 3, 4, 5));
        }

        [TestMethod]
        public void VectorTimesNumberShouldEqualScaledVector()
        {
            Assert.AreEqual(new Vec2(6, 8), new Vec2(3, 4) * 2);
            Assert.AreEqual(new Vec3(6, 8, 10), new Vec3(3, 4, 5) * 2);
            Assert.AreEqual(new Vec4(2, 6, 8, 10), new Vec4(1, 3, 4, 5) * 2);
        }

        [TestMethod]
        [DataRow(2, 0, 0, 3, 6)]
        [DataRow(5, 0, 10, 0, 0)]
        [DataRow(3, 4, -4, 3, 25)]
        public void Vec2TimesVec2ReturnsCrossProduct(double x1, double y1, double x2, double y2, double z)
        {
            Vec3 result = new Vec2(x1, y1) * new Vec2(x2, y2);
            Assert.AreEqual(new Vec3(0, 0, z), result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void Vec3TimesVec3ReturnsCrossProduct()
        {
            Vec3 result = new Vec3(3, 4, 5) * new Vec3(7, 2, 1);
            Assert.AreEqual(new Vec3(-6, 32, -22), result);
            Console.WriteLine(result);
        }
    }
}
