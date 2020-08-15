using System;
using System.Collections.Generic;

namespace DACMath
{
    public static class Sequences
    {
        public static MathMatrix SteppedSequence(double begin, double end, double step)
        {
            List<decimal> seq = new List<decimal>();
            for (decimal idx = Convert.ToDecimal(begin); idx <= Convert.ToDecimal(end); idx += Convert.ToDecimal(step))
                seq.Add(idx);

            MathMatrix retval = MathMatrix.CreateMatrix(1, seq.Count);
            for (int idx = 0; idx < seq.Count; ++idx)
                retval[0, idx] = Convert.ToDouble(seq[idx]);

            return retval;
        }
    }
}
