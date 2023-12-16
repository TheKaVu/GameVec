using System;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents a four-dimensional vector.
    /// </summary>
    public struct Vec4
    {
        /// <summary>
        /// Gets or sets the <c>W</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>W</c> coordinate of this vector.</returns>
        public double W { get; set; }

        /// <summary>
        /// Gets or sets the <c>X</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>X</c> coordinate of this vector.</returns>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the <c>Y</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>Y</c> coordinate of this vector.</returns>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the <c>Z</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>Z</c> coordinate of this vector.</returns>
        public double Z { get; set; }

        /// <summary>
        /// Gets the magnitude of this vector.
        /// </summary>
        /// <returns>Magnitude of this vector.</returns>
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

        /// <summary>
        /// Gets the three-dimensional part of this vector represented by <see cref="GameVec.Vec3"/> structure.
        /// </summary>
        /// <returns>Three-dimensional part of this vector.</returns>
        public Vec3 Vec3 => new Vec3(X, Y, Z);

        /// <summary>
        /// Origin point of four-dimensional space.
        /// </summary>
        public Vec4 Origin => new Vec4(0, 0, 0, 0);

        /// <summary>
        /// Creates new <see cref="Vec4"/> structure of specified coordinates.
        /// </summary>
        /// <param name="x">The <c>W</c> coordinate.</param>
        /// <param name="x">The <c>X</c> coordinate.</param>
        /// <param name="y">The <c>Y</c> coordinate.</param>
        /// <param name="z">The <c>Z</c> coordinate.</param>
        public Vec4(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates new <see cref="Vec4"/> structure from <see cref="GameVec.Vec3"/> structure and specified <c>Z</c> coordinate.
        /// </summary>
        /// <param name="vec3">Parential two-dimensional vector.</param>
        /// <param name="z">The <c>Z</c> coordinate.</param>
        public Vec4(double w, Vec3 vec3)
        {
            W = w;
            X = vec3.X;
            Y = vec3.Y;
            Z = vec3.Z;
        }

        /// <summary>
        /// Reverts this vector's coordinates.
        /// </summary>
        /// <returns>Reversed vector.</returns>
        public Vec4 Revert()
        {
            return -this;
        }

        /// <summary>
        /// Scales each coordinate of this vector with given multiplier.
        /// </summary>
        /// <param name="w"><c>W</c> coord multiplier.</param>
        /// <param name="x"><c>X</c> coord multiplier.</param>
        /// <param name="y"><c>Y</c> coord multiplier.</param>
        /// <param name="z"><c>Z</c> coord multiplier.</param>
        /// <returns>Scaled vector.</returns>
        public Vec4 Scale(double w, double x, double y, double z)
        {
            return new Vec4(W * w, X * x, Y * y, Z * z);
        }

        /// <summary>
        /// Scales this vector with designated one.
        /// </summary>
        /// <param name="scale">Vector this one will be scaled with.</param>
        /// <returns>Scaled vector.</returns>
        public Vec4 Scale(Vec4 scale)
        {
            return Scale(scale.W, scale.X, scale.Y, scale.Z);
        }

        /// <summary>
        /// Determines whether this vector is parallel to the specified one.
        /// </summary>
        /// <param name="other">Other vector represented by <see cref="Vec4"/> structure.</param>
        public bool IsParallelTo(Vec4 other)
        {
            double[] ratio = new double[] { W / other.W, X / other.X, Y / other.Y, Z / other.Z };
            foreach(var r in ratio)
                foreach(var r2 in ratio)
                    if(r != r2) return false;
            return true;
        }

        /// <summary>
        /// Adds two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Sum of two vectors.</returns>
        public static Vec4 operator +(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v2.W + v2.W, v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Substracts two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Difference of two vectors.</returns>
        public static Vec4 operator -(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v2.W - v2.W, v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Negates the following vector.
        /// </summary>
        /// <param name="vec">Vector to be negated.</param>
        /// <returns>Negated vector.</returns>
        public static Vec4 operator -(Vec4 vec)
        {
            return new Vec4(-vec.W, -vec.X, -vec.Y, -vec.Z);
        }

        /// <summary>
        /// Multiplies the following vector by scalar
        /// </summary>
        /// <param name="vec">Vector to be multiplied.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Multiplied vector.</returns>
        public static Vec4 operator *(Vec4 vec, double d)
        {
            return new Vec4(vec.W * d, vec.X * d, vec.Y * d, vec.Z * d);
        }

        /// <summary>
        /// Transforms the following vector using matrix represented by <see cref="Mat2"/> structure.
        /// </summary>
        /// <param name="mat">Matrix used for transformation.</param>
        /// <param name="vec">Vector to be transformed.</param>
        /// <returns>Transformed vector.</returns>
        public static Vec4 operator *(Mat4 mat, Vec4 vec)
        {
            return new Vec4(
                mat[0, 0] * vec.W + mat[0, 1] * vec.X + mat[0, 2] * vec.Y + mat[0, 3] * vec.Z,
                mat[1, 0] * vec.W + mat[1, 1] * vec.X + mat[1, 2] * vec.Y + mat[1, 3] * vec.Z,
                mat[2, 0] * vec.W + mat[2, 1] * vec.X + mat[2, 2] * vec.Y + mat[2, 3] * vec.Z,
                mat[3, 0] * vec.W + mat[3, 1] * vec.X + mat[3, 2] * vec.Y + mat[3, 3] * vec.Z
                );
        }

        /// <summary>
        /// Devides the following vector by scalar.
        /// </summary>
        /// <param name="vec">Vector to be devided.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Devided vector.</returns>
        public static Vec4 operator /(Vec4 vec, double d)
        {
            return new Vec4(vec.W / d, vec.X / d, vec.Y / d, vec.Z / d);
        }

        /// <summary>
        /// Returns the <see cref="string"/> representation of this particular vector.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of this vector.</returns>
        public override string ToString()
        {
            return $"[{W}, {X}, {Y}, {Z}]";
        }
    }
}
