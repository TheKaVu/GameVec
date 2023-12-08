namespace WinXPP.GameVec
{
    public struct Vec3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vec2 FaceX => new Vec2(Y, Z);
        public Vec2 FaceY => new Vec2(X, Z);
        public Vec2 FaceZ => new Vec2(X, Y);
        public static Vec3 Origin { get => new Vec3(0, 0, 0); }

        public Vec3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vec3(Vec2 vec2, double z)
        {
            X = vec2.X;
            Y = vec2.Y;
            Z = z;
        }
        public Vec3(Vec2 vec2) : this(vec2, 0) { }

        public Vec3 Revert()
        {
            return -this;
        }

        public Vec3 Scale(double x, double y, double z)
        {
            return new Vec3(X * x, Y * y, Z * z);
        }
        public Vec3 Scale(Vec3 scale)
        {
            return Scale(scale.X, scale.Y, scale.Z);
        }

        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vec3 operator -(Vec3 vec)
        {
            return new Vec3(-vec.X, -vec.Y, -vec.Z);
        }
        public static Vec3 operator *(Vec3 vec, double d)
        {
            return new Vec3(vec.X * d, vec.Y * d, vec.Z * d);
        }
        public static Vec3 operator *(Vec3 v1, Vec3 v2)
        {
            return new Vec3(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X
                );
        }
        public static Vec3 operator *(Mat3 mat, Vec3 vec)
        {
            return new Vec3(
                mat[0, 0] * vec.X + mat[0, 1] * vec.Y + mat[0, 2] * vec.Z,
                mat[1, 0] * vec.X + mat[1, 1] * vec.Y + mat[1, 2] * vec.Z,
                mat[2, 0] * vec.X + mat[2, 1] * vec.Y + mat[2, 2] * vec.Z
                );
        }
        public static Vec3 operator /(Vec3 vec, double d)
        {
            return new Vec3(vec.X / d, vec.Y / d, vec.Z / d);
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }
    }
}