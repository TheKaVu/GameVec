using System.Collections.Generic;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
    public struct Mat4
    {
        /// <summary>
        /// Size of 4x4 matrix.
        /// </summary>
        public static readonly int SIZE = 4;

        private double[] _mat;

        /// <summary>
        /// Gets the determinant of this matrix.
        /// </summary>
        /// <returns>The determinant of this matrix.</returns>
        public double Det
        {
            get
            {
                double det = 0;
                for (int i = 0; i < SIZE; i++)
                {
                    det += this[0, i] * this[1, (i + 1) % SIZE] * this[2, (i + 2) % SIZE] * this[3, (i + 3) % SIZE];
                    det -= this[3, i] * this[2, (i + 1) % SIZE] * this[1, (i + 2) % SIZE] * this[0, (i + 3) % SIZE];
                }
                return det;
            }
        }

        /// <summary>
        /// Creates new <see cref="Mat4"/> structure using an array. Matrix cells are assigned from top to bottom, left to right.<para/>
        /// <b>Note: </b> Array must be of size 16.
        /// </summary>
        /// <param name="mat">Array containing cells of new matrix.</param>
        /// <exception cref="InvalidMatrixArrayException">Thrown when designated array isn't of size 16.</exception>
        public Mat4(double[] mat)
        {
            int s = SIZE * SIZE;
            if (mat.Length != s) throw new InvalidMatrixArrayException();
            _mat = new double[s];
            mat.CopyTo(_mat, 0);
        }

        /// <summary>
        /// Creates new <see cref="Mat4"/> structure with cells of specified values.
        /// </summary>
        public Mat4(
            double w1, double w2, double w3, double w4,
            double x1, double x2, double x3, double x4,
            double y1, double y2, double y3, double y4,
            double z1, double z2, double z3, double z4
            )
            : this(new double[] {
                w1,  w2,  w3,  w4,
                x1,  x2,  x3,  x4,
                y1,  y2,  y3,  y4,
                z1,  z2,  z3,  z4 
            }) { }

        /// <summary>
        /// Gets or sets the value of this matrix's cell in specified location.
        /// </summary>
        /// <param name="r">Row (left to right)</param>
        /// <param name="c">Column (left to right)</param>
        /// <returns>The value of this matrix cell in specified location.</returns>
        public double this[int r, int c]
        {
            get { return _mat[r * SIZE + c]; }
            set { _mat[r * SIZE + c] = value; }
        }

        /// <summary>
        /// Multiplies following matrix by scalar.
        /// </summary>
        /// <param name="mat">Matrix to be multiplied.</param>
        /// <param name="d">Scalar.</param>
        /// <returns>Multiplied matrix.</returns>
        public static Mat4 operator *(Mat4 mat, double d)
        {
            for (int i = 0; i < mat._mat.Length; i++)
            {
                mat._mat[i] *= d;
            }
            return mat;
        }

        /// <summary>
        /// Multiplies two following matrices.
        /// </summary>
        /// <param name="m1">First matrix.</param>
        /// <param name="m2">Second matrix.</param>
        /// <returns>Dot product of two matrices.</returns>
        public static Mat4 operator *(Mat4 m1, Mat4 m2)
        {
            int s = SIZE * SIZE;
            Mat4 result = new Mat4(new double[s]);
            for (int i = 0; i < s; i++)
            {
                double sum = 0;
                for (int j = 0; j < SIZE; j++)
                {
                    sum += m1[i / SIZE, j] * m2[j, i % SIZE];
                }
                result._mat[i] = sum;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Mat4)) return false;
            Mat4 mat = (Mat4)obj;
            for (int i = 0; i < SIZE * SIZE; i++)
            {
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
