using System.Windows;

namespace WinXPP.GameVec
{
    public struct Vec2
    {
        public double X { get; set; }
        public double Y { get; set; }
        public static Vec2 Origin => new Vec2(0, 0);

        public Vec2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vec2(Point point)
            : this(point.X, point.Y) { }

        public Vec2 Revert()
        {
            return -this;
        }

        public Vec2 Scale(double x, double y)
        {
            return new Vec2(X * x, Y * y);
        }
        public Vec2 Scale(Vec2 scale)
        {
            return Scale(scale.X, scale.Y);
        }

        public Point AsPoint()
        {
            return new Point(X, Y);
        }

        // Operators
        public static Vec2 operator +(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vec2 operator -(Vec2 v1, Vec2 v2)
        {
            return new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vec2 operator -(Vec2 vec)
        {
            return new Vec2(-vec.X, -vec.Y);
        }
        public static Vec2 operator *(Vec2 vec, double d)
        {
            return new Vec2(vec.X * d, vec.Y * d);
        }
        public static Vec3 operator *(Vec2 v1, Vec2 v2)
        {
            return new Vec3(0, 0, new Mat2(v1.X, v2.X, v1.Y, v2.Y).Det);
        }
        public static Vec2 operator *(Mat2 mat, Vec2 vec)
        {
            return new Vec2(
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y
                );
        }
        public static Vec2 operator /(Vec2 vec, double d)
        {
            return new Vec2(vec.X / d, vec.Y / d);
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}