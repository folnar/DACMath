using System;
using System.Runtime.Serialization;

namespace DACMath
{
    public static class MatrixOperations
    {
        public static MathMatrix Transpose(MathMatrix inMatrix)
        {
            MathMatrix retval = MathMatrix.CreateMatrix(inMatrix.ColCount, inMatrix.RowCount);

            for (int m = 0; m < inMatrix.RowCount; ++m)
                for (int n = 0; n < inMatrix.ColCount; ++n)
                    retval[n, m] = inMatrix[m, n];

            return retval;
        }

        public static MathMatrix Multiply(MathMatrix A, MathMatrix B)
        {
            if (A.ColCount != B.RowCount)
                throw new InvalidMatrixMultiplicationDimensionsException();

            MathMatrix product = MathMatrix.CreateMatrix(A.RowCount, B.ColCount, 0);

            for (int r = 0; r < A.RowCount; ++r)
                for (int c = 0; c < B.ColCount; ++c)
                    for (int x = 0; x < B.RowCount; ++x)
                        product[r, c] += A[r, x] * B[x, c];

            return product;
        }

        public static MathMatrix Add(MathMatrix A, MathMatrix B)
        {
            if (A.RowCount != B.RowCount || A.ColCount != B.ColCount)
                throw new InvalidMatrixAddDimensionsException();

            MathMatrix sum = MathMatrix.CreateMatrix(A.RowCount, A.ColCount);

            for (int r = 0; r < A.RowCount; ++r)
                for (int c = 0; c < B.ColCount; ++c)
                    sum[r, c] = A[r, c] + B[r, c];

            return sum;
        }

        public static MathMatrix Subtract(MathMatrix A, MathMatrix B)
        {
            if (A.RowCount != B.RowCount || A.ColCount != B.ColCount)
                throw new InvalidMatrixAddDimensionsException();

            MathMatrix difference = MathMatrix.CreateMatrix(A.RowCount, A.ColCount);

            for (int r = 0; r < A.RowCount; ++r)
                for (int c = 0; c < B.ColCount; ++c)
                    difference[r, c] = A[r, c] - B[r, c];

            return difference;
        }

        // THE DOMAIN OF THIS FUNCTION AS OF NOW DOES NOT INCLUDE COMPLEX NUMBERS.
        public static MathMatrix Sqrt_Elmtwise(MathMatrix A)
        {
            MathMatrix sqrt = MathMatrix.CreateMatrix(A.RowCount, A.ColCount);

            for (int r = 0; r < A.RowCount; ++r)
                for (int c = 0; c < A.ColCount; ++c)
                    sqrt[r, c] = Math.Sqrt(A[r, c]);

            return sqrt;
        }

        public static MathMatrix Identity(int dim)
        {
            MathMatrix retval = MathMatrix.CreateMatrix(dim, dim, 0);
            for (int idx = 0; idx < dim; ++idx)
                retval[idx, idx] = 1;
            return retval;
        }
    }

    [Serializable]
    internal class InvalidMatrixAddDimensionsException : Exception
    {
        public InvalidMatrixAddDimensionsException()
        {
        }

        public InvalidMatrixAddDimensionsException(string message) : base(message)
        {
        }

        public InvalidMatrixAddDimensionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMatrixAddDimensionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class InvalidMatrixMultiplicationDimensionsException : Exception
    {
        public InvalidMatrixMultiplicationDimensionsException()
        {
        }

        public InvalidMatrixMultiplicationDimensionsException(string message) : base(message)
        {
        }

        public InvalidMatrixMultiplicationDimensionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMatrixMultiplicationDimensionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
