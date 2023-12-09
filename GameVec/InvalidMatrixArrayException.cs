using System;

namespace WinXPP.GameVec
{
    /// <summary>
    /// Represents error that occurs during an attempt of creating matrix out of invalid array.
    /// </summary>
    internal class InvalidMatrixArrayException : Exception
    {
        /// <summary>
        /// Initializes new instance of <see cref="InvalidMatrixArrayException"/> class.
        /// </summary>
        public InvalidMatrixArrayException() : base("Tried to create matrix out of array of unfitting size.") { }
    }
}
