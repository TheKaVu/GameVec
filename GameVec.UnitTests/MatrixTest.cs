using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinXPP.GameVec.UnitTests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void MatrixShouldEqualMatrixOfSameCoords()
        {
            Assert.AreEqual(new Mat2(1, 2, 3, 4), new Mat2(1, 2, 3, 4));
            Assert.AreEqual(new Mat3(1, 2, 3, 4, 5, 6, 7, 8, 9), new Mat3(1, 2, 3, 4, 5, 6, 7, 8, 9));

        }

        [TestMethod]
        public void Mat2TimesScalarShouldReturnScaledMat2()
        {
            Mat2 mat = new Mat2(new double[] {2, 4, 6, 8});
            Mat2 multipliedMat = mat * 5.0;
            Assert.AreEqual(multipliedMat, new Mat2(new double[]{ 10, 20, 30, 40}));
        }

        [TestMethod]
        public void Mat2TimesMat2ShouldReturnDotProduct()
        {
            Mat2 mat1 = new Mat2(new double[] { 2, 4, 6, 8 });
            Mat2 mat2 = new Mat2(new double[] { 1, 2, 3, 4 });
            Assert.AreEqual(new Mat2(new double[] { 14, 20, 30, 44 }), mat1 * mat2);
        }

        [TestMethod]
        [DataRow(new double[] { 1, 0, 0, 1 }, 3, 4, 3, 4)]
        [DataRow(new double[] { 2, 0, 0, 2 }, 3, 4, 6, 8)]
        [DataRow(new double[] { 0, -1, 1, 0 }, 3, 4, -4, 3)]
        public void Mat2TransformationOfVec2ShouldReturnDotProduct(double[] mat, double x, double y, double expX, double expY)
        {
            Assert.AreEqual(new Vec2(expX, expY), new Mat2(mat) * new Vec2(x, y));
        }

        [TestMethod]
        public void Mat3TransformationOfVec3ShouldReturnDotProduct()
        {
            Mat3 mat = new Mat3( 1, -2, 3, 2, 1, 4, 5, 6, 0 );
            Vec3 vec = new Vec3(3, 4, 5);
            Assert.AreEqual(new Vec3(10, 30, 39), mat * vec);
        }

        [TestMethod]
        public void Mat4TransformationOfVec4ShouldReturnDotProduct()
        {
            Mat4 mat = new Mat4(1, 2, 1, 3, -2, 5, 0, 4, 1, 0, 5, 0, -3, 4, 0, 0);
            Vec4 vec = new Vec4(1, 3, 4, 5);
            Assert.AreEqual(new Vec4(26, 33, 21, 9), mat * vec);
        }

        [TestMethod]
        public void MultitransformationOfVectorShouldProcessFromLeftToRight()
        {
            Mat2 rotation = new Mat2(0, -1, 1, 0);
            Mat2 shear= new Mat2(1, 1, 0, 1);
            Assert.AreEqual(new Vec2(-1, 2), shear * rotation * new Vec2(2, 3));
        }
    }
}
