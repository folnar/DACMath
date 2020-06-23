using System.Collections.Generic;

namespace DACMath
{
    public static class Sequences
    {
        public static MathMatrix SteppedSequence(double begin, double end, double step)
        {
            List<double> seq = new List<double>();
            for (double idx = begin; idx <= end; idx += step)
                seq.Add(idx);

            MathMatrix retval = MathMatrix.CreateMatrix(1, seq.Count);
            for (int idx = 0; idx < seq.Count; ++idx)
                retval[0, idx] = seq[idx];

            return retval;
        }
    }
}
