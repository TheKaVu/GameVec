using System;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents a three-dimensional vector.
    /// </summary>
    public struct Vec3
    {
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
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Gets this vector projection on surface perpendicular to <c>X</c> axis, keeping the order of coordinates.
        /// </summary>
        /// <returns>This vector projection represented by <see cref="Vec2"/> structure.</returns>
        public Vec2 FaceX => new Vec2(Y, Z);

        /// <summary>
        /// Gets this vector projection on surface perpendicular to <c>Y</c> axis, keeping the order of coordinates.
        /// </summary>
        /// <returns>This vector projection represented by <see cref="Vec2"/> structure.</returns>
        public Vec2 FaceY => new Vec2(X, Z);

        /// <summary>
        /// Gets this vector projection on surface perpendicular to <c>Z</c> axis, keeping the order of coordinates.
        /// </summary>
        /// <returns>This vector projection represented by <see cref="Vec2"/> structure.</returns>
        public Vec2 FaceZ => new Vec2(X, Y);

        /// <summary>
        /// Origin point of three-dimensional space.
        /// </summary>
        public static Vec3 Origin { get => new Vec3(0, 0, 0); }

        /// <summary>
        /// Creates new <see cref="Vec3"/> structure of specified coordinates.
        /// </summary>
        /// <param name="x">The <c>X</c> coordinate.</param>
        /// <param name="y">The <c>Y</c> coordinate.</param>
        /// <param name="z">The <c>Z</c> coordinate.</param>
        public Vec3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates new <see cref="Vec3"/> structure from <see cref="Vec2"/> structure and specified <c>Z</c> coordinate.
        /// </summary>
        /// <param name="vec2">Parential two-dimensional vector.</param>
        /// <param name="z">The <c>Z</c> coordinate.</param>
        public Vec3(Vec2 vec2, double z)
        {
            X = vec2.X;
            Y = vec2.Y;
            Z = z;
        }

        /// <summary>
        /// Creates new <see cref="Vec3"/> structure from <see cref="Vec2"/> structure.<para/>
        /// <b>Note:</b> The <c>Z</c> coordinate will be set to 0.
        /// </summary>
        /// <param name="vec2">Parential two-dimensional vector.</param>
        public Vec3(Vec2 vec2) : this(vec2, 0) { }

        /// <summary>
        /// Reverts this vector's coordinates.
        /// </summary>
        /// <returns>Reversed vector.</returns>
        public Vec3 Revert()
        {
            return -this;
        }

        /// <summary>
        /// Scales each coordinate of this vector with given multiplier.
        /// </summary>
        /// <param name="x"><c>X</c> coord multiplier.</param>
        /// <param name="y"><c>Y</c> coord multiplier.</param>
        /// <param name="z"><c>Z</c> coord multiplier.</param>
        /// <returns>Scaled vector.</returns>
        public Vec3 Scale(double x, double y, double z)
        {
            return new Vec3(X * x, Y * y, Z * z);
        }

        /// <summary>
        /// Scales this vector with designated one.
        /// </summary>
        /// <param name="scale">Vector this one will be scaled with.</param>
        /// <returns>Scaled vector.</returns>
        public Vec3 Scale(Vec3 scale)
        {
            return Scale(scale.X, scale.Y, scale.Z);
        }

        /// <summary>
        /// Determines whether this vector is parallel to the specified one.
        /// </summary>
        /// <param name="other">Other vector represented by <see cref="Vec3"/> structure.</param>
        public bool IsParallelTo(Vec3 other)
        {
            return
                X / other.X == Y / other.Y &&
                Y / other.Y == Z / other.Z &&
                X / other.X == Z / other.Z;
        }

        /// <summary>
        /// Adds two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Sum of two vectors.</returns>
        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Substracts two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Difference of two vectors<./returns>
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Negates the following vector.
        /// </summary>
        /// <param name="vec">Vector to be negated.</param>
        /// <returns>Negated vector.</returns>
        public static Vec3 operator -(Vec3 vec)
        {
            return new Vec3(-vec.X, -vec.Y, -vec.Z);
        }

        /// <summary>
        /// Multiplies the following vector by scalar
        /// </summary>
        /// <param name="vec">Vector to be multiplied.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Multiplied vector.</returns>
        public static Vec3 operator *(Vec3 vec, double d)
        {
            return new Vec3(vec.X * d, vec.Y * d, vec.Z * d);
        }

        /// <summary>
        /// Crosses two following vectors in given order.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Cross product of two vectors.</returns>
        public static Vec3 operator *(Vec3 v1, Vec3 v2)
        {
            return new Vec3(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X
                );
        }

        /// <summary>
        /// Transforms the following vector using matrix represented by <see cref="Mat2"/> structure.
        /// </summary>
        /// <param name="mat">Matrix used for transformation.</param>
        /// <param name="vec">Vector to be transformed.</param>
        /// <returns>Transformed vector.</returns>
        public static Vec3 operator *(Mat3 mat, Vec3 vec)
        {
            return new Vec3(
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y + mat[0, 2] * vec.Z,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y + mat[1, 2] * vec.Z,
                mat[2, 0] * vec.X + mat[2, 1] * vec.Y + mat[2, 2] * vec.Z
                );
        }

        /// <summary>
        /// Devides the following vector by scalar.
        /// </summary>
        /// <param name="vec">Vector to be devided.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Devided vector.</returns>
        public static Vec3 operator /(Vec3 vec, double d)
        {
            return new Vec3(vec.X / d, vec.Y / d, vec.Z / d);
        }

        /// <summary>
        /// Returns the <see cref="string"/> representation of this particular vector.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of this vector.</returns>
        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }
    }
}