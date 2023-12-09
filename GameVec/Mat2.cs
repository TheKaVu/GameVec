using System.Collections.Generic;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents a 2x2 matrix.
    /// </summary>
    public struct Mat2
    {
        /// <summary>
        /// Size of 2x2 matrix.
        /// </summary>
        public static readonly int SIZE = 2;

        private double[] _mat;

        /// <summary>
        /// Gets the determinant of this matrix.
        /// </summary>
        /// <returns>The determinant of this matrix.</returns>
        public double Det => _mat[0] * _mat[3] - _mat[1] * _mat[2];

        /// <summary>
        /// Creates new <see cref="Mat2"/> structure using an array. Matrix cells are assigned from top to bottom, left to right.<para/>
        /// <b>Note: </b> Array must be of size 4.
        /// </summary>
        /// <param name="mat">Array containing cells of new matrix.</param>
        /// <exception cref="InvalidMatrixArrayException">Thrown when designated array isn't of size 4.</exception>
        public Mat2(double[] mat) {
            int s = SIZE * SIZE;
            if (mat.Length != s) throw new InvalidMatrixArrayException();

            _mat = new double[s];
            mat.CopyTo(_mat, 0);
        }

        /// <summary>
        /// Creates new <see cref="Mat2"/> structure with cells of specified values.
        /// </summary>
        public Mat2(
            double x1, double x2,
            double y1, double y2
            )
            : this(new double[] {
                x1, x2,
                y1, y2
            }) { }

        /// <summary>
        /// Gets or sets the value of this matrix's cell in specified location.
        /// </summary>
        /// <param name="r">Row (left to right).</param>
        /// <param name="c">Column (left to right).</param>
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
        public static Mat2 operator *(Mat2 mat, double d)
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
