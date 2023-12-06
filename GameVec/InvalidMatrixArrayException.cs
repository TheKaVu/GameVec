using System;

namespace WinXPP.GameVec
{
    internal class InvalidMatrixArrayException : Exception
    {
        public InvalidMatrixArrayException() : base("Tried to create matrix out of array of unfitting size.") { }
    }
}
