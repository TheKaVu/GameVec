using System.Windows;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents a two-dimensional vector.
    /// </summary>
    public struct Vec2
    {
        /// <summary>
        /// Gets or sets the <c>X</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>X</c> coordinate of this <see cref="Vec2"/> structure.</returns>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the <c>Y</c> coordinate of this vector.
        /// </summary>
        /// <returns><c>Y</c> coordinate of this <see cref="Vec2"/> structure.</returns>
        public double Y { get; set; }

        /// <summary>
        /// Origin point of two-dimensional space.
        /// </summary>
        public static Vec2 Origin => new Vec2(0, 0);

        /// <summary>
        /// Creates new <see cref="Vec2"/> structure of specified coordinates.
        /// </summary>
        /// <param name="x">The <c>X</c> coordinate.</param>
        /// <param name="y">The <c>Y</c> coordinate.</param>
        public Vec2(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates new <see cref="Vec2"/> structure by grabbing coordinates from <see cref="Point"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> structure the coordinates will be grabbed from.</param>
        public Vec2(Point point)
            : this(point.X, point.Y) { }

        /// <summary>
        /// Reverts this vector's coordinates.
        /// </summary>
        /// <returns>Reversed vector.</returns>
        public Vec2 Revert()
        {
            return -this;
        }

        /// <summary>
        /// Scales each coordinate of this vector with given multiplier.
        /// </summary>
        /// <param name="x"><c>X</c> coord multiplier.</param>
        /// <param name="y"><c>Y</c> coord multiplier.</param>
        /// <returns>Scaled vector.</returns>
        public Vec2 Scale(double x, double y)
        {
            return new Vec2(X * x, Y * y);
        }

        /// <summary>
        /// Scales this vector with designated one.
        /// </summary>
        /// <param name="scale">Vector this one will be scaled with.</param>
        /// <returns>Scaled vector.</returns>
        public Vec2 Scale(Vec2 scale)
        {
            return Scale(scale.X, scale.Y);
        }

        /// <summary>
        /// Converts this vector to <see cref="Point"/> structure.
        /// </summary>
        /// <returns><see cref="Point"/> representation of this vector.</returns>
        public Point AsPoint()
        {
            return new Point(X, Y);
        }

        /// <summary>
        /// Adds two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Sum of two vectors.</returns>
        public static Vec2 operator +(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Substracts two following vectors.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Difference of two vectors.</returns>
        public static Vec2 operator -(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Negates the following vector.
        /// </summary>
        /// <param name="vec">Vector to be negated.</param>
        /// <returns>Negated vector.</returns>
        public static Vec2 operator -(Vec2 vec)
        {
            return new Vec2(-vec.X, -vec.Y);
        }

        /// <summary>
        /// Multiplies the following vector by scalar
        /// </summary>
        /// <param name="vec">Vector to be multiplied.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Multiplied vector.</returns>
        public static Vec2 operator *(Vec2 vec, double d)
        {
            return new Vec2(vec.X * d, vec.Y * d);
        }

        /// <summary>
        /// Crosses two following vectors in given order.
        /// </summary>
        /// <param name="v1">First vector.</param>
        /// <param name="v2">Second vector.</param>
        /// <returns>Cross product of two vectors.</returns>
        public static Vec3 operator *(Vec2 v1, Vec2 v2)
        {
            return new Vec3(0, 0, new Mat2(v1.X, v2.X, v1.Y, v2.Y).Det);
        }

        /// <summary>
        /// Transforms the following vector using matrix represented by <see cref="Mat2"/> structure.
        /// </summary>
        /// <param name="mat">Matrix used for transformation.</param>
        /// <param name="vec">Vector to be transformed.</param>
        /// <returns>Transformed vector.</returns>
        public static Vec2 operator *(Mat2 mat, Vec2 vec)
        {
            return new Vec2(
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y
                );
        }

        /// <summary>
        /// Devides the following vector by scalar.
        /// </summary>
        /// <param name="vec">Vector to be devided.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Devided vector.</returns>
        public static Vec2 operator /(Vec2 vec, double d)
        {
            return new Vec2(vec.X / d, vec.Y / d);
        }

        /// <summary>
        /// Returns the <see cref="string"/> representation of this particular vector.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of this vector.</returns>
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}