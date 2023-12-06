using System.Collections.Generic;

namespace WinXPP.GameVec
{
    public struct Mat2
    {
        public static readonly int SIZE = 2;

        private double[] _mat;

        public double Det => _mat[0] * _mat[3] - _mat[1] * _mat[2];

        public Mat2(double[] mat) {
            int s = SIZE * SIZE;
            if (mat.Length != s) throw new InvalidMatrixArrayException();

            _mat = new double[s];
            mat.CopyTo(_mat, 0);
        }

        public Mat2(
            double x1, double x2,
            double y1, double y2
            )
            : this(new double[] {
                x1, x2,
                y1, y2
            }) { }

        public double this[int r, int c]
        {
            get { return _mat[r * SIZE + c]; }
            set { _mat[r * SIZE + c] = value; }
        }
        public static Mat2 operator *(Mat2 mat, double d)
        {
            for (int i = 0; i < mat._mat.Length; i++)
            {
                mat._mat[i] *= d;
            }
            return mat;
        }
        public static Mat2 operator *(Mat2 m1, Mat2 m2)
        {
            int s = SIZE * SIZE;
            Mat2 result = new Mat2(new double[s]);
            for(int i = 0; i < s; i++)
            {
                double sum = 0;
                for(int j = 0; j < SIZE; j++)
                {
                    sum += m1[i / SIZE, j] * m2[j, i % SIZE];
                }
                result._mat[i] = sum;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Mat2)) return false;
            Mat2 mat = (Mat2)obj;
            for(int i = 0;i < SIZE*SIZE;i++) {
                if (_mat[i] != mat._mat[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return 1095348820 + EqualityComparer<double[]>.Default.GetHashCode(_mat);
        }
    }
}
