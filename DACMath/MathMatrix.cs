namespace DACMath
{
    public class MathMatrix
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }

        // THIS RECTANGULAR ARRAY CAN BE CHANGED TO A JAGGED ARRAY
        // IF PERFORMANCE BECOMES AN ISSUE.
        private double[,] Elements;

        public double this[int r, int c]
        {
            get { return Elements[r, c]; }
            set { Elements[r, c] = value; }
        }

        public static MathMatrix operator *(MathMatrix A, MathMatrix B) => MatrixOperations.Multiply(A, B);

        public static MathMatrix operator +(MathMatrix A, MathMatrix B) => MatrixOperations.Add(A, B);

        public static MathMatrix operator -(MathMatrix A, MathMatrix B) => MatrixOperations.Subtract(A, B);

        private MathMatrix() { }

        public static MathMatrix CreateMatrix(int r, int c)
        {
            return new MathMatrix
            {
                RowCount = r,
                ColCount = c,
                Elements = new double[r, c]
            };
        }

        public void LoadMatrix(double[,] data)
        {
            Elements = data;
        }

        public static MathMatrix CreateMatrix(int r, int c, double initval)
        {
            MathMatrix retval = new MathMatrix
            {
                RowCount = r,
                ColCount = c,
                Elements = new double[r, c]
            };

            for (int rowidx = 0; rowidx < r; ++rowidx)
                for (int colidx = 0; colidx < c; ++colidx)
                    retval[rowidx, colidx] = initval;

            return retval;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public MathMatrix ColumnVector(int c)
        {
            MathMatrix retval = CreateMatrix(RowCount, 1);

            for (int rowidx = 0; rowidx < RowCount; ++rowidx)
                retval[rowidx, 0] = Elements[rowidx, c];

            return retval;
        }

        public void AssignColumn(MathMatrix m, int c)
        {
            for (int rowidx = 0; rowidx < RowCount; ++rowidx)
                Elements[rowidx, c] = m[rowidx, 0];
        }
    }
}
