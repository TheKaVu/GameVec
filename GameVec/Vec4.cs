namespace WinXPP.GameVec
{
    public struct Vec4
    {
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vec3 Vec3 => new Vec3(X, Y, Z);
        public Vec4 Origin => new Vec4(0, 0, 0, 0);

        public Vec4(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }
        public Vec4(double w, Vec3 Vec4)
        {
            W = w;
            X = Vec4.X;
            Y = Vec4.Y;
            Z = Vec4.Z;
        }

        public Vec4 Revert()
        {
            W = -W;
            X = -X;
            Y = -Y;
            Z = -Z;
            return this;
        }

        public Vec4 Scale(double w, double x, double y, double z)
        {
            W = w;
            X *= x;
            Y *= y;
            Z *= z;
            return this;
        }

        public static Vec4 operator +(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v2.W + v2.W ,v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vec4 operator -(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v2.W - v2.W, v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vec4 operator -(Vec4 vec)
        {
            return new Vec4(-vec.W, -vec.X, -vec.Y, -vec.Z);
        }
        public static Vec4 operator *(Vec4 vec, double d)
        {
            return new Vec4(vec.W * d, vec.X * d, vec.Y * d, vec.Z * d);
        }
        public static Vec4 operator *(Mat4 mat, Vec4 vec)
        {
            return new Vec4(
                mat[0, 0] * vec.W + mat[0, 1] * vec.X + mat[0, 2] * vec.Y + mat[0, 3] * vec.Z, 
                mat[1, 0] * vec.W + mat[1, 1] * vec.X + mat[1, 2] * vec.Y + mat[1, 3] * vec.Z,
                mat[2, 0] * vec.W + mat[2, 1] * vec.X + mat[2, 2] * vec.Y + mat[2, 3] * vec.Z,
                mat[3, 0] * vec.W + mat[3, 1] * vec.X + mat[3, 2] * vec.Y + mat[3, 3] * vec.Z
                );
        }

        public override string ToString()
        {
            return $"[{W}, {X}, {Y}, {Z}]";
        }
    }
}
